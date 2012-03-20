using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Ebada.Scgl.Sbgl {
    public partial class UCDeviceTypeTree : UserControl {

        public event SendDataEventHandler<DeviceType> LineSelectionChanged;
        private Dictionary<string, DeviceType> mLines;
        private DataTable mTable;
        public UCDeviceTypeTree() {
            InitializeComponent();
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
                        
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            initTree();
        }
        private void initTable() {
            mTable = new DataTable();
            
        }
        private void initTree() {
            if (mTable == null) initTable();
            
        }
        void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e) {
            
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
           
        }

        
        
    }
}
