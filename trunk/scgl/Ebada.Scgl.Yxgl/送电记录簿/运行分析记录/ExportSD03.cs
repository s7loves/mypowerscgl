using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Scgl.Core;
namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportSD03
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(sdjl_03yxfx obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电03运行分析记录.xls";

            ex.Open(fname);
            //与会人员之间的间隔符号
            string jksign = "@";
            int row = 1;
            int col = 1;
            //每行显示文字长度
            int zc = 60;
            //获得创建的工作表个数
            // int pagemax = 1;
            string zt = Ecommon.Comparestring(obj.zt, "主题") ? "" : "主题：";
            List<string> listztstring = Ecommon.ResultStrList(zt + obj.zt, zc);
            Ecommon.Resultstrbystartbd(ref listztstring);
           
            string jy = Ecommon.Comparestring(obj.jy, "纪要") ? "" : "纪要：";
            List<string> listjy = Ecommon.ResultStrList(jy + obj.jy, zc);
            Ecommon.Resultstrbystartbd(ref listjy);
          
            string jr = Ecommon.Comparestring(obj.jr, "结论及对策") ? "" : "结论及对策：";
            List<string> listjldc = Ecommon.ResultStrList(jr + obj.jr, zc);
            Ecommon.Resultstrbystartbd(ref listjldc);
            
            List<string> listpy = Ecommon.ResultStrList("领导检查评语：" + obj.py, zc);
            Ecommon.Resultstrbystartbd(ref listpy);

            int[] strnumcol = { 0, listztstring.Count, listztstring.Count + listjy.Count, listztstring.Count + listjy.Count + listjldc.Count };
            int[] statnum = { 3, 3, 6, 7 };
            List<string> strcol = new List<string>();
            Ecommon.addstring(listztstring, ref strcol);
            Ecommon.addstring(listjy, ref strcol);
            Ecommon.addstring(listjldc, ref strcol);
            Ecommon.addstring(listpy, ref strcol);
            //Ecommon.CreatandWritesheet(ex, strcol, 15, 9, 1);

            Ecommon.CreatandWritesheet1(ex, strcol, 15, 9, 1,strnumcol,statnum);
            //进行加粗

            ex.ActiveSheet(1);
            //时间
            ex.SetCellValue(obj.rq.Year.ToString(), 4, 5);
            ex.SetCellValue(obj.rq.Month.ToString(), 4, 7);
            ex.SetCellValue(obj.rq.Day.ToString(), 4, 9);

            ////出席人员
            string[] ary = obj.cjry.Split(';');
            int n = ary.Length % 5;
            for (int i = 0; i < ary.Length; i++) {
                int tempcol = col + 1 + i % 5;
                if (i % 5 == 1 || i % 5 == 2 || i % 5 == 3) {
                    tempcol = col + 1 + i % 5 + 1;
                }
                if (i % 5 == 4) {
                    tempcol = col + 1 + i % 5 + 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 5, tempcol);
            }
            //主持人
            ex.SetCellValue(obj.zcr,5,11);
            //检查人签字
            //ex.ActiveSheet(1);
            ex.SetCellValue(obj.qz, 24, 4);

            ex.ShowExcel();

        }
    }
}