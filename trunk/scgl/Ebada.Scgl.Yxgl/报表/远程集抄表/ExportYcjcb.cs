using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
using System.Windows.Forms;
using System.IO;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportYcjcb
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        /// <summary>
        /// 远程集抄表
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcel(IList<xxgx_ycjc> nrList)
        {
            #region 远程集抄表
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\远程集抄表.xls";
            if (!File.Exists(fname))
            {
                MsgBox.ShowWarningMessageBox("文件模板不存在,导出失败!");
                return;
            }
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(nrList.Count, 24))
            {
                pageindex = Ecommon.GetPagecount(nrList.Count, 24);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
               
            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 24 + 1;
                int endrow = j * 24;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].sj, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].xlmc, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].jldmc, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].bh, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].zxygzdn.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1zxygdn.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2zxygdn.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3zxygdn.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4zxygdn.ToString(), row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].fxygzdn.ToString(), row + 4 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1fxygdn.ToString(), row + 4 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2fxygdn.ToString(), row + 4 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3fxygdn.ToString(), row + 4 + i, 13);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4fxygdn.ToString(), row + 4 + i, 14);
                        ex.SetCellValue(nrList[starow - 1 + i].zxwgzdn.ToString(), row + 4 + i, 15);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1zxwgdn.ToString(), row + 4 + i, 16);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2zxwgdn.ToString(), row + 4 + i, 17);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3zxwgdn.ToString(), row + 4 + i, 18);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4zxwgdn.ToString(), row + 4 + i, 19);
                        ex.SetCellValue(nrList[starow - 1 + i].fxwgzdn.ToString(), row + 4 + i, 20);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1fxwgdn.ToString(), row + 4 + i, 21);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2fxwgdn.ToString(), row + 4 + i, 22);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3fxwgdn.ToString(), row + 4 + i, 23);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4fxwgdn.ToString(), row + 4 + i, 24);
                       
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].sj, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].xlmc, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].jldmc, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].bh, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].zxygzdn.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1zxygdn.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2zxygdn.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3zxygdn.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4zxygdn.ToString(), row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].fxygzdn.ToString(), row + 4 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1fxygdn.ToString(), row + 4 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2fxygdn.ToString(), row + 4 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3fxygdn.ToString(), row + 4 + i, 13);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4fxygdn.ToString(), row + 4 + i, 14);
                        ex.SetCellValue(nrList[starow - 1 + i].zxwgzdn.ToString(), row + 4 + i, 15);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1zxwgdn.ToString(), row + 4 + i, 16);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2zxwgdn.ToString(), row + 4 + i, 17);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3zxwgdn.ToString(), row + 4 + i, 18);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4zxwgdn.ToString(), row + 4 + i, 19);
                        ex.SetCellValue(nrList[starow - 1 + i].fxwgzdn.ToString(), row + 4 + i, 20);
                        ex.SetCellValue(nrList[starow - 1 + i].fl1fxwgdn.ToString(), row + 4 + i, 21);
                        ex.SetCellValue(nrList[starow - 1 + i].fl2fxwgdn.ToString(), row + 4 + i, 22);
                        ex.SetCellValue(nrList[starow - 1 + i].fl3fxwgdn.ToString(), row + 4 + i, 23);
                        ex.SetCellValue(nrList[starow - 1 + i].fl4fxwgdn.ToString(), row + 4 + i, 24);
                        
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion

        }

      
    }
}
