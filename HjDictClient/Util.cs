using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HjDictClient
{
    public static class Util
    {
        /// <summary>
        /// 将单词显示一个新的dialog窗口里
        /// </summary>
        /// <param name="words"></param>
        public static void ShowWordDialog(Word[] words)
        {
            DataRow[] dr = words.ToDataRow();
            Dialog dialog = new Dialog();//在新的线程里创建的窗口，线程结束后，窗口使用的资源就会被释放
            int startLocationY = 0;
            UctWordEn card = null;
            for (int i = 0; i < dr.Length; i++)
            {
                card = new UctWordEn(dr[i]);
                card.Location = new Point(0, startLocationY);
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                startLocationY += card.Height;
                dialog.UctPal.Controls.Add(card);
                dialog.Text = words[0].Value;
            }
            dialog.Show();//showdialog 必须先关掉才能操作其他画面，show可以随便操作其他画面
        }
    }

}
