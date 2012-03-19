using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Scgl.Core;
using Excel = Microsoft.Office.Interop.Excel;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export03
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_03yxfx obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\03运行分析记录.xls";

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

            //if (pagemax < Ecommon.GetPagecount(listztstring.Count,2))
            //{
            //    pagemax = Ecommon.GetPagecount(listztstring.Count, 2);
            //}
            string jy = Ecommon.Comparestring(obj.jy, "纪要") ? "" : "纪要：";
            List<string> listjy = Ecommon.ResultStrList(jy + obj.jy, zc);
            //if (pagemax < Ecommon.GetPagecount(listjy.Count, 7))
            //{
            //    pagemax = Ecommon.GetPagecount(listjy.Count, 7);
            //}
            string jr = Ecommon.Comparestring(obj.jr, "结论及对策") ? "" : "结论及对策：";
            List<string> listjldc = Ecommon.ResultStrList(jr + obj.jr, zc);
            //if (pagemax < Ecommon.GetPagecount(listjldc.Count, 6))
            //{
            //    pagemax = Ecommon.GetPagecount(listjldc.Count, 6);
            //}

            int[] strnumcol = { 0, listztstring.Count, listztstring.Count + listjy.Count };
            int[] statnum = { 3, 3, 6 };
            List<string> strcol = new List<string>();
            Ecommon.addstring(listztstring, ref strcol);
            Ecommon.addstring(listjy, ref strcol);
            Ecommon.addstring(listjldc, ref strcol);

            //Ecommon.CreatandWritesheet(ex, strcol, 15, 9, 1);

            Ecommon.CreatandWritesheet1(ex, strcol, 15, 9, 1, strnumcol, statnum);
            //进行加粗

            ex.ActiveSheet(1);
            //时间
            ex.SetCellValue(obj.rq.Year.ToString(), 4, 5);
            ex.SetCellValue(obj.rq.Month.ToString(), 4, 7);
            ex.SetCellValue(obj.rq.Day.ToString(), 4, 9);

            //出席人员
            string[] ary = obj.cjry.Split(';');
            int n = ary.Length % 5;
            for (int i = 0; i < ary.Length; i++)
            {
                int tempcol = col + 1 + i % 5;
                if (i % 5 == 1 || i % 5 == 2 || i % 5 == 3)
                {
                    tempcol = col + 1 + i % 5 + 1;
                }
                if (i % 5 == 4)
                {
                    tempcol = col + 1 + i % 5 + 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 5, tempcol);
            }
            //主持人
            ex.SetCellValue(obj.zcr, 5, 11);
            //检查人签字
            //ex.CopySheet(1, 2);
            //ex.ActiveSheet(2);
            //ex.SetCellValue("kakaka", 24, 4);
            //ex.ActiveSheet(1);
            //   ex.SetCellValue(obj.qz, 24, 4);
            //签字时间
            //  if (ComboBoxHelper.CompreDate(obj.qzrq))
            //   {
            //        ex.SetCellValue(obj.qzrq.Year.ToString(), 24, 5);
            //       ex.SetCellValue(obj.qzrq.Month.ToString(), 24, 9);
            //       ex.SetCellValue(obj.qzrq.Day.ToString(), 24, 11);
            //   }

            //将固定的写完再创建不固定的。



            //添加变动内容
            //for (int j = 1; j <= pagemax;j++ )
            //{
            //    if (j>1)
            //    {
            //        ex.CopySheet(1, 1);
            //    }
            //}
            //ex.ShowExcel();
            //for (int j = 1; j <= pagemax;j++ )
            //{


            //        ex.ActiveSheet(j);
            //    //if (j>1)
            //    //{
            //    //   // ex.CopySheet(1, j);
            //    //    ex.ActiveSheet(j);
            //    //}
            //    //ex.ShowExcel();

            //    int prepageindex = j - 1;
            //    //主题
            //    int starow = prepageindex * 2 + 1;
            //    int endrow = j * 2;
            //    if (listztstring.Count>endrow)
            //    {
            //        for (int i = 0; i < 2;i++ )
            //        {
            //            ex.SetCellValue(listztstring[starow - 1 + i], 9 + i, 1);
            //        }
            //    }
            //    else if (listztstring.Count<=endrow&&listztstring.Count>=starow)
            //    {
            //        for (int i = 0; i < listztstring.Count - starow + 1;i++ )
            //        {
            //            ex.SetCellValue(listztstring[starow - 1 + i], 9 + i, 1);
            //        }
            //    }
            //   //纪要
            //    starow = prepageindex * 7 + 1;
            //   endrow = j * 7;
            //    if (listjy.Count > endrow)
            //    {
            //        for (int i = 0; i < 7; i++)
            //        {
            //            ex.SetCellValue(listjy[starow - 1 + i], 11 + i, 1);
            //        }
            //    }
            //    else if (listjy.Count <= endrow && listjy.Count >= starow)
            //    {
            //        for (int i = 0; i < listjy.Count - starow + 1; i++)
            //        {
            //            ex.SetCellValue(listjy[starow - 1 + i], 11+ i, 1);
            //        }
            //    }
            //    //结论及对策
            //    starow = prepageindex * 6 + 1;
            //    endrow = j * 6;
            //    if (listjldc.Count > endrow)
            //    {
            //        for (int i = 0; i < 6; i++)
            //        {
            //            ex.SetCellValue(listjldc[starow - 1 + i], 18 + i, 1);
            //        }
            //    }
            //    else if (listjldc.Count <= endrow && listjldc.Count >= starow)
            //    {
            //        for (int i = 0; i < listjldc.Count - starow + 1; i++)
            //        {
            //            ex.SetCellValue(listjldc[starow - 1 + i], 18 + i, 1);
            //        }
            //    }

            //}
            ////主题：

            //ex.SetCellValue("主题: " + obj.zt, 9, 1);
            ////纪要
            //string jystr = "纪要：" + obj.jy;

            //for (int i = 0; i < 7; i++)
            //{
            //    string tempstr = "";
            //    int startnum = i * zc;
            //    int endnum = (i + 1) * zc;
            //    bool ISempty=false;
            //    if (startnum>=jystr.Length)
            //    {
            //       ISempty=true;
            //    }
            //    else if (endnum >= jystr.Length)
            //    {
            //        endnum = jystr.Length;
            //    }
            //    if (!ISempty)
            //    {
            //         tempstr = jystr.Substring(startnum,endnum-startnum);
            //    }
            //    ex.SetCellValue(tempstr, 11 + i, 1);
            //}
            ////结论及对策:
            //string jlstr = "结论及对策：" + obj.jr;

            //for (int j = 0; j < 6; j++)
            //{
            //    string tempstr = "";
            //    int startnum = j * zc;
            //    int endnum = (j + 1) * zc;
            //    bool ISempty = false;
            //    if (startnum >= jlstr.Length)
            //    {
            //        ISempty = true;
            //    }
            //    else if (endnum >= jlstr.Length)
            //    {
            //        endnum = jlstr.Length;
            //    }
            //    if (!ISempty)
            //    {
            //        tempstr = jlstr.Substring(startnum, endnum - startnum);
            //    }
            //    ex.SetCellValue(tempstr, 18 + j, 1);
            //}

            //ex.CopySheet(1,2);
            //ex.CopySheet(1, 3);
            //ex.CopySheet(2, 4);
            ex.ShowExcel();


        }
        public static void ExportExcelWorkFlow(ref LP_Record currRecord, PJ_03yxfx obj)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\03运行分析记录.xls";
            dsoFramerWordControl1.FileOpen(fname);
            if (currRecord == null)
            {
                currRecord = new LP_Record();
                currRecord.Status = "文档生成";
            }
            currRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileSave();
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.FileDataGzip = currRecord.DocContent;
            ExcelAccess ex = new ExcelAccess();
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ex.MyWorkBook = wb;
            ex.MyExcel = wb.Application;


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

            //if (pagemax < Ecommon.GetPagecount(listztstring.Count,2))
            //{
            //    pagemax = Ecommon.GetPagecount(listztstring.Count, 2);
            //}
            string jy = Ecommon.Comparestring(obj.jy, "纪要") ? "" : "纪要：";
            List<string> listjy = Ecommon.ResultStrList(jy + obj.jy, zc);
            //if (pagemax < Ecommon.GetPagecount(listjy.Count, 7))
            //{
            //    pagemax = Ecommon.GetPagecount(listjy.Count, 7);
            //}
            string jr = Ecommon.Comparestring(obj.jr, "结论及对策") ? "" : "结论及对策：";
            List<string> listjldc = Ecommon.ResultStrList(jr + obj.jr, zc);
            //if (pagemax < Ecommon.GetPagecount(listjldc.Count, 6))
            //{
            //    pagemax = Ecommon.GetPagecount(listjldc.Count, 6);
            //}
            int[] strnumcol = { 0, listztstring.Count, listztstring.Count + listjy.Count };
            int[] statnum = { 3, 3, 6 };
            List<string> strcol = new List<string>();
            Ecommon.addstring(listztstring, ref strcol);
            Ecommon.addstring(listjy, ref strcol);
            Ecommon.addstring(listjldc, ref strcol);

            //Ecommon.CreatandWritesheet(ex, strcol, 15, 9, 1);

            Ecommon.CreatandWritesheet1(ex, strcol, 15, 9, 1, strnumcol, statnum);
            //进行加粗
            ex.ActiveSheet(1);
            //时间
            ex.SetCellValue(obj.rq.Year.ToString(), 4, 5);
            ex.SetCellValue(obj.rq.Month.ToString(), 4, 7);
            ex.SetCellValue(obj.rq.Day.ToString(), 4, 9);

            //出席人员
            string[] ary = obj.cjry.Split(';');
            int n = ary.Length % 5;
            for (int i = 0; i < ary.Length; i++)
            {
                int tempcol = col + 1 + i % 5;
                if (i % 5 == 1 || i % 5 == 2 || i % 5 == 3)
                {
                    tempcol = col + 1 + i % 5 + 1;
                }
                if (i % 5 == 4)
                {
                    tempcol = col + 1 + i % 5 + 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 5, tempcol);
            }
            //主持人
            ex.SetCellValue(obj.zcr, 5, 11);
            //检查人签字
            //ex.CopySheet(1, 2);
            //ex.ActiveSheet(2);
            //ex.SetCellValue("kakaka", 24, 4);
            //ex.ActiveSheet(1);
            ex.SetCellValue(obj.qz, 24, 4);
            //签字时间
            if (ComboBoxHelper.CompreDate(obj.qzrq))
            {
                ex.SetCellValue(obj.qzrq.Year.ToString(), 24, 5);
                ex.SetCellValue(obj.qzrq.Month.ToString(), 24, 9);
                ex.SetCellValue(obj.qzrq.Day.ToString(), 24, 11);
            }
            if (currRecord == null)
            {
                currRecord = new LP_Record();
                currRecord.Status = "文档生成";
            }
            dsoFramerWordControl1.FileSave();
            currRecord.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileSave();
            dsoFramerWordControl1.FileClose();

        }
    }
}