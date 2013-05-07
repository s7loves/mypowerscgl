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
    public class ExportDdcd
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        /// <summary>
        /// 导线驰度
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcel(IList<sdjls_ddxcd> nrList)
        {
            #region 导线驰度
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电12导(地)线驰度测量记录.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(nrList.Count, 17))
            {
                pageindex = Ecommon.GetPagecount(nrList.Count, 17);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(nrList[0].LineName, 4, 3);
            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 7 + 1;
                int endrow = j * 7;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 7; i++)
                    {

                        //导线
                        ex.SetCellValue(nrList[starow - 1 + i].dxxh, row+i+7, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].nzdgh, row + i + 7, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].cldgh, row + i + 7, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Year.ToString(), row + i + 7, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Month.ToString(), row + i + 7, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Day.ToString(), row + i + 7, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].wd, row + i + 7, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].dxscz, row + i + 7, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].dxsczz, row + i + 7, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].dxsczy, row + i + 7, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].dxbzz, row + i + 7, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].dxwcz, row + i + 7, 13);
                        ex.SetCellValue(nrList[starow - 1 + i].dxwczz, row + i + 7, 14);
                        ex.SetCellValue(nrList[starow - 1 + i].dxwcy, row + i + 7, 16);
                        ex.SetCellValue(nrList[starow - 1 + i].dxjl, row + i + 7, 17);
                        ex.SetCellValue(nrList[starow - 1 + i].clr, row + i + 7, 18);

                        //地线
                        ex.SetCellValue(nrList[starow - 1 + i].ddxxh, row + i + 17, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].nzdgh, row + i + 17, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].cldgh, row + i + 17, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Year.ToString(), row + i + 17, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Month.ToString(), row + i + 17, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Day.ToString(), row + i + 17, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].wd, row + i + 17, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxscz, row + i + 17, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxsczy, row + i + 17, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxbzz, row + i + 17, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].ddwcz, row + i + 17, 13);
                        ex.SetCellValue(nrList[starow - 1 + i].ddwcy, row + i + 17, 15);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxjl, row + i + 17, 17);
                        ex.SetCellValue(nrList[starow - 1 + i].clr, row + i + 17, 18);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        //导线
                        ex.SetCellValue(nrList[starow - 1 + i].dxxh, row + i + 7, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].nzdgh, row + i + 7, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].cldgh, row + i + 7, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Year.ToString(), row + i + 7, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Month.ToString(), row + i + 7, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Day.ToString(), row + i + 7, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].wd, row + i + 7, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].dxscz, row + i + 7, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].dxsczz, row + i + 7, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].dxsczy, row + i + 7, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].dxbzz, row + i + 7, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].dxwcz, row + i + 7, 13);
                        ex.SetCellValue(nrList[starow - 1 + i].dxwczz, row + i + 7, 14);
                        ex.SetCellValue(nrList[starow - 1 + i].dxwcy, row + i + 7, 16);
                        ex.SetCellValue(nrList[starow - 1 + i].dxjl, row + i + 7, 17);
                        ex.SetCellValue(nrList[starow - 1 + i].clr, row + i + 7, 18);

                        //地线
                        ex.SetCellValue(nrList[starow - 1 + i].ddxxh, row + i + 17, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].nzdgh, row + i + 17, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].cldgh, row + i + 17, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Year.ToString(), row + i + 17, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Month.ToString(), row + i + 17, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].clrq.Day.ToString(), row + i + 17, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].wd, row + i + 17, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxscz, row + i + 17, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxsczy, row + i + 17, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxbzz, row + i + 17, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].ddwcz, row + i + 17, 13);
                        ex.SetCellValue(nrList[starow - 1 + i].ddwcy, row + i + 17, 15);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxjl, row + i + 17, 17);
                        ex.SetCellValue(nrList[starow - 1 + i].clr, row + i + 17, 18);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion

        }

      
    }
}
