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
        public static void ExportExcel(PJ_16 obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\16高压配电线路条图汇总表.xls";

            ex.Open(fname);
            //此处写填充内容代码
            //线路名称
            ex.SetCellValue(obj.LineName, 4, 2);
            //总的杆塔数
            string sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "')").ToString();
            ex.SetCellValue(sumgt, 7, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or(LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "'))and gtType='铁塔'").ToString();
            ex.SetCellValue(sumgt, 8, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or(LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "'))and gtType='钢管杆'").ToString();
            ex.SetCellValue(sumgt, 9, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or(LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "'))and gtType='水泥杆'").ToString();
            ex.SetCellValue(sumgt, 10, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'or(LineCode in( select lineid from PS_xl where parentid='" + obj.LineCode + "'))and gtType='木杆'").ToString();
            ex.SetCellValue(sumgt, 11, 2);
            //主干长
            string length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "'and LineType='1')").ToString();
            ex.SetCellValue(length, 9, 4);
            ex.SetCellValue(length, 9, 5);
            length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')").ToString();
            ex.SetCellValue(length, 9, 3);
            //分支线的数目和长度
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xlRowCount", "where ParentID='" + obj.LineCode + "'and LineType in('2','3')").ToString();
            ex.SetCellValue(sumgt, 9, 6);
            length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where ParentID='" + obj.LineCode + "'and LineType in('2','3')").ToString();
            ex.SetCellValue(length, 9, 7);
            //变压器容量和台
           
            //总容量
            string ts = "0";
            Object bj=Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))");
            if (bj!=null)
            {
                if (!string.IsNullOrEmpty(obj.LineCode))
                {
                    string rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ex.SetCellValue(rl, 15, 1);
                    rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='6KV'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='6KV'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ex.SetCellValue(rl + "/" + ts, 15, 2);
                    rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='10KV'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='10KV'AND byqPhase='单相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ex.SetCellValue(rl + "/" + ts, 15, 3);

                    rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='6KV'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='6KV'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ex.SetCellValue(rl + "/" + ts, 15, 4);
                    rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqVol='10KV'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqVol='10KV'AND byqPhase='三相'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
                    ex.SetCellValue(rl + "/" + ts, 15, 5);
                }
              
            }
           
            

            //开关
            string kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(kg, 14, 8);
            kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='油开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(kg, 15, 8);
            kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='真空开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(kg, 16, 8);
            kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgModle='SF6开关'and gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(kg, 17, 8);

            //台区
            ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(ts, 21, 8);
            ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(ts, 22, 8);
            ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电亭'and tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(ts, 23, 8);
            //避雷器
            string blq = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='避雷器' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(blq, 14,13);
            blq = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='避雷器'and sbModle='氧化锌硅胶' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(blq, 15, 13);
            blq = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='避雷器'and sbModle='阀型' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(blq, 16, 13);
            blq = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='避雷器'and sbModle='氧化锌硅胶带熔断器' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(blq, 17, 13);
            //绝缘子
            string jyuz = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='绝缘子' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(jyuz, 21, 13);
            jyuz = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='绝缘子'and sbModle='XP-7C' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(jyuz, 22, 13);
            jyuz = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='绝缘子'and sbModle='P-15T' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(jyuz, 23, 13);
            jyuz = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='绝缘子'and sbModle='FSW6-10/70' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(jyuz, 24, 13);
            jyuz = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqsbRowCount", "Where sbType='绝缘子'and sbModle='FPQ2W-10/3T20' and tqID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "'))").ToString();
            ex.SetCellValue(jyuz, 25, 13);

            ex.ShowExcel();
        }
      
    }
}
