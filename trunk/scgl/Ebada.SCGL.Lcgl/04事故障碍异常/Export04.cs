using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export04 {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_04sgzayc obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\04事故障碍异常运行记录.xls";

            ex.Open(fname);
            //与会人员之间的间隔符号
            string jksign = "@";
            int row = 1;
            int col = 1;
            //每行显示文字长度
            int zc = 33;
            //要发生变化的部分
            //List<string>[] bhcollect = new List<string>[3] { Ecommon.ResultStrList("三、事故、障碍、异常运行情况及处理经过：" + obj.clqk, zc), Ecommon.ResultStrList("四、主要原因分析：" + obj.yyfx, zc), Ecommon.ResultStrList("五、今后防止对策：" + obj.fzdc, zc) };
            //int[] hs = new int[3] { 4, 5, 5 };
            //int[] starow = new int[3] { 9, 13, 18 };
            //Ecommon.CreatandWritesheet(ex, bhcollect, hs, starow);
            List<string> strcol = new List<string>();
            string sgyc = Ecommon.Comparestring(obj.clqk, "三") ? "" : "三、事故、障碍、异常运行情况及处理经过：";
            string zyyy = Ecommon.Comparestring(obj.yyfx, "四") ? "" : "四、主要原因分析：";
            string jhdc = Ecommon.Comparestring(obj.fzdc, "五") ? "" : "五、今后防止对策：";
            string sgzyc = sgyc + obj.clqk;
            string zyyuy = zyyy + obj.yyfx;
            string fzdc = jhdc + obj.fzdc;
            //Ecommon.addstring(Ecommon.ResultStrList(sgyc+ obj.clqk, zc), ref strcol);
            //Ecommon.addstring(Ecommon.ResultStrList(zyyy + obj.yyfx, zc), ref strcol);
            //Ecommon.addstring(Ecommon.ResultStrList(jhdc + obj.fzdc, zc), ref strcol);
            //Ecommon.CreatandWritesheet(ex, strcol, 14, 9, 1);
            ex.ActiveSheet(1);
            //事故异常发生地点
            ex.SetCellValue(obj.fsdd, 5, 6);
            //发生时间
            //停电时间
            ex.SetCellValue(obj.tdsj.Month.ToString(), 6, 5);
            ex.SetCellValue(obj.tdsj.Day.ToString(), 6, 7);
            ex.SetCellValue(obj.tdsj.Hour.ToString(), 6, 9);
            ex.SetCellValue(obj.tdsj.Minute.ToString(), 6, 11);
            //送电时间
            ex.SetCellValue(obj.sdsj.Month.ToString(), 7, 5);
            ex.SetCellValue(obj.sdsj.Day.ToString(), 7, 7);
            ex.SetCellValue(obj.sdsj.Hour.ToString(), 7, 9);
            ex.SetCellValue(obj.sdsj.Minute.ToString(), 7, 11);
            //时间间隔
            int data1 = (obj.sdsj - obj.tdsj).Days;
            int hour1 = (obj.sdsj - obj.tdsj).Hours + data1 * 24;
            int min1 = (obj.sdsj - obj.tdsj).Minutes;
            ex.SetCellValue(hour1.ToString(), 7, 17);
            ex.SetCellValue(min1.ToString(), 7, 19);
            //损失电量
            ex.SetCellValue(obj.ssdl.ToString(), 8, 5);
            //ex.SetCellValue(obj.rq.Month.ToString(), 4, 7);
            //ex.SetCellValue(obj.rq.Day.ToString(), 4, 9);
            //防治对策执行人
            ex.SetCellValue(obj.zxr, 23, 8);
            //记录填写人
            ex.SetCellValue(obj.CreateMan, 24, 8);
            ex.SetCellValue(obj.CreateDate.Month.ToString(), 24, 15);
            ex.SetCellValue(obj.CreateDate.Day.ToString(), 24, 17);

            //事故障碍异常

            //string hdstr = Ecommon.Comparestring(obj.hdnr, "活动内容") ? "" : "活动内容：";
            //List<string> hdlist = Ecommon.ResultStrListByPage(hdstr, obj.clqk, zc, 8);
            string jd1 = "";
            string jd2 = "";
            bool flag = true;
            if (sgzyc.Contains("处理人")) {

                jd1 = sgzyc.Substring(0, sgzyc.LastIndexOf("处理人"));
                jd2 = sgzyc.Substring(sgzyc.LastIndexOf("处理人"));
            } else
                jd1 = sgzyc;
            //for (int i = 0; i < 4; i++)
            //{
            //    string tempstr = "";
            //    int startnum = i * zc;
            //    int endnum = (i + 1) * zc;
            //    bool ISempty = false;
            //    if (startnum >= sgzyc.Length)
            //    {
            //        ISempty = true;
            //    }
            //    else if (endnum >= sgzyc.Length)
            //    {
            //        endnum = sgzyc.Length;
            //    }
            //    if (!ISempty)
            //    {
            //        tempstr = sgzyc.Substring(startnum, endnum - startnum);
            //    }
            //    ex.SetCellValue(tempstr, 9 + i, 1);
            //}
            for (int i = 0; i < 4; i++) {
                string tempstr = "";
                int startnum = i * zc;
                int endnum = (i + 1) * zc;
                bool ISempty = false;
                if (sgzyc.Length > 3 * zc) {
                    jd1 = sgzyc;
                } else if (sgzyc.Length <= 3 * zc && !string.IsNullOrEmpty(jd2)) {
                    ex.SetCellValue(jd2, 12, 1);
                }
                if (startnum >= jd1.Length) {
                    ISempty = true;

                } else if (endnum >= jd1.Length) {
                    endnum = jd1.Length;
                }
                if (!ISempty) {
                    tempstr = jd1.Substring(startnum, endnum - startnum);
                    ex.SetCellValue(tempstr, 9 + i, 1);
                }

            }
            //主要原因分析

            for (int i = 0; i < 5; i++) {
                string tempstr = "";
                int startnum = i * zc;
                int endnum = (i + 1) * zc;
                bool ISempty = false;
                if (startnum >= zyyuy.Length) {
                    ISempty = true;
                } else if (endnum >= zyyuy.Length) {
                    endnum = zyyuy.Length;
                }
                if (!ISempty) {
                    tempstr = zyyuy.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 13 + i, 1);
            }
            //今后放置对策

            for (int i = 0; i < 5; i++) {
                string tempstr = "";
                int startnum = i * zc;
                int endnum = (i + 1) * zc;
                bool ISempty = false;
                if (startnum >= fzdc.Length) {
                    ISempty = true;
                } else if (endnum >= fzdc.Length) {
                    endnum = fzdc.Length;
                }
                if (!ISempty) {
                    tempstr = fzdc.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 18 + i, 1);
            }



            ex.ShowExcel();

        }
    }
}