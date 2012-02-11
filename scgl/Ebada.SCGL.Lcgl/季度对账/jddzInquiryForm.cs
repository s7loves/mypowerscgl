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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string strsctzSQL = "where 1=1 ";
            string strfsctzSQL = "where 1=1 ";
            
            int i = 0;
            WaitDialogForm wdf = new WaitDialogForm("", "正在查询数据...");
            if (checkEdit1.Checked)
            {
                if (comboBoxEdit4.Text == "全部" || comboBoxEdit4.Text=="入库")
                strsctzSQL = strsctzSQL + " and (indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";
                if (comboBoxEdit4.Text == "全部" || comboBoxEdit4.Text == "出库")
                strfsctzSQL = strfsctzSQL + " and (indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";
            }
          
           
            //UCmjddzInquiry1.StrSQL = strSQL;
          
            wdf.Close();
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
                        strSQL = strSQL + " and  ID in  ( select ID from WF_TableFieldValueView where 1=1"
                         + " and WorkFlowId='" + workFlowId + "' " + str1
                         + "  and  FieldName='" + ((ListItem)cbeField.SelectedItem).ValueMember + "' and ControlValue like '%" + teField.Text + "%'"
                          + ") ";
                    }
                    else if (cbeFieldRule.Text == "不包含")
                    {
                        strSQL = strSQL + " and  ID  not in  ( select ID from WF_TableFieldValueView where 1=1"
                         + " and WorkFlowId='" + workFlowId + "' " + str1
                         + "  and   FieldName='" + ((ListItem)cbeField.SelectedItem).ValueMember + "' and ControlValue  like '%" + teField.Text + "%'"
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
          
            
        }
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            IniData();
        }

       



    
  
       

      

       
    }
}
