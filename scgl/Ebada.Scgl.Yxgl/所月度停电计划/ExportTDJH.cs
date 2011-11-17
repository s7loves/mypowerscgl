using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
using System.Windows.Forms;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportTDJH  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_02aqhd obj)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\02安全活动记录.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 60;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 1;
            int col = 1;

            //计算页码
            int pagecount = 1;
            //活动内容


            string hdstr =Ecommon.Comparestring(obj.hdnr,"活动内容")?"" :"活动内容：";
            List<string> hdlist = Ecommon.ResultStrListByPage(hdstr, obj.hdnr, zc, 8);
            if (Ecommon.GetPagecount(hdlist.Count, 8) > pagecount)
            {
                pagecount = Ecommon.GetPagecount(hdlist.Count, 8);
            }
            //活动小结
            string hdxjstr = Ecommon.Comparestring(obj.hdxj,"活动小结")?"":"活动小结：";
            List<string> hdxlist = Ecommon.ResultStrListByPage(hdxjstr, obj.hdxj, zc, 5);
            if (Ecommon.GetPagecount(hdxlist.Count, 5) > pagecount)
            {
                pagecount = Ecommon.GetPagecount(hdxlist.Count, 5);
            }
            //发言简要记录
            List<string> fyjyjllist = Ecommon.ResultStrListByPage("", obj.fyjyjl, zc, 21);
            if (Ecommon.GetPagecount(fyjyjllist.Count,21)>pagecount)
            {
                pagecount = Ecommon.GetPagecount(fyjyjllist.Count, 21);
            }
            //领导评语
            string ldpystr =Ecommon.Comparestring(obj.py,"领导检查评语")?"": "领导检查评语：";
            List<string> ldpylist = Ecommon.ResultStrListByPage(ldpystr, obj.py, zc, 2);
            if (Ecommon.GetPagecount(ldpylist.Count, 2) > pagecount)
            {
                pagecount = Ecommon.GetPagecount(ldpylist.Count, 2);
            }
            //复制空模版
            if (pagecount > 1)
            {
                for (int i = 1; i < pagecount; i++)
                {
                    ex.CopySheet(1, i);
                    ex.ReNameWorkSheet(i + 1, "Sheet" + (i + 1));
                }
            }

            for (int p = 0; p < pagecount; p++)
            {
                ex.ActiveSheet(p + 1);

                //活动内容
                for (int i = 0; i < 8; i++)
                {
                    if (p * 8 + i>=hdlist.Count)
                    {
                        break;
                    }
                    string tempstr = hdlist[p * 8 + i];
                    ex.SetCellValue(tempstr, 10 + i, 1);
                }
                //活动小结
                for (int s = 0; s < 5; s++)
                {
                    if (p * 5 + s >= hdxlist.Count)
                    {
                        break;
                    }
                    string tempstr = hdxlist[p * 5 + s];
                    ex.SetCellValue(tempstr, 18 + s, 1);
                }
                //领导评语
                for (int t = 0; t < 2; t++)
                {
                    if (p * 2 + t >= ldpylist.Count)
                    {
                        break;
                    }
                    string tempstr = ldpylist[p * 2 + t];
                   
                    ex.SetCellValue(tempstr, 23 + t, 1);
                }
                //简要记录
                for (int jy = 0; jy < 21;jy++ )
                {
                    if (p*21+jy>=fyjyjllist.Count)
                    {
                        break;
                    }
                    string tempstr = fyjyjllist[p * 21 + jy];
                    ex.SetCellValue(tempstr, 30 + jy,1);
                }
            }

            ex.ActiveSheet(1);

            //主持人
            ex.SetCellValue(obj.zcr, 4, 2);
            
            //开始时间
            row = 2;
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 2, col + 4);
           
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 2, col + 6);
           
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 2, col + 8);
           
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 2, col + 10);
          
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 2, col + 12);
           
            //结束时间
            ex.SetCellValue(obj.kssj.Year.ToString(), row + 3, col + 4);
          
            ex.SetCellValue(obj.kssj.Month.ToString(), row + 3, col + 6);
           
            ex.SetCellValue(obj.kssj.Day.ToString(), row + 3, col + 8);
         
            ex.SetCellValue(obj.kssj.Hour.ToString(), row + 3, col + 10);
            
            ex.SetCellValue(obj.kssj.Minute.ToString(), row + 3, col + 12);
           
            //出席人员
            string[] ary = obj.cjry.Split(jksign);
            int m = ary.Length / 8;
            int n = ary.Length % 8;
            if (n > 0) {
                m++;
            }
            if (m == 0) {
                m++;
            }
           
            for (int i = 0; i < ary.Length; i++)
            {
                int tempcol = col + 1 + i % 8;
                if (i % 8 > 3)
                {
                    tempcol = col + 4 + (i % 8 - 3) * 2;
                }
                ex.SetCellValue(ary[i], row + 4 + i / 8, tempcol);
            }
            //缺席人员
            string[] ary2 = obj.qxry.Split(jksign);
        
            for (int j = 0; j < ary2.Length; j++)
            {
                int tempcol = col + 2 + j % 7;
                if (j > 2 && j < 7)
                {
                    tempcol = col + 4 + (j % 7 - 2) * 2;
                }
                if (j < 7)
                {
                    ex.SetCellValue(ary2[j], row + 7, tempcol);
                }
                else//缺席人员大于七个时
                {
                    string tempstr = ex.ReadCellValue(row + 7, col + 12);
                    tempstr = tempstr + "/" + ary2[j];
                    ex.SetCellValue(tempstr, row + 7, col + 12);
                }

            }
           
          
            //签字
           // ex.SetCellValue("签字: ", 25, 1);
           // ex.SetCellValue(obj.qz, 25, col + 1);

          
            //签字时间小于系统默认时间则不输出
          //  if (ComboBoxHelper.CompreDate(obj.qzrq))
          //  {
           //     ex.SetCellValue(obj.qzrq.Year.ToString(), 25, 5);
           //     ex.SetCellValue(obj.qzrq.Month.ToString(), 25, 7);
           //     ex.SetCellValue(obj.qzrq.Day.ToString(), 25, 11);

        //    }
           
            ex.ShowExcel();
           
        }
      
    }
}
