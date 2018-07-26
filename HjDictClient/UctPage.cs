using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HjDictClient
{
    public partial class UctPage : UserControl
    {

        public delegate void UctBtnGoPage(int index);
        public UctBtnGoPage GoPage;

        private int Count = 0;//一共有多少条数据
        public int PrePageCount = 20;//每页有多少条数据
        private int PageCount = 1;//一共有多少页
        public int CurPageNum = 1;//当前页码

        public UctPage()
        {
            InitializeComponent();
        }

        public UctPage(int zCount)
        {
            InitializeComponent();
            Init(zCount);
        }

        public void Init(int zCount)
        {
            Count = zCount;
            PrePageCount = 20;//int.Parse(ComPrePageCount.Text);
            PageCount = zCount / PrePageCount + ((zCount % PrePageCount) == 0 ? 0 : 1);
            CurPageNum = 1;
            UpPageCode();
        }

        private void UpPageCode()
        {
            int x = (CurPageNum / 2) + ((CurPageNum % 2) == 0 ? 0 : 1);
            Btn1.Text = x == CurPageNum ? "*" : x.ToString();
            Btn2.Text = CurPageNum.ToString();
            x = CurPageNum + ((PageCount - CurPageNum) / 2) + (((PageCount - CurPageNum) % 2) == 0 ? 0 : 1);
            Btn3.Text = x == CurPageNum ? "*" : x.ToString();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            GoPage(1);
            CurPageNum = 1;
            UpPageCode();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (CurPageNum > 1)
            {
                GoPage(CurPageNum - 1);
                CurPageNum -= 1;
                UpPageCode();
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (CurPageNum < PageCount)
            {
                GoPage(CurPageNum + 1);
                CurPageNum += 1;
                UpPageCode();
            }
        }

        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            GoPage(PageCount);
            CurPageNum = PageCount;
            UpPageCode();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (Btn1.Text.Equals("*")) return;
            GoPage(int.Parse(Btn1.Text));
            CurPageNum = int.Parse(Btn1.Text);
            UpPageCode();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            if (Btn3.Text.Equals("*")) return;
            GoPage(int.Parse(Btn3.Text));
            CurPageNum = int.Parse(Btn3.Text);
            UpPageCode();
        }
    }
}
