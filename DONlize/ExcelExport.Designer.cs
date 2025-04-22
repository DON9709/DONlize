using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DONlize
{
    partial class ExcelExport : Form
    {
        private System.ComponentModel.IContainer components = null;
        private CheckBox checkBoxAll;
        private CheckBox checkBoxSelectedElements;
        private CheckBox checkBoxCurrentView;
        private Button btnNext;
        private Button btnCancel;

        /// <summary>
        /// 리소스 정리
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너 생성 코드

        private void InitializeComponent()
        {
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectedElements = new System.Windows.Forms.CheckBox();
            this.checkBoxCurrentView = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(26, 26);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(73, 17);
            this.checkBoxAll.TabIndex = 0;
            this.checkBoxAll.Text = "모델 전체";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxSelectedElements
            // 
            this.checkBoxSelectedElements.AutoSize = true;
            this.checkBoxSelectedElements.Location = new System.Drawing.Point(111, 26);
            this.checkBoxSelectedElements.Name = "checkBoxSelectedElements";
            this.checkBoxSelectedElements.Size = new System.Drawing.Size(84, 17);
            this.checkBoxSelectedElements.TabIndex = 1;
            this.checkBoxSelectedElements.Text = "선택한 요소";
            this.checkBoxSelectedElements.UseVisualStyleBackColor = true;
            // 
            // checkBoxCurrentView
            // 
            this.checkBoxCurrentView.AutoSize = true;
            this.checkBoxCurrentView.Location = new System.Drawing.Point(214, 26);
            this.checkBoxCurrentView.Name = "checkBoxCurrentView";
            this.checkBoxCurrentView.Size = new System.Drawing.Size(62, 17);
            this.checkBoxCurrentView.TabIndex = 2;
            this.checkBoxCurrentView.Text = "현재 뷰";
            this.checkBoxCurrentView.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(197, 69);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 22);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(49, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ExcelExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 113);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.checkBoxSelectedElements);
            this.Controls.Add(this.checkBoxCurrentView);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "ExcelExport";
            this.Text = "Excel Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
