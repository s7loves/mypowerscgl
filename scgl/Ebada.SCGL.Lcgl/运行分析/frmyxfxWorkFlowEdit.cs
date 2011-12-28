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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmyxfxWorkFlowEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_03yxfx> m_CityDic = new SortableSearchableBindingList<PJ_03yxfx>();
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_03yxfx,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;

            }
        }

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
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
            }
        }

        public frmyxfxWorkFlowEdit()
        {
            InitializeComponent();
            IniControlStatus();
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
                IniControlStatus();

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
                    memoEdit4.Enabled = false;
                    //groupBox4.Enabled = false;
                    //groupBox5.Enabled = false;
                    //groupBox6.Enabled = false;
                    dateEdit3.Enabled = false;
                    comboBoxEdit16.Enabled = false;
                    comboBoxEdit18.Enabled = false;

                    dateEdit4.Enabled = true;
                    comboBoxEdit17.Enabled = true;
                    groupBox7.Enabled = true;
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
            ComboBoxHelper.FillCBoxByDyk("公共属性", "签字人", ((ComboBoxEdit)groupBox7.Controls["comboBoxEdit" + 17]));

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

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strmes = "";
            PJ_03yxfx yxfx = RowData as PJ_03yxfx;
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_03yxfx>(yxfx.ID);
            if (obj == null)
            {

                yxfx.CreateDate = DateTime.Now;
                yxfx.CreateMan = MainHelper.User.UserName;
                MainHelper.PlatformSqlMap.Create<PJ_03yxfx>(yxfx);
                if (isWorkflowCall)
                {
                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ModleRecordID = yxfx.ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.ModleTableName = yxfx.GetType().ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.CreatTime = DateTime.Now;
                    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                }

            }
            else
            {
                MainHelper.PlatformSqlMap.Update<PJ_03yxfx>(RowData);

            }
            //currRecord.ImageAttachment = bt;
            //currRecord.SignImg = bt;
            currRecord.LastChangeTime = DateTime.Now.ToString();
            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { yxfx, currRecord });

            }
            WF_WorkTaskCommands wt;
            //string[] strtemp = RecordWorkTask.RunNewGZPRecord(currRecord.ID, kind, MainHelper.User.UserID);
            wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null)
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            }
            else
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            if (currRecord.ImageAttachment == null)
            {
                currRecord.ImageAttachment = new byte[0];
            }
            if (currRecord.DocContent== null)
            {
                currRecord.DocContent = new byte[0];
            }
            if (currRecord.SignImg == null)
            {
                currRecord.SignImg = new byte[0];
            }
            Export03.ExportExcelWorkFlow(ref  currRecord, (PJ_03yxfx)RowData);
            currRecord.LastChangeTime = DateTime.Now.ToString();
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
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
    }
}