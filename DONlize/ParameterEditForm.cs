using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using WinForms = System.Windows.Forms;
using System.Windows.Forms;

namespace DONlize
{
    public partial class ParameterEditForm : WinForms.Form
    {
        private UIDocument _uidoc;
        private ExternalEvent _pasteEvent;
        private ParameterPasteHandler _pasteHandler;
        private readonly string historyPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "DONlize",
            "ParameterHistory.json"
        );

        public ParameterEditForm(UIDocument uidoc)
        {
            InitializeComponent();
            _uidoc = uidoc;
            this.TopMost = true;

            // 창 크기 고정
            this.FormBorderStyle = WinForms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Paste 핸들러 등록
            _pasteHandler = new ParameterPasteHandler(_uidoc, this);
            _pasteEvent = ExternalEvent.Create(_pasteHandler);

            // 텍스트박스 수동 입력 가능하게
            for (int i = 1; i <= 8; i++)
            {
                var valueBox = Controls.Find($"txtValue{i}", true).FirstOrDefault() as WinForms.TextBox;
                if (valueBox != null)
                {
                    valueBox.ReadOnly = false;
                    valueBox.Enabled = true;
                }
            }

            LoadPreviousParameters();

            // 폼 종료 시 자동 저장
            this.FormClosing += (s, e) => SaveCurrentParameters();
        }

        private void LoadPreviousParameters()
        {
            try
            {
                if (!File.Exists(historyPath)) return;
                string json = File.ReadAllText(historyPath);
                var parameters = JsonSerializer.Deserialize<List<string>>(json);
                for (int i = 1; i <= 8; i++)
                {
                    var paramBox = Controls.Find($"txtParameter{i}", true).FirstOrDefault() as WinForms.TextBox;
                    if (paramBox != null && i <= parameters.Count)
                        paramBox.Text = parameters[i - 1];
                }
            }
            catch { /* 예외 무시 */ }
        }

        private void SaveCurrentParameters()
        {
            try
            {
                var parameters = new List<string>();
                for (int i = 1; i <= 8; i++)
                {
                    var paramBox = Controls.Find($"txtParameter{i}", true).FirstOrDefault() as WinForms.TextBox;
                    parameters.Add(paramBox?.Text ?? "");
                }

                Directory.CreateDirectory(Path.GetDirectoryName(historyPath));
                File.WriteAllText(historyPath, JsonSerializer.Serialize(parameters));
            }
            catch { /* 예외 무시 */ }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Document doc = _uidoc.Document;
            var selection = _uidoc.Selection.GetElementIds();

            if (selection.Count != 1)
            {
                WinForms.MessageBox.Show("하나의 요소만 선택해주세요.");
                return;
            }

            Element elem = doc.GetElement(selection.First());

            for (int i = 1; i <= 8; i++)
            {
                var paramBox = Controls.Find($"txtParameter{i}", true).FirstOrDefault() as WinForms.TextBox;
                var valueBox = Controls.Find($"txtValue{i}", true).FirstOrDefault() as WinForms.TextBox;

                if (paramBox != null && valueBox != null && !string.IsNullOrWhiteSpace(paramBox.Text))
                {
                    string paramName = paramBox.Text;
                    Parameter param = elem.LookupParameter(paramName);

                    if (param == null && paramName.Equals("Comments", StringComparison.OrdinalIgnoreCase))
                        param = elem.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                    else if (param == null && paramName.Equals("Mark", StringComparison.OrdinalIgnoreCase))
                        param = elem.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);

                    if (param != null)
                    {
                        switch (param.StorageType)
                        {
                            case StorageType.String:
                                valueBox.Text = param.AsString();
                                break;
                            case StorageType.Integer:
                                valueBox.Text = param.AsInteger().ToString();
                                break;
                            case StorageType.Double:
                                valueBox.Text = param.AsValueString();
                                break;
                            default:
                                valueBox.Text = "(unsupported)";
                                break;
                        }
                    }
                    else
                    {
                        valueBox.Text = "(unavailable)";
                    }
                }
            }
        }
        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (chkLock.Checked)
            {
                MessageBox.Show("PASTE LOCK이 활성화되어 있습니다.", "DONlize - 경고");
                return;
            }

            _pasteEvent.Raise(); // 기존 ExternalEvent 실행
        }

        public string GetParameterName(int i)
        {
            var box = Controls.Find($"txtParameter{i}", true).FirstOrDefault() as WinForms.TextBox;
            return box?.Text;
        }

        public string GetParameterValue(int i)
        {
            var box = Controls.Find($"txtValue{i}", true).FirstOrDefault() as WinForms.TextBox;
            return box?.Text;
        }

        public bool IsParameterChecked(int i)
        {
            var chk = Controls.Find($"chk{i}", true).FirstOrDefault() as WinForms.CheckBox;
            return chk != null && chk.Checked;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
    }
}
