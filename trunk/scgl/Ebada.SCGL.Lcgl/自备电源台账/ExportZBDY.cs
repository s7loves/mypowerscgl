﻿using System;
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
    public class ExportZBDY
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
        public  void ExportExcel(IList<PJ_zbdytz> datalist)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\自备电源台账.xls";
            ex.Open(fname);
            ExportExcel(ex, datalist);
            ex.ShowExcel();
           
        }
     
      
      
        public void ExportExcel(ExcelAccess ex, IList<PJ_zbdytz> datalist)
        {
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount =14;

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
                }
                ex.SetCellValue(((j + 1)).ToString(), row + j % rowcount, col);

                ex.SetCellValue(datalist[j].khmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].khdz, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].zdyOrgName, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].zdyLineName, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].zdykgModle, row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].zbdytype, row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].zbdyModle, row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].zbdyrl, row + j % rowcount, col + 8);
                ex.SetCellValue(datalist[j].kgfs, row + j % rowcount, col + 9);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 10);

            }
           
        }
    
    }
}
