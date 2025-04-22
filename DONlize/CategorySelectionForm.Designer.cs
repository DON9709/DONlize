using System.Windows.Forms;

namespace DONlize
{
    partial class CategorySelectionForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboCategories;
        private System.Windows.Forms.CheckedListBox listCategories;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMainCategory;
        private System.Windows.Forms.Label lblSubCategory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboCategories = new System.Windows.Forms.ComboBox();
            this.listCategories = new System.Windows.Forms.CheckedListBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMainCategory = new System.Windows.Forms.Label();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // comboCategories
            this.comboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategories.FormattingEnabled = true;
            this.comboCategories.Location = new System.Drawing.Point(100, 20);
            this.comboCategories.Name = "comboCategories";
            this.comboCategories.Size = new System.Drawing.Size(250, 21);
            this.comboCategories.TabIndex = 0;

            // listCategories
            this.listCategories.CheckOnClick = true;
            this.listCategories.FormattingEnabled = true;
            this.listCategories.Location = new System.Drawing.Point(20, 70);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(330, 199);
            this.listCategories.TabIndex = 1;

            // btnNext
            this.btnNext.Location = new System.Drawing.Point(275, 280);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(190, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            // lblMainCategory
            this.lblMainCategory.AutoSize = true;
            this.lblMainCategory.Location = new System.Drawing.Point(20, 23);
            this.lblMainCategory.Name = "lblMainCategory";
            this.lblMainCategory.Size = new System.Drawing.Size(55, 13);
            this.lblMainCategory.TabIndex = 4;
            this.lblMainCategory.Text = "대구분";

            // lblSubCategory
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Location = new System.Drawing.Point(20, 50);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(55, 13);
            this.lblSubCategory.TabIndex = 5;
            this.lblSubCategory.Text = "소구분";

            // CategorySelectionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 320);
            this.Controls.Add(this.lblSubCategory);
            this.Controls.Add(this.lblMainCategory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.listCategories);
            this.Controls.Add(this.comboCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategorySelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CategorySelection";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
