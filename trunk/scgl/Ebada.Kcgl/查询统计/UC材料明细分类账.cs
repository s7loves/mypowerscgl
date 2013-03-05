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
        DataTable dt = new DataTable();
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
            gridControl1.DataSource = dt;
            InitGridViewColumns();
        }

        private void InitGridViewColumns()
        {
           
        }

        private void InitDtColumns()
        {
            dt.Columns.Add(new DataColumn("工程类别", typeof(string)));
            dt.Columns.Add(new DataColumn("材料名称", typeof(string)));
            dt.Columns.Add(new DataColumn("规格及型号", typeof(string)));
            dt.Columns.Add(new DataColumn("类型", typeof(string)));//出库、入库
            dt.Columns.Add(new DataColumn("计量单位", typeof(string)));
            dt.Columns.Add(new DataColumn("单价", typeof(float)));
            dt.Columns.Add(new DataColumn("数量", typeof(float)));
            dt.Columns.Add(new DataColumn("合计",typeof(float)));
            dt.Columns.Add(new DataColumn("日期", typeof(DateTime)));
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
            dt.Rows.Clear();
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
                        DataRow dr = dt.NewRow();
                        dr["工程类别"] = kcin.工程类别;
                        dr["材料名称"] = kcin.材料名称;
                        dr["规格及型号"] = kcin.规格及型号;
                        dr["类型"] = "入库";
                        dr["计量单位"] = kcin.计量单位;
                        dr["单价"] = kcin.单价;
                        dr["数量"] = kcin.数量;
                        dr["合计"] = kcin.总计;
                        dr["日期"] = kcin.入库日期;
                        dt.Rows.Add(dr);
                    }
                }
                foreach (kc_出库明细表 kcout in outList)
                {
                    if (dateStr == kcout.出库日期.ToString("yyyy-MM-dd"))
                    {
                        DataRow dr = dt.NewRow();
                        dr["工程类别"] = kcout.工程类别;
                        dr["材料名称"] = kcout.材料名称;
                        dr["规格及型号"] = kcout.规格及型号;
                        dr["类型"] = "出库";
                        dr["计量单位"] = kcout.计量单位;
                        dr["单价"] = kcout.单价;
                        dr["数量"] = kcout.数量;
                        dr["合计"] = kcout.总计;
                        dr["日期"] = kcout.出库日期;
                        dt.Rows.Add(dr);
                    }
                }
                
            }
            gridControl1.DataSource = dt;
            
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
            ExportPDCA.ExportOutInDetail(dt);
        }        
    }
}
