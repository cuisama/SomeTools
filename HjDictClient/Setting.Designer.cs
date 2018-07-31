namespace HjDictClient
{
    partial class Setting
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.CKLOther = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CKLColumnJp = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CKLColumnEn = new System.Windows.Forms.CheckedListBox();
            this.TAB1 = new System.Windows.Forms.TabControl();
            this.风格 = new System.Windows.Forms.TabPage();
            this.ComFontSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.TAB1.SuspendLayout();
            this.风格.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.CKLOther);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CKLColumnJp);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.CKLColumnEn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "其他：";
            // 
            // CKLOther
            // 
            this.CKLOther.FormattingEnabled = true;
            this.CKLOther.Items.AddRange(new object[] {
            "自动朗读"});
            this.CKLOther.Location = new System.Drawing.Point(8, 189);
            this.CKLOther.Name = "CKLOther";
            this.CKLOther.Size = new System.Drawing.Size(120, 46);
            this.CKLOther.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "日文显示字段：";
            // 
            // CKLColumnJp
            // 
            this.CKLColumnJp.FormattingEnabled = true;
            this.CKLColumnJp.Items.AddRange(new object[] {
            "词汇展示",
            "发音",
            "简明释义",
            "常用短语",
            "详细释义"});
            this.CKLColumnJp.Location = new System.Drawing.Point(173, 31);
            this.CKLColumnJp.Name = "CKLColumnJp";
            this.CKLColumnJp.Size = new System.Drawing.Size(120, 130);
            this.CKLColumnJp.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "英文显示字段：";
            // 
            // CKLColumnEn
            // 
            this.CKLColumnEn.FormattingEnabled = true;
            this.CKLColumnEn.Items.AddRange(new object[] {
            "词汇展示",
            "美式发音",
            "英式发音",
            "简明释义",
            "常用短语",
            "详细释义",
            "英英释义",
            "同反义词",
            "词性变化"});
            this.CKLColumnEn.Location = new System.Drawing.Point(8, 31);
            this.CKLColumnEn.Name = "CKLColumnEn";
            this.CKLColumnEn.Size = new System.Drawing.Size(120, 130);
            this.CKLColumnEn.TabIndex = 1;
            // 
            // TAB1
            // 
            this.TAB1.Controls.Add(this.tabPage1);
            this.TAB1.Controls.Add(this.风格);
            this.TAB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TAB1.Location = new System.Drawing.Point(0, 0);
            this.TAB1.Name = "TAB1";
            this.TAB1.SelectedIndex = 0;
            this.TAB1.Size = new System.Drawing.Size(341, 312);
            this.TAB1.TabIndex = 2;
            // 
            // 风格
            // 
            this.风格.Controls.Add(this.ComFontSize);
            this.风格.Controls.Add(this.label4);
            this.风格.Location = new System.Drawing.Point(4, 22);
            this.风格.Name = "风格";
            this.风格.Padding = new System.Windows.Forms.Padding(3);
            this.风格.Size = new System.Drawing.Size(333, 286);
            this.风格.TabIndex = 1;
            this.风格.Text = "tabPage2";
            this.风格.UseVisualStyleBackColor = true;
            // 
            // ComFontSize
            // 
            this.ComFontSize.FormattingEnabled = true;
            this.ComFontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24"});
            this.ComFontSize.Location = new System.Drawing.Point(41, 8);
            this.ComFontSize.Name = "ComFontSize";
            this.ComFontSize.Size = new System.Drawing.Size(121, 20);
            this.ComFontSize.TabIndex = 0;
            this.ComFontSize.Text = "9";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "字号：";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(273, 327);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(56, 23);
            this.BtnConfirm.TabIndex = 10;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(209, 327);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(56, 23);
            this.BtnApply.TabIndex = 9;
            this.BtnApply.Text = "应用";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 359);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TAB1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TAB1.ResumeLayout(false);
            this.风格.ResumeLayout(false);
            this.风格.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox CKLOther;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox CKLColumnJp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox CKLColumnEn;
        private System.Windows.Forms.TabControl TAB1;
        private System.Windows.Forms.TabPage 风格;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComFontSize;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Button BtnApply;
    }
}