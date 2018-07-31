using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;

namespace HjDictClient
{
    public partial class UctWordEn : UserControl
    {
        //private SoundPlayer SoundPlayer = null;
        private SpeechSynthesizer Speech = null;
        private string Value = "";
        private DataRow row = null;


        public UctWordEn()
        {
            InitializeComponent();
        }

        public UctWordEn(DataRow dr)
        {
            InitializeComponent();
            Init(dr);
        }

        private void Init(DataRow dr)
        {
            row = dr;
            Control LblInfo = this.TexInfo;

            LblInfo.Text = string.Format("[{0}]\n{1}\n",
                dr["RowNum"].ToString(),
                string.Empty.PadRight(50, '#'));
            for (int i = 0; i < Para.ValueEn.Count; i++)
            {
                LblInfo.Text += dr[Para.ValueEn[i]].ToString() + "\n";
            }
            LblInfo.Text = LblInfo.Text.Replace("\n", "\r\n# ");
            LblInfo.Font = new Font("MS UI Gothic", Para.CardFontSize);
            LblInfo.Height = (Regex.Matches(LblInfo.Text, "\r\n").Count + 1) * 14;
            this.Height = LblInfo.Height + 20;
            this.Value = dr["Value"].ToString();

            BtnMark.BackColor = !dr.Table.Columns.Contains("Mark") ? Color.White : ((int.Parse(dr["Mark"].ToString()) % 2 != 0) ? Color.Yellow : Color.White);
            string Audio = Path.Combine(Para.AUDIO_PATH, dr["Value"].ToString() + ".mp3");

            Speech = new SpeechSynthesizer();

            //if (File.Exists(Audio))
            //{
            //    //SoundPlayer = new SoundPlayer();
            //    //SoundPlayer.SoundLocation = Audio;
            //    //SoundPlayer.Load();

            //    SoundPlayer = new SpeechSynthesizer();
            //}
            //else
            //{
            //    BtnPron.BackColor = Color.Gainsboro;
            //}
        }

        private void BtnPron_Click(object sender, EventArgs e)
        {
            PlayAutio(Value);
        }

        public void PlayAutio()
        {
            PlayAutio(Value);
        }

        public void PlayAutio(object Value)
        {
            if (Speech != null)
            {
                Speech.SpeakAsyncCancelAll();
                Speech.SpeakAsync(Value.ToString());
                //SoundPlayer.Play();
            }
        }

        /// <summary>
        /// 右键菜单 查词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMISearchWord_Click(object sender, EventArgs e)
        {
            string text = TexInfo.SelectedText.Trim();

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

        /// <summary>
        /// 右键菜单 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMICopy_Click(object sender, EventArgs e)
        {
            string text = TexInfo.SelectedText.Trim();
            if (text != "")
            {
                Clipboard.SetText(text);
            }
        }

        /// <summary>
        /// 标记按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMark_Click(object sender, EventArgs e)
        {
            using (DbManager db = new DbManager())
            {
                string sql = string.Format("UPDATE WORD_EN SET MARK = MARK+1 WHERE VALUE = '{0}'", this.Value);
                int res = db.ExeceteQuery(sql);
                if(res > 0)
                {
                    BtnMark.BackColor = BtnMark.BackColor == Color.Yellow ? Color.White : Color.Yellow;
                }
            }
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (DbManager db = new DbManager())
            {
                string sql = string.Format("DELETE WORD_EN WHERE VALUE = '{0}'", this.Value);
                int res = db.ExeceteQuery(sql);
                if (res > 0)
                {
                    Visible = false;
                }
            }
        }

        /// <summary>
        /// 朗读按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRead_Click(object sender, EventArgs e)
        {
            
            PlayAutio(row["Sample"]);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PlayAutio), row["Sample"]);
        }
    }
}
