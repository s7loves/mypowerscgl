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
    public partial class UCAQGJTZInquiry : FormBase
    {
        public UCAQGJTZInquiry()
        {
            InitializeComponent();
        }
        string strSQL = "";

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record,PJ_anqgjcrkd";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                //ucclck1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucsctz1.IsWorkflowCall = value;

            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucsctz1.CurrRecord = value;
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
                    ucsctz1.RecordWorkFlowData = value;
                    ucsctz1.liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucsctz1.VarDbTableName = value;
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string strSQL = "where 1=1 and (type='局安全工器具入库单' or type='局安全工器具出库单'  ) ";
            int i = 0;

            
            WaitDialogForm wdf = new WaitDialogForm("", "正在查询数据...");
            if (comboBoxEdit1.Text != "")
                strSQL += " and orgname='" + comboBoxEdit1.Text + "' ";
            if (comboBoxEdit3.Text != "")
                strSQL += " and wpmc='" + comboBoxEdit3.Text + "' ";
            if (comboBoxEdit4.Text != "")
                strSQL += " and wpgg='" + comboBoxEdit4.Text + "' ";
            if (comboBoxEdit5.Text != "")
                strSQL += " and type='" + comboBoxEdit5.Text + "' ";
            if (checkEdit1.Checked && checkEdit2.Checked)
            {
                strSQL = strSQL + " and ((indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59'  and (type like '%入库单'  )  ) "
                    + " or (ckdate between  '" + deEditTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deEditTimeEnd.DateTime.ToString("d") + " 23:59:59' and (type like '%出库单' or type like '%材料单' )  )) ";
            }
            else
            if (checkEdit1.Checked)
            {
                strSQL = strSQL + " and (indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59'  and (type like '%入库单'  ) ) ";
            }
            else
            if (checkEdit2.Checked)
            {
                strSQL = strSQL + " and (ckdate between  '" + deEditTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deEditTimeEnd.DateTime.ToString("d") + " 23:59:59' and (type like '%出库单' or type like '%材料单' )  ) ";
            }
            ucsctz1.StrSQL=(strSQL);
               
              
           
            
            wdf.Close();
        }
   
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            //comboBoxEdit5.SelectedIndex = 0;
            comboBoxEdit3.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpmc  from PJ_anqgjcrkd where 1=1  and wpmc!='' ");
            comboBoxEdit3.Properties.Items.AddRange(mclist);

            comboBoxEdit1.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgName   from mOrg where OrgType = '1' or OrgType = '2'");
            comboBoxEdit1.Properties.Items.AddRange(mclist);
        }

        

       
        private void comboBoxEdit3_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit4.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", 
                "select distinct wpgg  from PJ_anqgjcrkd where  wpmc='" + comboBoxEdit3.Text + "' and wpgg!='' ");
            comboBoxEdit4.Properties.Items.AddRange(mclist);
        }

        private void TaskOverButton_Click(object sender, EventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string strmes = "";

            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

            }
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
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);

            //gridControl1.FindForm().Close();
            this.Close();
        }

        private void barFJLY_Click(object sender, EventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }


  
    
  
       

      

       
    }
}
