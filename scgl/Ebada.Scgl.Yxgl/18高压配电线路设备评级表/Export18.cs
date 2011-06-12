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
    public class Export18 {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<PJ_18gysbpj> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\18双河所设备评级表.xls";

            ex.Open(fname);
            //此处写填充内容代码
            ex.SetCellValue("绥化农电局  " + objlist[0].OrgName, 4, 1);
            for (int i = 0; i < objlist.Count; i++)
            {
                if (i>=29)
                {
                    break;
                }
                ex.SetCellValue(objlist[i].sbdy, 7 + i, 2);
                ex.SetCellValue(objlist[i].one.ToString(), 7 + i, 3);
                ex.SetCellValue(objlist[i].two.ToString(), 7 + i, 4);
                ex.SetCellValue(objlist[i].three.ToString(), 7 + i, 5);
                ex.SetCellValue(objlist[i].whl*100+"%", 7 + i, 6);
                ex.SetCellValue(objlist[i].qxnr, 7 + i, 7);
                ex.SetCellValue(objlist[i].fzdw, 7 + i, 8);

            }

           ex.ShowExcel();
        }
      
    }
}
