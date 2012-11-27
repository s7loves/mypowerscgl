using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.Data;
using System.Collections;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export16  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_16 obj1) {
            PS_xl xl = new PS_xl() { LineCode = obj1.LineCode, LineName = obj1.LineName };
            ExportExcel(xl);
        }
        public static void ExportExcel(PS_xl obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\16高压配电线路条图汇总表.xls";

            object ot = new object();
            ex.Open(fname);
            //设置格式      
            try {
                ex.MyExcel.get_Range("A1", "T35").NumberFormat = "@";//文本格式
            } catch { }

            //此处写填充内容代码
            //线路名称
            ex.SetCellValue(obj.LineName, 4, 2);
            //总的杆塔数
            string sumgt = "0";
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "')");
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null) {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 7, 2);
            //铁塔
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType='铁塔' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null) {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 8, 2);
            //钢管杆
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType='钢管杆' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null) {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 9, 2);
            //水泥杆
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType like '混凝土%' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null) {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 10, 2);
            //木杆
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType='木杆' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null) {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 11, 2);
            //主干长
            string length = "0";
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", string.Format(" where LineCode='{0}'", obj.LineCode));
            int lenzg = (int)ot;
            if (ot != null) {
                length = Math.Round(lenzg / 1000.0, 2) + "";//km
            }

            ex.SetCellValue(length, 9, 5);//主干
            //总长度
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", string.Format("where  linecode like '{0}%' and linevol='10'", obj.LineCode));
            if (ot != null) {
                length = Math.Round((int)ot / 1000.0, 2) + "";
            }
            ex.SetCellValue(length, 9, 4);//小计（线路长度）
            ex.SetCellValue(length, 9, 3);//合计
            //分支线的数目和长度
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlRowCount", string.Format("where  linecode like '{0}%' and linevol='10' and len(linecode)>6", obj.LineCode));
            if (ot != null) {
                sumgt = (int)ot + "";
            }
            ex.SetCellValue(sumgt, 9, 6);

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", string.Format("where  linecode like '{0}%' and linevol='10' and len(linecode)>6", obj.LineCode));
            if (ot != null) {
                length = Math.Round((int)ot / 1000.0, 2) + "";
            }
            ex.SetCellValue(length, 9, 8);
            //供电半经
            double gdbj = jsgdbj(obj.LineCode);
            length = Math.Round(gdbj / 1000.0, 2) + "";
            ex.SetCellValue(length, 9, 13);
            //变压器容量和台

            //总容量
            string ts = "0";
            Object bj = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
            if (bj != null) {
                if (!string.IsNullOrEmpty(obj.LineCode)) {
                    string rl = "0";
                    ot = bj;// Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null) {
                        rl = ot.ToString();
                    }
                    ex.SetCellValue(rl, 15, 1);
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol like '6%'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    rl = "0";
                    if (ot != null) {
                        rl = ot.ToString();
                    }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol like '6%'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");

                    if (ot != null) {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 2);
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol like '10%'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    rl = "0";
                    if (ot != null) {
                        rl = ot.ToString();
                    }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol like '10%'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null) {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 3);
                    rl = "0";
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol like '6%'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null) {
                        rl = ot.ToString();
                    }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol like '6%'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null) {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 4);
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol like '10%'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    rl = "0";
                    if (ot != null) {
                        rl = ot.ToString();
                    }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol like '10%'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null) {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue((rl + "/" + ts).ToString(), 15, 5);
                }

            }
            object ot1 = null, ot2 = null;
            int 小计 = 0;
            int 合计 = 0;


            //开关
            string kg = "0";

            //    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='油开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle like '%DW%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            ot = ot ?? 0;
            合计 += Convert.ToInt32(ot);
            kg = ot.ToString();
            ex.SetCellValue(kg, 15, 8);

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle like '%ZW%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            ot = ot ?? 0;
            合计 += Convert.ToInt32(ot);
            kg = ot.ToString();
            ex.SetCellValue(kg, 16, 8);

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle like '%SF6%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            ot = ot ?? 0;
            合计 += Convert.ToInt32(ot);
            kg = ot.ToString();

            ex.SetCellValue(kg, 17, 8);

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle like '%智能%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            ot = ot ?? 0;
            合计 += Convert.ToInt32(ot);
            kg = ot.ToString();
            ex.SetCellValue(kg, 18, 8);
            //跌落开关
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(sbNumber) from ps_tqsb Where sbname='跌落保险'  and tqID in(select tqid from ps_tq WHERE xlCode ='{0}' )", obj.LineCode));
            ot = ot ?? 0;
            合计 += Convert.ToInt32(ot);
            kg = ot.ToString();
            ex.SetCellValue(kg, 19, 8);
            //开关合计
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");

            kg = 合计.ToString();
            ex.SetCellValue(kg, 14, 8);

            合计 = 0;
            //台区
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCount", "Where   xlCode ='" + obj.LineCode + "'");
            ts = "0";
            if (ot != null) {
                ts = ot.ToString();
            }
            ex.SetCellValue(ts, 21, 8);
            ts = "0";
            ot = null;// Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))");
            if (ot != null) {
                ts = ot.ToString();
            }
            ex.SetCellValue(ts, 22, 8);
            ts = "0";
            ot = null;// Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电亭'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))");
            if (ot != null) {
                ts = ot.ToString();
            }
            ex.SetCellValue(ts, 23, 8);
            //避雷器
            string blq = "0";


            //统计型号'Y%'
            //统计杆塔设备库
            ot1 = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(sbNumber) from ps_gtsb Where sbname='避雷器' and sbModle like 'Y%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10' ))", obj.LineCode.Length, obj.LineCode));
            //统计台区设备库
            ot2 = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(sbNumber) from ps_tqsb Where sbname='避雷器' and sbModle like 'Y%' and tqID in(select tqid from ps_tq WHERE xlCode ='{0}' )", obj.LineCode));
            ot1 = ot1 ?? 0;
            ot2 = ot2 ?? 0;
            小计 = Convert.ToInt32(ot1) + Convert.ToInt32(ot2);
            合计 += 小计;
            blq = 小计.ToString();
            ex.SetCellValue(blq, 15, 13);

            //统计型号'FZ%'            
            ot1 = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(sbNumber) from ps_gtsb Where sbname='避雷器' and sbModle like 'FZ%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10' ))", obj.LineCode.Length, obj.LineCode));
            ot2 = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(sbNumber) from ps_tqsb Where sbname='避雷器' and sbModle like 'FZ%' and tqID in(select tqid from ps_tq WHERE xlCode ='{0}' )", obj.LineCode));
            ot1 = ot1 ?? 0;
            ot2 = ot2 ?? 0;
            小计 = Convert.ToInt32(ot1) + Convert.ToInt32(ot2);
            合计 += 小计;
            blq = 小计.ToString();
            ex.SetCellValue(blq, 16, 13);

            //
            blq = "0";
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", string.Format("Where sbname='避雷器'and sbModle like '%Y5WZ-17/45%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10' ))", obj.LineCode.Length, obj.LineCode));
            if (ot != null) {
                blq = ot.ToString();
            }
            ex.SetCellValue(blq, 17, 13);

            blq = 合计.ToString();
            ex.SetCellValue(blq, 14, 13);
            合计 = 0;
            //绝缘子
            string jyuz = "0";
            //  ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbname='绝缘子' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where (sbname='高压立瓶' or sbname='高压悬垂' or sbname='高压悬式绝缘子'  or sbname='高压针式绝缘子' or sbname='10KV楔型耐张') and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null) {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 21, 13);
            jyuz = "0";
            //    ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where (sbname='高压立瓶' or sbname='高压针式绝缘子')and (sbModle like  'fp%' or sbModle like  'p-%'or sbModle like  '棕红色硅胶%') and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where (sbname='高压立瓶' or sbname='高压针式绝缘子') and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null) {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 22, 13);
            jyuz = "0";
            //       ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where  (sbname='高压悬垂' or sbname='高压悬式绝缘子')and (sbModle like  'fsw%' or sbModle like  'xp-%')  and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where  (sbname='高压悬垂' or sbname='高压悬式绝缘子') and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null) {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 23, 13);
            jyuz = "0";
            //          ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where sbname='10KV楔型耐张'and sbModle like 'j10%' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "select sum(sbNumber) from ps_gtsb Where sbname='10KV楔型耐张' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null) {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 24, 13);
            //  ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbname='绝缘子'and sbModle='FPQ2W-10/3T20' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            // if (ot != null) {
            //     jyuz = ot.ToString();
            //  }
            //  ex.SetCellValue(jyuz, 25, 13);

            ex.ShowExcel();
            Microsoft.Office.Interop.Excel.Worksheet ws = ex.MyExcel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            if (ws != null)
                ws.PrintPreview(true);
        }
        /// <summary>
        /// 计算供电半径
        /// </summary>
        /// <returns></returns>
        private static double jsgdbj(string linecode) {
            double ret = 0;
            IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where linecode like '" + linecode + "%' and linevol='10'");
            DataTable dt = Ebada.Core.ConvertHelper.ToDataTable((IList)list, typeof(PS_xl));
            ret = getMaxLen(dt, null);

            return ret;
        }

        private static double getMaxLen(DataTable dt, DataRow prow) {
            double maxlen = 0;
            string p = "";
            if (prow != null)
                p = prow["LineID"].ToString();
            DataRow[] rows = dt.Select("parentid='" + p + "'");
            foreach (DataRow row in rows) {
                double len = getMaxLen(dt, row);
                maxlen = Math.Max(maxlen, len + getLen(row, prow));
            }
            if (prow != null && rows.Length == 0) maxlen = (int)prow["WireLength"];
            if (prow == null && rows.Length == 1) maxlen = Math.Max(maxlen, (int)rows[0]["WireLength"]);
            return maxlen;
        }
        private static double getLen(DataRow row, DataRow prow) {
            double ret = 0;
            if (prow != null) {
                string pgt = row["ParentGT"].ToString();
                string plinecode = prow["LineCode"].ToString();
                try {
                    if (pgt.Length > 4)
                        ret = (int)Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(gtspan) from ps_gt where LineCode='{0}' and gtcode<='{1}'", plinecode, pgt));
                    else if (pgt.Length == 4)
                        ret = (int)Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", string.Format("select sum(gtspan) from ps_gt where LineCode='{0}' and gth<='{1}'", plinecode, pgt));
                } catch { }
            }
            return ret;
        }
    }
}
