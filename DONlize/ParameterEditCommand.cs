using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows.Forms;

namespace DONlize
{
    [Transaction(TransactionMode.Manual)]
    public class ParameterEditCommand : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            try
            {
                UIDocument uidoc = commandData.Application.ActiveUIDocument;

                ParameterEditForm form = new ParameterEditForm(uidoc);
                form.Show();

                // 🔥 MyApp.cs에 폼 넘겨주기
                MyApp.SetForm(form);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생: " + ex.Message);
                return Result.Failed;
            }
        }
    }
}
