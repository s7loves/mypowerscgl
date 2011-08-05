using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using System.Collections;

namespace Ebada.Scgl.Core
{
    public class LineAnaly
    {     
        
        private decimal lossRate=0;//线损率
        private decimal economyLossRate=0;//经济线损率
        private decimal economyI=0;//线路的经济负荷电流
        private decimal economyByqLoad=0;//变压器经济综合平均负荷
        private decimal fixLossWeight=0;//线路的固定损耗所站比重
        private decimal variableLossWeight=0;// 线路的可变损耗所站比重
        public LineAnaly()
        {

        }
        public LineAnaly(decimal loss,decimal rate,decimal i,decimal load,decimal lossweight,decimal variableweight)
        {
            lossRate = loss;
            economyLossRate = rate;
            economyI = i;
            economyByqLoad = load;
            fixLossWeight = lossweight;
            variableLossWeight = variableweight;
        }
        public decimal LossRate
        {
            get { return lossRate; }
            set { lossRate = value; }
        }
        public decimal EconomyLossRate
        {
            get { return economyLossRate; }
            set { economyLossRate = value; }
        }
        public decimal EconomyI
        {
            get { return economyI; }
            set { economyI = value; }
        }
        public decimal EconomyByqLoad
        {
            get { return economyByqLoad; }
            set { economyByqLoad = value; }
        }
        public decimal FixLossWeight
        {
            get { return fixLossWeight; }
            set { fixLossWeight = value; }
        }
        public decimal VariableLossWeight
        {
            get { return variableLossWeight; }
            set { variableLossWeight = value; }
        }
    }
    public class LineLossHelper
    {
        public static LineAnaly LineLossAnaly(PS_xl line)
        {
            LineAnaly lineAnaly = new LineAnaly();
            lineAnaly.LossRate = line.TheoryLoss / (line.LineP==Convert.ToDecimal(0)?Convert.ToDecimal(1):line.LineP);
            lineAnaly.EconomyLossRate = 2 * line.K * ((decimal)Math.Pow((double)(LineR(line) + ByqR(line)), 0.5)) / (Convert.ToDecimal(line.LineVol) * line.LineP / (decimal)(Math.Pow((double)(line.LineP * line.LineP + line.LineQ * line.LineQ), 0.5) * 1000));
            lineAnaly.EconomyI = (decimal)Math.Pow((double)(ByqP0(line)/(3*line.K*(LineR(line) + ByqR(line)))),0.5);
            lineAnaly.EconomyByqLoad = (decimal)Math.Pow((double)(ByqP0(line) / ( (LineR(line) + ByqR(line)))), 0.5);
            return lineAnaly;
        }
        /// <summary>
        /// 所有子线路
        /// </summary>
        /// <param name="id">线路父ID</param>
        /// <returns>指定ID的所有子线路集合</returns>
        public static List<PS_xl> GetChildrenList(string id)//所有子线路
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
        /// <summary>
        /// 线路线损
        /// </summary>
        /// <param name="line">线路</param>
        /// <returns>输入线路的线损</returns>
        public static decimal Loss(PS_xl line)//线损
        {
            decimal loss = 0;
            loss = LineLoss(line) + ByqLoss(line);
            return loss;
        }
        /// <summary>
        /// 线路可变损耗
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static decimal LineLoss(PS_xl line)//线路可变损耗
        {
            decimal lineLoss = (LineR(line) + ByqR(line)) * line.K * line.K * (line.LineP * line.LineP + line.LineQ * line.LineQ) / (Convert.ToDecimal(line.LineVol) * Convert.ToDecimal(line.LineVol));
            return lineLoss;
        }
        /// <summary>
        /// 线路变压器固定损耗
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static decimal ByqLoss(PS_xl line)//变压器固定损耗
        {
            decimal byqloss = 0;
            IList<PS_gt> listGT = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList", "where LineCode ='" + line.LineCode + "'");

            byqloss = ByqP0(listGT);
            return byqloss;
        }
        /// <summary>
        /// 线路等值电阻
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static decimal LineR(PS_xl line)//线路等值电阻
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
        /// <summary>
        /// 变压器等值电阻
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static decimal ByqR(PS_xl line)//变压器等值电阻
        {
            decimal byqloss = 0;
            IList<PS_gt> listGT = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList", "where LineCode ='" + line.LineCode + "'");
            decimal cap = ByqCapcity(listGT);
            byqloss = Convert.ToDecimal(line.LineVol) * Convert.ToDecimal(line.LineVol) * ByqPk(listGT) / (cap * cap);
            return byqloss;
        }
        /// <summary>
        /// 杆塔变压器容量
        /// </summary>
        /// <param name="gt"></param>
        /// <returns></returns>
        public static decimal ByqCapcity(PS_gt gt)//变压器容量
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
        /// <summary>
        /// 杆塔集合的变压器容量
        /// </summary>
        /// <param name="listgt"></param>
        /// <returns></returns>
        public static decimal ByqCapcity(IList<PS_gt> listgt)//变压器容量
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
        /// <summary>
        /// 杆塔集合的变压器短路损耗
        /// </summary>
        /// <param name="listgt"></param>
        /// <returns></returns>
        public static decimal ByqPk(IList<PS_gt> listgt)//变压器短路损耗
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
        /// <summary>
        /// 杆塔集合的变压器开路损耗
        /// </summary>
        /// <param name="listgt"></param>
        /// <returns></returns>
        public static decimal ByqP0(IList<PS_gt> listgt)//变压器开路损耗
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
        /// <summary>
        /// 线路的变压器开路损耗
        /// </summary>
        /// <param name="listgt"></param>
        /// <returns></returns>
        public static decimal ByqP0(PS_xl line)//变压器开路损耗
        {
            IList<PS_gt> listGT = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList", "where LineCode ='" + line.LineCode + "'");
            decimal byqpk = 0;
            byqpk = ByqP0(listGT);
            return byqpk;
        }
    }
}
