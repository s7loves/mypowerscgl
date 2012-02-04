using System;
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
using Ebada.SCGL.WFlow.Tool;

namespace  Ebada.Scgl.Lcgl
{
    public partial class frmGYPDXLJSZLTemplate : Form,IPopupFormEdit
    {
        #region 字段

        const int wordWidth = 13;
        private LP_Temple parentTemple = null;
        private IList<LP_Temple> templeList;
        private IList<Control> tempCtrlList=null;
        private WF_TableFieldValue currRecord = null;
        private string kind,status;
        private string plitchar = "|";
        private char pchar = '|';
        private char pcomboxchar = '，';
        private string strNumber = "";
        private Control ctrlNumber = null;
        private string activeSheetName = "";
        private int activeSheetIndex = 1;
        private DownFileControl filecontrol = null;
        //private SPYJControl hqyjcontrol = null;
        private Hashtable valuehs = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private bool isWorkflowCall = false;
        private string varDbTableName = "LP_Record";
        private string modleGuid = "";
        private string orgname = "";
        public string ModleGuid
        {
            set
            {

                modleGuid = value;
            }
        }
        public string OrgName
        {
            set
            {

                orgname = value;
            }
        }
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

        public WF_TableFieldValue CurrRecord
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
        private WF_TableFieldValue rowData = null;

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
                    this.rowData = value as WF_TableFieldValue;                  
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<WF_TableFieldValue>(value as WF_TableFieldValue, rowData);                    
                }
            }
        }

        #endregion
        public frmGYPDXLJSZLTemplate()
        {
            InitializeComponent();           
        }
        void dataBind()
        {        
            
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
       /// <summary>
        ///设置保护工作表
       /// </summary>
        private void LockExcel(Excel.Workbook wb, Excel.Worksheet xx)
        {
          
           
            xx.Protect("MyPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing);
            xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
            wb.SheetBeforeDoubleClick += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            //wb.SheetDeactivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetDeactivateEventHandler(Workbook_SheetDeactivate);
            //wb.SheetActivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetActivateEventHandler(Workbook_SheetActivate);
            //wb.SheetSelectionChange  += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetSelectionChangeEventHandler(Workbook_SheetSelectionChange);  
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
           
        }
        protected void Workbook_SheetActivate(object Sh)
        {
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            Excel.Worksheet sheet;
            sheet = wb.ActiveSheet as Excel.Worksheet;
            if (activeSheetName != sheet.Name)
            {

                sheet.Name = activeSheetName;

            }
            if (wb.Application.Sheets[activeSheetIndex] != wb.Application.Sheets[activeSheetName])
            {

                sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
                sheet.Move(Type.Missing, wb.Application.Sheets[activeSheetIndex]);
            }
           
            
            ea.ActiveSheet(activeSheetName);
           
        }
        protected void Workbook_SheetDeactivate(object Sh)
        {
            Workbook_SheetActivate( Sh);
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
              
                
                xx.Unprotect("MyPassword");
                xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
                wb.SheetBeforeDoubleClick -= new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);  
            }
            catch { }
        }
        private void LPFrm_Load(object sender, EventArgs e)
        {
            if (tempCtrlList==null)
            {
                tempCtrlList = new List<Control>();
            }
            this.Text = "高压配电线路技术档案";
            //InitializeComponent();
            if (valuehs == null)
                valuehs = new Hashtable();
            Excel.Workbook wb;
            Excel.Worksheet sheet;
            ExcelAccess ea = new ExcelAccess();
            parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and  CellName = '高压配电线路技术档案'");
            currRecord = rowData;
            if (parentTemple == null)
            {
                MsgBox.ShowWarningMessageBox("没有找到表单高压配电线路技术档案!");
                return;
            }
            //if (currRecord.BigData == null || currRecord.BigData.Length == 0)
            {

                this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
            }
            //else
            //{

            //    this.dsoFramerWordControl1.FileDataGzip = currRecord.BigData;
            //}
                InitIndex();
                InitContorl();
                InitData();
                if (status == "edit")
                {
                    IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                     " where RecordId='" + currRecord.ID + "' and UserControlId='" + parentTemple.LPID + "' and   WorkflowId='" + modleGuid + "' and WorkFlowInsId='" + orgname + "' ");
                   
                    Excel.Worksheet xx;
                    wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                    ea.MyWorkBook = wb;
                    ea.MyExcel = wb.Application;
                    string activeSheetName = "";
                    xx = wb.Application.Sheets[1] as Excel.Worksheet;
                    int i = 0;
                    unLockExcel(wb, xx);
                    ArrayList al = new ArrayList();
                    for (i = 1; i <= wb.Application.Sheets.Count; i++)
                    {
                        xx = wb.Application.Sheets[i] as Excel.Worksheet;
                        if (!al.Contains(xx.Name)) al.Add(xx.Name);
                    }
                    for (i = 0; i < tfvli.Count; i++)
                    {
                      
                        Control ctl= FindCtrl(tfvli[i].FieldId);
                        if (ctl != null)
                        {
                            ctl.Text = tfvli[i].ControlValue;
                            ctl.Focus();
                        }
                        if (!al.Contains(tfvli[i].ExcelSheetName))
                        {

                            continue;
                        }
                      
                        
                        
                        if (activeSheetName != tfvli[i].ExcelSheetName)
                        {
                            if (activeSheetName != "")
                            {

                                xx = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;


                            }
                            xx = wb.Application.Sheets[tfvli[i].ExcelSheetName] as Excel.Worksheet;

                            activeSheetName = tfvli[i].ExcelSheetName;

                            ea.ActiveSheet(xx.Index);
                        }

                        //if (tfvli[i].XExcelPos > -1 && tfvli[i].YExcelPos > -1) ea.SetCellValue(tfvli[i].ControlValue, tfvli[i].XExcelPos, tfvli[i].YExcelPos);


                    }
                    LockExcel(wb, xx);
                    dsoFramerWordControl1.FileSave();
                }

              
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
            if (parentTemple != null) templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                "where ParentID ='" + parentTemple.LPID + "' order by SortID");
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
            if (MaxWordWidth < 300)
            {
                MaxWordWidth = 300;
            }
            if (parentTemple != null && templeList!=null)
            {
                foreach (LP_Temple lp in templeList)
                {
                    bool flag;//= (lp.Status == CurrRecord.Status);
                    flag = lp.IsVisible==0;
                    Label label = new Label();
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

                   
                     ctrl.TextChanged += new EventHandler(ctrl_Leave);
                   
                    ctrl.Enter += new EventHandler(ctrl_Enter);
                    ctrl.Leave += new EventHandler(ctrl_Leave);
                    ctrl.Visible = flag;
                    ctrl.Tag = lp;
                    ctrl.TabIndex = index;
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        (ctrl as uc_gridcontrol).InitCol(lp.ColumnName.Split(pchar), lp);
                      
                        (ctrl as uc_gridcontrol).iniTableRecordData(currRecord.ID, lp, modleGuid, orgname);
                        
                    }
                    index++;
                    if (lp.CellName.IndexOf("供电所名称") > -1)
                    {
                        ctrl.Text = orgname;
                    }
                    ctrl.Name = lp.LPID;
                    dockPanel1.Controls.Add(label);
                    dockPanel1.Controls.Add(ctrl);
                   
                }
            }
            InitEvent();
            InitData();
            //if (RecordWorkTask.HaveRunSPYJRole(kind))
            //{
            //    if (hqyjcontrol == null) hqyjcontrol = new SPYJControl();
            //    hqyjcontrol.Size = new System.Drawing.Size(400, 200);
            //    hqyjcontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
            //    currentPosY = currentPosY + hqyjcontrol.Size.Height;
            //    hqyjcontrol.RecordID = CurrRecord.ID;
            //    dockPanel1.Controls.Add(hqyjcontrol);
            //}

            //if (RecordWorkTask.HaveRunFuJianRole(kind))
            //{

            if (filecontrol == null) filecontrol = new DownFileControl();
            if (status == "add")
                filecontrol.FormType = "上传";
            else if (status == "edit")
            {
                filecontrol.FormType = "下载";
            }
            filecontrol.Size = new System.Drawing.Size(400, 300);
            filecontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
            currentPosY = currentPosY + filecontrol.Size.Height;
            filecontrol.UpfilePath = "高压配电线路技术档案";

            filecontrol.RecordID = currRecord.ID;
            dockPanel1.Controls.Add(filecontrol);
            currentPosY += 20;
            //}
           
            Button btn_Submit = new Button();
            dockPanel1.Controls.Add(btn_Submit);
            btn_Submit.Location = new Point(currentPosX, currentPosY + 10);
            btn_Submit.Text = "提交";
            btn_Submit.Click += new EventHandler(btn_Submit_Click);
            if (dockPanel1.ControlContainer.Controls.Count > 0)
                dockPanel1.ControlContainer.Controls[0].Focus();
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ctrl_Leave(sender, e);

        }
        void btn_Close(object sender, EventArgs e)
        {
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.Dispose();
            dsoFramerWordControl1 = null;
            this.DialogResult = DialogResult.OK;
        }
      
        void btn_Submit_Click(object sender, EventArgs e)
        {
            Excel.Workbook wb;
            Excel.Worksheet sheet;
            dsoFramerWordControl1.FileSave();
            //currRecord.BigData = this.dsoFramerWordControl1.FileDataGzip;
            wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
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
            if (activeSheetName != "")
            {
                sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
            }
            else
            {
                sheet = wb.Application.Sheets[1] as Excel.Worksheet;
            }
            activeSheetIndex = sheet.Index;
            
            for (int i = 1; i <= wb.Application.Sheets.Count; i++)
            {
                if (i != activeSheetIndex)
                {
                    Excel.Worksheet tmpSheet = (Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                    try
                    {
                        if (tmpSheet != null) tmpSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible ;
                    }
                    catch { }

                }
            }
            unLockExcel(wb,sheet);
            for (int i = 1; sheet.Protection.AllowEditRanges.Count > 0; )
            {
                Excel.AllowEditRange editRange = sheet.Protection.AllowEditRanges.get_Item(i);
                editRange.Delete();
            }
            LockExcel(wb, sheet);
            byte[] bt = new byte[0];
            string strmes = "";
            WF_WorkTaskCommands wt;
            
           
            //rowData = null;
            ArrayList akeys = new ArrayList(valuehs.Keys);
            List<object> list = new List<object>();
            string strid = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
            for (int i = 0; i < akeys.Count; i++)
            {
                WF_TableFieldValue wfv = valuehs[akeys[i]] as WF_TableFieldValue;
                wfv.ID = wfv.CreateID();
                wfv.RecordId = currRecord.ID;
                wfv.WorkFlowId =modleGuid;
                wfv.WorkFlowInsId = orgname;
                wfv.WorkTaskId = "高压配电线路技术档案";
                wfv.WorkTaskInsId = "高压配电线路技术档案";
                wfv.UserControlId = parentTemple.LPID;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                list.Add(wfv);
                for (int j = 0; j < templeList.Count; j++)
                {
                    if (templeList[j].LPID == wfv.FieldId)
                    {
                        templeList.RemoveAt(j);
                        break;
                    }
                }
            }
            Control ct=null;
            DateTime dt = DateTime.Now;
            Random rd = new Random();
            decimal dtemp = Convert.ToDecimal(dt.ToString("yyyyMMddHHmmssffffff"));
            for (int i = 0; i < templeList.Count; i++)
            {
                WF_TableFieldValue wfv = new  WF_TableFieldValue();
                wfv.ExcelSheetName = templeList[i].KindTable;
                if (templeList[i].CellPos != "")
                {
                    wfv.XExcelPos = GetCellPos(templeList[i].CellPos)[0];
                    wfv.YExcelPos = GetCellPos(templeList[i].CellPos)[1];
                }
                else
                {

                    wfv.XExcelPos = -1;
                    wfv.YExcelPos = -1;
                }
                wfv.FieldId = templeList[i].LPID;
                wfv.FieldName = templeList[i].CellName;
                ct = FindCtrl( templeList[i].LPID);
                if(ct!=null)
                wfv.ControlValue=ct.Text;

                
                if (wfv.XExcelPos != -1 && wfv.YExcelPos != -1)
                    wfv.ID = Convert.ToString((dtemp + wfv.YExcelPos + wfv.XExcelPos * 10000));
                else
                    wfv.ID = Convert.ToString((dtemp + rd.Next() * 10000));
                wfv.RecordId = currRecord.ID;
                wfv.WorkFlowId =modleGuid ;
                wfv.WorkFlowInsId = orgname;
                wfv.WorkTaskId = "高压配电线路技术档案";
                wfv.WorkTaskInsId = "高压配电线路技术档案";
                wfv.UserControlId = parentTemple.LPID;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                list.Add(wfv);
            }
            switch (status)
            {
                case "add":

                    if (list.Count > 0)
                    {
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(list, null, null);
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
                    break;

                case "edit":

                    if (list.Count > 0)
                    {
                        foreach (WF_TableFieldValue wfv in list)
                        {
                           WF_TableFieldValue wtfvtemp= Client.ClientHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                                + " and   WorkflowId='" + wfv.WorkFlowId + "'"
                                + " and   RecordId='" + wfv.RecordId + "'"
                                + " and   UserControlId='" + wfv.UserControlId + "'"
                                + " and   WorkFlowInsId='" + wfv.WorkFlowInsId + "'"
                                + " and   FieldId='" + wfv.FieldId + "'"
                                + " and WorkTaskInsId='高压配电线路技术档案'");
                           wfv.ID = wtfvtemp.ID;
                        }
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, list, null);
                    }
                  
                    break;
            }
           
            dsoFramerWordControl1.FileClose();

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

        public void InitData()
        {
            foreach (Control ctrl in dockPanel1.ControlContainer.Controls)
            {
                //UpdateRelateData(ctrl);
                if (ctrl.Tag != null && (!tempCtrlList.Contains(ctrl)))
                {
                    if (((LP_Temple)ctrl.Tag).CellName == "供电所名称") continue;
                    InitCtrlData(ctrl, ((LP_Temple)ctrl.Tag).SqlSentence);
                }
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
                sheet = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                activeSheetIndex = sheet.Index;
            }
            else
            {

                sheet = wb.Application.Sheets[1] as Excel.Worksheet;
                activeSheetIndex = sheet.Index;
                activeSheetName = sheet.Name;
            }
            ea.ActiveSheet(activeSheetIndex);
            unLockExcel(wb, sheet);
            if (lp.CtrlType.Contains("uc_gridcontrol"))
            { FillTable(ea, lp, (ctrl as uc_gridcontrol).GetContent(String2Int(lp.WordCount.Split(pchar)))); return; }
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
                ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                if (valuehs.ContainsKey(lp.LPID +"$" +lp.CellPos))
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
                    WF_TableFieldValue tfv = new WF_TableFieldValue ();
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
                            ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);
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
                        ea.SetCellValue(str, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
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
                    ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                        GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
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
            LockExcel(wb,sheet);
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
            Excel.Worksheet xx;

            if (lp.KindTable != "")
            {
                activeSheetName = lp.KindTable;
                xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
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
                    xx.Protection.AllowEditRanges.Add(lp.CellPos.Replace("|", ""), range, Type.Missing);
                }
            }
            LockExcel(wb, xx);
        }

        void ctrl_Enter(object sender, EventArgs e)
        {
           
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            if (lp.CellPos == "") return;
            string str = (sender as Control).Text;
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet xx;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            if (lp.KindTable != "")
            {
                activeSheetName = lp.KindTable;
                xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                activeSheetIndex = xx.Index;
            }
            else
            {

                xx = wb.Application.Sheets[1] as Excel.Worksheet;
                activeSheetIndex = xx.Index;
                activeSheetName = xx.Name;
            }
            ea.ActiveSheet(activeSheetIndex);
            unLockExcel(wb,xx);
            string[] arrCellpos = lp.CellPos.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            if (arrCellpos.Length >= 1)
            {
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
                    xx.Protection.AllowEditRanges.Add(lp.CellPos.Replace("|", ""), range, Type.Missing);
                }
            }
            LockExcel(wb, xx);
        }
        void ctrl_Leave(object sender, EventArgs e)
        {
             
            
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            
                
            if (dsoFramerWordControl1==null||dsoFramerWordControl1.MyExcel==null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            Excel.Worksheet xx;
            if (lp.KindTable != "")
            {
                activeSheetName = lp.KindTable;
                xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;
                activeSheetIndex = xx.Index;
            }
            else
            {
                xx = wb.Application.Sheets[1] as Excel.Worksheet;
                activeSheetIndex = xx.Index;
                activeSheetName = xx.Name;
            }
            if (lp.KindTable != "")
            {
                ea.ActiveSheet(lp.KindTable);
            }
            else
            {
                ea.ActiveSheet(1);
            }
            if (lp.CellPos == "")
            {
                lp.CellPos = lp.CellPos;
                if (valuehs.ContainsKey(lp.LPID))
                {
                    WF_TableFieldValue tfv = valuehs[lp.LPID ] as WF_TableFieldValue;
                    tfv.ControlValue = str;
                    tfv.FieldId = lp.LPID;
                    tfv.FieldName = lp.CellName;
                    tfv.XExcelPos =-1;
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
                    tfv.ExcelSheetName = xx.Name;

                    valuehs.Add(lp.LPID, tfv);
                }
                return;
            }
            unLockExcel(wb,xx);

            string[] arrCellpos = lp.CellPos.Split(pchar);
            string[] arrtemp = lp.WordCount.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            if (lp.CtrlType.Contains("uc_gridcontrol"))
            { 
                FillTable(ea, lp, (sender as uc_gridcontrol).GetContent(String2Int(lp.WordCount.Split(pchar))));
                LockExcel(wb, xx);
                return; 
            }
            else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
            { 
                FillTime(ea, lp, (sender as DateEdit).DateTime);
                LockExcel(wb, xx);
                return;
            }
            else if (lp.CtrlType.Contains("DevExpress.XtraEditors.SpinEdit"))
            {

                IList<string> strList = new List<string>();
                if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
                {
                    ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                        tfv.ControlValue = str;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                        tfv.ExcelSheetName = xx.Name;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = str;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                        tfv.ExcelSheetName = xx.Name;
                        valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                    }
                }
                else if (arrCellpos.Length > 1 && (!string.IsNullOrEmpty(arrCellpos[1])))
                {
                    int i = 0;
                    ea.SetCellValue(str, GetCellPos(arrCellpos[i])[0], GetCellPos(arrCellpos[i])[1]);
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[i]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[i]] as WF_TableFieldValue;
                        tfv.ControlValue = str;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[i])[1];
                        tfv.ExcelSheetName = xx.Name;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = str;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[i])[1];
                        tfv.ExcelSheetName = xx.Name;
                        valuehs.Add(lp.LPID + "$" + arrCellpos[i], tfv);
                    }
                }
                LockExcel(wb, xx);
                return;
            }          
            string[] extraWord = lp.ExtraWord.Split(pchar);  
            List<int> arrCellCount = String2Int(arrtemp);
            if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
            {
                ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
                if (valuehs.ContainsKey(lp.LPID + "$" + lp.CellPos))
                {
                    WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + lp.CellPos] as WF_TableFieldValue;
                    tfv.ControlValue = str;
                    tfv.FieldId = lp.LPID;
                    tfv.FieldName = lp.CellName;
                    tfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    tfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                    tfv.ExcelSheetName = xx.Name;

                }
                else
                {
                    WF_TableFieldValue tfv = new WF_TableFieldValue();
                    tfv.ControlValue = str;
                    tfv.FieldId = lp.LPID;
                    tfv.FieldName = lp.CellName;
                    tfv.XExcelPos = GetCellPos(lp.CellPos)[0];
                    tfv.YExcelPos = GetCellPos(lp.CellPos)[1];
                    tfv.ExcelSheetName = xx.Name;
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
                            string strNew = str.Substring(0, str.Length - 1) + (j + 1).ToString();
                            ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);
                            if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[j]))
                            {
                                WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[j]] as WF_TableFieldValue;
                                tfv.ControlValue = strNew;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[j])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[j])[1];
                                tfv.ExcelSheetName = xx.Name;

                            }
                            else
                            {
                                WF_TableFieldValue tfv = new WF_TableFieldValue();
                                tfv.ControlValue = strNew;
                                tfv.FieldId = lp.LPID;
                                tfv.FieldName = lp.CellName;
                                tfv.XExcelPos = GetCellPos(arrCellpos[j])[0];
                                tfv.YExcelPos = GetCellPos(arrCellpos[j])[1];
                                tfv.ExcelSheetName = xx.Name;
                                valuehs.Add(lp.LPID + "$" + arrCellpos[j], tfv);
                            }
                        }
                    }
                    LockExcel(wb, xx);
                    return;
                }
                int i = 0;
                if (arrCellCount[0] != arrCellCount[1])
                {
                    if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[0]))
                    {
                        ea.SetCellValue(str, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                        if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                        {
                            WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                            tfv.ExcelSheetName = xx.Name;

                        }
                        else
                        {
                            WF_TableFieldValue tfv = new WF_TableFieldValue();
                            tfv.ControlValue = str;
                            tfv.FieldId = lp.LPID;
                            tfv.FieldName = lp.CellName;
                            tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                            tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                            tfv.ExcelSheetName = xx.Name;
                            valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                        }

                        LockExcel(wb, xx);
                        return;
                    }
                    ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                        GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellpos[0]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellpos[0]] as WF_TableFieldValue;
                        tfv.ControlValue = (str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])));
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellpos[0])[0];
                        tfv.YExcelPos = GetCellPos(arrCellpos[0])[1];
                        tfv.ExcelSheetName = xx.Name;

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
                        tfv.ExcelSheetName = xx.Name;
                        valuehs.Add(lp.LPID + "$" + arrCellpos[0], tfv);
                    }
                    str = str.Substring(help.GetFristLen(str, arrCellCount[0]) >= str.IndexOf("\r\n") &&
                        str.IndexOf("\r\n") != -1 ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                    i++;
                }
                str = help.GetPlitString(str, arrCellCount[1]);
                FillMutilRows(ea, i, lp, str, arrCellCount, arrCellpos);

            }
            if (lp.CellName == "单位")
            {
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgCode  from mOrg where OrgName='" + str + "'");
                if (list.Count > 0)
                {
                    switch (kind)
                    {

                        case "电力线路第一种工作票":
                        case "yzgzp":
                            strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                            break;
                        case "电力线路第二种工作票":
                        case "ezgzp":
                            strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                            break;
                        case "电力线路倒闸操作票":
                        case "dzczp":
                            strNumber = "BJ" + System.DateTime.Now.Year.ToString();
                            break;
                        case "电力线路事故应急抢修单":
                        case "xlqxp":
                            strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                            break;
                        default:
                            strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                            break;
                    }
                    IList<LP_Record> listLPRecord = ClientHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", " where kind = '" + kind + "' and number like '" + strNumber + "%'");
                    if (kind == "yzgzp")
                    {
                        strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                    }
                    else
                    {
                        strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                    }
                    if (ctrlNumber != null)
                    {
                        ctrlNumber.Text = strNumber;
                       
                    }
                   
                    //ContentChanged(ctrlNumber);
                }

            }

            LockExcel(wb, xx);
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
            str = help.GetPlitString(str, arrCellCount[1]);            
            string[] extraWord = lp.ExtraWord.Split(pchar);          

            string[] arrRst = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int j = 0;
            for (; i < arrCellPos.Length; i++)
            {
                if (j >= arrRst.Length)
                    break;
                ea.SetCellValue(arrRst[j], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
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

        public void FillTime(ExcelAccess ea, LP_Temple lp,DateTime dt)
        {
            string[] arrCellPos = lp.CellPos.Split(pchar);
            arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split(pchar);
            string[] extraWord = lp.ExtraWord.Split(pchar);         
            IList<string> strList=new List<string>();
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
                    strList.Add(dt.Month.ToString());
                    strList.Add(dt.Day.ToString());
                    break;
                case "MM-dd日":
                    strList.Add(dt.Month.ToString());
                    strList.Add(dt.Day.ToString());
                    break;
                case "yyyy-MM-dd HH:mm:ss":
                    strList.Add(dt.Year.ToString());
                    strList.Add(dt.Month.ToString());
                    strList.Add(dt.Day.ToString());
                    strList.Add(dt.Hour.ToString());
                    strList.Add(dt.Second.ToString());
                    break;
                case "HH:mm:ss":
                    strList.Add(dt.Hour.ToString());
                    strList.Add(dt.Minute.ToString());
                    strList.Add(dt.Second.ToString());
                    break;
                case "MM-dd日 HH:mm":
                    strList.Add(dt.Month.ToString());
                    strList.Add(dt.Day.ToString());
                    strList.Add(dt.Hour.ToString());
                    strList.Add(dt.Minute.ToString());
                    break;
                case "dd日 HH:mm":
                    strList.Add(dt.Day.ToString());
                    strList.Add(dt.Hour.ToString());
                    strList.Add(dt.Minute.ToString());
                    break;
                case "HH:mm":
                    strList.Add(dt.Hour.ToString());
                    strList.Add(dt.Minute.ToString());
                    break;
                default:
                    strList.Add(dt.Year.ToString());
                    strList.Add(dt.Month.ToString());
                    strList.Add(dt.Day.ToString());
                    strList.Add(dt.Hour.ToString());
                    strList.Add(dt.Minute.ToString());
                    break;
            }
           // int i = 0;
            for (int i = 0; i < strList.Count;i++ )
            {
                if (extraWord.Length>i)
                {
                    ea.SetCellValue(strList[i] + extraWord[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                        tfv.ControlValue = strList[i] + extraWord[i];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                        tfv.ExcelSheetName = activeSheetName;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = strList[i] + extraWord[i];
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                        tfv.ExcelSheetName = activeSheetName;
                        valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                    }
                }
                else
                {
                    ea.SetCellValue(strList[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                    if (valuehs.ContainsKey(lp.LPID + "$" + arrCellPos[i]))
                    {
                        WF_TableFieldValue tfv = valuehs[lp.LPID + "$" + arrCellPos[i]] as WF_TableFieldValue;
                        tfv.ControlValue = strList[i] ;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                        tfv.ExcelSheetName = activeSheetName;

                    }
                    else
                    {
                        WF_TableFieldValue tfv = new WF_TableFieldValue();
                        tfv.ControlValue = strList[i] ;
                        tfv.FieldId = lp.LPID;
                        tfv.FieldName = lp.CellName;
                        tfv.XExcelPos = GetCellPos(arrCellPos[i])[0];
                        tfv.YExcelPos = GetCellPos(arrCellPos[i])[1];
                        tfv.ExcelSheetName = activeSheetName;
                        valuehs.Add(lp.LPID + "$" + arrCellPos[i], tfv);
                    }
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
                    ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0], GetCellPos(arrCellPos)[1] + i);
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

                    ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0] + i, GetCellPos(arrCellPos)[1]);
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
            string ctrltype = "";
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
                            li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                            }
                            else {
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
                try
                {
                    sqlSentence = sqlSentence.Replace("\r\n", "");
                    li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                }
                catch (Exception ex)
                {
                    li.Add("出错:" + ex.Message);
                }
            }
            switch (ctrltype)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    if (li.Count > 0 && sqlSentence != ""&&li[0]!=null)
                        ((DevExpress.XtraEditors.TextEdit)ctrl).Text = li[0].ToString();
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Clear();
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    //if (sqlSentence != "")
                    //{
                    //    try
                    //    {
                    //        IList list = ClientHelper.PlatformSqlMap.GetList(SplitSQL(sqlSentence)[0], SplitSQL(sqlSentence)[1]);
                    //        for (int i = 0; i < list.Count; i++)
                    //        {
                    //            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Add(list[i].GetType().GetProperty(lp.SqlColName).GetValue(list[i], null));
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        string sql = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                    //        IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sql);
                    //        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.AddRange(list);
                    //        ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).SelectedItem = MainHelper.User.OrgName;
                    //    }

                    //}

                    if (li.Count > 0 && sqlSentence != "")
                    {
                        try
                        {
                            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.AddRange(li);
                        }
                        catch { }
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
                        if (lp.CellName != "单位")
                            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).SelectedIndex = 0;
                        //ContentChanged(ctrl);
                        if (lp.CellName == "单位")
                        {
                            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgCode  from mOrg where OrgName='" + ctrl.Text + "'");
                            if (list.Count > 0)
                            {
                                switch (kind)
                                {
                                    case "yzgzp":
                                        strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        break;
                                    case "ezgzp":
                                        strNumber = "08" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        break;
                                    case "dzczp":
                                        strNumber = "BJ" + System.DateTime.Now.Year.ToString();
                                        break;
                                    case "xlqxp":
                                        strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                                        break;
                                    default:
                                        strNumber = "07" + System.DateTime.Now.Year.ToString() + list[0].ToString().Substring(list[0].ToString().Length - 2, 2);
                                        break;
                                }
                                IList<LP_Record> listLPRecord = ClientHelper.PlatformSqlMap.GetList<LP_Record>("SelectLP_RecordList", " where kind = '" + kind + "' and number like '" + strNumber + "%'");
                                if (kind == "yzgzp")
                                {
                                    strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0') + "-1";
                                }
                                else
                                {
                                    strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                                }
                            }
                            if (ctrlNumber != null) ctrlNumber.Text = strNumber;
                            //ContentChanged(ctrlNumber);
                        }

                    }
                    break;
                case "DevExpress.XtraEditors.DateEdit":
                    if (li.Count > 0 && sqlSentence != "")
                        ((DevExpress.XtraEditors.DateEdit)ctrl).Text = li[0].ToString();
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
                    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;

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
                    if (li.Count > 0 && sqlSentence != "")
                        ((DevExpress.XtraEditors.MemoEdit)ctrl).Text = li[0].ToString();
                    break;
                //case "uc_gridcontrol":
                //    ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence.Split(new char[] { pchar }, StringSplitOptions.RemoveEmptyEntries), lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar),dsoFramerWordControl1,lp,currRecord);
                    //break;
            }
        
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
                if (listLPID.Count<=0)
                {
                    continue;
                }
                Control ctrl = FindCtrl((listLPID[0] as LP_Temple).LPID);
                //if (ctrl != null && ctrl.Visible)
                if (ctrl != null)
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
            InitCtrlData(ctrl, sqlSentence);
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
                currRecord = null;

                dsoFramerWordControl1.FileClose();
                dsoFramerWordControl1.Dispose();
                dockPanel1.ControlContainer.Controls.Clear();
                templeList.Clear();
                    //if (filecontrol != null)
                    //{

                    //    if (filecontrol.upThread != null && filecontrol.upThread.ThreadState == ThreadState.Running)
                    //    {
                            
                    //            filecontrol.upThread.IsBackground = true;
                    //            filecontrol.upThread.Abort();
                           
                    //    }
                    //    if (filecontrol.Isdownfile)
                    //    {

                    //        if (filecontrol.webClient!=null) filecontrol.webClient.CancelAsync();

                    //    }
                    //}
            }
            catch { }
        }

        private void frmLP_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (filecontrol != null)
            //    {
            //        if (filecontrol.Isupfile)
            //        {
            //            if (MsgBox.ShowAskMessageBox("正在上传文件，确认退出?") != DialogResult.OK)
            //            {
            //                e.Cancel = true;
            //                return;
            //            }
            //        }
            //        if (filecontrol.Isdownfile)
            //        {
            //            if (MsgBox.ShowAskMessageBox("正在下载文件，确认退出?") != DialogResult.OK)
            //            {
            //                e.Cancel = true;
            //            }

            //        }
            //    }
        }
    }
}
