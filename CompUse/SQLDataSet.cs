using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompUse
{
    public partial class SQLDataSet : Form
    {
        public SQLDataSet(DataSet tbls)
        {
            InitializeComponent();
            UpdateControlStatus();
            Init(tbls);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateControlStatus()
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            LastHeight = this.Height;
            LastWidth = this.Width;
            this.AutoScroll = true;
            //this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbls"></param>
        private void Init(DataSet tbls)
        {
            tabsCount = tbls.Tables.Count;
            int gvHeight = ((this.Height - 40 - 10 * tabsCount) / tabsCount);
            gvHeight = gvHeight < 70 ? 70 : gvHeight;
            for (int i = 0;i < tabsCount; i++)
            {
                DataGridView dtgv = new DataGridView();
                dtgv.Width = this.Width - 60;
                dtgv.Height = gvHeight;
                dtgv.Wink(false);
                //dtgv.BorderStyle = BorderStyle.None;
                dtgv.Location = new Point(15, 15 + i * (gvHeight + 5));
                dtgv.DataSource = tbls.Tables[i];
                this.Controls.Add(dtgv);
            }
        }

        private int LastWidth = 0;
        private int LastHeight = 0;
        private int tabsCount = 1;

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQLDataSet_Resize(object sender, EventArgs e)
        {
            var spc = sender as SQLDataSet;
            int movWidth = spc.Width - LastWidth;
            int movHeight = spc.Height - LastHeight;
            LastHeight = spc.Height;
            LastWidth = spc.Width;
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(DataGridView))
                {
                    c.Width += movWidth;
                    c.Height += movHeight / tabsCount;
                }
            }
            int k = 0;
            foreach(Control c in Controls)
            {
                if(c.GetType() == typeof(DataGridView))
                {
                    //c.Location = new Point(c.Location.X, c.Location.Y + k * (movHeight / tabsCount));
                    c.LocMove(0, k * (movHeight / tabsCount));
                    k++;    
                }
            }
        }
    }
}
