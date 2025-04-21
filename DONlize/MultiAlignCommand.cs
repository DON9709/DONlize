using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace DONlize
{
    [Transaction(TransactionMode.Manual)]
    public class MultiAlignCommand : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            try
            {
                // 여기에 기능 구현 ㄱㄱ
                TaskDialog.Show("DONlize - Align", "추후 기능 추가 예정입니다.");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("오류", ex.Message);
                return Result.Failed;
            }
        }
    }
}
