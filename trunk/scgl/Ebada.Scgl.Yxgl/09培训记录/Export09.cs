using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Scgl.Core;
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
        public static void ExportExcel(PJ_09pxjl obj)
        {
            //lgm
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
            //计算页码
            int pagecount = 1;

            //题目
            string timustr = "题目：";
            List<string> timulist = Ecommon.ResultStrListByPage(timustr,obj.tm, zc,4);
            if (Ecommon.GetPagecount(timulist.Count,4)>pagecount)
	        {
                pagecount=Ecommon.GetPagecount(timulist.Count,4);
	        }
            //活动内容
            string hdstr = "内容："; 
            List<string> hdlist = Ecommon.ResultStrListByPage(hdstr, obj.nr,zc,10);
              if (Ecommon.GetPagecount(hdlist.Count,10)>pagecount)
	        {
                pagecount=Ecommon.GetPagecount(hdlist.Count,10);
	        }
            //领导评语
            string ldpystr = "领导检查评语：" ;
            List<string> ldpylist = Ecommon.ResultStrListByPage(ldpystr,obj.py, zc,3);
             if (Ecommon.GetPagecount(ldpylist.Count,3)>pagecount)
	        {
                pagecount=Ecommon.GetPagecount(ldpylist.Count,3);
	        }
            //复制空模板
            for (int m = 1; m < pagecount; m++)
			{
                 ex.CopySheet(1,m);
                 ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
			}

            for (int p = 0; p < pagecount; p++)
            {
                ex.ActiveSheet(p + 1);

                //题目

                for (int i = 0; i < 4; i++)
                {
                    if (p*4+i>=timulist.Count)
                    {
                        break;
                    }
                    string  tempstr = timulist[p * 4 + i];
                    ex.SetCellValue(tempstr, 7 + i, 1);
                }
                //活动内容
              
                for (int r = 0; r < 10; r++)
                {
                    if (p*10+r>=hdlist.Count)
                    {
                        break;
                    }
                    string tempstr = hdlist[p * 10 + r];
                    ex.SetCellValue(tempstr, 11 + r, 1);
                }

                //领导评语
           
                for (int t = 0; t < 3; t++)
                {
                    if (p * 3 + t >= ldpylist.Count)
                    {
                        break;
                    }
                    string tempstr = ldpylist[p * 3 + t];
                    ex.SetCellValue(tempstr, 21 + t, 1);
                }
          

            }

            ex.ActiveSheet(1);
            
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

        
            //签字
            ex.SetCellValue(obj.qz, 24, 3);
            if (ComboBoxHelper.CompreDate(obj.qzrq))
            {
                ex.SetCellValue(obj.qzrq.Year.ToString(), 24, 8);
                ex.SetCellValue(obj.qzrq.Month.ToString(), 24, 10);
                ex.SetCellValue(obj.qzrq.Day.ToString(), 24, 12);
            }

            ex.ActiveSheet(1);
            ex.ShowExcel();
           
        }
      
    }
}
