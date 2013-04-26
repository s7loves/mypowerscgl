using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using Ebada.Core;
using Ebada.Kcgl.Model;
using Ebada.jhgl;

namespace Ebada.Kcgl
{
    public partial class UC材料明细分类账 : DevExpress.XtraEditors.XtraUserControl
    {
        //list.Sort(delegate(ListItem a, ListItem b) { return string.Compare(a.DisplayMember, b.DisplayMember); });
        List<string> storeList = new List<string>();
        DataTable Initdt = new DataTable();
        DataTable finalTable = new DataTable();
        private string sqlwhere = "";
        public UC材料明细分类账()
        {
            InitializeComponent();
        }

        private void UC材料明细分类账_Load(object sender, EventArgs e)
        {
            repositoryItemComboBox1.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 工程类别 from kc_工程类别"));
            repositoryItemComboBox2.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 材料名称 from kc_材料名称表"));
            repositoryItemComboBox3.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 规格及型号 from kc_材料名称表"));
            InitDtColumns();
            InitFinalColumns();
            gridControl1.DataSource = finalTable;
            
            InitGridViewColumns();
        }

        private void InitFinalColumns()
        {
            finalTable.Columns.Add(new DataColumn("Year",typeof(string)));
            finalTable.Columns.Add(new DataColumn("Month", typeof(string)));
            finalTable.Columns.Add(new DataColumn("Day", typeof(string)));
            finalTable.Columns.Add(new DataColumn("summary", typeof(string)));
            finalTable.Columns.Add(new DataColumn("incount", typeof(float)));
            finalTable.Columns.Add(new DataColumn("inprice", typeof(float)));
            finalTable.Columns.Add(new DataColumn("inmoney", typeof(float)));
            finalTable.Columns.Add(new DataColumn("outcount", typeof(float)));
            finalTable.Columns.Add(new DataColumn("outprice", typeof(float)));
            finalTable.Columns.Add(new DataColumn("outmoney", typeof(float)));
            finalTable.Columns.Add(new DataColumn("stockcount", typeof(float)));
            finalTable.Columns.Add(new DataColumn("stockprice", typeof(float)));
            finalTable.Columns.Add(new DataColumn("stockmoney", typeof(float)));

        }

        private void InitGridViewColumns()
        {
           
        }

        private void InitDtColumns()
        {
            Initdt.Columns.Add(new DataColumn("工程类别", typeof(string)));
            Initdt.Columns.Add(new DataColumn("材料名称", typeof(string)));
            Initdt.Columns.Add(new DataColumn("规格及型号", typeof(string)));
            Initdt.Columns.Add(new DataColumn("类型", typeof(string)));//出库、入库
            Initdt.Columns.Add(new DataColumn("计量单位", typeof(string)));
            Initdt.Columns.Add(new DataColumn("单价", typeof(float)));
            Initdt.Columns.Add(new DataColumn("数量", typeof(float)));
            Initdt.Columns.Add(new DataColumn("合计",typeof(float)));
            Initdt.Columns.Add(new DataColumn("日期", typeof(DateTime)));
        }
        private void InitStoreList()
        {
            //入库明细
            string wherein = "select distinct convert(char(10),入库日期,23) from kc_入库明细表 where 工程类别='"+barEditItem1.EditValue.ToString()+
                "' and 材料名称='" + barEditItem2.EditValue.ToString() + "' and 规格及型号= '" + barEditItem3.EditValue.ToString() +
                "' and year(入库日期)='"+Convert.ToDateTime(barEditItem4.EditValue).Year+"'";
            //出库明细
            string whereout = "select distinct convert(char(10),出库日期,23) from kc_出库明细表 where 工程类别='"+barEditItem1.EditValue.ToString()+
                "' and 材料名称='" + barEditItem2.EditValue.ToString() + "' and 规格及型号='" + barEditItem3.EditValue.ToString() +
                "' and year(出库日期)='"+Convert.ToDateTime(barEditItem4.EditValue).Year+"'";
            //入库时间列表
            IList inList = Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", wherein);
            //出库时间列表
            IList outList = Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", whereout);
            for (int i = 0; i < inList.Count;i++)
            {
                
                if (!storeList.Contains(inList[i].ToString()))
                {
                    storeList.Add(inList[i].ToString());
                }
            }
            for (int i = 0; i < outList.Count;i++)
            {
                if (!storeList.Contains(outList[i].ToString()))
                {
                    storeList.Add(outList[i].ToString());
                }
            }
            storeList.Sort(delegate(string a, string b) { return string.Compare(a, b); });
            InitDtData();
            
        }
        /// <summary>
        /// 更新导出列表
        /// </summary>
        private void InitDtData()
        {
            Initdt.Rows.Clear();
            //入库明细表
            string wherein = " where 工程类别='"+barEditItem1.EditValue.ToString()+
                "' and 材料名称='" + barEditItem2.EditValue.ToString() + "' and 规格及型号= '" + barEditItem3.EditValue.ToString() +
                "' and year(入库日期)='"+Convert.ToDateTime(barEditItem4.EditValue).Year+"'";
            //出库明细表
            string whereout=" where 工程类别='"+barEditItem1.EditValue.ToString()+
                "' and 材料名称='" + barEditItem2.EditValue.ToString() + "' and 规格及型号='" + barEditItem3.EditValue.ToString() +
                "' and year(出库日期)='"+Convert.ToDateTime(barEditItem4.EditValue).Year+"'";
            IList <kc_入库明细表 > inList = Client.ClientHelper.TransportSqlMap.GetListByWhere<kc_入库明细表>(wherein);
            IList<kc_出库明细表> outList =Client.ClientHelper.TransportSqlMap.GetListByWhere<kc_出库明细表>(whereout);
            foreach (string dateStr in storeList)
            {
                foreach (kc_入库明细表 kcin in inList)
                {
                    if (dateStr == kcin.入库日期.ToString("yyyy-MM-dd"))
                    {
                        DataRow dr = Initdt.NewRow();
                        dr["工程类别"] = kcin.工程类别;
                        dr["材料名称"] = kcin.材料名称;
                        dr["规格及型号"] = kcin.规格及型号;
                        dr["类型"] = "入库";
                        dr["计量单位"] = kcin.计量单位;
                        dr["单价"] = kcin.单价;
                        dr["数量"] = kcin.数量;
                        dr["合计"] = kcin.总计;
                        dr["日期"] = kcin.入库日期;
                        Initdt.Rows.Add(dr);
                    }
                }
                foreach (kc_出库明细表 kcout in outList)
                {
                    if (dateStr == kcout.出库日期.ToString("yyyy-MM-dd"))
                    {
                        DataRow dr = Initdt.NewRow();
                        dr["工程类别"] = kcout.工程类别;
                        dr["材料名称"] = kcout.材料名称;
                        dr["规格及型号"] = kcout.规格及型号;
                        dr["类型"] = "出库";
                        dr["计量单位"] = kcout.计量单位;
                        dr["单价"] = kcout.单价;
                        dr["数量"] = kcout.数量;
                        dr["合计"] = kcout.总计;
                        dr["日期"] = kcout.出库日期;
                        Initdt.Rows.Add(dr);
                    }
                }
                
            }
            InitFinalTable();
            
            
        }

        private void InitFinalTable()
        {
            finalTable.Rows.Clear();
            int inCount = 0;
            
            int outCount = 0;
            
            //结存数量
            int stockCount = 0;
            //结存金额
            decimal stockMoney = 0;
            foreach (DataRow rw in Initdt.Rows)
            {
                DataRow finalrow = finalTable.NewRow();
                finalrow["Year"] = Convert.ToDateTime(rw["日期"]).Year.ToString();
                finalrow["Month"] = Convert.ToDateTime(rw["日期"]).Month.ToString();
                finalrow["Day"] = Convert.ToDateTime(rw["日期"]).Day.ToString();
                if (rw["类型"].ToString() == "入库")
                {
                    finalrow["summary"] = "入库";
                    finalrow["inprice"] = Convert.ToDecimal(rw["单价"]);
                    finalrow["stockprice"] = Convert.ToDecimal(rw["单价"]);
                    finalrow["incount"] = Convert.ToInt32(rw["数量"]);
                    inCount = inCount + Convert.ToInt32(rw["数量"]);
                    stockCount = stockCount + inCount;
                    finalrow["stockcount"] = stockCount;
                    finalrow["inmoney"] = Convert.ToInt32(finalrow["incount"]) * Convert.ToDecimal(finalrow["inprice"]);
                    finalrow["stockmoney"] = stockMoney + Convert.ToDecimal(finalrow["inmoney"]);
                    stockMoney = Convert.ToDecimal(finalrow["stockmoney"]);
                    
                }
                else if (rw["类型"].ToString() == "出库")
                {
                    finalrow["summary"] = "出库";
                    finalrow["outprice"] = Convert.ToDecimal(rw["单价"]);
                    finalrow["stockprice"] = Convert.ToDecimal(rw["单价"]);
                    finalrow["outcount"] = Convert.ToInt32(rw["数量"]);
                    outCount = outCount + Convert.ToInt32(rw["数量"]);
                    stockCount = stockCount - outCount;
                    finalrow["stockcount"] = stockCount;
                    finalrow["outmoney"] = Convert.ToInt32(finalrow["outcount"]) * Convert.ToDecimal(finalrow["outprice"]);
                    finalrow["stockmoney"] = stockMoney - Convert.ToDecimal(finalrow["outmoney"]);
                    stockMoney = Convert.ToDecimal(finalrow["stockmoney"]);
                }
                finalTable.Rows.Add(finalrow);
            }
            gridControl1.DataSource = finalTable;
        }

        private bool CheckIsSelectALL()
        {
            bool retbool=true;
            if (barEditItem1.EditValue == null)
            {
                retbool=false;
            }
            if (barEditItem2.EditValue == null)
            {
                retbool = false;
            }
            if (barEditItem3.EditValue == null)
            {
                retbool = false;
            }
            if (barEditItem4.EditValue == null)
            {
                retbool = false;
            }
            
            return retbool;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitStoreList();
        }

        private void btnExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportPDCA.ExportOutInDetail(Initdt);
        }        
    }
}
