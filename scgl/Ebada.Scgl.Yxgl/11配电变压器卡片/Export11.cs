using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.Collections;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export11  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
      
        public static void ExportExcel(PS_tqbyq obj)
        {
            //lgm
            //页数
            int pagecount =1;
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\11配电变压器卡片.xls";
            ex.Open(fname);
            //此处写填充内容代码
            int row = 1;
            string strwhere1=" where byqID='"+obj.byqID+"'";
            IList<PJ_11byqbd> pjbdlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_11byqbd>("SelectPJ_11byqbdList", strwhere1);
            IList<PJ_11byqdydl> pjdydllist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_11byqdydl>("SelectPJ_11byqdydlList", strwhere1);
            IList<PJ_11byqdzcl> pjdzcllist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_11byqdzcl>("SelectPJ_11byqdzclList", strwhere1);
           //计算页数
            int byqhdpage = Ecommon.GetPagecount(pjbdlist.Count, 3);
            if (byqhdpage > pagecount)
            {
                pagecount = byqhdpage;
            }
            int byqdypage = Ecommon.GetPagecount(pjdydllist.Count, 22);
            if (byqdypage > pagecount)
            {
                pagecount = byqdypage;
            }
            int byqdzpage  = Ecommon.GetPagecount(pjdzcllist.Count, 9);
            if (byqdzpage > pagecount)
            {
                pagecount = byqdzpage;
            }
            //复制空模版
            if (pagecount>1)
            {
                for (int i = 1; i < pagecount; i++)
                {
                    ex.CopySheet(1, i);
                    ex.ReNameWorkSheet(i + 1, "Sheet" + (i + 1));
                }
            }

            PS_tq temptq = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_tq>(obj.tqID);
            //固定内容
            ex.ActiveSheet(1);
            //变压器内容
            row = 4;
            ex.SetCellValue(obj.byqModle, row, 4);
            ex.SetCellValue(obj.byqFactory, row, 14);
            ex.SetCellValue(obj.byqVolOne + "KV", row, 23);
            row++;
            ex.SetCellValue(obj.byqPhase, row, 4);
            ex.SetCellValue(obj.byqNumber, row, 14);
            ex.SetCellValue(obj.byqVolTwo + "KV", row, 23);
            row++;//6
            ex.SetCellValue(obj.byqCapcity.ToString(), row, 4);
            ex.SetCellValue(obj.byqMadeDate.Year.ToString(), row, 14);
            ex.SetCellValue(obj.byqMadeDate.Month.ToString(), row, 16);
            ex.SetCellValue(obj.byqMadeDate.Day.ToString(), row, 18);
            ex.SetCellValue(obj.byqCurrentOne.ToString(), row, 23);

            row += 2;//8
            ex.SetCellValue(obj.byqLineGroup, row, 4);
            ex.SetCellValue(obj.byqCycle, row, 14);
            ex.SetCellValue(obj.byqCurrentTwo.ToString(), row, 23);

            //活动页

            //标题 
            ex.SetCellValue("配电变压器卡片(" + temptq.tqName + ")", 2, 1);

            
            for (int k = 0; k < pagecount; k++)
            {
               
                ex.ActiveSheet(k + 1);
                //标题 
                ex.SetCellValue("配电变压器卡片(" + temptq.tqName + ")", 2, 1);


                //变压器变动内容
                row = 12;
                for (int i = 0; i < 3; i++)
                {
                    if (k * 3 + i >= pjbdlist.Count)
                    {
                        break;
                    }
                    PJ_11byqbd tempobj = pjbdlist[k * 3 + i];
                    ex.SetCellValue(tempobj.azrq.Year.ToString(), row + i, 1);
                    ex.SetCellValue(tempobj.azrq.Month.ToString(), row + i, 3);
                    ex.SetCellValue(tempobj.azrq.Day.ToString(), row + i, 5);

                    ex.SetCellValue(tempobj.azdd, row + i, 7);

                    ex.SetCellValue(tempobj.ccrq.Year.ToString(), row + i, 14);
                    ex.SetCellValue(tempobj.ccrq.Month.ToString(), row + i, 16);
                    ex.SetCellValue(tempobj.ccrq.Day.ToString(), row + i, 18);

                    ex.SetCellValue(tempobj.ccyy, row + i, 20);
                }

                //电压电流内容
                row = 6;
                for (int j = 0; j < 22; j++)
                {
                    if (k * 22 + j >= pjdydllist.Count)
                    {
                        break;
                    }
                    PJ_11byqdydl tempobj = pjdydllist[k * 22 + j];
                    ex.SetCellValue(tempobj.clrq.Year.ToString(), row + j, 26);
                    ex.SetCellValue(tempobj.clrq.Month.ToString(), row + j, 28);
                    ex.SetCellValue(tempobj.clrq.Day.ToString(), row + j, 30);

                    ex.SetCellValue(tempobj.fjtwz, row + j, 32);
                    ex.SetCellValue(tempobj.ao.ToString(), row + j, 33);
                    ex.SetCellValue(tempobj.bo.ToString(), row + j, 34);
                    ex.SetCellValue(tempobj.co.ToString(), row + j, 35);

                    ex.SetCellValue(tempobj.a.ToString(), row + j, 36);
                    ex.SetCellValue(tempobj.b.ToString(), row + j, 37);
                    ex.SetCellValue(tempobj.c.ToString(), row + j, 38);

                    ex.SetCellValue(tempobj.ao2.ToString(), row + j, 39);
                    ex.SetCellValue(tempobj.bo2.ToString(), row + j, 40);
                    ex.SetCellValue(tempobj.co2.ToString(), row + j, 41);   
                  
                }
                //绝缘电阻测量内容
                row = 16;
                for (int l = 0; l < 9; l++)
                {
                    if (k*9+l>=pjdzcllist.Count)
                    {
                        break;
                    }
                    if (l % 3 == 0 && l > 0)
                    {
                        row = 16 - l;
                    }
                    PJ_11byqdzcl tempobj = pjdzcllist[k * 9 + l];
                    if (l < 3)
                    {
                        ex.SetCellValue(tempobj.clrq.Year.ToString(), row + l, 7);
                        ex.SetCellValue(tempobj.clrq.Month.ToString(), row + l, 10);
                        ex.SetCellValue(tempobj.clrq.Day.ToString(), row + l, 12);
                        ex.SetCellValue(tempobj.one2one.ToString(), row + l + 1, 7);
                        ex.SetCellValue(tempobj.one2d.ToString(), row + l + 2, 7);
                        ex.SetCellValue(tempobj.two2d.ToString(), row + l + 3, 7);
                        row++;
                    }
                    else if (3 <= l && l < 6)
                    {
                        ex.SetCellValue(tempobj.clrq.Year.ToString(), row + l, 14);
                        ex.SetCellValue(tempobj.clrq.Month.ToString(), row + l, 16);
                        ex.SetCellValue(tempobj.clrq.Day.ToString(), row + l, 18);
                        ex.SetCellValue(tempobj.one2one.ToString(), row + l + 1, 14);
                        ex.SetCellValue(tempobj.one2d.ToString(), row + l + 2, 14);
                        ex.SetCellValue(tempobj.two2d.ToString(), row + l + 3, 14);
                        row++;
                    }
                    else if (6 <= l && l < 9)
                    {
                        ex.SetCellValue(tempobj.clrq.Year.ToString(), row + l, 20);
                        ex.SetCellValue(tempobj.clrq.Month.ToString(), row + l, 22);
                        ex.SetCellValue(tempobj.clrq.Day.ToString(), row + l, 24);
                        ex.SetCellValue(tempobj.one2one.ToString(), row + l + 1, 20);
                        ex.SetCellValue(tempobj.one2d.ToString(), row + l + 2, 20);
                        ex.SetCellValue(tempobj.two2d.ToString(), row + l + 3, 20);
                        row++;

                    }

                }

            }
            //设第一工作表为当前工作表
            ex.ActiveSheet(1);
           ex.ShowExcel();
        }

        
    }
}
