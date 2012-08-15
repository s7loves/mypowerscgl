using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using System.IO;
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    internal class PrintHelper {
        /// <summary>
        /// 根据入库单id，导出入库单
        /// </summary>
        /// <param name="rkid"></param>
        internal static void ExportRK(string rkid) {
            ExcelAccess ea = new ExcelAccess();
            string filename=AppDomain.CurrentDomain.BaseDirectory+"\\00记录模板\\入库单.xls";
            if (!File.Exists(filename))
            {
                //导出资源文件到本机
                Stream obj = typeof(PrintHelper).Assembly.GetManifestResourceStream("Ebada.Kcgl._00记录模板.入库单.xls");
                object[] files = typeof(PrintHelper).Assembly.GetManifestResourceNames();
                if (obj != null) {
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

            kc_入库单 rkobj=Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_入库单>(rkid);
            if(rkobj==null)return;
            kc_工程项目 gcobj=Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_工程项目>(rkobj.工程项目_ID);
            string kcname=gcobj!=null?gcobj.工程项目名称:"";
            ea.SetCellValue(rkobj.入库时间.ToString("yyyy-MM-dd"),3,5);
            //数据源
            IList<Model.kc_入库明细表> list = Client.ClientHelper.TransportSqlMap.GetList<kc_入库明细表>("where 入库单_ID='" + rkid + "'");

            int brow = 5;
            int bcol = 2;
            //填充数据
            for (int i = 0; i < list.Count; i++) {
                var obj = list[i];
                ea.SetCellValue((i+1).ToString(), i + brow, bcol-1);
                ea.SetCellValue(kcname, i + brow, bcol);
                ea.SetCellValue(obj.供货厂家, i + brow, bcol + 1);
                ea.SetCellValue(obj.材料名称, i + brow, bcol + 2);
                ea.SetCellValue(obj.规格及型号, i + brow, bcol + 3);
                ea.SetCellValue(obj.计量单位, i + brow, bcol + 4);
                ea.SetCellValue(obj.数量.ToString(), i + brow, bcol + 5);
                ea.SetCellValue(obj.备注, i + brow, bcol + 6);
            }

            //显示文件
            ea.ShowExcel();
        }
        internal static void ExportCK(string rkid) {
            ExcelAccess ea = new ExcelAccess();
            string filename = AppDomain.CurrentDomain.BaseDirectory + "\\00记录模板\\出库单.xls";
            if (!File.Exists(filename))
            {
                //导出资源文件到本机
                Stream obj = typeof(PrintHelper).Assembly.GetManifestResourceStream("Ebada.Kcgl._00记录模板.出库单.xls");
                object[] files = typeof(PrintHelper).Assembly.GetManifestResourceNames();
                if (obj != null) {
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
            

            ea.SetCellValue(rkobj.出库时间.Year + "", 3, 2);
            ea.SetCellValue(rkobj.出库时间.Month + "", 3, 4);
            ea.SetCellValue(rkobj.出库时间.Day + "", 3, 6);
            ea.SetCellValue(rkobj.出库时间.Year + "", 50, 2);
            ea.SetCellValue(rkobj.出库时间.Month + "", 50, 4);
            ea.SetCellValue(rkobj.出库时间.Day + "", 50, 6);
            ea.SetCellValue(rkobj.出库时间.Year + "", 97, 2);
            ea.SetCellValue(rkobj.出库时间.Month + "", 97, 4);
            ea.SetCellValue(rkobj.出库时间.Day + "", 97, 6);

            //数据源
            IList<Model.kc_出库明细表> list = Client.ClientHelper.TransportSqlMap.GetList<kc_出库明细表>("where 出库单_ID='" + rkid + "'");
            if (list.Count > 0) {
                kcname = list[0].工程类别;
                ea.SetCellValue(kcname + "", 1, 2);
                ea.SetCellValue(kcname + "", 48, 2);
                ea.SetCellValue(kcname + "", 95, 2);
                ea.SetCellValue(list[0].出库单位 + "", 5, 3);
                ea.SetCellValue(list[0].出库单位 + "", 52, 3);
                ea.SetCellValue(list[0].出库单位 + "", 99, 3);
            }
            int brow = 7;
            int bcol = 2;
            //填充数据
            for (int i = 0; i < list.Count; i++) {
                var obj = list[i];
                ea.SetCellValue((i + 1).ToString(), i + brow, bcol - 1);
                ea.SetCellValue(obj.材料名称, i + brow, bcol );
                ea.SetCellValue(obj.规格及型号, i + brow, bcol + 2);
                ea.SetCellValue(obj.计量单位, i + brow, bcol + 4);
                ea.SetCellValue(obj.数量.ToString(), i + brow, bcol + 5);
                ea.SetCellValue(obj.备注, i + brow, bcol + 6);
                if (i > 37) break;
            }
            brow = 54;
            bcol = 2;
            //填充数据
            for (int i = 0; i < list.Count; i++) {
                var obj = list[i];
                ea.SetCellValue((i + 1).ToString(), i + brow, bcol - 1);
                ea.SetCellValue(obj.材料名称, i + brow, bcol);
                ea.SetCellValue(obj.规格及型号, i + brow, bcol + 2);
                ea.SetCellValue(obj.计量单位, i + brow, bcol + 4);
                ea.SetCellValue(obj.数量.ToString(), i + brow, bcol + 5);
                ea.SetCellValue(obj.备注, i + brow, bcol + 6);
                if (i > 37) break;
            }
            brow = 101;
            bcol = 2;
            //填充数据
            for (int i = 0; i < list.Count; i++) {
                var obj = list[i];
                ea.SetCellValue((i + 1).ToString(), i + brow, bcol - 1);
                ea.SetCellValue(obj.材料名称, i + brow, bcol);
                ea.SetCellValue(obj.规格及型号, i + brow, bcol + 2);
                ea.SetCellValue(obj.计量单位, i + brow, bcol + 4);
                ea.SetCellValue(obj.数量.ToString(), i + brow, bcol + 5);
                ea.SetCellValue(obj.备注, i + brow, bcol + 6);
                if (i > 37) break;
            }
            //显示文件
            ea.ShowExcel();
        }
    }
}
