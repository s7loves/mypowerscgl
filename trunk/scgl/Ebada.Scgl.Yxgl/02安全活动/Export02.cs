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
    public class Export02  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_02aqhd obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\02安全活动记录.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 60;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 1;
            int col = 1;

            //主持人
            ex.SetCellValue(obj.zcr, 4, 2);
            
            //开始时间
            row = 2;
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 2, col + 4);
           
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 2, col + 6);
           
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 2, col + 8);
           
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 2, col + 10);
          
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 2, col + 12);
           
            //结束时间
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 3, col + 4);
          
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 3, col + 6);
           
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 3, col + 8);
         
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 3, col + 10);
            
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 3, col + 12);
           
            //出席人员
            string[] ary = obj.cjry.Split(jksign);
            int m = ary.Length / 8;
            int n = ary.Length % 8;
            if (n > 0) {
                m++;
            }
            if (m == 0) {
                m++;
            }
           
            for (int i = 0; i < ary.Length; i++)
            {
                int tempcol = col + 1 + i % 8;
                if (i % 8 > 3)
                {
                    tempcol = col + 4 + (i % 8 - 3) * 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 8, tempcol);
            }
            //缺席人员
            string[] ary2 = obj.qxry.Split(jksign);
        
            for (int j = 0; j < ary2.Length; j++)
            {
                int tempcol = col + 2 + j % 7;
                if (j > 2 && j < 7)
                {
                    tempcol = col + 4 + (j % 7 - 2) * 2;
                }
                if (j < 7)
                {
                    ex.SetCellValue(ary2[j], row + 7, tempcol);
                }
                else//缺席人员大于七个时
                {
                    string tempstr = ex.ReadCellValue(row + 7, col + 12);
                    tempstr = tempstr + "/" + ary2[j];
                    ex.SetCellValue(tempstr, row + 7, col + 12);
                }

            }
            //活动内容
           
            string hdstr = "活动内容：" + obj.hdnr;
            List<string > hdlist = Ecommon.ResultStrList(hdstr, zc);
            for (int r = 0; r < hdlist.Count; r++)
            {
                ex.SetCellValue(hdlist[r], 10 + r, 1);
            }
           
          
            //活动小结
            string hdxjstr = "活动小结：" + obj.hdxj;
            List<string> hdxlist = Ecommon.ResultStrList(hdxjstr, zc);
            for (int s = 0; s < hdxlist.Count; s++)
            {

                ex.SetCellValue(hdxlist[s], 18 + s, 1);
            }
           
            //领导评语
            string ldpystr = "领导检查评语：" + obj.py;
            List<string> ldpylist = Ecommon.ResultStrList(ldpystr, zc);
            for (int t = 0; t < ldpylist.Count; t++)
            {
                ex.SetCellValue(ldpylist[t], 23 + t, 1);
            }
          
            //签字
            ex.SetCellValue("签字: ", 25, 1);
            ex.SetCellValue(obj.qz, 25, col + 1);
            ex.SetCellValue(obj.qzrq.Year.ToString(), 25, 5);
            ex.SetCellValue(obj.qzrq.Month.ToString(), 25, 7);
            ex.SetCellValue(obj.qzrq.Day.ToString(), 25, 11);

            ex.ShowExcel();
           
        }
      
    }
}
