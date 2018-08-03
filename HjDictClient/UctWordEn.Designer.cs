namespace HjDictClient
{
    partial class UctWordEn
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnPron = new System.Windows.Forms.Button();
            this.CTMSRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMISearchWord = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMICopy = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnMark = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.BtnDetail = new System.Windows.Forms.Button();
            this.BtnBrower = new System.Windows.Forms.Button();
            this.TexInfo = new System.Windows.Forms.TextBox();
            this.CTMSRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPron
            // 
            this.BtnPron.BackColor = System.Drawing.SystemColors.Window;
            this.BtnPron.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPron.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPron.Location = new System.Drawing.Point(17, 13);
            this.BtnPron.Name = "BtnPron";
            this.BtnPron.Size = new System.Drawing.Size(47, 20);
            this.BtnPron.TabIndex = 1;
            this.BtnPron.Text = "声音";
            this.BtnPron.UseVisualStyleBackColor = false;
            this.BtnPron.Click += new System.EventHandler(this.BtnPron_Click);
            // 
            // CTMSRightMenu
            // 
            this.CTMSRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMISearchWord,
            this.TSMICopy});
            this.CTMSRightMenu.Name = "CTMSRightMenu";
            this.CTMSRightMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // TSMISearchWord
            // 
            this.TSMISearchWord.Name = "TSMISearchWord";
            this.TSMISearchWord.Size = new System.Drawing.Size(100, 22);
            this.TSMISearchWord.Text = "查词";
            this.TSMISearchWord.Click += new System.EventHandler(this.TSMISearchWord_Click);
            // 
            // TSMICopy
            // 
            this.TSMICopy.Name = "TSMICopy";
            this.TSMICopy.Size = new System.Drawing.Size(100, 22);
            this.TSMICopy.Text = "复制";
            this.TSMICopy.Click += new System.EventHandler(this.TSMICopy_Click);
            // 
            // BtnMark
            // 
            this.BtnMark.BackColor = System.Drawing.SystemColors.Window;
            this.BtnMark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnMark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnMark.Location = new System.Drawing.Point(17, 41);
            this.BtnMark.Name = "BtnMark";
            this.BtnMark.Size = new System.Drawing.Size(47, 20);
            this.BtnMark.TabIndex = 3;
            this.BtnMark.Text = "标记";
            this.BtnMark.UseVisualStyleBackColor = false;
            this.BtnMark.Click += new System.EventHandler(this.BtnMark_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.SystemColors.Window;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnDelete.Location = new System.Drawing.Point(17, 67);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(47, 20);
            this.BtnDelete.TabIndex = 4;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.BackColor = System.Drawing.SystemColors.Window;
            this.BtnRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRead.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRead.Location = new System.Drawing.Point(17, 93);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(47, 20);
            this.BtnRead.TabIndex = 5;
            this.BtnRead.Text = "朗读";
            this.BtnRead.UseVisualStyleBackColor = false;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // BtnDetail
            // 
            this.BtnDetail.BackColor = System.Drawing.SystemColors.Window;
            this.BtnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnDetail.Location = new System.Drawing.Point(17, 145);
            this.BtnDetail.Name = "BtnDetail";
            this.BtnDetail.Size = new System.Drawing.Size(47, 20);
            this.BtnDetail.TabIndex = 6;
            this.BtnDetail.Text = "详细";
            this.BtnDetail.UseVisualStyleBackColor = false;
            this.BtnDetail.Click += new System.EventHandler(this.BtnDetail_Click);
            // 
            // BtnBrower
            // 
            this.BtnBrower.BackColor = System.Drawing.SystemColors.Window;
            this.BtnBrower.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBrower.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnBrower.Location = new System.Drawing.Point(17, 119);
            this.BtnBrower.Name = "BtnBrower";
            this.BtnBrower.Size = new System.Drawing.Size(47, 20);
            this.BtnBrower.TabIndex = 7;
            this.BtnBrower.Text = "浏览器";
            this.BtnBrower.UseVisualStyleBackColor = false;
            this.BtnBrower.Click += new System.EventHandler(this.BtnBrower_Click);
            // 
            // TexInfo
            // 
            this.TexInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TexInfo.BackColor = System.Drawing.SystemColors.Window;
            this.TexInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TexInfo.ContextMenuStrip = this.CTMSRightMenu;
            this.TexInfo.Location = new System.Drawing.Point(70, 13);
            this.TexInfo.MinimumSize = new System.Drawing.Size(335, 152);
            this.TexInfo.Multiline = true;
            this.TexInfo.Name = "TexInfo";
            this.TexInfo.ReadOnly = true;
            this.TexInfo.Size = new System.Drawing.Size(335, 152);
            this.TexInfo.TabIndex = 2;
            this.TexInfo.Text = "*****************************************************";
            // 
            // UctWordEn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.BtnBrower);
            this.Controls.Add(this.BtnDetail);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnMark);
            this.Controls.Add(this.TexInfo);
            this.Controls.Add(this.BtnPron);
            this.Name = "UctWordEn";
            this.Size = new System.Drawing.Size(504, 183);
            this.Click += new System.EventHandler(this.UctWordEn_Click);
            this.CTMSRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnPron;
        private System.Windows.Forms.ContextMenuStrip CTMSRightMenu;
        private System.Windows.Forms.ToolStripMenuItem TSMISearchWord;
        private System.Windows.Forms.ToolStripMenuItem TSMICopy;
        private System.Windows.Forms.Button BtnMark;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Button BtnDetail;
        private System.Windows.Forms.Button BtnBrower;
        private System.Windows.Forms.TextBox TexInfo;
    }
}
