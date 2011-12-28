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
    public partial class frmsgzaycWorkFlowEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_04sgzayc> m_CityDic = new SortableSearchableBindingList<PJ_04sgzayc>();
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_04sgzayc,LP_Record";
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
        public frmsgzaycWorkFlowEdit()
        {
            InitializeComponent();
        }
        void dataBind() {
            this.textEdit2.DataBindings.Add("EditValue", rowData, "fsdd"); 
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "tdsj");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "sdsj");
            //this.spinEdit1.DataBindings.Add("EditValue", rowData,ssdl)
            //this.textEdit1.DataBindings.Add("EditValue", rowData, "gtdsj");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "ssdl");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "charMan");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "clqk",false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "yyfx", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "fzdc", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "zxr");

        }
        #region IPopupFormEdit Members
        private PJ_04sgzayc rowData = null;

        public object RowData {
            get {
               // rowData.gtdsj = rowData.sdsj - rowData.tdsj;
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_04sgzayc;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_04sgzayc>(value as PJ_04sgzayc, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //填充下拉列表数据
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            if (ryList.Count>0)
            {
                this.comboBoxEdit6.Properties.Items.AddRange(ryList);
                this.comboBoxEdit1.Properties.Items.AddRange(ryList);
            }
            
        }


        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PJ_dyk dyk = SelectorHelper.SelectDyk("04事故异常运行记录", "异常运行内容", memoEdit2, memoEdit1, memoEdit4);
            if (dyk != null) {
                memoEdit2.Text = memoEdit2.Text + "处理人：" + comboBoxEdit1.Text; 
                
                rowData.yyfx = dyk.nr2;
                rowData.fzdc = dyk.nr3;
            }
        }

        private void memoEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PJ_04sgzayc sbxs = RowData as PJ_04sgzayc;
            string strmes = "";
            object obj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_04sgzayc>(sbxs.ID);
            if (obj == null)
            {
                MainHelper.PlatformSqlMap.Create<PJ_04sgzayc>(sbxs);
            }

            else
            {
                MainHelper.PlatformSqlMap.Update<PJ_04sgzayc>(obj);

            }
            if (isWorkflowCall)
            {
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
    }
}