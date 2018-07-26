namespace HjDictClient
{
    partial class Main
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.PALWords = new System.Windows.Forms.Panel();
            this.UctPage = new HjDictClient.UctPage();
            this.SuspendLayout();
            // 
            // PALWords
            // 
            this.PALWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PALWords.AutoScroll = true;
            this.PALWords.Location = new System.Drawing.Point(12, 12);
            this.PALWords.Name = "PALWords";
            this.PALWords.Size = new System.Drawing.Size(495, 552);
            this.PALWords.TabIndex = 0;
            // 
            // UctPage
            // 
            this.UctPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UctPage.Location = new System.Drawing.Point(13, 570);
            this.UctPage.Name = "UctPage";
            this.UctPage.Size = new System.Drawing.Size(494, 30);
            this.UctPage.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 612);
            this.Controls.Add(this.UctPage);
            this.Controls.Add(this.PALWords);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PALWords;
        private UctPage UctPage;
    }
}

