using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HjDictClient
{
    public partial class Suspension : Form
    {
        public Suspension()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        /// <summary>
        /// 查单词 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TexSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;

                string text = TexSearch.Text.Trim();

                Dialog dialog = new Dialog();

                int startLocationY = 0;
                UctWordEn card = null;

                Word[] words = Engine.DealWord(text);
                DataRow[] dr = words.ToDataRow();

                for (int i = 0; i < dr.Length; i++)
                {
                    card = new UctWordEn(dr[i]);
                    card.Location = new Point(0, startLocationY);
                    card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    startLocationY += card.Height;
                    dialog.Controls.Add(card);
                }
                dialog.Show();
            }
        }

        private int RelativeX = -1;
        private int RelativeY = -1;

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suspension_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Cursor.Equals(Cursors.SizeAll))
            {
                Form p = sender as Form;
                RelativeX = Control.MousePosition.X - p.Location.X;
                RelativeY = Control.MousePosition.Y - p.Location.Y;
                p.BringToFront();
            }
        }

        /// <summary>
        /// 鼠标抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suspension_MouseUp(object sender, MouseEventArgs e)
        {
            RelativeX = -1;
            RelativeY = -1;
            if (this.Location.X + this.Width >= Screen.GetWorkingArea(this).Width)
            {
                this.Width = 10;
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width, this.Location.Y);
            }else
            {
                this.Width = 180;
            }
        }

        /// <summary>
        /// 鼠标按下 且 移动中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suspension_MouseMove(object sender, MouseEventArgs e)
        {
            if (RelativeX != -1 || RelativeY != -1)
            {
                Form p = sender as Form;
                p.Location = new Point(Control.MousePosition.X - RelativeX, Control.MousePosition.Y - RelativeY);
            }
        }

        /// <summary>
        /// 鼠标进入主窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suspension_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
            if (this.Width < 20)
            {
                this.Width = 180;
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width, this.Location.Y);
            }
        }

        /// <summary>
        /// 鼠标离开悬浮窗 鼠标进入textbox也是 leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Suspension_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            int x = MousePosition.X;
            int y = MousePosition.Y;
            if (!(x > Location.X && y > Location.Y && x < (Location.X + Width) && y < (Location.Y + Height)))
            {
                this.Width = 10;
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width, this.Location.Y);
            }
        }

    }
}
