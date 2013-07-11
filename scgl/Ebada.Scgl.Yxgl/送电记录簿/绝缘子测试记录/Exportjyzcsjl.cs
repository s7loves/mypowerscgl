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
    public class Exportjyzcsjl
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        /// <summary>
        /// 开关跳闸记录簿
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcel(IList<sdjls_jyzcsjl> nrList)
        {
            #region 开关跳闸记录
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电10绝缘子测试记录.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(nrList.Count, 11))
            {
                pageindex = Ecommon.GetPagecount(nrList.Count, 11);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(nrList[0].LineName,3,5);
            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 11 + 1;
                int endrow = j * 11;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        //ex.SetCellValue(nrList[starow - 1 + i].jcrq.Year.ToString(), row + 5 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].cssj.Year.ToString(), row + 5 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].cssj.Month.ToString(), row + 5 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].cssj.Day.ToString(), row + 5 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].gh, row + 5 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].gx, row + 5 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].jyzxh, row + 5 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].lzjyzwz, row + 5 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].syfzr, row + 5 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].c1, row + 5 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].clsj.Year.ToString(), row + 5 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].clsj.Month.ToString(), row + 5 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].clsj.Day.ToString(), row + 5 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].bz, row + 5 + i, 13);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].cssj.Year.ToString(), row + 5 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].cssj.Month.ToString(), row + 5 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].cssj.Day.ToString(), row + 5 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].gh, row + 5 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].gx, row + 5 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].jyzxh, row + 5 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].lzjyzwz, row + 5 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].syfzr, row + 5 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].c1, row + 5 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].clsj.Year.ToString(), row + 5 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].clsj.Month.ToString(), row + 5 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].clsj.Day.ToString(), row + 5 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].bz, row + 5 + i, 13);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion

        }

      
    }
}
