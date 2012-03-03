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
        private string varDbTableName = "LP_Record,PJ_clcrkd";
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
            string strSQL = "where 1=1  ";
            
            int i = 0;
            WaitDialogForm wdf = new WaitDialogForm("", "正在查询数据...");
            try
            {
                if (comboBoxEdit1.Text != "")
                    strSQL += " and ssgc='" + comboBoxEdit1.Text + "' ";
                if (comboBoxEdit2.Text != "")
                    strSQL += " and ssxm='" + comboBoxEdit2.Text + "' ";
                if (comboBoxEdit3.Text != "")
                    strSQL += " and wpmc='" + comboBoxEdit3.Text + "' ";
                if (comboBoxEdit4.Text != "")
                    strSQL += " and wpgg='" + comboBoxEdit4.Text + "' ";
                if (comboBoxEdit5.Text != "")
                    strSQL += " and type like'%" + comboBoxEdit5.Text + "%' ";
                if (comboBoxEdit7.Text != "")
                    strSQL += " and lqdw='" + comboBoxEdit7.Text + "' ";
                if (comboBoxEdit8.Text != "")
                    strSQL += " and ghdw='" + comboBoxEdit8.Text + "' ";

                if (checkEdit1.Checked && deCreatTimeStart.Text != "")
                {
                    strSQL = strSQL + " and (indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";
                }
                if (checkEdit2.Checked && deEditTimeStart.Text != "")
                {
                    strSQL = strSQL + " and (ckdate between  '" + deEditTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deEditTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";
                }
                uCmjddzInquiry1.StrSQL = strSQL;
            }
            catch { }
            wdf.Close();
        }
        
       
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            comboBoxEdit1.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ssgc  from PJ_clcrkd where 1=1  and ssgc!='' ");
            comboBoxEdit1.Properties.Items.AddRange(mclist);

            comboBoxEdit7.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct lqdw  from PJ_clcrkd where 1=1  and lqdw!='' ");
            comboBoxEdit7.Properties.Items.AddRange(mclist);
            comboBoxEdit8.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ghdw  from PJ_clcrkd where 1=1  and ghdw!='' ");
            comboBoxEdit8.Properties.Items.AddRange(mclist);
           
        }
        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct ssxm  from PJ_clcrkd where  ssgc!='' ");
            comboBoxEdit2.Properties.Items.AddRange(mclist);

            comboBoxEdit3.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpmc  from PJ_clcrkd where  ssgc='" + comboBoxEdit1.Text + "' and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpgg  from PJ_clcrkd where  ssgc='" + comboBoxEdit1.Text + "' and  wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit2_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit3.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpmc  from PJ_clcrkd where  ssxm='" + comboBoxEdit2.Text + "'  and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit4.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpgg  from PJ_clcrkd where  ssxm='" + comboBoxEdit2.Text + "'  and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void comboBoxEdit3_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit4.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpgg  from PJ_clcrkd where  wpmc='" + comboBoxEdit3.Text + "' and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
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
