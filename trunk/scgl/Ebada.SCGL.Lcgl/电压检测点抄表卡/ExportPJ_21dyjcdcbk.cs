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
    public class ExportPJ_21dyjcdcbk
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
        public  void ExportExcel(IList<PJ_21dyjcdcbkchild> datalist)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\电压检测点抄表卡.xls";
            ex.Open(fname);
            ExportExcel(ex, datalist);
            ex.ShowExcel();
           
        }
     
      
      
        public void ExportExcel(ExcelAccess ex, IList<PJ_21dyjcdcbkchild> datalist)
        {
            if (datalist.Count==0)
	        {
               return;
	        }
            PJ_21dyjcdcbk pj21 = MainHelper.PlatformSqlMap.GetOneByKey<PJ_21dyjcdcbk>(datalist[0].ParentID);

            //此处写填充内容代码
            int row = 7;
            int col = 0;
            int rowcount = 14;

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
                ex.ActiveSheet(j);
                string str = pj21.GdsName + pj21.year + "年度电压监测点抄表卡";
                ex.SetCellValue(str, 1, 1);
                ex.SetCellValue(pj21.type, 2, 3);
                ex.SetCellValue(pj21.zzxh, 2, 9);
                ex.SetCellValue(DateTime.Now.ToLongDateString(), 2, 11);
                ex.SetCellValue(pj21.num.ToString(), 3, 3);
            }
           

            for (int j = 0; j < datalist.Count; j++)
            {
                if (j % rowcount == 0)
                {
                    ex.ActiveSheet(j / rowcount + 1);
                }
                //ex.SetCellValue(((j + 1)).ToString(), row + j % rowcount, col);

                ex.SetCellValue(datalist[j].month.ToString(), row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].alltime.ToString(), row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].uptime.ToString(), row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].downtime.ToString(), row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].hegetime.ToString(), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].csxl.ToString()+"%", row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].cxxl.ToString() + "%", row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].hegel.ToString() + "%", row + j % rowcount, col + 8);
                ex.SetCellValue(datalist[j].bignumvalue.ToString(), row + j % rowcount, col + 9);
                ex.SetCellValue(datalist[j].bigshowtime.ToString("dd日HH:mm"), row + j % rowcount, col + 10);
                ex.SetCellValue(datalist[j].minnumvalue.ToString(), row + j % rowcount, col + 11);
                ex.SetCellValue(datalist[j].minshowtime.ToString("dd日HH:mm"), row + j % rowcount, col + 12);
                ex.SetCellValue(datalist[j].cbr, row + j % rowcount, col + 13);
     

            }
           
        }
    
    }
}
