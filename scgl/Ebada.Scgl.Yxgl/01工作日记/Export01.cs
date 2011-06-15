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
    public class Export01  {
        //ExcelAccess
        public static void ExportExcel(PJ_01gzrj jl, IList<PJ_gzrjnr> nrList) {

           ExcelAccess ex = new ExcelAccess();
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             string fname = Application.StartupPath + "\\00记录模板\\01工作日志.xls";
             ex.Open(fname);
                int row = 1;
                int col = 1;
                int row_nr = 9;
                int row_num = 36*2;
                List<string> strpy= Ecommon.ResultStrList("领导检查评语："+jl.py, row_num);
                List<string> strjs = Ecommon.ResultStrList("记事：" + jl.js, row_num);
                int p=Ecommon.GetPagecount(strpy.Count+strjs.Count, 5);
                System.Collections.ArrayList objlist = new System.Collections.ArrayList();
                objlist.Add(strjs);
                objlist.Add(strpy);
                List<string> allList = Ecommon.GetCollList(objlist);
                for (int i = 0; i < p-1;i++ )
                {
                    ex.CopySheet(1, 1 + i);
                }
                for (int page = 1; page <= p; page++)
                {
                    ex.ActiveSheet(page);
                    if (page == 1)
                    {
                        //日期
                        ex.SetCellValue(jl.rq.Year.ToString(), row + 3, col + 1);
                        ex.SetCellValue(jl.rq.Month.ToString(), row + 3, col + 3);
                        ex.SetCellValue(jl.rq.Day.ToString(), row + 3, col + 5);
                        ex.SetCellValue(jl.xq.Replace("星期", ""), row + 3, col + 10);
                        //姓名、原因
                        string[] rr = new string[10];
                        string[] yy = new string[10];
                        string[] rr2 = jl.qqry.Split(";".ToCharArray());
                        for (int i = 0; i < rr2.Length - 1; i++)
                        {
                            rr[i] = rr2[i].Split(":".ToCharArray())[0];
                            yy[i] = rr2[i].Split(":".ToCharArray())[1];
                        }
                        for (int i = rr2.Length - 1; i < rr.Length; i++)
                        {
                            rr[i] = "";
                            yy[i] = "";
                        }
                        ex.SetCellValue(rr[0], row + 4, col + 2);
                        ex.SetCellValue(rr[1], row + 4, col + 4);
                        ex.SetCellValue(rr[2], row + 4, col + 6);
                        ex.SetCellValue(rr[3], row + 4, col + 8);
                        ex.SetCellValue(rr[4], row + 4, col + 10);
                        ex.SetCellValue(rr[5], row + 6, col + 2);
                        ex.SetCellValue(rr[6], row + 6, col + 4);
                        ex.SetCellValue(rr[7], row + 6, col + 6);
                        ex.SetCellValue(rr[8], row + 6, col + 8);
                        ex.SetCellValue(rr[9], row + 6, col + 10);
                        ex.SetCellValue(yy[0], row + 5, col + 2);
                        ex.SetCellValue(yy[1], row + 5, col + 4);
                        ex.SetCellValue(yy[2], row + 5, col + 6);
                        ex.SetCellValue(yy[3], row + 5, col + 8);
                        ex.SetCellValue(yy[4], row + 5, col + 10);
                        ex.SetCellValue(yy[5], row + 7, col + 2);
                        ex.SetCellValue(yy[6], row + 7, col + 4);
                        ex.SetCellValue(yy[7], row + 7, col + 6);
                        ex.SetCellValue(yy[8], row + 7, col + 8);
                        ex.SetCellValue(yy[9], row + 7, col + 10);

                        //人身,设备
                        ex.SetCellValue(jl.rsaqts.ToString(), row + 5, col + 13);
                        ex.SetCellValue(jl.sbaqts.ToString(), row + 7, col + 13);
                        //工作内容
                        IList<PJ_gzrjnr> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_gzrjnr>(" where gzrjID='" + jl.gzrjID + "' order by seq");
                        for (int i = 0; i < list.Count; i++)
                        {
                            PJ_gzrjnr obj = list[i];
                            ex.SetCellValue(obj.seq.ToString(), row + 9 + i, col);
                            ex.SetCellValue(obj.gznr, row + 9 + i, col + 1);
                            ex.SetCellValue(obj.fzr, row + 9 + i, col + 8);
                            ex.SetCellValue(obj.cjry, row + 9 + i, col + 11);
                        }
                        for (int i = list.Count; i < 10; i++)
                        {
                            ex.SetCellValue((i + 1).ToString(), row + 9 + i, col);
                        }

                        //记事
                        for (int n = 0; n < 5; n++)
                        {
                            if (n + (page - 1) * 5 < allList.Count)
                            {
                                ex.SetCellValue(allList[n + (page - 1) * 5], row + 9 + n + row_nr, col);
                            }
                        }
                        
                        //签字、时间
                        ex.SetCellValue(jl.qz, row + 14 + row_nr, col + 2);
                        ex.SetCellValue(jl.qzrq.Year.ToString(), row + 14 + row_nr, col + 6);
                        ex.SetCellValue(jl.qzrq.Month.ToString(), row + 14 + row_nr, col + 9);
                        ex.SetCellValue(jl.qzrq.Day.ToString(), row + 14 + row_nr, col + 11);
                    }
                    else
                    {
                        for (int n = 0; n < 5; n++)
                        {
                            if (n + (page - 1) * 5 < allList.Count)
                            {
                                ex.SetCellValue(allList[n + (page - 1) * 5], row + 9 + n + row_nr, col);
                            }
                        }
                    }
                }
                ex.ActiveSheet(1);
                ex.ShowExcel();
                
        }
            
    }
}
