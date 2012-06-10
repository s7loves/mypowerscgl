using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export08 {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<PJ_08sbtdjx> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\08设备停电检修记录.xls";

            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 5;
            //分页 将要变化的进行分页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(objlist.Count, 20)) {
                pageindex = Ecommon.GetPagecount(objlist.Count, 20);
            }
            for (int j = 1; j <= pageindex; j++) {
                if (j > 1) {
                    ex.CopySheet(1, 1);
                }
            }
            ex.ShowExcel();
            for (int j = 1; j <= pageindex; j++) {

                ex.ActiveSheet(j);
                ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 20 + 1;
                int endrow = j * 20;
                if (objlist.Count > endrow) {
                    for (int i = 0; i < 20; i++) {
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Month.ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Day.ToString(), rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].LineName, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].jxnr, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Hour.ToString(), rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Minute.ToString(), rowcount + i, 9);
                        ex.SetCellValue(objlist[starow - 1 + i].sdsj.Hour.ToString(), rowcount + i, 11);
                        ex.SetCellValue(objlist[starow - 1 + i].sdsj.Minute.ToString(), rowcount + i, 13);
                        ex.SetCellValue(objlist[starow - 1 + i].tdxz, rowcount + i, 15);
                        ex.SetCellValue(objlist[starow - 1 + i].gzfzr, rowcount + i, 16);

                    }
                } else if (objlist.Count <= endrow && objlist.Count >= starow) {
                    for (int i = 0; i < objlist.Count - starow + 1; i++) {
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Month.ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Day.ToString(), rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].LineName, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].jxnr, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Hour.ToString(), rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].tdsj.Minute.ToString(), rowcount + i, 9);
                        ex.SetCellValue(objlist[starow - 1 + i].sdsj.Hour.ToString(), rowcount + i, 11);
                        ex.SetCellValue(objlist[starow - 1 + i].sdsj.Minute.ToString(), rowcount + i, 13);
                        ex.SetCellValue(objlist[starow - 1 + i].tdxz, rowcount + i, 15);
                        ex.SetCellValue(objlist[starow - 1 + i].gzfzr, rowcount + i, 16);

                    }
                }
            }
            ex.ActiveSheet(1);
            string gdsname = "";
            //记录变电所
            if (objlist.Count > 0) {


                gdsname = objlist[0].OrgName;
            }

            //工具仪表信息
            //for (int i = 0; i < objlist.Count;i++ )
            //{
            //    ex.SetCellValue(objlist[i].tdsj.Month.ToString(), rowcount + i, 1);
            //    ex.SetCellValue(objlist[i].tdsj.Day.ToString(), rowcount + i, 3);
            //    ex.SetCellValue(objlist[i].LineName, rowcount + i, 5);
            //    ex.SetCellValue(objlist[i].jxnr, rowcount + i, 6);
            //    ex.SetCellValue(objlist[i].tdsj.Hour.ToString(), rowcount + i, 7);
            //    ex.SetCellValue(objlist[i].tdsj.Minute.ToString(), rowcount + i, 9);
            //    ex.SetCellValue(objlist[i].sdsj.Hour.ToString(), rowcount + i,11);
            //    ex.SetCellValue(objlist[i].sdsj.Minute.ToString(), rowcount + i, 13);
            //    ex.SetCellValue(objlist[i].tdxz, rowcount + i, 15);
            //    ex.SetCellValue(objlist[i].gzfzr, rowcount + i, 16);

            //}
            ex.ShowExcel();
        }

    }
}
