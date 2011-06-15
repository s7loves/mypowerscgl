using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export21  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<PJ_21gzbxdh> objlist)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\21电力故障电话接听记录.xls";

            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 7;
             string orgname="";
            if (objlist.Count>0)
            {
                orgname = objlist[0].OrgName;
            }
         
            //变电所内容
            ex.SetCellValue(orgname, 4, 5);
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(objlist.Count, 19))
            {
                pageindex = Ecommon.GetPagecount(objlist.Count, 19);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
            }
            ex.ShowExcel();
            for (int j = 1; j <= pageindex; j++)
            {
               
                    ex.ActiveSheet(j);
              
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 19 + 1;
                int endrow = j * 19;
                if (objlist.Count > endrow)
                {
                    for (int i = 0; i < 19; i++)
                    {


                        ex.SetCellValue(objlist[starow - 1 + i].rq.Month.ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Day.ToString(), rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Hour.ToString(), rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Minute.ToString(), rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].lxfs, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].yhdz, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].gzjk, rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].djr, rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].clr, rowcount + i, 9);

                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Month.ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Day.ToString(), rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Hour.ToString(), rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].rq.Minute.ToString(), rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].lxfs, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].yhdz, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].gzjk, rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].djr, rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].clr, rowcount + i, 9);

                    }
                }
            }
            //记录
            //for (int i = 0; i < objlist.Count;i++ )
            //{
            //    ex.SetCellValue(objlist[i].rq.Month.ToString(), rowcount + i, 1);
            //    ex.SetCellValue(objlist[i].rq.Day.ToString(), rowcount + i, 2);
            //    ex.SetCellValue(objlist[i].rq.Hour.ToString(), rowcount + i, 3);
            //    ex.SetCellValue(objlist[i].rq.Minute.ToString(), rowcount + i, 4);
            //    ex.SetCellValue(objlist[i].lxfs, rowcount + i, 5);
            //    ex.SetCellValue(objlist[i].yhdz, rowcount + i, 6);
            //    ex.SetCellValue(objlist[i].gzjk, rowcount + i, 7);
            //    ex.SetCellValue(objlist[i].djr, rowcount + i,8);
            //    ex.SetCellValue(objlist[i].clr, rowcount + i,9);
            //}
            ex.ShowExcel();
        }
      
    }
}
