using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    [ToolboxItem(false)]
    public partial class UCv工程到货查询 : UserControl {
        public UCv工程到货查询() {
            InitializeComponent();
            gridControl1.DataSource = new List<Model.v工程到货查询表>();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            init();
        }
        void init() {
            //初始查询列表
            comboBoxEdit1.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 工程项目名称 from kc_工程项目"));
            //comboBoxEdit2.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 材料名称 from kc_材料名称表"));
            //comboBoxEdit3.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 规格及型号 from kc_材料名称表"));
            dateEdit1.EditValue = null;
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //查询 [项目名称], [工程类别], [材料名称], [规格及型号],[计量单位],[计划数量],[到货数量],[差值],[计划日期],[合同到货日期],[供货厂家],[联系人],[联系电话]
            
        }
        private void query() {
            string sql = "where 1=1  ";
            if(!string.IsNullOrEmpty(comboBoxEdit1.EditValue as string))
                sql+=string.Format(" and 项目名称='{0}'",comboBoxEdit1.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit2.EditValue as string))
                sql+=string.Format("  and 材料名称='{0}'",comboBoxEdit2.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit3.EditValue as string))
                sql+=string.Format("  and  规格及型号='{0}'",comboBoxEdit3.EditValue);
            if (dateEdit1.EditValue!=null)
                sql += string.Format("  and  计划日期='{0}'", dateEdit1.EditValue);
            

            IList list = Client.ClientHelper.TransportSqlMap.GetList("Select", "SELECT * FROM v工程到货查询表 "+sql);

            gridControl1.DataSource = DataConvert.HashTablesToDataTable(list);
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            query();
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.EditValue = null;
            if (comboBoxEdit1.EditValue == null)
                return;
            
            comboBoxEdit2.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", string.Format("select distinct 材料名称 from kc_工程计划明细表 where 项目名称='{0}'", comboBoxEdit1.EditValue.ToString())));

        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit3.EditValue = null;
            comboBoxEdit3.Properties.Items.Clear();
            if (comboBoxEdit1.EditValue == null)
                return;
            if (comboBoxEdit2.EditValue == null)
                return;
           
            comboBoxEdit3.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", string.Format("select distinct 规格及型号 from kc_工程计划明细表 where 项目名称='{0}' and 材料名称='{1}'", comboBoxEdit1.EditValue.ToString(), comboBoxEdit2.EditValue.ToString())));

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            DataTable dt = gridControl1.DataSource as DataTable;
            if (dt == null)
                return;
            IList<v工程到货查询表> gcdhList = new List<v工程到货查询表>();
            foreach (DataRow dr in dt.Rows)
            {
                v工程到货查询表 gcdh = DataConvert.RowToObject<v工程到货查询表>(dr);
                gcdhList.Add(gcdh);
            }
            ExportExcel.ExportGCDHCX(gcdhList);
        }
       
    }
}
