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
            //与会人员之间的间隔符号
            string jksign = "@";
            int row = 1;
            int col = 1;
            string fixstr1 = "附录02";
            string fixname = "安 全 活 动 记 录";
            string fixfyjl = "发 言 简 要 记 录";
            string fixzhuchi = "主持人";
            string fixhd = "活动";
            string fixstart = "开始";
            string fixend = "结束";
            string fixtime = "时间";
            string fixcxry = "出席人员";
            string fixqxry = "缺席人员";
            string fixhdnr = "活动内容：";
            string fixxj = "活动小结： ";
            string fixldpy = "领导检查评语：";
            string fixqz = "签字：";
            string fixjs = "黑龙江省农村电气化局-配管-02";

            //具体主持人
            ex.SetCellValue(obj.zcr, 4, 2);
            
            //开始时间
            row = 2;
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 2, col + 4);
            //ex.SetCellValue("年", row + 2, col + 5);
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 2, col + 6);
            //ex.SetCellValue("月", row + 2, col + 7);
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 2, col + 8);
            //ex.SetCellValue("日", row + 2, col + 9);
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 2, col + 10);
            //ex.SetCellValue("时", row + 2, col + 11);
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 2, col + 12);
            //ex.SetCellValue("分", row + 2, col + 13);
            //结束时间
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 3, col + 4);
            //ex.SetCellValue("年", row + 3, col + 5);
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 3, col + 6);
            //ex.SetCellValue("月", row + 3, col + 7);
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 3, col + 8);
            //ex.SetCellValue("日", row + 3, col + 9);
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 3, col + 10);
            //ex.SetCellValue("时", row + 3, col + 11);
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 3, col + 12);
            //ex.SetCellValue("分", row + 3, col + 13);
            //出席人员
            string[] ary = obj.cjry.Split('@');
            int m = ary.Length / 8;
            int n = ary.Length % 8;
            if (n > 0) {
                m++;
            }
            if (m == 0) {
                m++;
            }
            ex.SetCellValue(fixcxry, row + 4, col);
            //ex.UnitCells(row + 4, col, row + 4 + m - 1, col);
            for (int i = 0; i < ary.Length; i++) {
                ex.SetCellValue(ary[i], row + 4 + i / 8, col + 1 + i % 8);
            }
            //缺席人员
            string[] ary2 = obj.qxry.Split('@');
            ex.SetCellValue(fixqxry, row + 4 + m, col);
            //ex.UnitCells(row + 4 + m, col, row + 4 + m, col + 1);
            for (int j = 0; j < ary2.Length; j++) {
                if (j <= 7) {
                    ex.SetCellValue(ary2[j], row + 4 + m, col + 2 + j % 7);
                } else//缺席人员大于七个时
                {
                    string tempstr = ex.ReadCellValue(row + 4 + m, row + 13);
                    tempstr = "/" + ary2[j];
                    ex.SetCellValue(tempstr, row + 4 + m, col + 13);
                }

            }
            //活动内容
            ex.SetCellValue(fixhd + obj.hdnr, row + 4 + m + 1, col);
            //活动小结
            ex.SetCellValue(fixxj + obj.hdxj, row + 4 + m + 2, col);
            //领导评语
            ex.SetCellValue(fixldpy + obj.py, row + 4 + m + 3, col);
            //签字
            ex.SetCellValue(obj.qz, row + 4 + m + 4, col + 1);
            ex.SetCellValue(obj.qzrq.Year.ToString(), row + 4 + m + 4, col + 8);
            ex.SetCellValue(obj.qzrq.Month.ToString(), row + 4 + m + 4, col + 10);
            ex.SetCellValue(obj.qzrq.Day.ToString(), row + 4 + m + 4, col + 12);
            //结尾

            ex.SetCellValue(fixjs, row + 4 + m + 5, col);
            
            //发言简要记录
            //空一行
            //ex.UnitCells(row + 4 + m + 6, col, row + 4 + m + 6, col + 13);
            ex.SetCellValue(fixfyjl, row + 4 + m + 7, col);


            ex.ShowExcel();
           
        }
        public static void ExportExcel2(PJ_02aqhd obj) 
        {
            ExcelAccess ex = new ExcelAccess();
            // SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // string fname = "";
            // saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            // if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            // {
            //     fname = saveFileDialog1.FileName;
            //     ex.MyFileName = fname;
            //     ex.CreateExcel();
            //     ex.MyFileName = fname;
            //     ex.CreateWorkSheet("活动记录");
            //     ex.Save();
            // }

            // ex.Open(fname);
                ex.CreateExcel();
                ex.CreateWorkSheet("活动记录");
                ex.ActiveSheet("活动记录");
            //ex.Open("");
            //ex.SetCellValue("", row, col);
            //与会人员之间的间隔符号
            string jksign = "@";
            int row=1;
            int col=1;
            string fixstr1="附录02";
            string fixname="安 全 活 动 记 录";
            string fixfyjl = "发 言 简 要 记 录";
            string fixzhuchi="主持人";
            string fixhd = "活动";
            string fixstart = "开始";
            string fixend = "结束";
            string fixtime = "时间";
            string fixcxry = "出席\r\n人员";
            string fixqxry = "缺席人员";
            string fixhdnr = "活动内容：";
            string fixxj = "活动小结： ";
            string fixldpy = "领导检查评语：";
            string fixqz = "签字：";
            string fixjs = "黑龙江省农村电气化局-配管-02";
           

            //写附录02
            ex.SetCellValue(fixstr1,row,col);
            ex.UnitCells(row , col, row , col + 13);
            ex.AlignmentCells(row , col, row , col, ExcelStyle.ExcelHAlign.靠左, ExcelStyle.ExcelVAlign.居中);
            ex.SetFontNameSize(row, col, row, col, "黑体", 10);

            //写安全活动记录
            ex.SetCellValue(fixname, row + 1, col);
            ex.UnitCells(row + 1, col, row + 1, col + 13);
            ex.AlignmentCells(row + 1, col, row + 1, col, ExcelStyle.ExcelHAlign.居中, ExcelStyle.ExcelVAlign.居中);
            ex.SetFontNameSize(row + 1, col, row + 1, col, "黑体", 13);
            //主持人
            ex.SetCellValue(fixzhuchi, row + 2, col);
            ex.UnitCells(row + 2, col, row + 3, col);
            //具体主持人
            ex.SetCellValue(obj.zcr, row + 2, col+1);
            ex.UnitCells(row + 2, col+1, row + 3, col+1);
            //活动开始结束时间
            ex.SetCellValue(fixhd, row + 2, col + 2);
            ex.SetCellValue(fixtime, row + 3, col + 2);
            ex.SetCellValue(fixstart, row + 2, col + 3);
            ex.SetCellValue(fixend, row + 3, col + 3);
            //开始时间
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 2, col + 4);
            ex.SetCellValue("年", row + 2, col + 5);
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 2, col + 6);
            ex.SetCellValue("月", row + 2, col + 7);
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 2, col + 8);
            ex.SetCellValue("日", row + 2, col + 9);
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 2, col + 10);
            ex.SetCellValue("时", row + 2, col + 11);
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 2, col + 12);
            ex.SetCellValue("分", row + 2, col + 13);
            //结束时间
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 3, col + 4);
            ex.SetCellValue("年", row + 3, col + 5);
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 3, col + 6);
            ex.SetCellValue("月", row + 3, col + 7);
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 3, col + 8);
            ex.SetCellValue("日", row + 3, col + 9);
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 3, col + 10);
            ex.SetCellValue("时", row + 3, col + 11);
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 3, col + 12);
            ex.SetCellValue("分", row + 3, col + 13);
            //出席人员
            string[] ary = obj.cjry.Split('@');
            int m = ary.Length / 8;
            int n = ary.Length % 8;
            if ( n>0)
            {
                m++;
            }
            if (m==0)
            {
                m++;
            }
            ex.SetCellValue(fixcxry, row + 4, col);
            ex.UnitCells(row + 4, col, row + 4 + m - 1, col);
            ex.AlignmentCells(row + 4, col, row + 4, col, ExcelStyle.ExcelHAlign.居中, ExcelStyle.ExcelVAlign.居中);
            for (int k = 0; k < m; k++)
            {
                for (int l = 4; l < 13; l++)
                {

                    ex.UnitCells(row + 4 + k, col + l, row + 4 + k, col + l + 1);
                    l++;
                }
            }
            for (int i = 0; i < ary.Length; i++)
            {
                int tempcol = col + 1 + i % 8;
                if (i % 8>3)
                {
                    tempcol = col + 4 + (i % 8-3) * 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 8, tempcol);
            }
            //缺席人员
            string[] ary2 = obj.qxry.Split('@');
            ex.SetCellValue(fixqxry, row + 4 + m, col);
            ex.UnitCells(row + 4 + m, col, row + 4 + m, col + 1);
            for (int o = 4; o < 13; o++)
            {

                ex.UnitCells(row + 4 + m, col + o, row + 4 + m, col + o + 1);
                o++;
            }
            for (int j = 0; j < ary2.Length; j++)
            {
                int tempcol = col + 2 + j % 7;
                if (j > 2 && j < 7)
                {
                    tempcol = col + 4 + (j % 7 - 2) * 2;
                }
                if (j<7)
                {
                    ex.SetCellValue(ary2[j], row + 4 + m, tempcol);
                }
                else//缺席人员大于七个时
                {
                    string tempstr = ex.ReadCellValue(row + 4 + m, col + 12);
                    tempstr = tempstr+"/" + ary2[j];
                    ex.SetCellValue(tempstr, row + 4 + m, col + 12);
                }
               
            }
            //活动内容
            ex.SetCellValue(fixhdnr + obj.hdnr, row + 4 + m + 1, col);
            ex.UnitCells(row + 4 + m + 1, col, row + 4 + m + 1, col + 13);
            ex.RowAutoFit(row + 4 + m + 1);
            //活动小结
            ex.SetCellValue(fixxj + obj.hdxj, row + 4 + m + 2, col);
            ex.UnitCells(row + 4 + m + 2, col, row + 4 + m + 2, col + 13);
            ex.RowAutoFit(row + 4 + m + 2);
            //领导评语
            ex.SetCellValue(fixldpy+obj.py, row + 4 + m + 3, col);
            ex.UnitCells(row + 4 + m + 3, col, row + 4 + m + 3, col + 13);
            ex.RowAutoFit(row + 4 + m + 3);
            //签字
            ex.SetCellValue(fixqz, row + 4 + m + 4, col);
            ex.SetCellValue(obj.qz, row + 4 + m + 4, col+1);
            ex.UnitCells(row + 4 + m + 4, col + 1, row + 4 + m + 4, col + 6);
            ex.UnitCells(row + 4 + m + 4, col + 7, row + 4 + m + 4, col + 8);
            ex.SetCellValue(obj.qzrq.Year.ToString(), row + 4 + m + 4, col + 7);
            ex.SetCellValue("年", row + 4 + m + 4, col + 9);
            ex.SetCellValue(obj.qzrq.Month.ToString(), row + 4 + m + 4, col + 10);
            ex.SetCellValue("月", row + 4 + m + 4, col + 11);
            ex.SetCellValue(obj.qzrq.Day.ToString(), row + 4 + m + 4, col + 12);
            ex.SetCellValue("日", row + 4 + m + 4, col + 13);
            //结尾

            ex.SetCellValue(fixjs, row + 4 + m + 5, col );
            ex.UnitCells(row + 4 + m + 5, col, row + 4 + m + 5, col + 13);
            ex.AlignmentCells(row + 4 + m + 5, col, row + 4 + m + 5, col, ExcelStyle.ExcelHAlign.靠右, ExcelStyle.ExcelVAlign.居中);
            ex.SetFontNameSize(row + 4 + m + 5, col, row + 4 + m + 5, col, "黑体", 10);

            //发言简要记录
            //空一行
            ex.UnitCells(row + 4 + m + 6, col, row + 4 + m + 6, col + 13);
            ex.SetCellValue(fixfyjl, row + 4 + m + 7, col);
            ex.UnitCells(row + 4 + m + 7, col, row + 4 + m + 7, col + 13);
            ex.AlignmentCells(row + 4 + m + 7, col, row + 4 + m + 7, col, ExcelStyle.ExcelHAlign.居中, ExcelStyle.ExcelVAlign.居中);
            ex.SetFontNameSize(row + 4 + m + 7, col, row + 4 + m + 7, col, "黑体", 13);
             
           
                    if (ex.Save())
                    {
                        if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.Yes)
                            return;
                        System.Diagnostics.Process.Start(ex.MyFileName);
                    }
                    else
                    {
                        MsgBox.ShowWarningMessageBox("导出失败！");
                    }
                    ex.DisPoseExcel();
            //string[] ary3 = obj.fyjyjl.Split('@');
        }
    }
}
