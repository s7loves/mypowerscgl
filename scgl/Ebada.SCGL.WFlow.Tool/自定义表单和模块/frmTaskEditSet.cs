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
        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            return (System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute).DisplayName;
        }
        public frmTaskEditSet()
        {
            InitializeComponent();
        }
        private WF_WorkTastTrans rowData = null;
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

                this.rowData = value as WF_WorkTastTrans;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            rowData.slcid = ((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID;
            rowData.slcmc = ((ListItem)cbxSWorkFolwDataTable.SelectedItem).Name;
            rowData.slcjdid = ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID;
            rowData.slcjdmc = ((ListItem)cbxSWorkTastDataTable.SelectedItem).Name;
            rowData.slcjdzdid = ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID;
            rowData.slcjdzdmc = ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).Name;
            rowData.sSQL = tetSWorkSQL.Text;

            if (comboBox1.SelectedItem!=null) rowData.cdfs = ((ListItem)comboBox1.SelectedItem).ID;

            rowData.tlcid = ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID;
            rowData.tlcmc = ((ListItem)cbxTWorkFolwDataTable.SelectedItem).Name;
            rowData.tlcjdid = ((ListItem)cbxTWorkTastDataTable.SelectedItem).ID;
            rowData.tlcjdmc = ((ListItem)cbxTWorkTastDataTable.SelectedItem).Name;
            if (cbxTWorkTastzdDataTable.SelectedItem != null) rowData.tlcjdzdid = ((ListItem)cbxTWorkTastzdDataTable.SelectedItem).ID;
            if (cbxTWorkTastzdDataTable.SelectedItem != null) rowData.tlcjdzdmc = ((ListItem)cbxTWorkTastzdDataTable.SelectedItem).Name;
            rowData.tSQL = tetTWorkSQL.Text;
            this.DialogResult = DialogResult.OK;
        }
        

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            cbxSWorkFolwDataTable.Items.Clear();
            cbxTWorkFolwDataTable.Items.Clear();
            comboBox1.Items.Clear();
            ListItem l = new ListItem("###", "请选择");
            cbxSWorkFolwDataTable.Items.Add(l);
            cbxTWorkFolwDataTable.Items.Add(l);
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowList", "    where 1=1 order by FlowCaption ");
            
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxTWorkFolwDataTable, dt, "WorkFlowId", "FlowCaption");

            WF_WorkFlow wf = new WF_WorkFlow();
            wf.FlowCaption = "无";
            wf.WorkFlowId = "无";
            li.Insert(0, wf);
            dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxSWorkFolwDataTable, dt, "WorkFlowId", "FlowCaption");
            
            WinFormFun.LoadComboBox(cbxTWorkFolwDataTable, dt, "WorkFlowId", "FlowCaption");
            l = new ListItem("下拉并选中", "下拉并选中");
            comboBox1.Items.Add(l);
            l = new ListItem("下拉不选中", "下拉不选中");
            comboBox1.Items.Add(l);
            l = new ListItem("赋值", "赋值");
            comboBox1.Items.Add(l);

            setComoboxFocusIndex(cbxSWorkFolwDataTable, rowData.slcid);
            setComoboxFocusIndex(cbxTWorkFolwDataTable, rowData.tlcid);
            if (strtype == "edit")
            {
                setComoboxFocusIndex(cbxSWorkFolwDataTable, rowData.slcid);
                setComoboxFocusIndex(cbxSWorkTastDataTable, rowData.slcjdid);
                setComoboxFocusIndex(cbxSWorkTastzdDataTable, rowData.slcjdzdid);
                tetSWorkSQL.Text = rowData.sSQL;
                setComoboxFocusIndex(comboBox1, rowData.cdfs);
                setComoboxFocusIndex(cbxTWorkFolwDataTable, rowData.tlcid);
                setComoboxFocusIndex(cbxTWorkTastDataTable, rowData.tlcjdid);
                setComoboxFocusIndex(cbxTWorkTastzdDataTable, rowData.tlcjdzdid);
                tetTWorkSQL.Text = rowData.tSQL;
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

      
    
        private void cbxSWorkFolwDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSWorkFolwDataTable.SelectedIndex < 1) return;
            ListItem l = new ListItem("###", "请选择");
            cbxSWorkTastDataTable.Items.Clear();
            cbxSWorkTastDataTable.Items.Add(l); 
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskList",
                "where WorkFlowId ='" + ((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID + "' and TaskTypeId!='2' order by TaskTypeId");
            DataTable dt = new DataTable();
            if (((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID == "无")
            {
                li.Clear();
                WF_WorkTask wt = new WF_WorkTask();
                wt.WorkTaskId = "无";
                wt.TaskCaption = "无";
                li.Add(wt); 
            }
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            wfhash.Clear();
            for (int i = 0; i < li.Count ; i++)
            {
                if (((WF_WorkTask)li[i]).TaskTypeId == "6")
                    GetTaskList(ref  dt, ((WF_WorkTask)li[i]).WorkFlowId, ((WF_WorkTask)li[i]).WorkTaskId);
                
            }
            WinFormFun.LoadComboBox(cbxSWorkTastDataTable, dt, "WorkTaskId", "TaskCaption");
            cbxSWorkTastDataTable.SelectedIndex = 0;
        }
        private List<string> wfhash = new List<string>();
        private void GetTaskList(ref DataTable dt, string WorkFlowId, string WorkTaskId)
        {
            if (wfhash.Contains(WorkFlowId + WorkTaskId)) return ;//判断子流程是否已处理，避免死循环,add 2012.5.15 by rabbit 
            wfhash.Add(WorkFlowId + WorkTaskId);
                WF_SubWorkFlow sbf = MainHelper.PlatformSqlMap.GetOne<WF_SubWorkFlow>
                    (string.Format(" where WorkflowId='{0}' and WorkTaskId='{1}'",
                   WorkFlowId,  WorkTaskId));
                if (sbf != null)
                {
                    IList<WF_WorkTask> wtli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList",
               "where WorkFlowId ='" + sbf.subWorkflowId + "'  and TaskTypeId!='2'  order by TaskTypeId");
                    for (int j = 0; j < wtli.Count; j++)
                    {
                        if (wtli[j].TaskTypeId == "6")
                        {
                            if (wfhash.Contains(wtli[j].WorkFlowId + wtli[j].WorkTaskId)) continue;
                            wfhash.Add(wtli[j].WorkFlowId + wtli[j].WorkTaskId);
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
                mu = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtmtemp.Modu_ID);
                WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>
                            (string.Format(" where  WorkTaskId='{0}' and ControlType='表单'",

                           ((ListItem)cbxSWorkTastDataTable.SelectedItem).ID));
                if (mu.ModuTypes.ToLower() != "ebada.scgl.lcgl.frmlp")
                {
                    string varDbTableName = "";
                    WF_WorkTaskModle wtm = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>
                           (string.Format(" where  WorkTaskId='{1}'",
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
                            rowData.slcjdzdlx = "模块";
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
                        rowData.slcjdzdlx = "表单";
                    }

                }
            }
            else
            {
                ListItem li = new ListItem("无", "无");
                cbxSWorkTastzdDataTable.Items.Add(li); 
                rowData.slcjdzdlx = "无";
            }
            if (dt != null && (mu.ModuTypes.ToLower() != "ebada.scgl.lcgl.frmlp"))
            {
                WinFormFun.LoadComboBox(cbxSWorkTastzdDataTable, dt, "WorkFlowId", "Name");
                cbxSWorkTastzdDataTable.SelectedIndex = 0;

            }
            else if (dt != null && (mu.ModuTypes.ToLower() == "ebada.scgl.lcgl.frmlp"))
            {
                rowData.slcjdzdbid = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (rowData.slcjdzdbid == "")
                    {
                        rowData.slcjdzdbid = dr["UserControlId"].ToString();
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

        private void cbxSWorkTastzdDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpleButton3.Visible = false;
            tetSWorkSQL.Text ="";
            if (cbxSWorkTastzdDataTable.SelectedIndex > 0)
            {
                if (((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID != "无")
                {
                    string[] strli = ((ListItem)cbxSWorkTastzdDataTable.SelectedItem).ID.Split(' ');
                    if (rowData.slcjdzdlx == "模块")
                    {

                        IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + strli[0] + "'");
                        if (list.Count > 0 && 1 == 0)
                        {
                            tetSWorkSQL.Text = "select " + strli[1] + " from " + strli[0] + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                        }
                        else
                        {
                            tetSWorkSQL.Text = "select " + strli[1] + " from " + strli[0] + " where 5=5 ";
                        }
                        if (ceBind.Checked)
                        {
                            if (strli[0] == "WF_TableFieldValueView")
                            {
                                if ((((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID == ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID))
                                {
                                    tetSWorkSQL.Text = "" + tetSWorkSQL.Text + " and id='{recordid}'";
                                }
                                else
                                {
                                    tetSWorkSQL.Text = tetSWorkSQL.Text + " and RecordId='{recordparentid}'";
                                }
                            }
                            else
                                if (strli[0] == "LP_Record")
                                {

                                    if ((((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID == ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID))
                                    {
                                        tetSWorkSQL.Text = "" + tetSWorkSQL.Text + " and id='{recordid}'";
                                    }
                                    else
                                    {
                                        tetSWorkSQL.Text = tetSWorkSQL.Text + " and RecordId='{recordparentid}'";
                                    }
                                }
                                else
                                {



                                    if ((((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID == ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID))
                                    {
                                        tetSWorkSQL.Text = "" + tetSWorkSQL.Text + " and " + list[0].ToString()
                                            + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                                    }
                                    else
                                    {
                                        tetSWorkSQL.Text = tetSWorkSQL.Text + " and RecordId='{recordparentid}'";
                                    }
                                }

                        }
                    }
                    else
                        if (rowData.slcjdzdlx == "表单")
                        {
                            tetSWorkSQL.Text = "select ControlValue from WF_TableFieldValue where 10=10  "
                            + "and UserControlId='" + rowData.slcjdzdbid + "' "
                            + " and FieldId='" + strli[0] + "' ";
                            if (ceBind.Checked)
                            {
                                if ((((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID == ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID))
                                {
                                    tetSWorkSQL.Text = tetSWorkSQL.Text + " and RecordId='{recordid}'";
                                }
                                else if (((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID != ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID)
                                {
                                    tetSWorkSQL.Text = tetSWorkSQL.Text + " and RecordId='{recordparentid}'";
                                }

                            }
                        }
                }
                else
                {
                    simpleButton3.Visible = true;
                }
            }
        }

        private void cbxTWorkFolwDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTWorkFolwDataTable.SelectedIndex < 1) return;
            ListItem l = new ListItem("###", "请选择");
            cbxTWorkTastDataTable.Items.Clear();
            cbxTWorkTastDataTable.Items.Add(l);
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskList",
                "where WorkFlowId ='" + ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID + "'  and TaskTypeId!='2' order by TaskTypeId");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            for (int i = 0; i < li.Count; i++)
            {

                if (((WF_WorkTask)li[i]).TaskTypeId == "6")
                {
                    GetTaskList(ref  dt, ((WF_WorkTask)li[i]).WorkFlowId, ((WF_WorkTask)li[i]).WorkTaskId);
               //     WF_SubWorkFlow sbf = MainHelper.PlatformSqlMap.GetOne<WF_SubWorkFlow>
               //         (string.Format(" where WorkflowId='{0}' and WorkTaskId='{1}'",
               //        ((WF_WorkTask)li[i]).WorkFlowId, ((WF_WorkTask)li[i]).WorkTaskId));
               //     IList<WF_WorkTask> wtli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList",
               //"where WorkFlowId ='" + ((WF_WorkTask)li[i]).WorkFlowId + "' and WorkTaskId='"
               //+ ((WF_WorkTask)li[i]).WorkTaskId + "' order by TaskTypeId");
               //     for (int j = 0; j < wtli.Count; j++)
               //     {
               //         DataRow dr = dt.NewRow();
               //         dt.Rows[j]["TaskCaption"] = dt.Rows[j]["TaskCaption"] + "-" + wtli[j].TaskCaption;
               //     }
                }
            }
            WinFormFun.LoadComboBox(cbxTWorkTastDataTable, dt, "WorkTaskId", "TaskCaption");
            cbxTWorkTastDataTable.SelectedIndex = 0;
            if (((ListItem)cbxSWorkFolwDataTable.SelectedItem).ID != ((ListItem)cbxTWorkFolwDataTable.SelectedItem).ID)
            {
                cbxSWorkTastzdDataTable_SelectedIndexChanged(sender, e);
            }
        }

        private void cbxTWorkTastDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTWorkTastDataTable.SelectedIndex < 1) return;
            ListItem l = new ListItem("###", "请选择");
            cbxTWorkTastzdDataTable.Items.Clear();
            cbxTWorkTastzdDataTable.Items.Add(l);
            WF_WorkTaskModle wtmtemp = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>
                        (string.Format(" where  WorkTaskId='{0}'",
                       ((ListItem)cbxTWorkTastDataTable.SelectedItem).ID));
            mModule mu = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtmtemp.Modu_ID);
            WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>
                        (string.Format(" where  WorkTaskId='{0}' and ControlType='表单'",
                       ((ListItem)cbxTWorkTastDataTable.SelectedItem).ID));
            DataTable dt = null;
            if (mu.ModuTypes.ToLower() != "ebada.scgl.lcgl.frmlp")
            {
                string varDbTableName = "";
                WF_WorkTaskModle wtm = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>
                       (string.Format(" where WorkTaskId='{0}'",
                      ((ListItem)cbxTWorkTastDataTable.SelectedItem).ID));
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
                        rowData.tlcjdzdlx = "模块";
                    }
                }
            }
            else
            {
                IList lpli = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList",
                    string.Format(" where WorktaskId='{0}' and UserControlId='{1}'  ",
                    wtc.WorktaskId, wtc.UserControlId));
                if (lpli.Count > 0)
                {
                    dt = new DataTable();
                    dt = ConvertHelper.ToDataTable(lpli);
                    rowData.tlcjdzdlx = "表单";
                }

            }
            if (dt != null && (mu.ModuTypes.ToLower() != "ebada.scgl.lcgl.frmlp"))
            {
                WinFormFun.LoadComboBox(cbxTWorkTastzdDataTable, dt, "WorkFlowId", "Name");
                cbxTWorkTastzdDataTable.SelectedIndex = 0;

            }
            else if (dt != null && (mu.ModuTypes.ToLower() == "ebada.scgl.lcgl.frmlp"))
            {
                rowData.tlcjdzdbid = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (rowData.tlcjdzdbid == "") rowData.tlcjdzdbid = dr["UserControlId"].ToString();
                    //dr["CellName"] = dr["SortID"] + " " + dr["CellName"];
                    break;
                }
                WinFormFun.LoadComboBox(cbxTWorkTastzdDataTable, dt, "FieldId", "FieldName");
                cbxTWorkTastzdDataTable.SelectedIndex = 0;
            }
            else
            {
                cbxTWorkTastzdDataTable.SelectedIndex = 0;
            }

        }

        private void cbxTWorkTastzdDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            tetTWorkSQL.Text = "";
            if (cbxTWorkTastzdDataTable.SelectedIndex > 0)
            {
                string[] strli = ((ListItem)cbxTWorkTastzdDataTable.SelectedItem).ID.Split(' ');
                if (rowData.tlcjdzdlx == "模块")
                {

                    IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + strli[0] + "'");
                    if (list.Count > 0 && 1 == 0)
                    {
                        tetTWorkSQL.Text = "select " + list[0] + " from " + strli[0] + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                    }
                    else
                    {
                        tetTWorkSQL.Text = "select " + list[0] + " from " + strli[0] + " where 5=5 ";
                    }
                    if (ceBind.Checked)
                    {
                        if (strli[0] == "WF_TableFieldValueView")
                            tetTWorkSQL.Text = "" + tetTWorkSQL.Text + " and id='{recordid}'";
                        else
                            if (strli[0] == "LP_Record")
                                tetTWorkSQL.Text = "" + tetTWorkSQL.Text + " and id='{recordid}'";
                            else
                            {


                                tetTWorkSQL.Text = "" + tetTWorkSQL.Text + " and " + list[0].ToString()
                                    + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                            }

                    }
                }
                else
                    if (rowData.tlcjdzdlx == "表单")
                    {
                        tetTWorkSQL.Text = "select id from WF_TableFieldValue where 10=10  "
                        + "and UserControlId='" + rowData.tlcjdzdbid + "' "
                        + " and FieldId='" + strli[0] + "' ";
                        if (ceBind.Checked)
                        {
                            tetTWorkSQL.Text = tetTWorkSQL.Text + " and RecordId='{recordid}'";
                        }
                    }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmTaskSQLSet fees = new frmTaskSQLSet();
            fees.RowData = rowData;
            fees.StrSQL = tetSWorkSQL.Text;
            if (fees.ShowDialog() == DialogResult.OK)
            {
                tetSWorkSQL.Text = fees.StrSQL;
            }
        }


       

    }
}
