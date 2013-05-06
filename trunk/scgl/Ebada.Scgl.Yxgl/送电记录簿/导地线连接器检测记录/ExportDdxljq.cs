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
    public class ExportDdxljq
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        /// <summary>
        /// 开关跳闸记录簿
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcel(sdjls_ddxljq dgjc,IList<sdjls_ddxljqnr> nrList)
        {
            #region 开关跳闸记录
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电11导地线连接器检测记录.xls";
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
                ex.SetCellValue(dgjc.LineName, 3, 3);
                ex.SetCellValue(dgjc.jcrq.Year + "年" + dgjc.jcrq.Month + "月" + dgjc.jcrq.Day + "日", 3, 8);
            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 17 + 1;
                int endrow = j * 17;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 17; i++)
                    {
                        ex.SetCellValue((i + 1).ToString(), row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].gth, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].dj, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].xb, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].ljxs, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].djzwz, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxxh, row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].ljqxh, row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].sccj, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].bz, row + 4 + i, 10);
                        
                       
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue((i + 1).ToString(), row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].gth, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].dj, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].xb, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].ljxs, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].djzwz, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].ddxxh, row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].ljqxh, row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].sccj, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].bz, row + 4 + i, 10);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion

        }

      
    }
}
