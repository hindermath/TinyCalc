# GEMINI.md - MicroCalc .NET 10

## Project Overview
MicroCalc .NET 10 is a modern C# port of the classic Borland Turbo Pascal MicroCalc spreadsheet application. It serves as a showcase for "agentic" porting, demonstrating how legacy code can be systematically transformed into a modern architecture.

- **Primary Language:** C# (.NET 10)
- **UI Framework:** [Terminal.Gui](https://github.com/gui-cs/Terminal.Gui)
- **Architecture:** Clean separation between Domain Logic (Core) and Presentation (TUI).
- **Legacy Context:** Based on the original `CALC.PAS`, `CALC.INC`, and `CALC.HLP` files.

## Project Structure
- `src/MicroCalc.Core/`: Core engine, spreadsheet model, formula parser (recursive descent), and evaluation logic.
- `src/MicroCalc.Tui/`: Terminal.Gui application, including grid rendering, command palette, and help system.
- `tests/MicroCalc.Core.Tests/`: Unit tests for engine calculations, persistence, and formatting.
- `tests/MicroCalc.Tui.Tests/`: Smoke tests for the TUI, including a dedicated `--smoke` mode.
- `docs/`: Documentation, migration plans, and help content.

## Key Commands

### Building the Project
```bash
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
```

### Running the Application
```bash
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

### Running Tests
```bash
dotnet test MicroCalc.sln --configuration Release --no-build
```

### Running Smoke Tests
Executes a non-interactive validation of the TUI components.
```bash
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

## Branching & PR Workflow
- Create working branches as `codex/<short-topic>`.
- Do not push directly to `main`; merge via pull request.
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<Thema>.<feature-branch>.md` so the delivered requirement scope stays traceable in the repository.

## Development Conventions

### Architecture & Design
- **Separation of Concerns:** Keep the `MicroCalc.Core` independent of `Terminal.Gui`. The Core should handle all data manipulation and calculations.
- **Formula Engine:** Follow the recursive descent pattern for parsing. Ensure any new functions or operators are added to the evaluator logic and backed by golden tests.
- **Persistence:** Use JSON (`.mcalc.json`) as the primary storage format.

### UI & Interaction
- **Keybindings:** Maintain compatibility with classic navigation (Arrow keys) and the `/` command palette trigger.
- **Help System:** Help content is loaded from `CALC.HLP`. Ensure the `HelpDocument` logic remains robust to file path resolutions.

### Testing
- **Golden Tests:** Use `FormulaGoldenTests.cs` for verifying complex formula calculations against expected outputs.
- **Smoke Tests:** Any major UI refactoring should be verified via the `--smoke` flag.
- **Coverage:** Aim for high coverage in the `Core` project, especially for the formula evaluator.

### Documentation & Language
- Provide documentation and didactic comments bilingually: German first, English second.
- Keep both language blocks at CEFR B2 readability.
- Maintain complete XML documentation for affected public APIs (`<summary>`, `<param>`,
  `<returns>`, `<exception>` where applicable).
- Do not suppress CS1591 globally.
- If API signatures or XML comments change, regenerate DocFX output in the same change set.

## Legacy Reference
The original Pascal files (`CALC.PAS`, `CALC.INC`) and the help file (`CALC.HLP`) are stored in the root directory. These are the source of truth for behavior and feature parity.

## Documentation
- `PLAN_MICROCALC_CSHARP_DOTNET10.md`: Detailed migration strategy and feature mapping.
- `CONTRIBUTING.md`: Guidelines for contributions.
- `README.md`: General project overview and quick start.

## Project Statistics

- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Each update must capture branch or phase, observable work window, production/test/documentation line counts, main work packages, and the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation. When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year under a TVoeD-style calendar.
