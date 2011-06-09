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
            int zc = 36;
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

            for (int r = 0; r < 8; r++)
            {
                string tempstr = "";
                int startnum = r * zc;
                int endnum = (r + 1) * zc;
                bool ISempty = false;
                if (startnum >= hdstr.Length)
                {
                    ISempty = true;
                }
                else if (endnum >= hdstr.Length)
                {
                    endnum = hdstr.Length;
                }
                if (!ISempty)
                {
                    tempstr = hdstr.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 10 + r, 1);
            }
          
            //活动小结
            string hdxjstr = "活动小结：" + obj.hdxj;

            for (int s = 0; s < 8; s++)
            {
                string tempstr = "";
                int startnum = s * zc;
                int endnum = (s + 1) * zc;
                bool ISempty = false;
                if (startnum >= hdxjstr.Length)
                {
                    ISempty = true;
                }
                else if (endnum >= hdxjstr.Length)
                {
                    endnum = hdxjstr.Length;
                }
                if (!ISempty)
                {
                    tempstr = hdxjstr.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 18 + s, 1);
            }
           
            //领导评语
            string ldpystr = "领导检查评语：" + obj.py;

            for (int t = 0; t < 2; t++)
            {
                string tempstr = "";
                int startnum = t * zc;
                int endnum = (t + 1) * zc;
                bool ISempty = false;
                if (startnum >= ldpystr.Length)
                {
                    ISempty = true;
                }
                else if (endnum >= ldpystr.Length)
                {
                    endnum = ldpystr.Length;
                }
                if (!ISempty)
                {
                    tempstr = ldpystr.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 23 + t, 1);
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
