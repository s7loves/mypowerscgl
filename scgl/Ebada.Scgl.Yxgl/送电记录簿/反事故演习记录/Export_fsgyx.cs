using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export_fsgyx
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(sdjls_fsgyxjl obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电反事故演习记录.xls";

            ex.Open(fname);

            ex.ActiveSheet(1);
            //每行显示文字长度
            int zc = 39;
            //日期
            ex.SetCellValue(obj.yxrq.Year.ToString(),4,2);
            ex.SetCellValue(obj.yxrq.Month.ToString(), 4, 4);
            ex.SetCellValue(obj.yxrq.Day.ToString(), 4, 6);
            //单位
            ex.SetCellValue(obj.yxdd,4,11);
            //时间
            ex.SetCellValue(obj.kssj.Hour.ToString(),5,2);
            ex.SetCellValue(obj.kssj.Minute.ToString(), 5, 6);
            ex.SetCellValue(obj.jssj.Hour.ToString(), 5, 11);
            ex.SetCellValue(obj.jssj.Minute.ToString(),5,13);
            //演习地点
            ex.SetCellValue(obj.yxdd, 6, 3);
            //演习题目
            ex.SetCellValue(obj.yxtm, 7, 3);

            ex.SetCellValue(obj.ldr, 8, 3);
            ex.SetCellValue(obj.jhr, 8, 11);

            string jljpj = Ecommon.Comparestring(obj.jljpj, "结论及对参加演习人的评价") ? "" : "结论及对参加演习人的评价:";
            jljpj = jljpj + obj.jljpj;

            
            //结论及对参加演习人的评价
            for (int i = 0; i < 8; i++)
            {
                string tempstr = "";
                int startnum = i * zc;
                int endnum = (i + 1) * zc;
                bool ISempty = false;
                if (startnum >= jljpj.Length)
                {
                    ISempty = true;
                }
                else if (endnum >= jljpj.Length)
                {
                    endnum = jljpj.Length;
                }
                if (!ISempty)
                {
                    tempstr = jljpj.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 9 + i, 1);
                if (i == 0)
                {
                   ex.SetFontBold(9, 1, 9, 1, true, 1, 13);
                }
            }
            //根据演习结果拟定的措施

            int cszs = 23;
            for (int i = 0; i < 4; i++)
            {
                string tempstr = "";
                int startnum = i * cszs;
                int endnum = (i + 1) * cszs;
                bool ISempty = false;
                if (startnum >= obj.ndcs.Length)
                {
                    ISempty = true;
                }
                else if (endnum >= obj.ndcs.Length)
                {
                    endnum = obj.ndcs.Length;
                }
                if (!ISempty)
                {
                    tempstr = obj.ndcs.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 18 + i, 1);
            }
            //执行人
            ex.SetCellValue(obj.zxr, 18, 10);
            ex.SetCellValue(obj.zgxq.Year+"年"+obj.zgxq.Month+"月"+obj.zgxq.Day+"日", 18, 11);
            ex.SetCellValue(obj.qzldr, 22, 2);
            ex.SetCellValue(obj.qzjhr,22,10);
            ex.ShowExcel();

        }
    }
}