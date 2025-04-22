using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DONlize
{
    public partial class CategorySelectionForm : System.Windows.Forms.Form
    {
        private readonly Document _doc;
        private readonly List<Element> _elements;
        public List<BuiltInCategory> SelectedCategories { get; private set; }

        private Dictionary<string, List<BuiltInCategory>> _categoryGroups;

        public CategorySelectionForm(Document doc, List<Element> elements)
        {
            InitializeComponent();

            _doc = doc;
            _elements = elements ?? new List<Element>();
            SelectedCategories = new List<BuiltInCategory>();

            InitializeCategoryGroups();

            comboCategories.Items.AddRange(_categoryGroups.Keys.ToArray());
            comboCategories.SelectedIndexChanged += ComboCategories_SelectedIndexChanged;
            btnCancel.Click += BtnCancel_Click;
            btnNext.Click += BtnNext_Click;

            // 첫 로딩 시 첫 항목 자동 선택
            if (comboCategories.Items.Count > 0)
                comboCategories.SelectedIndex = 0;
        }

        private void InitializeCategoryGroups()
        {
            _categoryGroups = new Dictionary<string, List<BuiltInCategory>>
            {
                ["건축"] = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_Walls,
                    BuiltInCategory.OST_Doors,
                    BuiltInCategory.OST_Windows
                },
                ["토목"] = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_StructuralFraming,
                    BuiltInCategory.OST_StructuralColumns
                },
                ["덕트"] = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_DuctCurves,
                    BuiltInCategory.OST_DuctFitting,
                    BuiltInCategory.OST_DuctAccessory
                },
                ["전기"] = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_ElectricalEquipment,
                    BuiltInCategory.OST_ElectricalFixtures,
                    BuiltInCategory.OST_LightingFixtures
                },
                ["배관"] = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_PipeCurves,
                    BuiltInCategory.OST_PipeFitting,
                    BuiltInCategory.OST_PlumbingFixtures
                },
                ["설비"] = new List<BuiltInCategory>
                {
                    BuiltInCategory.OST_MechanicalEquipment
                },
                ["기타"] = new List<BuiltInCategory>() // 나머지 비분류
            };
        }

        private void ComboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCategories.Items.Clear();

            if (_elements == null || _elements.Count == 0)
                return;

            string selected = comboCategories.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(selected)) return;

            var allCategories = _elements
                .Where(el => el.Category != null)
                .Select(el => el.Category)
                .Distinct()
                .ToList();

            foreach (var cat in allCategories)
            {
                int catId = cat.Id.IntegerValue;

                if (_categoryGroups.TryGetValue(selected, out var group) && group.Count > 0)
                {
                    if (group.Contains((BuiltInCategory)catId))
                        listCategories.Items.Add(cat.Name, false);
                }
                else if (selected == "기타")
                {
                    bool known = _categoryGroups.Values
                        .SelectMany(x => x)
                        .Any(bic => (int)bic == catId);

                    if (!known)
                        listCategories.Items.Add(cat.Name, false);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); // 직접 닫기
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (listCategories.CheckedItems.Count == 0)
            {
                MessageBox.Show("하나 이상의 카테고리를 선택하세요.");
                return;
            }

            if (_elements == null) return;

            var allCategories = _elements
                .Where(el => el.Category != null)
                .Select(el => el.Category)
                .Distinct()
                .ToList();

            foreach (object item in listCategories.CheckedItems)
            {
                string name = item.ToString();
                var match = allCategories.FirstOrDefault(cat => cat.Name == name);
                if (match != null)
                    SelectedCategories.Add((BuiltInCategory)match.Id.IntegerValue);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
