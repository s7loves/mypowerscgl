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
using System.Reflection;
using System.Globalization;

namespace Ebada.SCGL.WFlow.Tool
{
   
       
   
    public partial class frmTaskRecordEditSet : FormBase
    {
        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            return (System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute).DisplayName;
        }
        public frmTaskRecordEditSet()
        {
            InitializeComponent();
        }
        private DataRow rowData = null;
        private DataTable griddt = null;
        private string strtype = "";
        private ArrayList excelList = null;
        public ArrayList ExcelList
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
        public string strType
        {
            get
            {
                return strtype;
            }
            set
            {
                if (value == null) return;

                strtype = value;
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

                this.rowData = value as DataRow;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
           
            this.DialogResult = DialogResult.OK;
        }
        private void GetTaskList(string WorkFlowId, string WorkTaskId, ref Hashtable taskht, ref DataTable dt)
        {

            WF_SubWorkFlow sbf = MainHelper.PlatformSqlMap.GetOne<WF_SubWorkFlow>
                (string.Format(" where WorkflowId='{0}' and WorkTaskId='{1}'",
               WorkFlowId, WorkTaskId));
            if (sbf != null)
            {
                IList<WF_WorkTask> wtli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList",
           "where WorkFlowId ='" + sbf.subWorkflowId + "'  order by TaskTypeId");
                for (int j = 0; j < wtli.Count; j++)
                {
                    if (wtli[j].TaskTypeId == "6")
                    {
                        GetTaskList(wtli[j].WorkFlowId, wtli[j].WorkTaskId, ref   taskht, ref dt);
                    }
                    else
                    {
                        if (!taskht.ContainsKey(wtli[j].WorkTaskId) && wtli[j].TaskTypeId != "2")
                        {

                            DataRow dr = dt.NewRow();
                            dr["name"] = wtli[j].WorkTaskId;
                            dt.Rows.Add(dr);
                            taskht.Add(wtli[j].WorkTaskId, sbf.subWorkflowCaption + "-" + wtli[j].TaskCaption);
                        }
                    }
                }
            }

        }
        public  void GetNextTask(string taskid, string workFlowId, ref Hashtable taskht,ref DataTable dt)
        {

            string tmpStr = " where  StartTaskId='" + taskid + "' and WorkFlowId='" + workFlowId + "'";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>("SelectWF_WorkTaskLinkViewList", tmpStr);
            foreach (WF_WorkTaskLinkView tl in li)
            {
                if (!taskht.ContainsKey(tl.EndTaskId) && tl.EndTaskTypeId != "2" && tl.EndTaskTypeId != "6")
                {
                    DataRow dr = dt.NewRow();
                    dr["name"] = tl.EndTaskId;
                    dt.Rows.Add(dr);
                    taskht.Add(tl.EndTaskId, tl.endTaskCaption);
                }
                if (tl.EndTaskTypeId == "6")
                {
                   
                  
                    GetTaskList(tl.WorkFlowId, tl.EndTaskId, ref taskht, ref dt);

                }
                GetNextTask(tl.EndTaskId, workFlowId, ref  taskht, ref dt);
            }

        }
        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            
            
            ListItem l = new ListItem("###", "请选择");

            int i = 0;
            Hashtable hs = new Hashtable();
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            DataRow dr = dt.NewRow();
            dr["name"] = "###";
            dt.Rows.Add(dr);
            hs.Add("###", "请选择");
            IList<WF_WorkTask> litemp = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList",
                "where WorkFlowId ='" + rowData["WorkFlowId"] + "'  and TaskTypeId='1' order by TaskTypeId");
            foreach (WF_WorkTask wt in litemp)
            {
                dr = dt.NewRow();
                dr["name"] = wt.WorkTaskId;
                dt.Rows.Add(dr);
                hs.Add(wt.WorkTaskId, wt.TaskCaption);

                GetNextTask(wt.WorkTaskId, wt.WorkFlowId, ref hs, ref dt);
            }
            string taskcaption = "";
            for (i = 0; i < dt.Rows.Count; i++)
            {
                taskcaption = hs[dt.Rows[i]["name"]] as string;
                ListItem item = new ListItem(dt.Rows[i]["name"].ToString(), taskcaption);
                cbxSWorkTastDataTable.Items.Add(item);
            }
            cbxSWorkTastDataTable.SelectedIndex = 0;
            //dt = ConvertHelper.ToDataTable(li);
            //WinFormFun.LoadComboBox(cbxSWorkTastDataTable, dt, "WorkTaskId", "TaskCaption");

            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select name as 'name' from sysobjects where xtype='U'  or xtype='V' order by xtype ,name");
            //dt = ConvertHelper.ToDataTable(li);
            dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            for ( i = 0; i < li.Count; i++)
            {
                dr = dt.NewRow();
                dr["name"] = li[i];
                dt.Rows.Add(dr);
            }
            WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, dt, "name", "name");
            

           
            if (strtype == "edit")
            {


                setComoboxFocusIndex(cbxSWorkTastDataTable, rowData["WorkTaskId"].ToString());
                setComoboxFocusIndex(cbxSWorkTastzdDataTable, rowData["VarName"].ToString());
                tetSWorkSQL.Text = rowData["InitValue"].ToString();
               
                
            }
           
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
        private void SetDataBaseSQL(DevExpress.XtraEditors.TextEdit tetSQL, ComboBox cbxDbTable, ComboBox cbxDbTableColumns)
        {
            if (cbxDbTable.SelectedIndex > 0 && cbxDbTableColumns.SelectedIndex > 0)
            {
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + ((ListItem)cbxDbTable.SelectedItem).ID + "'");
                if (list.Count > 0&&1==0)
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                }
                else
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 ";
                }
                if (ceBind.Checked)
                {
                    if (cbxDbTable.Text == "WF_TableFieldValueView")
                        tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                    else
                        if (cbxDbTable.Text == "LP_Record")
                            tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                        else
                        {


                            tetSQL.Text = "" + tetSQL.Text + " and " + list[0].ToString()
                                + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                        }

                }
            }

        }
       

      
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }

        private void cbxWorkDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
    
   
        private void GetTaskList(ref DataTable dt, string WorkFlowId, string WorkTaskId)
        {
            
                WF_SubWorkFlow sbf = MainHelper.PlatformSqlMap.GetOne<WF_SubWorkFlow>
                    (string.Format(" where WorkflowId='{0}' and WorkTaskId='{1}'",
                   WorkFlowId,  WorkTaskId));
                if (sbf != null)
                {
                    IList<WF_WorkTask> wtli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList",
               "where WorkFlowId ='" + sbf.subWorkflowId  + "'  order by TaskTypeId");
                    for (int j = 0; j < wtli.Count; j++)
                    {
                        if (wtli[j].TaskTypeId == "6")
                        {
                            GetTaskList(ref  dt, wtli[j].WorkFlowId, wtli[j].WorkTaskId);
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["TaskCaption"] = sbf.subWorkflowCaption + "-" + wtli[j].TaskCaption;
                            dr["WorkTaskId"] = wtli[j].WorkTaskId;
                            dt.Rows.Add(dr);
                        }
                    }
                }
            
        }
       

        public static object CreatNewMoldeIns(string assemblyFileName, string moduTypes, string methodName, string moduName)
        {
            object fromCtrl;
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + assemblyFileName);
            Type tp = assembly.GetType(moduTypes);
            //MethodInfo method = tp.GetMethod(methodName);

            //if (methodName == "")////窗体的构造函数不需要参数
            fromCtrl = Activator.CreateInstance(tp);
            //else//窗体的构造函数需要参数
            //    fromCtrl = Activator.CreateInstance(tp, method);
            if (fromCtrl is UserControl)
            {
                UserControl uc = fromCtrl as UserControl;
                uc.Name = moduName;

            }
            else if (fromCtrl is Form)
            {
                Form fm = fromCtrl as Form;
                fm.Name = moduName;
            }
            //if (method != null)
            //{
            //    object[] objArray = new object[0];
            //    method.Invoke(fromCtrl, objArray);
            //}
            return fromCtrl;
        }
        public static object Execute(string assemblyName, string className, string methodName, object[] paramValues, Form mdi, ref object classInstance)
        {
            int num;
            if (assemblyName == null)
            {
                assemblyName = string.Empty;
            }
            if ((className == null) || (className == string.Empty))
            {
                return null;
            }
            if (string.IsNullOrEmpty(methodName))
            {
                methodName = "Show";
            }
            if (paramValues == null)
            {
                paramValues = new object[0];
            }
            object obj2 = null;
            Type type = Assembly.GetExecutingAssembly().GetType(className);
            if (null == type)
            {
                type = ((assemblyName == string.Empty) ? Assembly.GetExecutingAssembly() : Assembly.LoadFrom(Application.StartupPath + @"\" + assemblyName)).GetType(className, true);
            }
            Type[] types = new Type[paramValues.Length];
            for (num = 0; num < paramValues.Length; num++)
            {
                types[num] = paramValues[num].GetType();
            }
            MethodInfo method = type.GetMethod(methodName, types);
            if (method == null)
            {
                return obj2;
            }
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != paramValues.Length)
            {
                return obj2;
            }
            object[] objArray = new object[paramValues.Length];
            for (num = 0; num < paramValues.Length; num++)
            {
                objArray[num] = Convert.ChangeType(paramValues[num], parameters[num].ParameterType, CultureInfo.InvariantCulture);
            }
            if (classInstance == null)
            {
                classInstance = method.IsStatic ? null : Activator.CreateInstance(type);
            }
            if ((classInstance is Form) && (mdi != null))
            {
                ((Form)classInstance).MdiParent = mdi;
            }
            else if (classInstance is UserControl)
            {
                return classInstance;
            }
            return method.Invoke(classInstance, objArray);
        }

  
       
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmTaskRecordSQLSet fees = new frmTaskRecordSQLSet();
            rowData["WorkTaskId"] = ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID;
            rowData["TaskCaption"] = ((ListItem)cbxSWorkTastDataTable.SelectedItem).Name;
            fees.RowData = rowData;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID);
            fees.StrSQL  = tetSWorkSQL.Text;
            fees.ColumnNameList = li;
            if (fees.ShowDialog() == DialogResult.OK)
            {
                tetSWorkSQL.Text = fees.StrSQL;
                rowData["InitValue"] = fees.StrSQL;
                rowData["VarName"] = ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID;
                rowData["WorkTaskId"] = ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID;
            }
        }


       

    }
}
