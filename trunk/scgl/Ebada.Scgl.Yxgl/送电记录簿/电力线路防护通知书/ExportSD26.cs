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
    public class ExportSD26
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(sdjl_26 obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电17防护通知书.xls";
            int sz = 30;//一行最多30个
            ex.Open(fname);
            //此处写填充内容代码
            ex.ActiveSheet(1);
            //通知单位
            ex.SetCellValue(obj.tzdw, 5, 1);
            //电压
            ex.SetCellValue(obj.lineVol, 6, 7);
            //线路
            ex.SetCellValue(obj.c1, 6, 9);
            //发现问题
            List<string> fxwtList = GetList(obj.fxwt, sz);
            for (int i = 0; i < fxwtList.Count; i++)
            {
                ex.SetCellValue(fxwtList[i], 7+i, 1);
                if (i > 1)
                    break;
            }
            //处理措施
            List<string> clcsList = GetList(obj.clcs, sz);
            for (int i = 0; i < clcsList.Count; i++)
            {
                ex.SetCellValue(obj.clcs, 12+i, 1);
                if (i > 2)
                    break;
            }
           
           ex.ShowExcel();
        }

        private static List<string> GetList(string nr, int size)
        {
            List<string> strList = new List<string>();
            if (nr.Length < size)
            {
                strList.Add(nr);
                return strList;
            }
            int count = 1;
            if (nr.Length % size == 0)
            {
                count = nr.Length / size;
            }
            else
            {
                count = nr.Length / size + 1;
            }
            for (int i = 0; i <count; i++)
            {
                if (i == count - 1)
                {
                    strList.Add(nr.Substring(i * size, nr.Length - i * size));
                }
                else
                {
                    strList.Add(nr.Substring(i * size, size));
                }

            }
            return strList;
        }
      
    }
}
