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
    public partial class frmTaskEditSet : FormBase
    {
        public frmTaskEditSet()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private DataTable griddt = null;
        private string strSQL = "";
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
            int i = 0;
            strSQL = "";
            foreach (DataRow dr in griddt.Rows)
            {
                if (dr["sql"].ToString() != "")
                {
                    strSQL += "[" + i + ":" + dr["sql"] + "]";
                }
                i++;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            int i = 0;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowList", " where 1=1 ");
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxSWorkFolwDataTable, dt, "WorkFlowId", "FlowCaption");

           
            ListItem l = new ListItem("###", "请选择");
            cbxSWorkTastDataTable.Items.Clear();
            cbxSWorkTastDataTable.Items.Add(l); 

            
            
             tetTWorkSQL.Text = "说明 SQL语句支持中的特殊代码\r\n 固定值中 数字+数字:{1+10}表示1到10用于序号 {sortid}:当前表单的序号为sortid的字段\r\n{recordid}:票LP_Record的ID\r\n{orgcode}:用户单位编号\r\n{userid}:用户编号\r\n{编号规则一:单位的sortid}:把26个供电所按顺序编号分别为01、02、03以此类推，001为单据编号\r\n";
            this.tetTWorkSQL.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);

            string[] comItem = SelectorHelper.ToDBC(rowData.ColumnName).Split('|');
            griddt = new DataTable();
            griddt.Columns.Add("name",typeof(string));
            griddt.Columns.Add("sql",typeof(string));
            griddt.Rows.Clear();
            i = 0;
            foreach (string strname in comItem)
            {
                DataRow dr = griddt.NewRow();
                if (strname == "") continue;
                dr["name"] = strname;
                Regex r1 = new Regex(@"(?<=\["+i+":).*?(?=\\])");
                if (r1.Match(rowData.SqlSentence.Replace("\r\n"," ")).Value!="")
                {
                    dr["sql"] = r1.Match(rowData.SqlSentence.Replace("\r\n", " ")).Value;
                }
                griddt.Rows.Add(dr);
                i++;
            }
            WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, griddt, "sql", "name");
           
            //gridView1.OptionsBehavior.Editable = true;
           
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

      
    
        private void cbxSWorkFolwDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSWorkFolwDataTable.SelectedIndex < 1) return;
            ListItem l = new ListItem("###", "请选择");
            cbxSWorkTastDataTable.Items.Clear();
            cbxSWorkTastDataTable.Items.Add(l); 
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskList",
                "where WorkFlowId ='" + ((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID + "' order by TaskTypeId");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            for (int i = 0; i < dt.Rows.Count && li.Count > 0; i++)
            {
                
                if (dt.Rows[i]["TaskTypeId"].ToString() == "6")
                {
                    WF_SubWorkFlow sbf = MainHelper.PlatformSqlMap.GetOne<WF_SubWorkFlow>
                        (string.Format (" where WorkflowId='{0}' and WorkTaskId='{1}'",
                       dt.Rows[i]["WorkFlowId"] ,dt.Rows[i]["TaskTypeId"]));
                    IList<WF_WorkTask> wtli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList",
               "where WorkFlowId ='" + dt.Rows[i]["WorkFlowId"] + "' and WorkTaskId='"
               +dt.Rows[i]["WorkTaskId"] +"' order by TaskTypeId");
                    for ( i = 0; i < wtli.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows[i]["TaskCaption"] =dt.Rows[i]["TaskCaption"]+ "-" + wtli[i].TaskCaption  ;
                    }
                }
            }
            WinFormFun.LoadComboBox(cbxSWorkTastDataTable, dt, "WorkTaskId", "TaskCaption");
            cbxSWorkTastDataTable.SelectedIndex = 0;
        }

        private void cbxSWorkTastDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSWorkTastDataTable.SelectedIndex < 1) return;
            ListItem l = new ListItem("###", "请选择");
            cbxSWorkTastzdDataTable.Items.Clear();
            cbxSWorkTastzdDataTable.Items.Add(l); 
            WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>
                        (string.Format (" where WorkflowId='{0}' and WorkTaskId='{1}'",
                       ((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID,
                       ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID));
            DataTable dt = null;
            if (wtc == null)
            {
                string varDbTableName = "";
                WF_WorkTaskModle wtm = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>
                       (string.Format(" where WorkflowId='{0}' and WorkTaskId='{1}'",
                      ((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID,
                      ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID));
                mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtm.WorktaskId);
                object fromCtrl = CreatNewMoldeIns(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, obj.ModuName);

                if (fromCtrl.GetType().GetProperty("VarDbTableName") != null && fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null) != null)
                    varDbTableName = fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null).ToString();
                IList tbli = MainHelper.PlatformSqlMap.GetList("GetTableColumns", varDbTableName);
               
                if (tbli.Count > 0)
                {
                    dt = new DataTable();
                    dt = ConvertHelper.ToDataTable(tbli);
                }
            }
            else
            {
                IList lpli = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList",
                    string.Format(" where ParentID='{0}'",
                     wtc.UserControlId));
                if (lpli.Count > 0)
                {
                    dt = new DataTable();
                    dt = ConvertHelper.ToDataTable(lpli);
                }

            }
            if (dt != null && wtc != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["CellName"] = dr["SortID"] + " " + dr["CellName"];
                }
                WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, dt, "LPID", "CellName");
                cbxSWorkTastzdDataTable.SelectedIndex = 0;
            }
            else if (dt != null && wtc == null)
            {
                WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, dt, "name", "name");
                cbxSWorkTastzdDataTable.SelectedIndex = 0;

            }
            else
            {
                cbxSWorkTastzdDataTable.SelectedIndex = 0;
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

        private void cbxSWorkTastzdDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

    }
}
