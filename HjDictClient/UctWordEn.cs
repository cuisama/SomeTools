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

namespace HjDictClient
{
    public partial class UctWordEn : UserControl
    {
        private SoundPlayer SoundPlayer = null;

        public UctWordEn(DataRow dr)
        {
            InitializeComponent();
            Init(dr);
        }

        private void Init(DataRow dr)
        {
            lblInfo.Text = dr["Info"].ToString();
            this.Height = lblInfo.Height + 20;
            string Audio = Path.Combine(Para.AUDIO_PATH, dr["Value"].ToString() + ".mp3");
            if (File.Exists(Audio))
            {
                SoundPlayer = new SoundPlayer();
                SoundPlayer.SoundLocation = Audio;
                SoundPlayer.Load();
            }
            else
            {
                BtnPron.BackColor = Color.Gainsboro;
            }
        }

        private void PlayAudio(object o)
        {
            SoundPlayer.Play();
        }

        private void BtnPron_Click(object sender, EventArgs e)
        {
            if (SoundPlayer != null)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(PlayAudio));
            }
        }
    }
}
