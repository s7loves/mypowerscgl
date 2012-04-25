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
using Ebada.Core;
using Ebada.Scgl.Core;
using Ebada.Client;
using System.Text.RegularExpressions;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class frmTaskRecordSQLList : FormBase
    {
        public frmTaskRecordSQLList()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private DataTable griddt = null;
        private string strSQL = "";
        private string strWorkFlowID = "";
        private IList excelList = null;
        private DataTable dt = null;
        public IList ExcelList
        {
            get
            {
                return excelList;
            }
            set
            {
                if (value == null) return;

                excelList = value;
            }
        }
        public string StrSQL
        {
            get
            {
                return strSQL;
            }
            set
            {
                if (value == null) return;

                strSQL = value;
            }
        }
        public string StrWorkFlowID
        {
            get
            {
                return strWorkFlowID;
            }
            set
            {
                if (value == null) return;

                strWorkFlowID = value;
                iniColumn();
                refreshData();
            }
        }
        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                
                    this.rowData = value as LP_Temple;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //strSQL = "";
            //foreach (DataRow dr in griddt.Rows)
            //{
            //    if (dr["sql"].ToString() != "")
            //    {
            //        strSQL += "[" + i + ":" + dr["sql"] + "]";
            //    }
            //    i++;
            //}
            this.DialogResult = DialogResult.OK;
        }
        private void iniColumn()
        {
            dt = new DataTable();
            dt.Columns.Clear();
            dt.Columns.Add("TaskVarId");
            dt.Columns.Add("WorkFlowId");
            dt.Columns.Add("WorkTaskId");
            dt.Columns.Add("TaskCaption");
            dt.Columns.Add("VarName");
            dt.Columns.Add("InitValue");
            dt.Columns.Add("AccessType");
            dt.Columns.Add("VarType");
            dt.Columns.Add("TableName");
            dt.Columns.Add("TableField");
            dt.Columns.Add("VarModule");
           
        }
        private void refreshData()
        {
            dt.Rows.Clear();  
            IList<WF_TaskVar> wttli = MainHelper.PlatformSqlMap.GetList<WF_TaskVar>(" where WorkFlowID='" + strWorkFlowID + "' and AccessType='生成记录' ");
            foreach (WF_TaskVar wtv in wttli)
            {
                DataRow dr = dt.NewRow();
                dr["TaskVarId"] = wtv.TaskVarId;
                dr["WorkFlowId"] = wtv.WorkFlowId;
                dr["WorkTaskId"] = wtv.WorkTaskId;
                WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOne<WF_WorkTask>(" where WorkTaskId='" + wtv.WorkTaskId + "'");
                dr["TaskCaption"] = wt.TaskCaption ;
                dr["TableName"] = wtv.TableName;
                dr["InitValue"] = wtv.InitValue;
                dr["VarName"] = wtv.VarName;
                dr["VarType"] = wtv.VarType;
                dr["TableField"] = wtv.TableField;
                dr["VarModule"] = wtv.VarModule;
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;
        
        }
        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            
           
        }
        void setComoboxFocusIndex(ComboBox cbx,string text)
        {
            int focusindex =-1, i = 0;
            foreach (ListItem it in cbx.Items)
            {

                ListItem l = it as ListItem;
                if (l.ID == text)
                {
                    focusindex = i;
                    break;
                }
                i++;
            }
            cbx.SelectedIndex = focusindex;
        }
     
    
      
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow(); 
            frmTaskRecordEditSet ftes = new frmTaskRecordEditSet();
            dr["WorkFlowId"] = strWorkFlowID;
            ftes.RowData = dr;
            ftes.strType = "add";
            if (ftes.ShowDialog() == DialogResult.OK)
            {
                WF_TaskVar wtv = new WF_TaskVar();
                wtv.WorkTaskId = dr["WorkTaskId"].ToString();
                wtv.WorkFlowId  = dr["WorkFlowId"].ToString();
                wtv.TableName = dr["TableName"].ToString() ;
                wtv.InitValue = dr["InitValue"].ToString();
                wtv.VarName = dr["VarName"].ToString();
                wtv.VarType = dr["VarType"].ToString();
                wtv.TableField = dr["TableField"].ToString();
                wtv.VarModule = dr["VarModule"].ToString();
                wtv.AccessType = "生成记录";
                MainHelper.PlatformSqlMap.Create<WF_TaskVar>(wtv); 
                refreshData();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < -1)
                return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle) as DataRow;
            frmTaskRecordEditSet ftes = new frmTaskRecordEditSet();
            ftes.RowData = dr;
            ftes.strType = "edit";

            if (ftes.ShowDialog() == DialogResult.OK)
            {
                WF_TaskVar wtv = MainHelper.PlatformSqlMap.GetOneByKey<WF_TaskVar>(dr["TaskVarId"]);
                wtv.WorkTaskId = dr["WorkTaskId"].ToString();
                wtv.WorkFlowId = dr["WorkFlowId"].ToString();
                wtv.TableName = dr["TableName"].ToString();
                wtv.InitValue = dr["InitValue"].ToString();
                wtv.VarName = dr["VarName"].ToString();
                wtv.VarType = dr["VarType"].ToString();
                wtv.TableField = dr["TableField"].ToString();
                wtv.VarModule = dr["VarModule"].ToString();
                MainHelper.PlatformSqlMap.Update<WF_TaskVar>(wtv); 
                refreshData();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < -1)
                return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle) as DataRow;
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除 【" + dr["TaskCaption"] + "】?") != DialogResult.OK)
            {
                return;
            }
            WF_TaskVar wtv = MainHelper.PlatformSqlMap.GetOneByKey<WF_TaskVar>(dr["TaskVarId"]);
            MainHelper.PlatformSqlMap.Delete<WF_TaskVar>(wtv);
            refreshData();

        }

       
       
       

       

    }
}
