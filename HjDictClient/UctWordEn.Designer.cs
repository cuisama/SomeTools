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
            this.lblInfo = new System.Windows.Forms.Label();
            this.BtnPron = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(323, 12);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "*****************************************************";
            // 
            // BtnPron
            // 
            this.BtnPron.BackColor = System.Drawing.SystemColors.Window;
            this.BtnPron.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPron.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPron.Location = new System.Drawing.Point(367, 37);
            this.BtnPron.Name = "BtnPron";
            this.BtnPron.Size = new System.Drawing.Size(47, 20);
            this.BtnPron.TabIndex = 1;
            this.BtnPron.Text = "声音";
            this.BtnPron.UseVisualStyleBackColor = false;
            this.BtnPron.Click += new System.EventHandler(this.BtnPron_Click);
            // 
            // UctWordEn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.BtnPron);
            this.Controls.Add(this.lblInfo);
            this.Name = "UctWordEn";
            this.Size = new System.Drawing.Size(436, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button BtnPron;
    }
}
