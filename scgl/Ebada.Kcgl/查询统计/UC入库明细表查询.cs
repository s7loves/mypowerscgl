using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ebada.Kcgl {
    public partial class UC入库明细表查询 : UserControl {
        public UC入库明细表查询() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            init();
        }
        void init() {
            //初始查询列表
            comboBoxEdit1.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 工程类别 from kc_工程类别"));
            comboBoxEdit2.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 材料名称 from kc_材料名称表"));
            comboBoxEdit3.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 规格及型号 from kc_材料名称表"));
            dateEdit1.EditValue = null;
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            
        }
        private void query() {
            string sql = "where 1=1  ";
            if(!string.IsNullOrEmpty(comboBoxEdit1.EditValue as string))
                sql+=string.Format(" and 工程类别='{0}'",comboBoxEdit1.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit2.EditValue as string))
                sql+=string.Format("  and 材料名称='{0}'",comboBoxEdit2.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit3.EditValue as string))
                sql+=string.Format("  and  规格及型号='{0}'",comboBoxEdit3.EditValue);
            if (dateEdit1.EditValue!=null)
                sql += string.Format("  and  入库日期='{0}'", dateEdit1.EditValue);


            var list = Client.ClientHelper.TransportSqlMap.GetList<Model.kc_入库明细表>(sql);

            gridControl1.DataSource = list;
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            query();
        }
       
    }
}
