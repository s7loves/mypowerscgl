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
    public class Export16  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_16 obj1)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\16高压配电线路条图汇总表.xls";
            PJ_16 obj = new PJ_16();
            Ebada.Core.ConvertHelper.CopyTo(obj1, obj);
            object ot = new object();
            ex.Open(fname);
            //此处写填充内容代码
            //线路名称
            ex.SetCellValue(obj.LineName, 4, 2);
            //总的杆塔数
            string sumgt = "0";
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "')");
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')",obj.LineCode.Length,obj.LineCode));
            if (ot != null)
            {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 7, 2);
            //铁塔
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType='铁塔' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null)
            {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 8, 2);
            //钢管杆
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType='钢管杆' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null)
            {
                sumgt = ot.ToString();
            }
            ex.SetCellValue(sumgt, 9, 2);
            //水泥杆
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType like '混凝土%' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
           if (ot != null)
           {
               sumgt = ot.ToString();
           }
            ex.SetCellValue(sumgt, 10, 2);
            //木杆
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", string.Format("where gtjg='否' and gtType='木杆' and  linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
           if (ot != null)
           {
               sumgt = ot.ToString();
           }
            ex.SetCellValue(sumgt, 11, 2);
            //主干长
            string length = "0";
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", string.Format("where linetype='1' and linevol='10' and linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')",obj.LineCode.Length,obj.LineCode));
            if (ot!=null)
            {
                length = (int)ot/1000.0+"";//km
            }
            ex.SetCellValue(length, 9, 4);
            ex.SetCellValue(length, 9, 5);
            //总长度
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", string.Format("where linevol='10' and linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null)
            {
                length = (int)ot / 1000.0 + "";
            }
            ex.SetCellValue(length, 9, 3);
            //分支线的数目和长度
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlRowCount", string.Format("where LineType in('2','3') and linevol='10' and linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if (ot != null)
            {
                sumgt = (int)ot + "";
            }
            ex.SetCellValue(sumgt, 9, 6);

            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", string.Format("where LineType in('2','3') and linevol='10' and linecode in (select linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10')", obj.LineCode.Length, obj.LineCode));
            if(ot!=null)
            {
                length = (int)ot / 1000.0 + "";
            }
            ex.SetCellValue(length, 9, 8);
            //变压器容量和台
           
            //总容量
            string ts = "0";
            Object bj=Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
            if (bj!=null)
            {
                if (!string.IsNullOrEmpty(obj.LineCode))
                {
                    string rl = "0";
                    ot = bj;// Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot!=null)
                    {
                        rl = ot.ToString();
                    }
                    ex.SetCellValue(rl, 15, 1);
                   ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='6'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                   rl = "0";
                    if (ot != null)
                   {
                       rl = ot.ToString();
                   }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='6'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                   
                    if (ot != null)
                    {
                       ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 2);
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='10'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    rl = "0";
                    if (ot != null)
                    {
                        rl = ot.ToString();
                    }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='10'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null)
                    {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 3);
                    rl = "0";
                   ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='6'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                   if (ot != null)
                   {
                       rl = ot.ToString();
                   }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='6'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null)
                    {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 4);
                   ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='10'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                   rl = "0";
                    if (ot != null)
                   {
                       rl = ot.ToString();
                   }
                    ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='10'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "')");
                    if (ot != null)
                    {
                        ts = ot.ToString();
                    }
                    ex.SetCellValue(rl + "/" + ts, 15, 5);
                }
              
            }
           
            

            //开关
            string kg = "0";
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                kg = ot.ToString();
            }
            ex.SetCellValue(kg, 14, 8);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='油开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                kg = ot.ToString();
            }
            ex.SetCellValue(kg, 15, 8);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='真空开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                kg = ot.ToString();
            }
            ex.SetCellValue(kg, 16, 8);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='SF6开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                kg = ot.ToString();
            }
            ex.SetCellValue(kg, 17, 8);

            //台区
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqRowCount", "Where   xlCode ='" + obj.LineCode + "'");
            ts = "0";
            if (ot != null)
            {
                ts = ot.ToString();
            }
            ex.SetCellValue(ts, 21, 8);
            ts = "0";
            ot = null;// Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                ts = ot.ToString();
            }
            ex.SetCellValue(ts, 22, 8);
            ts = "0";
            ot = null;// Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电亭'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                ts = ot.ToString();
            }
            ex.SetCellValue(ts, 23, 8);
            //避雷器
            string blq = "0";
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbname='避雷器' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT linecode from ps_xl where left(LineCode,{0})='{1}' and linevol='10') ))");
            if (ot != null)
            {
                blq = ot.ToString();
            }
            ex.SetCellValue(blq, 14,13);
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbname='避雷器'and sbModle='氧化锌硅胶' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
           if (ot != null)
           {
               blq = ot.ToString();
           }
            ex.SetCellValue(blq, 15, 13);
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbname='避雷器'and sbModle='阀型' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                blq = ot.ToString();
            }
            ex.SetCellValue(blq, 16, 13);
            //ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbname='避雷器'and sbModle='氧化锌硅胶带熔断器' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                blq = ot.ToString();
            }
            ex.SetCellValue(blq, 17, 13);
            //绝缘子
            string jyuz = "0";
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbType='绝缘子' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 21, 13);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbType='绝缘子'and sbModle='XP-7C' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 22, 13);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbType='绝缘子'and sbModle='P-15T' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 23, 13);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbType='绝缘子'and sbModle='FSW6-10/70' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
           if (ot != null)
           {
               jyuz = ot.ToString();
           }
            ex.SetCellValue(jyuz, 24, 13);
            ot = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtsbRowCount", "Where sbType='绝缘子'and sbModle='FPQ2W-10/3T20' and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))");
            if (ot != null)
            {
                jyuz = ot.ToString();
            }
            ex.SetCellValue(jyuz, 25, 13);

            ex.ShowExcel();
            Microsoft.Office.Interop.Excel.Worksheet ws = ex.MyExcel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            if (ws != null)
                ws.PrintPreview(true);
        }
      
    }
}
