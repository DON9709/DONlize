using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace DONlize
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class ExcelImportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Excel Import", "추후 기능 추가 예정입니다.");
            return Result.Succeeded;
        }
    }
}
