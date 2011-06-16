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
    public class Export12  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PS_kg obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\12线路开关卡片";

            ex.Open(fname);
            //此处写填充内容代码
            int pagecount = 1;
            string strwhere1 = " where kgID='" + obj.kgID + "'";
            IList<PJ_12kgbd> pjbdlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_12kgbd>("SelectPJ_12kgbdList", strwhere1);
            IList<PJ_12kgjx> pjjxlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_12kgjx>("SelectPJ_12kgjxList", strwhere1);
            IList<PJ_12kgsy> pjsylist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_12kgsy>("SelectPJ_12kgsyList", strwhere1);
            if (Ecommon.GetPagecount(pjbdlist.Count, 14) > pagecount)
            {
                pagecount = Ecommon.GetPagecount(pjbdlist.Count, 14);
            }
            if (Ecommon.GetPagecount(pjjxlist.Count, 15) > pagecount)
            {
                pagecount = Ecommon.GetPagecount(pjjxlist.Count, 15);
            }
            if (Ecommon.GetPagecount(pjsylist.Count, 3) > pagecount)
            {
                pagecount = Ecommon.GetPagecount(pjsylist.Count, 3);
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
                //变动记录
                for (int i = 0; i < 14; i++)
                {
                    if (p*14+i>=pjbdlist.Count)
                    {
                        break;
                    }
                    PJ_12kgbd tempobj = pjbdlist[p * 14 + i];
                    ex.SetCellValue(tempobj.azrq.Year.ToString(), 12 + 2 * i, 1);
                    ex.SetCellValue(tempobj.azrq.Month.ToString(), 12 +2 * i, 3);
                    ex.SetCellValue(tempobj.azrq.Day.ToString(), 12 + 2 * i, 5);
                    ex.SetCellValue(tempobj.azdd, 12 + 2 * i, 7);
                    ex.SetCellValue(tempobj.gtbh, 12 + 2 * i, 9);
                    ex.SetCellValue(tempobj.kgCode, 12 + 2 * i,10);

                    ex.SetCellValue(tempobj.ccrq.Year.ToString(), 12 + 2 * i, 11);
                    ex.SetCellValue(tempobj.ccrq.Month.ToString(), 12 + 2 * i, 13);
                    ex.SetCellValue(tempobj.ccrq.Day.ToString(), 12 + 2 * i, 15);

                    ex.SetCellValue(tempobj.ccyy, 12 + 2 * i, 17);
                    ex.SetCellValue(tempobj.Remark, 12 + 2 * i, 19);
                }

                //实验记录
                for (int j = 0; j < 3; j++)
                {
                    if (p*3+j>pjsylist.Count)
                    {
                        break;
                    }
                    PJ_12kgsy tempobj = pjsylist[p * 3 + j];

                    ex.SetCellValue(tempobj.azrq.Year.ToString(), 4, 27 + j * 6);
                    ex.SetCellValue(tempobj.azrq.Month.ToString(), 4, 29 + j * 6);
                    ex.SetCellValue(tempobj.azrq.Day.ToString(), 4, 31 + j * 6);

                    ex.SetCellValue(tempobj.azdd, 5, 27 + j * 6);
                    ex.SetCellValue(tempobj.gtbh, 6, 27 + j * 6);

                    ex.SetCellValue(tempobj.A_BCO, 7, 27 + j * 6);
                    ex.SetCellValue(tempobj.B_CAO, 8, 27 + j * 6);
                    ex.SetCellValue(tempobj.C_ABO, 9, 27 + j * 6);

                    ex.SetCellValue(tempobj.A_BCO2, 10, 27 + j * 6);
                    ex.SetCellValue(tempobj.B_CAO2, 11, 27 + j * 6);
                    ex.SetCellValue(tempobj.C_ABO2, 12, 27 + j * 6);

                    ex.SetCellValue(tempobj.dy, 13, 27 + j * 6);
                    ex.SetCellValue(tempobj.dysj, 14, 27 + j * 6);

                    ex.SetCellValue(tempobj.dl, 15, 27 + j * 6);
                    ex.SetCellValue(tempobj.dlsj, 16, 27 + j * 6);

                    ex.SetCellValue(tempobj.dzA, 17, 27 + j * 6);
                    ex.SetCellValue(tempobj.dzB, 18, 27 + j * 6);
                    ex.SetCellValue(tempobj.dzC, 19, 27 + j * 6);

                    ex.SetCellValue(tempobj.tqjc, 20, 27 + j * 6);
                    ex.SetCellValue(tempobj.wgjc, 21, 27 + j * 6);

                    ex.SetCellValue(tempobj.syjl, 22, 27 + j * 6);
                    ex.SetCellValue(tempobj.syz, 23, 27 + j * 6);
                }
                //检修记录
                for (int k = 0; k <15 ; k++)
                {
                    if (p*15+k>=pjjxlist.Count)
	                {
                        break;
	                }
                    PJ_12kgjx tempobj = pjjxlist[p * 15 + k];
                    ex.SetCellValue(tempobj.jxsj.Year.ToString(), 25+k, 20);
                    ex.SetCellValue(tempobj.jxsj.Month.ToString(), 25+k, 22);
                    ex.SetCellValue(tempobj.jxsj.Day.ToString(), 25+k, 24);
                    ex.SetCellValue(tempobj.jxnr, 25+k, 26);
                    ex.SetCellValue(tempobj.fzr, 25+k, 39);
     
                }


            }


            ex.ActiveSheet(1);
            ex.SetCellValue(obj.kgModle, 4, 7);
            ex.SetCellValue(obj.kgCapcity+"A", 4, 9);
            ex.SetCellValue(obj.kgMadeDate.Year.ToString(), 4, 11);
            ex.SetCellValue(obj.kgMadeDate.Month.ToString(), 4, 13);
            ex.SetCellValue(obj.kgMadeDate.Day.ToString(), 4, 15);
            ex.SetCellValue(obj.kgLineGroup, 4, 19);

            ex.SetCellValue(obj.kgFactory, 6, 7);
            ex.SetCellValue(obj.kgVol, 6, 9);
            ex.SetCellValue(obj.kgPhase , 6, 11);
            ex.SetCellValue(obj.kgCloseVol, 6, 19);

            ex.SetCellValue(obj.kgNumber, 8, 7);
            ex.SetCellValue(obj.kgOpenEle, 8, 11);

            ex.ActiveSheet(1);
           ex.ShowExcel();
        }
      
    }
}
