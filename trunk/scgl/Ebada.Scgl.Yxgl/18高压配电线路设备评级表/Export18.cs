using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Client.Platform;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export18 {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_18gysbpj obj) {
            //lgm
            IList<PJ_18gysbpjmx> objlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_18gysbpjmx>("SelectPJ_18gysbpjmxList", "where PJ_ID='" + obj.PJ_ID + "'");
            ExportExcel(obj, objlist);
        }
        public static void ExportExcel(PJ_18gysbpj obj, IList<PJ_18gysbpjmx> objlist) {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\18双河所设备评级表.xls";

            ex.Open(fname);
            //此处写填充内容代码
            int pagecout = Ecommon.GetPagecount(objlist.Count, 29);

            //复制空模板并重命名
            for (int m = 1; m < pagecout; m++) {
                ex.CopySheet(1, m);
                ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
            }
            for (int p = 0; p < pagecout; p++) {
                ex.ActiveSheet(p + 1);
                ex.SetCellValue("绥化农电局  " + obj.OrgName, 4, 1);

                for (int i = 0; i < 29; i++) {
                    if (p * 29 + i >= objlist.Count) {
                        break;
                    }
                    PJ_18gysbpjmx tempobj = objlist[p * 29 + i];
                    //ex.SetCellValue((p * 29 + i).ToString(), 7 + i, 1);
                    ex.SetCellValue(tempobj.xh.ToString(), 7 + i, 1);
                    ex.SetCellValue(tempobj.sbdy, 7 + i, 2);
                    ex.SetCellValue(tempobj.one.ToString(), 7 + i, 5);
                    ex.SetCellValue(tempobj.two.ToString(), 7 + i, 6);
                    ex.SetCellValue(tempobj.three.ToString(), 7 + i, 9);
                    ex.SetCellValue(tempobj.whl * 100 + "%", 7 + i, 12);
                    ex.SetCellValue(tempobj.qxnr, 7 + i, 13);
                    ex.SetCellValue(tempobj.fzdw, 7 + i, 14);

                }
                //            ex.SetCellValue(obj.fzr, 36, 2);
                ex.SetCellValue(obj.zbr, 36, 4);
                ex.SetCellValue(obj.rq.Year.ToString(), 36, 6);
                ex.SetCellValue(obj.rq.Month.ToString(), 36, 8);
                ex.SetCellValue(obj.rq.Day.ToString(), 36, 10);
            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }
        /// <summary>
        /// 动太生成显示评级表，地理信息调用
        /// </summary>
        /// <param name="orgcode"></param>
        public static void BuildPjView(string orgcode,string orgname) {
            if (string.IsNullOrEmpty(orgname)) {
                mOrg org = Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + orgcode + "'");
                if (org == null) {
                    throw new Exception("没有找到相应单位" + orgcode);
                }
                orgname = org.OrgName;
            }
            PJ_18gysbpj obj = new PJ_18gysbpj();
            obj.OrgCode = orgcode;
            obj.OrgName = orgname;
            obj.CreateDate = DateTime.Now;
            obj.CreateMan = MainHelper.User.UserName;
            obj.rq = DateTime.Now;
            obj.zbr = obj.CreateMan;
            ExportExcel(obj, BuildPj(obj, false));
        }
        public static List<PJ_18gysbpjmx> BuildPj(PJ_18gysbpj obj,bool save) {
            IList<PS_xl> listxl = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + obj.OrgCode + "'and ParentID = ''");
            List<PJ_18gysbpjmx> listmx = new List<PJ_18gysbpjmx>();
            int bh = 0;
            string loginname=MainHelper.User.UserName;
            foreach (PS_xl pl in listxl) {
                bh++;
                //线路
                PJ_18gysbpjmx pjmx = new PJ_18gysbpjmx();
                pjmx.PJ_ID = obj.PJ_ID;
                pjmx.xh = bh;
                pjmx.sbdy = pl.LineName;
                pjmx.CreateDate = DateTime.Now;
                pjmx.CreateMan = loginname;
                int line1 = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "SELECT SUM(WireLength) FROM PS_xl WHERE linevol='10' and  SUBSTRING(LineCode, 1, 6) = '" + pl.LineCode + "'AND (lineKind = '一类')"));
                int line2 = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "SELECT SUM(WireLength) FROM PS_xl WHERE linevol='10' and SUBSTRING(LineCode, 1, 6) = '" + pl.LineCode + "'AND (lineKind = '二类')"));
                int line3 = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "SELECT SUM(WireLength) FROM PS_xl WHERE linevol='10' and SUBSTRING(LineCode, 1, 6) = '" + pl.LineCode + "'AND (lineKind = '三类')"));
                pjmx.one = line1;
                pjmx.two = line2;
                pjmx.three = line3;
                if ((line1 + line2 + line3) != 0) {
                    pjmx.whl = Convert.ToDecimal((line1 + line2) / (line1 + line2 + line3));
                }
                listmx.Add(pjmx);
                //台区
                IList<PS_tq> listtq = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("where SUBSTRING(xlCode, 1, 6) ='" + pl.LineCode + "'");

                foreach (PS_tq pq in listtq) {

                    bh++;
                    pjmx = new PJ_18gysbpjmx();
                    pjmx.ID += bh;
                    pjmx.xh = bh;
                    pjmx.PJ_ID = obj.PJ_ID;
                    pjmx.sbdy = pq.tqName;
                    pjmx.CreateDate = DateTime.Now;
                    pjmx.CreateMan = loginname;
                    switch (pq.btKind) {
                        case "一类":
                            pjmx.one = 1;
                            pjmx.whl = 1;
                            break;
                        case "二类":
                            pjmx.two = 2;
                            pjmx.whl = 1;
                            break;
                        case "三类":
                            pjmx.three = 1;
                            pjmx.whl = 0;
                            break;

                    }
                    listmx.Add(pjmx);
                }
                //开关
                IList<PS_kg> listkg = Client.ClientHelper.PlatformSqlMap.GetList<PS_kg>("WHERE (gtID IN(SELECT gtID FROM PS_gt WHERE (SUBSTRING(LineCode, 1, 6) = '" + pl.LineCode + "')))");
                foreach (PS_kg pq in listkg) {
                    bh++;
                    pjmx = new PJ_18gysbpjmx();
                    pjmx.ID += bh;
                    pjmx.xh = bh;
                    pjmx.PJ_ID = obj.PJ_ID;
                    pjmx.sbdy = pq.kgName;
                    pjmx.CreateDate = DateTime.Now;
                    pjmx.CreateMan = loginname;
                    switch (pq.kgkind) {
                        case "一类":
                            pjmx.one = 1;
                            pjmx.whl = 1;
                            break;
                        case "二类":
                            pjmx.two = 2;
                            pjmx.whl = 1;
                            break;
                        case "三类":
                            pjmx.three = 1;
                            pjmx.whl = 0;
                            break;

                    }
                    listmx.Add(pjmx);
                }
                //变压器
                IList<PS_tqbyq> listbyq = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("WHERE (tqID IN(SELECT tqID FROM PS_tq WHERE (SUBSTRING(tqcode, 1, 6) = '" + pl.LineCode + "')))");
                foreach (PS_tqbyq pq in listbyq) {
                    bh++;
                    pjmx = new PJ_18gysbpjmx();
                    pjmx.ID += bh;
                    pjmx.xh = bh;
                    pjmx.PJ_ID = obj.PJ_ID;
                    pjmx.sbdy = pq.byqName;
                    pjmx.CreateDate = DateTime.Now;
                    pjmx.CreateMan = loginname;
                    switch (pq.byqkind) {
                        case "一类":
                            pjmx.one = 1;
                            pjmx.whl = 1;
                            break;
                        case "二类":
                            pjmx.two = 2;
                            pjmx.whl = 1;
                            break;
                        case "三类":
                            pjmx.three = 1;
                            pjmx.whl = 0;
                            break;

                    }
                    listmx.Add(pjmx);
                }
            }
            if (save)
                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(listmx.ToArray(), null, null);
            return listmx;
        }
    }
    
}
