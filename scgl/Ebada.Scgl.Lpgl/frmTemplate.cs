using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Reflection;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Scgl.WFlow;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace Ebada.Scgl.Lpgl
{
    public partial class frmTemplate : DevExpress.XtraEditors.XtraForm
    {
       // Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application(); //引用Excel对象
        string uid1 = "";
        string filename = "";
        string filepath = Path.GetTempPath();
        LP_Record _pjobject;
        private DataTable dt = null;//实例流程信息
        private LP_Temple parentTemple = null;

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public DataTable RecordWorkFlowData
        {
            get
            {

                return dt;
            }
            set
            {


                dt = value;


            }
        }
        public frmTemplate()
        {
            InitializeComponent();
        }
        public LP_Record pjobject
        {
            get
            {
                return _pjobject;
            }
            set
            {
                _pjobject = value;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认退回 ?") != DialogResult.OK)
            {
                return;
            }
            if (dt.Rows.Count > 0)
            {
                //if (!RecordWorkTask.HaveWorkFlowBackRole(dt.Rows[0]["WorkTaskId"].ToString(), dt.Rows[0]["WorkFlowId"].ToString()))
                //{
                //    MsgBox.ShowWarningMessageBox("当前节点不能退回.设置里没有允许退回，退回失败!");
                //    return;
                //}
                string strmes = RecordWorkTask.RunWorkFlowBack(MainHelper.User.UserID, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString());
                if (strmes.IndexOf("未提交至任何人") > -1)
                {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                else
                {

                    _pjobject.Status = RecordWorkTask.GetWorkFlowTaskCaption(dt.Rows[0]["WorkTaskInsId"].ToString());
                    MainHelper.PlatformSqlMap.Update("UpdateLP_Record", _pjobject);
                    MsgBox.ShowTipMessageBox(strmes);
                    this.DialogResult = DialogResult.OK;

                }
            }
            else
            {
                MsgBox.ShowTipMessageBox("无当前用户可以操作此记录的流程信息,退回失败!");
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
        /// <summary>
        ///设置保护工作表
        /// </summary>
        private void LockExcel(ExcelAccess ea)
        {
            Excel.Workbook wb = ea.MyWorkBook as Excel.Workbook;
            Excel.Worksheet xx = ea.MyExcel.ActiveSheet as Excel.Worksheet;
            xx.Protect("MyPassword", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing);
            xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
            wb.SheetBeforeDoubleClick += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
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
        private void unLockExcel(ExcelAccess ea)
        {
            try
            {
                Excel.Workbook wb = ea.MyWorkBook  as Excel.Workbook;
                Excel.Worksheet xx = ea.MyExcel.ActiveSheet   as Excel.Worksheet;
                xx.Unprotect("MyPassword");
                xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
                wb.SheetBeforeDoubleClick -= new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDoubleClickEventHandler(wb_SheetBeforeDoubleClick);
            }
            catch { }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
              SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = "";
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog1.FileName;
                try
                {
                    dsoFramerControl1.FileSave(saveFileDialog1.FileName, true);
                    ExcelAccess ea = new ExcelAccess();
                    ea.Open(fname);
                    char pchar = '|';
                    Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                    Excel.Worksheet xx = wb.Application.Sheets[1] as Excel.Worksheet;
                    IList<LP_Temple> templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", "where ParentID ='" + parentTemple.LPID + "' and isExplorer='1' Order by SortID");
                    LockExcel(ea);
                    unLockExcel( ea);

                    foreach (LP_Temple lp in templeList)
                    {
                        string[] arrCellpos = lp.CellPos.Split(pchar);
                        for (int i = 0; i < arrCellpos.Length && arrCellpos[i]!=""; i++)
                        {
                            ea.SetCellValue("", GetCellPos(arrCellpos[i])[0],GetCellPos(arrCellpos[i])[1]);
                        
                        }

                    }






                     LockExcel( ea);
                        ea.ShowExcel();
                        //Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application(); //引用Excel对象
                        //Microsoft.Office.Interop.Excel.Workbook book = exc.Application.Workbooks.Add(fname); //引用Excel工作簿
                        //exc.Visible = true; //使Excel可视
                        return;
                    
                   
                }
                catch
                {
                   
                    MsgBox.ShowSuccessfulMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                    return;
                }
            }
        }
       

        private void frm26Template_Load(object sender, EventArgs e)
        {
            //string fname = filepath + Guid.NewGuid().ToString() + ".xls";
            //filename = fname;
            //fname = Application.StartupPath + "\\00记录模板\\24设备变更通知书.xls";
            if (pjobject.Status != "安监审核")
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if (pjobject.DocContent ==null)
            {
                return;
            }
            else
            {
                if (pjobject.DocContent .Length!=0)
                {
                    dsoFramerControl1.FileDataGzip  = pjobject.DocContent ;
                }
                else
                {
                    return;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //dsoFramerControl1.FileSave();
            //pjobject.BigData = dsoFramerControl1.FileData;
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            workFlowRun();
            this.DialogResult = DialogResult.OK;
        }

        private void frm24Template_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dsoFramerControl1 != null)
            {
                dsoFramerControl1.FileClose();
                dsoFramerControl1.Dispose();
                dsoFramerControl1 = null;
            }
        }
        private void workFlowRun()
        {
            string strmes = "";
            WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + dt.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + dt.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null)
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            }
            else
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, dt.Rows[0]["OperatorInsId"].ToString(), dt.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(dt.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                pjobject.Status = "存档";
            }
            else
            {
                pjobject.Status = strmes;
            }
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", pjobject);
        
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            workFlowRun();
            this.DialogResult = DialogResult.OK;
        }

    }
}