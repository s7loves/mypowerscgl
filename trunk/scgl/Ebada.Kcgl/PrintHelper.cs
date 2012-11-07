using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using System.IO;
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl
{
    internal class PrintHelper
    {
        /// <summary>
        /// 根据入库单id，导出入库单
        /// </summary>
        /// <param name="rkid"></param>
        internal static void ExportRK(string rkid)
        {
            ExcelAccess ea = new ExcelAccess();
            string filename = AppDomain.CurrentDomain.BaseDirectory + "\\00记录模板\\入库单.xls";
            if (!File.Exists(filename))
            {
                //导出资源文件到本机
                Stream obj = typeof(PrintHelper).Assembly.GetManifestResourceStream("Ebada.Kcgl._00记录模板.入库单.xls");
                object[] files = typeof(PrintHelper).Assembly.GetManifestResourceNames();
                if (obj != null)
                {
                    byte[] buff = new byte[obj.Length];
                    obj.Read(buff, 0, (int)obj.Length);

                    FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                    fs.Write(buff, 0, buff.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }

            }
            ea.Open(filename);

            kc_入库单 rkobj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_入库单>(rkid);
            if (rkobj == null) return;
            kc_工程类别 gcobj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_工程类别>(rkobj.工程类别_ID);
            string kcname = gcobj != null ? gcobj.工程类别 : "";
            //数据源
            IList<Model.kc_入库明细表> list = Client.ClientHelper.TransportSqlMap.GetList<kc_入库明细表>("where 入库单_ID='" + rkid + "'");

            ea.SetCellValue(kcname, 2, 4);
            ea.SetCellValue(kcname, 4, 10);
            ea.SetCellValue(rkobj.入库时间.Year.ToString(), 4, 1);
            ea.SetCellValue(rkobj.入库时间.Month.ToString(), 4, 3);
            ea.SetCellValue(rkobj.入库时间.Day.ToString(), 4, 5);

            int brow = 6;
            int bcol = 1;
            int rowcount = 12;

            ea.ReNameWorkSheet(1, kcname);
            int pageindex = 1;

            if (rowcount != 0)
            {
                if (list.Count % rowcount != 0)
                {
                    pageindex = (list.Count / rowcount + 1);
                }
                else
                {
                    pageindex = list.Count / rowcount;
                }
            }

            for (int j = 2; j <= pageindex; j++)
            {
                ea.CopySheet(1, j - 1);

                ea.ReNameWorkSheet(j, kcname + "(" + (j) + ")");
            }

            //填充数据

            for (int i = 0; i < list.Count; i++)
            {
                if (i % rowcount == 0)
                {
                    if (i == 0) ea.ActiveSheet(kcname);
                    else ea.ActiveSheet(kcname + "(" + (i / rowcount + 1) + ")");
                }

                var obj = list[i];
                ea.SetCellValue(obj.材料名称, brow + i % rowcount, bcol);
                ea.SetCellValue(obj.规格及型号, brow + i % rowcount, bcol + 6);
                ea.SetCellValue(obj.计量单位, brow + i % rowcount, bcol + 8);
                ea.SetCellValue(obj.数量.ToString(), brow + i % rowcount, bcol + 9);
                ea.SetCellValue(obj.单价.ToString(), brow + i % rowcount, bcol + 10);
                ea.SetCellValue(obj.总计.ToString(), brow + i % rowcount, bcol + 12);
            }

            //显示文件
            //ea.Print();
            //ea.DisPoseExcel();
            ea.ActiveSheet(kcname);
            ea.ShowExcel();
        }
        internal static void ExportCK(string rkid)
        {
            ExcelAccess ea = new ExcelAccess();
            string filename = AppDomain.CurrentDomain.BaseDirectory + "\\00记录模板\\出库单.xls";
            if (!File.Exists(filename))
            {
                //导出资源文件到本机
                Stream obj = typeof(PrintHelper).Assembly.GetManifestResourceStream("Ebada.Kcgl._00记录模板.出库单.xls");
                object[] files = typeof(PrintHelper).Assembly.GetManifestResourceNames();
                if (obj != null)
                {
                    byte[] buff = new byte[obj.Length];
                    obj.Read(buff, 0, (int)obj.Length);

                    FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                    fs.Write(buff, 0, buff.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }

            }
            ea.Open(filename);

            kc_出库单 rkobj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_出库单>(rkid);
            if (rkobj == null) return;
            kc_工程项目 gcobj = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_工程项目>(rkobj.工程项目_ID);
            string kcname = gcobj != null ? gcobj.工程项目名称 : "";


            ea.SetCellValue(rkobj.出库时间.Year + "", 4, 7);
            ea.SetCellValue(rkobj.出库时间.Month + "", 4, 9);
            ea.SetCellValue(rkobj.出库时间.Day + "", 4, 11);

            //数据源
            IList<Model.kc_出库明细表> list = Client.ClientHelper.TransportSqlMap.GetList<kc_出库明细表>("where 出库单_ID='" + rkid + "'");
            if (list.Count > 0)
            {
                kcname = list[0].工程类别;
                ea.SetCellValue(kcname + "", 2, 3);
                ea.SetCellValue(list[0].出库单位 + "", 4, 2);
            }
            int brow = 7;
            int bcol = 1;
            int rowcount = 10;
            ea.ReNameWorkSheet(1, kcname);
            int pageindex = 1;

            if (rowcount != 0)
            {
                if (list.Count % rowcount != 0)
                {
                    pageindex = (list.Count / rowcount + 1);
                }
                else
                {
                    pageindex = list.Count / rowcount;
                }
            }

            for (int j = 2; j <= pageindex; j++)
            {
                ea.CopySheet(1, j - 1);

                ea.ReNameWorkSheet(j, kcname + "(" + (j) + ")");
            }

            //填充数据
            for (int i = 0; i < list.Count; i++)
            {
                if (i % rowcount == 0)
                {
                    if (i == 0) ea.ActiveSheet(kcname);
                    else ea.ActiveSheet(kcname + "(" + (i / rowcount + 1) + ")");
                }

                var obj = list[i];
                ea.SetCellValue(obj.材料名称, brow + i % rowcount, bcol);
                ea.SetCellValue(obj.规格及型号, brow + i % rowcount, bcol + 2);
                ea.SetCellValue(obj.计量单位, brow + i % rowcount, bcol + 4);
                ea.SetCellValue(obj.数量.ToString(), brow + i % rowcount, bcol + 5);
                ea.SetCellValue(obj.单价.ToString(), brow + i % rowcount, bcol + 7);


                char[] count = obj.总计.ToString("000000.00").Replace(".", "").ToCharArray();

                for (int j = 0; j < count.Length; j++)
                {
                    ea.SetCellValue(count[j].ToString(), brow + i % rowcount, bcol + j + 11);
                }
            }
            //显示文件
            //ea.Print();
            ea.ActiveSheet(kcname);
            ea.ShowExcel();
            //ea.DisPoseExcel();
        }
    }
}
