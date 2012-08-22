using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace Ebada.Scgl.Gis.Device {
    public partial class frmTQSelector : frmBaseSelector {
        static DataTable tqTable;//pym内存
        public frmTQSelector() {
            InitializeComponent();
            this.Text = "台区";
            gridControl1.Top += 27;
            gridControl1.Height -= 27;
            this.textEdit1.Properties.NullText = "输入拼音首字母 查询";
        }

        protected override void InitData() {
            this.UseWaitCursor = true;
            if (tqTable == null) {//构建拼音码内存表
                IList list = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>(" order by  tqcode") as IList;

                tqTable = Ebada.Core.ConvertHelper.ToDataTable(list);
                tqTable.Columns.Add("pym", typeof(string));
                foreach (DataRow row in tqTable.Rows) {

                    if (string.IsNullOrEmpty(row["tqName"].ToString())) continue;
                    row["pym"] = Ebada.Scgl.Core.SelectorHelper.GetPysm(row["tqName"].ToString());
                }
            }
            textEdit1.TextChanged += new EventHandler(textEdit1_TextChanged);

            gridControl1.DataSource = tqTable;
            gridView1.Columns["tqName"].Caption = "台区名称";
            gridView1.Columns["tqCode"].Caption = "台区代码";

            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;
            }
            try {
                gridView1.Columns["tqName"].Visible = true;
                gridView1.Columns["tqCode"].Visible = true;
            } catch { }
            this.UseWaitCursor = false;
        }

        void textEdit1_TextChanged(object sender, EventArgs e) {
            if(tqTable!=null)
            tqTable.DefaultView.RowFilter="pym like '%" + textEdit1.Text + "%'";

        }
        public override object GetSelected() {
           DataRow row = gridView1.GetFocusedDataRow();
            PS_tq tq=null;
            if (row != null)
                tq = Ebada.Core.ConvertHelper.RowToObject<PS_tq>(row);

            return tq;
        }
    }
}
