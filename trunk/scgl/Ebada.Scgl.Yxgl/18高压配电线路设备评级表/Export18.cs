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
        public static void ExportExcel(PJ_18gysbpj obj) 
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\18双河所设备评级表.xls";
            IList<PJ_18gysbpjmx> objlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_18gysbpjmx>("SelectPJ_18gysbpjmxList", "where PJ_ID='" + obj.PJ_ID + "'");



            ex.Open(fname);
            //此处写填充内容代码
            int pagecout = Ecommon.GetPagecount(objlist.Count, 29);

            //复制空模板并重命名
            for (int m = 1; m < pagecout; m++)
            {
                ex.CopySheet(1, m);
                ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
            }
            for (int p = 0; p < pagecout; p++)
            {
                ex.ActiveSheet(p + 1);
                ex.SetCellValue("绥化农电局  " + obj.OrgName, 4, 1);

                for (int i = 0; i < 29; i++)
                {
                    if (p*29+i>=objlist.Count)
                    {
                        break;
                    }
                    PJ_18gysbpjmx tempobj = objlist[i];
                    //ex.SetCellValue((p * 29 + i).ToString(), 7 + i, 1);
                    ex.SetCellValue(tempobj.xh.ToString(), 7 + i, 1);
                    ex.SetCellValue(tempobj.sbdy, 7 + i, 2);
                    ex.SetCellValue(tempobj.one.ToString(), 7 + i, 5);
                    ex.SetCellValue(tempobj.two.ToString(), 7 + i, 6);
                    ex.SetCellValue(tempobj.three.ToString(), 7 + i, 9);
                    ex.SetCellValue(tempobj.whl + "%", 7 + i, 12);
                    ex.SetCellValue(tempobj.qxnr, 7 + i, 13);
                    ex.SetCellValue(tempobj.fzdw, 7 + i, 14);

                }
    //            ex.SetCellValue(obj.fzr, 36, 2);
                ex.SetCellValue(obj.zbr, 36, 4);
                ex.SetCellValue(obj.rq.Year.ToString(), 36, 6);
                ex.SetCellValue(obj.rq.Month.ToString(), 36, 8);
                ex.SetCellValue(obj.rq.Day.ToString(), 36, 10);
            }
           ex.ActiveSheet(1);
           ex.ShowExcel();
        }
      
    }
}
