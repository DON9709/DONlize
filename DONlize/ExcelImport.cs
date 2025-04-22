using System;
using System.Windows.Forms;

namespace DONlize
{
    public partial class ExcelImport : Form
    {
        public string SelectedExcelPath { get; private set; }

        public ExcelImport()
        {
            InitializeComponent();
            btnBrowse.Click += BtnBrowse_Click;
            btnCancel.Click += BtnCancel_Click;
            btnNext.Click += BtnNext_Click;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel 파일 (*.xlsx)|*.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dialog.FileName;
                SelectedExcelPath = dialog.FileName;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("엑셀 파일을 선택해주세요.", "알림");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
