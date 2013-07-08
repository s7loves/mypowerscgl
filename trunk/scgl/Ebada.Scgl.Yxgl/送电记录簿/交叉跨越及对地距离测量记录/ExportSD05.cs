﻿using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// </summary>
    public class ExportSD05
    {
        //ExcelAccess
        public static void ExportExcel(sdjl_05jcky jl)
        {

            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电06交叉跨越及对地距离测量记录.xls";
            ex.Open(fname);
            int row = 1;
            int col = 1;
            int rowcount = 11;
            //
            IList<sdjl_05jckyjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sdjl_05jckyjl>(" where jckyID='" + jl.jckyID + "' order by CreateDate");
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
            // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
            ex.ActiveSheet(1);
            sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linecode='" + jl.LineID + "'");
            if (xl != null)
            {
                string sublinename = "";
              string linename= andparentlinename(xl);
                string[] fz=linename.Split(" ".ToCharArray());
                if (fz.Length > 2)
                {
                    sublinename += fz[0]+" " +fz[1] + " " + fz[fz.Length - 1];
                }
                else
                    sublinename = linename;
                ex.SetCellValue(linename, row + 3, col+1);
            }
            else
            {
                string sublinename = "";
                string linename = jl.kywz;
                string[] fz = linename.Split(" ".ToCharArray());
                if (fz.Length > 2)
                {
                    sublinename += fz[0] + " " + fz[1] + " " + fz[fz.Length - 1];
                }
                else
                    sublinename = linename;
                ex.SetCellValue(linename, row + 3, col+1);
            }


            //ex.SetCellValue("'" + jl.gtID, row + 3, col + 3);
            //ex.SetCellValue(jl.kywz, row + 3, col + 6);


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
                        //ex.SetCellValue(mans[1], rowcount + i, col + 6);
                        ex.SetCellValue(list[starow - 1 + i].jr, rowcount + i, col + 7);

                    }
                }

            }
            ex.ActiveSheet(1);

            ex.ShowExcel();

        }
        public static void ExportExcel(sdjl_05jcky jl,string years) {

            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电06交叉跨越及对地距离测量记录.xls";
            ex.Open(fname);
            int row = 1;
            int col = 1;
            int rowcount = 11;
            //
            IList<sdjl_05jckyjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sdjl_05jckyjl>(" where jckyID='" + jl.jckyID + "'and year(clrq) in" + years + "order by CreateDate desc");
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(list.Count, 15)) {
                pageindex = Ecommon.GetPagecount(list.Count, 15);
            }
            for (int j = 1; j <= pageindex; j++) {
                if (j > 1) {
                    ex.CopySheet(1, 1);
                }
            }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
            ex.ActiveSheet(1);
            sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where linecode='" + jl.LineID + "'");
            if (xl != null)
            {
                string sublinename = "";
                string linename = andparentlinename(xl);
                string[] fz = linename.Split(" ".ToCharArray());
                if (fz.Length > 2)
                {
                    sublinename += fz[0] + " " + fz[1] + " " + fz[fz.Length - 1];
                }
                else
                    sublinename = linename;
                ex.SetCellValue(linename, row + 3, col + 1);
            }
            else
            {
                string sublinename = "";
                string linename = jl.kywz;
                string[] fz = linename.Split(" ".ToCharArray());
                if (fz.Length > 2)
                {
                    sublinename += fz[0] + " " + fz[1] + " " + fz[fz.Length - 1];
                }
                else
                    sublinename = linename;
                ex.SetCellValue(linename, row + 3, col + 1);
            }

            
            //ex.SetCellValue("'" + jl.gtID, row + 3, col + 3);
            //ex.SetCellValue(jl.kywz, row + 3, col + 6);

            //交叉跨越行
            ex.SetCellValue(jl.kygh, row + 6, col);
            ex.SetCellValue(jl.gdjl.ToString(), row + 6, col + 3);
            ex.SetCellValue(jl.kymc, row + 6, col + 4);
            ex.SetCellValue(jl.ssdw, row + 6, col + 5);
            ex.SetCellValue(jl.jb, row + 6, col + 7);
            //测量记录

            ex.ShowExcel();
            for (int j = 1; j <= pageindex; j++) {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 15 + 1;
                int endrow = j * 15;

                if (list.Count > endrow) {
                    for (int i = 0; i < 15; i++) {

                        string str = list[starow - 1 + i].clrqz;
                        string[] man = str.Split(new char[1] { ';' });
                        string[] mans = new string[3]{"","",""};
                        for (int k = 0; k < man.Length; k++)
                        {
                            mans[i] = man[i];
                        }
                        ex.SetCellValue(list[starow - 1 + i].clrq.Year.ToString(), rowcount + i, col);
                        ex.SetCellValue(list[starow - 1 + i].clrq.Month.ToString(), rowcount + i, col + 1);
                        ex.SetCellValue(list[starow - 1 + i].clrq.Day.ToString(), rowcount + i, col + 2);
                        ex.SetCellValue(list[starow - 1 + i].scz.ToString(), rowcount + i, col + 3);
                        ex.SetCellValue(list[starow - 1 + i].qw, rowcount + i, col + 4);
                        ex.SetCellValue(mans[0], rowcount + i, col + 5);
                        ex.SetCellValue(mans[1], rowcount + i, col + 6);
                        ex.SetCellValue(list[starow - 1 + i].jr, rowcount + i, col + 7);

                    }
                } else if (list.Count <= endrow && list.Count >= starow) {
                    for (int i = 0; i < list.Count - starow + 1; i++) {
                        string str = list[starow - 1 + i].clrqz;
                        string[] man = str.Split(new char[1] { ';' });
                        string[] mans = new string[3] { "", "", "" };
                        for (int k = 0; k < man.Length; k++)
                        {
                            mans[i] = man[i];
                        }
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

      private static string andparentlinename(sd_xl xl)
        {
            string linename = "";
            sd_xl xl1 = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>(" where lineid='" + xl.ParentID + "'");
          if (xl1==null)
          {
           linename=xl.LineName;
          }
          else
          {
              linename += andparentlinename(xl1)+" ";
              linename += xl.LineName;
          }
          return linename;
        }

    }
}
