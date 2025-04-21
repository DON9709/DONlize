using System.Configuration.Assemblies;
using System.Reflection;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using System;
using System.Collections.Generic;
using Autodesk.Revit.UI.Events;

namespace DONlize
{
    public class MyApp : IExternalApplication
    {
        private static ParameterEditForm _form;
        private static List<ElementId> _pendingApply = new List<ElementId>();

        public Result OnStartup(UIControlledApplication app)
        {
            string tabName = "DONlize";
            string panelName = "Excel 관리";

            try { app.CreateRibbonTab(tabName); } catch { }
            RibbonPanel panel = app.CreateRibbonPanel(tabName, panelName);

            panel.AddItem(new PushButtonData("ExcelExportButton", "Excel Export", typeof(MyApp).Assembly.Location, "DONlize.ExcelExportCommand"));
            panel.AddItem(new PushButtonData("ExcelImport", "Excel Import", Assembly.GetExecutingAssembly().Location, "DONlize.ExcelImportCommand"));

            RibbonPanel editPanel = app.CreateRibbonPanel(tabName, "Model 편집");
            editPanel.AddItem(new PushButtonData("ParameterEditButton", "Parameter\n편집", Assembly.GetExecutingAssembly().Location, "DONlize.ParameterEditCommand"));
            editPanel.AddItem(new PushButtonData("ConnectButton", "Connect", Assembly.GetExecutingAssembly().Location, "DONlize.ConnectCommand"));
            PushButtonData alignButton = new PushButtonData("MultiAlignButton", "다중\nAlign", Assembly.GetExecutingAssembly().Location, "DONlize.MultiAlignCommand");
            editPanel.AddItem(alignButton);
            // 🔥 이벤트 등록
            app.ControlledApplication.DocumentChanged += OnDocumentChanged;
            app.Idling += OnIdling;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            app.ControlledApplication.DocumentChanged -= OnDocumentChanged;
            app.Idling -= OnIdling;
            return Result.Succeeded;
        }

        private void OnDocumentChanged(object sender, DocumentChangedEventArgs args)
        {
            if (_form == null || !_form.IsHandleCreated || _form.IsDisposed) return;
            if (!_form.chkAuto.Checked) return;

            ICollection<ElementId> added = args.GetAddedElementIds();
            if (added.Count > 0)
            {
                _pendingApply.AddRange(added);
            }
        }

        private void OnIdling(object sender, IdlingEventArgs args)
        {
            if (_pendingApply.Count == 0 || _form == null || !_form.chkAuto.Checked) return;

            UIApplication uiapp = sender as UIApplication;
            Document doc = uiapp?.ActiveUIDocument?.Document;
            if (doc == null) return;

            using (Transaction tx = new Transaction(doc, "Auto Apply Parameters"))
            {
                tx.Start();

                foreach (ElementId id in _pendingApply)
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

                        // BuiltInParameter 보정
                        if (param == null && paramName.Equals("Comments", StringComparison.OrdinalIgnoreCase))
                            param = elem.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                        else if (param == null && paramName.Equals("Mark", StringComparison.OrdinalIgnoreCase))
                            param = elem.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);

                        if (param == null || param.IsReadOnly) continue;

                        try
                        {
                            switch (param.StorageType)
                            {
                                case StorageType.String:
                                    param.Set(value);
                                    break;
                                case StorageType.Integer:
                                    if (int.TryParse(value, out int intval)) param.Set(intval);
                                    break;
                                case StorageType.Double:
                                    if (double.TryParse(value, out double dblval)) param.Set(dblval);
                                    break;
                            }
                        }
                        catch { }
                    }
                }

                tx.Commit();
            }

            _pendingApply.Clear();
        }

        // 폼 참조 설정
        public static void SetForm(ParameterEditForm form)
        {
            _form = form;
        }
    }
}
