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
    public class ExportAQGJSTZEdit
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
        public void ExportExcel(IList<PJ_anqgjcrkd> datalist)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所安全工器具台帐.xls";
            ex.Open(fname);
            ExportExcel(ex, datalist, "供电所安全工器具台帐汇总");
            
            ex.DeleteSheet(1);
            ex.ShowExcel();
           
        }



        public void ExportExcel(ExcelAccess ex, IList<PJ_anqgjcrkd> datalist, string wpmc)
        {
            //此处写填充内容代码
            int row = 4;
            int col = 1;
            int rowcount = 18;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j <= pageindex; j++)
            {

                ex.CopySheet(1, j);
                if (j == 1) ex.ReNameWorkSheet(j + 1, wpmc);
                else
                    ex.ReNameWorkSheet(j + 1, wpmc + (j));
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(wpmc);
                    else ex.ActiveSheet(wpmc + (j / rowcount + 1));

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col+1 );
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 2);

                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].wpsl, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].wpcj, row + j % rowcount, col + 5);
                if (datalist[j].num.Length>0)
                ex.SetCellValue(datalist[j].num.Substring(datalist[j].num.Length-4), row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].indate.ToString("yyyy年MM月dd日"), row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].synx, row + j % rowcount, col + 9);
                if (datalist[j].syzq != "物品不需要试验")
                {
                    ex.SetCellValue(datalist[j].scsydate.ToString("yyyy年MM月dd日"), row + j % rowcount, col + 8);

                    ex.SetCellValue(datalist[j].syzq, row + j % rowcount, col + 10);
                }


            }
        }
    
    
    }
}
