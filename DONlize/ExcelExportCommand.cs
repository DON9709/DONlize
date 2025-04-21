using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace DONlize
{
    [Transaction(TransactionMode.Manual)]
    public class ExcelExportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            ExcelExport form = new ExcelExport(doc); // ← 여기서 넘겨주는 거야!
            form.ShowDialog();

            return Result.Succeeded;
        }

    }
}
