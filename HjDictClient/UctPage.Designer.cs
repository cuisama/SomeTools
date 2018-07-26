namespace HjDictClient
{
    partial class UctPage
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
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnLast = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.ComPrePageCount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.SystemColors.Window;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnStart.Location = new System.Drawing.Point(19, 10);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(47, 20);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "首页";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnLast
            // 
            this.BtnLast.BackColor = System.Drawing.SystemColors.Window;
            this.BtnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLast.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnLast.Location = new System.Drawing.Point(72, 10);
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.Size = new System.Drawing.Size(59, 20);
            this.BtnLast.TabIndex = 3;
            this.BtnLast.Text = "上一页";
            this.BtnLast.UseVisualStyleBackColor = false;
            this.BtnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.SystemColors.Window;
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnNext.Location = new System.Drawing.Point(251, 10);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(59, 20);
            this.BtnNext.TabIndex = 4;
            this.BtnNext.Text = "下一页";
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnEnd
            // 
            this.BtnEnd.BackColor = System.Drawing.SystemColors.Window;
            this.BtnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnEnd.Location = new System.Drawing.Point(316, 10);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(47, 20);
            this.BtnEnd.TabIndex = 5;
            this.BtnEnd.Text = "尾页";
            this.BtnEnd.UseVisualStyleBackColor = false;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // Btn1
            // 
            this.Btn1.BackColor = System.Drawing.SystemColors.Window;
            this.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn1.Location = new System.Drawing.Point(137, 10);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(32, 20);
            this.Btn1.TabIndex = 6;
            this.Btn1.Text = "1";
            this.Btn1.UseVisualStyleBackColor = false;
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn2
            // 
            this.Btn2.BackColor = System.Drawing.SystemColors.Window;
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn2.Location = new System.Drawing.Point(175, 10);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(32, 20);
            this.Btn2.TabIndex = 7;
            this.Btn2.Text = "2";
            this.Btn2.UseVisualStyleBackColor = false;
            // 
            // Btn3
            // 
            this.Btn3.BackColor = System.Drawing.SystemColors.Window;
            this.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn3.Location = new System.Drawing.Point(213, 10);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(32, 20);
            this.Btn3.TabIndex = 8;
            this.Btn3.Text = "3";
            this.Btn3.UseVisualStyleBackColor = false;
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // ComPrePageCount
            // 
            this.ComPrePageCount.FormattingEnabled = true;
            this.ComPrePageCount.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "50",
            "100"});
            this.ComPrePageCount.Location = new System.Drawing.Point(381, 10);
            this.ComPrePageCount.Name = "ComPrePageCount";
            this.ComPrePageCount.Size = new System.Drawing.Size(53, 20);
            this.ComPrePageCount.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "/页";
            // 
            // UctPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComPrePageCount);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.BtnEnd);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnLast);
            this.Controls.Add(this.BtnStart);
            this.Name = "UctPage";
            this.Size = new System.Drawing.Size(509, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnLast;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnEnd;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.ComboBox ComPrePageCount;
        private System.Windows.Forms.Label label1;
    }
}
