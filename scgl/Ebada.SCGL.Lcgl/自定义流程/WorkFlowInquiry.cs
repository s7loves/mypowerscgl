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

namespace Ebada.Scgl.Lcgl
{
    public partial class WorkFlowInquiry : FormBase
    {
        public WorkFlowInquiry()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string strSQL = "where 1=1 ";
            int i = 0;
            object workFlowId = MainHelper.PlatformSqlMap.GetObject("SelectOneStr", "select WorkFlowId from WF_WorkFlow  where FlowCaption='" + cbeWorkFlowCaption.Text + "'");
            if (workFlowId == null) return;
            string workTaskId = "";
            for (i = 0; xtraTabControl1.TabPages.Count>1;)
            {
                if (xtraTabControl1.TabPages[i].Text != "流程信息")
                {
                    xtraTabControl1.TabPages.Remove(xtraTabControl1.TabPages[i]);
                }
                else
                {
                    i++;
                }
            }
                if (cbeWorkFlowCaption.Text != "全部")
                {

                    if (cbeWorkFlowCaption.Text == "电力线路倒闸操作票")
                    {
                        strSQL = strSQL + " and (Kind='dzczp' or Kind='电力线路倒闸操作票') ";
                    }
                    else if (cbeWorkFlowCaption.Text == "电力线路第一种工作票")
                    {
                        strSQL = strSQL + " and (Kind='yzgzp' or Kind='电力线路第一种工作票') ";
                    }
                    else if (cbeWorkFlowCaption.Text == "电力线路第二种工作票")
                    {
                        strSQL = strSQL + " and (Kind='ezgzp' or Kind='电力线路第二种工作票') ";
                    }
                    else if (cbeWorkFlowCaption.Text == "电力线路事故应急抢修单")
                    {
                        strSQL = strSQL + " and (Kind='xlqxp' or Kind='电力线路事故应急抢修单') ";
                    }
                    else
                    {
                        strSQL = strSQL + " and (Kind='" + cbeWorkFlowCaption.Text + "' ) ";
                    }
                }
            if (cbeOrg.Text != "全部")
            {
                strSQL = strSQL + " and (OrgName='" + cbeOrg.Text + "' ) ";
            }
            if (cbeStatus.Text != "全部")
            {
                strSQL = strSQL + " and (Status='" + cbeStatus.Text + "' ) ";
                workTaskId = ((ListItem)cbeStatus.SelectedItem).ValueMember;
            }
            if (teNumber.Text != "")
            {
                strSQL = strSQL + " and (Number='" + teNumber.Text + "' ) ";
            }
            GetckField(ref  strSQL, ceField1, cbeField1, cbeFieldRule1, teField1, workFlowId.ToString(), workTaskId);
            GetckField(ref  strSQL, ceField2, cbeField2, cbeFieldRule2, teField2, workFlowId.ToString(), workTaskId);
            GetckField(ref  strSQL, ceField3, cbeField3, cbeFieldRule3, teField3, workFlowId.ToString(), workTaskId);
            if (checkEdit1.Checked)
            {
                strSQL = strSQL + " and (CreateTime between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";
            }
            if (checkEdit2.Checked)
            {
                strSQL = strSQL + " and (LastChangeTime between  '" + deEditTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deEditTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";
            }
            uCmLPInquiryRecord1.StrSQL = strSQL;
            if (teModleTable.Text != "")
            {
                string strModleSQL = "",str1="";
                string[] strTableidli = teModleTable.Text.Split(',');
                IList<LP_Record> li = MainHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", strSQL);
                strModleSQL = "";
                 if (workTaskId != "")
                {
                    str1 = "and WorkTaskId='" + workTaskId + "' ";
                }
               
                foreach (LP_Record lp in li)
                {
                    if (strModleSQL == "")
                        strModleSQL = " select ModleRecordID from WF_ModleRecordWorkTaskIns where   WorkFlowId='" 
                            + workFlowId + "' "
                            + str1 + " and (RecordID='"+lp.ID+"' ";
                    else
                        strModleSQL = strModleSQL + " or RecordID='" + lp.ID + "' ";
                   

                }
                strModleSQL = strModleSQL + " )";
                foreach (string strtable in strTableidli)
                {
                    string str2 = "";
                    if (strtable == "LP_Record")
                    {
                        continue;
                    }
                    object keyobj = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '"
                        + strtable + "'");
                    str2 = " select * from "+strtable+" where "+keyobj+" in ("+strModleSQL+")";
                    XtraTabPage modleTabPage=new XtraTabPage ();
                    modleTabPage.Text = "表" + strtable+"相关记录";
                    UCmLPInquiryModleRecord modlerecord = new UCmLPInquiryModleRecord();
                    modlerecord.TableName = strtable;
                    modlerecord.StrSQL = str2;
                    modlerecord.Keyobj = keyobj.ToString();
                    modlerecord.Dock = DockStyle.Fill;
                    modleTabPage.Controls.Add(modlerecord);
                    xtraTabControl1.TabPages.Add(modleTabPage);
                }
            }

        }
        private void GetckField(ref string strSQL, CheckEdit ceField,ComboBoxEdit cbeField,ComboBoxEdit cbeFieldRule,TextEdit teField, string workFlowId, string workTaskId)
        {
            string  strname = "";
            int index = 0;
            if (ceField.Checked)
            {
                string str1 = "";
                index = cbeField.SelectedIndex;
                strname = cbeFieldTable1.Properties.Items[index].ToString();
                if (workTaskId != "")
                {

                    str1 = "and WorkTaskId='" + workTaskId + "' ";
                }
                if (strname == "表单")
                {
                    if (cbeFieldRule.Text == "包含")
                    {
                        strSQL = strSQL + " and  ID in  ( select RecordID from WF_TableFieldValueView where 1=1"
                         + " and WorkFlowId='" + workFlowId + "' " + str1
                         + "  and  " + ((ListItem)cbeField.SelectedItem).ValueMember + " like '%" + teField.Text + "%'"
                          + ") ";
                    }
                    else if (cbeFieldRule.Text == "不包含")
                    {
                        strSQL = strSQL + " and  ID  not in  ( select RecordID from WF_TableFieldValueView where 1=1"
                         + " and WorkFlowId='" + workFlowId + "' " + str1
                         + "  and  " + ((ListItem)cbeField.SelectedItem).ValueMember + " like '%" + teField.Text + "%'"
                         + " ) ";
                    }
                }
                else
                {

                    object keyobj = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + strname + "'");
                    if (workTaskId != "")
                    {

                        str1 = "and WorkTaskId='" + workTaskId + "' ";
                    }
                    if (cbeFieldRule.Text == "包含")
                    {
                        strSQL = strSQL + " and  ID in  ( select RecordID from WF_ModleRecordWorkTaskIns where 1=1"
                        + " and WorkFlowId='" + workFlowId + "' " + str1
                    + " and  ModleRecordID  in ("
                            +
                            " select " + keyobj + " from " + strname + " where " + ((ListItem)cbeField.SelectedItem).ValueMember + " like '%" + teField.Text + "%'"
                            + ") ) ";
                    }
                    else if (cbeFieldRule.Text == "不包含")
                    {
                        strSQL = strSQL + " and  ID not in  ( select RecordID from WF_ModleRecordWorkTaskIns where 1=1"
                    + " and WorkFlowId='" + workFlowId + "' " + str1
                    + " and ModleRecordID  in ("
                            +
                            " select " + keyobj + " from " + strname + " where " + ((ListItem)cbeField.SelectedItem).ValueMember + "  like '%" + teField.Text + "%'"
                            + ") ) ";
                    }

                }
            }
        
        }
        private void IniData()
        {
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select FlowCaption from WF_WorkFlow  where 1=1");
            cbeWorkFlowCaption.Properties.Items.AddRange(li);
            cbeOrg.Properties.Items.Clear();
            ListItem item = new ListItem("全部", "全部");
            cbeOrg.Properties.Items.Add(item);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgName  from mOrg  where 1=1");
            cbeOrg.Properties.Items.AddRange(li);
            deCreatTimeStart.DateTime = DateTime.Now;
            deCreatTimeEnd.DateTime = DateTime.Now;
            deEditTimeStart.DateTime = DateTime.Now;
            deEditTimeEnd.DateTime = DateTime.Now;
        }
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            IniData();
        }

        private void cbeWorkFlowCaption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i=0;
            string varDbTableName = "";
            string strSQL = "";
            object workFlowId = MainHelper.PlatformSqlMap.GetObject("SelectOneStr", "select WorkFlowId from WF_WorkFlow  where FlowCaption='" + cbeWorkFlowCaption.Text + "'");
            if (workFlowId == null) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  WorkTaskId+','+TaskCaption from WF_WorkTask  where WorkFlowId='" + workFlowId + "'");
            cbeStatus.Properties.Items.Clear();
            cbeField1.Properties.Items.Clear();
            cbeField2.Properties.Items.Clear();
            cbeField3.Properties.Items.Clear();
            cbeFieldTable1.Properties.Items.Clear();
            ListItem item=new ListItem ("全部","全部");
            cbeStatus.Properties.Items.Add(item);
            teModleTable.Text="";

            IList fieldli =null;
            for (i = 0; i < li.Count; i++)
            {
                string[] strTaskidli = li[i].ToString().Split(',');
                if (strTaskidli[1].IndexOf("结束节点1") > -1)
                {
                    strTaskidli[1] = "存档";
                
                }
                item = new ListItem(strTaskidli[0],strTaskidli[1]);
                cbeStatus.Properties.Items.Add(item);
                object fromCtrl = RecordWorkTask.GetWorkTaskModle(workFlowId.ToString(), strTaskidli[0]);
                if (fromCtrl.GetType().GetProperty("VarDbTableName") != null && fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null) != null)
                    varDbTableName = fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null).ToString();
                else
                {
                    MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                    return;
                }
                
                if ((fromCtrl is frmLP) == false)
                {
                    if (teModleTable.Text.IndexOf(varDbTableName) == -1)
                    {
                        if (teModleTable.Text == "")
                            teModleTable.Text = varDbTableName;
                        else
                            teModleTable.Text = teModleTable.Text + "," + varDbTableName;
                    }
                    string[] nameli = varDbTableName.ToString().Split(',');
                    foreach (string strname in nameli)
                    {
                        if (strname == "LP_Record")
                        {
                            continue;
                        }
                        strSQL= "SELECT c.name+'^'+CAST(ex.value as nvarchar) "
                            +" FROM  sys.columns c LEFT OUTER JOIN  sys.extended_properties ex "+
                            " ON    ex.major_id = c.object_id   AND ex.minor_id = c.column_id     AND ex.name = 'MS_Description' WHERE "
                            +" OBJECTPROPERTY(c.object_id, 'IsMsShipped')=0 "
                             +   "AND OBJECT_NAME(c.object_id) = '"+strname+"' ORDER    BY OBJECT_NAME(c.object_id), c.column_id";
                        fieldli = MainHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                        foreach (string strfield in fieldli)
                        {
                            if (strfield == null) continue;
                            string[] fieldvalueli = strfield.ToString().Split('^');
                            item = new ListItem(fieldvalueli[0], fieldvalueli[1]);
                            cbeField1.Properties.Items.Add(item);
                            cbeField2.Properties.Items.Add(item);
                            cbeField3.Properties.Items.Add(item);
                            item = new ListItem(strname, strname);
                            cbeFieldTable1.Properties.Items.Add(item);
                        }
                    }

                }//节点关联的是模块表
                else
                { 
                    fieldli = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "SELECT  distinct FieldName from WF_TableFieldValueView where "
                        +" WorkFlowId='"+workFlowId+"' and WorkTaskId='"+strTaskidli[0]+"'");
                    foreach (string strfield in fieldli)
                    {

                        item = new ListItem(strfield, strfield);
                        cbeField1.Properties.Items.Add(item);
                        cbeField2.Properties.Items.Add(item);
                        cbeField3.Properties.Items.Add(item);
                        item = new ListItem("表单", "表单");
                        cbeFieldTable1.Properties.Items.Add(item);
                    }
                
                }

            }
            
            if (cbeOrg.Properties.Items.Count > 0)
            {
                cbeOrg.SelectedIndex = 0;
            }
            if (cbeStatus.Properties.Items.Count > 0)
            {
                cbeStatus.SelectedIndex = 0;
            }
        }



    
  
       

      

       
    }
}
