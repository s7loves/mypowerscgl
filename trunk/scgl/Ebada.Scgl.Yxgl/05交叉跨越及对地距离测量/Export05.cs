using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// </summary>
    public class Export05  {
        //ExcelAccess
        public static void ExportExcel(PJ_05jcky jl) {

           ExcelAccess ex = new ExcelAccess();
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             string fname = Application.StartupPath + "\\00记录模板\\05交叉跨越及对地距离测量记录.xls";
             ex.Open(fname);
                int row = 1;
                int col = 1;
                int rowcount = 11;
                //
                IList<PJ_05jckyjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_05jckyjl>(" where jckyID='" + jl.jckyID + "' order by CreateDate");
                //加页
                int pageindex = 1;
                if (pageindex < Ecommon.GetPagecount(list.Count, 15))
                {
                    pageindex = Ecommon.GetPagecount(list.Count, 15);
                }
                for (int j = 1; j <= pageindex; j++)
                {
                    if (j > 1)
                    {
                        ex.CopySheet(1, 1);
                    }
                }
                PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
                ex.ActiveSheet(1);
                ex.SetCellValue(xlobject.LineName, row + 3, col);
                PS_xl xlobject2 = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.gtID);

                ex.SetCellValue("'" + xlobject2.LineName, row + 3, col + 3);
                ex.SetCellValue(jl.kywz, row + 3, col + 6);

                //交叉跨越行
                ex.SetCellValue(jl.kygh, row + 6, col);
                ex.SetCellValue(jl.gdjl.ToString(), row + 6, col + 3);
                ex.SetCellValue(jl.kymc, row + 6, col + 4);
                ex.SetCellValue(jl.ssdw, row + 6, col + 5);
                ex.SetCellValue(jl.jb, row + 6, col + 7);
                //测量记录
              
                ex.ShowExcel();
                for (int j = 1; j <= pageindex; j++)
                {
                    ex.ActiveSheet(j);
                    //ex.ReNameWorkSheet(j, "Sheet" + (j));
                    int prepageindex = j - 1;
                    //主题
                    int starow = prepageindex * 15 + 1;
                    int endrow = j * 15;
                   
                    if (list.Count > endrow)
                    {
                        for (int i = 0; i < 15; i++)
                        {

                            string str = list[starow - 1 + i].clrqz;
                            string[] mans = str.Split(new char[1] { ';' });
                            ex.SetCellValue(list[starow - 1 + i].clrq.Year.ToString(), rowcount+ i, col);
                            ex.SetCellValue(list[starow - 1 + i].clrq.Month.ToString(), rowcount + i, col + 1);
                            ex.SetCellValue(list[starow - 1 + i].clrq.Day.ToString(), rowcount + i, col + 2);
                            ex.SetCellValue(list[starow - 1 + i].scz.ToString(), rowcount + i, col + 3);
                            ex.SetCellValue(list[starow - 1 + i].qw, rowcount + i, col + 4);
                            ex.SetCellValue(mans[0], rowcount + i, col + 5);
                            ex.SetCellValue(mans[1], rowcount + i, col + 6);
                            ex.SetCellValue(list[starow - 1 + i].jr, rowcount + i, col + 7);

                        }
                    }
                    else if (list.Count <= endrow && list.Count >= starow)
                    {
                        for (int i = 0; i < list.Count - starow + 1; i++)
                        {
                            string str = list[starow - 1 + i].clrqz;
                            string[] mans = str.Split(new char[1] { ';' });
                            ex.SetCellValue(list[starow - 1 + i].clrq.Year.ToString(), rowcount + i, col);
                            ex.SetCellValue(list[starow - 1 + i].clrq.Month.ToString(), rowcount + i, col + 1);
                            ex.SetCellValue(list[starow - 1 + i].clrq.Day.ToString(), rowcount + i, col + 2);
                            ex.SetCellValue(list[starow - 1 + i].scz.ToString(), rowcount + i, col + 3);
                            ex.SetCellValue(list[starow - 1 + i].qw, rowcount + i, col + 4);
                            
                            ex.SetCellValue(mans[0], rowcount + i, col + 5);
                            ex.SetCellValue(mans[1], rowcount + i, col + 6);
                            ex.SetCellValue(list[starow - 1 + i].jr, rowcount + i, col + 7);

                        }
                    }

                }
                ex.ActiveSheet(1);
                
                ex.ShowExcel();
                
        }
            
    }
}
