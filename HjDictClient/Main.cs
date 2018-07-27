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
    public partial class Main : Form
    {
        private Control.ControlCollection Container = null;
        public Main()
        {
            InitializeComponent();
            UpdateControlStatus();
            Init();
        }

        private void UpdateControlStatus()
        {
            //this.AutoScroll = true;
            Container = PALWords.Controls;
        }

        private void Init()
        {
            //string sql = @"select Value, '[' + Convert(varchar(5), ROW_NUMBER() OVER(ORDER BY updatetime desc)) + ']'
            //                    + CHAR(10) + '*****************************************************'
            //                    + CHAR(10) + Value
            //                    + CHAR(10) + (case when PronouncesUs is null or PronouncesUs ='美' then PronouncesEn else PronouncesUs end)
            //                    + CHAR(10) + Sample
            //                    + CHAR(10) + replace(replace(Phrase, '源自:《新世纪英汉大词典》Collins外研社',''), '常用短语', char(10) + '常用短语')
            //                    + CHAR(10) + '*****************************************************' + CHAR(10) AS Info 
            //                    from WORD_EN order by updatetime desc";

            string sql = "SELECT ROW_NUMBER() OVER(ORDER BY UpdateTime DESC) AS RowNum,* FROM WORD_EN ORDER BY UpdateTime DESC";

            using (DbManager db = new DbManager())
            {
                dt = db.CreateDataTable(sql);
            }

            UctPage.GoPage = new UctPage.UctBtnGoPage(GoPage);
            UctPage.Init(dt.Rows.Count);

        }
        private DataTable dt = null;


        private void GoPage(int index)
        {
            Container.Clear();

            int startLocationY = 0;

            int start = (index - 1) * UctPage.PrePageCount;
            int end = Math.Min(dt.Rows.Count, index * UctPage.PrePageCount);

            UctWordEn card = null;
            for (int i = start; i < end; i++)
            {
                card = new UctWordEn(dt.Rows[i]);
                card.Location = new Point(0, startLocationY);
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                startLocationY += card.Height;
                Container.Add(card);
            }
            PALWords.Select();
            if (Para.AUTO_PLAY && UctPage.PrePageCount == 1 && card != null)
            {
                card.PlayAutio();
            }

        }

        /// <summary>
        /// 查词 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Container.Clear();
            DataRow[] dr = dt.Select(string.Format("Value like '%{0}%'", TexSearch.Text));
            int startLocationY = 0;
            UctWordEn card = null;
            for (int i = 0; i < dr.Length; i++)
            {
                card = new UctWordEn(dt.Rows[i]);
                card.Location = new Point(0, startLocationY);
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                startLocationY += card.Height;
                Container.Add(card);
            }
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
                BtnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// 菜单栏 - 帮助 - 选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIOptions_Click(object sender, EventArgs e)
        {
            Setting form = new Setting();
            form.Show();
        }
    }
}
