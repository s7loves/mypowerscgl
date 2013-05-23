using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ebada.Kcgl {
    [ToolboxItem(false)]
    public partial class UCv库存明细表查询 : UserControl {
        public UCv库存明细表查询() {
            InitializeComponent();
            gridControl1.DataSource = new List<Model.v库存明细表>();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            init();
        }
        void init() {
            //初始查询列表
            comboBoxEdit1.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 工程类别 from kc_工程类别"));
            //comboBoxEdit2.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 材料名称 from kc_材料名称表"));
            //comboBoxEdit3.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 规格及型号 from kc_材料名称表"));
            //初始合计列
            this.gridView1.OptionsView.ShowFooter = true;
            gridView1.Columns[Model.v库存明细表.f_总计].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[Model.v库存明细表.f_总计].SummaryItem.DisplayFormat = "合计={0}";
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            
        }
        private void query() {
            string sql = "where 1=1  ";
            if(!string.IsNullOrEmpty(comboBoxEdit1.EditValue as string))
                sql += string.Format(" and 工程类别='{0}'", comboBoxEdit1.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit2.EditValue as string))
                sql+=string.Format("  and 材料名称='{0}'",comboBoxEdit2.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit3.EditValue as string))
                sql+=string.Format("  and  规格及型号='{0}'",comboBoxEdit3.EditValue);
            

            IList list = Client.ClientHelper.TransportSqlMap.GetList("Select", "SELECT * FROM v库存明细表 "+sql);

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
            
            comboBoxEdit2.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", string.Format("select distinct 材料名称 from kc_工程计划明细表 where 工程类别='{0}'", comboBoxEdit1.EditValue.ToString())));

        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit3.EditValue = null;
            comboBoxEdit3.Properties.Items.Clear();
            if (comboBoxEdit1.EditValue == null)
                return;
            if (comboBoxEdit2.EditValue == null)
                return;
            
            comboBoxEdit3.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", string.Format("select distinct 规格及型号 from kc_工程计划明细表 where 工程类别='{0}' and 材料名称='{1}'", comboBoxEdit1.EditValue.ToString(), comboBoxEdit2.EditValue.ToString())));

        }
       
    }
}
