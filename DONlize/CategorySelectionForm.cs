using Form = System.Windows.Forms.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace DONlize
{
    public partial class CategorySelectionForm : Form
    {
        public List<BuiltInCategory> SelectedCategories { get; private set; } = new List<BuiltInCategory>();

        private Dictionary<string, List<BuiltInCategory>> categoryGroups = new Dictionary<string, List<BuiltInCategory>>
        {
            { "배관(Piping)", new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_PipeAccessory,
                    BuiltInCategory.OST_PipeFitting,
                    BuiltInCategory.OST_PipeInsulations,
                    BuiltInCategory.OST_PipeSegments,
                    BuiltInCategory.OST_PipingSystem
                }
            },
            { "덕트(Ducting)", new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_DuctAccessory,
                    BuiltInCategory.OST_DuctFitting,
                    BuiltInCategory.OST_DuctInsulations,
                    BuiltInCategory.OST_DuctCurves,
                    BuiltInCategory.OST_DuctTerminal
                }
            },
            { "전기(Electrical)", new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_ElectricalFixtures,
                    BuiltInCategory.OST_ElectricalEquipment,
                    BuiltInCategory.OST_LightingDevices,
                    BuiltInCategory.OST_LightingFixtures,
                    BuiltInCategory.OST_Conduit
                }
            },
            { "설비(Equipment)", new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_MechanicalEquipment,
                    BuiltInCategory.OST_PlumbingFixtures,
                    BuiltInCategory.OST_SpecialityEquipment
                }
            },
            { "기타(Misc)", new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_GenericModel,
                    BuiltInCategory.OST_Casework,
                    BuiltInCategory.OST_StructuralFraming,
                    BuiltInCategory.OST_Walls
                }
            }
        };

        public CategorySelectionForm()
        {
            InitializeComponent();
            InitComboBox();
            comboCategories.SelectedIndexChanged += ComboCategories_SelectedIndexChanged;
            clbCategories.ItemCheck += (s, e) => clbCategories.Invalidate(); // 한 번 클릭으로 반응하게 함
        }
        private Document _doc;

        public CategorySelectionForm(Document doc)
        {
            InitializeComponent();
            _doc = doc;

            InitComboBox();
            comboCategories.SelectedIndexChanged += ComboCategories_SelectedIndexChanged;
            clbCategories.ItemCheck += (s, e) => clbCategories.Invalidate();
        }

        private void InitComboBox()
        {
            comboCategories.Items.Clear();
            foreach (var key in categoryGroups.Keys)
            {
                comboCategories.Items.Add(key);
            }
            comboCategories.SelectedIndex = 0;
        }

        private void ComboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = comboCategories.SelectedItem.ToString();
            if (!categoryGroups.ContainsKey(selectedGroup)) return;

            clbCategories.Items.Clear();
            foreach (var bic in categoryGroups[selectedGroup])
            {
                string name = bic.ToString().Replace("OST_", "");
                clbCategories.Items.Add(name, false);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCategories.Items.Count; i++)
            {
                clbCategories.SetItemChecked(i, true);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCategories.Items.Count; i++)
            {
                clbCategories.SetItemChecked(i, false);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string selectedGroup = comboCategories.SelectedItem.ToString();
            var bicList = categoryGroups[selectedGroup];

            SelectedCategories = new List<BuiltInCategory>();

            for (int i = 0; i < clbCategories.Items.Count; i++)
            {
                if (clbCategories.GetItemChecked(i))
                {
                    SelectedCategories.Add(bicList[i]);
                }
            }

            if (SelectedCategories.Count == 0)
            {
                MessageBox.Show("하나 이상의 카테고리를 선택해주세요.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
