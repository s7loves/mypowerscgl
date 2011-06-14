﻿using System;
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
            int zc = 36;

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
                if (i % 5==1||i % 5==2||i % 5==3)
                {
                    tempcol = col + 1 + i % 5 + 1;
                }
                if (i % 5==4)
                {
                    tempcol = col + 1 + i % 5 + 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 5, tempcol);
            }
            //主持人
            ex.SetCellValue(obj.zcr,5,11);
            //主题：
            ex.SetCellValue("主题: " + obj.zt, 9, 1);
            //纪要
            string jystr = "纪要：" + obj.jy;
           
            for (int i = 0; i < 7; i++)
            {
                string tempstr = "";
                int startnum = i * zc;
                int endnum = (i + 1) * zc;
                bool ISempty=false;
                if (startnum>=jystr.Length)
                {
                   ISempty=true;
                }
                else if (endnum >= jystr.Length)
                {
                    endnum = jystr.Length;
                }
                if (!ISempty)
	            {
                     tempstr = jystr.Substring(startnum,endnum-startnum);
	            }
                ex.SetCellValue(tempstr, 11 + i, 1);
            }
            //结论及对策:
            string jlstr = "结论及对策：" + obj.jr;

            for (int j = 0; j < 6; j++)
            {
                string tempstr = "";
                int startnum = j * zc;
                int endnum = (j + 1) * zc;
                bool ISempty = false;
                if (startnum >= jlstr.Length)
                {
                    ISempty = true;
                }
                else if (endnum >= jlstr.Length)
                {
                    endnum = jlstr.Length;
                }
                if (!ISempty)
                {
                    tempstr = jlstr.Substring(startnum, endnum - startnum);
                }
                ex.SetCellValue(tempstr, 18 + j, 1);
            }
            //检查人签字
            ex.SetCellValue(obj.qz, 24, 4);
            //签字时间
            ex.SetCellValue(obj.qzrq.Year.ToString(), 24, 5);
            ex.SetCellValue(obj.qzrq.Month.ToString(), 24, 9);
            ex.SetCellValue(obj.qzrq.Day.ToString(), 24, 11);
            //ex.CopySheet(1,2);
            //ex.CopySheet(1, 3);
            //ex.CopySheet(2, 4);
            ex.ShowExcel();

        }
    }
}