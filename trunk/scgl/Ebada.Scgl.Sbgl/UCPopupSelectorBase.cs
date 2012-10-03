using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraGrid.Columns;
using Ebada.Core;

namespace Ebada.Scgl.Sbgl {
    [ToolboxItem(false)]
    public partial class UCPopupSelectorBase : XtraUserControl {
        public event EventHandler InitColumns;
        //public new string Text=string.Empty;
        public List<string> clist;
        public event EventHandler RowSelected;
        public UCPopupSelectorBase() {
            InitializeComponent();
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowColumnHeaders = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.InvertSelection = true;
            textEdit1.Properties.NullText = "输入 拼音码 查询";
            gridControl1.GetToolTipController().SetToolTip(gridControl1, "双击进行选择");
            clist = new List<string>();
            this.Dock = DockStyle.Fill; gridControl1.MouseDoubleClick += new MouseEventHandler(gridControl1_MouseDoubleClick);
        }
        public string NullText {
            get { return textEdit1.Properties.NullText; }
            set { textEdit1.Properties.NullText = value; }
        }
        void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (RowSelected != null && GetFocusedDataRow() != null) {
                RowSelected(gridView1, null);
            }
        }

        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            
        }

        void gridView1_MouseDown(object sender, MouseEventArgs e) {
            
        }

        void gridControl1_MouseClick(object sender, MouseEventArgs e) {
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            textEdit1.Focus();

            textEdit1.TextChanged += new EventHandler(textEdit1_TextChanged);
        }
        public DataTable DataSource {
            get {
                return gridControl1.DataSource as DataTable;
            }
            set {
                gridControl1.DataSource = value;
                if (InitColumns != null)
                    InitColumns(gridView1, null);
            }
        }
        public void SetColumnsVisible(string c1,params string[] cols){
            foreach (GridColumn item in gridView1.Columns) {
                item.Visible = false;
            }
            try {
                gridView1.Columns[c1].Visible = true;
                foreach (var item in cols) { gridView1.Columns[item].Visible = true; }
            } catch { }
        }
        public DataRow GetFocusedDataRow() {

            return gridView1.GetFocusedDataRow();
        }
        public T GetFocusedRow<T>() {
            return ConvertHelper.RowToObject<T>(GetFocusedDataRow());
        }
        public void SetFilterColumns(string c1, params string[] cols) {
            clist.Clear();
            clist.Add(c1);
            if (cols.Length > 0)
                clist.AddRange(cols);
        }
        string getFilterString() {
            string str = "1=1 ";
            foreach (var item in clist) {
                str += " and  "+item+" like '" + this.Text + "%'";
            }
            return str;
        }
        void textEdit1_TextChanged(object sender, EventArgs e) {
            Text = textEdit1.Text;
            DataSource.DefaultView.RowFilter = getFilterString();
        }
    }
}
