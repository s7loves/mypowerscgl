using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using DevExpress.XtraTreeList.Nodes;

namespace Ebada.Scgl.Outer {
    public partial class frmKgjk : FormBase {
        DBATLLibHelper dbhelper;
        public frmKgjk() {
            InitializeComponent();
            dbhelper = new DBATLLibHelper();
            dbhelper.OnDataChanged += new DBATLLib._IDataCommEvents_OnDataChangedEventHandler(RealDB_OnDataChanged);
 
            treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            treeList1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.Editable = false;
        }

        void treeList1_DoubleClick(object sender, EventArgs e) {
            TreeListNode node = treeList1.FocusedNode;
            if (node != null) {
                if (node.Level == 2) {
                    dbhelper.initKgcs(node["id"].ToString(), gridControl1);
                }
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            timer1.Enabled = true;
            Text = "智能开关监控";
        }

        void RealDB_OnDataChanged(int num, string name, object data) {
            BeginInvoke(new DBATLLib._IDataCommEvents_OnDataChangedEventHandler(datachanged), num, name, data);
        }
        void datachanged(int num, string name, object data) {
            if (dbhelper.tagValues.ContainsKey(name)) {
                dbhelper.tagValues[name]["值"] = data.ToString();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e) {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {

        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            dbhelper.initkgtree(treeList1);
            treeList1.ExpandAll();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (dbhelper.IsOpen) {
                toolStripStatusLabel1.Text = "智能开关服务器：" + DBATLLibHelper.dbServer;
            } else {
                toolStripStatusLabel1.Text = "脱机";
            }
        }

    }
}
