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
    public class Export07  {
        //ExcelAccess
        public static void ExportExcel(PJ_07jdzz jl) {

           ExcelAccess ex = new ExcelAccess();
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             string fname = Application.StartupPath + "\\00记录模板\\07接地装置检测记录.xls";
             ex.Open(fname);
                int row = 1;
                int col = 1;
                //测量记录
                IList<PJ_07jdzzjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_07jdzzjl>(" where jdzzID='" + jl.jdzzID + "' order by clrq");
                int p = Ecommon.GetPagecount(list.Count, 16);

                for (int i = 0; i < p - 1; i++)
                {
                    ex.CopySheet(1, 1 + i);
                }
                ex.ActiveSheet(1);

                //线路名称行
                ex.SetCellValue(jl.LineName, row + 4, col+2);
                ex.SetCellValue(jl.fzxl, row + 4, col + 6);
                ex.SetCellValue(jl.gzwz,row + 4, col + 11);
                ex.SetCellValue("'"+jl.gth, row + 4, col + 15);
                 
                //设备名称行
                ex.SetCellValue(jl.sbmc, row + 7, col);
                //ex.SetCellValue(jl.xhgg, row + 7, col + 3);
                string[] str = jl.xhgg.Split('|');
                if (str.Length>=1)
                {
                    ex.SetCellValue(str[0], row + 7, col + 3);
                }
                if (str.Length >=2 )
                {
                    ex.SetCellValue(str[1], row + 7, col + 4);
                }
              
                ex.SetCellValue(jl.jddz.ToString(), row + 7, col + 5);
                ex.SetCellValue(jl.tz, row + 7, col + 9);
                ex.SetCellValue(jl.trdzr.ToString(), row + 7, col + 11);

                for (int page = 1; page <= p; page++)
                {
                    ex.ActiveSheet(page);
                    if (page == 1)
                    {

                        for (int i = 0; i < 16; i++)
                        {

                            if (i + (page - 1) * 16 < list.Count)
                            {
                                PJ_07jdzzjl obj = list[i + (page - 1) * 16];
                                ex.SetCellValue(obj.clrq.Year.ToString(), row + 9 + i, col);
                                ex.SetCellValue(obj.clrq.Month.ToString(), row + 9 + i, col + 1);
                                ex.SetCellValue(obj.clrq.Day.ToString(), row + 9 + i, col + 2);
                                ex.SetCellValue(obj.tq, row + 9 + i, col + 3);
                                ex.SetCellValue(obj.scz.ToString(), row + 9 + i, col + 4);
                                ex.SetCellValue(obj.hsz.ToString(), row + 9 + i, col + 6);
                                ex.SetCellValue(obj.jcqk, row + 9 + i, col + 8);
                                ex.SetCellValue(obj.jr, row + 9 + i, col + 10);
                                //ex.SetCellValue(obj.jcr, row + 9 + i, col + 12);
                                string[] jcrstr = obj.jcr.Split(';');
                                if (jcrstr.Length >= 1)
                                {
                                    ex.SetCellValue(jcrstr[0], row + 9 + i, col + 12);
                                }
                                if (jcrstr.Length >= 2)
                                {
                                    ex.SetCellValue(jcrstr[1], row + 9 + i, col + 15);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 16; i++)
                        {

                            if (i + (page - 1) * 16 < list.Count)
                            {
                                PJ_07jdzzjl obj = list[i + (page - 1) * 16];
                                ex.SetCellValue(obj.clrq.Year.ToString(), row + 9 + i, col);
                                ex.SetCellValue(obj.clrq.Month.ToString(), row + 9 + i, col + 1);
                                ex.SetCellValue(obj.clrq.Day.ToString(), row + 9 + i, col + 2);
                                ex.SetCellValue(obj.tq, row + 9 + i, col + 3);
                                ex.SetCellValue(obj.scz.ToString(), row + 9 + i, col + 4);
                                ex.SetCellValue(obj.hsz.ToString(), row + 9 + i, col + 6);
                                ex.SetCellValue(obj.jcqk, row + 9 + i, col + 8);
                                ex.SetCellValue(obj.jr, row + 9 + i, col + 10);

                                string[] jcrstr = obj.jcr.Split(';');
                                if (jcrstr.Length >= 1)
                                {
                                    ex.SetCellValue(jcrstr[0], row + 9 + i, col + 12);
                                }
                                if (jcrstr.Length >= 2)
                                {
                                    ex.SetCellValue(jcrstr[1], row + 9 + i, col + 15);
                                }
                                //ex.SetCellValue(obj.jcr, row + 9 + i, col + 12);
                            }
                        }
                    }
                }
                ex.ActiveSheet(1);
                ex.ShowExcel();
                
        }
            
    }
}
