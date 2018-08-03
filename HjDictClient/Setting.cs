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
    public partial class Setting : Form
    { 

        public static string[] VALUE_EN = new string[] { "Value", "PronouncesUs", "PronouncesEn", "Sample", "Phrase", "Detail", "DetailEnEn", "Synant", "Inflections" };
        public static string[] VALUE_JP = new string[] { "Value", "Pronounces", "Sample", "Phrase", "Detail", "Synant" };

        public Setting()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化checkbox
        /// </summary>
        private void Init()
        {
            for (int i = 0; i < Para.ValueEn.Count; i++)
            {
                CKLColumnEn.SetItemChecked(Array.IndexOf(VALUE_EN, Para.ValueEn[i]), true);
            }
            for (int i = 0; i < Para.ValueJp.Count; i++)
            {
                CKLColumnJp.SetItemChecked(Array.IndexOf(VALUE_JP, Para.ValueJp[i]), true);
            }
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            Para.ValueEn.Clear();
            for (int i = 0; i < CKLColumnEn.Items.Count; i++)
            {
                if (CKLColumnEn.GetItemChecked(i))
                {
                    Para.ValueEn.Add(VALUE_EN[i]);
                }
            }

            Para.ValueJp.Clear();
            for (int i = 0; i < CKLColumnJp.Items.Count; i++)
            {
                if (CKLColumnJp.GetItemChecked(i))
                {
                    Para.ValueJp.Add(VALUE_JP[i]);
                }
            }
            //2.
            Para.CardFontSize = int.Parse(ComFontSize.Text);

            
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            BtnApply_Click(null, null);
            this.Close();
            
        }

    }
}
