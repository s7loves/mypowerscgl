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
    public class Export13  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PS_tqdlbh jl)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\13剩余电流动作保护器测试记录.xls";

            ex.Open(fname);
            int row = 1;
            int col = 1;
            //测量记录
            IList<PJ_13dlbhjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_13dlbhjl>(" where sbID='" + jl.sbID + "' order by CreateDate");
            int p = Ecommon.GetPagecount(list.Count, 12);

            for (int i = 0; i < p - 1; i++)
            {
                ex.CopySheet(1, 1 + i);
            }
            ex.ActiveSheet(1);

            //线路名称行
            ex.SetCellValue(jl.tqName, 4, 1);
            ex.SetCellValue(jl.Factory, 5, 13);
            ex.SetCellValue(jl.InstallAdress, row + 4, col + 3);
            ex.SetCellValue(jl.dzdl, row + 4, col + 6);
            ex.SetCellValue(jl.sbModle, row + 4, col + 10);
            ex.SetCellValue(jl.Factory, row + 4, col + 13);
            //设备名称行
            ex.SetCellValue(jl.glr, row + 6, col+3);
            ex.SetCellValue(jl.dzsj, row + 6, col + 6);
            ex.SetCellValue(jl.InDate.Year.ToString(), row + 7 , col+10);
            ex.SetCellValue(jl.InDate.Month.ToString(), row + 7 , col + 11);
            ex.SetCellValue(jl.InDate.Day.ToString(), row + 7 , col + 13);

            for (int page = 1; page <= p; page++)
            {
                ex.ActiveSheet(page);
                if (page == 1)
                {

                    for (int i = 0; i < 12; i++)
                    {

                        if (i + (page - 1) * 12 < list.Count)
                        {
                            PJ_13dlbhjl obj = list[i + (page - 1) * 12];
                            ex.SetCellValue(obj.rq.Year.ToString(), row + 11 + i, col);
                            ex.SetCellValue(obj.rq.Month.ToString(), row + 11 + i, col + 1);
                            ex.SetCellValue(obj.rq.Day.ToString(), row + 11 + i, col + 2);
                            ex.SetCellValue(obj.dzdl, row + 11 + i, col + 3);
                            ex.SetCellValue(obj.dzsj.ToString(), row + 11 + i, col + 4);
                            ex.SetCellValue(obj.yxqk, row + 11 + i, col + 5);
                            ex.SetCellValue(obj.csr, row + 11 + i, col + 6);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 12; i++)
                    {

                        if (i + (page - 1) * 12 < list.Count)
                        {
                            PJ_13dlbhjl obj = list[i + (page - 1) * 12];
                            ex.SetCellValue(obj.rq.Year.ToString(), row + 11 + i, col);
                            ex.SetCellValue(obj.rq.Month.ToString(), row + 11 + i, col + 1);
                            ex.SetCellValue(obj.rq.Day.ToString(), row + 11 + i, col + 2);
                            ex.SetCellValue(obj.dzdl, row + 11 + i, col + 3);
                            ex.SetCellValue(obj.dzsj.ToString(), row + 11 + i, col + 4);
                            ex.SetCellValue(obj.yxqk, row + 11 + i, col + 5);
                            ex.SetCellValue(obj.csr, row + 11 + i, col + 6);
                        }
                    }
                }
            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }
      
    }
}
