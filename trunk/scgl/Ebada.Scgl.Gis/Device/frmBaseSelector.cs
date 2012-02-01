using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Gis.Device {
    public partial class frmBaseSelector : XtraForm {
        public frmBaseSelector() {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            InitColumns();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Application.DoEvents();
            InitData();
        }
        protected virtual void simpleButton1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
        protected virtual void simpleButton2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void InitData(){

        }
        protected virtual void InitColumns() {

        }
        public virtual object GetSelected() {

            return gridView1.GetFocusedRow();
        }
    }
}
