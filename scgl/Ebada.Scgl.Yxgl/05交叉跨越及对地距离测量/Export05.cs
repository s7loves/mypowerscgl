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
                //
                ex.SetCellValue(jl.LineID, row + 3, col);
                ex.SetCellValue(jl.gtID, row + 3, col + 3);

                //交叉跨越行
                ex.SetCellValue(jl.kygh, row + 6, col);
                ex.SetCellValue(jl.gdjl.ToString(), row + 6, col + 3);
                ex.SetCellValue(jl.kymc, row + 6, col + 4);
                ex.SetCellValue(jl.ssdw, row + 6, col + 5);
                ex.SetCellValue(jl.jb, row + 6, col + 7);
                //测量记录
                IList<PJ_05jckyjl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_05jckyjl>(" where jckyID='" + jl.jckyID + "' order by CreateDate");
                for (int i = 0; i < list.Count;i++ )
                {
                    PJ_05jckyjl obj = list[i];
                    ex.SetCellValue(obj.clrq.Year.ToString(), row + 10 + i, col);
                    ex.SetCellValue(obj.clrq.Month.ToString(), row + 10 + i, col+1);
                    ex.SetCellValue(obj.clrq.Day.ToString(), row + 10 + i, col+2);
                    ex.SetCellValue(obj.scz.ToString(), row + 10 + i, col + 3);
                    ex.SetCellValue(obj.qw, row + 10 + i, col + 4);
                    ex.SetCellValue(obj.clrqz, row + 10 + i, col + 5);
                    ex.SetCellValue(obj.jr, row + 10 + i, col + 7);
                }
                
                ex.ShowExcel();
                
        }
            
    }
}
