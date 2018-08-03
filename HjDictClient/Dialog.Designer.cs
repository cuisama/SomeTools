namespace HjDictClient
{
    partial class Dialog
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
            this.UctPal = new HjDictClient.UctPanel();
            this.SuspendLayout();
            // 
            // UctPal
            // 
            this.UctPal.AutoScroll = true;
            this.UctPal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UctPal.Location = new System.Drawing.Point(0, 0);
            this.UctPal.Name = "UctPal";
            this.UctPal.Size = new System.Drawing.Size(479, 236);
            this.UctPal.TabIndex = 0;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(479, 236);
            this.Controls.Add(this.UctPal);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        internal UctPanel UctPal;
    }
}