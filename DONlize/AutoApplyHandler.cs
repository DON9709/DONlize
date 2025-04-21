using System;
using System.Linq;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;

namespace DONlize
{
    public class AutoApplyHandler
    {
        private ParameterEditForm _form;

        public AutoApplyHandler(ParameterEditForm form)
        {
            _form = form;
        }

        public void Register(UIApplication app)
        {
            app.Application.DocumentChanged += OnDocumentChanged;
        }

        public void Unregister(UIApplication app)
        {
            app.Application.DocumentChanged -= OnDocumentChanged;
        }

        private void OnDocumentChanged(object sender, DocumentChangedEventArgs args)
        {
            Document doc = args.GetDocument();

            if (!_form.IsHandleCreated || _form.IsDisposed)
                return;

            if (!_form.chkAuto.Checked) return;

            ICollection<ElementId> addedIds = args.GetAddedElementIds();
            if (addedIds.Count == 0) return;

            using (Transaction tx = new Transaction(doc, "Auto Apply Parameters"))
            {
                tx.Start();

                foreach (ElementId id in addedIds)
                {
                    Element elem = doc.GetElement(id);
                    if (elem == null) continue;

                    for (int i = 1; i <= 8; i++)
                    {
                        if (!_form.IsParameterChecked(i)) continue;

                        string paramName = _form.GetParameterName(i);
                        string value = _form.GetParameterValue(i);

                        if (string.IsNullOrWhiteSpace(paramName)) continue;

                        Parameter param = elem.LookupParameter(paramName);
                        if (param == null || param.IsReadOnly) continue;

                        try
                        {
                            switch (param.StorageType)
                            {
                                case StorageType.String:
                                    param.Set(value); break;
                                case StorageType.Integer:
                                    if (int.TryParse(value, out int intval)) param.Set(intval); break;
                                case StorageType.Double:
                                    if (double.TryParse(value, out double dblval)) param.Set(dblval); break;
                            }
                        }
                        catch { /* 실패는 무시 */ }
                    }
                }

                tx.Commit();
            }
        }
    }
}
