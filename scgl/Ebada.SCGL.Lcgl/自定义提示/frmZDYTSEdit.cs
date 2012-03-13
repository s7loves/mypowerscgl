using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
using System.Text.RegularExpressions;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmZDYTSEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PJ_znts> m_CityDic = new SortableSearchableBindingList<PJ_znts>();

        public frmZDYTSEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "szdx");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "xsgs");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "tjsql");
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "sql");


        }
        #region IPopupFormEdit Members
        private PJ_znts rowData = null;

        public object RowData
        {
            get
            {

                return rowData;

            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as PJ_znts;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_znts>(value as PJ_znts, rowData);
                }

            }
        }

        #endregion




        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void InitComboBoxData()
        {

            //填充下拉列表数据








        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }




        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmSQLSet fe = new frmSQLSet();
            fe.StrSQL = rowData.tjsql;
            if (fe.ShowDialog() == DialogResult.OK)
            {
                memoEdit3.Text = fe.StrSQL;
                rowData.tjsql = fe.StrSQL;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmSQLSet fe = new frmSQLSet();
            fe.StrSQL = rowData.sql;
            if (fe.ShowDialog() == DialogResult.OK)
            {
                memoEdit4.Text = fe.StrSQL;
                rowData.sql = fe.StrSQL;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmSQLSet fe = new frmSQLSet();
            fe.StrSQL = rowData.xsgs;
            if (fe.ShowDialog() == DialogResult.OK)
            {
                memoEdit1.Text = fe.StrSQL;
                rowData.xsgs = fe.StrSQL;
            }
        }

        private void frmZDYTSEdit_Load(object sender, EventArgs e)
        {
            memoEdit2.Text = "说明 SQL语句支持中的特殊代码\r\n {orgcode}:用户单位编号\r\n{orgname}:用户单位名称\r\n{userid}:用户编号\r\n";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string xstj = "";
            IList li = InitSQLData(rowData.tjsql);
            if (li.Count == 1)
            {
                if (li[0] == null || li[0].ToString().IndexOf("出错:") > -1)
                {
                    if (li[0] != null)
                    {
                        MsgBox.ShowTipMessageBox("显示条件语句出错，" + li[0]);
                        return;
                    }
                    else
                    {
                        MsgBox.ShowTipMessageBox("设置显示格式出错!");
                        return;
                    }
                }
            }
            li = InitSQLData(rowData.sql);
            if (li.Count == 1)
            {
                if (li[0] == null || li[0].ToString().IndexOf("出错:") > -1)
                {
                    if (li[0] != null)
                    {
                        MsgBox.ShowTipMessageBox("设置提示个数SQL出错，" + li[0]);
                        return;
                    }
                    else
                    {
                        MsgBox.ShowTipMessageBox("设置显示格式出错!");
                        return;
                    }
                }
            }
            string ss = "select  top 1 '" + rowData.xsgs.Replace("{gs}", li.Count.ToString()) + "'from mOrg where 1=1";
            li = InitSQLData(ss);
            if (li.Count == 1)
            {
                if (li[0] == null || li[0].ToString().IndexOf("出错:") > -1)
                {
                    if (li[0] != null)
                    {
                        MsgBox.ShowTipMessageBox("设置显示格式出错，" + li[0]);
                        return;
                    }
                    else
                    {
                        MsgBox.ShowTipMessageBox("设置显示格式出错!" );
                        return;
                    }
                }
            }
            showMessage(3,li[0].ToString());
        }
        private void showMessage(int type, string nr)
        {
            TaskbarNotifier taskbarNotifier1 = new TaskbarNotifier();
            switch (type)
            {
                case 1:
                    taskbarNotifier1.SetBackgroundBitmap(new Bitmap(Image.FromStream(typeof(DownFileControl).Assembly.GetManifestResourceStream("Ebada.Scgl.Lcgl.Resources.skin1.bmp"))), Color.FromArgb(255, 0, 255));
                    taskbarNotifier1.SetCloseBitmap(new Bitmap(Image.FromStream(typeof(DownFileControl).Assembly.GetManifestResourceStream("Ebada.SCGL.Lcgl.Resources.close.bmp"))), Color.FromArgb(255, 0, 255), new Point(127, 8));
                    taskbarNotifier1.TitleRectangle = new Rectangle(40, 9, 70, 25);
                    taskbarNotifier1.ContentRectangle = new Rectangle(8, 41, 133, 68);
                    break;
                case 2:
                    taskbarNotifier1.SetBackgroundBitmap(new Bitmap(Image.FromStream(typeof(DownFileControl).Assembly.GetManifestResourceStream("Ebada.Scgl.Lcgl.Resources.skin2.bmp"))), Color.FromArgb(255, 0, 255));
                    taskbarNotifier1.SetCloseBitmap(new Bitmap(Image.FromStream(typeof(DownFileControl).Assembly.GetManifestResourceStream("Ebada.Scgl.Lcgl.Resources.close.bmp"))), Color.FromArgb(255, 0, 255), new Point(300, 74));
                    taskbarNotifier1.TitleRectangle = new Rectangle(123, 80, 176, 16);
                    taskbarNotifier1.ContentRectangle = new Rectangle(116, 97, 197, 22);
                    break;
                default:
                    taskbarNotifier1.SetBackgroundBitmap(new Bitmap(Image.FromStream(typeof(DownFileControl).Assembly.GetManifestResourceStream("Ebada.Scgl.Lcgl.Resources.skin3.bmp"))), Color.FromArgb(255, 0, 255));
                    taskbarNotifier1.SetCloseBitmap(new Bitmap(Image.FromStream(typeof(DownFileControl).Assembly.GetManifestResourceStream("Ebada.Scgl.Lcgl.Resources.close.bmp"))), Color.FromArgb(255, 0, 255), new Point(280, 57));
                    taskbarNotifier1.TitleRectangle = new Rectangle(150, 57, 125, 28);
                    taskbarNotifier1.ContentRectangle = new Rectangle(75, 92, 215, 55);
                    break;
            }
            taskbarNotifier1.CloseClickable = true;
            taskbarNotifier1.TitleClickable = false;
            taskbarNotifier1.ContentClickable = true;
            taskbarNotifier1.EnableSelectionRectangle = true;
            taskbarNotifier1.KeepVisibleOnMousOver = true;	// Added Rev 002
            taskbarNotifier1.ReShowOnMouseOver = false;			// Added Rev 002
            //taskbarNotifier1.TitleClick += new EventHandler(TitleClick);
            //taskbarNotifier1.CloseClick += new EventHandler(CloseClick);
            taskbarNotifier1.Show("农电生产系统", nr, 10, 5000, 50);

        }
        
        public IList InitSQLData(string sqlSentence)
        {



            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            Regex r1;
            if (sqlSentence != "")
            {
                
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName );
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
               



                }
              
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", " ");
                    li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                    if (sqlSentence.IndexOf("where 9=9") > -1)
                    {
                        string strtemp = li[0].ToString();
                        li.Clear();
                        r1 = new Regex(@"[0-9]+\+[0-9]+");
                        if (r1.Match(strtemp).Value != "")
                        {
                            int istart = 1;
                            int ilen = 10;
                            r1 = new Regex(@"[0-9]+(?=\+)");
                            if (r1.Match(strtemp).Value != "")
                            {
                                istart = Convert.ToInt32(r1.Match(strtemp).Value);
                            }
                            r1 = new Regex(@"(?<=\+)[0-9]+");
                            if (r1.Match(strtemp).Value != "")
                            {
                                ilen = Convert.ToInt32(r1.Match(strtemp).Value); ;
                            }
                            for (int i = istart; i <= ilen; i++)
                            {
                                li.Add(string.Format("{0}", i));
                            }
                        }
                        else
                        {
                            string[] strli = SelectorHelper.ToDBC(strtemp).Split(',');
                            foreach (string ss in strli)
                            {
                                li.Add(ss);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    li.Add("出错:" + ex.Message);
                }
                return li;
            }
        }
    }

       

      

       
    
