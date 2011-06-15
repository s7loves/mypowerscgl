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
    public class Export15  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<PS_gjyb> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\15工具仪表台账.xls";

            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 6;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(objlist.Count, 18))
            {
                pageindex = Ecommon.GetPagecount(objlist.Count, 18);
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
                int starow = prepageindex * 18 + 1;
                int endrow = j * 18;
                int bh = 0;
                if (objlist.Count > endrow)
                {
                    for (int i = 0; i < 18; i++)
                    {
                        bh++;

                        ex.SetCellValue((bh + 1).ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].sbName, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].jdgg, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].dw, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].sl.ToString(), rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].cj, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].sbCode, rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].lqsj.Year.ToString(), rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].lqsj.Month.ToString(), rowcount + i, 9);

                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        bh++;
                        ex.SetCellValue((bh + 1).ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].sbName, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].jdgg, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].dw, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].sl.ToString(), rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].cj, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].sbCode, rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].lqsj.Year.ToString(), rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].lqsj.Month.ToString(), rowcount + i, 9);

                    }
                }
            }
            ex.ActiveSheet(1);
            string gdsname = "";
            //记录变电所
            if (objlist.Count>0)
            {
                 IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + objlist[0].OrgID + "'");
             
            if (list.Count > 0)

                gdsname = list[0].OrgName;
            }
            ex.SetCellValue(gdsname, 3, 2);
           
            //工具仪表信息
            //for (int i = 0; i < objlist.Count;i++ )
            //{
            //    ex.SetCellValue((i+1).ToString(), rowcount + i, 1);
            //    ex.SetCellValue(objlist[i].sbName, rowcount + i,2);
            //    ex.SetCellValue(objlist[i].jdgg, rowcount + i,3);
            //    ex.SetCellValue(objlist[i].dw, rowcount + i, 4);
            //    ex.SetCellValue(objlist[i].sl.ToString(), rowcount + i, 5);
            //    ex.SetCellValue(objlist[i].cj, rowcount + i, 6);
            //    ex.SetCellValue(objlist[i].sbCode, rowcount + i, 7);
            //    ex.SetCellValue(objlist[i].lqsj.Year.ToString(), rowcount + i, 8);
            //    ex.SetCellValue(objlist[i].lqsj.Month.ToString(), rowcount + i, 9);
            //}
           ex.ShowExcel();
        }
      
    }
}
