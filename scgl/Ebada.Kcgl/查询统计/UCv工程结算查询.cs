using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Columns;

namespace Ebada.Kcgl {
    [ToolboxItem(false)]
    public partial class UCv工程结算查询 : UserControl {
        public UCv工程结算查询() {
            InitializeComponent();
            gridControl1.DataSource = new List<Model.v工程结算查询>();
            gridControl2.DataSource = new List<Model.v出库汇总表_项目除返库>();
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
            comboBoxEdit4.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select distinct 工程类别 from kc_工程类别"));
            //dateEdit1.EditValue = null;
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            comboBoxEdit4.Properties.NullText = "输入工程类别 查询";

            gridView1.Columns["ID"].Visible = false;
            foreach (GridColumn c in gridView2.Columns) {

                if(c.FieldName.Contains("ID"))c.Visible=false;
            }
            //初始合计列
            this.gridView1.OptionsView.ShowFooter = true;
            gridView1.Columns[Model.v工程结算查询.f_总价].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[Model.v工程结算查询.f_总价].SummaryItem.DisplayFormat = "合计={0}";
            this.gridView2.OptionsView.ShowFooter = true;
            gridView2.Columns[Model.v工程结算查询.f_总价].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns[Model.v工程结算查询.f_总价].SummaryItem.DisplayFormat = "合计={0}";
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //查询 [项目名称], [工程类别], [材料名称], [规格及型号],[计量单位],[计划数量],[到货数量],[差值],[计划日期],[合同到货日期],[供货厂家],[联系人],[联系电话]
            
        }
        private void query() {
            string sql = "where 1=1  ";
            
            if (string.IsNullOrEmpty(comboBoxEdit4.EditValue as string)) {
                Ebada.Client.MsgBox.ShowAskMessageBox("请输入工程类别 查询");
                return;
            }
            if (!string.IsNullOrEmpty(comboBoxEdit4.EditValue as string))
                sql += string.Format(" and 工程类别='{0}'", comboBoxEdit4.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit2.EditValue as string))
                sql+=string.Format("  and 材料名称='{0}'",comboBoxEdit2.EditValue);
            if(!string.IsNullOrEmpty(comboBoxEdit3.EditValue as string))
                sql+=string.Format("  and  规格及型号='{0}'",comboBoxEdit3.EditValue);
            //if (dateEdit1.EditValue!=null)
            //    sql += string.Format("  and  计划日期='{0}'", dateEdit1.EditValue);
            

            IList list = Client.ClientHelper.TransportSqlMap.GetList("Select", "SELECT * FROM v工程结算查询 "+sql);

            gridControl1.DataSource = DataConvert.HashTablesToDataTable(list);

            sql = "where 1=1  ";
            //if (string.IsNullOrEmpty(comboBoxEdit1.EditValue as string)) {
            //    gridControl2.DataSource = null; return;
            //}
            if (!string.IsNullOrEmpty(comboBoxEdit4.EditValue as string))
                sql += string.Format(" and 工程类别='{0}'", comboBoxEdit4.EditValue);
            if (!string.IsNullOrEmpty(comboBoxEdit1.EditValue as string))
                sql += string.Format(" and 工程项目名称='{0}'", comboBoxEdit1.EditValue);
            if (!string.IsNullOrEmpty(comboBoxEdit2.EditValue as string))
                sql += string.Format("  and 材料名称='{0}'", comboBoxEdit2.EditValue);
            if (!string.IsNullOrEmpty(comboBoxEdit3.EditValue as string))
                sql += string.Format("  and  规格及型号='{0}'", comboBoxEdit3.EditValue);

            list = Client.ClientHelper.TransportSqlMap.GetList("Select", "SELECT * FROM v出库汇总表_项目除返库 " + sql);

            gridControl2.DataSource = DataConvert.HashTablesToDataTable(list);
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            query();
        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.EditValue = null;
            if (comboBoxEdit4.EditValue == null)
                return;
            
            comboBoxEdit2.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", string.Format("select distinct 材料名称 from kc_工程计划明细表 where 工程类别='{0}'", comboBoxEdit4.EditValue.ToString())));

        }

        private void comboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit3.EditValue = null;
            comboBoxEdit3.Properties.Items.Clear();
            if (comboBoxEdit1.EditValue == null)
                return;
            if (comboBoxEdit2.EditValue == null)
                return;
            
            comboBoxEdit3.Properties.Items.AddRange(Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", string.Format("select distinct 规格及型号 from kc_工程计划明细表 where 工程类别='{0}' and 材料名称='{1}'", comboBoxEdit4.EditValue.ToString(), comboBoxEdit2.EditValue.ToString())));

        }        
       
    }
}
