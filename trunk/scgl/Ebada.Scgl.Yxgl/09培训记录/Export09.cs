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
    public class Export09  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_09pxjl obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\09培训记录.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 60;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 1;
            int col = 1;
            
            //培训时间
            row = 2;
            ex.SetCellValue(obj.rq.Year.ToString(), 4, 2);

            ex.SetCellValue(obj.rq.Month.ToString(), 4, 4);

            ex.SetCellValue(obj.rq.Day.ToString(), 4, 6);
            //学习时数
            string[] ary = obj.xxss.Split(jksign);
            if (ary.Length>=1)
            {
                ex.SetCellValue(ary[0], 4, 9);
            }
            else
            {
                ex.SetCellValue("", 4, 9);
            }
            if (ary.Length >= 2)
            {
                ex.SetCellValue(ary[1], 4, 11);
            }
            else
            {
                ex.SetCellValue("", 4, 11);
            }
            //参加人数
            ex.SetCellValue(obj.cjrs, 4, 14);
            //主持人
            ex.SetCellValue(obj.zcr, 6, 3);
            ex.SetCellValue(obj.zjr, 6, 9);
            //会议地点
            ex.SetCellValue(obj.hydd, 6, 14);

            //题目
            string timustr = "题目：" + obj.tm;
            List<string> timulist = Ecommon.ResultStrList(timustr, zc);
            for (int i = 0; i < timulist.Count; i++)
            {
                if (i >= 4)
                {
                    break;
                }
                ex.SetCellValue(timulist[i], 7 + i, 1);
            }
            //活动内容
            string hdstr =  obj.nr;
            List<string > hdlist = Ecommon.ResultStrList(hdstr, zc);
            for (int r = 0; r < hdlist.Count; r++)
            {
                if (r >= 9)
                {
                    break;
                }
                ex.SetCellValue(hdlist[r], 12 + r, 1);
            }
           
            //领导评语
            string ldpystr = "领导检查评语：" + obj.py;
            List<string> ldpylist = Ecommon.ResultStrList(ldpystr, zc);
            for (int t = 0; t < ldpylist.Count; t++)
            {
                if (t>=3)
                {
                    break;
                }
                ex.SetCellValue(ldpylist[t], 21 + t, 1);
            }
          
            //签字
           
            ex.SetCellValue(obj.qz, 24, 3);
            ex.SetCellValue(obj.qzrq.Year.ToString(), 24, 8);
            ex.SetCellValue(obj.qzrq.Month.ToString(), 24, 10);
            ex.SetCellValue(obj.qzrq.Day.ToString(), 24, 12);

            ex.ShowExcel();
           
        }
      
    }
}
