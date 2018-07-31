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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.PALWords = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可视格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIReloadDB = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.TexSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.TSSBtnTomoto = new System.Windows.Forms.ToolStripSplitButton();
            this.TSMITomotoReset = new System.Windows.Forms.ToolStripMenuItem();
            this.TSSLblTomotoTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSLblTomotoTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CTMSNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIShowSuspension = new System.Windows.Forms.ToolStripMenuItem();
            this.UctPage = new HjDictClient.UctPage();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.CTMSNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // PALWords
            // 
            this.PALWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PALWords.AutoScroll = true;
            this.PALWords.Location = new System.Drawing.Point(12, 52);
            this.PALWords.Name = "PALWords";
            this.PALWords.Size = new System.Drawing.Size(495, 498);
            this.PALWords.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(519, 26);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.另存为ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据格式ToolStripMenuItem,
            this.可视格式ToolStripMenuItem,
            this.cSVToolStripMenuItem});
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.另存为ToolStripMenuItem.Text = "导出为...";
            // 
            // 数据格式ToolStripMenuItem
            // 
            this.数据格式ToolStripMenuItem.Name = "数据格式ToolStripMenuItem";
            this.数据格式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.数据格式ToolStripMenuItem.Text = "数据格式";
            // 
            // 可视格式ToolStripMenuItem
            // 
            this.可视格式ToolStripMenuItem.Name = "可视格式ToolStripMenuItem";
            this.可视格式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.可视格式ToolStripMenuItem.Text = "可视格式";
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "退出";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIReloadDB});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // TSMIReloadDB
            // 
            this.TSMIReloadDB.Name = "TSMIReloadDB";
            this.TSMIReloadDB.Size = new System.Drawing.Size(136, 22);
            this.TSMIReloadDB.Text = "重载数据库";
            this.TSMIReloadDB.Click += new System.EventHandler(this.TSMIReloadDB_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowSuspension});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.版权ToolStripMenuItem,
            this.TSMIOptions});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 版权ToolStripMenuItem
            // 
            this.版权ToolStripMenuItem.Name = "版权ToolStripMenuItem";
            this.版权ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.版权ToolStripMenuItem.Text = "版权";
            // 
            // TSMIOptions
            // 
            this.TSMIOptions.Name = "TSMIOptions";
            this.TSMIOptions.Size = new System.Drawing.Size(100, 22);
            this.TSMIOptions.Text = "选项";
            this.TSMIOptions.Click += new System.EventHandler(this.TSMIOptions_Click);
            // 
            // TexSearch
            // 
            this.TexSearch.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TexSearch.Location = new System.Drawing.Point(66, 29);
            this.TexSearch.Name = "TexSearch";
            this.TexSearch.Size = new System.Drawing.Size(327, 19);
            this.TexSearch.TabIndex = 0;
            this.TexSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TexSearch_KeyPress);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnSearch.Location = new System.Drawing.Point(13, 28);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(47, 20);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "查词";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSBtnTomoto,
            this.TSSLblTomotoTimer,
            this.TSSLblTomotoTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 596);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(519, 23);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // TSSBtnTomoto
            // 
            this.TSSBtnTomoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSSBtnTomoto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMITomotoReset});
            this.TSSBtnTomoto.Image = ((System.Drawing.Image)(resources.GetObject("TSSBtnTomoto.Image")));
            this.TSSBtnTomoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSSBtnTomoto.Name = "TSSBtnTomoto";
            this.TSSBtnTomoto.Size = new System.Drawing.Size(32, 21);
            this.TSSBtnTomoto.Text = "TSSBtnTomoto";
            this.TSSBtnTomoto.ButtonClick += new System.EventHandler(this.TSSBtnTomoto_ButtonClick);
            // 
            // TSMITomotoReset
            // 
            this.TSMITomotoReset.Name = "TSMITomotoReset";
            this.TSMITomotoReset.Size = new System.Drawing.Size(100, 22);
            this.TSMITomotoReset.Text = "重置";
            this.TSMITomotoReset.Click += new System.EventHandler(this.TSMITomotoReset_Click);
            // 
            // TSSLblTomotoTimer
            // 
            this.TSSLblTomotoTimer.Name = "TSSLblTomotoTimer";
            this.TSSLblTomotoTimer.Size = new System.Drawing.Size(41, 18);
            this.TSSLblTomotoTimer.Text = "30:00";
            // 
            // TSSLblTomotoTime
            // 
            this.TSSLblTomotoTime.Name = "TSSLblTomotoTime";
            this.TSSLblTomotoTime.Size = new System.Drawing.Size(15, 18);
            this.TSSLblTomotoTime.Text = "0";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.CTMSNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "沪江小D";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // CTMSNotifyIcon
            // 
            this.CTMSNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIExit});
            this.CTMSNotifyIcon.Name = "CTMSNotifyIcon";
            this.CTMSNotifyIcon.Size = new System.Drawing.Size(101, 26);
            // 
            // TSMIExit
            // 
            this.TSMIExit.Name = "TSMIExit";
            this.TSMIExit.Size = new System.Drawing.Size(100, 22);
            this.TSMIExit.Text = "退出";
            this.TSMIExit.Click += new System.EventHandler(this.TSMIExit_Click);
            // 
            // TSMIShowSuspension
            // 
            this.TSMIShowSuspension.Name = "TSMIShowSuspension";
            this.TSMIShowSuspension.Size = new System.Drawing.Size(152, 22);
            this.TSMIShowSuspension.Text = "显示悬浮窗";
            this.TSMIShowSuspension.Click += new System.EventHandler(this.TSMIShowSuspension_Click);
            // 
            // UctPage
            // 
            this.UctPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UctPage.Location = new System.Drawing.Point(13, 559);
            this.UctPage.Name = "UctPage";
            this.UctPage.Size = new System.Drawing.Size(494, 30);
            this.UctPage.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 619);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TexSearch);
            this.Controls.Add(this.UctPage);
            this.Controls.Add(this.PALWords);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "沪江小D";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.CTMSNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PALWords;
        private UctPage UctPage;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 可视格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.TextBox TexSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.ToolStripMenuItem 版权ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMIOptions;
        private System.Windows.Forms.ToolStripMenuItem TSMIReloadDB;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSplitButton TSSBtnTomoto;
        private System.Windows.Forms.ToolStripStatusLabel TSSLblTomotoTimer;
        private System.Windows.Forms.ToolStripStatusLabel TSSLblTomotoTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem TSMITomotoReset;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip CTMSNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem TSMIExit;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowSuspension;
    }
}

