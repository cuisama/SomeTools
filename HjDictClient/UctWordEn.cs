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

namespace HjDictClient
{
    public partial class UctWordEn : UserControl
    {
        //private SoundPlayer SoundPlayer = null;
        private SpeechSynthesizer SoundPlayer = null;

        public UctWordEn(DataRow dr)
        {
            InitializeComponent();
            Init(dr);
        }

        private string Value = "";

        private void Init(DataRow dr)
        {
            lblInfo.Text = string.Format("[{0}]\n{1}\n", dr["RowNum"].ToString(), "".PadRight(50, '#'));
            for (int i = 0; i < Para.ValueEn.Count; i++)
            {
                lblInfo.Text += dr[Para.ValueEn[i]].ToString() + "\n";
            }
            this.Height = lblInfo.Height + 20;
            Value = dr["Value"].ToString();
            string Audio = Path.Combine(Para.AUDIO_PATH, dr["Value"].ToString() + ".mp3");

            SoundPlayer = new SpeechSynthesizer();

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
            PlayAutio();
        }

        public void PlayAutio()
        {
            if (SoundPlayer != null)
            {
                SoundPlayer.SpeakAsync(Value);
                //SoundPlayer.Play();
            }
        }
    }
}
