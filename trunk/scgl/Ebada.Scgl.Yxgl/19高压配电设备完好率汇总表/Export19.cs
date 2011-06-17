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
    public class Export19  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_19 objorg)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\19高压配电设备完好率汇总表.xls";

            ex.Open(fname);
            //此处写填充内容代码
            ex.SetCellValue(objorg.OrgName, 4, 2);
            IList<PS_xl> objlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where OrgCode ='" + objorg.OrgCode + "'or OrgCode2='" + objorg.OrgCode + "'and LineType='1'");
            //分页 将要变化的进行分页
            //建立一个求总和的
            PS_xl objz = new PS_xl();
            objlist.Insert(0, objz);
            double xlsum = 0, xl1 = 0, xl2 = 0, xl3 = 0, pdbysum = 0, pdbyts = 0, pdby1 = 0, pdbyts1 = 0, pdby2 = 0, pdbyts2 = 0, pdby3 = 0, pdbyts3 = 0, pdssum = 0, pdstssum = 0, pds1 = 0, pdsts1 = 0, pds2 = 0, pdsts2 = 0, pds3 = 0, pdsts3 = 0;
            double zskgsum = 0, zskg1 = 0, zskg2 = 0, zskg3 = 0;
            int pageindex = 1;
            //杆塔搜索语句
            
           
            if (pageindex < Ecommon.GetPagecount(objlist.Count, 13))
            {
                pageindex = Ecommon.GetPagecount(objlist.Count, 13);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
            }
            ex.ShowExcel();
            for (int j = 1; j <= pageindex; j++)
            {

                ex.ActiveSheet(j);

                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 13 + 1;
                int endrow = j * 13;
                if (objlist.Count > endrow)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        PS_xl obj=objlist[starow - 1 + i];
                        
                        if (j==1&&i==0)
                        {
                            //合计的先跳过
                            continue;
                        }
                        //
                        ex.SetCellValue(obj.LineName,8+i,1);
                        //配电线路
                        string gtcon = "gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "')";
                        string length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')").ToString();
                        string tqcon = "tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))";
                        ex.SetCellValue(length,8+i,2);
                        xlsum += Convert.ToDouble(length);
                        length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "') and LineType='1'").ToString();
                        ex.SetCellValue(length,8+i,3);
                        xl1 += Convert.ToDouble(length);
                        length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')and LineType='2'").ToString();
                        ex.SetCellValue(length,8+i,4);
                        xl2 += Convert.ToDouble(length);
                        length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')and LineType='3'").ToString();
                        ex.SetCellValue(length,8+i,5);
                        xl3 += Convert.ToDouble(length);
                        ex.SetCellValue("100%",8+i,6);
                        //配电变压器
                        string rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and" + tqcon).ToString();
                        string ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,7);
                        pdbysum += Convert.ToDouble(rl);
                        pdbyts += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and byqState='1'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and byqState='1'" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,8);
                        pdby1 += Convert.ToDouble(rl);
                        pdbyts1+= Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and byqState='2'" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and byqState='2'" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,9);
                        pdby2 += Convert.ToDouble(rl);
                        pdbyts2 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and byqState='3'" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and byqState='3'" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,10);
                        pdby3 += Convert.ToDouble(rl);
                        pdbyts3 += Convert.ToDouble(ts);
                         ex.SetCellValue("100%",8+i,11);
                        //配电站
                         rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'orbyqModle='配电亭' and" + tqcon).ToString();
                         ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'orbyqModle='配电亭'and" + tqcon).ToString();
                        pdssum += Convert.ToDouble(rl);
                        pdstssum += Convert.ToDouble(ts);
                        ex.SetCellValue(rl+"/"+ts,8+i,12);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'or byqModle='配电亭' and byqState='1'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'or byqModle='配电亭' and byqState='1'and" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,13);
                        pds1 += Convert.ToDouble(rl);
                        pdsts1 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'or byqModle='配电亭' and byqState='2'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'or byqModle='配电亭' and byqState='2'and" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,14);
                        pds2 += Convert.ToDouble(rl);
                        pdsts2 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'or byqModle='配电亭' and byqState='3'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'or byqModle='配电亭' and byqState='3'and" + tqcon).ToString();
                        ex.SetCellValue(rl+"/"+ts,8+i,15);
                        pds3 += Convert.ToDouble(rl);
                        pdsts3 += Convert.ToDouble(ts);
                         ex.SetCellValue("100%",8+i,16);
                        //柱上开关
                         string kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where" + gtcon).ToString();
                          ex.SetCellValue(kg, 8 + i, 17);
                          zskgsum += Convert.ToDouble(kg);
                          kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgVol='1'and" + gtcon).ToString();
                          ex.SetCellValue(kg, 8 + i, 18);
                          zskg1 += Convert.ToDouble(kg);
                          kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgVol='2'and" + gtcon).ToString();
                          ex.SetCellValue(kg, 8 + i, 19);
                          zskg2 += Convert.ToDouble(kg);
                          kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgVol='3'and" + gtcon).ToString();
                          ex.SetCellValue(kg, 8 + i, 20);
                          zskg3 += Convert.ToDouble(kg);
                          ex.SetCellValue("100%", 8 + i, 21);
                       



                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        PS_xl obj = objlist[starow - 1 + i];
                        if (j == 1 && i == 0)
                        {
                            //合计的先跳过
                            continue;
                        }
                        //
                        ex.SetCellValue(obj.LineName, 8 + i, 1);
                        //配电线路
                        string length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')").ToString();
                        string gtcon = "gtID in(select gtID from ps_gt WHERE LineCode IN (SELECT lineid from ps_xl where lineid='" + obj.LineCode + "'or ParentID='" + obj.LineCode + "')";
                        string tqcon = "tqID in (select tqID from ps_tq where xlCode ='" + obj.LineCode + "'or xlCode2 in(select lineid from ps_xl where ParentID='" + obj.LineCode + "'))";
                        ex.SetCellValue(length, 8 + i, 2);
                        xlsum += Convert.ToDouble(length);
                        length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "') and LineType='1'").ToString();
                        ex.SetCellValue(length, 8 + i, 3);
                        xl1 += Convert.ToDouble(length);
                        length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')and LineType='2'").ToString();
                        ex.SetCellValue(length, 8 + i, 4);
                        xl2 += Convert.ToDouble(length);
                        length = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_xllength", "where LineID='" + obj.LineCode + "'or(ParentID='" + obj.LineCode + "')and LineType='3'").ToString();
                        ex.SetCellValue(length, 8 + i, 5);
                        xl3 += Convert.ToDouble(length);
                        ex.SetCellValue("100%", 8 + i, 6);
                        //配电变压器
                        string rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and" + tqcon).ToString();
                        string ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 7);
                        pdbysum += Convert.ToDouble(rl);
                        pdbyts += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and byqState='1'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and byqState='1'" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 8);
                        pdby1 += Convert.ToDouble(rl);
                        pdbyts1 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and byqState='2'" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and byqState='2'" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 9);
                        pdby2 += Convert.ToDouble(rl);
                        pdbyts2 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='变台'and byqState='3'" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='变台'and byqState='3'" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 10);
                        pdby3 += Convert.ToDouble(rl);
                        pdbyts3 += Convert.ToDouble(ts);
                        ex.SetCellValue("100%", 8 + i, 11);
                        //配电站
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'orbyqModle='配电亭' and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'orbyqModle='配电亭'and" + tqcon).ToString();
                        pdssum += Convert.ToDouble(rl);
                        pdstssum += Convert.ToDouble(ts);
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 12);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'or byqModle='配电亭' and byqState='1'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'or byqModle='配电亭' and byqState='1'and" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 13);
                        pds1 += Convert.ToDouble(rl);
                        pdsts1 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'or byqModle='配电亭' and byqState='2'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'or byqModle='配电亭' and byqState='2'and" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 14);
                        pds2 += Convert.ToDouble(rl);
                        pdsts2 += Convert.ToDouble(ts);
                        rl = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqbyqCapcity", "Where byqModle='配电站'or byqModle='配电亭' and byqState='3'and" + tqcon).ToString();
                        ts = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_tqbyqRowCount", "Where byqModle='配电站'or byqModle='配电亭' and byqState='3'and" + tqcon).ToString();
                        ex.SetCellValue(rl + "/" + ts, 8 + i, 15);
                        pds3 += Convert.ToDouble(rl);
                        pdsts3 += Convert.ToDouble(ts);
                        ex.SetCellValue("100%", 8 + i, 16);
                        //柱上开关
                        string kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where" + gtcon).ToString();
                        ex.SetCellValue(kg, 8 + i, 17);
                        zskgsum += Convert.ToDouble(kg);
                        kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgVol='1'and" + gtcon).ToString();
                        ex.SetCellValue(kg, 8 + i, 18);
                        zskg1 += Convert.ToDouble(kg);
                        kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgVol='2'and" + gtcon).ToString();
                        ex.SetCellValue(kg, 8 + i, 19);
                        zskg2 += Convert.ToDouble(kg);
                        kg = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_kgRowCount", "Where kgVol='3'and" + gtcon).ToString();
                        ex.SetCellValue(kg, 8 + i, 20);
                        zskg3 += Convert.ToDouble(kg);
                        ex.SetCellValue("100%", 8 + i, 21);
                       

                    }
                }
            }
            ex.ActiveSheet(1);
            //合计
            //配电线路
            ex.SetCellValue(xlsum.ToString(), 8, 2);
            ex.SetCellValue(xl1.ToString(), 8, 3);
            ex.SetCellValue(xl2.ToString(), 8, 4);
            ex.SetCellValue(xl3.ToString(), 8, 5);
            ex.SetCellValue("100%",8,6);
            //配电变压器
            ex.SetCellValue(pdbysum.ToString() + "/" + pdbyts.ToString(), 8, 7);
            ex.SetCellValue(pdby1.ToString() + "/" + pdbyts1.ToString(), 8, 8);
            ex.SetCellValue(pdby2.ToString() + "/" + pdbyts2.ToString(), 8, 9);
            ex.SetCellValue(pdby3.ToString() + "/" + pdbyts3.ToString(), 8,10);
            ex.SetCellValue("100%", 8, 11);
            //变台边亭
            ex.SetCellValue(pdssum.ToString() + "/" + pdstssum.ToString(), 8, 12);
            ex.SetCellValue(pds1.ToString() + "/" + pdsts1.ToString(), 8, 13);
            ex.SetCellValue(pds2.ToString() + "/" + pdsts2.ToString(), 8, 14);
            ex.SetCellValue(pds3.ToString() + "/" + pdsts3.ToString(), 8, 15);
            ex.SetCellValue("100%", 8, 16);
            //开关
            ex.SetCellValue(zskgsum.ToString(), 8, 17);
            ex.SetCellValue(zskg1.ToString(), 8, 18);
            ex.SetCellValue(zskg2.ToString(), 8, 19);
            ex.SetCellValue(zskg3.ToString(), 8, 20);
            ex.SetCellValue("100%", 8, 21);
            //在此处得到合计的内容
           ex.ShowExcel();
        }
      
    }
}
