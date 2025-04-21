using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DONlize
{
    public partial class ParameterSelectionForm : Form
    {
        public List<string> SelectedParameters { get; private set; }

        public ParameterSelectionForm(List<string> availableParameters)
        {
            InitializeComponent();
            SelectedParameters = new List<string>();

            // 파라메터 리스트를 listBox1에 넣기
            foreach (var param in availableParameters)
            {
                listBox1.Items.Add(param);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedItems = listBox1.SelectedItems.Cast<string>().ToList();
            foreach (var item in selectedItems)
            {
                if (!listBox2.Items.Contains(item))
                    listBox2.Items.Add(item);
            }

            foreach (var item in selectedItems)
            {
                listBox1.Items.Remove(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedItems = listBox2.SelectedItems.Cast<string>().ToList();
            foreach (var item in selectedItems)
            {
                if (!listBox1.Items.Contains(item))
                    listBox1.Items.Add(item);
            }

            foreach (var item in selectedItems)
            {
                listBox2.Items.Remove(item);
            }
        }

        private void btnAddall_Click(object sender, EventArgs e)
        {
            var itemsToMove = listBox1.Items.Cast<string>().ToList();
            foreach (var item in itemsToMove)
            {
                if (!listBox2.Items.Contains(item))
                    listBox2.Items.Add(item);
            }
            listBox1.Items.Clear();
        }

        private void btnDeleteall_Click(object sender, EventArgs e)
        {
            var itemsToMove = listBox2.Items.Cast<string>().ToList();
            foreach (var item in itemsToMove)
            {
                if (!listBox1.Items.Contains(item))
                    listBox1.Items.Add(item);
            }
            listBox2.Items.Clear();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SelectedParameters.Clear();

            foreach (var item in listBox2.Items)
            {
                SelectedParameters.Add(item.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
