using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using System.Collections;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using Ebada.Scgl.WFlow;
using Ebada.Client;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.Utils;

namespace Ebada.Scgl.Lcgl
{
    public partial class jddzInquiryForm : FormBase
    {
        public jddzInquiryForm()
        {
            InitializeComponent();
        }

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
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
            set { currRecord = value; }
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

                if (isWorkflowCall)
                {
                    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                    {
                        barFJLY.Visible = true;
                        if (fjly == null) fjly = new frmModleFjly();
                    }
                    //liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    //liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        //if (wt.CommandName == "01")
                        //{
                        //    //SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                        //    //if (wt.Description != "") SubmitButton.Caption = wt.Description;
                        //    //barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //}
                        //else
                        //    if (wt.CommandName == "02")
                        //    {
                                TaskOverButton.Visible = true;
                                if (wt.Description != "") TaskOverButton.Text = wt.Description;
                            //}

                    }
                }
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string strSQL = "where 1=1 and type!='原始库存' ";
            
            int i = 0;
            WaitDialogForm wdf = new WaitDialogForm("", "正在查询数据...");
            if (comboBoxEdit4.Text == "入库")
            {
                strSQL = strSQL + " and type='入库单'  ";
            }
            if (comboBoxEdit4.Text == "出库")
            {
                strSQL = strSQL + " and type='出库单'  ";
            } 
            if (checkEdit1.Checked)
            {

                strSQL = strSQL + " and (indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";

            }
            if (checkEdit2.Checked)
            {

                strSQL = strSQL + " and (wpmc =  '" + cbeWPMC.Text + "' ) ";

            }
            if (checkEdit3.Checked)
            {

                strSQL = strSQL + " and (wpgg =  '" + cbewpgg.Text + "' ) ";

            }
            if (checkEdit4.Checked)
            {

                strSQL = strSQL + " and (wpdw =  '" + cbewpdw.Text + "' ) ";

            }
            //if (checkEdit5.Checked)
            {

                strSQL = strSQL + " and (OrgName =  '" + cbeOrg.Text + "' ) ";

            }
            //strSQL = strSQL + "  order by type,indate";

            uCmjddzInquiry1.StrOrgName = cbeOrg.Text;
            uCmjddzInquiry1.StrSQL = strSQL;
          
            wdf.Close();
        }
        
        private void IniData()
        {
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgName  from mOrg  where 1=1 order by OrgCode");
            cbeOrg.Properties.Items.AddRange(li);
            if (cbeOrg.Properties.Items.Count > 0)
            {
                cbeOrg.SelectedIndex = 0;
            }
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpmc  from PJ_clcrkd  where 1=1 ");
            cbeWPMC.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpgg  from PJ_clcrkd  where 1=1 ");
            cbewpgg.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpdw  from PJ_clcrkd  where 1=1 ");
            cbewpdw.Properties.Items.AddRange(li);
            
        }
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            IniData();
        }

        private void cbeWPMC_TextChanged(object sender, EventArgs e)
        {
            cbewpgg.Properties.Items.Clear();
            cbewpdw.Properties.Items.Clear();
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpgg  from PJ_clcrkd  where 1=1 and wpmc='" + cbeWPMC.Text + "' ");
            cbewpgg.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpdw  from PJ_clcrkd  where 1=1 and wpmc='" + cbeWPMC.Text + "' ");
            cbewpdw.Properties.Items.AddRange(li);
        }

        private void barFJLY_ItemClick(object sender, EventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }

        private void TaskOverButton_ItemClick(object sender, EventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string strmes = "";
            WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
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
            fjly.btn_Submit_Click(sender, e);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            currRecord.LastChangeTime = DateTime.Now.ToString();
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            this.Close();
        }



    
  
       

      

       
    }
}
