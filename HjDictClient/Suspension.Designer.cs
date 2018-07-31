namespace HjDictClient
{
    partial class Suspension
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
            this.TexSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TexSearch
            // 
            this.TexSearch.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TexSearch.Location = new System.Drawing.Point(8, 1);
            this.TexSearch.Name = "TexSearch";
            this.TexSearch.Size = new System.Drawing.Size(154, 19);
            this.TexSearch.TabIndex = 1;
            this.TexSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TexSearch_KeyPress);
            // 
            // Suspension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(180, 21);
            this.Controls.Add(this.TexSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Suspension";
            this.Text = "Suspension";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Suspension_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Suspension_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Suspension_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Suspension_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Suspension_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TexSearch;
    }
}