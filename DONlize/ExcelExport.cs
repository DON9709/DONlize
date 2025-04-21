using System;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace DONlize
{
    public partial class ExcelExport : System.Windows.Forms.Form
    {
        private Document _doc;

        public ExcelExport(Document doc)
        {
            InitializeComponent();
            _doc = doc;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (EntireModel.Checked)
            {
                // 모델 전체 선택 시 → 카테고리 선택 폼 띄우기
                var catForm = new CategorySelectionForm(_doc);
                if (catForm.ShowDialog() == DialogResult.OK)
                {
                    // 선택된 카테고리 확인 (일단 메시지박스로 확인)
                    var selected = catForm.SelectedCategories;
                    string msg = "선택된 카테고리:\n" + string.Join("\n", selected);
                    MessageBox.Show(msg, "카테고리 확인");

                    // 다음 단계 (파라메터 선택 폼)으로 이어질 예정
                }
            }
            else
            {
                MessageBox.Show("현재는 '모델 전체'만 구현되어 있습니다.", "알림");
            }
        }
    }
}
