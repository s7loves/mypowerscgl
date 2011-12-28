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
    public partial class frmJGGCJHWorkFlowEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_jggcjh> m_CityDic = new SortableSearchableBindingList<PJ_jggcjh>();
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_jggcjh,LP_Record";
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
                if (RecordWorkTask.HaveWorkFlowBackRole(WorkFlowData.Rows[0]["WorkTaskId"].ToString(), WorkFlowData.Rows[0]["WorkFlowId"].ToString()))
                {
                    btBack.Visible = true;
                }
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

        public frmJGGCJHWorkFlowEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "NeedFunds");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "ProjectName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "OrgName"); ;
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "Planenddate");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "ProjecNR");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_jggcjh rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_jggcjh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_jggcjh>(value as PJ_jggcjh, rowData);
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

        private void InitComboBoxData() {

            //填充下拉列表数据
            comboBoxEdit3.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='年度技改工程计划' and sx like '%{0}%' and nr!=''", "编制单位"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("绥化市郊农电局"); 
            }
            
            dateEdit1.DateTime = DateTime.Now;
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


      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("年度技改工程计划", "备注", memoEdit3);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("年度技改工程计划", "主要内容及措施", memoEdit1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PJ_jggcjh sbxs = RowData as PJ_jggcjh;
            string strmes = "";
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_jggcjh>(sbxs.ID);
            if (obj == null)
            {
                MainHelper.PlatformSqlMap.Create<PJ_jggcjh>(sbxs);

                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = sbxs.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = sbxs.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }

            else
            {
                MainHelper.PlatformSqlMap.Update<PJ_jggcjh>(sbxs);

            }
            if (isWorkflowCall)
            {


                currRecord.LastChangeTime = DateTime.Now.ToString();
                if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
                {

                    RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { sbxs, currRecord });

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
                if (currRecord.DocContent == null)
                {
                    currRecord.DocContent = new byte[0];
                }
                if (currRecord.SignImg == null)
                {
                    currRecord.SignImg = new byte[0];
                }

                currRecord.LastChangeTime = DateTime.Now.ToString();
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {

            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认退回?") != DialogResult.OK)
            {
                
                return;
            }
            string strmes = RecordWorkTask.RunWorkFlowBack(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
            {

                currRecord.LastChangeTime = DateTime.Now.ToString();
                currRecord.Status = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                MsgBox.ShowTipMessageBox(strmes);

            }
         
            this.DialogResult = DialogResult.OK;
        }

        private void frmJGGCJHWorkFlowEdit_Load(object sender, EventArgs e)
        {
            
        }

        


       
    }
}