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
    public partial class UCrsdaInquiry : FormBase
    {
        public UCrsdaInquiry()
        {
            InitializeComponent();
        }
        string strSQL = "";

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record,PJ_ryda";
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
            string strSQL = "where 1=1 ";
            int i = 0;

            
            WaitDialogForm wdf = new WaitDialogForm("", "正在查询数据...");
            try
            {
                if (comboBoxEdit1.Text != "")
                    strSQL += " and wdmc='" + comboBoxEdit1.Text + "' ";
                if (comboBoxEdit2.Text != "")
                    strSQL += " and wdlx='" + comboBoxEdit2.Text + "' ";
                if (comboBoxEdit3.Text != "")
                    strSQL += " and orgname='" + comboBoxEdit3.Text + "' ";
                IList<PJ_ryda> li = MainHelper.PlatformSqlMap.GetListByWhere<PJ_ryda>(strSQL);
                DataTable dt = new DataTable();
                dt.Columns.Add("wdmc");
                dt.Columns.Add("wdlx");
                dt.Columns.Add("OrgName");
                dt.Columns.Add("show");
                dt.Columns.Add("ID"); 
                foreach(PJ_ryda ry in li)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = ry.ID ;
                    dr["wdmc"] = ry.wdmc;
                    dr["wdlx"] = ry.wdlx;
                    dr["OrgName"] = ry.OrgName;
                    dr["show"] = "查看";
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
            }
            catch { }
              
           
            
            wdf.Close();
        }


        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int ihand = gridView1.FocusedRowHandle;
            if (ihand < 0)
                return;
            DataRow dr = gridView1.GetDataRow(ihand);
            PJ_ryda ry = MainHelper.PlatformSqlMap.GetOneByKey<PJ_ryda>(dr["ID"]);
            frmrsdaTemplate frm = new frmrsdaTemplate();
            frm.pjobject = ry;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            //comboBoxEdit5.SelectedIndex = 0;
            

            comboBoxEdit1.Properties.Items.Clear();
            IList  mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct UserName  from mUser where 1=1  and UserName!='' ");
            comboBoxEdit1.Properties.Items.AddRange(mclist);

            comboBoxEdit2.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct PostName  from mUser where 1=1  and PostName!='' ");
             comboBoxEdit2.Properties.Items.AddRange(mclist);

             comboBoxEdit3.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct OrgName  from mOrg where 1=1  and OrgName!='' ");
             comboBoxEdit3.Properties.Items.AddRange(mclist);

        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct PostName  from mUser where  UserName='" + comboBoxEdit1.Text + "' ");
            comboBoxEdit2.Properties.Items.AddRange(mclist);

            
           
        }

       
        private void comboBoxEdit3_TextChanged(object sender, EventArgs e)
        {


            comboBoxEdit1.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct UserName  from mUser where  OrgName='" + comboBoxEdit3.Text + "' and UserName!='' ");
            comboBoxEdit1.Properties.Items.AddRange(mclist);

            comboBoxEdit2.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
               "select distinct PostName  from mUser  where  OrgName='" + comboBoxEdit3.Text + "' and UserName!='' ");
            comboBoxEdit2.Properties.Items.AddRange(mclist);
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

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName != "show" )
                e.Cancel = true;
        }


  
    
  
       

      

       
    }
}
