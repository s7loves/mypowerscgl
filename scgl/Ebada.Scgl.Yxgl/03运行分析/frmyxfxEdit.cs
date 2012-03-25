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
using Ebada.Scgl.WFlow;
using System.Threading;
namespace Ebada.Scgl.Yxgl
{
    public partial class frmyxfxEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_03yxfx> m_CityDic = new SortableSearchableBindingList<PJ_03yxfx>();

        public frmyxfxEdit() {
            InitializeComponent();
            //IniControlStatus();
        }
        void dataBind() {


          this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "zcr");
          this.dateEdit3.DataBindings.Add("EditValue", rowData, "rq");
          this.dateEdit4.DataBindings.Add("EditValue", rowData, "qzrq");
          //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "cjry");
          this.memoEdit5.DataBindings.Add("EditValue", rowData, "zt", false, DataSourceUpdateMode.OnPropertyChanged);
          this.memoEdit1.DataBindings.Add("EditValue", rowData, "jy", false, DataSourceUpdateMode.OnPropertyChanged);
          this.memoEdit2.DataBindings.Add("EditValue", rowData, "jr", false, DataSourceUpdateMode.OnPropertyChanged);
          this.memoEdit4.DataBindings.Add("EditValue", rowData, "py");
          this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "qz");
          this.comboBoxEdit18.DataBindings.Add("EditValue", rowData, "hydd");


        }
        void setqqry()
        {
            string str = rowData.cjry;
            string[] mans = str.Split(new char[1] { ';' }, 15, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 15; i++)
            {
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = "";
               // ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = "";
            }
            for (int i = 0; i < mans.Length; i++)
            {
                //string[] ry = mans[i].Split(':');
                ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue =mans[i];
                //((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue = ry[1];
            }
        }
        void getqqry()
        {
            string str = "";
            string ry = "";
            //string yy = "";
            for (int i = 0; i < 15; i++)
            {
                ry = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue.ToString();
                //yy = ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 11)]).EditValue.ToString();
                if (!string.IsNullOrEmpty(ry.Trim()))
                    str += ry + ";";
            }
            rowData.cjry = str;
        }
        #region IPopupFormEdit Members
        private PJ_03yxfx rowData = null;

        public object RowData {
            get {
                getqqry();
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_03yxfx;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_03yxfx>(value as PJ_03yxfx, rowData);
                }
                setqqry();
            }
        }

        private DataTable  WorkFlowData = null;//实例流程信息

        public DataTable RecordWorkFlowData
        {
            get
            {

                return WorkFlowData;
            }
            set
            {


                WorkFlowData = value;
                   
                
            }
        }
       
        //private int recordStatus = -1;//记录流程
        private int recordStatus = 0;//记录流程
        public int RecordStatus
        {
            get
            {

                return recordStatus;
            }
            set
            {


                recordStatus = value;
                //IniControlStatus();

            }
        }
        #endregion
        private void IniControlStatus()
        {
            switch (recordStatus)
            {
                case 0:
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                    //groupBox4.Enabled = true;
                    //groupBox5.Enabled = true;
                    //groupBox6.Enabled = true;

                    dateEdit4.Enabled = false;
                    comboBoxEdit17.Enabled = false;
                    groupBox7.Enabled = false;
                    break;
                case 1:

                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    //groupBox4.Enabled = false;
                    //groupBox5.Enabled = false;
                    //groupBox6.Enabled = false;

                    dateEdit4.Enabled = false;
                    comboBoxEdit17.Enabled = false;
                    groupBox7.Enabled = true;
                    break;
                case 2:

                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    //groupBox4.Enabled = false;
                    //groupBox5.Enabled = false;
                    //groupBox6.Enabled = false;
                    dateEdit3.Enabled = false;
                    comboBoxEdit16.Enabled = false;
                    comboBoxEdit18.Enabled = false;

                    dateEdit4.Enabled = true;
                    comboBoxEdit17.Enabled = true;
                    groupBox7.Enabled =  false;
                    break;
                default :
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    //groupBox4.Enabled = false;
                    //groupBox5.Enabled = false;
                    //groupBox6.Enabled = false;

                    dateEdit4.Enabled = false;
                    comboBoxEdit17.Enabled = false;
                    groupBox7.Enabled = false;
                    break;
            }
        
        }
        private void InitComboBoxData() {

            //填充下拉列表数据
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
           // ICollection yyList = ComboBoxHelper.GetQqyy();//获取缺勤原因列表
            for (int i = 0; i < 16; i++)
            {
                if (ryList.Count>0)
                {
                    if (i<15)
                    {
                        ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);
                    }
                    if (i>=15)
                    {
                        ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit" + (i + 1)]).Properties.Items.AddRange(ryList);
                    }
                }

                
            }
            //((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]).Properties.Items.AddRange(ryList);
            ((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]).Properties.Items.Clear();
            ComboBoxHelper.FillCBoxByDyk("公用属性", "签字人", ((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]));
            comboBoxEdit18.Properties.Items.Clear();
            comboBoxEdit18.Properties.Items.Add("会议室");
            comboBoxEdit18.Properties.Items.Add("所长室");
            comboBoxEdit18.Properties.Items.Add("配电班");
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
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

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (recordStatus == 0)
            //{

                 PJ_gzrjnr gzr = new PJ_gzrjnr();
                 PJ_03yxfx yxfx = RowData as PJ_03yxfx;
                 object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_03yxfx>(yxfx.ID);
                 if (obj == null)
                 {
                     rowData.gznrID = gzr.gznrID;
                     gzr.ParentID = yxfx.ID;
                     yxfx.CreateDate = DateTime.Now;
                     yxfx.CreateMan = MainHelper.User.UserName;
                     IList<PJ_01gzrj> gzrj01 = MainHelper.PlatformSqlMap.GetList<PJ_01gzrj>("SelectPJ_01gzrjList", "where rq between '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59") + "'");
                     if (gzrj01.Count > 0)
                     {
                         gzr.gzrjID = gzrj01[0].gzrjID;
                     }
                     else
                     {
                         PJ_01gzrj pj = new PJ_01gzrj();
                         pj.gzrjID = pj.CreateID();
                         pj.GdsCode = MainHelper.User.OrgCode;
                         pj.GdsName = MainHelper.User.OrgName;
                         pj.CreateDate = DateTime.Now;
                         pj.CreateMan = MainHelper.User.UserName;
                         gzr.gzrjID = pj.gzrjID;
                         pj.rq = DateTime.Now.Date;
                         pj.xq = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                         pj.rsaqts = (DateTime.Today - MainHelper.UserOrg.PSafeTime.Date).Days;
                         pj.sbaqts = (DateTime.Today - MainHelper.UserOrg.DSafeTime.Date).Days;
                         Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                         MainHelper.PlatformSqlMap.Create<PJ_01gzrj>(pj);


                     }
                         IList<PJ_gzrjnr> gzrlist = MainHelper.PlatformSqlMap.GetList<PJ_gzrjnr>("SelectPJ_gzrjnrList", "where ParentID  = '" + gzr.ParentID + "' order by seq  ");
                         if (gzrlist.Count > 0)
                         {
                             gzr.seq = gzrlist[gzrlist.Count - 1].seq + 1;
                         }
                         else
                             gzr.seq = 1;
                         gzr.gznr = yxfx.hydd + "运行分析-" + yxfx.type;
                         gzr.fzr = yxfx.zcr;
                         gzr.fssj = yxfx.rq;
                         string[] ss = yxfx.cjry.Split(';');
                         if (ss.Length >= 1)
                         {

                             gzr.cjry = ss[0] + "、" + ss[1];
                             if (ss.Length > 2) gzr.cjry = gzr.cjry + "等";
                             gzr.cjry = gzr.cjry + ss.Length + "人";
                         }
                         else
                         {
                             gzr.cjry = gzr.fzr;
                         }


                     
                    
                     
                         MainHelper.PlatformSqlMap.Create<PJ_gzrjnr>(gzr);
                     MainHelper.PlatformSqlMap.Create<PJ_03yxfx>(yxfx);
                 }
                 else
                 {
                     yxfx.CreateDate = yxfx.rq;
                     MainHelper.PlatformSqlMap.Update<PJ_03yxfx>(RowData);
                 }
                //string strmes = RecordWorkTask.RunNewYXFXRecord(rowData.ID, yxfx.type,MainHelper.User.UserID   );
               
                //if (strmes.IndexOf("未提交至任何人") > -1)
                //{
                //    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                //    return;
                //}
                //else
                //    MsgBox.ShowTipMessageBox(strmes);
                //if (gzrj01.Count > 0)
                //    MainHelper.PlatformSqlMap.Create<PJ_gzrjnr>(gzr);
                //MainHelper.PlatformSqlMap.Create<PJ_03yxfx>(yxfx);
                //this.Close();
            //}
            //else
            //{
            //    //try
            //    //{
            //    //    string strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            //    //    if (strmes.IndexOf("未提交至任何人") > -1)
            //    //    {
            //    //        MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
            //    //        return;
            //    //    }
            //    //    else
            //    //        MsgBox.ShowTipMessageBox(strmes);
                   
            //    //}
            //    //catch (System.Exception ex)
            //    //{
                	
            //    //}

            //    MainHelper.PlatformSqlMap.Update<PJ_03yxfx>(RowData);

            //}

            //this.Close(); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           PJ_dyk dyk= SelectorHelper.SelectDyk("03运行分析记录", "分析记录内容", memoEdit5,memoEdit1,memoEdit2);
            if (dyk != null)
            {
                rowData.zt = dyk.nr;
                rowData.jy = dyk.nr2;
                rowData.jr = dyk.nr3;
            }
            //memoEdit1.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmorgRySelect fr = new frmorgRySelect();
            fr.gdscode = rowData.OrgCode;
            DataTable dt = new DataTable();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dt = fr.DT1;
                if (MsgBox.ShowAskMessageBox("是否确认快速写入人名") == DialogResult.OK)
                {
                    if (dt.Rows.Count >= 15)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = dt.Rows[i][0].ToString();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ((ComboBoxEdit)groupBox2.Controls["comboBoxEdit" + (i + 1)]).EditValue = dt.Rows[i][0].ToString();
                        }
                    }
                }
            }
        }
    }
}