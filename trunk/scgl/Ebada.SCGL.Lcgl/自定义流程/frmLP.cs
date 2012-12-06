﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Reflection;
using System.Collections;
using Ebada.Client;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using System.IO;
using Ebada.Core;
using DevExpress.XtraRichEdit.API.Word;
using Ebada.Scgl.WFlow;
using DevExpress.XtraGrid.Views.Base;
using System.Text.RegularExpressions;
using DevExpress.XtraTreeList;
using System.Net;
using System.Threading;
using Ebada.Scgl.Core;
using Ebada.SCGL.WFlow.Tool;
using System.IO;
using Ebada.UI.Base;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmLP : Form, IPopupFormEdit
    {
        #region 字段

        const int wordWidth = 13;
        public string strxiestatus = "";
        private LP_Temple parentTemple = null;
        private IList<LP_Temple> templeList;
        private IList<Control> tempCtrlList = null;
        private LP_Record currRecord = null;
        private string kind, status;
        private string plitchar = "|";
        private char pchar = '|';
        private char pcomboxchar = '，';
        private string strNumber = "";
        private Control ctrlNumber = null;
        private Control ctrlNumber2 = null;
        private string activeSheetName = "";
        private int activeSheetIndex = 1;
        private DownFileControl filecontrol = null;
        private SPYJControl hqyjcontrol = null;
        private Hashtable valuehs = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private bool isWorkflowCall = false;
        private string varDbTableName = "LP_Record";
        public bool IsWorkflowCall
        {
            set
            {
                isWorkflowCall = value;
            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public string Status//add,edit,etc....
        {
            get { return status; }
            set { status = value; }
        }

        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
            }
        }

        #endregion
        #region IPopupFormEdit Members
        private LP_Record rowData = null;
        Excel.Workbook wb;
        Excel.Worksheet sheet;
        public object RowData
        {
            get
            {
                rowData = currRecord;
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as LP_Record;
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<LP_Record>(value as LP_Record, rowData);
                }
            }
        }

        #endregion
        public frmLP()
        {
            InitializeComponent();
        }
        void dataBind()
        {

        }
        Hashtable bhht = new Hashtable();
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

        /// <summary>
        ///设置保护工作表
        /// </summary>
        private void LockExcel(Excel.Workbook wb, Excel.Worksheet xx)
        {
            return;
            xx.Protect("MyPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing);
            xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
            //wb.SheetBeforeDoubleClick += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            //wb.SheetDeactivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetDeactivateEventHandler(Workbook_SheetDeactivate);
            //wb.SheetActivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetActivateEventHandler(Workbook_SheetActivate);
            try
            {
                wb.SheetSelectionChange += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetSelectionChangeEventHandler(Workbook_SheetSelectionChange);
            }
            catch { }
        }
        protected void Workbook_SheetSelectionChange(object Sh, Excel.Range Target)
        {
            //Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            //Excel.Worksheet sheet = wb.ActiveSheet as Excel.Worksheet;
            //activeSheetName = sheet.Name;
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;

            Excel.Worksheet sheet = wb.Application.Sheets[activeSheetIndex] as Excel.Worksheet;
            if (activeSheetName != sheet.Name)
            {
                sheet.Name = activeSheetName;
            }
            if (activeSheetName != "简图")
                LockExcel(wb, sheet);
        }
        protected void Workbook_SheetActivate(object Sh)
        {
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            Excel.Worksheet sheet;
            sheet = wb.ActiveSheet as Excel.Worksheet;
            sheet.SelectionChange += new Microsoft.Office.Interop.Excel.DocEvents_SelectionChangeEventHandler(sheet_SelectionChange);

            if (activeSheetName != sheet.Name)
            {
                sheet.Name = activeSheetName;
            }
            if (wb.Application.Sheets[activeSheetIndex] != wb.Application.Sheets[activeSheetName])
            {
                sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
                sheet.Move(Type.Missing, wb.Application.Sheets[activeSheetIndex]);
            }

            try
            {
                ea.ActiveSheet(activeSheetName);
            }
            catch { }

        }
        Dictionary<string, openflie> linkdic = new Dictionary<string, openflie>();

        class openflie
        {
            public openflie(int type, string path)
            {
                Type = type;
                Path = path;
            }
            public int Type;
            public string Path;
        }
        private void loadbasedata()
        {
            linkdic.Clear();

            openflie f1 = new openflie(2, "20110510173256448250");
            linkdic.Add("配电设备完好率汇总表", f1);




            //26种簿册
            openflie f01 = new openflie(2, "20110510172600588875");
            linkdic.Add("工作日志", f01);
            openflie f02 = new openflie(2, "20110510172218010750");
            linkdic.Add("安全活动记录", f02);
            openflie f03 = new openflie(2, "20110727093630264875");
            linkdic.Add("运行分析记录", f03);

            openflie f04 = new openflie(2, "20110510172241276375");
            linkdic.Add("事故、障碍、异常运行记录", f04);
            openflie f05 = new openflie(2, "20110510172241729500");
            linkdic.Add("交叉跨越及对地距离测量记录", f05);
            openflie f06 = new openflie(2, "20110510172242073250");
            linkdic.Add("设备巡视及缺陷消除记录", f06);
            openflie f07 = new openflie(2, "20110510172242745125");
            linkdic.Add("接地装置检测记录", f07);
            openflie f08 = new openflie(2, "20110510172242417000");
            linkdic.Add("设备停电检修记录", f08);
            openflie f09 = new openflie(2, "20110510172243057625");
            linkdic.Add("培训记录", f09);
            openflie f010 = new openflie(2, "20110510172023792000");
            linkdic.Add("配电变压器汇总表", f010);

            openflie f011 = new openflie(2, "20110510173027854500");
            linkdic.Add("配电变压器卡片", f011);
            openflie f012 = new openflie(2, "20110510172955135750");
            linkdic.Add("线路开关卡片", f012);
            openflie f013 = new openflie(2, "20110510172243870125");
            linkdic.Add("剩余电流动作保护器测试记录", f013);
            openflie f014 = new openflie(2, "20110510172559526375");
            linkdic.Add("电力工器具测试记录", f014);
            openflie f015 = new openflie(2, "20110510173019088875");
            linkdic.Add("工具、仪表台张", f015);
            openflie f016 = new openflie(2, "20110510173028401375");
            linkdic.Add("高压配电线路条图", f016);
            openflie f017 = new openflie(2, "20110510173028135750");
            linkdic.Add("高压配电线路条图汇总表", f017);
            openflie f018 = new openflie(2, "20110510173200917000");
            linkdic.Add("高压配电设备评级表", f018);
            openflie f019 = new openflie(2, "20110510173256448250");
            linkdic.Add("高压配电设备完好率汇总表", f019);
            openflie f020 = new openflie(2, "20110510173027557625");
            linkdic.Add("低压线路完好率及台区网络图", f020);



            openflie f021 = new openflie(2, "20110510172559932625");
            linkdic.Add("电力故障报修电话接听记录", f021);
            openflie f022 = new openflie(2, "20120319141849123000");
            linkdic.Add("报修服务修理票", f022);
            openflie f023 = new openflie(2, "20110510173404948250");
            linkdic.Add("配电设备产权产权及维护范围协议书", f023);
            openflie f024 = new openflie(2, "20110510173324542000");
            linkdic.Add("设备变更通知书", f024);
            openflie f025 = new openflie(2, "20110510173331370125");
            linkdic.Add("双电源协议书", f025);
            openflie f026 = new openflie(2, "20110510173332292000");
            linkdic.Add("电力线路防护通知书", f026);

        }
        void sheet_SelectionChange(Microsoft.Office.Interop.Excel.Range Target)
        {
            if ((bool)Target.MergeCells)
            {
                Microsoft.Office.Interop.Excel.Range temp = (Microsoft.Office.Interop.Excel.Range)Target.Cells[1, 1];
                string str = temp.Text.ToString();
                OpenFile(str.Trim());
            }
            else
            {
                string str = Target.Text.ToString();
                OpenFile(str.Trim());
            }


        }
        private string GetFileName(string file)
        {
            string result = System.Windows.Forms.Application.StartupPath + "\\文档资料\\" + file;
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;

        }

        void OpenFile(string keystr)
        {
            //lgm20121103
            if (linkdic.ContainsKey(keystr)) {
                
                openflie f1 = linkdic[keystr];

                if (keystr == "低压线路完好率及台区网络图") {
                    MsgBox.ShowWarningMessageBox(keystr+ " 不能在此处打开，请从26种记录薄中进入！" );
                }else if(keystr=="电力线路防护通知书"){
                    MsgBox.ShowWarningMessageBox(keystr + " 不能在此处打开，请从26种记录薄中进入！");
                } else {
                    if (f1.Type == 2) {
                        //打开24个工作簿
                        try {
                            mModule mdtemp = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(f1.Path);
                            OpenModule(mdtemp);
                        } catch (Exception) {


                        }

                    } else {
                        //打开文件夹
                        System.Diagnostics.Process.Start(GetFileName(f1.Path));

                    }
                }
            }
        }
        public void OpenModule(mModule obj)
        {

            object instance = null;//模块接口
            //this.WindowState = FormWindowState.Minimized;
            try {
                object result = null;
                if (obj.MethodParam == null || string.IsNullOrEmpty(obj.MethodName))
                    result = MainHelper.Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, null, this, ref instance);
                else {
                    result = MainHelper.Execute(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, obj.MethodParam.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                }
                if (result is UserControl) {
                    instance = showControl(result as UserControl, obj.Modu_ID, obj.ModuName);
                }
                if (instance is Form) {
                    Form fb = instance as Form;
                    fb.Visible = false;
                    fb.Text = obj.ModuName;
                    fb.Size = new Size(800, 600);
                    fb.StartPosition = FormStartPosition.CenterScreen;
                    fb.ShowDialog();
                }
                this.Cursor = Cursors.Default;

            } catch (Exception err) {
                this.Cursor = Cursors.Default;
                MsgBox.ShowException(err);
            } finally {
                //this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// 显示用户控件方法
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private FormBase showControl(UserControl uc, string moduID, string text)
        {
            FormBase dlg = new FormBase();
            dlg.Text = text;
            dlg.Size = new Size(800, 600);
            dlg.StartPosition = FormStartPosition.CenterScreen;
            if (!string.IsNullOrEmpty(moduID))
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("Modu_ID", moduID);
                dlg.Tag = dic;
            }
            dlg.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            //dlg.ShowDialog();
            return dlg;
        }
        protected void Workbook_SheetDeactivate(object Sh)
        {
            Workbook_SheetActivate(Sh);
        }
        protected void wb_SheetBeforeDoubleClick(object Sh, Microsoft.Office.Interop.Excel.Range Target, ref bool Cancel)
        {
            if ((bool)(Target.Locked))
            {
                Cancel = true;
            }
        }

        /// <summary>
        /// 去保护工作表
        /// </summary>
        private void unLockExcel(Excel.Workbook wb, Excel.Worksheet xx)
        {
            try
            {
                //return;
                xx.Unprotect("MyPassword");
                xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
                wb.SheetSelectionChange -= new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetSelectionChangeEventHandler(Workbook_SheetSelectionChange);
                //wb.SheetBeforeDoubleClick -= new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            }
            catch { }
        }
        private void LPFrm_Load(object sender, EventArgs e)
        {
            loadbasedata();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            if (tempCtrlList == null)
            {
                tempCtrlList = new List<Control>();
            }
            //InitializeComponent();
            if (valuehs == null)
                valuehs = new Hashtable();
            InitIndex();
            if (kind == null) return;
            if (GetWorkFlowNmae(kind).IndexOf("电力线路") > -1)
            {
                bhht.Clear();
                bhht.Add("宝山供电所", "01");
                bhht.Add("长发供电所", "02");
                bhht.Add("绥胜供电所", "03");
                bhht.Add("红旗供电所", "04");
                bhht.Add("永安供电所", "05");
                bhht.Add("连岗供电所", "06");
                bhht.Add("太平供电所", "07");
                bhht.Add("新华供电所", "08");
                bhht.Add("北郊供电所", "09");

                bhht.Add("东郊供电所", "10");
                bhht.Add("东富供电所", "11");
                bhht.Add("兴福供电所", "12");
                bhht.Add("利民供电所", "13");
                bhht.Add("东津供电所", "14");
                bhht.Add("津河供电所", "15");
                bhht.Add("龙太供电所", "16");
                bhht.Add("秦家供电所", "17");
                bhht.Add("双河供电所", "18");
                bhht.Add("五营供电所", "19");
                bhht.Add("三河供电所", "20");

                bhht.Add("四方台供电所", "21");
                bhht.Add("张维供电所", "22");
                bhht.Add("民吉供电所", "23");
                bhht.Add("三井供电所", "24");
                bhht.Add("联合供电所", "25");
                bhht.Add("新生供电所", "26");
                bhht.Add("张维变电所", "27");

                bhht.Add("秦家变电所", "28");
                bhht.Add("四方台变电所", "29");
                bhht.Add("三河变电所", "30");
                bhht.Add("长发变电所", "31");
                bhht.Add("五营变电所", "32");
                bhht.Add("新华变电所", "33");
                bhht.Add("太平变电所", "34");

                bhht.Add("红旗变电所", "35");
                bhht.Add("连岗变电所", "36");
                bhht.Add("津河变电所", "37");
                bhht.Add("送变电工区", "38");


            }
            //InitContorl();
            WF_TableFieldValue wfv = null;
            ExcelAccess ea = new ExcelAccess();
            LP_Temple lp = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + parentTemple.LPID + "' and SortID=1");
            if (lp != null)
            {
                if (wfv == null)
                {
                    wfv = new WF_TableFieldValue();
                    wfv.ID = wfv.CreateID();
                    wfv.RecordId = currRecord.ID;
                    wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    wfv.UserControlId = parentTemple.LPID;
                    wfv.ControlValue = "";
                    wfv.FieldId = lp.LPID;
                    wfv.FieldName = lp.CellName;
                    wfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    wfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                }
                wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                                 + " and   WorkflowId='" + wfv.WorkFlowId + "'"
                                 + " and   RecordId='" + wfv.RecordId + "'"
                                 + " and   UserControlId='" + wfv.UserControlId + "'"
                                 + " and   WorkFlowInsId='" + wfv.WorkFlowInsId + "'"
                                 + " and   fieldname='" + lp.CellName + "'"
                                 + " and   FieldId='" + lp.LPID + "' and Bigdata is not null"
                                );

            }
            if (status == "add" && parentTemple.DocContent != null && parentTemple.DocContent.Length > 0)
            {
                if (wfv != null && wfv.Bigdata != null && wfv.Bigdata.Length > 0)
                {
                    this.dsoFramerWordControl1.FileDataGzip = wfv.Bigdata;
                }
                else
                    if (GetWorkFlowNmae(kind).IndexOf("电力线路") > -1 && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
                        this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
                    else
                        this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
                InitContorl();
            }
            else if (status == "edit")
            {
                if (currRecord.DocContent == null)
                {
                    currRecord.DocContent = new byte[0];
                }
                if (currRecord.ID.IndexOf("N") == -1)
                {
                    this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
                }
                else
                {
                    if (wfv != null && wfv.Bigdata != null && wfv.Bigdata.Length > 0)
                    {
                        this.dsoFramerWordControl1.FileDataGzip = wfv.Bigdata;
                    }
                    else
                        if (GetWorkFlowNmae(kind).IndexOf("电力线路") > -1 && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
                            this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
                        else
                            this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
                }
                InitContorl();

                //LoadContent();
            }

            if ((parentTemple != null && parentTemple.DocContent != null) || (currRecord != null && currRecord.DocContent != null && currRecord.DocContent.Length > 0))
            {
                wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;

                //sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;

                //activeSheetIndex = sheet.Index;
                try
                {
                    for (int i = 1; i <= wb.Application.Sheets.Count; i++)
                    {

                        sheet = wb.Application.Sheets[i] as Excel.Worksheet;
                        Workbook_SheetDeactivate(sheet);
                        //保护工作表
                        LockExcel(wb, sheet);
                        //if (i != activeSheetIndex)
                        //{
                        //    Excel.Worksheet tmpSheet = (Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                        //    try
                        //    {
                        //        if (tmpSheet != null) tmpSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;

                        //    }
                        //    catch { }

                    }

                }
                catch { }
            }
            IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                    " where RecordId='" + currRecord.ID + "' and UserControlId='" + parentTemple.LPID + "' and   WorkflowId='" + WorkFlowData.Rows[0]["WorkflowId"] + "' and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"] + "' order by YExcelPos,XExcelPos");

            Excel.Worksheet xx;
            wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            string activeSheetName = "";
            try
            {
                xx = wb.Application.Sheets[1] as Excel.Worksheet;
            }
            catch { }

            for (int i = 0; i < tfvli.Count; i++)
            {

                Control ctl = FindCtrl(tfvli[i].FieldId);
                if (ctl != null)
                {
                    lp = ctl.Tag as LP_Temple;
                    if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit") == false)
                    {
                        if (lp.CellName != "编号")
                        {
                            if (ctl.Text.IndexOf(tfvli[i].ControlValue) == -1)
                                ctl.Text += tfvli[i].ControlValue;
                        }
                        else
                        {
                            ctl.Text = tfvli[i].ControlValue;
                        }
                        ctl.Focus();
                    }
                    else
                    {

                        IList<WF_TableFieldValue> tfvlitemp = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                    " where RecordId='" + currRecord.ID + "' and UserControlId='" + parentTemple.LPID + "' and   WorkflowId='" + WorkFlowData.Rows[0]["WorkflowId"] + "' and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"] + "'  and FieldId='" + tfvli[i].FieldId.ToString() + "' and FieldName='" + tfvli[i].FieldName + "完整时间' order by id desc, YExcelPos,XExcelPos");
                        if (tfvlitemp.Count > 0)
                        {
                            ((DevExpress.XtraEditors.DateEdit)ctl).DateTime = Convert.ToDateTime(tfvlitemp[0].ControlValue);
                        }
                        //((DevExpress.XtraEditors.DateEdit)ctl).DateTime = Convert.ToDateTime(tfvli[i].ControlValue);
                    }
                }
            }
            dsoFramerWordControl1.FileSave();
            //保护工作表
            //    LockExcel(wb,sheet);
            //}
        }

        protected override void OnShown(EventArgs e)
        {
            //InitializeComponent();
            base.OnShown(e);

            //InitIndex();

            //if (parentTemple != null)
            //    InitContorl();
            ////currRecord = rowData;
            //if (status == "add" && parentTemple.DocContent != null && parentTemple.DocContent.Length > 0)
            //{              
            //    this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;                
            //}
            //else if (status == "edit" && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
            //{
            //    this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
            //    LoadContent();
            //}

            // this.dsoFramerWordControl1.FileDataGzip = this.rowData.DocContent;
        }
        public void InitIndex()
        {
            if (parentTemple != null) templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where LPID in ( select FieldId from WF_TableUsedField where UserControlId ='" + parentTemple.LPID + "' and WorkflowId='" + WorkFlowData.Rows[0]["WorkflowId"] + "'and WorkTaskid='" + WorkFlowData.Rows[0]["WorkTaskid"] + "' ) Order by SortID");
            //else
            //{
            //    LP_Temple temple = new LP_Temple();
            //   templeList =(List<LP_Temple>)temple ;
            //}
            //IList<LP_Temple> parentlist = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID='0' and Kind='" + kind + "'");
            //if (parentlist.Count > 0)
            //    parentTemple = parentlist[0];
            // dsoFramerWordControl1.
        }
        public static string GetWorkFlowNmae(string kind)
        {
            string strkind = kind;
            if (kind == "dzczp")
                strkind = "电力线路倒闸操作票";
            else if (kind == "yzgzp")
                strkind = "电力线路第一种工作票";
            else if (kind == "ezgzp")
                strkind = "电力线路第二种工作票";
            else if (kind == "xlqxp")
                strkind = "电力线路事故应急抢修单";
            return strkind;
        }
        public void InitContorl()
        {
            int MaxWordWidth = CalcWidth();
            int currentPosY = 10;
            int currentPosX = 10;
            int index = 0;
            if (MaxWordWidth < 300) MaxWordWidth = 300;
            try
            {
                if (parentTemple != null)
                {
                    foreach (LP_Temple lp in templeList)
                    {
                        bool flag;//= (lp.Status == CurrRecord.Status);
                        flag = lp.IsVisible == 0;
                        Label label = new Label();
                        ComboBoxEdit btTip = null;
                        CheckEdit ceTip = null;
                        label.Text = lp.CellName;
                        //string[] location = lp.CtrlLocation.Split(',');
                        string[] size = lp.CtrlSize.Split(',');
                        label.Location = new Point(currentPosX, currentPosY);
                        label.Size = new Size(MaxWordWidth, 14);
                        label.Visible = flag;
                        if (flag)
                        {
                            currentPosY += 20;
                        }
                        IList<WF_WorkTastTrans> wttli = MainHelper.PlatformSqlMap.GetList<WF_WorkTastTrans>(" where tlcjdid='" +
                            WorkFlowData.Rows[0]["WorkTaskId"].ToString()
                            + "' and cdfs like '下拉%' and tlcjdzdid='" + lp.LPID + "'");
                        if (lp.CtrlType.Contains("MemoEdit") && flag && (lp.SqlSentence != "" || wttli.Count > 0))
                        {
                            btTip = new ComboBoxEdit();
                            btTip.Name = "bt" + lp.LPID;
                            btTip.Location = new Point(currentPosX, currentPosY);
                            btTip.Size = new Size(300, 14);
                            btTip.Tag = lp;

                            ceTip = new CheckEdit();
                            ceTip.Name = "ce" + lp.LPID;
                            ceTip.Location = new Point(currentPosX + btTip.Width + 10, currentPosY);
                            ceTip.Size = new Size(80, 14);
                            ceTip.Text = "累加";
                            ceTip.Checked = false;
                            currentPosY += 30;
                        }
                        else
                            if (lp.CtrlType.Contains("TextEdit") && flag && (lp.SqlSentence != "" || wttli.Count > 0))
                            {
                                btTip = new ComboBoxEdit();
                                btTip.Name = "bt" + lp.LPID;
                                btTip.Location = new Point(currentPosX, currentPosY);
                                btTip.Size = new Size(300, 14);
                                btTip.Tag = lp;

                                ceTip = new CheckEdit();
                                ceTip.Name = "ce" + lp.LPID;
                                ceTip.Location = new Point(currentPosX + btTip.Width + 10, currentPosY);
                                ceTip.Size = new Size(80, 14);
                                ceTip.Text = "累加";
                                ceTip.Checked = false;
                                currentPosY += 30;
                            }

                        Control ctrl;

                        if (lp.CtrlType.Contains("uc_gridcontrol"))
                        {
                            ctrl = new uc_gridcontrol();
                            ((uc_gridcontrol)ctrl).CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
                            ((uc_gridcontrol)ctrl).FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(gridView1_FocusedColumnChanged);
                        }
                        else
                            ctrl = (Control)Activator.CreateInstance(Type.GetType(lp.CtrlType));
                        ctrl.Location = new Point(currentPosX, currentPosY);
                        ctrl.Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                        if (flag)
                        {
                            currentPosY += int.Parse(size[1]) + 10;
                        }
                        ctrl.Enter += new EventHandler(ctrl_Enter);
                        ctrl.Leave += new EventHandler(ctrl_Leave);
                        ctrl.TextChanged += new EventHandler(ctrl_Leave);
                        ctrl.Visible = flag;
                        ctrl.Tag = lp;
                        ctrl.TabIndex = index;
                        if (btTip != null)
                        {
                            btTip.TabIndex = index;
                            index++;
                            btTip.TextChanged += new EventHandler(btTip_Click);
                        }
                        if (lp.CtrlType.Contains("uc_gridcontrol"))
                        {
                            label.Text = lp.CellName + "(Tab键可选下一格)";
                            (ctrl as uc_gridcontrol).InitCol(lp.ColumnName.Split(pchar), lp);
                            //if (RecordWorkTask.HaveRunPowerRole(WorkConst.WorkTask_BindTable, WorkFlowData.Rows[0]["WorkFlowId"].ToString(), WorkFlowData.Rows[0]["WorkTaskId"].ToString()) || currRecord.Status == "填票")
                            {
                                (ctrl as uc_gridcontrol).iniTableRecordData(currRecord.ID, lp, WorkFlowData.Rows[0]["WorkFlowId"].ToString(), WorkFlowData.Rows[0]["WorkFlowInsId"].ToString());
                            }
                        }

                        index++;
                        ctrl.Name = lp.LPID;
                        dockPanel1.Controls.Add(label);
                        if (btTip != null)
                        {
                            dockPanel1.Controls.Add(btTip);
                            dockPanel1.Controls.Add(ceTip);
                        }
                        dockPanel1.Controls.Add(ctrl);
                        if (lp.CellName == "编号")
                        {
                            ctrlNumber = ctrl;
                        }
                        if (lp.CellName.Contains("编号2"))
                        {
                            ctrlNumber2 = ctrl;
                        }
                        if (lp.CtrlType.IndexOf("DateEdit") > -1)
                        {

                            if (lp.WordCount.ToLower().IndexOf("hh") > -1)
                            {
                                ((DateEdit)ctrl).Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                                ((DateEdit)ctrl).Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                            }
                        }
                        if (lp.CtrlType.Contains("SpinEdit") && lp.WordCount != "")
                        {
                            SpinEdit lue1 = (SpinEdit)ctrl;
                            if (lp.WordCount.IndexOf("p") > -1)
                            {
                                lue1.Properties.Increment = (decimal)0.0001;
                                lue1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            }
                            else
                                if (lp.WordCount.IndexOf(".") > -1)
                                {
                                    Regex r2 = new Regex(@"(?<=\.).*");
                                    lue1.Properties.Increment = (decimal)Math.Pow(0.1, r2.Match(lp.WordCount).Value.Length / 2);
                                    lue1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                                }
                            lue1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            lue1.Properties.EditFormat.FormatString = lp.WordCount;
                            lue1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            lue1.Properties.DisplayFormat.FormatString = lp.WordCount;
                            lue1.Properties.EditMask = lp.WordCount;

                        }
                    }
                }
                InitEvent();
                InitData();
                InitTaskData();
            }
            catch { }
            try
            {
                if (RecordWorkTask.HaveRunSPYJRole(kind))
                {
                    if (hqyjcontrol == null) hqyjcontrol = new SPYJControl();
                    hqyjcontrol.Size = new System.Drawing.Size(400, 200);
                    hqyjcontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
                    currentPosY = currentPosY + hqyjcontrol.Size.Height;
                    hqyjcontrol.RecordID = CurrRecord.ID;
                    hqyjcontrol.TabIndex = index;
                    index++;
                    dockPanel1.Controls.Add(hqyjcontrol);
                }

                if (RecordWorkTask.HaveRunFuJianRole(kind))
                {

                    if (filecontrol == null) filecontrol = new DownFileControl();
                    if (status == "add")
                        filecontrol.FormType = "上传";
                    else if (status == "edit")
                    {
                        filecontrol.FormType = "下载";
                    }
                    filecontrol.Size = new System.Drawing.Size(400, 200);
                    filecontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
                    currentPosY = currentPosY + filecontrol.Size.Height;
                    filecontrol.UpfilePath = GetWorkFlowNmae(kind);
                    filecontrol.TaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    if (currRecord == null)
                    {
                        currRecord = new LP_Record();
                    }
                    filecontrol.RecordID = CurrRecord.ID;
                    filecontrol.TabIndex = index;
                    index++;
                    dockPanel1.Controls.Add(filecontrol);
                    currentPosY += 20;
                }
                if (RecordWorkTask.HaveWorkFlowBackRole(WorkFlowData.Rows[0]["WorkTaskId"].ToString(), WorkFlowData.Rows[0]["WorkFlowId"].ToString()))
                {
                    Button btn_Back = new Button();
                    dockPanel1.Controls.Add(btn_Back);
                    btn_Back.Click += new EventHandler(btn_Back_Click);
                    btn_Back.Location = new Point(currentPosX + 80, currentPosY + 10);
                    btn_Back.Text = "退回";

                    btn_Back = new Button();
                    dockPanel1.Controls.Add(btn_Back);
                    btn_Back.Click += new EventHandler(btn_Save_Click);
                    btn_Back.Location = new Point(currentPosX + 80 + btn_Back.Width, currentPosY + 10);
                    btn_Back.Text = "保存";
                }
                else
                {
                    Button btn_Back = new Button();
                    dockPanel1.Controls.Add(btn_Back);
                    btn_Back.Click += new EventHandler(btn_Save_Click);
                    btn_Back.Location = new Point(currentPosX + 80, currentPosY + 10);
                    btn_Back.Text = "保存";

                }
            }
            catch { }
            Button btn_Submit = new Button();
            dockPanel1.Controls.Add(btn_Submit);
            btn_Submit.Location = new Point(currentPosX, currentPosY + 10);
            btn_Submit.Text = "提交";
            btn_Submit.Click += new EventHandler(btn_Submit_Click);
            if (dockPanel1.ControlContainer.Controls.Count > 0)
                dockPanel1.ControlContainer.Controls[0].Focus();
        }
        void btTip_Click(object sender, EventArgs e)
        {
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            Control ct = FindCtrl(lp.LPID);
            Control ce = FindCtrl("ce" + lp.LPID);
            if (ct != null && ct.Text.IndexOf(str) == -1)
            {
                if (lp.CellName.Replace(" ", "").Substring(lp.CellName.Replace(" ", "").Length - 1) == "人"
                    || lp.CellName.Replace(" ", "").IndexOf("人员") > -1
                    || lp.CellName.Replace(" ", "").IndexOf("成员") > -1)
                {
                    if (ct.Text == "" || !((CheckEdit)ce).Checked)
                        ct.Text = str;
                    else
                        ct.Text += "、" + str;
                }
                else
                {
                    if (lp.CtrlType.Contains("MemoEdit"))
                    {
                        if (ct.Text == "" || !((CheckEdit)ce).Checked)
                            ct.Text = str;
                        else
                            ct.Text += "\r\n" + str;
                    }
                    else
                        if (lp.CtrlType.Contains("TextEdit"))
                        {
                            if (ct.Text == "" || !((CheckEdit)ce).Checked)
                                ct.Text = str;
                            else
                                ct.Text += "，" + str;
                        }

                }
            }
            ctrl_Leave(ct, null);
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ctrl_Leave(sender, e);

        }
        void btn_Save_Click(object sender, EventArgs e)
        {

            dsoFramerWordControl1.FileSave();
            try
            {
                currRecord.LastChangeTime = DateTime.Now.ToString();
                currRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                Client.ClientHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                ArrayList akeys = new ArrayList(valuehs.Keys);
                List<object> list = new List<object>();

                DateTime dt = DateTime.Now;
                Random rd = new Random();
                WF_TableFieldValue wfv = null;
                int irpos = 5001;
                decimal dtemp = Convert.ToDecimal(dt.ToString("yyyyMMddHHmmssffffff"));
                for (int i = 0; i < akeys.Count; i++)
                {
                    wfv = valuehs[akeys[i]] as WF_TableFieldValue;
                    if (wfv.XExcelPos != -1 && wfv.YExcelPos != -1)
                        wfv.ID = Convert.ToString((dtemp + wfv.YExcelPos + wfv.XExcelPos * 10000));
                    else
                    {

                        wfv.ID = Convert.ToString((dtemp + irpos + irpos * 10000));
                        irpos++;
                    }
                    wfv.RecordId = currRecord.ID;
                    wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    wfv.UserControlId = parentTemple.LPID;
                    //MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                    //Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    list.Add(wfv);
                    MainHelper.PlatformSqlMap.DeleteByWhere<WF_TableFieldValue>(" where FieldId ='" + wfv.FieldId + "' and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                }
                //foreach (WF_TableFieldValue wfv in list)
                //{
                //    Console.Write(wfv.ID + "\r\n");
                //}
                foreach (WF_TableFieldValue wfv2 in list)
                {
                    WF_TableFieldValue wtfvtemp = Client.ClientHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                         + " and   WorkflowId='" + wfv2.WorkFlowId + "'"
                         + " and   RecordId='" + wfv2.RecordId + "'"
                         + " and   UserControlId='" + wfv2.UserControlId + "'"
                         + " and   WorkFlowInsId='" + wfv2.WorkFlowInsId + "'"
                         + " and   fieldname='" + wfv2.FieldName + "'"
                         + " and   FieldId='" + wfv2.FieldId + "'"
                         + " and   XExcelPos='" + wfv2.XExcelPos + "'"
                         + " and   YExcelPos='" + wfv2.YExcelPos + "'"
                         + " and   WorkTaskId='" + wfv2.WorkTaskId + "'"
                         );
                    if (wtfvtemp != null)
                        wfv2.ID = wtfvtemp.ID;
                    else
                    {
                        Client.ClientHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv2);
                    }
                }
                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, list, null);
                LP_Temple lp = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + parentTemple.LPID + "' and SortID=1");
                if (lp != null)
                {
                    if (wfv == null)
                    {
                        wfv = new WF_TableFieldValue();
                        wfv.ID = wfv.CreateID();
                        wfv.RecordId = currRecord.ID;
                        wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        wfv.UserControlId = parentTemple.LPID;
                        wfv.ControlValue = "";
                        wfv.FieldId = lp.LPID;
                        wfv.FieldName = lp.CellName;
                        wfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                        wfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                        wfv.ExcelSheetName = activeSheetName;
                    }

                    wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                                     + " and   WorkflowId='" + wfv.WorkFlowId + "'"
                                     + " and   RecordId='" + wfv.RecordId + "'"
                                     + " and   UserControlId='" + wfv.UserControlId + "'"
                                     + " and   WorkFlowInsId='" + wfv.WorkFlowInsId + "'"
                                     + " and   fieldname='" + lp.CellName + "'"
                                     + " and   FieldId='" + lp.LPID + "' and Bigdata is not null"
                                    );
                    dsoFramerWordControl1.FileSave();
                    currRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    if (wfv == null)
                    {
                        wfv = new WF_TableFieldValue();
                        wfv.ID = wfv.CreateID();
                        wfv.RecordId = currRecord.ID;
                        wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        wfv.UserControlId = parentTemple.LPID;
                        wfv.ControlValue = "";
                        wfv.FieldId = lp.LPID;
                        wfv.FieldName = lp.CellName;
                        wfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                        wfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                        wfv.ExcelSheetName = activeSheetName;
                        wfv.Bigdata = currRecord.DocContent;
                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                    }
                    else
                    {
                        wfv.Bigdata = currRecord.DocContent;
                        MainHelper.PlatformSqlMap.Update<WF_TableFieldValue>(wfv);

                    }
                }
                MsgBox.ShowTipMessageBox("保存成功!");
                //this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MsgBox.ShowTipMessageBox("出错,保存失败!");
            }
        }
        void btn_Back_Click(object sender, EventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认退回?") != DialogResult.OK)
            {
                return;
            }
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            string strmes = RecordWorkTask.RunWorkFlowBack(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
            {

                currRecord.Status = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());

                currRecord.LastChangeTime = DateTime.Now.ToString();
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                MsgBox.ShowTipMessageBox(strmes);

            }
            if (hqyjcontrol != null)
            {
                PJ_lcspyj lcyj = new PJ_lcspyj();
                lcyj.Charman = MainHelper.User.UserName;
                lcyj.ID = PJ_lcspyj.Newid();
                lcyj.RecordID = currRecord.ID;
                lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                lcyj.Creattime = DateTime.Now;
                if (hqyjcontrol.nowMemoEdit.Text != "")
                    MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);

            }
            dsoFramerWordControl1.FileSave();
            dsoFramerWordControl1.FileClose();
            this.DialogResult = DialogResult.OK;
        }
        void btn_Submit_Click(object sender, EventArgs e)
        {
            Excel.Workbook wb;
            //Excel.Worksheet sheet;
            wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            if (activeSheetName != "")
            {
                sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
            }
            else
            {
                sheet = wb.Application.Sheets[1] as Excel.Worksheet;
            }
            //activeSheetIndex = sheet.Index;
            if (filecontrol != null)
            {
                if (filecontrol.Isupfile)
                {
                    MsgBox.ShowTipMessageBox("请稍后，正在上传文件");
                    return;
                }
                if (filecontrol.Isdownfile)
                {
                    if (MsgBox.ShowAskMessageBox("正在下载文件，确认提交?") != DialogResult.OK)
                    {
                        return;
                    }

                }
            }
            for (int i = 1; i <= wb.Application.Sheets.Count; i++)
            {
                if (i != activeSheetIndex)
                {
                    Excel.Worksheet tmpSheet = (Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                    try
                    {
                        if (tmpSheet != null) tmpSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                    }
                    catch { }

                }
            }
            unLockExcel(wb, sheet);
            for (int i = 1; sheet.Protection.AllowEditRanges.Count > 0; )
            {
                Excel.AllowEditRange editRange = sheet.Protection.AllowEditRanges.get_Item(i);
                editRange.Delete();
            }
            LockExcel(wb, sheet);
            byte[] bt = new byte[0];
            string strmes = "";
            WF_WorkTaskCommands wt;
            if (strNumber != "") currRecord.Number = strNumber;
            ArrayList akeys = new ArrayList(valuehs.Keys);
            List<object> list = new List<object>();

            DateTime dt = DateTime.Now;
            Random rd = new Random();
            int irpos = 5001;
            WF_TableFieldValue wfv = null;
            decimal dtemp = Convert.ToDecimal(dt.ToString("yyyyMMddHHmmssffffff"));
            for (int i = 0; i < akeys.Count; i++)
            {
                wfv = valuehs[akeys[i]] as WF_TableFieldValue;
                if (wfv.XExcelPos != -1 && wfv.YExcelPos != -1)
                    wfv.ID = Convert.ToString((dtemp + wfv.YExcelPos + wfv.XExcelPos * 10000));
                else
                {

                    wfv.ID = Convert.ToString((dtemp + irpos + irpos * 10000));
                    irpos++;
                }
                wfv.RecordId = currRecord.ID;
                wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                wfv.UserControlId = parentTemple.LPID;
                //MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                //Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                wfv.ID = wfv.CreateID()+new Random().Next(10,99);
                list.Add(wfv);
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_TableFieldValue>(" where FieldId ='" + wfv.FieldId + "' and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            }
            //foreach (WF_TableFieldValue wfv in list)
            //{
            //    Console.Write(wfv.ID+"\r\n");
            //}

            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, dsoFramerWordControl1, currRecord.ID, new object[] { currRecord });

            }
            //RecordWorkTask.CreateJL(WorkFlowData, dsoFramerWordControl1, currRecord.ID, new object[] { currRecord });
            if (strxiestatus == "add")
            {
                if (list.Count > 0)
                {

                    Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(list, null, null);

                }
            }
            else
            {
                if (list.Count > 0)
                {
                    foreach (WF_TableFieldValue wfv2 in list)
                    {
                        WF_TableFieldValue wtfvtemp = Client.ClientHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                             + " and   WorkflowId='" + wfv2.WorkFlowId + "'"
                             + " and   RecordId='" + wfv2.RecordId + "'"
                             + " and   UserControlId='" + wfv2.UserControlId + "'"
                             + " and   WorkFlowInsId='" + wfv2.WorkFlowInsId + "'"
                             + " and   fieldname='" + wfv2.FieldName + "'"
                             + " and   FieldId='" + wfv2.FieldId + "'"
                             + " and   XExcelPos='" + wfv2.XExcelPos + "'"
                             + " and   YExcelPos='" + wfv2.YExcelPos + "'"
                             + " and   WorkTaskId='" + wfv2.WorkTaskId + "'"
                             );
                        if (wtfvtemp != null)
                            wfv2.ID = wtfvtemp.ID;
                        else
                        {
                            wfv2.ID = wfv2.CreateID();
                            Client.ClientHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv2);
                        }
                    }
                    Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, list, null);
                }
            }
            LP_Temple lp = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + parentTemple.LPID + "' and SortID=1");
            if (lp != null)
            {
                if (wfv == null)
                {
                    wfv = new WF_TableFieldValue();
                    wfv.ID = wfv.CreateID();
                    wfv.RecordId = currRecord.ID;
                    wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    wfv.UserControlId = parentTemple.LPID;
                    wfv.ControlValue = "";
                    wfv.FieldId = lp.LPID;
                    wfv.FieldName = lp.CellName;
                    wfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    wfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                    wfv.ExcelSheetName = activeSheetName;
                }

                wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                                 + " and   WorkflowId='" + wfv.WorkFlowId + "'"
                                 + " and   RecordId='" + wfv.RecordId + "'"
                                 + " and   UserControlId='" + wfv.UserControlId + "'"
                                 + " and   WorkFlowInsId='" + wfv.WorkFlowInsId + "'"
                                 + " and   fieldname='" + lp.CellName + "'"
                                 + " and   FieldId='" + lp.LPID + "' and Bigdata is not null"
                                );

                dsoFramerWordControl1.FileSave();
                currRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                if (wfv == null)
                {
                    wfv = new WF_TableFieldValue();
                    wfv.ID = wfv.CreateID();
                    wfv.RecordId = currRecord.ID;
                    wfv.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    wfv.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    wfv.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    wfv.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    wfv.UserControlId = parentTemple.LPID;
                    wfv.ControlValue = "";
                    wfv.FieldId = lp.LPID;
                    wfv.FieldName = lp.CellName;
                    wfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    wfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                    wfv.ExcelSheetName = activeSheetName;
                    wfv.Bigdata = currRecord.DocContent;
                    MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                }
                else
                {
                    wfv.Bigdata = currRecord.DocContent;
                    MainHelper.PlatformSqlMap.Update<WF_TableFieldValue>(wfv);

                }
            }
            RunTaskUpdate();
            RunTaskRecordUpdate();
            switch (status)
            {
                case "add":

                    //LP_Record newRecord = new LP_Record();
                    currRecord.Kind = kind;
                    currRecord.Content = GetContent();
                    dsoFramerWordControl1.FileSave();
                    //dsoFramerWordControl1.FileClose();
                    if (ctrlNumber != null)
                        currRecord.Number = ctrlNumber.Text;
                    //currRecord.ImageAttachment = bt;
                    //currRecord.SignImg = bt;
                    currRecord.LastChangeTime = DateTime.Now.ToString();

                    //string[] strtemp = RecordWorkTask.RunNewGZPRecord(currRecord.ID, kind, MainHelper.User.UserID);
                    wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    if (wt != null)
                    {
                        strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
                    }
                    else
                    {
                        strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
                    }
                    //strmes = strtemp[0];
                    //currRecord.Status = strtemp[1];
                    if (strmes.IndexOf("未提交至任何人") > -1)
                    {
                        MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
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
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                    rowData = null;
                    if (hqyjcontrol != null)
                    {
                        PJ_lcspyj lcyj = new PJ_lcspyj();
                        lcyj.Charman = MainHelper.User.UserName;
                        lcyj.ID = PJ_lcspyj.Newid();
                        lcyj.RecordID = currRecord.ID;
                        lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                        lcyj.Creattime = DateTime.Now;
                        if (hqyjcontrol.nowMemoEdit.Text != "")
                            MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);
                    }
                    if (filecontrol != null)
                    {
                        for (int i = 0; i < filecontrol.FJtable.Rows.Count; i++)
                        {

                            PJ_lcfj lcfu = new PJ_lcfj();
                            lcfu.ID = lcfu.CreateID();
                            lcfu.Filename = Path.GetFileName(filecontrol.FJtable.Rows[i]["FilePath"].ToString());
                            lcfu.FileRelativePath = filecontrol.FJtable.Rows[i]["SaveFileName"].ToString();
                            lcfu.FileSize = Convert.ToInt64(filecontrol.FJtable.Rows[i]["FileSize"]);
                            lcfu.RecordID = currRecord.ID;
                            lcfu.Creattime = DateTime.Now;
                            Thread.Sleep((new TimeSpan(100000)));//0.1毫秒
                            if (filecontrol.FJtable.Rows[i]["Kind"].ToString() != "已上传")
                                MainHelper.PlatformSqlMap.Create<PJ_lcfj>(lcfu);
                        }

                    }
                    //currRecord = newRecord;
                    break;
                case "edit":

                    currRecord.LastChangeTime = DateTime.Now.ToString();
                    // dsoFramerWordControl1.FileSave();
                    //currRecord.DocContent = this.dsoFramerWordControl1.FileDataGzip;
                    //byte[] bt = new byte[0];
                    //currRecord.ImageAttachment = bt;
                    //currRecord.SignImg = bt;
                    currRecord.Content = GetContent();
                    dsoFramerWordControl1.FileSave();
                    //dsoFramerWordControl1.FileClose();
                    wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    if (wt != null)
                    {
                        strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
                    }
                    else
                    {
                        strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
                    }
                    string towho = strmes;
                    strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
                    if (strmes.IndexOf("结束节点") > -1)
                    {
                        CurrRecord.Status = "存档";
                    }
                    else
                    {
                        CurrRecord.Status = strmes;
                    }
                    if (towho.IndexOf("未提交至任何人") > -1)
                    {
                        MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                        return;
                    }
                    else
                        MsgBox.ShowTipMessageBox(towho);
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                    if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record", currRecord);
                    if (hqyjcontrol != null)
                    {
                        PJ_lcspyj lcyj = new PJ_lcspyj();
                        lcyj.Charman = MainHelper.User.UserName;
                        lcyj.ID = PJ_lcspyj.Newid();
                        lcyj.RecordID = currRecord.ID;
                        lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                        lcyj.Creattime = DateTime.Now;
                        if (hqyjcontrol.nowMemoEdit.Text != "")
                            MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);

                    }

                    rowData = null;
                    break;
            }


            this.DialogResult = DialogResult.OK;
        }

        public string GetContent()
        {
            StringBuilder strBuild = new StringBuilder();
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                {
                    LP_Temple lp = ctrl.Tag as LP_Temple;
                    strBuild.Append(lp.LPID);
                    strBuild.Append(",");
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        strBuild.Append((ctrl as uc_gridcontrol).ConvertBetweenDataTableAndXML_AX((ctrl as uc_gridcontrol).GetDS()));
                    }
                    else
                        strBuild.Append(ctrl.Text);
                    strBuild.Append(plitchar);
                }
            }
            return strBuild.ToString();
        }
        public void ClearContent()
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                {
                    LP_Temple lp = ctrl.Tag as LP_Temple;
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        (ctrl as uc_gridcontrol).SetDs(null);
                    }
                    else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
                    {
                        (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = System.DateTime.Now;
                    }
                    else
                        ctrl.Text = "";
                }
            }
        }
        public void LoadContent()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] arrContent = currRecord.Content.Split(pchar);
            for (int i = 0; i < arrContent.Length; i++)
            {
                if (arrContent[i] != "")
                {
                    int index = arrContent[i].IndexOf(',');
                    dict[arrContent[i].Substring(0, index)] = arrContent[i].Substring(index + 1);
                }
            }
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                {
                    LP_Temple lp = ctrl.Tag as LP_Temple;
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        if (dict.ContainsKey(lp.LPID)) (ctrl as uc_gridcontrol).SetDs((ctrl as uc_gridcontrol).ConvertBetweenDataTableAndXML_AX(dict[lp.LPID]));
                    }
                    else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
                    {
                        if (dict.ContainsKey(lp.LPID))
                        {
                            Regex r1 = new Regex(@"[0-9]+-[0-9]+日 [0-9]+:[0-9]+");
                            if (r1.Match(dict[lp.LPID]).Value != "")
                            {
                                (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = Convert.ToDateTime(DateTime.Now.Year + "-" + dict[lp.LPID].Replace("日", ""));
                            }
                            else
                            {

                                (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = Convert.ToDateTime(dict[lp.LPID]);
                            }
                        }
                    }
                    else
                    {
                        if (dict.ContainsKey(lp.LPID))
                            ctrl.Text = dict[lp.LPID];
                    }
                    //ContentChanged(ctrl);
                }
            }
            if (parentTemple != null && currRecord.ID.IndexOf("N") > -1)
            {
                IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                    " where RecordId='" + currRecord.ID + "' and UserControlId='" + parentTemple.LPID + "' and   WorkflowId='" + WorkFlowData.Rows[0]["WorkflowId"] + "' and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"] + "' ");
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                Excel.Worksheet xx;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                activeSheetName = "";
                xx = wb.Application.Sheets[1] as Excel.Worksheet;
                int i = 0;
                ArrayList al = new ArrayList();
                for (i = 1; i <= wb.Application.Sheets.Count; i++)
                {
                    xx = wb.Application.Sheets[i] as Excel.Worksheet;
                    if (!al.Contains(xx.Name)) al.Add(xx.Name);
                }
                for (i = 0; i < tfvli.Count; i++)
                {
                    if (!al.Contains(tfvli[i].ExcelSheetName))
                    {

                        continue;
                    }
                    if (activeSheetName != tfvli[i].ExcelSheetName)
                    {
                        if (activeSheetName != "")
                        {

                            xx = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
                            LockExcel(wb, xx);

                        }
                        xx = wb.Application.Sheets[tfvli[i].ExcelSheetName] as Excel.Worksheet;
                        Workbook_SheetDeactivate(xx);
                        unLockExcel(wb, xx);
                        activeSheetName = tfvli[i].ExcelSheetName;
                        activeSheetIndex = xx.Index;
                        try
                        {
                            ea.ActiveSheet(xx.Index);
                        }
                        catch { }
                    }

                    try
                    {
                        ea.SetCellValue(tfvli[i].ControlValue, tfvli[i].XExcelPos, tfvli[i].YExcelPos);
                    }
                    catch { }
                }
                LockExcel(wb, xx);
            }
        }

        public void InitEvent()
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Tag != null)
                {
                    RelateEvent(ctrl);
                }
            }
        }
        public void RunTaskUpdate()
        {
            IList<WF_WorkTastTrans> wttli = MainHelper.PlatformSqlMap.GetList<WF_WorkTastTrans>(" where slcjdid='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "' and cdfs like '赋值%'");
            foreach (WF_WorkTastTrans wtt in wttli)
            {
                Control ctrl = FindCtrl(wtt.slcjdzdid);
                if (ctrl != null)
                {
                    RunTaskCtrlData(ctrl, wtt.sSQL, wtt);

                }
            }

        }
        /// <summary>
        /// 节点生成记录
        /// </summary>
        public void RunTaskRecordUpdate()
        {

            IList<WF_TaskVar> wttli = MainHelper.PlatformSqlMap.GetList<WF_TaskVar>(" where WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "' and AccessType like '生成记录%'");
            foreach (WF_TaskVar wtt in wttli)
            {
                RunTaskRecordCtrlData(wtt.InitValue, wtt);

            }
        }
        public static void RunTaskRecordUpdate(DataTable wf)
        {

            IList<WF_TaskVar> wttli = MainHelper.PlatformSqlMap.GetList<WF_TaskVar>(" where WorkTaskId='" + wf.Rows[0]["WorkTaskId"].ToString() + "' and AccessType like '生成记录%'");
            foreach (WF_TaskVar wtt in wttli)
            {
                RunTaskRecordCtrlData(wtt.InitValue, wtt, wf);

            }
        }

        private static void RunTaskRecordCtrlData(string p, WF_TaskVar wtt, DataTable wf)
        {
            throw new NotImplementedException();
        }


        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            return (System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute).DisplayName;
        }

        public void RunTaskRecordCtrlData(string sqlSentence, WF_TaskVar wtt)
        {
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", wtt.VarName);
            Hashtable hs = new Hashtable();
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "Ebada.Scgl.Model.dll");
            Type tpe = assembly.GetType("Ebada.Scgl.Model." + wtt.VarName);

            for (int i = 0; i < li.Count; i++)
            {
                Regex r1 = new Regex(@"(?<=\[" + (li[i] as WF_WorkFlow).Name + ":).*?(?=\\])");
                if (r1.Match(sqlSentence.Replace("\r\n", " ")).Value != "")
                {

                    IList sli = ExTaskRecordCtrlSQL(r1.Match(sqlSentence.Replace("\r\n", " ")).Value, wtt);
                    if (hs.Contains((li[i] as WF_WorkFlow).Name) == false) hs.Add((li[i] as WF_WorkFlow).Name, "");
                    if (sli.Count > 0)
                    {

                        if (GetDisplayName(tpe, (li[i] as WF_WorkFlow).Name).IndexOf("时间") > 0)
                        {
                            if (sli[0].ToString().IndexOf("年") > -1)
                                hs[(li[i] as WF_WorkFlow).Name] = sli[1];
                            else
                                hs[(li[i] as WF_WorkFlow).Name] = sli[0];

                        }
                        else
                        {
                            hs[(li[i] as WF_WorkFlow).Name] = sli[0];
                        }

                    }
                }


            }
            ArrayList akeys = new ArrayList(hs.Keys);
            string strsql = "";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + wtt.VarName + "'");
            strsql = " INSERT INTO " + wtt.VarName;

            foreach (string strv in list)
            {
                if (strv == list[0].ToString())
                {
                    strsql = strsql + " ( " + strv;
                }
                else
                {
                    strsql = strsql + "," + strv;
                }
            }
            for (int i = 0; i < akeys.Count; i++)
            {
                if (list[0].ToString() != akeys[i].ToString())
                {
                    strsql += "," + akeys[i];
                }
            }
            string strid = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
            strsql += " )  values (";
            foreach (string strv in list)
            {
                if (strv == list[0].ToString())
                {
                    if (hs.Contains(strv))
                        strsql = strsql + "  '" + hs[strv] + "'";
                    else
                        strsql = strsql + "  '" + strid + "'";

                }
                else
                {

                    if (hs.Contains(strv))
                        strsql = strsql + ",'" + hs[strv] + "'";
                    else
                        strsql = strsql + ",'" + strid + "'";
                }
            }
            //strsql += "'" + strid + "' ";
            for (int i = 0; i < akeys.Count; i++)
            {

                if (list[0].ToString() != akeys[i].ToString())
                {
                    if (tpe.GetMember(akeys[i].ToString())[0].ToString().IndexOf("System.Int") > 0
                        || tpe.GetMember(akeys[i].ToString())[0].ToString().IndexOf("System.Double") > 0
                        )
                        strsql += " , " + hs[akeys[i]] + " ";
                    else
                        strsql += " , '" + hs[akeys[i]] + "' ";
                }
            }
            strsql += " )  ";
            MainHelper.PlatformSqlMap.Update("Update", strsql);
            WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
            mrwt.ModleRecordID = strid;
            mrwt.RecordID = currRecord.ID;
            mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
            mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
            mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
            mrwt.ModleTableName = wtt.VarName;
            mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
            mrwt.CreatTime = DateTime.Now;
            MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
        }
        public IList ExTaskRecordCtrlSQL(string sqlSentence, WF_TaskVar wtt)
        {



            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            Regex r1 = null;
            if (sqlSentence.IndexOf("Excel:") == 0)
            {
                int index1 = sqlSentence.LastIndexOf(":");
                string tablename = sqlSentence.Substring(6, index1 - 6);
                string cellpos = sqlSentence.Substring(index1 + 1);
                string[] arrCellPos = cellpos.Split('|');
                arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                string strcellvalue = "";
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                Excel.Worksheet sheet;
                sheet = wb.Application.Sheets[tablename] as Excel.Worksheet;

                for (int i = 0; i < arrCellPos.Length; i++)
                {
                    Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                    strcellvalue += range.Value2;
                }
                li.Add(strcellvalue);
            }
            else if (sqlSentence != "")
            {
                if (sqlSentence.IndexOf("{recordparentid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordparentid}", currRecord.ParentID);
                }
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                if (sqlSentence.IndexOf("'{datetime}'") > -1)
                {
                    sqlSentence = sqlSentence.Replace("'{datetime}'", "getdate()");
                }
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", " ");
                    Hashtable value = Client.ClientHelper.PlatformSqlMap.GetObject("Select", sqlSentence) as Hashtable;
                    if (value != null && value.Count > 0)
                    {
                        foreach (object obj in value.Values)
                        {
                            li.Add(obj); break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (sqlSentence.Contains("{datetime}"))
                        li.Add(DateTime.Now);
                    else
                        li.Add("出错:" + ex.Message);
                }
            }
            return li;
        }
        public void RunTaskCtrlData(Control ctrl, string sqlSentence, WF_WorkTastTrans wtt)
        {
            IList sli = ExTaskCtrlSQL(ctrl, wtt.sSQL, wtt);
            IList tli = ExTaskCtrlSQL(ctrl, wtt.tSQL, wtt);
            if (sli.Count > 0 && tli.Count > 0)
            {
                string svalue = "";
                if (sli.Count > 1)
                {
                    if (wtt.slcjdzdmc.IndexOf("时间") > 0 && wtt.slcjdzdlx == "表单")
                    {
                        if (sli[0].ToString().IndexOf("年") > -1)
                            svalue = sli[1].ToString();
                        else
                            svalue = sli[0].ToString();

                    }
                    else
                    {
                        svalue = sli[0].ToString();
                    }
                }

                if (sli[0].ToString().IndexOf("出错:") == -1 && tli[0].ToString().IndexOf("出错:") == -1)
                {
                    string sql = "";
                    if (wtt.tlcjdzdlx == "表单")
                    {
                        sql = "update WF_TableFieldValue  set ControlValue='" + svalue
                            + "' where id='" + tli[0].ToString() + "'";

                    }
                    else if (wtt.tlcjdzdlx == "模块")
                    {
                        sql = "update " + wtt.tlcjdzdid.Split(' ')[0] + "  set " + wtt.tlcjdzdid.Split(' ')[1] + "='" + svalue
                           + "' where id='" + tli[0].ToString() + "'";
                    }
                    MainHelper.PlatformSqlMap.Update("Update", sql);
                }
            }
        }
        public IList ExTaskCtrlSQL(Control ctrl, string sqlSentence, WF_WorkTastTrans wtt)
        {

            LP_Temple lp = (LP_Temple)ctrl.Tag;
            bool flag = (lp.Status == CurrRecord.Status);
            string ctrltype = "";
            if (lp.CtrlType.IndexOf("uc_gridcontrol") > -1)
            {

                if (sqlSentence.IndexOf("{recordparentid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordparentid}", currRecord.ParentID);
                }
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {

                            if (ct is DateEdit)
                            {
                                ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                                ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                            }
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            IList li2 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li2.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li2[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }
                }

            }
            if (lp.CtrlType.IndexOf(',') == -1)
                ctrltype = lp.CtrlType;
            else
                ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            if (sqlSentence.IndexOf("Excel:") == 0)
            {
                int index1 = sqlSentence.LastIndexOf(":");
                string tablename = sqlSentence.Substring(6, index1 - 6);
                string cellpos = sqlSentence.Substring(index1 + 1);
                string[] arrCellPos = cellpos.Split('|');
                arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                string strcellvalue = "";
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                Excel.Worksheet sheet;
                sheet = wb.Application.Sheets[tablename] as Excel.Worksheet;

                for (int i = 0; i < arrCellPos.Length; i++)
                {
                    Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                    strcellvalue += range.Value2;
                }
                li.Add(strcellvalue);
            }
            else if (sqlSentence != "")
            {
                if (sqlSentence.IndexOf("{recordparentid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordparentid}", currRecord.ParentID);
                }
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            if (ct is DateEdit)
                            {
                                ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                                ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                            }
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }

                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }



                }
                r1 = new Regex(@"(?<={编号规则一:)[0-9]+(?=})");
                if (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("SelectmOrgList",
                                "where OrgName='" + ct.Text + "'");
                            if (list.Count > 0)
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", RecordWorkTask.CreatWorkFolwNo(list[0], listLPID[0].ParentID, "编号规则一"));
                            else
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "");

                        }
                        else
                        {
                            sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                    }

                }
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", " ");
                    li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);

                }
                catch (Exception ex)
                {
                    li.Add("出错:" + ex.Message);
                }
            }
            return li;
        }
        public void InitTaskData()
        {
            IList<WF_WorkTastTrans> wttli = MainHelper.PlatformSqlMap.GetList<WF_WorkTastTrans>(" where  tlcjdid='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "' and cdfs like '下拉%'");
            foreach (WF_WorkTastTrans wtt in wttli)
            {
                Control ctrl = FindCtrl(wtt.tlcjdzdid);
                if (ctrl != null)
                {
                    InitTaskCtrlData(ctrl, wtt.sSQL, wtt);

                }
            }
        }

        public void InitTaskCtrlData(Control ctrl, string sqlSentence, WF_WorkTastTrans wtt)
        {

            LP_Temple lp = (LP_Temple)ctrl.Tag;
            bool flag = (lp.Status == CurrRecord.Status);
            string ctrltype = "";
            if (lp.CtrlType.IndexOf("uc_gridcontrol") > -1)
            {

                if (sqlSentence.IndexOf("{recordparentid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordparentid}", currRecord.ParentID);
                }
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {

                            if (ct is DateEdit)
                            {
                                ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                                ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                            }
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            IList li2 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li2.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li2[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }
                }
                ((uc_gridcontrol)ctrl).InitGridData(sqlSentence);
                gridView1_CellValueChanged(ctrl, null);
                //((uc_gridcontrol)ctrl).InitData(lp.SqlSentence, lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar), dsoFramerWordControl1, lp, currRecord);
                return;
            }
            if (lp.CtrlType.IndexOf(',') == -1)
                ctrltype = lp.CtrlType;
            else
                ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            if (sqlSentence.IndexOf("Excel:") == 0)
            {
                int index1 = sqlSentence.LastIndexOf(":");
                string tablename = sqlSentence.Substring(6, index1 - 6);
                string cellpos = sqlSentence.Substring(index1 + 1);
                string[] arrCellPos = cellpos.Split('|');
                arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                string strcellvalue = "";
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                Excel.Worksheet sheet;
                sheet = wb.Application.Sheets[tablename] as Excel.Worksheet;

                for (int i = 0; i < arrCellPos.Length; i++)
                {
                    Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                    strcellvalue += range.Value2;
                }
                li.Add(strcellvalue);
            }
            else if (sqlSentence != "")
            {
                if (sqlSentence.IndexOf("{recordparentid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordparentid}", currRecord.ParentID);
                }
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            if (ct is DateEdit)
                            {
                                ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                                ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                            }
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }

                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }



                }
                r1 = new Regex(@"(?<={编号规则一:)[0-9]+(?=})");
                if (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("SelectmOrgList",
                                "where OrgName='" + ct.Text + "'");
                            if (list.Count > 0)
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", RecordWorkTask.CreatWorkFolwNo(list[0], listLPID[0].ParentID, "编号规则一"));
                            else
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "");

                        }
                        else
                        {
                            sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                    }

                }
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", " ");
                    li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                    if (sqlSentence.IndexOf("where 9=9") > -1)
                    {
                        string strtemp = li[0].ToString();
                        li.Clear();
                        r1 = new Regex(@"[0-9]+\+[0-9]+");
                        if (r1.Match(strtemp).Value != "")
                        {
                            int istart = 1;
                            int ilen = 10;
                            r1 = new Regex(@"[0-9]+(?=\+)");
                            if (r1.Match(strtemp).Value != "")
                            {
                                istart = Convert.ToInt32(r1.Match(strtemp).Value);
                            }
                            r1 = new Regex(@"(?<=\+)[0-9]+");
                            if (r1.Match(strtemp).Value != "")
                            {
                                ilen = Convert.ToInt32(r1.Match(strtemp).Value); ;
                            }
                            for (int i = istart; i <= ilen; i++)
                            {
                                li.Add(string.Format("{0}", i));
                            }
                        }
                        else
                        {
                            string[] strli = SelectorHelper.ToDBC(strtemp).Split(',');
                            foreach (string ss in strli)
                            {
                                li.Add(ss);
                            }

                        }
                    } else if (sqlSentence.IndexOf("where 12=12") > -1) {//表格数据源
                        StringBuilder sb = new StringBuilder();
                        foreach (var obj in li) {
                            sb.Append(obj);
                        }
                        li.Clear();
                        li.Add(sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    li.Add("出错:" + ex.Message);
                }
            }
            switch (ctrltype)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    if (li.Count > 0 && sqlSentence != "" && wtt.cdfs == "下拉并选中")
                        ((DevExpress.XtraEditors.TextEdit)ctrl).Text = li[0].ToString();
                    if (li.Count > 0 && sqlSentence != "")
                    {
                        //((DevExpress.XtraEditors.TextEdit)ctrl).Text = li[0].ToString();
                        Control bttip = FindCtrl("bt" + lp.LPID);
                        if (bttip != null)
                        {
                            ((ComboBoxEdit)bttip).Properties.Items.Clear();
                            ((ComboBoxEdit)bttip).Properties.Items.AddRange(li);
                            if (((ComboBoxEdit)bttip).Properties.Items.Count > 0 && wtt.cdfs == "下拉并选中")
                                ((ComboBoxEdit)bttip).SelectedIndex = 0;
                        }
                    }
                    break;
                case "DevExpress.XtraEditors.SpinEdit":
                    if (li.Count > 0 && sqlSentence != "")
                    {
                        if (li.Count > 0 && sqlSentence != "" && wtt.cdfs == "下拉并选中" && li[0].ToString() != "")
                            ((DevExpress.XtraEditors.SpinEdit)ctrl).Value = Convert.ToDecimal(li[0].ToString());
                        Control bttip = FindCtrl("bt" + lp.LPID);
                        if (bttip != null)
                        {
                            ((ComboBoxEdit)bttip).Properties.Items.Clear();
                            ((ComboBoxEdit)bttip).Properties.Items.AddRange(li);
                            if (((ComboBoxEdit)bttip).Properties.Items.Count > 0 && wtt.cdfs == "下拉并选中")
                                ((ComboBoxEdit)bttip).SelectedIndex = 0;
                        }
                    }
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

                    if (li.Count > 0 && sqlSentence != "") {
                        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Clear();
                        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.AddRange(li);
                    }
                    string[] comBoxItem = lp.ComBoxItem.Split(pcomboxchar);
                    comBoxItem = StringHelper.ReplaceEmpty(comBoxItem).Split(pchar);
                    for (int i = 0; i < comBoxItem.Length; i++)
                    {
                        if (comBoxItem[i] != "")
                        {
                            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Add(comBoxItem[i]);
                        }
                    }
                    if (((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Count > 0)
                    {

                        if (lp.CellName == "单位")
                        {
                            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgCode  from mOrg where OrgName='" + ctrl.Text + "'");
                            if (list.Count > 0)
                            {
                                switch (kind)
                                {
                                    case "电力线路第一种工作票":
                                    case "yzgzp":
                                        //strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        if (bhht[ctrl.Text] != null)
                                        {
                                            strNumber = "07" + bhht[ctrl.Text].ToString();

                                        }
                                        else
                                            strNumber = "07";
                                        break;
                                    case "电力线路第二种工作票":
                                    case "ezgzp":
                                        //strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        break;
                                    case "电力线路倒闸操作票":
                                    case "dzczp":
                                        //strNumber = "BJ" + System.DateTime.Now.Year.ToString();
                                        strNumber = "06" + list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        break;
                                    case "电力线路事故应急抢修单":
                                    case "xlqxp":
                                        //strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        break;
                                    default:
                                        if (lp.KindTable == "低压第一种工作票")
                                        {
                                            strNumber = "11" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        }
                                        else if (lp.KindTable == "低压第二种工作票")
                                        {
                                            strNumber = "12" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        }
                                        else
                                        {
                                            strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        }
                                        break;
                                }
                                //IList<LP_Record> listLPRecord = ClientHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", " where kind = '" + kind + "' and number like '" + strNumber + "%'");
                                IList listLPRecord = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select ControlValue from WF_TableFieldValue where  FieldName='编号' and UserControlId='{0}' and WorkFlowInsId!='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' and ControlValue like '" + strNumber + "%' and id like '" + DateTime.Now.Year + "%' order by id desc", parentTemple.LPID));
                                if (kind == "yzgzp")
                                {
                                    //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                                    //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                                    if (listLPRecord.Count == 0)
                                        strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                    else
                                    {
                                        decimal udw = Convert.ToDecimal(listLPRecord[0]);
                                        strNumber = "0" + (udw + 1).ToString().PadLeft(3, '0');
                                    }
                                }
                                else
                                {
                                    if (listLPRecord.Count == 0)
                                        strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                    else
                                    {
                                        decimal udw = Convert.ToDecimal(listLPRecord[0].ToString().Substring(listLPRecord[0].ToString().Length - 3));
                                        strNumber = listLPRecord[0].ToString().Substring(0, listLPRecord[0].ToString().Length - 3) + (udw + 1).ToString().PadLeft(3, '0');
                                    }
                                    //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                }
                            }
                            if (ctrlNumber != null) ctrlNumber.Text = strNumber;
                            //ContentChanged(ctrlNumber);
                        }
                        //else
                        //{
                        //Control bttip = FindCtrl("bt" + lp.LPID);
                        if (li.Count > 0  && wtt.cdfs == "下拉并选中")
                            ((ComboBoxEdit)ctrl).Text = li[0].ToString();
                        //}

                    }
                    break;
                case "DevExpress.XtraEditors.DateEdit":

                    if (li.Count > 0 && sqlSentence != "" && wtt.cdfs == "下拉并选中" && li[0].ToString() != "")
                        ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = Convert.ToDateTime(li[0].ToString());

                    if (lp.WordCount != "" && lp.WordCount.IndexOf("|") == -1)
                    {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = lp.WordCount;
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = lp.WordCount;
                    }
                    else
                    {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd HH:mm";

                    }
                    break;
                case "DevExpress.XtraEditors.MemoEdit":
                    if (li.Count > 0 && sqlSentence != "" && wtt.cdfs == "下拉并选中")
                        ((DevExpress.XtraEditors.MemoEdit)ctrl).Text = li[0].ToString();

                    if (li.Count > 0 && sqlSentence != "")
                    {
                        //((DevExpress.XtraEditors.MemoEdit)ctrl).Text = li[0].ToString();
                        Control bttip = FindCtrl("bt" + lp.LPID);
                        if (bttip != null)
                        {
                            ((ComboBoxEdit)bttip).Properties.Items.Clear();
                            ((ComboBoxEdit)bttip).Properties.Items.AddRange(li);
                            //if (((ComboBoxEdit)bttip).Properties.Items.Count > 0)
                            //    ((ComboBoxEdit)bttip).SelectedIndex = 0;
                        }
                    }
                    break;
                case "uc_gridcontrol":
                    if (sqlSentence.IndexOf("{recordid}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                    }
                    if (sqlSentence.IndexOf("{orgcode}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                    }
                    if (sqlSentence.IndexOf("{userid}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                    }
                    if (sqlSentence.IndexOf("{orgname}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                    }
                    if (sqlSentence.IndexOf("{username}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                    }
                    Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                    while (r1.Match(sqlSentence).Value != "")
                    {
                        string sortid = r1.Match(sqlSentence).Value;
                        IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                        if (listLPID.Count > 0)
                        {
                            Control ct = FindCtrl(listLPID[0].LPID);
                            if (ct != null)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                            }
                            else
                            {
                                string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                      + " UserControlId='" + listLPID[0].ParentID + "' "
                                      + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                                IList li2 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                                if (li2.Count > 0)
                                {
                                    sqlSentence = sqlSentence.Replace("{" + sortid + "}", li2[0].ToString());
                                }
                                else
                                {
                                    sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                            break;
                        }
                    }
                    ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence, lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar), dsoFramerWordControl1, lp, currRecord);
                    break;
            }
            if (lp.CellName == "编号") strNumber = ctrl.Text;
            if (ctrlNumber != null && strNumber != "") ctrlNumber.Text = strNumber;
        }
        public static void ReadTaskData(object des, DataTable workflowdata, LP_Temple temp, LP_Record record)
        {
            Type t = des.GetType();
            t.GetProperties();
            Dictionary<string, object> dic = ReadTaskData(workflowdata, temp, record);
            string key = "";
            Dictionary<Type, string> dictypename = new Dictionary<Type, string>();
            foreach (var p in t.GetProperties())
            {
                key = t.Name + " " + p.Name;
                if (dic.ContainsKey(key))
                {
                    if (p.PropertyType == dic[key].GetType())
                        p.SetValue(des, dic[key], null);
                    else
                    {
                        object value = dic[key];
                        switch (p.PropertyType.Name)
                        {
                            case "DateTime":
                                value = Convert.ToDateTime(value);
                                break;
                            case "Int32":
                            case "Int64":
                                value = Convert.ToInt32(value);
                                break;
                            case "Decimal":
                                value = Convert.ToDecimal(value);
                                break;
                            case "Double":
                                value = Convert.ToDouble(value);
                                break;
                        }
                        try { p.SetValue(des, value, null); }
                        catch { }
                    }
                }
            }
        }
        public static Dictionary<string, object> ReadTaskData(DataTable workflowdata, LP_Temple temp, LP_Record record)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            IList<WF_WorkTastTrans> wttli = MainHelper.PlatformSqlMap.GetList<WF_WorkTastTrans>(" where WorkFlowId='" + workflowdata.Rows[0]["WorkFlowId"].ToString() + "' AND tlcjdid='" + workflowdata.Rows[0]["WorkTaskId"].ToString() + "' and tlcjdzdlx = '模块'");
            foreach (WF_WorkTastTrans wtt in wttli)
            {
                IList list = GetTaskCtrlData2(record, temp, wtt.sSQL, wtt);
                if (list.Count > 0)
                    dic.Add(wtt.tlcjdzdid, list[0]);
            }
            return dic;
        }
        public static IList GetTaskCtrlData2(LP_Record record, LP_Temple lp, string sqlSentence, WF_WorkTastTrans wtt)
        {

            //LP_Temple lp =null ;
            string ctrltype = "";

            //if (lp.CtrlType.IndexOf(',') == -1)
            //    ctrltype = lp.CtrlType;
            //else
            //    ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            if (sqlSentence.IndexOf("Excel:") == 0)
            {
                //int index1 = sqlSentence.LastIndexOf(":");
                //string tablename = sqlSentence.Substring(6, index1 - 6);
                //string cellpos = sqlSentence.Substring(index1 + 1);
                //string[] arrCellPos = cellpos.Split('|');
                //arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                //string strcellvalue = "";
                //Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                //ExcelAccess ea = new ExcelAccess();
                //ea.MyWorkBook = wb;
                //ea.MyExcel = wb.Application;
                //Excel.Worksheet sheet;
                //sheet = wb.Application.Sheets[tablename] as Excel.Worksheet;

                //for (int i = 0; i < arrCellPos.Length; i++) {
                //    Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                //    strcellvalue += range.Value2;
                //}
                //li.Add(strcellvalue);
            }
            else if (sqlSentence != "")
            {
                if (sqlSentence.IndexOf("{recordparentid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordparentid}", record.ParentID);
                }
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", record.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        //Control ct = FindCtrl(listLPID[0].LPID);
                        //if (ct != null) {
                        //    if (ct is DateEdit) {
                        //        ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                        //        ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                        //    }
                        //    sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        //} else {
                        string strSQL = "select ControlValue from WF_TableFieldValueView where"
                              + " UserControlId='" + listLPID[0].ParentID + "' "
                              + "and FieldId='" + listLPID[0].LPID + "' and ID='" + record.ID + "'";
                        li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                        if (li.Count > 0)
                        {
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                        }
                        else
                        {
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                            break;
                        }
                        //}

                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }
                }
                //r1 = new Regex(@"(?<={编号规则一:)[0-9]+(?=})");
                //if (r1.Match(sqlSentence).Value != "") {
                //    string sortid = r1.Match(sqlSentence).Value;
                //    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                //    if (listLPID.Count > 0) {
                //        Control ct = FindCtrl(listLPID[0].LPID);
                //        if (ct != null) {
                //            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("SelectmOrgList",
                //                "where OrgName='" + ct.Text + "'");
                //            if (list.Count > 0)
                //                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", RecordWorkTask.CreatWorkFolwNo(list[0], listLPID[0].ParentID, "编号规则一"));
                //            else
                //                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "");

                //        } else {
                //            sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                //        }
                //    } else {
                //        sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                //    }

                //}
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", " ");

                    if (sqlSentence.IndexOf("where 9=9") > -1)
                    {
                        string strtemp = li[0].ToString();
                        li.Clear();
                        r1 = new Regex(@"[0-9]+\+[0-9]+");
                        if (r1.Match(strtemp).Value != "")
                        {
                            int istart = 1;
                            int ilen = 10;
                            r1 = new Regex(@"[0-9]+(?=\+)");
                            if (r1.Match(strtemp).Value != "")
                            {
                                istart = Convert.ToInt32(r1.Match(strtemp).Value);
                            }
                            r1 = new Regex(@"(?<=\+)[0-9]+");
                            if (r1.Match(strtemp).Value != "")
                            {
                                ilen = Convert.ToInt32(r1.Match(strtemp).Value); ;
                            }
                            for (int i = istart; i <= ilen; i++)
                            {
                                li.Add(string.Format("{0}", i));
                            }
                        }
                        else
                        {
                            string[] strli = SelectorHelper.ToDBC(strtemp).Split(',');
                            foreach (string ss in strli)
                            {
                                li.Add(ss);
                            }
                        }
                    }
                    else
                    {
                        IList ht = Client.ClientHelper.PlatformSqlMap.GetList("Select", sqlSentence);
                        if (ht.Count > 0)
                        {
                            DataTable dt = ConvertHelper.ToDataTable(ht);
                            li.Add(dt.Rows[0][0]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    li.Add("出错:" + ex.Message);
                }
            }
            return li;
        }
        public void InitData()
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                //UpdateRelateData(ctrl);
                if (ctrl.Name.IndexOf("bt") > -1)
                    continue;
                if (ctrl.Tag != null && (!tempCtrlList.Contains(ctrl)))
                    InitCtrlData(ctrl, ((LP_Temple)ctrl.Tag).SqlSentence);
            }
        }
        void ContentChanged(Control ctrl)
        {
            LP_Temple lp = (LP_Temple)ctrl.Tag;
            string str = ctrl.Text;
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }

            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet sheet;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;

            if (lp.KindTable != "")
            {
                activeSheetName = lp.KindTable;
                try {
                    sheet = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                } catch { sheet = wb.Application.Sheets[1] as Excel.Worksheet; }
                
                activeSheetIndex = sheet.Index;
            }
            else
            {

                sheet = wb.Application.Sheets[1] as Excel.Worksheet;
                activeSheetIndex = sheet.Index;
                activeSheetName = sheet.Name;
            }
            try
            {
                ea.ActiveSheet(activeSheetIndex);
            }
            catch { }
            unLockExcel(wb, sheet);
            if (lp.CtrlType.Contains("uc_gridcontrol")) { FillTable(ea, lp, (ctrl as uc_gridcontrol).GetContent(String2Int(lp.WordCount.Split(pchar)))); return; }
            else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
            {
                FillTime(ea, lp, (ctrl as DateEdit).DateTime);
                return;
            }
            string[] arrCellpos = lp.CellPos.Split(pchar);
            string[] arrtemp = lp.WordCount.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            arrtemp = StringHelper.ReplaceEmpty(arrtemp).Split(pchar);
            List<int> arrCellCount = String2Int(arrtemp);
            if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
            {
                try
                {
                    if (lp.isExplorer != 1) ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                }
                catch { }
                if (valuehs.ContainsKey(lp.LPID + "$" + lp.CellPos))
                {
                    WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + lp.CellPos] as WF_TableFieldValue;
                    tfv.ControlValue = str;
                    tfv.FieldId = lp.LPID;
                    tfv.FieldName = lp.CellName;
                    tfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    tfv.YExcelPos = GetCellPos(lp.CellPos)[1];

                }
                else
                {
                    WF_TableFieldValue tfv = new WF_TableFieldValue();
                    tfv.ControlValue = str;
                    tfv.FieldId = lp.LPID;
                    tfv.FieldName = lp.CellName;
                    tfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    tfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                    valuehs.Add(lp.LPID + "$" + lp.CellPos, tfv);
                }
            }
            else if (arrCellpos.Length > 1 && (!string.IsNullOrEmpty(arrCellpos[1])))
            {

                StringHelper help = new StringHelper();
                if (lp.CellName == "编号")
                {
                    for (int j = 0; j < arrCellpos.Length; j++)
                    {
                        if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[j]))
                        {
                            string strNew = str.Substring(0, (str.Length > 0 ? str.Length : 1) - 1) + (j + 1).ToString();
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[j]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[j]] as WF_TableFieldValue;
                                tfv.ControlValue = str;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[j])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[j])[1];
                                tfv.ExcelSheetName = sheet.Name;
                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = str;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[j])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[j])[1];
                                tfv.ExcelSheetName = sheet.Name;
                                valuehs.Add(lp.LPID + "$" + arrCellpos[j], tfv);
                            }
                        }
                    }
                    return;
                }
                int i = 0;
                if (arrCellCount[0] != arrCellCount[1])
                {
                    if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[0]))
                    {
                        try
                        {
                            if (lp.isExplorer != 1) ea.SetCellValue(str, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                        }
                        catch { }
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                            tfv.ExcelSheetName = sheet.Name;

                        }
                        else
                        {
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                            tfv.ExcelSheetName = sheet.Name;
                            valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                        }
                        return;
                    }
                    try
                    {
                        if (lp.isExplorer != 1) ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                            str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                            GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                    }
                    catch { }
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                        tfv.ControlValue = str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                        tfv.ExcelSheetName = sheet.Name;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                        tfv.ExcelSheetName = sheet.Name;
                        valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                    }

                    str = str.Substring(help.GetFristLen(str, arrCellCount[0]) >= str.IndexOf("\r\n") &&
                        str.IndexOf("\r\n") != -1 ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                    i++;
                }
                str = help.GetPlitString(str, arrCellCount[1]);
                FillMutilRows(ea, i, lp, str, arrCellCount, arrCellpos);

            }
            LockExcel(wb, sheet);
        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {


            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            if (lp == null) return;
            //string str = (sender as Control).Text;
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet xx=null;

            if (lp.KindTable != "")
            {
                activeSheetName = lp.KindTable;
                try {
                    xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                } catch {  }
                if (xx == null) return;
                activeSheetIndex = xx.Index;
            }
            else
            {

                xx = wb.Application.Sheets[1] as Excel.Worksheet;
                activeSheetIndex = xx.Index;
                activeSheetName = xx.Name;
            }

            unLockExcel(wb, xx);
            string[] arrCellpos = lp.CellPos.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            int i = e.FocusedColumn.VisibleIndex, j = Convert.ToInt32(e.FocusedColumn.Tag);
            if (i > arrCellpos.Length || i < 0) i = 0;
            if (j < 0) j = 0;
            if (arrCellpos.Length >= 1)
            {
                //ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                Excel.Range range;
                if (lp.ExtraWord == "横向")
                {
                    range = (Excel.Range)xx.get_Range(xx.Cells[GetCellPos(arrCellpos[i])[0],
                    GetCellPos(arrCellpos[i])[1] + j],
                    xx.Cells[GetCellPos(arrCellpos[i])[0], GetCellPos(arrCellpos[i])[1] + j]);
                }
                else
                {

                    range = (Excel.Range)xx.get_Range(xx.Cells[GetCellPos(arrCellpos[i])[0] + j,
                    GetCellPos(arrCellpos[i])[1]],
                    xx.Cells[GetCellPos(arrCellpos[i])[0] + j, GetCellPos(arrCellpos[i])[1]]);
                }
                range.Select();
                bool isfind = false;
                for (i = 1; i <= xx.Protection.AllowEditRanges.Count; i++)
                {
                    Excel.AllowEditRange editRange = xx.Protection.AllowEditRanges.get_Item(i);
                    if (editRange.Title == lp.CellPos.Replace("|", ""))
                    {
                        isfind = true;
                        break;
                    }
                }
                if (!isfind)
                {
                    try
                    {
                        xx.Protection.AllowEditRanges.Add(lp.CellPos.Replace("|", ""), range, Type.Missing);
                    }
                    catch { }
                }
            }
            LockExcel(wb, xx);
        }

        void ctrl_Enter(object sender, EventArgs e)
        {

            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet xx=null;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            try
            {
                if (lp.KindTable != "")
                {
                    activeSheetName = lp.KindTable;

                    try {
                        xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                    } catch {  }
                    if (xx == null) return;
                    activeSheetIndex = xx.Index;

                }
                else
                {

                    xx = wb.Application.Sheets[1] as Excel.Worksheet;
                    activeSheetIndex = xx.Index;
                    activeSheetName = xx.Name;
                }
                try
                {
                    ea.ActiveSheet(activeSheetIndex);
                }
                catch { }
                unLockExcel(wb, xx);
                if (lp.CellPos == "")
                {
                    if (lp.CellName.IndexOf("简图") > -1)
                    {

                        PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + str + "'");
                        if (tb != null)
                        {
                            if (tb.picName != "表箱")
                            {
                                string tempPath = Path.GetTempPath();
                                string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + tb.S1;
                                FileStream fs;
                                fs = new FileStream(tempfile, FileMode.Create, FileAccess.Write);
                                BinaryWriter bw = new BinaryWriter(fs);
                                bw.Write(tb.picImage);
                                bw.Flush();
                                bw.Close();
                                fs.Close();
                                //IDataObject data = new DataObject(DataFormats.FileDrop, new string[] { tempfile });
                                //MemoryStream memo = new MemoryStream(4);
                                //byte[] bytes = new byte[] { (byte)(5), 0, 0, 0 };
                                //memo.Write(bytes, 0, bytes.Length);
                                //data.SetData("ttt", memo);
                                //Clipboard.SetDataObject(data);
                                Image im = Bitmap.FromFile(tempfile);
                                Bitmap bt = new Bitmap(im);
                                DataObject dataObject = new DataObject();
                                dataObject.SetData(DataFormats.Bitmap, bt);
                                Clipboard.SetDataObject(dataObject, true);
                            }
                            else
                            {

                                Microsoft.Office.Interop.Excel.Shape activShape = null;
                                activShape = xx.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                                    (float)153.75, (float)162.75, (float)22.5, (float)10.5);
                                activShape.TextFrame.Characters(1, 1).Font.Size = 8;
                                activShape.TextFrame.Characters(1, 1).Text = "1";
                                activShape.TextFrame.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                activShape.Cut();
                            }
                        }
                    }
                    return;
                }
                string[] arrCellpos = lp.CellPos.Split(pchar);
                arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
                if (arrCellpos.Length >= 1)
                {
                    if (arrCellpos[0] == "") return;
                    //ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                    Excel.Range range = (Excel.Range)xx.get_Range(xx.Cells[GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]], xx.Cells[GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]]);
                    range.Select();
                    bool isfind = false;
                    for (int i = 1; i <= xx.Protection.AllowEditRanges.Count; i++)
                    {
                        Excel.AllowEditRange editRange = xx.Protection.AllowEditRanges.get_Item(i);
                        if (editRange.Title == lp.CellPos.Replace("|", ""))
                        {
                            isfind = true;
                            break;
                        }
                    }
                    if (!isfind)
                    {
                        try
                        {
                            xx.Protection.AllowEditRanges.Add(lp.CellPos.Replace("|", ""), range, Type.Missing);
                        }
                        catch { }
                    }
                }
                LockExcel(wb, xx);
            }
            catch { }
        }
        void ctrl_Leave(object sender, EventArgs e)
        {


            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            try
            {
                if (lp.KindTable != activeSheetName)
                {
                    if (lp.KindTable != "")
                    {
                        activeSheetName = lp.KindTable;
                        try {
                            sheet = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                        } catch { sheet = wb.Application.Sheets[1] as Excel.Worksheet; }
                
                        activeSheetIndex = sheet.Index;
                    } else {
                        sheet = wb.Application.Sheets[1] as Excel.Worksheet;
                        activeSheetIndex = sheet.Index;
                        activeSheetName = sheet.Name;
                    }
                }
                if (lp.KindTable != "")
                {
                    //try {
                    //    ea.ActiveSheet(lp.KindTable);
                    //} catch { }
                }
                else
                {
                    try
                    {
                        ea.ActiveSheet(1);
                    }
                    catch { }
                }

                if (lp.CellPos == "")
                {

                    if (lp.CellName.IndexOf("简图") > -1)
                    {
                        unLockExcel(wb, sheet);
                        PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + str + "'");
                        if (tb != null)
                        {
                            if (tb.picName != "表箱")
                            {
                                string tempPath = Path.GetTempPath();
                                string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + tb.S1;
                                FileStream fs;
                                fs = new FileStream(tempfile, FileMode.Create, FileAccess.Write);
                                BinaryWriter bw = new BinaryWriter(fs);
                                bw.Write(tb.picImage);
                                bw.Flush();
                                bw.Close();
                                fs.Close();
                                //IDataObject data = new DataObject(DataFormats.FileDrop, new string[] { tempfile });
                                //MemoryStream memo = new MemoryStream(4);
                                //byte[] bytes = new byte[] { (byte)(5), 0, 0, 0 };
                                //memo.Write(bytes, 0, bytes.Length);
                                //data.SetData("ttt", memo);
                                //Clipboard.SetDataObject(data);
                                Image im = Bitmap.FromFile(tempfile);
                                Bitmap bt = new Bitmap(im);
                                DataObject dataObject = new DataObject();
                                dataObject.SetData(DataFormats.Bitmap, bt);
                                Clipboard.SetDataObject(dataObject, true);
                            }
                            else
                            {
                                Microsoft.Office.Interop.Excel.Shape activShape = null;
                                activShape = sheet.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                                    (float)153.75, (float)162.75, (float)22.5, (float)10.5);
                                activShape.TextFrame.Characters(1, 1).Font.Size = 8;
                                activShape.TextFrame.Characters(1, 1).Text = "1";
                                activShape.TextFrame.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                activShape.Cut();
                            }
                        }
                    }
                    else
                    {
                        if (valuehs.ContainsKey(lp.LPID))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID] as WF_TableFieldValue;
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = -1;
                            tfv.YExcelPos = -1;

                        }
                        else
                        {
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = -1;
                            tfv.YExcelPos = -1;
                            tfv.ExcelSheetName = sheet.Name;

                            valuehs.Add(lp.LPID, tfv);
                        }

                    }
                    return;
                }

                unLockExcel(wb, sheet);
                string[] arrCellpos = lp.CellPos.Split(pchar);
                string[] arrtemp = lp.WordCount.Split(pchar);
                arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
                if (lp.CtrlType.Contains("uc_gridcontrol") == false)
                {
                    for (int i = 0; i < arrCellpos.Length; i++)
                    {
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[i]))
                        {
                            valuehs.Remove(lp.LPID + "$" + arrCellpos[i]);
                        }
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[i] + "完整时间"))
                        {
                            valuehs.Remove(lp.LPID + "$" + arrCellpos[i] + "完整时间");
                        }
                        try
                        {
                            if (lp.isExplorer != 1)
                            {
                                //ea.SetCellValue("", GetCellPos(arrCellpos[i])[0], GetCellPos(arrCellpos[i])[1]);
                            }
                        }
                        catch { }
                    }



                }
                if (lp.CtrlType.Contains("uc_gridcontrol"))
                {
                    FillTable(ea, lp, (sender as uc_gridcontrol).GetContent(String2Int(lp.WordCount.Split(pchar))));
                    LockExcel(wb, sheet);
                    return;
                }
                else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
                {
                    FillTime(ea, lp, (sender as DateEdit).DateTime);
                    LockExcel(wb, sheet);
                    return;
                }
                else if (lp.CtrlType.Contains("DevExpress.XtraEditors.SpinEdit"))
                {

                    IList<string> strList = new List<string>();
                    if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
                    {
                        try
                        {
                            if (lp.isExplorer != 1) ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                        }
                        catch { }
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                            tfv.ExcelSheetName = sheet.Name;

                        }
                        else
                        {
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                            tfv.ExcelSheetName = sheet.Name;
                            valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                        }
                    }
                    else if (arrCellpos.Length > 1 && (!string.IsNullOrEmpty(arrCellpos[1])))
                    {
                        int i = 0;
                        try
                        {
                            if (lp.isExplorer != 1) ea.SetCellValue(str, GetCellPos(arrCellpos[i])[0], GetCellPos(arrCellpos[i])[1]);
                        }
                        catch { }
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[i]))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[i]] as WF_TableFieldValue;
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[i])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[i])[1];
                            tfv.ExcelSheetName = sheet.Name;

                        }
                        else
                        {
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[i])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[i])[1];
                            tfv.ExcelSheetName = sheet.Name;
                            valuehs.Add(lp.LPID + "$" + arrCellpos[i], tfv);
                        }
                    }
                    LockExcel(wb, sheet);

                    return;
                }

                string[] extraWord = lp.ExtraWord.Split(pchar);
                List<int> arrCellCount = String2Int(arrtemp);
                string value = lp.ExtraWord;
                if (lp.ExtraWord == "合同编号")
                {
                    for (int j = 0; j < arrCellpos.Length; j++)
                    {
                        if (str.Length > j)
                        {
                            string strNew = str.Substring(j, 1);
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);

                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                                tfv.ControlValue = strNew;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = strNew;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;
                                valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                            }

                        }
                        else
                            break;

                    }
                    LockExcel(wb, sheet);
                    return;
                }
                else
                    if (lp.ExtraWord != "")
                    {
                        str = value.Replace("{0}", str);

                    }
                if (lp.CellName == "工作班人员" || lp.CellName == "抢修班人员" || lp.CellName == "工作班成员")
                {
                    LP_Temple lpt = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where CellName='人数' and ParentID='" + parentTemple.LPID + "'");
                    Control relateCtrl = FindCtrl(lp.LPID);
                    Control resCtrl = FindCtrl(lpt.LPID);
                    if (relateCtrl != null)
                    {
                        string[] strcount = SelectorHelper.ToDBC(relateCtrl.Text).Split('、');
                        int irencount = 0;
                        for (int iren = 0; iren < strcount.Length; iren++)
                        {
                            if (strcount[iren] != "") irencount++;
                        }
                        if (irencount != 0)
                        {
                            resCtrl.Text = irencount.ToString();
                        }
                    }
                }
                if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
                {
                    try
                    {
                        if (lp.isExplorer != 1)
                        {
                            int[] cc = GetCellPos(arrCellpos[0]);
                            ea.SetCellValue("'" + str, cc[0], cc[1]);
                        }
                    }
                    catch { }
                    if (valuehs.ContainsKey(lp.LPID + "$" + lp.CellPos))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + lp.CellPos] as WF_TableFieldValue;
                        tfv.ControlValue = str;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                        tfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                        tfv.ExcelSheetName = sheet.Name;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = str;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                        tfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                        tfv.ExcelSheetName = sheet.Name;
                        valuehs.Add(lp.LPID + "$" + lp.CellPos, tfv);
                    }

                }
                else if (arrCellpos.Length > 1 && (!string.IsNullOrEmpty(arrCellpos[1])))
                {
                    StringHelper help = new StringHelper();
                    if (lp.CellName == "编号")
                    {
                        for (int j = 0; j < arrCellpos.Length; j++)
                        {
                            if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[j]) && str != "")
                            {
                                //string strNew = str.Substring(0, str.Length - 1) + (j + 1).ToString();
                                string strNew = str;
                                try
                                {
                                    if (lp.isExplorer != 1) ea.SetCellValue("'" + strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);
                                }
                                catch { }

                                if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[j]))
                                {
                                    WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[j]] as WF_TableFieldValue;
                                    tfv.ControlValue = strNew;
                                    tfv.FieldId = lp.LPID;
                                    tfv.FieldName = lp.CellName;
                                    tfv.XExcelPos = GetCellPos(arrCellpos[j])[0];
                                    tfv.YExcelPos = GetCellPos(arrCellpos[j])[1];
                                    tfv.ExcelSheetName = sheet.Name;

                                }
                                else
                                {
                                    WF_TableFieldValue tfv = new WF_TableFieldValue();
                                    tfv.ControlValue = strNew;
                                    tfv.FieldId = lp.LPID;
                                    tfv.FieldName = lp.CellName;
                                    tfv.XExcelPos = GetCellPos(arrCellpos[j])[0];
                                    tfv.YExcelPos = GetCellPos(arrCellpos[j])[1];
                                    tfv.ExcelSheetName = sheet.Name;
                                    valuehs.Add(lp.LPID + "$" + arrCellpos[j], tfv);
                                }
                            }
                        }
                        LockExcel(wb, sheet);
                        return;
                    }
                    int i = 0;
                    //if (arrCellCount.Count>1&&arrCellCount[0] != arrCellCount[1])
                    if (arrCellCount.Count > 1)
                    {
                        if ((lp.CtrlType.IndexOf("uc_gridcontrol") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[i])) || (lp.CtrlType.IndexOf("uc_gridcontrol") > -1 && str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[i])))
                        {
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue(str, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                                tfv.ControlValue = str;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = str;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;
                                valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                            }

                            LockExcel(wb, sheet);
                            return;
                        }

                        if (lp.CtrlType.IndexOf("uc_gridcontrol") > -1)
                        {
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                                    str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                                    GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                                tfv.ControlValue = (str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                                str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])));
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = (str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                                str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])));
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;
                                valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                            }
                            str = str.Substring(help.GetFristLen(str, arrCellCount[0]) >= str.IndexOf("\r\n") &&
                                str.IndexOf("\r\n") != -1 ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                            i++;

                            str = help.GetPlitString(str, arrCellCount[1]);
                        }
                        else
                        {
                            int i1 = str.IndexOf("\r\n");
                            if (i1 > help.GetFristLen(str, arrCellCount[0]))
                                i1 = help.GetFristLen(str, arrCellCount[0]);
                            if (i1 == -1)
                                i1 = help.GetFristLen(str, arrCellCount[0]);
                            if (str.Length > i1 + 1 && (str.Substring(i1, 1) == "，" || str.Substring(i1, 1) == "。" || str.Substring(i1 + 1, 1) == "、" || str.Substring(i1 + 1, 1) == "：" || str.Substring(i1 + 1, 1) == "！"))
                            {
                                i1 = i1 + 1;
                            }
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue(str.Substring(0, i1), GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                                tfv.ControlValue = str.Substring(0, i1);
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = str.Substring(0, i1);
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                                tfv.ExcelSheetName = sheet.Name;
                                valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                            }
                            str = str.Substring(i1);
                            i++;
                            //str = help.GetPlitString(str, arrCellCount[1]);
                        }
                        FillMutilRows(ea, i, lp, str, arrCellCount, arrCellpos);
                    }

                }
                if (lp.CellName == "单位")
                {
                    IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgCode  from mOrg where OrgName='" + str + "'");
                    if (list.Count > 0)
                    {

                        switch (parentTemple.CellName)
                        {

                            case "电力线路第一种工作票":
                            case "yzgzp":
                                //strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                if (bhht[str] != null)
                                {
                                    strNumber = "07" + bhht[str].ToString();

                                }
                                else
                                    strNumber = "07";
                                break;
                            case "电力线路第二种工作票":
                            case "ezgzp":
                                //strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                break;
                            case "电力线路倒闸操作票":
                            case "dzczp":
                                //strNumber = "BJ" + System.DateTime.Now.Year.ToString();
                                strNumber = "06" + list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                break;
                            case "电力线路事故应急抢修单":
                            case "xlqxp":
                                //strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                break;

                            case "低压线路第一种工作票":
                                if (bhht[str] != null)
                                {
                                    strNumber = "11" + bhht[str].ToString();
                                }
                                else
                                    strNumber = "11";
                                break;
                            case "低压线路第二种工作票":
                                strNumber = "12" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                break;

                            default:
                                strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                break;
                        }

                        //IList<LP_Record> listLPRecord = ClientHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", " where kind = '" + kind + "' and number like '" + strNumber + "%'");
                        IList listLPRecord = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select ControlValue from WF_TableFieldValue where  FieldName='编号' and UserControlId='{0}' and WorkFlowInsId!='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' and ControlValue like '" + strNumber + "%' and id like '" + DateTime.Now.Year + "%' order by id desc", parentTemple.LPID));
                        if (kind == "yzgzp" || parentTemple.CellName == "电力线路第一种工作票")
                        {
                            //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                            if (listLPRecord.Count == 0)
                                strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                            else
                            {
                                decimal udw = Convert.ToDecimal(listLPRecord[0]);
                                strNumber = "0" + (udw + 1).ToString().PadLeft(3, '0');
                            }
                        }
                        else
                        {
                            int step = 1;
                            if (ctrlNumber2 != null) step = 2;
                            if (listLPRecord.Count == 0)
                                strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                            else
                            {
                                decimal udw = Convert.ToDecimal(listLPRecord[0].ToString().Substring(listLPRecord[0].ToString().Length - 3));
                                strNumber = listLPRecord[0].ToString().Substring(0, listLPRecord[0].ToString().Length - 3) + (udw + step).ToString().PadLeft(3, '0');
                            }
                            if (ctrlNumber2 != null)
                            {
                                ctrlNumber2.Text = strNumber.Substring(0, strNumber.Length - 3) + (int.Parse(strNumber.Substring(strNumber.Length - 3)) + 1).ToString("000");
                            }
                            //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                        }
                        if (ctrlNumber != null)
                        {
                            ctrlNumber.Text = strNumber;
                            currRecord.Number = ctrlNumber.Text;
                        }
                        if (currRecord != null) currRecord.OrgName = str;
                        //ContentChanged(ctrlNumber);
                    }

                }
                LockExcel(wb, sheet);
            }
            catch { }
        }

        public void FillTable(ExcelAccess ea, LP_Temple lp, string[] content)
        {
            string[] arrCol = lp.CellPos.Split(pchar);
            arrCol = StringHelper.ReplaceEmpty(arrCol).Split(pchar);
            string[] arrtemp = lp.WordCount.Split(pchar);
            arrtemp = StringHelper.ReplaceEmpty(arrtemp).Split(pchar);
            string[] coltemp = lp.ColumnName.Split(pchar);
            arrtemp = StringHelper.ReplaceEmpty(arrtemp).Split(pchar);
            List<int> arrCellCount = String2Int(arrtemp);
            for (int i = 0; i < arrCol.Length; i++)
            {
                if (string.IsNullOrEmpty(arrCol[i]))
                {
                    continue;
                }
                if (content.Length > i && content[i] != null)
                    FillMutilRowsT(ea, lp, content[i], arrCellCount[i], arrCol[i], coltemp[i]);
            }
        }

        public void FillMutilRows(ExcelAccess ea, int i, LP_Temple lp, string str, List<int> arrCellCount, string[] arrCellPos)
        {
            StringHelper help = new StringHelper();

            string[] extraWord = lp.ExtraWord.Split(pchar);
            if (lp.CtrlType.IndexOf("uc_gridcontrol") > -1)
            {
                str = help.GetPlitString(str, arrCellCount[1]);
                string[] arrRst = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int j = 0;
                for (; i < arrCellPos.Length; i++)
                {
                    if (j >= arrRst.Length)
                        break;
                    try
                    {
                        if (lp.isExplorer != 1) ea.SetCellValue(arrRst[j], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                    }
                    catch { }
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                        tfv.ControlValue = arrRst[j];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                        tfv.ExcelSheetName = activeSheetName;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = arrRst[j];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                        tfv.ExcelSheetName = activeSheetName;
                        valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                    }
                    j++;
                }
            }
            else
            {
                string strarrRst = str;
                int i1 = strarrRst.IndexOf("\r\n");

                for (; i < arrCellPos.Length; i++)
                {
                    i1 = strarrRst.IndexOf("\r\n");
                    if (i1 > help.GetFristLen(strarrRst, arrCellCount[i]))
                        i1 = help.GetFristLen(strarrRst, arrCellCount[i]);
                    if (i1 == 0)
                    {
                        strarrRst = strarrRst.Substring(2);
                        i1 = strarrRst.IndexOf("\r\n");
                        if (i1 > help.GetFristLen(strarrRst, arrCellCount[i]))
                            i1 = help.GetFristLen(strarrRst, arrCellCount[i]);
                    }
                    if (i1 == -1)
                        i1 = help.GetFristLen(str, arrCellCount[i]);
                    if (strarrRst.Length > i1 + 1 && (strarrRst.Substring(i1, 1) == "，" || strarrRst.Substring(i1, 1) == "。" || strarrRst.Substring(i1 + 1, 1) == "、" || strarrRst.Substring(i1 + 1, 1) == "：" || strarrRst.Substring(i1 + 1, 1) == "！"))
                    {
                        i1 = i1 + 1;
                    }
                    //if (strarrRst.Length <= help.GetFristLen(str, arrCellCount[i]))
                    //{
                    //    try
                    //    {
                    //        if (lp.isExplorer != 1) ea.SetCellValue(strarrRst, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                    //    }
                    //    catch { }
                    //    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                    //    {
                    //        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                    //        tfv.ControlValue = strarrRst;
                    //        tfv.FieldId = lp.LPID;
                    //        tfv.FieldName = lp.CellName;
                    //        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                    //        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                    //        tfv.ExcelSheetName = activeSheetName;

                    //    }
                    //    else
                    //    {
                    //        WF_TableFieldValue tfv = new WF_TableFieldValue();
                    //        tfv.ControlValue = strarrRst;
                    //        tfv.FieldId = lp.LPID;
                    //        tfv.FieldName = lp.CellName;
                    //        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                    //        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                    //        tfv.ExcelSheetName = activeSheetName;
                    //        valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                    //    }
                    //    break;
                    //}
                    //else
                    {
                        if (strarrRst.Length >= i1)
                        {
                            try
                            {
                                if (lp.isExplorer != 1) if (lp.isExplorer != 1) ea.SetCellValue(strarrRst.Substring(0, i1), GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                                tfv.ControlValue = strarrRst.Substring(0, i1);
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                                tfv.ExcelSheetName = activeSheetName;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = strarrRst.Substring(0, i1);
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                                tfv.ExcelSheetName = activeSheetName;
                                valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                            }
                            strarrRst = strarrRst.Substring(i1);
                        }
                        else
                        {
                            try
                            {
                                if (lp.isExplorer != 1) if (lp.isExplorer != 1) ea.SetCellValue(strarrRst, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                                tfv.ControlValue = strarrRst;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                                tfv.ExcelSheetName = activeSheetName;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = strarrRst;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                                tfv.ExcelSheetName = activeSheetName;
                                valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                            }
                            strarrRst = "";
                        }
                        //i++;
                        //strarrRst = help.GetPlitString(strarrRst, arrCellCount[i]);
                    }


                }
            }
        }

        public void FillTime(ExcelAccess ea, LP_Temple lp, DateTime dt)
        {
            string[] arrCellPos = lp.CellPos.Split(pchar);
            arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split(pchar);
            string[] extraWord = lp.ExtraWord.Split(pchar);
            IList<string> strList = new List<string>();
            //if (arrCellPos.Length == 5)
            //{
            //    strList.Add(dt.Year.ToString()); strList.Add(dt.Month.ToString());
            //    strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            //}
            //else if (arrCellPos.Length == 4)
            //{
            //    strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            //}
            //else if (arrCellPos.Length == 3)
            //{
            //    // strList.Add(dt.Year.ToString()); strList.Add(dt.Month.ToString());
            //    //strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            //    strList.Add(dt.Year.ToString());
            //    strList.Add(dt.Month.ToString());
            //    strList.Add(dt.Day.ToString());
            //}
            //else if (arrCellPos.Length == 2)
            //{
            //    strList.Add(dt.Hour.ToString());
            //    strList.Add(dt.Minute.ToString());
            //}
            //else if (arrCellPos.Length == 1)
            //{
            //    strList.Add(dt.ToString());
            //}
            switch (lp.WordCount)
            {
                case "yyyy-MM-dd":

                    strList.Add(dt.Year.ToString());
                    strList.Add(string.Format("{0:D2}", dt.Month));
                    strList.Add(string.Format("{0:D2}", dt.Day));
                    break;
                case "yyyy-MM-dd HH:mm:ss":
                    strList.Add(dt.Year.ToString());
                    strList.Add(string.Format("{0:D2}", dt.Month));
                    strList.Add(string.Format("{0:D2}", dt.Day));
                    strList.Add(string.Format("{0:D2}", dt.Hour));
                    strList.Add(string.Format("{0:D2}", dt.Minute));
                    strList.Add(string.Format("{0:D2}", dt.Second));
                    break;
                case "HH:mm:ss":
                    strList.Add(dt.Hour.ToString());
                    strList.Add(string.Format("{0:D2}", dt.Minute));
                    strList.Add(string.Format("{0:D2}", dt.Second));
                    break;
                case "MM-dd日 HH:mm":
                    strList.Add(string.Format("{0:D2}", dt.Month));
                    strList.Add(string.Format("{0:D2}", dt.Day));
                    strList.Add(string.Format("{0:D2}", dt.Hour));
                    strList.Add(string.Format("{0:D2}", dt.Minute));
                    break;
                case "dd日 HH:mm":
                    strList.Add(string.Format("{0:D2}", dt.Day));
                    strList.Add(string.Format("{0:D2}", dt.Hour));
                    strList.Add(string.Format("{0:D2}", dt.Minute));
                    break;
                case "HH:mm":
                    strList.Add(string.Format("{0:D2}", dt.Hour));
                    strList.Add(string.Format("{0:D2}", dt.Minute));
                    break;
                default:
                    if (lp.WordCount.IndexOf("yyyy") > -1)
                    {
                        if (lp.WordCount.IndexOf("yyyy年") > -1)
                            strList.Add(dt.Year.ToString() + "年");
                        else
                            strList.Add(dt.Year.ToString());

                    }
                    if (lp.WordCount.IndexOf("MM") > -1)
                    {
                        if (lp.WordCount.IndexOf("MM月") > -1)
                            strList.Add(string.Format("{0:D2}", dt.Month) + "月");
                        else
                            strList.Add(string.Format("{0:D2}", dt.Month));
                    }
                    if (lp.WordCount.IndexOf("dd") > -1)
                    {
                        if (lp.WordCount.IndexOf("dd日") > -1)
                            strList.Add(string.Format("{0:D2}", dt.Day) + "日");
                        else
                            strList.Add(string.Format("{0:D2}", dt.Day));
                    }
                    if (lp.WordCount.IndexOf("HH") > -1)
                    {
                        if (lp.WordCount.IndexOf("HH时") > -1)
                            strList.Add(string.Format("{0:D2}", dt.Hour) + "时");
                        else
                            strList.Add(string.Format("{0:D2}", dt.Hour));
                    }
                    if (lp.WordCount.IndexOf("mm") > -1)
                    {
                        if (lp.WordCount.IndexOf("mm分") > -1)
                            strList.Add(string.Format("{0:D2}", dt.Minute) + "分");
                        else
                            strList.Add(string.Format("{0:D2}", dt.Minute));
                    }
                    if (lp.WordCount.IndexOf("ss") > -1)
                    {
                        if (lp.WordCount.IndexOf("ss秒") > -1)
                            strList.Add(string.Format("{0:D2}", dt.Second) + "秒");
                        else
                            strList.Add(string.Format("{0:D2}", dt.Second));
                    }
                    break;
            }
            // int i = 0;
            string value = lp.ExtraWord;
            for (int i = 0; i < strList.Count; i++)
            {
                //if (extraWord.Length > i)
                //{
                //    ea.SetCellValue(strList[i] + extraWord[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                //    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                //    {
                //        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                //        tfv.ControlValue = strList[i] + extraWord[i];
                //        tfv.FieldId = lp.LPID;
                //        tfv.FieldName = lp.CellName;
                //        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                //        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                //        tfv.ExcelSheetName = activeSheetName;

                //    }
                //    else
                //    {
                //        WF_TableFieldValue tfv = new WF_TableFieldValue();
                //        tfv.ControlValue = strList[i] + extraWord[i];
                //        tfv.FieldId = lp.LPID;
                //        tfv.FieldName = lp.CellName;
                //        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                //        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                //        tfv.ExcelSheetName = activeSheetName;
                //        valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                //    }
                //}
                //else
                //{
                //    ea.SetCellValue(strList[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                //    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                //    {
                //        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                //        tfv.ControlValue = strList[i];
                //        tfv.FieldId = lp.LPID;
                //        tfv.FieldName = lp.CellName;
                //        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                //        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                //        tfv.ExcelSheetName = activeSheetName;

                //    }
                //    else
                //    {
                //        WF_TableFieldValue tfv = new WF_TableFieldValue();
                //        tfv.ControlValue = strList[i];
                //        tfv.FieldId = lp.LPID;
                //        tfv.FieldName = lp.CellName;
                //        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                //        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                //        tfv.ExcelSheetName = activeSheetName;
                //        valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                //    }
                //}
                if (lp.ExtraWord == "")
                {
                    if (arrCellPos.Length > 1)
                    {
                        if (dt.ToString("yyyyMMdd") == "00010101")
                        {
                            strList[i] = " ";
                        }
                        try
                        {
                            if (lp.isExplorer != 1) ea.SetCellValue("'" + strList[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                        }
                        catch { }

                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                            tfv.ControlValue = strList[i];
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                            tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                            tfv.ExcelSheetName = activeSheetName;

                            tfv = valuehs[lp.LPID + "$" + arrCellPos[i] + "时间"] as WF_TableFieldValue;
                            if (tfv != null)
                            {
                                tfv.ControlValue = dt.ToString();
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName + "完整时间";
                                tfv.XExcelPos = -1;
                                tfv.YExcelPos = -1;
                                tfv.ExcelSheetName = activeSheetName;
                            }
                        }
                        else
                        {
                            if (dt.ToString("yyyyMMdd") == "00010101")
                            {
                                strList[i] = " ";
                            }
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = strList[i];
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                            tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                            tfv.ExcelSheetName = activeSheetName;
                            valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);

                            tfv = new WF_TableFieldValue();
                            tfv.FieldId = lp.LPID;
                            tfv.ControlValue = dt.ToString();
                            tfv.FieldName = lp.CellName + "完整时间";
                            tfv.XExcelPos = -1;
                            tfv.YExcelPos = -1;
                            tfv.ExcelSheetName = activeSheetName;
                            valuehs.Add(lp.LPID + "$" + arrCellPos[i] + "完整时间", tfv);


                        }
                    }
                    else
                    {
                        if (dt.ToString("yyyyMMdd") == "00010101")
                        {
                            //for (int item = 0; i < strList.Count; i++)
                            if (strList[i].IndexOf("年") > -1) strList[i] = "年";
                            else
                                if (strList[i].IndexOf("月") > -1) strList[i] = "      月";
                                else
                                    if (strList[i].IndexOf("日") > -1) strList[i] = "      日";
                                    else
                                        if (strList[i].IndexOf("时") > -1) strList[i] = "      时";
                                        else
                                            if (strList[i].IndexOf("分") > -1) strList[i] = "      分";
                        }
                        value += strList[i];
                        if (strList.Count == i + 1)
                        {
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue("'" + value, GetCellPos(arrCellPos[0])[0], GetCellPos(arrCellPos[0])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[0]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[0]] as WF_TableFieldValue;
                                tfv.ControlValue = value;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                                tfv.ExcelSheetName = activeSheetName;

                                tfv = valuehs[lp.LPID + "$" + arrCellPos[0] + "时间"] as WF_TableFieldValue;
                                if (tfv != null)
                                {
                                    tfv.ControlValue = dt.ToString();
                                    tfv.FieldId = lp.LPID;
                                    tfv.FieldName = lp.CellName + "完整时间";
                                    tfv.XExcelPos = -1;
                                    tfv.YExcelPos = -1;
                                    tfv.ExcelSheetName = activeSheetName;
                                }

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = value;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                                tfv.ExcelSheetName = activeSheetName;
                                valuehs.Add(lp.LPID + "$" + arrCellPos[0], tfv);

                                tfv = new WF_TableFieldValue();
                                tfv.FieldId = lp.LPID;
                                tfv.ControlValue = dt.ToString();
                                tfv.FieldName = lp.CellName + "完整时间";
                                tfv.XExcelPos = -1;
                                tfv.YExcelPos = -1;
                                tfv.ExcelSheetName = activeSheetName;
                                valuehs.Add(lp.LPID + "$" + arrCellPos[0] + "完整时间", tfv);
                            }
                        }
                    }
                }
                else
                {
                    if (dt.ToString("yyyyMMdd") == "00010101")
                    {
                        strList[i] = " ";
                    }
                    if (lp.ExtraWord.IndexOf("|") == -1)
                    {
                        value = value.Replace("{" + i + "}", strList[i]);
                        if (i == strList.Count - 1)
                        {
                            try
                            {
                                if (lp.isExplorer != 1) ea.SetCellValue("'" + value, GetCellPos(arrCellPos[0])[0], GetCellPos(arrCellPos[0])[1]);
                            }
                            catch { }
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[0]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[0]] as WF_TableFieldValue;
                                tfv.ControlValue = value;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                                tfv.ExcelSheetName = activeSheetName;

                                tfv = valuehs[lp.LPID + "$" + arrCellPos[0] + "时间"] as WF_TableFieldValue;
                                if (tfv != null)
                                {
                                    tfv.ControlValue = dt.ToString();
                                    tfv.FieldId = lp.LPID;
                                    tfv.FieldName = lp.CellName + "完整时间";
                                    tfv.XExcelPos = -1;
                                    tfv.YExcelPos = -1;
                                    tfv.ExcelSheetName = activeSheetName;
                                }
                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = value;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                                tfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                                tfv.ExcelSheetName = activeSheetName;
                                valuehs.Add(lp.LPID + "$" + arrCellPos[0], tfv);

                                tfv = new WF_TableFieldValue();
                                tfv.FieldId = lp.LPID;
                                tfv.ControlValue = dt.ToString();
                                tfv.FieldName = lp.CellName + "完整时间";
                                tfv.XExcelPos = -1;
                                tfv.YExcelPos = -1;
                                tfv.ExcelSheetName = activeSheetName;
                                valuehs.Add(lp.LPID + "$" + arrCellPos[0] + "完整时间", tfv);

                            }
                        }

                    }
                    else
                    {
                        if (dt.ToString("yyyyMMdd") == "00010101")
                        {
                            strList[i] = " ";
                        }
                        string[] strextrlist = lp.ExtraWord.Split('|');
                        value = strList[i];
                        if (strextrlist.Length > i)
                            value += strextrlist[i];
                        try
                        {
                            if (lp.isExplorer != 1) ea.SetCellValue("'" + value, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                        }
                        catch { }
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[0]))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[0]] as WF_TableFieldValue;
                            tfv.ControlValue = value;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                            tfv.ExcelSheetName = activeSheetName;

                            tfv = valuehs[lp.LPID + "$" + arrCellPos[0] + "时间"] as WF_TableFieldValue;
                            if (tfv != null)
                            {
                                tfv.ControlValue = dt.ToString();
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName + "完整时间";
                                tfv.XExcelPos = -1;
                                tfv.YExcelPos = -1;
                                tfv.ExcelSheetName = activeSheetName;
                            }
                        }
                        else
                        {
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = value;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                            tfv.ExcelSheetName = activeSheetName;
                            valuehs.Add(lp.LPID + "$" + arrCellPos[0], tfv);

                            tfv = new WF_TableFieldValue();
                            tfv.FieldId = lp.LPID;
                            tfv.ControlValue = dt.ToString();
                            tfv.FieldName = lp.CellName + "完整时间";
                            tfv.XExcelPos = -1;
                            tfv.YExcelPos = -1;
                            tfv.ExcelSheetName = activeSheetName;
                            valuehs.Add(lp.LPID + "$" + arrCellPos[0] + "完整时间", tfv);
                        }
                    }
                    //ea.SetCellValue(strList[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);

                }

            }
            //foreach (string str in strList)
            //{
            //    ea.SetCellValue(str, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
            //    i++;
            //}
        }

        public void FillMutilRowsT(ExcelAccess ea, LP_Temple lp, string str, int cellcount, string arrCellPos, string coltemp)
        {
            StringHelper help = new StringHelper();
            //str = help.GetPlitString(str, cellcount);
            string[] arrRst = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (lp.ExtraWord == "横向")
            {
                for (int i = 0; i < arrRst.Length; i++)
                {
                    try
                    {
                        if (lp.isExplorer != 1) ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0], GetCellPos(arrCellPos)[1] + i);
                    }
                    catch { }
                    if (valuehs.ContainsKey(lp.LPID + "$" + Convert.ToString(GetCellPos(arrCellPos)[0] + i) + "|" + GetCellPos(arrCellPos)[1]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + Convert.ToString(GetCellPos(arrCellPos)[0] + i) + "|" + GetCellPos(arrCellPos)[1]] as WF_TableFieldValue;
                        tfv.ControlValue = arrRst[i];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName + "-" + coltemp;
                        tfv.XExcelPos = GetCellPos(arrCellPos)[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos)[1] + i;
                        tfv.ExcelSheetName = activeSheetName;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = arrRst[i];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName + "-" + coltemp;
                        tfv.XExcelPos = GetCellPos(arrCellPos)[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos)[1] + i;
                        tfv.ExcelSheetName = activeSheetName;
                        valuehs.Add(lp.LPID + "$" + Convert.ToString(GetCellPos(arrCellPos)[0] + i) + "|" + GetCellPos(arrCellPos)[1], tfv);
                    }
                }
            }
            else
            {
                for (int i = 0; i < arrRst.Length; i++)
                {
                    try
                    {
                        if (lp.isExplorer != 1) ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0] + i, GetCellPos(arrCellPos)[1]);
                    }
                    catch { }
                    if (valuehs.ContainsKey(lp.LPID + "$" + Convert.ToString(GetCellPos(arrCellPos)[0] + i) + "|" + GetCellPos(arrCellPos)[1]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + Convert.ToString(GetCellPos(arrCellPos)[0] + i) + "|" + GetCellPos(arrCellPos)[1]] as WF_TableFieldValue;
                        tfv.ControlValue = arrRst[i];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName + "-" + coltemp;
                        tfv.XExcelPos = GetCellPos(arrCellPos)[0] + i;
                        tfv.YExcelPos = GetCellPos(arrCellPos)[1];
                        tfv.ExcelSheetName = activeSheetName;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = arrRst[i];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName + "-" + coltemp;
                        tfv.XExcelPos = GetCellPos(arrCellPos)[0] + i;
                        tfv.YExcelPos = GetCellPos(arrCellPos)[1];
                        tfv.ExcelSheetName = activeSheetName;
                        valuehs.Add(lp.LPID + "$" + Convert.ToString(GetCellPos(arrCellPos)[0] + i) + "|" + GetCellPos(arrCellPos)[1], tfv);
                    }
                }
            }
        }

        public int[] GetCellPos(string cellpos)
        {

            cellpos = cellpos.Replace("|", "");
            Regex r1 = new Regex(@"[0-9]+");
            if (cellpos == "") return new int[] { 0, 0 };
            string str = r1.Match(cellpos).Value;
            int ix = 0;
            int iy = 0;
            ix = int.Parse(str);
            r1 = new Regex(@"[A-Z]+");
            str = r1.Match(cellpos).Value;
            if (str.Length == 2)
            {
                iy = ((int)str[0] - 64) * 26 + ((int)str[1] - 64);
            }
            else
            {
                iy = (int)cellpos[0] - 64;
            }
            return new int[] { ix, iy };
        }

        public List<int> String2Int(string[] temp)
        {
            List<int> arrRst = new List<int>();
            for (int i = 0; i < temp.Length; i++)
            {
                if (string.IsNullOrEmpty(temp[i]))
                {
                    temp[i] = "0";
                }
                arrRst.Add(int.Parse(temp[i]));
            }
            return arrRst;
        }


        public void InitCtrlData(Control ctrl, string sqlSentence)
        {
            tempCtrlList.Add(ctrl);
            LP_Temple lp = (LP_Temple)ctrl.Tag;
            bool flag = (lp.Status == CurrRecord.Status);
            string ctrltype = "";
            if (lp.CtrlType.IndexOf("uc_gridcontrol") > -1)
            {
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {

                            if (ct is DateEdit)
                            {
                                ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                                ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                            }
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            IList li2 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li2.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li2[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }
                }
                ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence, lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar), dsoFramerWordControl1, lp, currRecord);
                return;
            }
            if (lp.CtrlType.IndexOf(',') == -1)
                ctrltype = lp.CtrlType;
            else
                ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            if (sqlSentence.IndexOf("Excel:") == 0)
            {
                int index1 = sqlSentence.LastIndexOf(":");
                string tablename = sqlSentence.Substring(6, index1 - 6);
                string cellpos = sqlSentence.Substring(index1 + 1);
                string[] arrCellPos = cellpos.Split('|');
                arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                string strcellvalue = "";
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                Excel.Worksheet sheet;
                sheet = wb.Application.Sheets[tablename] as Excel.Worksheet;

                for (int i = 0; i < arrCellPos.Length; i++)
                {
                    Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                    strcellvalue += range.Value2;
                }
                li.Add(strcellvalue);
            }
            else if (sqlSentence != "")
            {
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            if (ct is DateEdit)
                            {
                                ((DateEdit)ct).Properties.EditMask = listLPID[0].WordCount;
                                ((DateEdit)ct).Properties.DisplayFormat.FormatString = listLPID[0].WordCount;
                            }
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }

                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }



                }
                r1 = new Regex(@"(?<={编号规则一:)[0-9]+(?=})");
                if (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("SelectmOrgList",
                                "where OrgName='" + ct.Text + "'");
                            if (list.Count > 0)
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", RecordWorkTask.CreatWorkFolwNo(list[0], listLPID[0].ParentID, "编号规则一"));
                            else
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "");

                        }
                        else
                        {
                            sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                    }

                }
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", " ");
                    li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                    if (sqlSentence.IndexOf("where 9=9") > -1)
                    {
                        string strtemp = li[0].ToString();
                        li.Clear();
                        r1 = new Regex(@"[0-9]+\+[0-9]+");
                        if (r1.Match(strtemp).Value != "")
                        {
                            int istart = 1;
                            int ilen = 10;
                            r1 = new Regex(@"[0-9]+(?=\+)");
                            if (r1.Match(strtemp).Value != "")
                            {
                                istart = Convert.ToInt32(r1.Match(strtemp).Value);
                            }
                            r1 = new Regex(@"(?<=\+)[0-9]+");
                            if (r1.Match(strtemp).Value != "")
                            {
                                ilen = Convert.ToInt32(r1.Match(strtemp).Value); ;
                            }
                            for (int i = istart; i <= ilen; i++)
                            {
                                li.Add(string.Format("{0}", i));
                            }
                        }
                        else
                        {
                            string[] strli = SelectorHelper.ToDBC(strtemp).Split(',');
                            foreach (string ss in strli)
                            {
                                li.Add(ss);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    li.Add("出错:" + ex.Message);
                }
            }
            switch (ctrltype)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    //if (li.Count > 0 && sqlSentence != "")
                    //    ((DevExpress.XtraEditors.TextEdit)ctrl).Text = li[0].ToString();
                    if (li.Count > 0 && sqlSentence != "")
                    {
                        //((DevExpress.XtraEditors.TextEdit)ctrl).Text = li[0].ToString();
                        Control bttip = FindCtrl("bt" + lp.LPID);
                        if (bttip != null)
                        {
                            ((ComboBoxEdit)bttip).Properties.Items.Clear();
                            ((ComboBoxEdit)bttip).Properties.Items.AddRange(li);
                            //if (((ComboBoxEdit)bttip).Properties.Items.Count > 0)
                            //    ((ComboBoxEdit)bttip).SelectedIndex = 0;
                        }
                    }
                    break;
                case "DevExpress.XtraEditors.SpinEdit":
                    if (li.Count > 0 && sqlSentence != "")
                    {
                        //((DevExpress.XtraEditors.SpinEdit)ctrl).Text = li[0].ToString();
                        Control bttip = FindCtrl("bt" + lp.LPID);
                        if (bttip != null)
                        {
                            ((ComboBoxEdit)bttip).Properties.Items.Clear();
                            ((ComboBoxEdit)bttip).Properties.Items.AddRange(li);
                            //if (((ComboBoxEdit)bttip).Properties.Items.Count > 0)
                            //    ((ComboBoxEdit)bttip).SelectedIndex = 0;
                        }
                    }
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Clear();
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    if (sqlSentence != "")
                    {
                        try
                        {
                            IList list = ClientHelper.PlatformSqlMap.GetList(SplitSQL(sqlSentence)[0], SplitSQL(sqlSentence)[1]);
                            for (int i = 0; i < list.Count; i++)
                            {
                                ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Add(list[i].GetType().GetProperty(lp.SqlColName).GetValue(list[i], null));
                            }
                        }
                        catch
                        {
                            //string sql = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                            //IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sql);
                            //((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.AddRange(list);
                            //((DevExpress.XtraEditors.ComboBoxEdit)ctrl).SelectedItem = MainHelper.User.OrgName;
                        }

                    }

                    if (li.Count > 0 && sqlSentence != "")
                        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.AddRange(li);
                    string[] comBoxItem = lp.ComBoxItem.Split(pcomboxchar);
                    comBoxItem = StringHelper.ReplaceEmpty(comBoxItem).Split(pchar);
                    for (int i = 0; i < comBoxItem.Length; i++)
                    {
                        if (comBoxItem[i] != "")
                        {
                            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Add(comBoxItem[i]);
                        }
                    }
                    if (((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Count > 0)
                    {
                        //if (lp.CellName != "单位")
                        //    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).SelectedIndex = 0;
                        //ContentChanged(ctrl);
                        if (lp.CellName == "单位")
                        {
                            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgCode  from mOrg where OrgName='" + ctrl.Text + "'");
                            if (list.Count > 0)
                            {
                                switch (kind)
                                {
                                    case "电力线路第一种工作票":
                                    case "yzgzp":
                                        //strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        if (bhht[ctrl.Text] != null)
                                        {
                                            strNumber = "07" + bhht[ctrl.Text].ToString();

                                        }
                                        else
                                            strNumber = "07";
                                        break;
                                    case "电力线路第二种工作票":
                                    case "ezgzp":
                                        //strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        break;
                                    case "电力线路倒闸操作票":
                                    case "dzczp":
                                        //strNumber = "BJ" + System.DateTime.Now.Year.ToString();
                                        strNumber = "06" + list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        break;
                                    case "电力线路事故应急抢修单":
                                    case "xlqxp":
                                        //strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        break;
                                    default:
                                        strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        break;
                                }
                                //IList<LP_Record> listLPRecord = ClientHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", " where kind = '" + kind + "' and number like '" + strNumber + "%'");
                                IList listLPRecord = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select ControlValue from WF_TableFieldValue where  FieldName='编号' and UserControlId='{0}' and WorkFlowInsId!='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' and ControlValue like '" + strNumber + "%' and id like '" + DateTime.Now.Year + "%' order by id desc", parentTemple.LPID));
                                if (kind == "yzgzp")
                                {
                                    //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                                    //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                                    if (listLPRecord.Count == 0)
                                        strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                    else
                                    {
                                        decimal udw = Convert.ToDecimal(listLPRecord[0]);
                                        strNumber = "0" + (udw + 1).ToString().PadLeft(3, '0');
                                    }
                                }
                                else
                                {
                                    if (listLPRecord.Count == 0)
                                        strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                    else
                                    {
                                        decimal udw = Convert.ToDecimal(listLPRecord[0].ToString().Substring(listLPRecord[0].ToString().Length - 3));
                                        strNumber = listLPRecord[0].ToString().Substring(0, listLPRecord[0].ToString().Length - 3) + (udw + 1).ToString().PadLeft(3, '0');
                                    }
                                    //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                }
                            }
                            if (ctrlNumber != null) ctrlNumber.Text = strNumber;
                            //ContentChanged(ctrlNumber);
                        }

                    }
                    break;
                case "DevExpress.XtraEditors.DateEdit":
                    if (li.Count > 0 && sqlSentence != "") {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = Convert.ToDateTime(li[0]);
                    }
                    //((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "F";          
                    //string[] arrCellPos = lp.CellPos.Split(pchar);
                    //if (arrCellPos.Length == 5)
                    //{
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd HH:mm";
                    //}
                    //else if (arrCellPos.Length == 3)
                    //{

                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd";
                    //}
                    //((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;

                    if (lp.WordCount != "" && lp.WordCount.IndexOf("|") == -1)
                    {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = lp.WordCount;
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = lp.WordCount;
                    }
                    else
                    {
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd HH:mm";

                    }
                    break;
                case "DevExpress.XtraEditors.MemoEdit":
                    //if (li.Count > 0 && sqlSentence != "")
                    //    ((DevExpress.XtraEditors.MemoEdit)ctrl).Text = li[0].ToString();

                    if (li.Count > 0 && sqlSentence != "")
                    {
                        //((DevExpress.XtraEditors.MemoEdit)ctrl).Text = li[0].ToString();
                        Control bttip = FindCtrl("bt" + lp.LPID);
                        if (bttip != null)
                        {
                            ((ComboBoxEdit)bttip).Properties.Items.Clear();
                            ((ComboBoxEdit)bttip).Properties.Items.AddRange(li);
                            //if (((ComboBoxEdit)bttip).Properties.Items.Count > 0)
                            //    ((ComboBoxEdit)bttip).SelectedIndex = 0;
                        }
                    }
                    break;
                case "uc_gridcontrol":
                    if (sqlSentence.IndexOf("{recordid}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                    }
                    if (sqlSentence.IndexOf("{orgcode}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                    }
                    if (sqlSentence.IndexOf("{userid}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                    }
                    if (sqlSentence.IndexOf("{orgname}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                    }
                    if (sqlSentence.IndexOf("{username}") > -1)
                    {
                        sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                    }
                    Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                    while (r1.Match(sqlSentence).Value != "")
                    {
                        string sortid = r1.Match(sqlSentence).Value;
                        IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                        if (listLPID.Count > 0)
                        {
                            Control ct = FindCtrl(listLPID[0].LPID);
                            if (ct != null)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                            }
                            else
                            {
                                string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                      + " UserControlId='" + listLPID[0].ParentID + "' "
                                      + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                                IList li2 = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                                if (li2.Count > 0)
                                {
                                    sqlSentence = sqlSentence.Replace("{" + sortid + "}", li2[0].ToString());
                                }
                                else
                                {
                                    sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                            break;
                        }
                    }
                    ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence, lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar), dsoFramerWordControl1, lp, currRecord);
                    break;
            }
            if (lp.CellName == "编号") strNumber = ctrl.Text;
            if (ctrlNumber != null && strNumber != "") ctrlNumber.Text = strNumber;
        }

        public int CalcWidth()
        {
            int wordcount = 0;
            if (templeList != null)
            {
                foreach (LP_Temple lp in templeList)
                {
                    if (lp.CellName.Length > wordcount)
                        wordcount = lp.CellName.Length;
                    //Label l = new Label();
                    //l.Text = lp.CellName;
                    //l.AutoSize = true;
                    //if (l.Width > wordcount)
                    //    wordcount = l.Width;

                }
            }
            //return wordcount;
            return wordWidth * wordcount;
        }

        public string[] SplitSQL(string sql)
        {
            int pos = sql.IndexOf("where");
            string temp = "";
            return new string[] { pos == -1 ? (temp=sql.Replace(" ","")) : 
                (temp=sql.Substring(0, pos).Replace(" ","")), pos == -1 ? "" : sql.Substring(pos) };
        }


        public void RelateEvent(Control ctrl)
        {
            try
            {
                LP_Temple lp = (LP_Temple)ctrl.Tag;
                if (lp.AffectLPID != null && lp.AffectLPID != "")
                {
                    string[] arrLPID = lp.AffectLPID.Split(pchar);
                    arrLPID = StringHelper.ReplaceEmpty(arrLPID).Split(pchar);
                    string[] arrEvent = lp.AffectEvent.Split(pchar);
                    for (int i = 0; i < arrLPID.Length; i++)
                    {
                        IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + arrLPID[i] + "' and parentid = '" + lp.ParentID + "'");
                        if (listLPID.Count <= 0)
                        {
                            continue;
                        }
                        Control ctrlTemp = FindCtrl((listLPID[0] as LP_Temple).LPID);
                        if (!ctrlTemp.Visible)
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(arrLPID[i]) || string.IsNullOrEmpty(arrEvent[i]))
                        {
                            continue;
                        }
                        ctrl.GetType().GetEvent(arrEvent[i]).AddEventHandler(ctrl, new EventHandler(TriggerRelateEvent));

                    }
                }

            }
            catch (System.Exception e)
            {

            }

        }

        public void TriggerRelateEvent(object sender, EventArgs e)
        {
            LP_Temple lp = (LP_Temple)((Control)sender).Tag;
            string[] arrLPID = lp.AffectLPID.Split(pchar);
            foreach (string lpid in arrLPID)
            {
                IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + lpid + "' and parentid = '" + lp.ParentID + "'");
                if (listLPID.Count <= 0)
                {
                    continue;
                }
                Control ctrl = FindCtrl((listLPID[0] as LP_Temple).LPID);
                if (ctrl != null && ctrl.Visible)
                {
                    UpdateRelateData(ctrl);
                }
            }
        }

        public void UpdateRelateData(Control ctrl)
        {
            LP_Temple lp = (LP_Temple)ctrl.Tag;
            string[] arrLPID = lp.RelateLPID.Split(pchar);
            arrLPID = StringHelper.ReplaceEmpty(arrLPID).Split(pchar);
            string sqlSentence = lp.SqlSentence;
            foreach (string lpid in arrLPID)
            {
                if (string.IsNullOrEmpty(lpid))
                {
                    continue;
                }
                IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + lpid + "' and parentid = '" + lp.ParentID + "'");
                if (listLPID.Count <= 0)
                {
                    continue;
                }
                Control relateCtrl = FindCtrl((listLPID[0] as LP_Temple).LPID);
                if (relateCtrl != null)
                {
                    int pos = sqlSentence.IndexOf("{" + lpid + "}");
                    if (pos != -1)
                    {
                        sqlSentence = sqlSentence.Remove(pos, ("{" + lpid + "}").Length);
                        sqlSentence = sqlSentence.Insert(pos, relateCtrl.Text);
                        //((LP_Temple)ctrl.Tag).SqlSentence = sqlSentence;
                    }
                }
            }
            if (lp.CtrlType.IndexOf("uc_gridcontrol") == -1)
                InitCtrlData(ctrl, sqlSentence);
            else
            {
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                if (sqlSentence.IndexOf("{orgname}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgname}", MainHelper.User.OrgName);
                }
                if (sqlSentence.IndexOf("{username}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{username}", MainHelper.User.UserName);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        Control ct = FindCtrl(listLPID[0].LPID);
                        if (ct != null)
                        {
                            sqlSentence = sqlSentence.Replace("{" + sortid + "}", ct.Text);
                        }
                        else
                        {
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            IList li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        }
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }
                }
                ((uc_gridcontrol)ctrl).InitData(sqlSentence, lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar), dsoFramerWordControl1, lp, currRecord);
            }
        }

        public Control FindCtrl(string name)
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                if (ctrl.Name == name)
                    return ctrl;
            }
            return null;
        }

        private void frmLP_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                //base.Close();
                //rowData = null;
                if (dsoFramerWordControl1 != null)
                {

                    dockPanel1.ControlContainer.Controls.Clear();
                    templeList.Clear();
                    //string strfilename = dsoFramerWordControl1.fileName;
                    dsoFramerWordControl1.FileSave();
                    dsoFramerWordControl1.FileClose();
                    dsoFramerWordControl1.Dispose();
                    //SelectorHelper.Execute("del /f/s/q \"" + strfilename+"\"", 500);
                    dsoFramerWordControl1 = null;
                    currRecord = null;
                }
                if (filecontrol != null)
                {

                    if (filecontrol.upThread != null && filecontrol.upThread.ThreadState == ThreadState.Running)
                    {

                        filecontrol.upThread.IsBackground = true;
                        filecontrol.upThread.Abort();

                    }
                    if (filecontrol.Isdownfile)
                    {

                        if (filecontrol.webClient != null) filecontrol.webClient.CancelAsync();

                    }
                }
            }
            catch { }
        }

        private void frmLP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (filecontrol != null)
            {
                if (filecontrol.Isupfile)
                {
                    if (MsgBox.ShowAskMessageBox("正在上传文件，确认退出?") != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (filecontrol.Isdownfile)
                {
                    if (MsgBox.ShowAskMessageBox("正在下载文件，确认退出?") != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }

                }
            }
        }

        private void dsoFramerWordControl1_Click(object sender, EventArgs e)
        {
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }

            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet sheet;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
        }
    }
}