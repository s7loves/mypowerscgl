using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.Data;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportJSBPJJH
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
        public void ExportExcel()
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\局设备评级计划.xls";
            ex.Open(fname);

            string strfirst = "";
            string filter = "";

            filter = "  where 1=1 ";
            if (isWorkflowCall)
            {
                filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                    + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                        + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                    + "    RecordID='" + currRecord.ID + "') "
                    ;
            }
            IList<PJ_jsbpjjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_jsbpjjh>(
             filter
               );
            ExportExcel(ex, datalist);




            ex.ShowExcel();
        }
        public void ExportExcel(ExcelAccess ex, IList<PJ_jsbpjjh> datalist)
        {
            //此处写填充内容代码
            int row = 4;
            int col = 1;
            int rowcount = 4;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j < pageindex; j++)
            {

                ex.CopySheet(1, j);
              
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(1);
                    else ex.ActiveSheet( (j / rowcount + 1));

                    ex.SetCellValue(DateTime.Now.ToString("yyyy年") + "大修更改工程项目计划申报表", 1, 1);

                    ex.SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日") , 3, 8);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].gzxm, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].wcsj.ToString("yyyy年MM月dd日"), row + j % rowcount, col + 2);

                ex.SetCellValue(datalist[j].lsr, row + j % rowcount, col +3);
                ex.SetCellValue(datalist[j].dbr, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].lsyq, row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col +6);


            }
        
        }
    }
}
