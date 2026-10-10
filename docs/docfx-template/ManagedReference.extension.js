// DE: DocFX 2.78 erzeugt Links auf leere Eltern-Namespaces ohne eigene Seite.
// EN: DocFX 2.78 links empty parent namespaces that have no generated page.
exports.postTransform = function (model) {
  var ns = model.namespace;
  if (ns && typeof ns.uid === 'string' && Array.isArray(ns.specName)) {
    var text = ns.uid.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    ns.specName.forEach(function (name) { name.value = text; });
  }
  return model;
};
