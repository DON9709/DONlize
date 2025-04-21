namespace DONlize
{
    partial class ParameterSelectorControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;

        /// <summary> 
        /// 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteall = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddall = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBefore = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parameter Selector";
            // 
            // btnDeleteall
            // 
            this.btnDeleteall.Location = new System.Drawing.Point(346, 539);
            this.btnDeleteall.Name = "btnDeleteall";
            this.btnDeleteall.Size = new System.Drawing.Size(65, 25);
            this.btnDeleteall.TabIndex = 15;
            this.btnDeleteall.Text = "전체삭제";
            this.btnDeleteall.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(227, 253);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 25);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "추가>";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(227, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 25);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "<삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddall
            // 
            this.btnAddall.Location = new System.Drawing.Point(93, 539);
            this.btnAddall.Name = "btnAddall";
            this.btnAddall.Size = new System.Drawing.Size(65, 25);
            this.btnAddall.TabIndex = 12;
            this.btnAddall.Text = "전체선택";
            this.btnAddall.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(285, 87);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(178, 446);
            this.listBox2.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(40, 87);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 446);
            this.listBox1.TabIndex = 10;
            // 
            // btnBefore
            // 
            this.btnBefore.Location = new System.Drawing.Point(93, 604);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(64, 25);
            this.btnBefore.TabIndex = 9;
            this.btnBefore.Text = "Before";
            this.btnBefore.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(347, 604);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 25);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // ParameterSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteall);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddall);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnBefore);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label1);
            this.Name = "ParameterSelectorControl";
            this.Size = new System.Drawing.Size(497, 718);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteall;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddall;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.Button btnNext;
    }
}
