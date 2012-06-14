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
    public partial class frmTaskRecordSQLSet : FormBase
    {
        public frmTaskRecordSQLSet()
        {
            InitializeComponent();
        }
        private DataRow rowData = null;
        private DataTable griddt = null;
        private string strSQL = "";
        private IList columnNameList = null;
        public IList ColumnNameList
        {
            get
            {
                return columnNameList;
            }
            set
            {
                if (value == null) return;

                columnNameList = value;
            }
        }
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
                
                    this.rowData = value as DataRow;
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
                    strSQL += "[" + dr["name"] + ":" + dr["sql"] + "]";
                }
                if (dr["modle"].ToString() != "")
                {
                    strSQL += "[" + dr["name"] + "VarModule:" + dr["modle"] + "]";
                }
                if (dr["TableField"].ToString() != "")
                {
                    strSQL += "[" + dr["name"] + "TableField:" + dr["TableField"] + "]";
                }
                i++;
            }
            this.DialogResult = DialogResult.OK;
        }
        private void GetTaskList( string WorkFlowId, string WorkTaskId,ref Hashtable taskht,ref DataTable dt)
        {
            if (wfhash2.Contains(WorkFlowId + WorkTaskId)) return;//判断子流程是否已处理，避免死循环,add 2012.5.15 by rabbit 
            wfhash2.Add(WorkFlowId + WorkTaskId);
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
                        GetTaskList( wtli[j].WorkFlowId, wtli[j].WorkTaskId, ref   taskht,ref dt);
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
       
        public  void GetPreviousTask(string taskid, string workFlowId, ref Hashtable taskht,ref DataTable dt)
        {
            if (wfhash.Contains(workFlowId + taskid)) return;//判断子流程是否已处理，避免死循环,add 2012.5.15 by rabbit 
            wfhash.Add(workFlowId + taskid);
            string tmpStr = " where  EndTaskId='" + taskid + "' and WorkFlowId='" + workFlowId + "'";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>("SelectWF_WorkTaskLinkViewList", tmpStr);
            foreach (WF_WorkTaskLinkView tl in li)
            {
                if (!taskht.ContainsKey(tl.StartTaskId) && tl.StartTaskTypeId != "2" && tl.StartTaskTypeId != "6")
                {
                    DataRow dr = dt.NewRow();
                    dr["name"] = tl.StartTaskId;
                    dt.Rows.Add(dr);
                    taskht.Add(tl.StartTaskId, tl.startTaskCaption);
                }
                if (tl.StartTaskTypeId == "6")
                {
                   
                  //)
                    GetTaskList(tl.WorkFlowId, tl.StartTaskId , ref taskht,ref dt  );

                }
                GetPreviousTask(tl.StartTaskId, workFlowId, ref  taskht,ref dt);
            }

        }
        private List<string> wfhash = new List<string>();
        private List<string> wfhash2 = new List<string>();
        private void frmExcelEditSQLSet_Load(object sender, EventArgs e) {
            int i = 0;
            Hashtable hs = new Hashtable();
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            hs.Add("###", "请选择");
            hs.Add(rowData["WorkTaskId"], rowData["TaskCaption"]);
            DataRow dr = dt.NewRow();
            dr["name"] = "###";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["name"] = rowData["WorkTaskId"].ToString();
            dt.Rows.Add(dr);
            GetPreviousTask(rowData["WorkTaskId"].ToString(), rowData["WorkFlowId"].ToString(), ref hs, ref dt);
            IList li = null;
            string taskcaption = "";
            for (i = 0; i < dt.Rows.Count; i++) {
                taskcaption = hs[dt.Rows[i]["name"]] as string;
                ListItem item = new ListItem(dt.Rows[i]["name"].ToString(), taskcaption);
                cbxSWorkTastDataTable.Items.Add(item);
            }

            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select name as 'name' from sysobjects where xtype='U'  or xtype='V' order by xtype ,name");
            //dt = ConvertHelper.ToDataTable(li);
            dt = new DataTable();
            dt.Columns.Add("name", typeof(string));

            for (i = 0; i < li.Count; i++) {
                dr = dt.NewRow();
                dr["name"] = li[i];
                dt.Rows.Add(dr);
            }
            WinFormFun.LoadComboBox(cbxWorkDbTable, dt, "name", "name");
            memoEdit1.Text = "说明 特殊代码\r\n 固定值中 数字+数字:{1+10}表示1到10用于序号 {sortid}:当前表单的序号为sortid的字段\r\n{recordid}:票LP_Record的ID\r\n{orgcode}:用户单位编号\r\n{orgname}:用户单位名称\r\n{userid}:用户编号\r\n{username}:用户姓名\r\n{编号规则一:单位的sortid}:把26个供电所按顺序编号分别为01、02、03以此类推，001为单据编号\r\n";
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);


            griddt = new DataTable();
            griddt.Columns.Add("name", typeof(string));
            griddt.Columns.Add("modle", typeof(string));
            griddt.Columns.Add("TableField", typeof(string));
            griddt.Columns.Add("sql", typeof(string));
            griddt.Rows.Clear();
            i = 0;
            foreach (WF_WorkFlow wf in columnNameList) {
                dr = griddt.NewRow();
                if (wf.Name == "") continue;
                dr["name"] = wf.Name;
                Regex r1 = new Regex(@"(?<=\[" + dr["name"] + ":).*?(?=\\])");
                if (r1.Match(rowData["InitValue"].ToString().Replace("\r\n", " ")).Value != "") {
                    dr["sql"] = r1.Match(rowData["InitValue"].ToString().Replace("\r\n", " ")).Value;
                }
                r1 = new Regex(@"(?<=\[" + dr["name"] + "VarModule:).*?(?=\\])");
                if (r1.Match(rowData["InitValue"].ToString().Replace("\r\n", " ")).Value != "") {
                    dr["modle"] = r1.Match(rowData["InitValue"].ToString().Replace("\r\n", " ")).Value;
                }
                r1 = new Regex(@"(?<=\[" + dr["name"] + "TableField:).*?(?=\\])");
                if (r1.Match(rowData["InitValue"].ToString().Replace("\r\n", " ")).Value != "") {
                    dr["TableField"] = r1.Match(rowData["InitValue"].ToString().Replace("\r\n", " ")).Value;
                }
                griddt.Rows.Add(dr);
                i++;
            }
            WinFormFun.LoadComboBox(columnBox, griddt, "sql", "name");

            gridControl1.DataSource = griddt;
            gridView1.Columns["name"].Caption = "列名";
            gridView1.Columns["name"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["sql"].Caption = "SQL语句";
            gridView1.Columns["sql"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["sql"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["sql"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gridView1.Columns["modle"].Visible = false;
            //gridView1.Columns["TableField"].Visible = false;
            //gridView1.OptionsBehavior.Editable = true;

        }
        void setComoboxFocusIndex(ComboBox cbx, string text) {
            int focusindex = -1, i = 0;
            foreach (ListItem it in cbx.Items) {

                ListItem l = it as ListItem;
                if (l.ID == text) {
                    focusindex = i;
                    break;
                }
                i++;
            }
            cbx.SelectedIndex = focusindex;
        }
        private void SetDataBaseSQL(DevExpress.XtraEditors.TextEdit tetSQL, ComboBox cbxDbTable, ComboBox cbxDbTableColumns) {
            if (cbxDbTable.SelectedIndex > 0 && cbxDbTableColumns.SelectedIndex > 0) {
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + ((ListItem)cbxDbTable.SelectedItem).ID + "'");
                if (list.Count > 0 && 1 == 0) {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                } else {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 ";
                }
                if (ceBind.Checked) {
                    if (cbxDbTable.Text == "WF_TableFieldValueView")
                        tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                    else
                        if (cbxDbTable.Text == "LP_Record")
                            tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                        else {


                            tetSQL.Text = "" + tetSQL.Text + " and " + list[0].ToString()
                                + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                        }

                }
            }

        }
        private void cbxWorkDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxWorkDbTable.SelectedIndex <1) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxWorkDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDbTableColumns, dt, "name", "name");
            cbxWorkDbTableColumns.SelectedIndex = 0;
            SetDataBaseSQL(tetWorkSQL, cbxWorkDbTable, cbxWorkDbTableColumns);
        }

        private void cbxWorkDbTableColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBaseSQL(tetWorkSQL, cbxWorkDbTable, cbxWorkDbTableColumns);
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
            string strSQLtemp = "";
            simpleButton3.Text = "修改";
            if (rbnWorkFixValue.Checked == true)
            {

                strSQLtemp = "select top 1 '" + tetWorkFixValue.Text.Replace("\r\n"," ") + "' from LP_Temple where 9=9";
            }
            else if (rbnWorkTable.Checked == true)
            {
                strSQLtemp = tetWorkSQL.Text;

            }
            else if (rbnWorkDatabase.Checked == true)
            {
                strSQLtemp = tetWorkSQL.Text;
            }

            
            int i = 0;
            foreach (DataRow dr in griddt.Rows)
            {
                if (dr["name"].ToString() == columnBox.Text)
                {
                    dr["sql"] = strSQLtemp;
                    if (rbnWorkFixValue.Checked == true)
                    {
                        dr["modle"] = "固定值";
                        
                    }
                    else if (rbnWorkTable.Checked == true)
                    {
                        dr["modle"] = "节点" + " " + ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID;
                        dr["TableField"] = "节点" + " " + ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID;

                    }
                    else if (rbnWorkDatabase.Checked == true)
                    {
                        dr["modle"] = "数据库";
                    }
                    break;
                }
                i++;
            }
            if ( columnBox.Items.Count>i+1) ((ListItem)columnBox.Items[i + 1]).ID = strSQLtemp;
        }

        private void columnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQLtemp = ((ListItem)columnBox.SelectedItem).ID;
            if (columnBox.SelectedIndex < 1) return;
            if (strSQLtemp != "")
            {
                simpleButton3.Text = "修改";
                if (strSQLtemp.IndexOf("9=9") > -1)
                {
                    rbnWorkFixValue.Checked = true;

                    tetWorkFixValue.Text = strSQLtemp.Replace("select top 1 '", "").Replace("' from LP_Temple where 9=9", "");
                }
                else if (strSQLtemp.IndexOf("10=10") > -1)
                {
                    string str = "";
                    foreach (DataRow dr in griddt.Rows)
                    {
                        if (dr["name"].ToString() == columnBox.Text)
                        {

                            setComoboxFocusIndex(cbxSWorkTastDataTable, dr["modle"].ToString().Replace("节点 ", ""));
                            setComoboxFocusIndex(cbxSWorkTastzdDataTable, dr["TableField"].ToString().Replace("节点 ", ""));
                                break;
                           
                        }
                        
                    }
                    rbnWorkTable.Checked = true;

                    
                    
                }
                else
                {
                    rbnWorkDatabase.Checked = true;
                    int index1 = strSQLtemp.ToLower().IndexOf("select");
                    int index2 = strSQLtemp.ToLower().IndexOf("from");
                    int index3 = strSQLtemp.ToLower().IndexOf("where");
                    string tablename = "";
                    if (index1 == -1 || index2 == -1 || index3 == -1) return;
                    tablename = strSQLtemp.Substring(index2 + 4, index3 - (index2 + 4)).Trim();
                    string cellpos = strSQLtemp.Substring(index1 + 6, index2 - (index1 + 6)).Trim();
                    //cbxWorkDbTable.SelectedItem = tablename;
                    //cbxWorkTableColumns.Text = cellpos;
                    setComoboxFocusIndex(cbxWorkDbTable, tablename);
                    setComoboxFocusIndex(cbxWorkDbTableColumns, cellpos);
                    tetWorkSQL.Text = strSQLtemp;
                }

            }
            else
            {
                tetWorkFixValue.Text = "";
                tetWorkSQL.Text = "";
                simpleButton3.Text = "添加";
            }
        }

        private void cbxSWorkTastDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSWorkTastDataTable.SelectedIndex < 1) return;
            ListItem l = new ListItem("###", "请选择");
            cbxSWorkTastzdDataTable.Items.Clear();
            cbxSWorkTastzdDataTable.Items.Add(l);
            DataTable dt = null;
            mModule mu = null;
            if (((ListItem)cbxSWorkTastDataTable.SelectedItem).ID != "无")
            {
                WF_WorkTaskModle wtmtemp = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>
                            (string.Format(" where  WorkTaskId='{0}'",
                           ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID));
                if (wtmtemp == null) return;
                mu = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtmtemp.Modu_ID);
                WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>
                            (string.Format(" where  WorkTaskId='{0}' and ControlType='表单'",

                           ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID));
                if (mu.ModuTypes.ToLower() != "ebada.scgl.lcgl.frmlp")
                {
                    string varDbTableName = "";
                    WF_WorkTaskModle wtm = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>
                           (string.Format(" where WorkTaskId='{0}'",
                          
                          ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID));
                    if (wtm != null)
                    {
                        mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtm.Modu_ID);
                        object fromCtrl = CreatNewMoldeIns(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, obj.ModuName);

                        if (fromCtrl.GetType().GetProperty("VarDbTableName") != null && fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null) != null)
                            varDbTableName = fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null).ToString();
                        string[] strli = varDbTableName.Split(',');
                        IList tbli = new List<WF_WorkFlow>();
                        foreach (string str in strli)
                        {
                            IList tbli2 = MainHelper.PlatformSqlMap.GetList("GetTableColumns", str);
                            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "Ebada.Scgl.Model.dll");
                            Type tpe = assembly.GetType("Ebada.Scgl.Model." + str);
                            foreach (WF_WorkFlow wf in tbli2)
                            {
                                wf.WorkFlowId = str + " " + wf.Name;
                                wf.Name = str + " " + GetDisplayName(tpe, wf.Name);
                                tbli.Add(wf);
                            }
                        }
                        if (tbli.Count > 0)
                        {
                            dt = new DataTable();
                            dt = ConvertHelper.ToDataTable(tbli);
                            rowData["VarType"] = "模块";
                        }
                    }
                }
                else if (wtc != null)
                {
                    IList lpli = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList",
                        string.Format(" where WorktaskId='{0}' and UserControlId='{1}'  ",
                        wtc.WorktaskId, wtc.UserControlId));
                    if (lpli.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ConvertHelper.ToDataTable(lpli);
                        rowData["VarType"] = "表单";
                    }

                }
            }
            else
            {
                ListItem li = new ListItem("无", "无");
                cbxSWorkTastzdDataTable.Items.Add(li);
                rowData["VarType"] = "无";
            }
            if (dt != null && (mu.ModuTypes.ToLower() != "ebada.scgl.lcgl.frmlp"))
            {
                WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, dt, "WorkFlowId", "Name");
                cbxSWorkTastzdDataTable.SelectedIndex = 0;

            }
            else if (dt != null && (mu.ModuTypes.ToLower() == "ebada.scgl.lcgl.frmlp"))
            {
                rowData["TableName"] = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (rowData["TableName"].ToString() == "")
                    {
                        rowData["TableName"] = dr["UserControlId"].ToString();
                        break;
                    }
                    //dr["CellName"] = dr["SortID"] + " " + dr["CellName"];
                }
                WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, dt, "FieldId", "FieldName");
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

        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            return (System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute).DisplayName;
        }

        private void cbxSWorkTastzdDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            tetWorkSQL.Text = "";
            if (cbxSWorkTastzdDataTable.SelectedIndex > 0)
            {


                string[] strli = ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID.Split(' ');
                
                    if (rowData["VarType"].ToString() == "模块")
                    {
                        IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + strli[0] + "'");
                        if (list.Count > 0 && 1 == 0)
                        {
                            tetWorkSQL.Text = "select " + strli[1] + " from " + strli[0] + " where 10=10 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                        }
                        else
                        {
                            tetWorkSQL.Text = "select " + strli[1] + " from " + strli[0] + " where 10=10 ";
                        }
                        if (ceBind.Checked)
                        {
                            if (strli[0] == "WF_TableFieldValueView")
                            {
                              
                                    tetWorkSQL.Text = "" + tetWorkSQL.Text + " and id='{recordid}'";
                                
                            }
                            else
                                if (strli[0] == "LP_Record")
                                {


                                    tetWorkSQL.Text = "" + tetWorkSQL.Text + " and id='{recordid}'";
                                    
                                }
                                else
                                {




                                    tetWorkSQL.Text = "" + tetWorkSQL.Text + " and " + list[0].ToString()
                                            + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                                    
                                }

                        }
                    }
                    else
                        if (rowData["VarType"].ToString()== "表单")
                        {
                            tetWorkSQL.Text = "select ControlValue from WF_TableFieldValue where 10=10  "
                            + "and UserControlId='" + rowData["TableName"] + "' "
                            + " and FieldId='" + strli[0] + "' ";
                            if (ceBind.Checked)
                            {
                                    tetWorkSQL.Text = tetWorkSQL.Text + " and RecordId='{recordid}'";
                               

                            }
                        }
               
            }
        }

      

    }
}
