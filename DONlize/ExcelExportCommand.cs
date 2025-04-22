using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace DONlize
{
    [Transaction(TransactionMode.Manual)]
    public class ExcelExportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            // 선택된 요소 가져오기
            List<Element> selectedElements = uidoc.Selection
                .GetElementIds()
                .Select(id => doc.GetElement(id))
                .Where(e => e != null)
                .ToList();

            ExcelExport form = new ExcelExport(doc, selectedElements);
            form.ShowDialog();

            return Result.Succeeded;
        }
    }
}
