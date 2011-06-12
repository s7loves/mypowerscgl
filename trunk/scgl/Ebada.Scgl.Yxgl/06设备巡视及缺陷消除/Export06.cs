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
    public class Export06  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<PJ_06sbxs> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\06设备巡视及缺陷消除记录.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 15;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 7;
            int col = 1;
            int len1 = 3;
            ex.SetCellValue(objlist[0].LineName.ToString(), 4, 4);
            ex.SetCellValue(objlist[0].xlqd, 4, 8);
            for (int i = 0; i < objlist.Count; i++)
            {
                if (i==9)
                {
                    break;
                }
                //巡视时间
                ex.SetCellValue(objlist[i].xssj.Year.ToString(), row + i * len1, 1);
                ex.SetCellValue(objlist[i].xssj.Month.ToString(), row + i * len1, 2);
                ex.SetCellValue(objlist[i].xssj.Day.ToString(), row + i * len1, 3);
                //缺陷内容
                List<string> tempstr = Ecommon.ResultStrList(objlist[i].qxnr, zc);
                if (tempstr.Count>=1)
                {
                    ex.SetCellValue(tempstr[0], row + i * len1, 4);
                }
                else
                {
                    ex.SetCellValue("", row + i * len1, 4);
                }
                if (tempstr.Count >= 2)
                {
                    ex.SetCellValue(tempstr[1], row + i * len1 + 1, 4);
                }
                else
                {
                    ex.SetCellValue("", row + i * len1 + 1, 4);
                }
                //缺陷类别
                ex.SetCellValue(objlist[i].qxlb, row + i * len1, 7);
                //巡视人
                string[] ary = objlist[i].xsr.Split(jksign);
                if (ary.Length>=1)
                {
                    ex.SetCellValue(ary[0], row + 3 + i * len1, 5);
                }
                else
                {
                    ex.SetCellValue("", row + 3 + i * len1, 5);
                }
                if (ary.Length>=2)
                {
                    ex.SetCellValue(ary[1], row + 3 + i * len1, 6);
                }
                else
                {
                    ex.SetCellValue("", row + 3 + i * len1, 6);
                }
                //消除人
                string[] ary2 = objlist[i].xcr.Split(jksign);
                if (ary.Length >= 1)
                {
                    ex.SetCellValue(ary2[0], row + i * len1, 9);
                }
                else
                {
                    ex.SetCellValue("", row + i * len1, 9);
                }
                if (ary.Length >= 2)
                {
                    ex.SetCellValue(ary2[1], row  + i * len1, 12);
                }
                else
                {
                    ex.SetCellValue("", row + i * len1,12);
                }
                //消除时间
                ex.SetCellValue(objlist[i].xcrq.Year.ToString(), row + 3 + i * len1, 8);
                ex.SetCellValue(objlist[i].xcrq.Month.ToString(), row + 3 + i * len1, 11);
                ex.SetCellValue(objlist[i].xcrq.Day.ToString(), row + 3 + i * len1, 13);

            }
            
           

            ex.ShowExcel();
           
        }
      
    }
}
