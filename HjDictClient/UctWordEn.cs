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
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

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

        private string GetInfoText(List<string> list)
        {
            string result = string.Format("[{0}]\n{1}\n",
                row["RowNum"].ToString(),
                string.Empty.PadRight(50, '#'));
            for (int i = 0; i < list.Count; i++)
            {
                result += row[list[i]].ToString() + "\n";
            }
            result = result.Replace("\n", "\r\n# ");
            return result;
        }

        private void Init(DataRow dr)
        {
            row = dr;
            Control LblInfo = this.TexInfo;

            LblInfo.Text = GetInfoText(Para.ValueEn);


            LblInfo.Font = new Font("MS UI Gothic", Para.CardFontSize);
            //LblInfo.Height = (Regex.Matches(LblInfo.Text, "\r\n").Count + 1) * 14;
            LblInfo.Height = ((Control.ControlAccessibleObject)LblInfo.AccessibilityObject).Owner.PreferredSize.Height;
            this.Height = LblInfo.Height + 20;
            this.Value = dr["Value"].ToString();

            BtnMark.BackColor = !dr.Table.Columns.Contains("Mark") ? Color.White : ((int.Parse(dr["Mark"].ToString()) % 2 != 0) ? Color.Yellow : Color.White);
            //string Audio = Path.Combine(Para.AUDIO_PATH, dr["Value"].ToString() + ".mp3");

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
            //Word[] words = Engine.DealWord(text);
            new Deal(Engine.DealWord).BeginInvoke(text,new AsyncCallback(ShowDialog),null);
        }

        private delegate object Deal(object o);
        private delegate void Deal02(Word[] o);

        private void ShowDialog(IAsyncResult result)
        {
            Word[] words = (Word[])((Deal)((AsyncResult)result).AsyncDelegate).EndInvoke(result);
            Invoke(new Deal02(Util.ShowWordDialog), new object[] { words });
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
                DataRow[] dr = Main.dt.Select(string.Format("Value = '{0}'", this.Value));
                dr[0]["Mark"] = int.Parse(dr[0]["Mark"].ToString()) + 1 + "";
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

        /// <summary>
        /// 为了父panel的滚动条能动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UctWordEn_Click(object sender, EventArgs e)
        {
            this.BtnPron.Select();
        }

        /// <summary>
        /// 在浏览器中打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrower_Click(object sender, EventArgs e)
        {
            Process.Start(string.Format(Engine.DICT, Value));
        }

        /// <summary>
        /// 显示所有词汇所有信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDetail_Click(object sender, EventArgs e)
        {
            TexInfo.Text = GetInfoText(Setting.VALUE_EN.ToList<string>());
            TexInfo.Height = ((Control.ControlAccessibleObject)TexInfo.AccessibilityObject).Owner.PreferredSize.Height;
        }
    }
}
