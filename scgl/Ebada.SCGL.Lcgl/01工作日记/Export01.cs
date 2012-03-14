using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Scgl.Core;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// </summary>
    public class Export01 {
        //ExcelAccess
        public static void ExportExcel(PJ_01gzrj jl, IList<PJ_gzrjnr> nrList) {
            nrList = getRjnrList(jl.gzrjID);
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\01工作日志.xls";
            ex.Open(fname);
            int row = 1;
            int col = 1;
            int row_nr = 9;
            int row_num = 36 * 2;
            List<string> strpy = Ecommon.ResultStrList("领导检查评语：" + jl.py, row_num);
            List<string> strjs = Ecommon.ResultStrList("记事：" + jl.js, row_num);
            int nrpage = Ecommon.GetPagecount(nrList.Count, 9);
            int p = Math.Max(Ecommon.GetPagecount(strpy.Count + strjs.Count, 5), nrpage);
            System.Collections.ArrayList objlist = new System.Collections.ArrayList();
            objlist.Add(strjs);
            objlist.Add(strpy);
            List<string> allList = Ecommon.GetCollList(objlist);
            
            for (int j = 1; j <= p; j++) {
                if (j > 1) {
                    ex.CopySheet(1, 1);
                }
            }
            for (int j = 1; j <= p; j++) {
                ex.ActiveSheet(j);
                ex.ReNameWorkSheet(j, "Sheet" + (j));
                setHead(ex, jl);
                if (j == 1) {
                    setHead2(ex, jl);
                }
                int prepageindex = j - 1;
                //主题
                int starownr = prepageindex * 9 + 1;
                int js = prepageindex * 5 + 1;
                int endrownr = j * 9;
                int endrowjs = j * 5;
                int bh = 0;
                if (nrList.Count > endrownr) {
                    for (int i = 0; i < 9; i++) {
                        bh++;
                        PJ_gzrjnr obj = nrList[starownr - 1 + i];
                        ex.SetCellValue(obj.seq > 0 ? obj.seq.ToString() : "", row + 9 + i, col);
                        ex.SetCellValue(obj.gznr, row + 9 + i, col + 1);
                        ex.SetCellValue(obj.fzr, row + 9 + i, col + 8);
                        ex.SetCellValue(obj.cjry, row + 9 + i, col + 11);

                    }
                } else if (nrList.Count <= endrownr && nrList.Count >= starownr) {
                    for (int i = 0; i < nrList.Count - starownr + 1; i++) {
                        PJ_gzrjnr obj = nrList[starownr - 1 + i];
                        ex.SetCellValue(obj.seq > 0 ? obj.seq.ToString() : "", row + 9 + i, col);
                        ex.SetCellValue(obj.gznr, row + 9 + i, col + 1);
                        ex.SetCellValue(obj.fzr, row + 9 + i, col + 8);
                        ex.SetCellValue(obj.cjry, row + 9 + i, col + 11);
                    }
                }
                if (allList.Count > endrowjs) {
                    for (int i = 0; i < 5; i++) {
                        ex.SetCellValue(allList[js - 1 + i], row + 18 + i, col);
                    }
                } else if (allList.Count <= endrowjs && allList.Count >= js) {
                    for (int i = 0; i < allList.Count - js + 1; i++) {
                        ex.SetCellValue(allList[js - 1 + i], row + 18 + i, col);
                    }
                }
            }
            ex.ActiveSheet(1);
            ex.ShowExcel();

        }
        /// <summary>
        /// 填充头尾
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="jl"></param>
        private static void setHead(ExcelAccess ex, PJ_01gzrj jl) {
            int row = 1;
            int col = 1;
            int row_nr = 9;
            //日期
            ex.SetCellValue(jl.rq.Year.ToString(), row + 3, col + 1);
            ex.SetCellValue(jl.rq.Month.ToString(), row + 3, col + 3);
            ex.SetCellValue(jl.rq.Day.ToString(), row + 3, col + 5);
            ex.SetCellValue(jl.xq.Replace("星期", ""), row + 3, col + 10);
            ////签字、时间
            //ex.SetCellValue(jl.qz, row + 14 + row_nr, col + 2);
            //if (ComboBoxHelper.CompreDate(jl.qzrq))
            //{
            //    ex.SetCellValue(jl.qzrq.Year.ToString(), row + 14 + row_nr, col + 6);
            //    ex.SetCellValue(jl.qzrq.Month.ToString(), row + 14 + row_nr, col + 9);
            //    ex.SetCellValue(jl.qzrq.Day.ToString(), row + 14 + row_nr, col + 11);
            //}
            
        }
        /// <summary>
        /// 填充人员
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="jl"></param>
        private static void setHead2(ExcelAccess ex, PJ_01gzrj jl) {
            int row = 1;
            int col = 1;
           
            //姓名、原因
            string[] rr = new string[10];
            string[] yy = new string[10];
            string[] rr2 = jl.qqry.Split(";".ToCharArray());
            for (int i = 0; i < rr2.Length - 1; i++) {
                rr[i] = rr2[i].Split(":".ToCharArray())[0];
                yy[i] = rr2[i].Split(":".ToCharArray())[1];
            }
            for (int i = rr2.Length - 1; i < rr.Length; i++) {
                rr[i] = "";
                yy[i] = "";
            }
            ex.SetCellValue(rr[0], row + 4, col + 2);
            ex.SetCellValue(rr[1], row + 4, col + 4);
            ex.SetCellValue(rr[2], row + 4, col + 6);
            ex.SetCellValue(rr[3], row + 4, col + 8);
            ex.SetCellValue(rr[4], row + 4, col + 10);
            ex.SetCellValue(rr[5], row + 6, col + 2);
            ex.SetCellValue(rr[6], row + 6, col + 4);
            ex.SetCellValue(rr[7], row + 6, col + 6);
            ex.SetCellValue(rr[8], row + 6, col + 8);
            ex.SetCellValue(rr[9], row + 6, col + 10);
            ex.SetCellValue(yy[0], row + 5, col + 2);
            ex.SetCellValue(yy[1], row + 5, col + 4);
            ex.SetCellValue(yy[2], row + 5, col + 6);
            ex.SetCellValue(yy[3], row + 5, col + 8);
            ex.SetCellValue(yy[4], row + 5, col + 10);
            ex.SetCellValue(yy[5], row + 7, col + 2);
            ex.SetCellValue(yy[6], row + 7, col + 4);
            ex.SetCellValue(yy[7], row + 7, col + 6);
            ex.SetCellValue(yy[8], row + 7, col + 8);
            ex.SetCellValue(yy[9], row + 7, col + 10);

            //人身,设备
            ex.SetCellValue(jl.rsaqts.ToString(), row + 5, col + 13);
            ex.SetCellValue(jl.sbaqts.ToString(), row + 7, col + 13);
        }

        /// <summary>
        /// 获了内容记录
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private static IList<PJ_gzrjnr> getRjnrList(string pid) {
            IList<PJ_gzrjnr> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_gzrjnr>(" where gzrjID='" + pid + "' order by seq");
            IList<PJ_gzrjnr> list2 = new List<PJ_gzrjnr>();
            int nrows = 0;
            for (int i = 0; i < list.Count; i++) {
                PJ_gzrjnr nr = list[i];
                List<string> lines = Ecommon.ResultStrList(nr.gznr, 34);
                //string[] lines = nr.gznr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                nr.gznr = "";
                int j = 0;
                foreach (string line in lines) {
                    j++;
                    nrows++;
                    if (j == 1) {
                        nr.gznr = line;
                        list2.Add(nr);
                    } else {
                        PJ_gzrjnr newnr = new PJ_gzrjnr();
                        newnr.gznr = line;
                        list2.Add(newnr);
                    }
                }
            }
            return list2;
        }

    }
}
