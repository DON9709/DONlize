namespace DONlize
{
    partial class ExcelExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EntireModel = new System.Windows.Forms.CheckBox();
            this.Selected = new System.Windows.Forms.CheckBox();
            this.CurrentView = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EntireModel
            // 
            this.EntireModel.AutoSize = true;
            this.EntireModel.Location = new System.Drawing.Point(44, 69);
            this.EntireModel.Name = "EntireModel";
            this.EntireModel.Size = new System.Drawing.Size(76, 16);
            this.EntireModel.TabIndex = 1;
            this.EntireModel.Text = "모델 전체";
            this.EntireModel.UseVisualStyleBackColor = true;
            // 
            // Selected
            // 
            this.Selected.AutoSize = true;
            this.Selected.Location = new System.Drawing.Point(190, 69);
            this.Selected.Name = "Selected";
            this.Selected.Size = new System.Drawing.Size(88, 16);
            this.Selected.TabIndex = 2;
            this.Selected.Text = "선택한 요소";
            this.Selected.UseVisualStyleBackColor = true;
            // 
            // CurrentView
            // 
            this.CurrentView.AutoSize = true;
            this.CurrentView.Location = new System.Drawing.Point(336, 69);
            this.CurrentView.Name = "CurrentView";
            this.CurrentView.Size = new System.Drawing.Size(64, 16);
            this.CurrentView.TabIndex = 3;
            this.CurrentView.Text = "현재 뷰";
            this.CurrentView.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(365, 146);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ExcelExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 207);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.CurrentView);
            this.Controls.Add(this.Selected);
            this.Controls.Add(this.EntireModel);
            this.Name = "ExcelExport";
            this.Text = "ExcelExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EntireModel;
        private System.Windows.Forms.CheckBox Selected;
        private System.Windows.Forms.CheckBox CurrentView;
        private System.Windows.Forms.Button btnNext;
    }
}