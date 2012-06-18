using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ebada.Scgl.Lcgl {
    [ToolboxItem(false)]
    public partial class UCLPRecordtj : UserControl {
        public UCLPRecordtj() {
            InitializeComponent();
            barEditItem1.EditValueChanged += new EventHandler(barEditItem1_EditValueChanged);
        }

        void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            tj();
        }
        void tj() {
            if (string.IsNullOrEmpty(barEditItem1.EditValue.ToString())) return;
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("Select", "exec proc_lptj @year=" + barEditItem1.EditValue);

            gridControl1.DataSource = Ebada.Core.ConvertHelper.ToDataTable(list);
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            initdata();
        }
        void initdata() {
            for(int i=0;i<20;i++){
                repositoryItemComboBox1.Items.Add(2011 + i);
            }
            barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            tj();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (ParentForm != null)
                ParentForm.Close();
        }
        private void export() {

        }
    }
}
