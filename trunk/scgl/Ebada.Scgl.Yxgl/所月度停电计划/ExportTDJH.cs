using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
using System.Windows.Forms;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportTDJH  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public  void ExportExcel(IList<PJ_tdjh> datalist)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\所月度停电计划.xls";
            ex.Open(fname);
            ExportExcel(ex, datalist);
            ex.ShowExcel();
           
        }
        public void ExportExcelMonth(string orgid)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\所月度停电计划.xls";
            ex.Open(fname);
            string startday = "20";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='所月度停电计划' and sx like '%{0}%' and nr!=''", "申报截止日期"));
            if (list.Count > 0)
                startday=list[0].ToString();
            IList<PJ_tdjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_tdjh>(
                " where TDtime between '" + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-"+startday
                + " 00:00:00' and  '" 
                + DateTime.Now.Year + "-"
                + (DateTime.Now.Month + 1) + "-" + startday + " 00:00:00' and OrgCode='"+orgid+"'"
                );
            ExportExcel(ex, datalist);
            ex.ShowExcel();

        }
        public void ExportExcelSubmit(ref LP_Temple parentTemple, string cellname, string sheetname, string orgid, bool isShow)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\所月度停电计划.xls";
            dsoFramerWordControl1.FileOpen(fname);
            string startday = "20";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='所月度停电计划' and sx like '%{0}%' and nr!=''", "申报截止日期"));
            if (list.Count > 0)
                startday = list[0].ToString();
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
            ExcelAccess ex = new ExcelAccess();
            Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            ex.MyWorkBook = wb;
            ex.MyExcel = wb.Application;

            IList<PJ_tdjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_tdjh>(
                  " where TDtime between '" + DateTime.Now.Year + "-"
                  + DateTime.Now.Month + "-" + startday
                  + " 00:00:00' and  '"
                  + DateTime.Now.Year + "-"
                  + (DateTime.Now.Month + 1) + "-" + startday + " 00:00:00' and OrgCode='" + orgid + "'"
                  );
            ExportExcel(ex, datalist);
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            dsoFramerWordControl1.FileSave();
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
        }
        public void ExportExcel(ExcelAccess ex ,IList<PJ_tdjh> datalist)
        {
            //此处写填充内容代码
            int row = 6;
            int col = 1;
            int rowcount = 8;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    ex.ActiveSheet(j / rowcount + 1);
                    ex.SetCellValue(datalist[j].OrgName, 2, 3);
                    ex.SetCellValue(DateTime.Now.Year.ToString(), 2, 9);
                    ex.SetCellValue(DateTime.Now.Month.ToString(), 2, 11);
                    ex.SetCellValue(DateTime.Now.Day.ToString(), 2, 13);
                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].SQOrgname, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].JXSB, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].JXNR, row + j % rowcount, col + 3);
                //停送电时间
                ex.SetCellValue(datalist[j].TDtime.Month.ToString(), row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].TDtime.Day.ToString(), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].TDtime.Hour.ToString(), row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].TDtime.Minute.ToString(), row + j % rowcount, col + 7);

                ex.SetCellValue(datalist[j].SDtime.Month.ToString(), row + j % rowcount, col + 8);
                ex.SetCellValue(datalist[j].SDtime.Day.ToString(), row + j % rowcount, col + 9);
                ex.SetCellValue(datalist[j].SDtime.Hour.ToString(), row + j % rowcount, col + 10);
                ex.SetCellValue(datalist[j].SDtime.Minute.ToString(), row + j % rowcount, col + 11);
                //配合检修单位
                ex.SetCellValue(datalist[j].ASSOrgname, row + j % rowcount, col + 12);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 13);


            }
        }
    }
}
