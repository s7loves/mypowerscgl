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

namespace Ebada.Scgl.Lcgl
{
    public partial class frmLP : Form,IPopupFormEdit
    {
        #region 字段

        const int wordWidth = 13;
        private LP_Temple parentTemple = null;
        private IList<LP_Temple> templeList;
        private IList<Control> tempCtrlList=null;
        private LP_Record currRecord = null;
        private string kind,status;
        private string plitchar = "|";
        private char pchar = '|';
        private char pcomboxchar = '，';
        private string strNumber = "";
        private Control ctrlNumber = null;
        private string activeSheetName = "";
        private int activeSheetIndex = 1;
        private DownFileControl filecontrol = null;
        private SPYJControl hqyjcontrol = null;

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

        #endregion
        #region IPopupFormEdit Members
        private LP_Record rowData = null;

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
        private DataTable WorkFlowData = null;//实例流程信息

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
        private void LockExcel()
        {
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet xx = wb.Application.Sheets[activeSheetName ] as Excel.Worksheet;  
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
        private void unLockExcel()
        {
            try
            {
              
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                Excel.Worksheet xx = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
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
            //InitializeComponent();
            InitIndex();            
                //InitContorl();
            Excel.Workbook wb;
            Excel.Worksheet sheet;
            ExcelAccess ea = new ExcelAccess();
            Regex r1 = new Regex(@"(?<=" + CurrRecord.Status + ":)([^,]+)((?=,)?)");
            if (r1.Match(parentTemple.KindTable).Value != "")
            {
                activeSheetName = r1.Match(parentTemple.KindTable).Value;
            }
            //int istart = parentTemple.KindTable.IndexOf(CurrRecord.Status + ":") + CurrRecord.Status.Length + 1;
            //int iend = parentTemple.KindTable.IndexOf(",", istart);
            //if (iend>-1)
            //activeSheetName = parentTemple.KindTable.Substring(istart, iend);
            //else
            //    activeSheetName = parentTemple.KindTable.Substring(istart);

            if (status == "add" && parentTemple.DocContent != null && parentTemple.DocContent.Length > 0)
            {              
                this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
               
                InitContorl();
            }
            else if (status == "edit" && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
            {
                if (parentTemple != null)
                    InitContorl();             
                this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;



                //保护工作表
                LockExcel();
                LoadContent();
            }
            if (parentTemple.DocContent != null || (currRecord.DocContent != null&&currRecord.DocContent.Length >0))
            {
                wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
                activeSheetIndex = sheet.Index;
                for (int i = 1; i <= wb.Application.Sheets.Count; i++)
                {
                    if (i != activeSheetIndex)
                    {
                        Excel.Worksheet tmpSheet = (Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                        try
                        {
                            if (tmpSheet != null) tmpSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
                           
                        }
                        catch { }

                    }
                }
                //保护工作表
                LockExcel();
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
            templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID ='" + parentTemple.LPID +"' and Kind='" + kind + "' Order by SortID");
            //IList<LP_Temple> parentlist = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID='0' and Kind='" + kind + "'");
            //if (parentlist.Count > 0)
            //    parentTemple = parentlist[0];
           // dsoFramerWordControl1.
        }

        public void InitContorl()
        {
            int MaxWordWidth = CalcWidth();
            int currentPosY = 10;
            int currentPosX = 10;
            int index = 0;
            foreach (LP_Temple lp in templeList)
            {
                bool flag = (lp.Status == CurrRecord.Status);
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
                Control ctrl ;

                if (lp.CtrlType.Contains("uc_gridcontrol"))
                {
                    ctrl = new uc_gridcontrol();
                    ((uc_gridcontrol)ctrl).CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
                }
                else
                    ctrl = (Control)Activator.CreateInstance(Type.GetType(lp.CtrlType));
                ctrl.Location = new Point(currentPosX, currentPosY);
                ctrl.Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                if (flag)
                {
                    currentPosY += int.Parse(size[1]) + 10; 
                }

                if (flag)
                {
                    ctrl.TextChanged += new EventHandler(ctrl_Leave);
                }
                ctrl.Enter += new EventHandler(ctrl_Enter);                
                ctrl.Leave += new EventHandler(ctrl_Leave);
                ctrl.Visible = flag;
                ctrl.Tag = lp;
                ctrl.TabIndex = index;
                if (lp.CtrlType.Contains("uc_gridcontrol"))
                {
                    (ctrl as uc_gridcontrol).InitCol(lp.ColumnName.Split(pchar));
                }
                index++;
                ctrl.Name = lp.LPID;
                dockPanel1.Controls.Add(label);
                dockPanel1.Controls.Add(ctrl);
                if (lp.CellName == "编号")
                {
                    ctrlNumber = ctrl;
                }
            }
            InitEvent();
            InitData();
            if (RecordWorkTask.HaveRunSPYJRole(parentTemple.Kind))
            {
                if (hqyjcontrol == null) hqyjcontrol = new SPYJControl();
                hqyjcontrol.Size = new System.Drawing.Size(400, 200);
                hqyjcontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
                currentPosY = currentPosY + hqyjcontrol.Size.Height;
                hqyjcontrol.RecordID = CurrRecord.ID;
                dockPanel1.Controls.Add(hqyjcontrol);
            }

            if(RecordWorkTask.HaveRunFuJianRole(parentTemple.Kind))
            {
                
                if (filecontrol==null) filecontrol = new DownFileControl();
                if(status=="add")
                filecontrol.FormType = "上传";
                else if (status == "edit")
                {
                    filecontrol.FormType = "下载";
                }
                filecontrol.Size = new System.Drawing.Size(400, 300);
                filecontrol.Location = new System.Drawing.Point(currentPosX, currentPosY + 10);
                currentPosY = currentPosY + filecontrol.Size.Height;
                filecontrol.UpfilePath = parentTemple.CellName;
                if (currRecord==null)
                {
                    currRecord = new LP_Record();
                }
                filecontrol.RecordID = CurrRecord.ID;
                dockPanel1.Controls.Add(filecontrol);
                currentPosY += 20;
            }
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
        void btn_Submit_Click(object sender, EventArgs e)
        {
            Excel.Workbook wb;
            Excel.Worksheet sheet;
            wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            sheet = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;
            activeSheetIndex = sheet.Index;
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
                        if (tmpSheet != null) tmpSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible ;
                    }
                    catch { }

                }
            }
            unLockExcel();
            for (int i = 1; sheet.Protection.AllowEditRanges.Count > 0; )
            {
                Excel.AllowEditRange editRange = sheet.Protection.AllowEditRanges.get_Item(i);
                editRange.Delete();
            }
            LockExcel();
            byte[] bt = new byte[0];
            string strmes = "";
            switch (status)
            {
                case "add":
                    //LP_Record newRecord = new LP_Record();
                    dsoFramerWordControl1.FileSave();
                    currRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
                    currRecord.Kind = kind;
                    currRecord.Content = GetContent();
                    if (ctrlNumber!=null)
                        currRecord.Number = ctrlNumber.Text; 
                    //currRecord.ImageAttachment = bt;
                    //currRecord.SignImg = bt;
                    currRecord.CreateTime = DateTime.Now.ToString();

                    string[] strtemp = RecordWorkTask.RunNewGZPRecord(currRecord.ID, kind, MainHelper.User.UserID);
                    strmes = strtemp[0];
                    currRecord.Status = strtemp[1];
                    if (strmes.IndexOf("未提交至任何人") > -1)
                    {
                        MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                        return;
                    }
                    else
                        MsgBox.ShowTipMessageBox(strmes);

                    MainHelper.PlatformSqlMap.Create<LP_Record>(currRecord);
                    rowData = null;
                    if (hqyjcontrol != null)
                    {
                        PJ_lcspyj lcyj = new PJ_lcspyj();
                        lcyj.Charman = MainHelper.User.UserName;
                        lcyj.ID = PJ_lcspyj.Newid();
                        lcyj.RecordID = currRecord.ID;
                        WorkFlowData=RecordWorkTask.GetRecordWorkFlowData(currRecord.ID, MainHelper.User.UserID);
                        lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                        lcyj.Creattime = DateTime.Now;
                        MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);
                    }
                    if (filecontrol != null)
                    {
                        for (int i = 0; i < filecontrol.FJtable.Rows.Count; i++)
                        {

                             PJ_lcfj lcfu = new PJ_lcfj();
                             lcfu.ID = lcfu.CreateID();
                             lcfu.Filename = Path.GetFileName(filecontrol.FJtable.Rows[i]["FilePath"].ToString());
                             lcfu.FileRelativePath =  filecontrol.FJtable.Rows[i]["SaveFileName"].ToString();
                             lcfu.FileSize = Convert.ToInt64(filecontrol.FJtable.Rows[i]["FileSize"]);
                             lcfu.RecordID = currRecord.ID;
                             lcfu.Creattime = DateTime.Now;
                             Thread.Sleep((new TimeSpan(100000)));//0.1毫秒
                             MainHelper.PlatformSqlMap.Create<PJ_lcfj>(lcfu);
                         }
                    
                    }
                    //currRecord = newRecord;
                    break;
                case "edit":
                    currRecord.LastChangeTime = DateTime.Now.ToString();
                    dsoFramerWordControl1.FileSave();
                    currRecord.DocContent = this.dsoFramerWordControl1.FileDataGzip;
                    //byte[] bt = new byte[0];
                    //currRecord.ImageAttachment = bt;
                    //currRecord.SignImg = bt;
                    currRecord.Content = GetContent();
                    WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    if (wt != null)
                    {
                        strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
                    }
                    else
                    {
                        strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(),  "提交");
                    }
                    if (strmes.IndexOf("未提交至任何人") > -1)
                    {
                        MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                        return;
                    }
                    else
                        MsgBox.ShowTipMessageBox(strmes);
                    strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
                    if (hqyjcontrol != null)
                    {
                        PJ_lcspyj lcyj = new PJ_lcspyj();
                        lcyj.Charman = MainHelper.User.UserName;
                        lcyj.ID = PJ_lcspyj.Newid();
                        lcyj.RecordID = currRecord.ID;
                        lcyj.taskID = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        lcyj.Spyj = hqyjcontrol.nowMemoEdit.Text;
                        lcyj.Creattime = DateTime.Now;
                        MainHelper.PlatformSqlMap.Create<PJ_lcspyj>(lcyj);

                    }
                    if (filecontrol != null)
                    {
                        for (int i = 0; i < filecontrol.FJtable.Rows.Count; i++)
                        {

                            PJ_lcfj lcfu = new PJ_lcfj();
                            lcfu.ID = lcfu.CreateID();
                            lcfu.Filename = Path.GetFileName(filecontrol.FJtable.Rows[i]["FilePath"].ToString());
                            lcfu.FileRelativePath = filecontrol.UpfilePath + "/" + filecontrol.FJtable.Rows[i]["SaveFileName"].ToString();
                            lcfu.FileSize = Convert.ToInt64(filecontrol.FJtable.Rows[i]["FileSize"]);
                            lcfu.RecordID = currRecord.ID;
                            lcfu.Creattime = DateTime.Now;
                            MainHelper.PlatformSqlMap.Create<PJ_lcfj>(lcfu);
                        }

                    }
                    if (strmes == "结束节点1")
                    {
                        CurrRecord.Status = "存档";
                    }
                    else
                    {
                        CurrRecord.Status = strmes;
                    }
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record",CurrRecord);
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
                        (ctrl as uc_gridcontrol).SetDs((ctrl as uc_gridcontrol).ConvertBetweenDataTableAndXML_AX(dict[lp.LPID]));
                    }
                    else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
                    {
                        (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = Convert.ToDateTime(dict[lp.LPID]);
                    }
                    else
                    {
                        if (dict.ContainsKey(lp.LPID))
                        ctrl.Text = dict[lp.LPID];
                    }
                    //ContentChanged(ctrl);
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
                if (ctrl.Tag != null&&(!tempCtrlList.Contains(ctrl)))
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
            unLockExcel();
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
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
                ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
            else if (arrCellpos.Length > 1 && (!string.IsNullOrEmpty(arrCellpos[1])))
            {

                StringHelper help = new StringHelper();
                if (lp.CellName == "编号")
                {
                    for (int j = 0; j < arrCellpos.Length; j++)
                    {
                        if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[j]))
                        {
                            string strNew = str.Substring(0, (str.Length>0?str.Length:1)- 1) + (j + 1).ToString();
                            ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);                            
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
                        return;
                    }
                    ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                        GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);

                    str = str.Substring(help.GetFristLen(str, arrCellCount[0]) >= str.IndexOf("\r\n") &&
                        str.IndexOf("\r\n") != -1 ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                    i++;
                }
                str = help.GetPlitString(str, arrCellCount[1]);
                FillMutilRows(ea, i, lp, str, arrCellCount, arrCellpos);

            }
            LockExcel();
        }
        void ctrl_Enter(object sender, EventArgs e)
        {
            unLockExcel();
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            if (dsoFramerWordControl1.MyExcel == null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            Excel.Worksheet xx = wb.Application.Sheets[1] as Excel.Worksheet;
            string[] arrCellpos = lp.CellPos.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            if (arrCellpos.Length > 1)
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
            LockExcel();
        }
        void ctrl_Leave(object sender, EventArgs e)
        {
             
            unLockExcel();
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            if (dsoFramerWordControl1.MyExcel==null)
            {
                return;
            }
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            ea.ActiveSheet(activeSheetName);
            if (lp.CtrlType.Contains("uc_gridcontrol"))
            { 
                FillTable(ea, lp, (sender as uc_gridcontrol).GetContent(String2Int(lp.WordCount.Split(pchar))));
                LockExcel();
                return; 
            }
            else if (lp.CtrlType.Contains("DevExpress.XtraEditors.DateEdit"))
            { 
                FillTime(ea, lp, (sender as DateEdit).DateTime);
                LockExcel();
                return;
            }            
            string[] arrCellpos = lp.CellPos.Split(pchar);
            string[] arrtemp = lp.WordCount.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            string[] extraWord = lp.ExtraWord.Split(pchar);  
            List<int> arrCellCount = String2Int(arrtemp);            
            if (arrCellpos.Length == 1||string.IsNullOrEmpty(arrCellpos[1]))
                ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
            else if(arrCellpos.Length>1&&(!string.IsNullOrEmpty(arrCellpos[1])))
            {
                StringHelper help = new StringHelper();
                if (lp.CellName == "编号")
                {
                    for (int j = 0; j < arrCellpos.Length; j++)
                    {
                        if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[j])&&str!="" )
                        {
                            string strNew = str.Substring(0, str.Length - 1) + (j + 1).ToString();
                            ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);
                        }
                    }
                    LockExcel();
                    return;
                }
                int i = 0;
                if (arrCellCount[0] != arrCellCount[1])
                {
                    if (str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[0]))
                    {
                        ea.SetCellValue(str, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
                        LockExcel();
                        return;
                    }
                    ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                        str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                        GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);

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
                    ctrlNumber.Text = strNumber;
                    //ContentChanged(ctrlNumber);
                }

            }

            LockExcel();
        }

        public void FillTable(ExcelAccess ea, LP_Temple lp, string[] content)
        {
            string[] arrCol = lp.CellPos.Split(pchar);
            arrCol = StringHelper.ReplaceEmpty(arrCol).Split(pchar);
            string[] arrtemp=lp.WordCount.Split(pchar);
            arrtemp = StringHelper.ReplaceEmpty(arrtemp).Split(pchar);
            List<int> arrCellCount = String2Int(arrtemp);
            for (int i = 0; i < arrCol.Length; i++)
            {
                if (string.IsNullOrEmpty(arrCol[i]))
                {
                    continue;
                }
                if(content[i]!=null)
                    FillMutilRowsT(ea, lp, content[i], arrCellCount[i], arrCol[i]);
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
                j++;
            }
        }

        public void FillTime(ExcelAccess ea, LP_Temple lp,DateTime dt)
        {
            string[] arrCellPos = lp.CellPos.Split(pchar);
            arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split(pchar);
            string[] extraWord = lp.ExtraWord.Split(pchar);         
            IList<string> strList=new List<string>();
            if (arrCellPos.Length == 5)
            { 
                strList.Add(dt.Year.ToString());strList.Add(dt.Month.ToString());
                strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            }
            else if (arrCellPos.Length == 4)
            {
                strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            }
            else if (arrCellPos.Length == 3)
            {
               // strList.Add(dt.Year.ToString()); strList.Add(dt.Month.ToString());
                strList.Add(dt.Day.ToString()); strList.Add(dt.Hour.ToString()); strList.Add(dt.Minute.ToString());
            }
            else if (arrCellPos.Length ==2)
            {
                strList.Add(dt.Hour.ToString());
                strList.Add(dt.Minute.ToString());
            }
            else if (arrCellPos.Length == 1)
            {
                strList.Add(dt.ToString());
            }
           // int i = 0;
            for (int i = 0; i < strList.Count;i++ )
            {
                if (extraWord.Length>i)
                {
                    ea.SetCellValue(strList[i] + extraWord[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                }
                else
                {
                    ea.SetCellValue(strList[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                }
                
            }
            //foreach (string str in strList)
            //{
            //    ea.SetCellValue(str, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
            //    i++;
            //}
        }

        public void FillMutilRowsT(ExcelAccess ea, LP_Temple lp, string str, int cellcount, string arrCellPos)
        {
            StringHelper help = new StringHelper();
            //str = help.GetPlitString(str, cellcount);
            string[] arrRst = str.Split(new string[] { "\r\n" },StringSplitOptions.None);
            for (int i=0; i < arrRst.Length; i++)
            {
                ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0] + i, GetCellPos(arrCellPos)[1]);
            }
        }

        public int[] GetCellPos(string cellpos)
        {
            cellpos = cellpos.Replace("|", "");          
            return new int[] { int.Parse(cellpos.Substring(1)), (int)cellpos[0] - 64 };
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
            if (lp.CtrlType.IndexOf(',') == -1)
                ctrltype = lp.CtrlType;
            else
                ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            switch (ctrltype)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Clear();     
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    if (sqlSentence!="")
                    {
                        try
                        {
                            IList list = ClientHelper.PlatformSqlMap.GetList(SplitSQL(sqlSentence)[0], SplitSQL(sqlSentence)[1]);
                            for (int i = 0; i < list.Count; i++)
                            {
                                ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.Add(list[i].GetType().GetProperty(lp.SqlColName).GetValue(list[i], null));
                            }
                        }
                        catch {
                            string sql = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sql);
                            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).Properties.Items.AddRange(list);
                            ((DevExpress.XtraEditors.ComboBoxEdit)ctrl).SelectedItem    = MainHelper.User.OrgName  ;
                        }
                        
                    }
                    string[] comBoxItem = lp.ComBoxItem.Split(pcomboxchar);
                    comBoxItem = StringHelper.ReplaceEmpty(comBoxItem).Split(pchar);
                    for (int i = 0; i < comBoxItem.Length;i++ )
                    {
                        if (comBoxItem[i]!="")
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
                            ctrlNumber.Text = strNumber;
                            //ContentChanged(ctrlNumber);
                        }                     

                    }
                    break;
                case "DevExpress.XtraEditors.DateEdit":
                    //((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "F";                  
                    ((DevExpress.XtraEditors.DateEdit)ctrl).DateTime = DateTime.Now;
                    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                    ((DevExpress.XtraEditors.DateEdit)ctrl).Properties.EditMask = "yyyy-MM-dd HH:mm";                   
                
                    break;
                case "DevExpress.XtraEditors.MemoEdit":
                    break;
                case "uc_gridcontrol":
                    ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence.Split(new char[]{pchar},StringSplitOptions.RemoveEmptyEntries), lp.SqlColName.Split(pchar),lp.ComBoxItem.Split(pchar));
                    break;
            }
           
        }

        public int CalcWidth()
        {
            int wordcount = 0;
            foreach (LP_Temple lp in templeList)
            {
                if (lp.CellName.Length > wordcount)
                    wordcount = lp.CellName.Length;
            }
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
                if (ctrl != null&&ctrl.Visible)
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
                    int pos = sqlSentence.IndexOf("@" + lpid);
                    if (pos != -1)
                    {
                        sqlSentence = sqlSentence.Remove(pos, ("@" + lpid).Length);
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
            //base.Close();
            currRecord = null;
            //rowData = null;
            dockPanel1.ControlContainer.Controls.Clear();
            templeList.Clear();
            try
            {
                    if (filecontrol != null)
                    {
                        
                        if (filecontrol.upThread.ThreadState == ThreadState.Running)
                        {
                            
                                filecontrol.upThread.IsBackground = true;
                                filecontrol.upThread.Abort();
                           
                        }
                        if (filecontrol.Isdownfile)
                        {

                            if (filecontrol.webClient!=null) filecontrol.webClient.CancelAsync();

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
    }
}
