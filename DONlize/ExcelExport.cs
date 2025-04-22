using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace DONlize
{
    public partial class ExcelExport : System.Windows.Forms.Form
    {
        private readonly Document _doc;
        private readonly List<Element> _elements;

        public bool ExportAll => checkBoxAll.Checked;
        public bool ExportSelected => checkBoxSelectedElements.Checked;
        public bool ExportCurrentView => checkBoxCurrentView.Checked;

        public ExcelExport(Document doc, List<Element> elements)
        {
            InitializeComponent();

            _doc = doc;
            _elements = elements;

            // 단일 선택 로직
            checkBoxAll.CheckedChanged += OnCheckChanged;
            checkBoxSelectedElements.CheckedChanged += OnCheckChanged;
            checkBoxCurrentView.CheckedChanged += OnCheckChanged;

            // 취소 버튼
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            // Next 버튼
            btnNext.Click += (s, e) =>
            {
                var categoryForm = new CategorySelectionForm(_doc, _elements);
                var result = categoryForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var selected = categoryForm.SelectedCategories;
                    // TODO: 이후 Excel 내보내기 로직 추가
                    DialogResult = DialogResult.OK; // 이 시점에만 창 닫기
                }

                // Cancel일 경우 ExcelExport는 계속 열려 있음
            };
        }

        private void OnCheckChanged(object sender, EventArgs e)
        {
            var changed = sender as CheckBox;
            if (changed.Checked)
            {
                if (changed != checkBoxAll) checkBoxAll.Checked = false;
                if (changed != checkBoxSelectedElements) checkBoxSelectedElements.Checked = false;
                if (changed != checkBoxCurrentView) checkBoxCurrentView.Checked = false;
            }
        }
    }
}
