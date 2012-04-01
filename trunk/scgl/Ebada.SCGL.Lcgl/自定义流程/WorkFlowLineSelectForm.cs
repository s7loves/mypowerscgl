using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Scgl.WFlow;
using Ebada.Client;

namespace Ebada.Scgl.Lcgl
{
    public partial class WorkFlowLineSelectForm : FormBase
    {
        public WorkFlowLineSelectForm()
        {
            InitializeComponent();
        }

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private Hashtable checkkeys = null;
        private DataTable retWorkFlowData = null;//实例流程信息
        private string varDbTableName = "LP_Record";
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
        public DataTable RetWorkFlowData
        {
            get { return retWorkFlowData; }
        }
        public static void GetNextTask(string taskid, string workFlowId, ref Hashtable taskht)
        {

            string tmpStr = " where  StartTaskId='" + taskid + "' and WorkFlowId='" + workFlowId + "' order by startTaskCaption";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>("SelectWF_WorkTaskLinkViewList", tmpStr);
            if (li.Count == 1)
            {
                if (li[0].EndTaskTypeId == "7")
                {
                    taskht.Add("跳过", "跳过");
                }
                else
                {
                    foreach (WF_WorkTaskLinkView tl in li)
                    {
                        if (!taskht.ContainsKey(tl.EndTaskId))
                            taskht.Add(tl.EndTaskId, tl.endTaskCaption);

                    }
                }
            }
            else
            {
                foreach (WF_WorkTaskLinkView tl in li)
                {
                    if (!taskht.ContainsKey(tl.EndTaskId))
                        taskht.Add(tl.EndTaskId, tl.endTaskCaption);

                }

            }
        }
        private void WorkFlowLineSelectForm_Load(object sender, EventArgs e)
        {
            string taskid="";
            string workFlowId="";
            checkkeys = new Hashtable();
            taskid = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
            workFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
            GetNextTask(taskid, workFlowId, ref  checkkeys);
            ArrayList akeys = new ArrayList(checkkeys.Keys);
            if (akeys.Count == 1 && akeys[0].ToString() == "跳过")
            {
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
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                comboBoxEdit1.Properties.Items.Clear();
                foreach (string strtask in akeys)
                {
                    ListItem lt = new ListItem();
                    lt.DisplayMember = checkkeys[strtask].ToString();
                    lt.ValueMember = strtask;
                    comboBoxEdit1.Properties.Items.Add(lt);
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            WF_TaskVar wl = MainHelper.PlatformSqlMap.GetOne<WF_TaskVar>(" where TableName='LP_Record' and TableField='Status' "
                + " and WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"] + "'"
                );
            if (wl == null)
            {
                wl = new WF_TaskVar();
                wl.AccessType = "1";
                wl.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                wl.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                wl.TableName = "LP_Record";
                wl.TableField = "Status";
                wl.TaskVarId = Guid.NewGuid().ToString();
                wl.TableField = "Status";
                wl.VarName = "kind";
                wl.VarType = "string";
                wl.VarModule = "out";
                MainHelper.PlatformSqlMap.Create<WF_TaskVar>(wl);
            }
            string tmpStr = " where  StartTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"]
                + "' and WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"] + "'";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>
                ("SelectWF_WorkTaskLinkViewList", tmpStr);
            foreach (WF_WorkTaskLinkView tl in li)
            {
               
                WF_WorkLink wlk = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkLink>
                (tl.WorkLinkId);
                if (wlk.Condition == "")
                {
                    wlk.Condition = "<%kind%>='" + tl.endTaskCaption + "'";
                    wlk.Description = tl.endTaskCaption;
                    MainHelper.PlatformSqlMap.Update<WF_WorkLink>(wlk);
                }
                else
                {
                    wlk.Condition = "<%kind%>='" + tl.endTaskCaption + "'";
                    wlk.Description = tl.endTaskCaption;
                    MainHelper.PlatformSqlMap.Update<WF_WorkLink>(wlk);
                }
            }
            string statustem = currRecord.Status;
            currRecord.Status = comboBoxEdit1.Text;
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
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
                currRecord.Status = statustem;

                currRecord.LastChangeTime = DateTime.Now.ToString();
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
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

            currRecord.LastChangeTime = DateTime.Now.ToString();
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            //retWorkFlowData = WorkFlowData.Clone();
            DataTable dtall = RecordWorkTask.GetRecordWorkFlowData(currRecord.ID, MainHelper.User.UserID);
            retWorkFlowData = dtall.Clone();
            retWorkFlowData.Rows.Clear();
            foreach (DataRow dr in dtall.Rows)
            {
                if (WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() == dr["WorkFlowInsId"].ToString())
                {
                    DataRow dr2 = retWorkFlowData.NewRow();
                    foreach (DataColumn dc in dtall.Columns)
                    {
                        dr2[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    retWorkFlowData.Rows.Add(dr2);
                    break;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
