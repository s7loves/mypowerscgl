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
                //线路名称行
                ex.SetCellValue(jl.LineName, row + 4, col+2);
                ex.SetCellValue(jl.gth, row + 4, col + 15);

                //设备名称行
                ex.SetCellValue(jl.sbmc, row + 7, col);
                ex.SetCellValue(jl.xhgg, row + 7, col + 3);
                ex.SetCellValue(jl.jddz.ToString(), row + 7, col + 5);
                ex.SetCellValue(jl.tz, row + 7, col + 9);
                ex.SetCellValue(jl.trdzr.ToString(), row + 7, col + 11);
                //测量记录
                IList<PJ_07jdzzjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_07jdzzjl>(" where jdzzID='" + jl.jdzzID + "' order by clrq");
                for (int i = 0; i < list.Count;i++ )
                {
                    PJ_07jdzzjl obj = list[i];
                    ex.SetCellValue(obj.clrq.Year.ToString(), row + 9 + i, col);
                    ex.SetCellValue(obj.clrq.Month.ToString(), row + 9 + i, col+1);
                    ex.SetCellValue(obj.clrq.Day.ToString(), row + 9 + i, col+2);
                    ex.SetCellValue(obj.tq, row + 9 + i, col + 3);
                    ex.SetCellValue(obj.scz.ToString(), row + 9 + i, col + 4);
                    ex.SetCellValue(obj.hsz.ToString(), row + 9 + i, col + 5);
                    ex.SetCellValue(obj.jcqk, row + 9 + i, col + 6);
                    ex.SetCellValue(obj.jr, row + 9 + i, col + 7);
                    ex.SetCellValue(obj.jcr, row + 9 + i, col + 8);
                }
                
                ex.ShowExcel();
                
        }
            
    }
}
