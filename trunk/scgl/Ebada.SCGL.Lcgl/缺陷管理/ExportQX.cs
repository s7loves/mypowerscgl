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
            string fname = Application.StartupPath + "\\00记录模板\\缺陷分类统计表.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 20;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 6;
            int col = 2;
            int len1 =1;
            ex.SetCellValue(objlist[0].OrgName, 3, 2);
            int pagecout = Ecommon.GetPagecount(objlist.Count,12);
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
                    PJ_qxfl tempobj = objlist[p *12 + i];
                    //缺陷情况
                    ex.SetCellValue(tempobj.qxnr, row + i * len1, 2);

                    //缺陷类别
                    ex.SetCellValue(tempobj.qxlb, row + i * len1,3);
                  
                   
                    //发现日期
                    if (ComboBoxHelper.CompreDate(tempobj.xssj))
                    {
                        ex.SetCellValue(tempobj.xssj.Year.ToString(), row  + i * len1, 4);
                        ex.SetCellValue(tempobj.xssj.Month.ToString(), row + i * len1, 5);
                        ex.SetCellValue(tempobj.xssj.Day.ToString(), row + i * len1, 6);
                    }
                    //消除时限
                    if (ComboBoxHelper.CompreDate(Convert.ToDateTime(tempobj.xcqx)))
                    {
                        ex.SetCellValue(Convert.ToDateTime(tempobj.xcqx).Year.ToString(), row + i * len1, 7);
                        ex.SetCellValue(Convert.ToDateTime(tempobj.xcqx).Month.ToString(), row + i * len1, 8);
                        ex.SetCellValue(Convert.ToDateTime(tempobj.xcqx).Day.ToString(), row + i * len1, 9);
                    }
                    //备注
                    ex.SetCellValue(tempobj.remark, row + i * len1,10);

                }

            }

            ex.ActiveSheet(1);

            ex.ShowExcel();
           
        }
      
    }
}
