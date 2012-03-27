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
    public class Export10  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(string obj)
        {
            obj = "317";
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\10配电变压器汇总表.xls";
            IList<PS_sheetTemp> list1 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=10 ");
            IList<PS_sheetTemp> list2 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=20 ");
            IList<PS_sheetTemp> list3 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=30 ");
            IList<PS_sheetTemp> list4 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=50 ");
            IList<PS_sheetTemp> list5 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=63 ");
            IList<PS_sheetTemp> list6 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=80 ");
            IList<PS_sheetTemp> list7 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=100 ");
            IList<PS_sheetTemp> list8 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=125 ");
            IList<PS_sheetTemp> list9 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=160 ");
            IList<PS_sheetTemp> list10 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=200 ");
            IList<PS_sheetTemp> list11 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=250 ");
            IList<PS_sheetTemp> list12 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=300 ");
            IList<PS_sheetTemp> list13 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=315 ");
            IList<PS_sheetTemp> list14 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=400 ");
            IList<PS_sheetTemp> list15 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sheetTemp>("SelectPS_tqbyqByGDSView", "'" + obj + "' and d.byqCapcity=630 ");
            ex.Open(fname);
            //此处写填充内容代码
            ex.SetCellValue(list1[0].Col1.ToString(), 7, 5);
            ex.SetCellValue(list1[0].Col2.ToString(), 8, 5);
            ex.SetCellValue(list1[0].Col3.ToString(), 9, 5);
            ex.SetCellValue(list1[0].Col4.ToString(), 10, 5);
            ex.SetCellValue(list1[0].Col5.ToString(), 11, 5);
            ex.SetCellValue(list1[0].Col6.ToString(), 12, 5);
            ex.SetCellValue(list1[0].Col7.ToString(), 13, 5);
            ex.SetCellValue(list1[0].Col8.ToString(), 14, 5);
            ex.SetCellValue(Convert.ToString(list1[0].Col1 + list1[0].Col3 + list1[0].Col5 + list1[0].Col7), 5, 5);
            ex.SetCellValue(Convert.ToString(list1[0].Col2 + list1[0].Col4 + list1[0].Col6 + list1[0].Col8), 6, 5);
            ex.SetCellValue(Convert.ToString(list1[0].Col1 + list2[0].Col1 + list3[0].Col1 + list4[0].Col1 + list5[0].Col1 + list6[0].Col1 + list7[0].Col1 + list8[0].Col1 + list9[0].Col1 + list10[0].Col1 + list11[0].Col1 + list12[0].Col1 + list13[0].Col1 + list14[0].Col1 + list15[0].Col1), 7, 4);

            ex.SetCellValue(list2[0].Col1.ToString(), 7, 6);
            ex.SetCellValue(list2[0].Col2.ToString(), 8, 6);
            ex.SetCellValue(list2[0].Col3.ToString(), 9, 6);
            ex.SetCellValue(list2[0].Col4.ToString(), 10, 6);
            ex.SetCellValue(list2[0].Col5.ToString(), 11, 6);
            ex.SetCellValue(list2[0].Col6.ToString(), 12, 6);
            ex.SetCellValue(list2[0].Col7.ToString(), 13, 6);
            ex.SetCellValue(list2[0].Col8.ToString(), 14, 6);
            ex.SetCellValue(Convert.ToString(list2[0].Col1 + list2[0].Col3 + list2[0].Col5 + list2[0].Col7), 5, 6);
            ex.SetCellValue(Convert.ToString(list2[0].Col2 + list2[0].Col4 + list2[0].Col6 + list2[0].Col8), 6, 6);
            ex.SetCellValue(Convert.ToString(list1[0].Col2 + list2[0].Col2 + list3[0].Col2 + list4[0].Col2 + list5[0].Col2 + list6[0].Col2 + list7[0].Col2 + list8[0].Col2 + list9[0].Col2 + list10[0].Col2 + list11[0].Col2 + list12[0].Col2 + list13[0].Col2 + list14[0].Col2 + list15[0].Col2), 8, 4);

            ex.SetCellValue(list3[0].Col1.ToString(), 7, 7);
            ex.SetCellValue(list3[0].Col2.ToString(), 8, 7);
            ex.SetCellValue(list3[0].Col3.ToString(), 9, 7);
            ex.SetCellValue(list3[0].Col4.ToString(), 10, 7);
            ex.SetCellValue(list3[0].Col5.ToString(), 11, 7);
            ex.SetCellValue(list3[0].Col6.ToString(), 12, 7);
            ex.SetCellValue(list3[0].Col7.ToString(), 13, 7);
            ex.SetCellValue(list3[0].Col8.ToString(), 14, 7);
            ex.SetCellValue(Convert.ToString(list3[0].Col1 + list3[0].Col3 + list3[0].Col5 + list3[0].Col7), 5, 7);
            ex.SetCellValue(Convert.ToString(list3[0].Col2 + list3[0].Col4 + list3[0].Col6 + list3[0].Col8), 6, 7);
            ex.SetCellValue(Convert.ToString(list1[0].Col3 + list2[0].Col3 + list3[0].Col3 + list4[0].Col3 + list5[0].Col3 + list6[0].Col3 + list7[0].Col3 + list8[0].Col3 + list9[0].Col3 + list10[0].Col3 + list11[0].Col3 + list12[0].Col3 + list13[0].Col3 + list14[0].Col3 + list15[0].Col3), 9, 4);

            ex.SetCellValue(list4[0].Col1.ToString(), 7, 8);
            ex.SetCellValue(list4[0].Col2.ToString(), 8, 8);
            ex.SetCellValue(list4[0].Col3.ToString(), 9, 8);
            ex.SetCellValue(list4[0].Col4.ToString(), 10, 8);
            ex.SetCellValue(list4[0].Col5.ToString(), 11, 8);
            ex.SetCellValue(list4[0].Col6.ToString(), 12, 8);
            ex.SetCellValue(list4[0].Col7.ToString(), 13, 8);
            ex.SetCellValue(list4[0].Col8.ToString(), 14, 8);
            ex.SetCellValue(Convert.ToString(list4[0].Col1 + list4[0].Col3 + list4[0].Col5 + list4[0].Col7), 5, 8);
            ex.SetCellValue(Convert.ToString(list4[0].Col2 + list4[0].Col4 + list4[0].Col6 + list4[0].Col8), 6, 8);
            ex.SetCellValue(Convert.ToString(list1[0].Col4 + list2[0].Col4 + list3[0].Col4 + list4[0].Col4 + list5[0].Col4 + list6[0].Col4 + list7[0].Col4 + list8[0].Col4 + list9[0].Col4 + list10[0].Col4 + list11[0].Col4 + list12[0].Col4 + list13[0].Col4 + list14[0].Col4 + list15[0].Col4), 10, 4);

            ex.SetCellValue(list5[0].Col1.ToString(), 7, 9);
            ex.SetCellValue(list5[0].Col2.ToString(), 8, 9);
            ex.SetCellValue(list5[0].Col3.ToString(), 9, 9);
            ex.SetCellValue(list5[0].Col4.ToString(), 10, 9);
            ex.SetCellValue(list5[0].Col5.ToString(), 11, 9);
            ex.SetCellValue(list5[0].Col6.ToString(), 12, 9);
            ex.SetCellValue(list5[0].Col7.ToString(), 13, 9);
            ex.SetCellValue(list5[0].Col8.ToString(), 14, 9);
            ex.SetCellValue(Convert.ToString(list5[0].Col1 + list5[0].Col3 + list5[0].Col5 + list5[0].Col7), 5, 9);
            ex.SetCellValue(Convert.ToString(list5[0].Col2 + list5[0].Col4 + list5[0].Col6 + list5[0].Col8), 6, 9);
            ex.SetCellValue(Convert.ToString(list1[0].Col5 + list2[0].Col5 + list3[0].Col5 + list4[0].Col5 + list5[0].Col4 + list6[0].Col5 + list7[0].Col5 + list8[0].Col5 + list9[0].Col5 + list10[0].Col5 + list11[0].Col5 + list12[0].Col5 + list13[0].Col5 + list14[0].Col5 + list15[0].Col5), 11, 4);

            ex.SetCellValue(list6[0].Col1.ToString(), 7, 10);
            ex.SetCellValue(list6[0].Col2.ToString(), 8, 10);
            ex.SetCellValue(list6[0].Col3.ToString(), 9, 10);
            ex.SetCellValue(list6[0].Col4.ToString(), 10, 10);
            ex.SetCellValue(list6[0].Col5.ToString(), 11, 10);
            ex.SetCellValue(list6[0].Col6.ToString(), 12, 10);
            ex.SetCellValue(list6[0].Col7.ToString(), 13, 10);
            ex.SetCellValue(list6[0].Col8.ToString(), 14, 10);
            ex.SetCellValue(Convert.ToString(list6[0].Col1 + list6[0].Col3 + list6[0].Col5 + list6[0].Col7), 5, 10);
            ex.SetCellValue(Convert.ToString(list6[0].Col2 + list6[0].Col4 + list6[0].Col6 + list6[0].Col8), 6, 10);
            ex.SetCellValue(Convert.ToString(list1[0].Col6 + list2[0].Col6 + list3[0].Col6 + list4[0].Col6 + list5[0].Col6 + list6[0].Col6 + list7[0].Col6 + list8[0].Col6 + list9[0].Col6 + list10[0].Col6 + list11[0].Col6 + list12[0].Col6 + list13[0].Col6 + list14[0].Col6 + list15[0].Col6), 12, 4);
            ex.SetCellValue(list7[0].Col1.ToString(), 7, 11);
            ex.SetCellValue(list7[0].Col2.ToString(), 8, 11);
            ex.SetCellValue(list7[0].Col3.ToString(), 9, 11);
            ex.SetCellValue(list7[0].Col4.ToString(), 10, 11);
            ex.SetCellValue(list7[0].Col5.ToString(), 11, 11);
            ex.SetCellValue(list7[0].Col6.ToString(), 12, 11);
            ex.SetCellValue(list7[0].Col7.ToString(), 13, 11);
            ex.SetCellValue(list7[0].Col8.ToString(), 14, 11);
            ex.SetCellValue(Convert.ToString(list7[0].Col1 + list7[0].Col3 + list7[0].Col5 + list7[0].Col7), 5, 11);
            ex.SetCellValue(Convert.ToString(list7[0].Col2 + list7[0].Col4 + list7[0].Col6 + list7[0].Col8), 6, 11);
            ex.SetCellValue(Convert.ToString(list1[0].Col7 + list2[0].Col7 + list3[0].Col7 + list4[0].Col7 + list5[0].Col7 + list6[0].Col7 + list7[0].Col7 + list8[0].Col7 + list9[0].Col7 + list10[0].Col7 + list11[0].Col7 + list12[0].Col7 + list13[0].Col7 + list14[0].Col7 + list15[0].Col7), 13, 4);
            ex.SetCellValue(list8[0].Col1.ToString(), 7, 12);
            ex.SetCellValue(list8[0].Col2.ToString(), 8, 12);
            ex.SetCellValue(list8[0].Col3.ToString(), 9, 12);
            ex.SetCellValue(list8[0].Col4.ToString(), 10, 12);
            ex.SetCellValue(list8[0].Col5.ToString(), 11, 12);
            ex.SetCellValue(list8[0].Col6.ToString(), 12, 12);
            ex.SetCellValue(list8[0].Col7.ToString(), 13, 12);
            ex.SetCellValue(list8[0].Col8.ToString(), 14, 12);
            ex.SetCellValue(Convert.ToString(list8[0].Col1 + list8[0].Col3 + list8[0].Col5 + list8[0].Col7), 5, 12);
            ex.SetCellValue(Convert.ToString(list8[0].Col2 + list8[0].Col4 + list8[0].Col6 + list8[0].Col8), 6, 12);
            ex.SetCellValue(Convert.ToString(list1[0].Col8 + list2[0].Col8 + list3[0].Col8 + list4[0].Col8 + list5[0].Col8 + list6[0].Col8 + list7[0].Col8 + list8[0].Col8 + list9[0].Col8 + list10[0].Col8 + list11[0].Col8 + list12[0].Col8 + list13[0].Col8 + list14[0].Col8 + list15[0].Col8), 14, 4);
            ex.SetCellValue(list9[0].Col1.ToString(), 7, 13);
            ex.SetCellValue(list9[0].Col2.ToString(), 8, 13);
            ex.SetCellValue(list9[0].Col3.ToString(), 9, 13);
            ex.SetCellValue(list9[0].Col4.ToString(), 10, 13);
            ex.SetCellValue(list9[0].Col5.ToString(), 11, 13);
            ex.SetCellValue(list9[0].Col6.ToString(), 12, 13);
            ex.SetCellValue(list9[0].Col7.ToString(), 13, 13);
            ex.SetCellValue(list9[0].Col8.ToString(), 14, 13);
            ex.SetCellValue(Convert.ToString(list9[0].Col1 + list9[0].Col3 + list9[0].Col5 + list9[0].Col7), 5, 13);
            ex.SetCellValue(Convert.ToString(list9[0].Col2 + list9[0].Col4 + list9[0].Col6 + list9[0].Col8), 6, 13);

            ex.SetCellValue(list10[0].Col1.ToString(), 7, 14);
            ex.SetCellValue(list10[0].Col2.ToString(), 8, 14);
            ex.SetCellValue(list10[0].Col3.ToString(), 9, 14);
            ex.SetCellValue(list10[0].Col4.ToString(), 10, 14);
            ex.SetCellValue(list10[0].Col5.ToString(), 11, 14);
            ex.SetCellValue(list10[0].Col6.ToString(), 12, 14);
            ex.SetCellValue(list10[0].Col7.ToString(), 13, 14);
            ex.SetCellValue(list10[0].Col8.ToString(), 14, 14);
            ex.SetCellValue(Convert.ToString(list10[0].Col1 + list10[0].Col3 + list10[0].Col5 + list10[0].Col7), 5, 14);
            ex.SetCellValue(Convert.ToString(list10[0].Col2 + list10[0].Col4 + list10[0].Col6 + list10[0].Col8), 6, 14);

            ex.SetCellValue(list11[0].Col1.ToString(), 7, 15);
            ex.SetCellValue(list11[0].Col2.ToString(), 8, 15);
            ex.SetCellValue(list11[0].Col3.ToString(), 9, 15);
            ex.SetCellValue(list11[0].Col4.ToString(), 10, 15);
            ex.SetCellValue(list11[0].Col5.ToString(), 11, 15);
            ex.SetCellValue(list11[0].Col6.ToString(), 12, 15);
            ex.SetCellValue(list11[0].Col7.ToString(), 13, 15);
            ex.SetCellValue(list11[0].Col8.ToString(), 14, 15);
            ex.SetCellValue(Convert.ToString(list11[0].Col1 + list11[0].Col3 + list11[0].Col5 + list11[0].Col7), 5, 15);
            ex.SetCellValue(Convert.ToString(list11[0].Col2 + list11[0].Col4 + list11[0].Col6 + list11[0].Col8), 6, 15);

            ex.SetCellValue(list12[0].Col1.ToString(), 7, 16);
            ex.SetCellValue(list12[0].Col2.ToString(), 8, 16);
            ex.SetCellValue(list12[0].Col3.ToString(), 9, 16);
            ex.SetCellValue(list12[0].Col4.ToString(), 10, 16);
            ex.SetCellValue(list12[0].Col5.ToString(), 11, 16);
            ex.SetCellValue(list12[0].Col6.ToString(), 12, 16);
            ex.SetCellValue(list12[0].Col7.ToString(), 13, 16);
            ex.SetCellValue(list12[0].Col8.ToString(), 14, 16);
            ex.SetCellValue(Convert.ToString(list12[0].Col1 + list12[0].Col3 + list12[0].Col5 + list12[0].Col7), 5, 16);
            ex.SetCellValue(Convert.ToString(list12[0].Col2 + list12[0].Col4 + list12[0].Col6 + list12[0].Col8), 6, 16);

            ex.SetCellValue(list13[0].Col1.ToString(), 7, 17);
            ex.SetCellValue(list13[0].Col2.ToString(), 8, 17);
            ex.SetCellValue(list13[0].Col3.ToString(), 9, 17);
            ex.SetCellValue(list13[0].Col4.ToString(), 10, 17);
            ex.SetCellValue(list13[0].Col5.ToString(), 11, 17);
            ex.SetCellValue(list13[0].Col6.ToString(), 12, 17);
            ex.SetCellValue(list13[0].Col7.ToString(), 13, 17);
            ex.SetCellValue(list13[0].Col8.ToString(), 14, 17);
            ex.SetCellValue(Convert.ToString(list13[0].Col1 + list13[0].Col3 + list13[0].Col5 + list13[0].Col7), 5, 17);
            ex.SetCellValue(Convert.ToString(list13[0].Col2 + list13[0].Col4 + list13[0].Col6 + list13[0].Col8), 6, 17);

            ex.SetCellValue(list14[0].Col1.ToString(), 7, 18);
            ex.SetCellValue(list14[0].Col2.ToString(), 8, 18);
            ex.SetCellValue(list14[0].Col3.ToString(), 9, 18);
            ex.SetCellValue(list14[0].Col4.ToString(), 10, 18);
            ex.SetCellValue(list14[0].Col5.ToString(), 11, 18);
            ex.SetCellValue(list14[0].Col6.ToString(), 12, 18);
            ex.SetCellValue(list14[0].Col7.ToString(), 13, 18);
            ex.SetCellValue(list14[0].Col8.ToString(), 14, 18);
            ex.SetCellValue(Convert.ToString(list14[0].Col1 + list14[0].Col3 + list14[0].Col5 + list14[0].Col7), 5, 18);
            ex.SetCellValue(Convert.ToString(list14[0].Col2 + list14[0].Col4 + list14[0].Col6 + list14[0].Col8), 6, 18);

            ex.SetCellValue(list15[0].Col1.ToString(), 7, 19);
            ex.SetCellValue(list15[0].Col2.ToString(), 8, 19);
            ex.SetCellValue(list15[0].Col3.ToString(), 9, 19);
            ex.SetCellValue(list15[0].Col4.ToString(), 10, 19);
            ex.SetCellValue(list15[0].Col5.ToString(), 11, 19);
            ex.SetCellValue(list15[0].Col6.ToString(), 12, 19);
            ex.SetCellValue(list15[0].Col7.ToString(), 13, 19);
            ex.SetCellValue(list15[0].Col8.ToString(), 14, 19);
            ex.SetCellValue(Convert.ToString(list15[0].Col1 + list15[0].Col3 + list15[0].Col5 + list15[0].Col7), 5, 19);
            ex.SetCellValue(Convert.ToString(list15[0].Col2 + list15[0].Col4 + list15[0].Col6 + list15[0].Col8), 6, 19);

            ex.SetCellValue(Convert.ToString(list1[0].Col1 + list1[0].Col3 + list1[0].Col5 + list1[0].Col7 + list2[0].Col1 + list2[0].Col3 + list2[0].Col5 + list2[0].Col7 + list3[0].Col1 + list3[0].Col3 + list3[0].Col5 + list3[0].Col7 + list4[0].Col1 + list4[0].Col3 + list4[0].Col5 + list4[0].Col7 + list5[0].Col1 + list5[0].Col3 + list5[0].Col5 + list5[0].Col7 + list6[0].Col1 + list6[0].Col3 + list6[0].Col5 + list6[0].Col7 + list7[0].Col1 + list7[0].Col3 + list7[0].Col5 + list7[0].Col7 + list8[0].Col1 + list8[0].Col3 + list8[0].Col5 + list8[0].Col7 + list9[0].Col1 + list9[0].Col3 + list9[0].Col5 + list9[0].Col7 + list10[0].Col1 + list10[0].Col3 + list10[0].Col5 + list10[0].Col7 + list11[0].Col1 + list11[0].Col3 + list11[0].Col5 + list11[0].Col7 + list12[0].Col1 + list12[0].Col3 + list12[0].Col5 + list12[0].Col7 + list13[0].Col1 + list13[0].Col3 + list13[0].Col5 + list13[0].Col7 + list14[0].Col1 + list14[0].Col3 + list14[0].Col5 + list14[0].Col7 + list15[0].Col1 + list15[0].Col3 + list15[0].Col5 + list15[0].Col7), 5, 4);
            ex.SetCellValue(Convert.ToString(list1[0].Col2 + list1[0].Col4 + list1[0].Col6 + list1[0].Col8 + list2[0].Col2 + list2[0].Col4 + list2[0].Col6 + list2[0].Col8 + list3[0].Col2 + list3[0].Col4 + list3[0].Col6 + list3[0].Col8 + list4[0].Col2 + list4[0].Col4 + list4[0].Col6 + list4[0].Col8 + list5[0].Col2 + list5[0].Col4 + list5[0].Col6 + list5[0].Col8 + list6[0].Col2 + list6[0].Col4 + list6[0].Col6 + list6[0].Col8 + list7[0].Col2 + list7[0].Col4 + list7[0].Col6 + list7[0].Col8 + list8[0].Col2 + list8[0].Col4 + list8[0].Col6 + list8[0].Col8 + list9[0].Col2 + list9[0].Col4 + list9[0].Col6 + list9[0].Col8 + list10[0].Col2 + list10[0].Col4 + list10[0].Col6 + list10[0].Col8 + list11[0].Col2 + list11[0].Col4 + list11[0].Col6 + list11[0].Col8 + list12[0].Col2 + list12[0].Col4 + list12[0].Col6 + list12[0].Col8 + list13[0].Col2 + list13[0].Col4 + list13[0].Col6 + list13[0].Col8 + list14[0].Col2 + list14[0].Col4 + list14[0].Col6 + list14[0].Col8 + list15[0].Col2 + list15[0].Col4 + list15[0].Col6 + list15[0].Col8), 6, 4);
            ex.ShowExcel();
        }

        /// <summary>
        /// 文档格式预定义好的，动态填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExceldt(string obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\10配电变压器汇总表.xls";
            ex.Open(fname );
            IList list=new  ArrayList ();
            int pagecount=0;
            //obj = "317";
            string strfilter = " and 1=1";
            if (obj != "") strfilter = strfilter + " and a.OrgCode='" + obj+"' ";
            IList caplist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select distinct  b.byqCapcity    from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " order by b.byqCapcity");
            //caplist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", "11配电变压器卡片", "容量"));
            //IList modmflist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  UPPER(replace(b.byqModle,'-'+cast(b.byqCapcity as nvarchar(50))+'/'+cast(b.byqVol  as nvarchar(50)),'')) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID   " + strfilter + " and b.omniseal='true'");
            //IList modtmlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  UPPER(replace(b.byqModle,'-'+cast(b.byqCapcity as nvarchar(50))+'/'+cast(b.byqVol  as nvarchar(50)),'')) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID   " + strfilter + " and (b.omniseal!='true' or b.omniseal is null)");
            IList modmflist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  left(UPPER(b.byqModle),CHARINDEX('-',UPPER(b.byqModle))-1) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID   " + strfilter + " and b.omniseal='true'");
            IList modtmlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  left(UPPER(b.byqModle),CHARINDEX('-',UPPER(b.byqModle))-1) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID   " + strfilter + " and (b.omniseal!='true' or b.omniseal is null)");
            int jmax = 18;
            pagecount =(int)Math.Ceiling( caplist.Count / (jmax + 0.0));
            int itemp = modtmlist.Count / 6.0 > modmflist.Count / 3.0 ? (int)Math.Ceiling(modtmlist.Count / 6.0) : (int)Math.Ceiling(modmflist.Count / 3.0 );
            int i = 0;
            pagecount = itemp * pagecount;
            if (pagecount > 1)
            {
                ex.DeleteWorkSheet("Sheet2");
                ex.DeleteWorkSheet("Sheet3"); 
            }
            /////计算需要多少个工作表
            for (i = 1; i < pagecount; i++)
            {
               
               
                ex.CopySheet(1,i);
                ex.ReNameWorkSheet((i + 1), "Sheet" + (i + 1));
               
            }
            int istart = 7, istart2 = 19, jstart = 4, j=0;
            string jstrfilter="";
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(obj);
            for ( j = 0; j < caplist.Count; j++)
            {
                ex.ActiveSheet("Sheet" + (j / jmax == 0 ? 1 : (int)Math.Ceiling(j / (jmax + 0.0))));
                //ex.ActiveSheet("Sheet" + (1 + (j / jmax) * (int)Math.Ceiling(j / (jmax + 0.0))));
                if (j % jmax == 0)
                {

                    jstrfilter = " and 1=1";
                    ex.ActiveSheet("Sheet" + (1+(j / jmax)*(int)Math.Ceiling(j / (jmax + 0.0))));
                    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select   b.byqCapcity from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + jstrfilter);
                    if (list.Count >0) ex.SetCellValue(list.Count.ToString(), 5, jstart + j % jmax);
                    list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select   sum(b.byqCapcity) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID    " + strfilter + jstrfilter);
                    //if (list[0] == null) list[0] = 0;
                    if (list[0] != null)
                    ex.SetCellValue(list[0].ToString(), 6, jstart + j % jmax);
                    setExceldt(ex, list, caplist, modtmlist, modmflist, jstrfilter, strfilter, jstart, j, jmax, istart, istart2);    
                }
                ex.ActiveSheet("Sheet" + ((j+1) / jmax == 0 ? 1 : (int)Math.Ceiling((j+1) / (jmax + 0.0))));
               
                    jstrfilter = " and 1=1 and b.byqCapcity='" + caplist[j] + "'";
                    //ex.SetCellValue(caplist[j].ToString(), 4, jstart + j % jmax + 1);
                    setExceldt(ex, list, caplist, modtmlist, modmflist, jstrfilter, strfilter, jstart+1, j, jmax, istart, istart2);    
                
               
            }
            for (i = 0; i < pagecount; i++)
            {
                ex.ActiveSheet("Sheet" + (i+1));
                int jzu=caplist.Count/jmax+1;
                int itempmin = 0, itempmax = 0;
                    itempmax = (i % jzu+1) * jmax;
                    itempmin = (i % jzu) * jmax;

                    if (org != null)
                        ex.SetCellValue(org.OrgName, 3, 3);
                    else
                        ex.SetCellValue("全局", 3, 3);

                for (j = itempmin; j < itempmax && j < caplist.Count ; j++)
                {
                    ex.SetCellValue(caplist[j].ToString(), 4, jstart + j % jmax + 1);
                
                }
                //ex.SetCellValue(caplist[j].ToString(), 4, jstart + j % jmax + 1);

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }
        /// <summary>
        /// 设置Excel数据信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="list"></param>
        /// <param name="caplist"></param>
        /// <param name="modtmlist"></param>
        /// <param name="modmflist"></param>
        /// <param name="jstrfilter"></param>
        /// <param name="strfilter"></param>
        /// <param name="jstart"></param>
        /// <param name="j"></param>
        /// <param name="jmax"></param>
        /// <param name="istart"></param>
        /// <param name="istart2"></param>
        public static void setExceldt(ExcelAccess ex, IList list, IList caplist, IList modtmlist, IList modmflist, string jstrfilter, string strfilter, int jstart, int j, int jmax, int istart, int istart2)
        {
            
            //string str = "";
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select   b.byqCapcity from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + jstrfilter);

            if (list.Count > 0) ex.SetCellValue(list.Count.ToString(), 5, jstart + j % jmax);
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select   sum(b.byqCapcity) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID    " + strfilter + jstrfilter);
           
            //if (list[0] == null) list[0] = 0;
            if (list[0] != null)

            ex.SetCellValue(list[0].ToString(), 6, jstart + j % jmax);

            for (int itm = 0; itm < modtmlist.Count; itm++)
            {
                ex.ActiveSheet("Sheet" + (1 + (itm / 6) * (int)Math.Ceiling(caplist.Count /( jmax + 0.0)) + j / jmax));
                if (j % jmax == 0)
                {
                    ex.SetCellValue(modtmlist[itm].ToString(), istart + (itm % 6) * 2, 1);
                    //jstrfilter = " and 1=1";
                    //setExceltmdt(ex, list, modtmlist, jstrfilter, strfilter, jstart, j, jmax, istart, itm);
                }
                //jstrfilter = " and 1=1 and b.byqCapcity='" + caplist[j] + "'";
                setExceltmdt(ex, list, modtmlist, jstrfilter, strfilter, jstart, j, jmax, istart, itm);
            }
            for (int imf = 0; imf < modmflist.Count; imf++)
            {

                ex.ActiveSheet("Sheet" + (1 + (imf / 3) * (int)Math.Ceiling(caplist.Count / (jmax + 0.0)) + j / jmax));
                if (j % jmax == 0)
                {
                    ex.SetCellValue(modmflist[imf].ToString(), istart2 + (imf % 3) * 2, 2);
                    //jstrfilter = " and 1=1";
                    //setExcelmfdt(ex, list, modmflist, jstrfilter, strfilter, jstart, j, jmax, istart2, imf);

                }
                //jstrfilter = " and 1=1 and b.byqCapcity='" + caplist[j] + "'";
                setExcelmfdt(ex, list, modmflist, jstrfilter, strfilter, jstart, j, jmax, istart2, imf);

            }
        }
        /// <summary>
        /// 设置非密封数据
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="list"></param>
        /// <param name="modtmlist"></param>
        /// <param name="jstrfilter"></param>
        /// <param name="strfilter"></param>
        /// <param name="jstart"></param>
        /// <param name="j"></param>
        /// <param name="jmax"></param>
        /// <param name="istart"></param>
        /// <param name="itm"></param>
        public static void setExceltmdt(ExcelAccess ex, IList list,IList modtmlist, string jstrfilter, string strfilter, int jstart, int j, int jmax, int istart,  int itm)
        {

            //string str = "select   b.byqCapcity from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle='" + modtmlist[itm] + "-'+cast(b.byqCapcity as nvarchar(50))+'/'+ cast(b.byqVol as nvarchar(50)) and (b.omniseal!='true' or b.omniseal is null)" + jstrfilter;
            string str = "select   b.byqCapcity from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle like '" + modtmlist[itm] + "%' and (b.omniseal!='true' or b.omniseal is null)" + jstrfilter;
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", str);
            if (list.Count >0) ex.SetCellValue(list.Count.ToString(), istart + (itm % 6) * 2, jstart + j % jmax);
            //str = "select  sum( b.byqCapcity) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle='" + modtmlist[itm] + "-'+cast(b.byqCapcity as nvarchar(50))+'/'+ cast(b.byqVol as nvarchar(50)) and (b.omniseal!='true' or b.omniseal is null)" + jstrfilter;
            str = "select  sum( b.byqCapcity) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle like '%" + modtmlist[itm] + "%' and (b.omniseal!='true' or b.omniseal is null)" + jstrfilter;
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", str);
            //if (list[0] == null) list[0] = 0;
            if (list[0] != null)
            ex.SetCellValue(list[0].ToString(), istart + (itm % 6) * 2 + 1, jstart + j % jmax);
        }
        /// <summary>
        /// 设置密封数据
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="list"></param>
        /// <param name="modmflist"></param>
        /// <param name="jstrfilter"></param>
        /// <param name="strfilter"></param>
        /// <param name="jstart"></param>
        /// <param name="j"></param>
        /// <param name="jmax"></param>
        /// <param name="istart2"></param>
        /// <param name="imf"></param>
        public static void setExcelmfdt(ExcelAccess ex, IList list,   IList modmflist, string jstrfilter, string strfilter, int jstart, int j, int jmax, int istart2,int imf)
        {

            //string str = "select   b.byqCapcity from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle='" + modmflist[imf] + "-'+cast(b.byqCapcity as nvarchar(50))+'/'+ cast(b.byqVol as nvarchar(50))  and (b.omniseal='true' )" + jstrfilter;
            string str = "select   b.byqCapcity from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle like '" + modmflist[imf] + "%'  and (b.omniseal='true' )" + jstrfilter;
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", str);
            if (list.Count > 0) ex.SetCellValue(list.Count.ToString(), istart2 + (imf % 3) * 2, jstart + j % jmax);
            //str = "select  sum( b.byqCapcity) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle='" + modmflist[imf] + "-'+cast(b.byqCapcity as nvarchar(50))+'/'+ cast(b.byqVol as nvarchar(50)) and (b.omniseal='true' )" + jstrfilter;
            str = "select  sum( b.byqCapcity) from dbo.mOrg a,dbo.PS_tqbyq b,dbo.PS_xl c, dbo.PS_tq d where a.OrgCode=c.OrgCode and c.LineCode=d.xlCode and d.tqID=b.tqID  " + strfilter + " and b.byqModle like '" + modmflist[imf] + "%' and (b.omniseal='true' )" + jstrfilter;
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", str);
            //if (list[0] == null) list[0] = 0;
            if (list[0] != null)
            ex.SetCellValue(list[0].ToString(), istart2 + (imf % 3) * 2 + 1, jstart + j % jmax);
        }
    }
}
