using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Ebada.Client.Platform;
using Ebada.Components;
using System.Threading;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportCYSBMFDTZ
    {
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;

            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
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
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public  void ExportExcel(IList<PJ_cysbmfdtz> datalist)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\充油设备密封点台账.xls";
            ex.Open(fname);
            ExportExcel(ex, datalist);
            ex.ShowExcel();
           
        }
        public void ExportExcelMonth(string orgid)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\充油设备密封点台账.xls";
         
        }
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid)
        {

            
        }

        
        public void ExportExcelSubmit(ref LP_Temple parentTemple,  string orgid, bool isShow)
        {
           
        }
        public void ExportExcel(ExcelAccess ex ,IList<PJ_cysbmfdtz> datalist)
        {
            //此处写填充内容代码
            int row = 6;
            int col = 1;
            int rowcount = 12;

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
                    ex.SetCellValue(datalist[j].OrgName, 3, 2);
                    ex.SetCellValue(datalist[j].sbmc, 3, 7);
                    ex.SetCellValue(datalist[j].InstallPlace, 3, 18);
                    if (datalist[j].sbModle != "" && datalist[j].sbCapcity != "")
                        ex.SetCellValue(datalist[j].sbModle +"/"+ datalist[j].sbCapcity, 3, 23);
                    else

                        ex.SetCellValue(datalist[j].sbModle + "" + datalist[j].sbCapcity, 3, 23);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].sbmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].cysbFactory, row + j % rowcount, col + 2);
                //装设日期
                ex.SetCellValue(datalist[j].inDate.Year.ToString(), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].inDate.Month.ToString(), row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].inDate.Day.ToString(), row + j % rowcount, col + 9);

                //下次更换日期
                ex.SetCellValue(datalist[j].changeDate.Year.ToString(), row + j % rowcount, col + 11);
                ex.SetCellValue(datalist[j].changeDate.Month.ToString(), row + j % rowcount, col + 13);
                ex.SetCellValue(datalist[j].changeDate.Day.ToString(), row + j % rowcount, col + 15);

                ex.SetCellValue(datalist[j].mfStatus, row + j % rowcount, col + 17);
                ex.SetCellValue(datalist[j].jcr, row + j % rowcount, col + 18);

                //检查日期
                ex.SetCellValue(datalist[j].jcDate.Year.ToString(), row + j % rowcount, col + 19);
                ex.SetCellValue(datalist[j].jcDate.Month.ToString(), row + j % rowcount, col + 21);
                ex.SetCellValue(datalist[j].jcDate.Day.ToString(), row + j % rowcount, col + 23);


                ex.SetCellValue(datalist[j].remark, row + j % rowcount, col + 25);


            }
        }
    
    }
}
