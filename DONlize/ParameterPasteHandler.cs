using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace DONlize
{
    public class ParameterPasteHandler : IExternalEventHandler
    {
        private UIDocument _uidoc;
        private ParameterEditForm _form;

        public ParameterPasteHandler(UIDocument uidoc, ParameterEditForm form)
        {
            _uidoc = uidoc;
            _form = form;
        }

        public void Execute(UIApplication app)
        {
            Document doc = _uidoc.Document;
            var selection = _uidoc.Selection.GetElementIds();

            if (selection.Count == 0)
            {
                TaskDialog.Show("오류", "요소를 하나 이상 선택해주세요.");
                return;
            }

            int success = 0, fail = 0;

            using (Transaction tx = new Transaction(doc, "Paste Parameters"))
            {
                tx.Start();

                foreach (var id in selection)
                {
                    Element elem = doc.GetElement(id);

                    for (int i = 1; i <= 8; i++)
                    {
                        if (!_form.IsParameterChecked(i)) continue;

                        string paramName = _form.GetParameterName(i);
                        string value = _form.GetParameterValue(i);

                        if (string.IsNullOrWhiteSpace(paramName)) continue;

                        Parameter param = elem.LookupParameter(paramName);

                        // BuiltInParameter 예외 대응 (선택사항: 확장 가능)
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
                                    success++;
                                    break;
                                case StorageType.Integer:
                                    if (int.TryParse(value, out int intval))
                                    {
                                        param.Set(intval);
                                        success++;
                                    }
                                    else fail++;
                                    break;
                                case StorageType.Double:
                                    if (double.TryParse(value, out double dblval))
                                    {
                                        param.Set(dblval);
                                        success++;
                                    }
                                    else fail++;
                                    break;
                                default:
                                    fail++;
                                    break;
                            }
                        }
                        catch
                        {
                            fail++;
                        }
                    }
                }

                tx.Commit();
            }

            // 결과 메시지 조건부 표시
            if (fail > 0 || success == 0)
            {
                TaskDialog.Show("DONlize - 완료", $"파라메터 적용 완료\n성공: {success}, 실패: {fail}");
            }
        }

        public string GetName() => "Parameter Paste Handler";
    }
}
