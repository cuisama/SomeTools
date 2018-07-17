using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CompUse
{
    public partial class Main : Form
    {
        private static Dictionary<string, DataTable> SysTables = new Dictionary<string, DataTable>();

        public Main()
        {
            InitializeComponent();
            UpdateControlStatus("153.59.64.177");
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateControlStatus(string dbIp)
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            LastHeight = this.Height;
            LastWidth = this.Width;
            //this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DTGVSqlResult.Wink(false);

            this.BtnExecuteSql.MouseDown += new System.Windows.Forms.MouseEventHandler(Util.BoforeEvent);
            this.BtnExecuteSql.MouseUp += new System.Windows.Forms.MouseEventHandler(Util.AfterEvent);

            TexDBIP.Text = dbIp;

            InitComDBName();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComDBName()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");
            dt.AddRow("ENTSVR", "entsvr,ncrsa_ora");
            dt.AddRow("IFHWRK", "entsvr,ncrsa_ora");
            dt.AddRow("STORESOL", "REALACE,ncrsa_ora");
            dt.AddRow("STORESOLPLU", "REALACE,ncrsa_ora");

            COMDBName.DataSource = dt;
            COMDBName.DisplayMember = "Key";
            COMDBName.ValueMember = "Value";
            //COMDBName.SelectedIndex = 0;
            //COMDBName.FindString("ENTSVR");
            Init("ENTSVR");
            COMDBName.SelectedIndexChanged += new System.EventHandler(COMDBName_SelectedIndexChanged);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        private void Init(string dbName)
        {
            //string dbName = COMDBName.Text;
            string value = string.IsNullOrEmpty(COMDBName.SelectedValue.ToString()) ? Para.PCS_DBUSERID + "," + Para.PCS_DBPASSWORD : COMDBName.SelectedValue.ToString();
            string userId = value.Split(',')[0];
            string password = value.Split(',')[1];
            if (!SysTables.ContainsKey(dbName))
            {
                string sysTables = "SELECT NAME FROM SYS.TABLES ORDER BY NAME";
                //string sysTables = " SELECT NAME,TYPE FROM " + dbName + ".SYS.OBJECTS WHERE TYPE IN ('U','V','P') ORDER BY TYPE,NAME";
                using (DbManager db = new DbManager(TexDBIP.Text.Trim(), dbName, userId, password))
                {
                    SysTables.Add(dbName, db.CreateDataTable(sysTables));
                }
            }
            ComTableName.DataSource = SysTables[dbName];
            ComTableName.DisplayMember = "NAME";

        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExecuteSql_Click(object sender, EventArgs e)
        {
            try
            {
                string dbName = COMDBName.Text;
                string userId = COMDBName.SelectedValue.ToString().Split(',')[0];
                string password = COMDBName.SelectedValue.ToString().Split(',')[1];

                string sql = RTexSql.SelectedText;
                sql = sql == "" ? RTexSql.Text : sql;

                using (DbManager db = new DbManager(TexDBIP.Text.Trim(), dbName, userId, password))
                {
                    DateTime startTime = System.DateTime.Now;
                    //db.BeginTransaction();
                    DataSet tbls = db.CreateDataSet(sql + "\n--");
                    //db.Rollback();
                    LblExeTime.Text = (System.DateTime.Now - startTime).TotalMilliseconds.ToString() + "ms";
                    if (tbls.Tables.Count == 0)
                    {
                        DTGVSqlResult.DataSource = null;
                        LblDataCount.Text = "0行";
                    }
                    else if (tbls.Tables.Count == 1)
                    {
                        DTGVSqlResult.DataSource = tbls.Tables[0];
                        LblDataCount.Text = tbls.Tables[0].Rows.Count + "行";
                    }
                    else
                    {
                        SQLDataSet sqlDataSet = new SQLDataSet(tbls);
                        sqlDataSet.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                Util.CatchException(this);
                throw;
            }
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQLStudio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    BtnExecuteSql_Click(sender, e);
                    break;
            }
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TexTableName_TextChanged(object sender, EventArgs e)
        {
            string dbName = COMDBName.Text;
            if (SysTables.ContainsKey(dbName))
            {
                DataRow[] drs = SysTables[dbName].Select(string.Format("NAME LIKE '%{0}%'", TexTableName.Text));
                DataTable tbl = SysTables[dbName].Clone();
                foreach (DataRow dr in drs)
                {
                    tbl.ImportRow(dr);
                }
                ComTableName.DataSource = tbl;
                ComTableName.DisplayMember = "NAME";
                ComTableName.DroppedDown = true;
                Cursor = Cursors.Default;
            }
        }

        private int LastWidth = 0;
        private int LastHeight = 0;

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Resize(object sender, EventArgs e)
        {
            var spc = sender as Main;
            int movWidth = spc.Width - LastWidth;
            int movHeight = spc.Height - LastHeight;
            LastHeight = spc.Height;
            LastWidth = spc.Width;

            RTexSql.Width += movWidth;
            DTGVSqlResult.Width += movWidth;

            RTexSql.Height += movHeight / 2;
            DTGVSqlResult.Height += movHeight - movHeight / 2;

            DTGVSqlResult.LocMove(0, movHeight / 2);
            LblExeTime.LocMove(movWidth, movHeight);
            LblDataCount.LocMove(movWidth, movHeight);

            LblMoveLine.LocMove(movWidth / 2, movHeight / 2);

        }
        private bool MoveLineFlag = false;

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMoveLine_MouseDown(object sender, MouseEventArgs e)
        {
            MoveLineFlag = true;
            CursorLastPX = Cursor.Position.X;
            CursorLastPY = Cursor.Position.Y;
            Cursor = Cursors.SizeNS;
        }

        private int CursorLastPX = 0;
        private int CursorLastPY = 0;

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMoveLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (MoveLineFlag)
            {
                int movWidth = Cursor.Position.X - CursorLastPX;
                int movHeight = Cursor.Position.Y - CursorLastPY;
                if ((RTexSql.Height < 60 && movHeight < 0) || (DTGVSqlResult.Height < 70 && movHeight > 0))
                {
                    MoveLineFlag = false;
                    Cursor = Cursors.Default;
                    return;
                }
                CursorLastPX = Cursor.Position.X;
                CursorLastPY = Cursor.Position.Y;
                RTexSql.Height += movHeight;
                LblMoveLine.LocMove(0, movHeight);
                DTGVSqlResult.Height -= movHeight;
                DTGVSqlResult.LocMove(0, movHeight);
            }
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMoveLine_MouseUp(object sender, MouseEventArgs e)
        {
            MoveLineFlag = false;
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMoveLine_Enter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNS;
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMoveLine_Leave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void COMDBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Init(COMDBName.Text);
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            string date = RTexData.Text;
            string tableName = ComTableName.Text;
            string[] lines = date.Split('\n');
            string sql = string.Format("INSERT INTO {0} VALUES", tableName);
            for(int i = 0; i < lines.Length; i++)
            {
                sql += "(";
                string[] columns = lines[i].Split('\t');
                for(int j=0;j< columns.Length; j++)
                {
                    if (columns[j].Equals(""))
                    {
                        sql += "NULL,";
                    }
                    else
                    {
                        sql += string.Format("'{0}',", columns[j]);                           
                    }
                }
                sql = sql.Substring(0, sql.Length - 1) + "),";
            }
            sql = sql.Substring(0, sql.Length - 1);
            string ip = TexDBIP.HostName();
            using (DbManager db = new DbManager(ip, Para.PCS_DB))
            {
                db.ExeceteQuery(sql);
                DataTable dt = db.CreateDataTable(string.Format("SELECT * FROM {0}", tableName));
                DTGVSqlResult.DataSource = dt;
            }
        }

        private void ComTableName_TextUpdate(object sender, EventArgs e)
        {
            string dbName = COMDBName.Text;
            if (SysTables.ContainsKey(dbName))
            {
                DataRow[] drs = SysTables[dbName].Select(string.Format("NAME LIKE '%{0}%'", TexTableName.Text));
                DataTable tbl = SysTables[dbName].Clone();
                foreach (DataRow dr in drs)
                {
                    tbl.ImportRow(dr);
                }
                ComTableName.DataSource = tbl;
                ComTableName.DisplayMember = "NAME";
                ComTableName.DroppedDown = true;
                Cursor = Cursors.Default;
            }
        }
    }
}
