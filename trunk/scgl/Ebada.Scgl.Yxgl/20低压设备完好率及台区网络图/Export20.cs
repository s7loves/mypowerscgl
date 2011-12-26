using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Scgl.Core;
using Ebada.Client.Platform;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using DevExpress.XtraEditors;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export20  {
        public static void ExportExcelAll(string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\20低压设备完好率及台区网络图";
            //Ecommon.WriteDoc(obj.BigData,ref fname);


            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                DSOFramerControl ds1 = new DSOFramerControl();
               
                fname = saveFileDialog1.FileName;
                try
                {
                    ;
                    IList<LP_Temple> templeList = null;
                    LP_Temple parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where ParentID not in (select LPID from LP_Temple where 1=1) and  CellName like '%低压线路完好率及台区网络图%'");
                    if (parentTemple != null)
                    {
                        ds1.FileDataGzip = parentTemple.DocContent;
                        Excel.Workbook wb = ds1.AxFramerControl.ActiveDocument as Excel.Workbook;
                        ExcelAccess ea = new ExcelAccess();
                        ea.MyWorkBook = wb;
                        ea.MyExcel = wb.Application;

                        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                            "where ParentID ='" + parentTemple.LPID + "' order by SortID");

                        string valEX = @"[0-9]+(\.)?[0-9]+";//只允许整数或小数的正则表达式
                        int i = 0;
                        ArrayList al = new ArrayList();
                        Excel.Worksheet xx;
                        for (i = 1; i <= wb.Application.Sheets.Count; i++)
                        {
                            xx = wb.Application.Sheets[i] as Excel.Worksheet;
                            if (!al.Contains(xx.Name)) al.Add(xx.Name);
                        }
                        string activeSheetName = "";
                        string filter = " where 1=1 ";
                        if (orgid != "") filter += " and OrgCode='" + orgid+ "'";
                        IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(filter);
                        string strtqcode="";
                        foreach (PS_xl xl in xlList)
                        {
                            IList<PS_tq> tqList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where left(tqcode,{0})='{1}'", xl.LineCode.Length, xl.LineCode));
                            foreach (PS_tq tq in tqList)
                            {
                                if (strtqcode != "")
                                {
                                    strtqcode += "or  WorkflowId='" + tq.tqCode + "' ";
                                }
                                else
                                {
                                    strtqcode = " and ( WorkflowId='"+tq.tqCode+"' ";
                                }
                            }
                        }
                        if (strtqcode != "")
                        {
                            strtqcode += ")";
                        }
                        foreach (LP_Temple lp in templeList)
                        {
                            IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                            " where   UserControlId='" + parentTemple.LPID + "'  and WorkTaskInsId='20低压设备完好率及台区网络图'"
                            + " and  FieldId='" + lp.LPID + "' " + strtqcode
                            + " order by YExcelPos");
                            object obj = null;
                            double sum = 0;
                            int idw = 1;
                            if (lp.isExplorer == 1)
                            {
                                continue;
                            }

                            foreach (WF_TableFieldValue tfv in tfvli)
                            {
                                WF_TableFieldValue tfvtemp = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(
                                " where   UserControlId='" + parentTemple.LPID + "'"
                                + " and   WorkflowId='" + tfv.WorkFlowId + "'"
                                + " and   RecordId='" + tfv.RecordId + "'"
                                + " and   FieldName='类型'"
                                + " and WorkTaskInsId='20低压设备完好率及台区网络图'"
                                + " order by YExcelPos");
                                if (tfvtemp != null && tfvtemp.ControlValue == "新增")
                                    idw = 1;
                                else
                                    if (tfvtemp != null && tfvtemp.ControlValue == "减少")
                                        idw = -1;
                                    else
                                        idw = 1;

                                if (tfv.FieldName.IndexOf("时间") == -1 && lp.IsVisible == 0)
                                {
                                    valEX = "^[0-9]+(\\.)?[0-9]+";
                                    if (tfv.ControlValue == "" || Regex.Match(tfv.ControlValue, valEX).Value != "")
                                    {
                                        if (tfv.ControlValue == "")
                                            sum += 0;
                                        else
                                            sum += idw * Convert.ToDouble(tfv.ControlValue);
                                        obj = sum;
                                    }
                                    else
                                    {
                                        obj = tfv.ControlValue;
                                        break;
                                    }
                                }
                                else
                                {
                                    obj = tfv.ControlValue;
                                    break;
                                }
                            }
                            if (!al.Contains(lp.KindTable))
                            {
                                continue;
                            }

                            if (activeSheetName != lp.KindTable)
                            {
                                if (activeSheetName != "")
                                {

                                    xx = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;


                                }
                                xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;

                                activeSheetName = lp.KindTable;

                                ea.ActiveSheet(xx.Index);
                            }
                            if (obj != null && tfvli.Count > 0 && tfvli[0].XExcelPos > 0 && tfvli[0].XExcelPos > 0)
                                ea.SetCellValue(obj.ToString(), tfvli[0].XExcelPos, tfvli[0].YExcelPos);




                        }
                        ds1.FileSave(fname, true);
                        ds1.FileClose();
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                            return;
                    }

                    System.Diagnostics.Process.Start(fname);
                }
                catch (Exception mex)
                {
                    Console.WriteLine(mex.Message);
                    MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");

                }
            }
            
        }
        public static void ExportExcelTQ(string tqCode)
        {
             ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname =Application.StartupPath + "\\00记录模板\\20低压设备完好率及台区网络图";
            //Ecommon.WriteDoc(obj.BigData,ref fname);
            
            
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                DSOFramerControl ds1 = new DSOFramerControl();
                fname = saveFileDialog1.FileName;
                try
                {;
                IList<LP_Temple> templeList = null;
                    LP_Temple parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where ParentID not in (select LPID from LP_Temple where 1=1) and  CellName like '%低压线路完好率及台区网络图%'");
                    if (parentTemple != null)
                    {
                        ds1.FileDataGzip = parentTemple.DocContent;
                        Excel.Workbook wb = ds1.AxFramerControl.ActiveDocument as Excel.Workbook;
                        ExcelAccess ea = new ExcelAccess();
                        ea.MyWorkBook = wb;
                        ea.MyExcel = wb.Application;

                        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                            "where ParentID ='" + parentTemple.LPID + "' order by SortID");
                        
                        string valEX = @"[0-9]+(\.)?[0-9]+";//只允许整数或小数的正则表达式
                        int i=0;
                        ArrayList al = new ArrayList();
                        Excel.Worksheet xx;
                        for (i = 1; i <= wb.Application.Sheets.Count; i++)
                        {
                            xx = wb.Application.Sheets[i] as Excel.Worksheet;
                            if (!al.Contains(xx.Name)) al.Add(xx.Name);
                        }
                        string activeSheetName = "";
                        foreach (LP_Temple lp in templeList)
                        {
                            IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                            " where   UserControlId='" + parentTemple.LPID + "' and   WorkflowId='" + tqCode + "' and WorkTaskInsId='20低压设备完好率及台区网络图'"
                            + " and  FieldId='"+lp.LPID+"' "
                            +" order by YExcelPos");
                            object obj = null;
                            double sum = 0;
                            int idw = 1;
                            if (lp.isExplorer == 1)
                            {
                                continue;
                            }
                         
                            foreach (WF_TableFieldValue tfv in tfvli)
                            {
                                WF_TableFieldValue tfvtemp = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(
                                " where   UserControlId='" + parentTemple.LPID+"'"
                                + " and   WorkflowId='" + tqCode + "'"
                                + " and   RecordId='" + tfv.RecordId + "'"
                                + " and   FieldName='类型'"
                                +" and WorkTaskInsId='20低压设备完好率及台区网络图'"
                                + " order by YExcelPos");
                                if (tfvtemp != null && tfvtemp.ControlValue == "新增")
                                    idw = 1;
                                else
                                    if (tfvtemp != null && tfvtemp.ControlValue == "减少")
                                        idw = -1;
                                    else
                                        idw = 1;

                                if (tfv.FieldName.IndexOf("时间") == -1&&lp.IsVisible==0)
                                {
                                    valEX = "^[0-9]+(\\.)?[0-9]+";
                                    if (tfv.ControlValue == "" || Regex.Match(tfv.ControlValue, valEX).Value!="")
                                    {
                                        if (tfv.ControlValue == "")
                                            sum += 0;
                                        else
                                            sum += idw * Convert.ToDouble(tfv.ControlValue);
                                        obj = sum;
                                    }
                                    else
                                    {
                                        obj = tfv.ControlValue;
                                        break;
                                    }
                                }
                                else
                                {
                                    obj = tfv.ControlValue;
                                    break;
                                }
                            }
                            if (!al.Contains(lp.KindTable))
                            {
                                continue;
                            }
                               
                                if (activeSheetName != lp.KindTable)
                                {
                                    if (activeSheetName != "")
                                    {

                                        xx = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;


                                    }
                                    xx = wb.Application.Sheets[lp.KindTable] as Excel.Worksheet;

                                    activeSheetName = lp.KindTable;

                                    ea.ActiveSheet(xx.Index);
                                }
                                if (obj != null && tfvli.Count > 0 && tfvli[0].XExcelPos > 0 && tfvli[0].XExcelPos>0)
                                    ea.SetCellValue(obj.ToString(), tfvli[0].XExcelPos, tfvli[0].YExcelPos);

                                       


                        }
                        ds1.FileSave(fname, true);
                        ds1.FileClose();
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                            return;
                    }

                    System.Diagnostics.Process.Start(fname);
                }
                catch (Exception mex)
                {
                    Console.WriteLine(mex.Message);
                    MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");

                }
            }
            //此处写填充内容代码


        }
        private static void unLockExcel(Excel.Workbook wb, Excel.Worksheet xx)
        {
            try
            {


                xx.Unprotect("MyPassword");
                xx.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
              
            }
            catch { }
        }
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_20 obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname =Application.StartupPath + "\\00记录模板\\20低压设备完好率及台区网络图";
            //Ecommon.WriteDoc(obj.BigData,ref fname);
            
            
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog1.FileName;
                try
                {

                    DSOFramerControl ds1 = new DSOFramerControl();

                    ds1.FileDataGzip = obj.BigData;
                    ds1.FileSave(fname, true);
                    ds1.FileClose();
                    if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                        return;

                    System.Diagnostics.Process.Start(fname);
                }
                catch (Exception mex)
                {
                    Console.WriteLine(mex.Message);
                    MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");

                }
            }
            //此处写填充内容代码

           
        }
      
    }
}
