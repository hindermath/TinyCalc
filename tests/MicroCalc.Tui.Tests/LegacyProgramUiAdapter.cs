using System.Diagnostics;
using System.Runtime.ExceptionServices;
using MicroCalc.Core.Model;
using Terminal.Gui.App;
using Terminal.Gui.Drivers;
using Terminal.Gui.Input;
using Terminal.Gui.Testing;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

// DE: Nach dem Legacy-Rot nutzt der Adapter dieselben produktiven Session-Views, ohne Reflection oder Fachaufrufe.
// EN: After legacy red proof, the adapter uses the same production session views without reflection or business calls.
internal sealed class LegacyProgramUiAdapter : IDisposable
{
    private readonly TuiSession _session;
    private readonly SizeDetectionMode _originalSizeDetection;
    private readonly Stopwatch _elapsed = Stopwatch.StartNew();
    private Exception? _failure;
    private TimeSpan _lastStep;
    private bool _disposed;

    internal IApplication App { get; }
    internal Window Root => _session.Root;
    internal View? CurrentView => App.TopRunnableView;
    internal CellAddress Address => _session.Address;
    internal string GridText => _session.GridText;
    internal string StatusText => _session.StatusText;
    internal string MessageText => _session.MessageText;
    internal Cell CurrentCell => _session.CellSnapshot;
    internal bool AutoCalc => _session.AutoCalc;
    internal string Snapshot => System.Text.Json.JsonSerializer.Serialize(new
    {
        Selection = Address.ToString(), AutoCalc,
        Cells = Enumerable.Range(1, 21).SelectMany(row => "ABCDEFG".Select(column =>
            new { Address = $"{column}{row}", Cell = _session.SnapshotAt(new CellAddress(column, row)) })).ToArray(),
    });

    internal LegacyProgramUiAdapter(int width = 120, int height = 40)
    {
        _originalSizeDetection = Driver.SizeDetection;
        IApplication? initializingApp = null;
        try
        {
            // DE: Im Test die gesetzte ANSI-Größe nutzen, nicht die fremde Hosted-Konsole abfragen; Originalmodus danach wiederherstellen.
            // EN: Use the configured ANSI size in tests rather than polling the host console; restore the original mode afterwards.
            Driver.SizeDetection = SizeDetectionMode.AnsiQuery;
            initializingApp = Application.Create();
            App = initializingApp.Init(DriverRegistry.Names.ANSI);
            App.Screen = new System.Drawing.Rectangle(0, 0, width, height);
            _session = new TuiSession(App);
        }
        catch
        {
            try { initializingApp?.Dispose(); }
            finally { Driver.SizeDetection = _originalSizeDetection; }
            throw;
        }
    }

    internal void Send(Key key) => App.InjectKey(key);

    internal void Run(params Action<LegacyProgramUiAdapter>[] steps)
        => RunCore(false, steps);

    internal void RunToExit(params Action<LegacyProgramUiAdapter>[] steps)
        => RunCore(true, steps);

    private void RunCore(bool requireNaturalExit, Action<LegacyProgramUiAdapter>[] steps)
    {
        var pending = new Queue<Action<LegacyProgramUiAdapter>>(steps);
        _lastStep = _elapsed.Elapsed;
        App.Iteration += (_, _) =>
        {
            if (_failure is not null)
            {
                StopOwnedSessions();
                return;
            }
            if (pending.Count == 0)
            {
                // DE: Quit-Tests dürfen nicht durch automatische Testbereinigung scheinbar erfolgreich enden.
                // EN: Quit tests must not appear successful merely because fixture cleanup stopped the app.
                if (!requireNaturalExit) StopOwnedSessions();
                return;
            }
            if (_elapsed.Elapsed.TotalSeconds > 180 || (_elapsed.Elapsed - _lastStep).TotalSeconds > 30)
            {
                _failure = new TimeoutException("Owned UI session exceeded contract deadline.");
                StopOwnedSessions();
                return;
            }
            try
            {
                // DE: Vor Aufruf entnehmen, damit der echte verschachtelte Dialogloop den nächsten Schritt ausführen kann.
                // EN: Dequeue before dispatch so the real nested dialog loop can execute the next step.
                var action = pending.Dequeue();
                _lastStep = _elapsed.Elapsed;
                action(this);
            }
            catch (Exception exception)
            {
                _failure = exception;
                StopOwnedSessions();
            }
        };
        App.AddTimeout(TimeSpan.FromSeconds(30), () =>
        {
            if ((_elapsed.Elapsed - _lastStep).TotalSeconds < 30 && _elapsed.Elapsed.TotalSeconds < 180)
                return true;
            _failure ??= new TimeoutException("Owned UI session exceeded contract deadline.");
            StopOwnedSessions();
            return false;
        });
        App.Run(Root);
        if (_failure is not null)
            ExceptionDispatchInfo.Capture(_failure).Throw();
        Assert.Empty(pending);
    }

    internal static IEnumerable<View> Descendants(View root)
    {
        foreach (var child in root.SubViews)
        {
            yield return child;
            foreach (var descendant in Descendants(child))
                yield return descendant;
        }
    }

    private void StopOwnedSessions()
    {
        if (App.SessionStack is not { } stack)
            return;
        foreach (var token in stack.ToArray())
            if (token.Runnable is not null)
                App.RequestStop(token.Runnable);
    }

    public void Dispose()
    {
        if (_disposed)
            return;
        _disposed = true;
        try { _session.Dispose(); }
        finally
        {
            try { App.Dispose(); }
            finally { Driver.SizeDetection = _originalSizeDetection; }
        }
    }

}
