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
        /// 绝缘子测试记录
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcel(IList<sdjls_jyzcsjl> nrList)
        {
            #region 绝缘子测试记录
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电10绝缘子测试记录.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            int nzglzs = 0;//耐张杆零值数
            int zxglzs = 0;//直线杆零值数
            List<sdjls_jyzcsjl> jyzList=(List<sdjls_jyzcsjl>)nrList;
            jyzList.Sort(delegate(sdjls_jyzcsjl j1, sdjls_jyzcsjl j2) { return Comparer<string>.Default.Compare(j1.gh, j2.gh); });
            string startgh = jyzList[0].gh;
            string endgh = jyzList[jyzList.Count - 1].gh;
            foreach (sdjls_jyzcsjl jl in nrList)
            {
                int result = 0;
                int.TryParse(jl.c3, out result);
                if (jl.gx.Trim() == "直线杆")
                {
                    zxglzs += result;
                }
                else
                {
                    nzglzs += result;
                }
            }
            if (pageindex < Ecommon.GetPagecount(nrList.Count, 12))
            {
                pageindex = Ecommon.GetPagecount(nrList.Count, 12);
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
                int starow = prepageindex * 12 + 1;
                int endrow = j * 12;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 12; i++)
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
                    ex.SetCellValue("#"+startgh, 18, 6);
                    ex.SetCellValue("#~" + endgh, 18, 7);
                    ex.SetCellValue(nrList.Count.ToString(), 18, 9);
                    ex.SetCellValue(nzglzs.ToString()+"片;", 19, 6);
                    ex.SetCellValue(zxglzs.ToString(), 19, 10);
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
