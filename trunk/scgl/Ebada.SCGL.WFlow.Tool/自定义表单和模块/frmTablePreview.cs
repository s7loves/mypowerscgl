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
using DevExpress.XtraGrid.Views.Base;
using System.Threading;
using System.Text.RegularExpressions;
using Ebada.Scgl.Core;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class frmTablePreview : Form,IPopupFormEdit
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
        private Control ctrlOrgName = null;
        private string activeSheetName = "";
        private int activeSheetIndex = 1;

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
        public frmTablePreview()
        {
            InitializeComponent();
        }
        Hashtable bhht = new Hashtable();
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
        private void LockExcel(Excel.Workbook wb, Excel.Worksheet xx)
        {

            //try
            //{

            //xx.Protect("MyPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing);
            //xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
            //wb.SheetBeforeDoubleClick += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            ////wb.SheetDeactivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetDeactivateEventHandler(Workbook_SheetDeactivate);
            ////wb.SheetActivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetActivateEventHandler(Workbook_SheetActivate);
            ////wb.SheetSelectionChange  += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetSelectionChangeEventHandler(Workbook_SheetSelectionChange);  }
            //catch { }
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
            //try
            //{


            //    xx.Unprotect("MyPassword");
            //    xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
            //    wb.SheetBeforeDoubleClick -= new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            //}
            //catch { }
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
        private void LPFrm_Load(object sender, EventArgs e)
        {
            if (tempCtrlList==null)
            {
                tempCtrlList = new List<Control>();
            }
            //InitializeComponent();
            InitIndex();            
                //InitContorl();

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
            if (status == "add" && parentTemple.DocContent != null && parentTemple.DocContent.Length > 0)
            {              
                this.dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;            
                InitContorl();
            }
            else if (status == "edit" && currRecord.DocContent != null && currRecord.DocContent.Length > 0)
            {
                this.dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
                if (parentTemple != null)
                    InitContorl();               
                LoadContent();
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
            if (MaxWordWidth < 300)
            {
                MaxWordWidth = 300;
            } try
            {
                foreach (LP_Temple lp in templeList)
                {
                    bool flag = (lp.Status == CurrRecord.Status);
                    flag = true;
                    Label label = new Label();
                    label.Text = lp.CellName;
                    ComboBoxEdit btTip = null;
                    CheckEdit ceTip = null;
                    //string[] location = lp.CtrlLocation.Split(',');
                    string[] size = lp.CtrlSize.Split(',');
                    label.Location = new Point(currentPosX, currentPosY);
                    label.Size = new Size(MaxWordWidth, 14);
                    label.Visible = flag;
                    if (flag)
                    {
                        currentPosY += 20;
                    }
                    if (lp.CtrlType.Contains("MemoEdit") && flag && lp.SqlSentence != "")
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
                        if (lp.CtrlType.Contains("TextEdit") && flag && lp.SqlSentence != "")
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
                        ((uc_gridcontrol)ctrl).CellValueChanged += new CellValueChangedEventHandler(gridView1_CellValueChanged);
                        ((uc_gridcontrol)ctrl).FocusedColumnChanged += new FocusedColumnChangedEventHandler(gridView1_FocusedColumnChanged);
                    }
                    else
                        ctrl = (Control)Activator.CreateInstance(Type.GetType(lp.CtrlType));
                    ctrl.Location = new Point(currentPosX, currentPosY);
                    if (size[0] != "" && size[1] != "")
                        ctrl.Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                    else
                    {
                        ctrl.Size = new Size(200, 20);
                        size[0] = "200";
                        size[1] = "20";

                    }
                    if (flag)
                    {
                        currentPosY += int.Parse(size[1]) + 10;
                    }


                    ctrl.TextChanged += new EventHandler(ctrl_Leave);
                    ctrl.Leave += new EventHandler(ctrl_Leave);
                    ctrl.Enter += new EventHandler(ctrl_Enter);
                    ctrl.Visible = flag;
                    ctrl.Tag = lp;
                    ctrl.TabIndex = index;
                    index++;
                    if (btTip != null)
                    {
                        btTip.TabIndex = index;
                        index++;
                        btTip.TextChanged += new EventHandler(btTip_Click);
                    }
                    if (lp.CtrlType.Contains("uc_gridcontrol"))
                    {
                        (ctrl as uc_gridcontrol).InitCol(lp.ColumnName.Split(pchar), lp);
                    }
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
                    if (lp.CellName == "单位")
                    {
                        ctrlOrgName = ctrl;
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
                InitEvent();
                InitData();
            }
            catch { }
            Button btn_Submit = new Button();
            btn_Submit.TabIndex = index;
            index++;
            dockPanel1.Controls.Add(btn_Submit);
            btn_Submit.Location = new Point(currentPosX, currentPosY + 10);
            btn_Submit.Click += new EventHandler(btn_Submit_Click);
            btn_Submit.Text = "关闭";
            if (dockPanel1.ControlContainer.Controls.Count > 0)
                dockPanel1.ControlContainer.Controls[0].Focus();
        }
      
        void btn_Submit_Click(object sender, EventArgs e)
        {
            //dsoFramerWordControl1.FileSave();
            //dsoFramerWordControl1.FileClose();
            this.DialogResult = DialogResult.OK;
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ctrl_Leave(sender, e);

        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {


            LP_Temple lp = (LP_Temple)(sender as  Control).Tag;
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
            int i = e.FocusedColumn.VisibleIndex,j=Convert.ToInt32( e.FocusedColumn.Tag);
            if (i > arrCellpos.Length || i < 0) i = 0;
            if (j< 0) j = 0;
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

                    range = (Excel.Range)xx.get_Range(xx.Cells[GetCellPos(arrCellpos[i])[0]+j,
                    GetCellPos(arrCellpos[i])[1]],
                    xx.Cells[GetCellPos(arrCellpos[i])[0] + j, GetCellPos(arrCellpos[i])[1]]);
                }
                range.Select();
                bool isfind = false;
                for ( i = 1; i <= xx.Protection.AllowEditRanges.Count; i++)
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
                        ctrl.Text = dict[lp.LPID];
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
                if (ctrl.Tag != null && (!tempCtrlList.Contains(ctrl)))
                {
                    if (ctrl.Name.IndexOf("bt") > -1)
                        continue;
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
            LockExcel(wb, sheet);
        }
        void btTip_Click(object sender, EventArgs e)
        {
            LP_Temple lp = (LP_Temple)(sender as Control).Tag;
            string str = (sender as Control).Text;
            Control ct = FindCtrl(lp.LPID);
            Control ce = FindCtrl("ce"+lp.LPID);
            if (ct != null && ct.Text.IndexOf(str) == -1)
            {
                if (lp.CellName.Replace(" ", "").Substring(lp.CellName.Replace(" ", "").Length - 1) == "人"
                    || lp.CellName.Replace(" ", "").IndexOf("人员")>-1 
                    || lp.CellName.Replace(" ", "").IndexOf("成员")>-1)
                {
                    if (ct.Text == "" || !((CheckEdit)ce).Checked)
                        ct.Text = str;
                    else
                        ct.Text += "，" + str;
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
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            if (lp.KindTable != "")
            {
                ea.ActiveSheet(lp.KindTable);
            }
            else
            {
                ea.ActiveSheet(1);
            }
            unLockExcel(wb, xx);
            if (lp.CellPos == "")
            {
                if (lp.CellName.IndexOf("简图") > -1)
                {

                    PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + str + "'");
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
                return;
            }
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
            if (lp.CellPos == "")
            {
                if (lp.CellName.IndexOf("简图") > -1)
                {

                    PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + str + "'");
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
                    DataObject   dataObject   =   new   DataObject();
                    dataObject.SetData(DataFormats.Bitmap, bt);
                    Clipboard.SetDataObject(dataObject, true);

                }
                return;
            }
            if (dsoFramerWordControl1.MyExcel == null)
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
            unLockExcel(wb, xx);
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
                FillDoubleValue(ea, lp, (sender as SpinEdit));
                LockExcel(wb, xx);
                return;
            }
            string[] arrCellpos = lp.CellPos.Split(pchar);
            string[] arrtemp = lp.WordCount.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            //string[] extraWord = lp.ExtraWord.Split(pchar);
            string value=lp.ExtraWord;
            if (lp.ExtraWord == "合同编号")
            {
                for (int j = 0; j < arrCellpos.Length; j++)
                {
                    if (str.Length > j)
                    {
                        string strNew = str.Substring(j, 1);
                        ea.SetCellValue(strNew, GetCellPos(arrCellpos[j])[0], GetCellPos(arrCellpos[j])[1]);
                    }
                    else
                        break;

                }
                LockExcel(wb, xx);
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
            List<int> arrCellCount = String2Int(arrtemp);
            if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
            {
                
                    ea.SetCellValue(str, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);
              

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
                           
                        }
                    }
                    LockExcel(wb, xx);
                    return;
                }
                int i = 0;
                //if (arrCellCount.Count > 1 && arrCellCount[0] != arrCellCount[1])
                if (arrCellCount.Count>1)
                {

                    if ((lp.CtrlType.IndexOf("uc_gridcontrol") == -1  && str.Length <= help.GetFristLen(str, arrCellCount[i])) || (lp.CtrlType.IndexOf("uc_gridcontrol") > -1 && str.IndexOf("\r\n") == -1 && str.Length <= help.GetFristLen(str, arrCellCount[i])))
                    {
                        ea.SetCellValue(str, GetCellPos(arrCellpos[i])[0], GetCellPos(arrCellpos[i])[1]);
                      

                        LockExcel(wb, xx);
                        return;
                    }
                    if (lp.CtrlType.IndexOf("uc_gridcontrol") > -1)
                    {
                        ea.SetCellValue(str.Substring(0, str.IndexOf("\r\n") != -1 && help.GetFristLen(str, arrCellCount[0]) >=
                            str.IndexOf("\r\n") ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0])),
                            GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);

                        str = str.Substring(help.GetFristLen(str, arrCellCount[0]) >= str.IndexOf("\r\n") &&
                            str.IndexOf("\r\n") != -1 ? str.IndexOf("\r\n") : help.GetFristLen(str, arrCellCount[0]));
                        i++;
                        str = help.GetPlitString(str, arrCellCount[1]);
                    }
                    else
                    {
                        int i1 = str.IndexOf("\r\n");
                        if(i1>help.GetFristLen(str, arrCellCount[0]))
                        i1=help.GetFristLen(str, arrCellCount[0]);
                        if (i1 == -1)
                            i1 = help.GetFristLen(str, arrCellCount[0]);
                        if (str.Length > i1 + 1 && (str.Substring(i1, 1) == "，" || str.Substring(i1, 1) == "。" || str.Substring(i1 + 1, 1) == "、" || str.Substring(i1 + 1, 1) == "：" || str.Substring(i1 + 1, 1) == "！"))
                        {
                            i1 = i1 + 1;
                        }
                        ea.SetCellValue(str.Substring(0, i1), GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);

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
                    switch (kind)
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
                        default:
                            strNumber = list[0].ToString().Substring(list[0].ToString().Length - 2, 2) + System.DateTime.Now.Year.ToString();
                            break;
                    }
                    IList listLPRecord = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select ControlValue from WF_TableFieldValue where  FieldName='编号' and UserControlId='{0}' and ControlValue like '" + strNumber + "%' and id like '" + DateTime.Now.Year + "%' order by id desc", parentTemple.LPID));
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
                        if (listLPRecord.Count == 0)
                            strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                        else
                        {
                            decimal udw = Convert.ToDecimal(listLPRecord[0].ToString().Substring(listLPRecord[0].ToString().Length - 3));
                            strNumber = listLPRecord[0].ToString().Substring(0, listLPRecord[0].ToString().Length - 3) + (udw + 1).ToString().PadLeft(3, '0');
                        }
                        //strNumber += (listLPRecord.Count + 1).ToString().PadLeft(3, '0');
                    }
                    if (ctrlNumber != null) ctrlNumber.Text = strNumber;
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
            List<int> arrCellCount = String2Int(arrtemp);
            for (int i = 0; i < arrCol.Length; i++)
            {
                if (string.IsNullOrEmpty(arrCol[i]))
                {
                    continue;
                }
                if (content.Length>i&&content[i] != null)
                    FillMutilRowsT(ea, lp, content[i], arrCellCount[i], arrCol[i]);
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
                    ea.SetCellValue(arrRst[j], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);

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
                        i1 = help.GetFristLen(strarrRst, arrCellCount[i]);
                    if (strarrRst.Length>i1+1&&(strarrRst.Substring(i1, 1) == "，" || strarrRst.Substring(i1, 1) == "。" || strarrRst.Substring(i1 + 1, 1) == "、" || strarrRst.Substring(i1 + 1, 1) == "：" || strarrRst.Substring(i1 + 1, 1) == "！"))
                    {
                        i1=i1 + 1;
                    }
                    //if (strarrRst.Length <= help.GetFristLen(str, arrCellCount[i]))
                    //{
                    //    ea.SetCellValue(strarrRst, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                    //    break;
                    //}
                    //else
                    {

                        if (strarrRst.Length >= i1)
                        {
                            ea.SetCellValue(strarrRst.Substring(0, i1), GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                            strarrRst = strarrRst.Substring(i1);
                        }
                        else
                        {
                            ea.SetCellValue(strarrRst, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                            strarrRst = "";
                        }

                        
                        
                        //strarrRst = help.GetPlitString(strarrRst, arrCellCount[i]);
                    }
                    
                    if (strarrRst.Length == 0) break;
                   
                }
            }
        }
        public void FillDoubleValue(ExcelAccess ea, LP_Temple lp, SpinEdit se)
        {
            string[] arrCellpos = lp.CellPos.Split(pchar);
            arrCellpos = StringHelper.ReplaceEmpty(arrCellpos).Split(pchar);
            string[] extraWord = lp.ExtraWord.Split(pchar);
            IList<string> strList = new List<string>();
            if (arrCellpos.Length == 1 || string.IsNullOrEmpty(arrCellpos[1]))
            {
                ea.SetCellValue(se.Text, GetCellPos(lp.CellPos)[0], GetCellPos(lp.CellPos)[1]);

            }
            else if (arrCellpos.Length > 1 && (!string.IsNullOrEmpty(arrCellpos[1])))
            {
               
                ea.SetCellValue(se.Text, GetCellPos(arrCellpos[0])[0], GetCellPos(arrCellpos[0])[1]);
            }
        }
    
        public void FillTime(ExcelAccess ea, LP_Temple lp, DateTime dt)
        {
            string[] arrCellPos = lp.CellPos.Split(pchar);
            arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split(pchar);
            string[] extraWord = lp.ExtraWord.Split(pchar);
            IList<string> strList = new List<string>();
            
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
                    //strList.Add(dt.Year.ToString());
                    //strList.Add(dt.Month.ToString());
                    //strList.Add(dt.Day.ToString());
                    //strList.Add(dt.Hour.ToString());
                    //strList.Add(dt.Minute.ToString());
                    break;
            }
            // int i = 0;
            string value = lp.ExtraWord;
            //value = "{0}年{1}月{2}日";
            for (int i = 0; i < strList.Count; i++)
            {
           
                if (lp.ExtraWord == "")
                {
                    if (dt.ToString("yyyyMMdd") == "00010101")
                    {
                        strList[i] = " ";
                    }

                    if (arrCellPos.Length > 1)
                        ea.SetCellValue(strList[i], GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
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
                            if (strList.Count == i+1)
                            ea.SetCellValue(value, GetCellPos(arrCellPos[0])[0], GetCellPos(arrCellPos[0])[1]);
                    }
                }
                else
                {
                    if (lp.ExtraWord.IndexOf("|") == -1)
                    {
                        value = value.Replace("{" + i + "}", strList[i]);
                        if (i == strList.Count - 1)
                        {
                            ea.SetCellValue(value, GetCellPos(arrCellPos[0])[0], GetCellPos(arrCellPos[0])[1]);
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
                        ea.SetCellValue(value, GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]);
                       
                    }
                }
                   
               

            }

         
        }

        public void FillMutilRowsT(ExcelAccess ea, LP_Temple lp, string str, int cellcount, string arrCellPos)
        {
            StringHelper help = new StringHelper();
            //str = help.GetPlitString(str, cellcount);
            string[] arrRst = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (lp.ExtraWord == "横向")
            {
                for (int i = 0; i < arrRst.Length; i++)
                {
                    ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0], GetCellPos(arrCellPos)[1] + i);

                }
            }
            else
            {
                for (int i = 0; i < arrRst.Length; i++)
                {
                    ea.SetCellValue(arrRst[i], GetCellPos(arrCellPos)[0] + i, GetCellPos(arrCellPos)[1]);

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
            //return new int[] { int.Parse(cellpos.Substring(1)), (int)cellpos[0] - 64 };
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

        public static string CreatWorkFolwNo(mOrg org, string parentID, string kind)
        {
            string number = "";
            IList<WF_TableFieldValueView> datalist = null;
            switch (kind)
            {
                case "编号规则一":
                    datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<WF_TableFieldValueView>(
               " where FieldName='编号' and UserControlId='" + parentID + "' and ControlValue like '%" + org.OrgCode.Substring(org.OrgCode.Length - 2) + "-%' order by Number desc");
                    if (datalist.Count > 0)
                    {
                        string stri = datalist[0].Number.Substring(datalist[0].Number.Length - 3);
                        number = org.OrgCode.Substring(org.OrgCode.Length - 2) + string.Format("-{0:D3}", Convert.ToInt32(stri) + 1);
                    }
                    else
                    {

                        number = org.OrgCode.Substring(org.OrgCode.Length - 2) + "-001";
                    }

                    break;
                default:
                    datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<WF_TableFieldValueView>(
                        " where FieldName='编号' and UserControlId='" + parentID + "' and ControlValue like '%" +
                        DateTime.Now.ToString("yyyyMMdd") + org.OrgCode + "%' order by Number desc");

                    if (datalist.Count > 0)
                    {
                        string stri = datalist[0].Number.Substring(datalist[0].Number.Length - 3);
                        number = DateTime.Now.ToString("yyyyMMdd") + org.OrgCode + string.Format("{0:D4}", Convert.ToInt32(stri) + 1);
                    }
                    else
                    {

                        number = DateTime.Now.ToString("yyyyMMdd") + org.OrgCode + "0001";
                    }
                    break;
            }
            return number;
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
                string cellpos = sqlSentence.Substring(index1+1);
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
            else if (sqlSentence!= "")
            {
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}",currRecord.ID);
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
                    string sortid=r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count >0)
                    {
                       Control ct= FindCtrl(listLPID[0].LPID);
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
                                sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", CreatWorkFolwNo(list[0], listLPID[0].ParentID, "编号规则一"));
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
                catch(Exception ex)
                {
                    li.Add( "出错:" + ex.Message);
                }
            }
            switch (ctrltype)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    if (li.Count > 0 && sqlSentence != "")
                    {
                        //((DevExpress.XtraEditors.TextEdit)ctrl).Text = li[0].ToString();
                        Control bttip = FindCtrl("bt"+lp.LPID);
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
                    //if (li.Count > 0 && sqlSentence != "")
                    //    ((DevExpress.XtraEditors.DateEdit)ctrl).Text = li[0].ToString();
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
                    ((uc_gridcontrol)ctrl).InitData(lp.SqlSentence, lp.SqlColName.Split(pchar), lp.ComBoxItem.Split(pchar),dsoFramerWordControl1,lp,currRecord);
                    break;
            }
            if (lp.CellName == "编号") strNumber = ctrl.Text;
            if (ctrlNumber != null && strNumber!="") ctrlNumber.Text = strNumber;
        }

        public int CalcWidth()
        {
            int wordcount = 0;

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
                if (lp.AffectLPID != null && lp.AffectLPID!="")
                {

                    string  strlpid = lp.AffectLPID;
                    string[] arrLPID = strlpid.Split(pchar);
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
                        //if (!ctrlTemp.Visible)
                        //{
                        //    continue;
                        //}
                        if (ctrlTemp==null)
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
                //if (ctrl != null && ctrl.Visible)
                
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
                    int pos = sqlSentence.IndexOf("{" + lpid+"}");
                    if (pos != -1)
                    {
                        sqlSentence = sqlSentence.Remove(pos, ("{" + lpid+"}").Length);
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
                    sqlSentence = sqlSentence.Replace("{recordid}",currRecord.ID);
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
            //base.Close();
            currRecord = null;
            //rowData = null;
            //dockPanel1.ControlContainer.Controls.Clear();
            //templeList.Clear();
            dsoFramerWordControl1.FileSave();
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.Dispose();
        }

        private void frmLP_FormClosing(object sender, FormClosingEventArgs e)
        {
            
           
        }
    }
}
