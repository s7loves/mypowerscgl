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
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\20低压设备完好率及台区网络图";
            //Ecommon.WriteDoc(obj.BigData,ref fname);
            ExcelAccess ea = new ExcelAccess();

            //saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LP_Temple parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and  CellName like '%低压线路完好率及台区网络图%'");
                LP_Temple lp2 = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + parentTemple.LPID + "' and SortID=1");
                WF_TableFieldValue wfv = new WF_TableFieldValue();
                //wfv.ID = wfv.CreateID();
                //wfv.WorkFlowId = tqCode;
                //wfv.WorkTaskId = "20低压设备完好率及台区网络图";
                //wfv.WorkTaskInsId = "20低压设备完好率及台区网络图";
                //wfv.UserControlId = parentTemple.LPID;
                //wfv.ControlValue = "";
                //wfv.FieldId = lp2.LPID;

                if (orgid != "")
                    wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                                     + " and   WorkflowId like '" + orgid + "%'"
                                     + " and   UserControlId='" + parentTemple.LPID + "'"
                                     + " and   fieldname='" + lp2.CellName + "'"
                                     + " and   FieldId='" + lp2.LPID + "' and Bigdata is not null"
                                    );
                else
                {
                    wfv = null;
                }
                DSOFramerControl ds1 = new DSOFramerControl();
               
                //fname = saveFileDialog1.FileName;
                try
                {
                    
                    IList<LP_Temple> templeList = null;
                    parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where   ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and  CellName like '%低压线路完好率及台区网络图%'");
                    if (parentTemple != null)
                    {
                        if (wfv != null && wfv.Bigdata != null && wfv.Bigdata.Length > 0)
                            ds1.FileDataGzip = wfv.Bigdata;
                        else
                            ds1.FileDataGzip = parentTemple.DocContent;
                        fname = ds1.FileName;
                            //ds1.FileSave(fname, true);
                            ds1.FileClose();
                        ea.Open(fname);

                        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                            "where ParentID ='" + parentTemple.LPID + "' order by SortID");

                        string valEX = @"[0-9]+(\.)?([0-9]+)?$";//只允许整数或小数的正则表达式
                        int i = 0;
                        ArrayList al = new ArrayList();
                        
                       
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
                        Hashtable ht = new Hashtable();
                        foreach (LP_Temple lp in templeList)
                        {
                           
                            object obj = null;
                            double sum = 0;
                            int idw = 1;
                            string value = "";
                            if (lp.isExplorer == 1)
                            {
                                continue;
                            }
                            
                            IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                           " where   UserControlId='" + parentTemple.LPID + "'  and WorkTaskInsId='20低压设备完好率及台区网络图'"
                           + " and  FieldId='" + lp.LPID + "' " + strtqcode
                           + " order by YExcelPos");
                            foreach (WF_TableFieldValue tfv in tfvli)
                            {
                                
                                if ((lp.CellName.IndexOf("补偿电容") > -1 || lp.CellName.IndexOf("电动机") > -1 || lp.CellName.Trim().IndexOf("机井") > -1
                                || lp.CellName.IndexOf("农副业") > -1 || lp.CellName.IndexOf("照明户数") > -1
                                || lp.CellName.IndexOf("单相表数") > -1 || lp.CellName.IndexOf("三相表数") > -1) == true)
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
                                        valEX = "^[0-9]+(\\.)?([0-9]+)?$";
                                        if (tfv.ControlValue == "" || Regex.Match(tfv.ControlValue, valEX).Value != "")
                                        {
                                            if (tfv.ControlValue == "")
                                                sum += 0;
                                            else
                                                sum += idw * Convert.ToDouble(tfv.ControlValue);
                                            value = sum.ToString();
                                        }
                                        else
                                        {
                                            valEX = "^[0-9]+(\\.)?([0-9]+)?/[0-9]+(\\.)?([0-9]+)?";
                                            if (Regex.Match(tfv.ControlValue, valEX).Value != "")
                                            {
                                                string[] str1 = tfv.ControlValue.Split('/');
                                                if (value == "")
                                                {

                                                    value = (idw * Convert.ToDouble(str1[0])).ToString() + "/" + (idw * Convert.ToDouble(str1[1])).ToString();
                                                }
                                                else if (value.IndexOf('/') > -1)
                                                {
                                                    string[] str2 = value.Split('/');
                                                    sum = idw * Convert.ToDouble(str1[0]) + Convert.ToDouble(str2[0]);
                                                    value = sum.ToString();
                                                    sum = idw * Convert.ToDouble(str1[1]) + Convert.ToDouble(str2[1]);
                                                    value = value + "/" + sum.ToString();
                                                }
                                            }
                                            else
                                            {
                                                value = tfv.ControlValue;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        value = tfv.ControlValue;

                                    }
                                }
                                else
                                {
                                    if (ht.Contains(tfv.WorkFlowId))
                                    {
                                        string str = ht[tfv.WorkFlowId].ToString();
                                        if (str.IndexOf(lp.LPID) > -1)
                                            continue;
                                        else
                                        {
                                            ht[tfv.WorkFlowId] += lp.LPID;
                                        }
                                    }
                                    else
                                    {
                                        ht.Add(tfv.WorkFlowId, lp.LPID);
                                    }
                                    valEX = "^[0-9]+(\\.)?([0-9]+)?$";
                                    if (lp.CellName.IndexOf("配电变压器容量") == -1 && lp.CellName.IndexOf("最大供电半径") == -1 && (tfv.ControlValue == "" || Regex.Match(tfv.ControlValue, valEX).Value != ""))
                                    {
                                        if (tfv.ControlValue == "")
                                            sum += 0;
                                        else
                                            sum += idw * Convert.ToDouble(tfv.ControlValue);
                                        value = sum.ToString();
                                    }
                                    else
                                    {
                                        value = tfv.ControlValue;
                                    }
                                   
                                }
                            }
                            if (activeSheetName != lp.KindTable)
                            {
                                activeSheetName = lp.KindTable;
                                ea.ActiveSheet(activeSheetName);
                            }
                            if (value != null && tfvli.Count > 0 && tfvli[0].XExcelPos > 0 && tfvli[0].XExcelPos > 0)
                            {
                                string strvalue = value;
                                valEX = "^[0-9]+(\\.)?([0-9]+)?$";
                                if (value == "" || Regex.Match(value, valEX).Value != "")
                                {
                                    if (value == "")
                                        strvalue = value;
                                    {
                                        strvalue = Math.Round(Convert.ToDecimal(value), 3).ToString();
                                    }

                                }
                                else
                                {
                                    valEX = "^[0-9]+(\\.)?([0-9]+)?/[0-9]+(\\.)?([0-9]+)?";
                                    if (Regex.Match(value, valEX).Value != "")
                                    {
                                        string[] str1 = value.Split('/');

                                        strvalue = Math.Round(Convert.ToDecimal(str1[0]), 3).ToString() + "/" + Math.Round(Convert.ToDecimal(str1[1]), 3).ToString();

                                    }
                                }
                                ea.SetCellValue("'" + strvalue.ToString(), tfvli[0].XExcelPos, tfvli[0].YExcelPos);
                            }



                        }
                        //if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                        //    return;
                    }

                    //System.Diagnostics.Process.Start(fname);
                    ea.ShowExcel();
                }
                catch (Exception mex)
                {
                    Console.WriteLine(mex.Message);
                    MsgBox.ShowWarningMessageBox("无法保存" + fname + "。" + mex.Message);

                }
            }
            
        }
        public static void ExportExcelTQ(string tqCode)
        {
             ExcelAccess ea = new ExcelAccess();
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname =Application.StartupPath + "\\00记录模板\\20低压设备完好率及台区网络图";
            //Ecommon.WriteDoc(obj.BigData,ref fname);
            
            
            //saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LP_Temple parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and  CellName like '%低压线路完好率及台区网络图%'");
                LP_Temple lp2 = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where  ParentID='" + parentTemple.LPID + "' and SortID=1");
                WF_TableFieldValue wfv = new WF_TableFieldValue();
                    //wfv.ID = wfv.CreateID();
                    //wfv.WorkFlowId = tqCode;
                    //wfv.WorkTaskId = "20低压设备完好率及台区网络图";
                    //wfv.WorkTaskInsId = "20低压设备完好率及台区网络图";
                    //wfv.UserControlId = parentTemple.LPID;
                    //wfv.ControlValue = "";
                    //wfv.FieldId = lp2.LPID;
                

                wfv = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(" where  UserControlId='" + parentTemple.LPID + "'"
                                 + " and   WorkflowId='" + tqCode + "'"
                                 + " and   UserControlId='" + parentTemple.LPID + "'"
                                 + " and   fieldname='" + lp2.CellName + "'"
                                 + " and   FieldId='" + lp2.LPID + "' and Bigdata is not null"
                                );
                DSOFramerControl ds1 = new DSOFramerControl();
                //fname = saveFileDialog1.FileName;
                try
                {;
                IList<LP_Temple> templeList = null;
                 //parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and  CellName like '%低压线路完好率及台区网络图%'");
                if (parentTemple != null)
                    {
                        if (wfv != null && wfv.Bigdata != null && wfv.Bigdata.Length > 0)
                        ds1.FileDataGzip = wfv.Bigdata;
                        else
                            ds1.FileDataGzip = parentTemple.DocContent;
                        //ds1.FileSave(fname, true);
                        fname = ds1.FileName;
                        ds1.FileClose();
                        
                        
                        ea.Open(fname);
                        templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                            "where ParentID ='" + parentTemple.LPID + "' order by SortID");
                        
                        string valEX = @"[0-9]+(\.)?[0-9]+$";//只允许整数或小数的正则表达式
                        int i=0;
                        ArrayList al = new ArrayList();

                        string activeSheetName = "";
                        foreach (LP_Temple lp in templeList)
                        {
                            object obj = null;
                            double sum = 0;
                            int idw = 1;
                            string value = "";
                            if (lp.isExplorer == 1)
                            {
                                continue;
                            }
                            if ((lp.CellName.IndexOf("补偿电容") > -1 || lp.CellName.IndexOf("电动机") > -1 || lp.CellName.Trim().IndexOf("机井") > -1
                                || lp.CellName.IndexOf("农副业") > -1 || lp.CellName.IndexOf("照明户数") > -1
                                || lp.CellName.IndexOf("单相表数") > -1 || lp.CellName.IndexOf("三相表数") > -1) == false)
                            {
                                continue;
                            }
                            IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                            " where   UserControlId='" + parentTemple.LPID + "' and   WorkflowId='" + tqCode + "' and WorkTaskInsId='20低压设备完好率及台区网络图'"
                            + " and  FieldId='" + lp.LPID + "' "
                            + " order by YExcelPos");
                         
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
                                    valEX = "^[0-9]+(\\.)?([0-9]+)?$";
                                    if (tfv.ControlValue == "" || Regex.Match(tfv.ControlValue, valEX).Value!="")
                                    {
                                        if (tfv.ControlValue == "")
                                            sum += 0;
                                        else
                                            sum += idw * Convert.ToDouble(tfv.ControlValue);
                                        value = sum.ToString();
                                    }
                                    else
                                    {
                                        valEX = "^[0-9]+(\\.)?([0-9]+)?/[0-9]+(\\.)?([0-9]+)?";
                                        if (Regex.Match(tfv.ControlValue, valEX).Value != "")
                                        {
                                            string[] str1 = tfv.ControlValue.Split('/');
                                            if (value == "")
                                            {

                                                value = (idw * Convert.ToDouble(str1[0])).ToString() + "/" + (idw * Convert.ToDouble(str1[1])).ToString();
                                            }
                                            else if (value.IndexOf('/')>-1)
                                            {
                                                string[] str2 = value.Split('/');
                                                sum = idw * Convert.ToDouble(str1[0]) + Convert.ToDouble(str2[0]);
                                                value = sum.ToString();
                                                sum = idw * Convert.ToDouble(str1[1]) + Convert.ToDouble(str2[1]);
                                                value = value + "/" + sum.ToString();
                                            }
                                        }
                                        else
                                        {
                                            value = tfv.ControlValue;
                                        }
                                        
                                    }
                                }
                                else
                                {
                                    value = tfv.ControlValue;
                                   
                                }
                            }
                          
                               
                                if (activeSheetName != lp.KindTable)
                                {
                                    
                                    activeSheetName = lp.KindTable;
                                    ea.ActiveSheet(activeSheetName);
                                }
                                if (value != null && tfvli.Count > 0 && tfvli[0].XExcelPos > 0 && tfvli[0].XExcelPos > 0)
                                {
                                    string strvalue = value;
                                    valEX = "^[0-9]+(\\.)?([0-9]+)?$";
                                    if (value == "" || Regex.Match(value, valEX).Value != "")
                                    {
                                        if (value=="")
                                            strvalue = value;
                                        {
                                            strvalue = Math.Round(Convert.ToDecimal(value), 3).ToString(); 
                                        }

                                    }
                                    else
                                    {
                                        valEX = "^[0-9]+(\\.)?([0-9]+)?/[0-9]+(\\.)?([0-9]+)?";
                                        if (Regex.Match(value, valEX).Value != "")
                                        {
                                            string[] str1 = value.Split('/');

                                            strvalue = Math.Round(Convert.ToDecimal(str1[0]), 3).ToString() + "/" + Math.Round(Convert.ToDecimal(str1[1]), 3).ToString();
                                            
                                        }
                                    }
                                    ea.SetCellValue("'" + strvalue.ToString(), tfvli[0].XExcelPos, tfvli[0].YExcelPos);
                                }

                                       


                        }
                        //if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                        //    return;
                    }
                ea.ShowExcel();
                    //System.Diagnostics.Process.Start(fname);
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
