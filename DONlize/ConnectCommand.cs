using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows;

namespace DONlize
{
    [Transaction(TransactionMode.Manual)]
    public class ConnectCommand : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            TaskDialog.Show("DONlize - Connect", "추후 기능 추가 예정입니다.");
            return Result.Succeeded;
        }
    }
}
