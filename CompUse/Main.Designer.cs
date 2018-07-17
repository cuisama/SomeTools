namespace CompUse
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.LblExeTime = new System.Windows.Forms.Label();
            this.LblDataCount = new System.Windows.Forms.Label();
            this.DTGVSqlResult = new System.Windows.Forms.DataGridView();
            this.RTexSql = new System.Windows.Forms.RichTextBox();
            this.LblMoveLine = new System.Windows.Forms.Label();
            this.COMDBName = new System.Windows.Forms.ComboBox();
            this.TexDBIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TexTableName = new System.Windows.Forms.TextBox();
            this.ComTableName = new System.Windows.Forms.ComboBox();
            this.BtnExecuteSql = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RTexData = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGVSqlResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 557);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnInsert);
            this.tabPage1.Controls.Add(this.LblExeTime);
            this.tabPage1.Controls.Add(this.LblDataCount);
            this.tabPage1.Controls.Add(this.DTGVSqlResult);
            this.tabPage1.Controls.Add(this.RTexSql);
            this.tabPage1.Controls.Add(this.LblMoveLine);
            this.tabPage1.Controls.Add(this.COMDBName);
            this.tabPage1.Controls.Add(this.TexDBIP);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TexTableName);
            this.tabPage1.Controls.Add(this.ComTableName);
            this.tabPage1.Controls.Add(this.BtnExecuteSql);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.RTexData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(125, 35);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(87, 25);
            this.BtnInsert.TabIndex = 25;
            this.BtnInsert.Text = "插入";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // LblExeTime
            // 
            this.LblExeTime.AutoSize = true;
            this.LblExeTime.Location = new System.Drawing.Point(393, 513);
            this.LblExeTime.Name = "LblExeTime";
            this.LblExeTime.Size = new System.Drawing.Size(26, 12);
            this.LblExeTime.TabIndex = 24;
            this.LblExeTime.Text = "0ms";
            // 
            // LblDataCount
            // 
            this.LblDataCount.AutoSize = true;
            this.LblDataCount.Location = new System.Drawing.Point(478, 513);
            this.LblDataCount.Name = "LblDataCount";
            this.LblDataCount.Size = new System.Drawing.Size(27, 12);
            this.LblDataCount.TabIndex = 23;
            this.LblDataCount.Text = "0 行";
            // 
            // DTGVSqlResult
            // 
            this.DTGVSqlResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGVSqlResult.Location = new System.Drawing.Point(11, 298);
            this.DTGVSqlResult.Name = "DTGVSqlResult";
            this.DTGVSqlResult.Size = new System.Drawing.Size(515, 212);
            this.DTGVSqlResult.TabIndex = 20;
            // 
            // RTexSql
            // 
            this.RTexSql.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RTexSql.Location = new System.Drawing.Point(11, 135);
            this.RTexSql.Name = "RTexSql";
            this.RTexSql.Size = new System.Drawing.Size(515, 151);
            this.RTexSql.TabIndex = 21;
            this.RTexSql.Text = "";
            // 
            // LblMoveLine
            // 
            this.LblMoveLine.AutoSize = true;
            this.LblMoveLine.Location = new System.Drawing.Point(254, 285);
            this.LblMoveLine.Name = "LblMoveLine";
            this.LblMoveLine.Size = new System.Drawing.Size(83, 12);
            this.LblMoveLine.TabIndex = 22;
            this.LblMoveLine.Text = "-------------";
            this.LblMoveLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMoveLine_MouseDown);
            this.LblMoveLine.MouseEnter += new System.EventHandler(this.LblMoveLine_Enter);
            this.LblMoveLine.MouseLeave += new System.EventHandler(this.LblMoveLine_Leave);
            this.LblMoveLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblMoveLine_MouseMove);
            this.LblMoveLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblMoveLine_MouseUp);
            // 
            // COMDBName
            // 
            this.COMDBName.FormattingEnabled = true;
            this.COMDBName.Location = new System.Drawing.Point(215, 6);
            this.COMDBName.Name = "COMDBName";
            this.COMDBName.Size = new System.Drawing.Size(121, 20);
            this.COMDBName.TabIndex = 18;
            // 
            // TexDBIP
            // 
            this.TexDBIP.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TexDBIP.Location = new System.Drawing.Point(27, 6);
            this.TexDBIP.Name = "TexDBIP";
            this.TexDBIP.Size = new System.Drawing.Size(100, 19);
            this.TexDBIP.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "IP：";
            // 
            // TexTableName
            // 
            this.TexTableName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TexTableName.Location = new System.Drawing.Point(362, 6);
            this.TexTableName.Name = "TexTableName";
            this.TexTableName.Size = new System.Drawing.Size(143, 19);
            this.TexTableName.TabIndex = 15;
            this.TexTableName.TextChanged += new System.EventHandler(this.TexTableName_TextChanged);
            // 
            // ComTableName
            // 
            this.ComTableName.FormattingEnabled = true;
            this.ComTableName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ComTableName.Location = new System.Drawing.Point(237, 35);
            this.ComTableName.Name = "ComTableName";
            this.ComTableName.Size = new System.Drawing.Size(268, 20);
            this.ComTableName.TabIndex = 14;
            this.ComTableName.TextUpdate += new System.EventHandler(this.ComTableName_TextUpdate);
            // 
            // BtnExecuteSql
            // 
            this.BtnExecuteSql.Location = new System.Drawing.Point(27, 35);
            this.BtnExecuteSql.Name = "BtnExecuteSql";
            this.BtnExecuteSql.Size = new System.Drawing.Size(87, 25);
            this.BtnExecuteSql.TabIndex = 13;
            this.BtnExecuteSql.Text = "実行(&F5)";
            this.BtnExecuteSql.UseVisualStyleBackColor = true;
            this.BtnExecuteSql.Click += new System.EventHandler(this.BtnExecuteSql_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "データベース：";
            // 
            // RTexData
            // 
            this.RTexData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTexData.Location = new System.Drawing.Point(11, 75);
            this.RTexData.Name = "RTexData";
            this.RTexData.Size = new System.Drawing.Size(517, 54);
            this.RTexData.TabIndex = 0;
            this.RTexData.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 557);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Main";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGVSqlResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DTGVSqlResult;
        private System.Windows.Forms.RichTextBox RTexSql;
        private System.Windows.Forms.Label LblMoveLine;
        private System.Windows.Forms.ComboBox COMDBName;
        private System.Windows.Forms.TextBox TexDBIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TexTableName;
        private System.Windows.Forms.ComboBox ComTableName;
        private System.Windows.Forms.Button BtnExecuteSql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RTexData;
        private System.Windows.Forms.Label LblExeTime;
        private System.Windows.Forms.Label LblDataCount;
        private System.Windows.Forms.Button BtnInsert;
    }
}

