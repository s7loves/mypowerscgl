using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using System.Collections;

namespace Ebada.Scgl.Core
{
    public class LineLossHelper
    {
        public static List<PS_xl> GetChildrenList(string id)
        {
            List<PS_xl> list = new List<PS_xl>();
            IList<PS_xl> list1 = new List<PS_xl>();
            list1 = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("SelectPS_xlList"," where ParentID = '" + id + "'");
            list.AddRange(list1);
            foreach (PS_xl xl in list1)
            {
                list.AddRange(GetChildrenList(xl.LineID));
            }
            return list;
        }
        public static decimal Loss(PS_xl line)
        {
            decimal loss = 0;
            loss = LineLoss(line) + ByqLoss(line);
            return loss;
        }
        public static decimal LineLoss(PS_xl line)
        {
            decimal lineLoss = (LineR(line) + ByqR(line)) * line.K * line.K * (line.LineP * line.LineP + line.LineQ * line.LineQ) / (Convert.ToDecimal(line.LineVol) * Convert.ToDecimal(line.LineVol));
            return lineLoss;
        }
        public static decimal ByqLoss(PS_xl line)
        {
            decimal byqloss = 0;
            IList<PS_gt> listGT = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList", "where LineCode ='" + line.LineCode + "'");

            byqloss = ByqP0(listGT);
            return byqloss;
        }
        public static decimal LineR(PS_xl line)
        {
            decimal lineloss = 0;
            IList<PS_gt> listGT = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList","where LineCode ='" + line.LineCode + "'");
            IList<PS_dxxh> listxh = Client.ClientHelper.PlatformSqlMap.GetList<PS_dxxh>("SelectPS_dxxhList", "where dydj = '" + line.LineVol + "' and dxxh = '" + line.WireType + "'");
            if (listxh.Count<=0)
            {
                return 0;
            }
            PS_dxxh xh = listxh[0];
            IList<PS_gt> listGTAfterRemove = listGT;
            decimal capSum = ByqCapcity(listGT);
            foreach (PS_gt gt in listGT)
            {
                decimal cap = ByqCapcity(listGTAfterRemove);
                lineloss += xh.dwdz * gt.gtSpan * cap * cap;
                listGTAfterRemove.Remove(gt);
            }
            return lineloss/(capSum*capSum);
        }
        public static decimal ByqR(PS_xl line)
        {
            decimal byqloss = 0;
            IList<PS_gt> listGT = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList", "where LineCode ='" + line.LineCode + "'");
            decimal cap = ByqCapcity(listGT);
            byqloss = Convert.ToDecimal(line.LineVol) * Convert.ToDecimal(line.LineVol) * ByqPk(listGT) / (cap * cap);
            return byqloss;
        }
        public static decimal ByqCapcity(PS_gt gt)
        {
            decimal byqCap = 0;
            IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_tqList", "where gtID = '" + gt.gtID + "'");
            foreach (PS_tq tq in listTQ)
            {
                IList<PS_tqbyq> listTQBYQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("SelectPS_tqbyqList", "where tqID = '" + tq.tqID + "'");
                foreach (PS_tqbyq tqbyq in listTQBYQ)
                {
                    byqCap += tqbyq.byqCapcity;
                }
            }
            return byqCap;
        }
        public static decimal ByqCapcity(IList<PS_gt> listgt)
        {
            decimal byqCap = 0;
            foreach (PS_gt gt in listgt)
            {
                IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_tqList", "where gtID = '" + gt.gtID + "'");
                foreach (PS_tq tq in listTQ)
                {
                    IList<PS_tqbyq> listTQBYQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("SelectPS_tqbyqList", "where tqID = '" + tq.tqID + "'");
                    foreach (PS_tqbyq tqbyq in listTQBYQ)
                    {
                        byqCap += tqbyq.byqCapcity;
                    }
                }
            }
            return byqCap;
        }
        public static decimal ByqPk(IList<PS_gt> listgt)//短路损耗
        {
            decimal byqpk = 0;
            foreach (PS_gt gt in listgt)
            {
                IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_tqList", "where gtID = '" + gt.gtID + "'");
                foreach (PS_tq tq in listTQ)
                {
                    IList<PS_tqbyq> listTQBYQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("SelectPS_tqbyqList", "where tqID = '" + tq.tqID + "'");
                    foreach (PS_tqbyq tqbyq in listTQBYQ)
                    {
                        IList<PS_byqxh> listByqxh = Client.ClientHelper.PlatformSqlMap.GetList<PS_byqxh>("SelectPS_byqxhList","where byqModel = '" +tqbyq.byqModle +"' and byqVol = '" + tqbyq.byqVol +"'");
                        if (listByqxh.Count>0)
                        {
                            byqpk += (listByqxh[0] as PS_byqxh).Loss1;
                        }
                    }
                }
            }
            return byqpk;
        }
        public static decimal ByqP0(IList<PS_gt> listgt)
        {
            decimal byqpk = 0;
            foreach (PS_gt gt in listgt)
            {
                IList<PS_tq> listTQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("SelectPS_tqList", "where gtID = '" + gt.gtID + "'");
                foreach (PS_tq tq in listTQ)
                {
                    IList<PS_tqbyq> listTQBYQ = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("SelectPS_tqbyqList", "where tqID = '" + tq.tqID + "'");
                    foreach (PS_tqbyq tqbyq in listTQBYQ)
                    {
                        IList<PS_byqxh> listByqxh = Client.ClientHelper.PlatformSqlMap.GetList<PS_byqxh>("SelectPS_byqxhList", "where byqModel = '" + tqbyq.byqModle + "' and byqVol = '" + tqbyq.byqVol + "'");
                        if (listByqxh.Count > 0)
                        {
                            byqpk += (listByqxh[0] as PS_byqxh).Loss2;
                        }
                    }
                }
            }
            return byqpk;
        }
    }
}
