using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Windows.Forms;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportQX
    {
        public static void ExportExcel(Dictionary<string, List<PJ_qxfl>> objdic)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\06设备巡视及缺陷消除记录.xls";

            ex.Open(fname);
            int zc = 20;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 7;
            int col = 1;
            int len1 = 3;
            int pageindex = 1;
            pageindex = objdic.Count;
            //根据所有的线路数来确定创建的页数
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
            }
            int pags = 0;
            foreach (KeyValuePair<string, List<PJ_qxfl>> pp in objdic)
            {
                List<PJ_qxfl> objlist = pp.Value;
                ex.ActiveSheet(pags++);

            }
           
        }
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<PJ_qxfl> objlist) 
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\06设备巡视及缺陷消除记录.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 20;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 7;
            int col = 1;
            int len1 = 3;
            ex.SetCellValue(objlist[0].LineName, 4, 4);
            ex.SetCellValue(objlist[0].xlqd, 4, 8);
            int pagecout = Ecommon.GetPagecount(objlist.Count, 9);
            //复制空模板
            for (int m = 1; m < pagecout; m++) 
            {
                ex.CopySheet(1, m);
                ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
            }

            for (int p = 0; p < pagecout; p++)
            {
                ex.ActiveSheet(p + 1);
                for (int i = 0; i < 9; i++)
                {
                    if (p*9+i>=objlist.Count)
                    {
                        break;
                    }
                    PJ_qxfl tempobj = objlist[p * 9 + i];
                    //巡视时间
                    ex.SetCellValue(tempobj.xssj.Year.ToString(), row + i * len1, 1);
                    ex.SetCellValue(tempobj.xssj.Month.ToString(), row + i * len1, 2);
                    ex.SetCellValue(tempobj.xssj.Day.ToString(), row + i * len1, 3);
                    //缺陷内容
                    List<string> tempstr = Ecommon.ResultStrList(tempobj.qxnr, zc);
                    if (tempstr.Count >= 1)
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
                    ex.SetCellValue(tempobj.qxlb, row + i * len1, 7);
                    //巡视人
                    string[] ary = tempobj.xsr.Split(jksign);
                    if (ary.Length >= 1)
                    {
                        ex.SetCellValue(ary[0], row + 2 + i * len1, 5);
                    }
                    else
                    {
                        ex.SetCellValue("", row + 2 + i * len1, 5);
                    }
                    if (ary.Length >= 2)
                    {
                        ex.SetCellValue(ary[1], row + 2 + i * len1, 6);
                    }
                    else
                    {
                        ex.SetCellValue("", row + 2 + i * len1, 6);
                    }
                    //消除人
                    string[] ary2 = tempobj.xcr.Split(jksign);
                    if (ary2.Length >= 1)
                    {
                        ex.SetCellValue(ary2[0], row + i * len1, 9);
                    }
                    else
                    {
                        ex.SetCellValue("", row + i * len1, 9);
                    }
                    if (ary2.Length >= 2)
                    {
                        ex.SetCellValue(ary2[1], row + i * len1, 12);
                    }
                    else
                    {
                        ex.SetCellValue("", row + i * len1, 12);
                    }
                    //消除时间
                    if (ComboBoxHelper.CompreDate(tempobj.xcrq))
                    {
                        ex.SetCellValue(tempobj.xcrq.Year.ToString(), row + 2 + i * len1, 8);
                        ex.SetCellValue(tempobj.xcrq.Month.ToString(), row + 2 + i * len1, 11);
                        ex.SetCellValue(tempobj.xcrq.Day.ToString(), row + 2 + i * len1, 13);
                    }
                   

                }

            }

            ex.ActiveSheet(1);

            ex.ShowExcel();
           
        }
      
    }
}
