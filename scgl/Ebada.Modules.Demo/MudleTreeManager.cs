using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Components;
using Ebada.Client;
using Ebada.Platform.Model;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using Ebada.Core;

namespace sample1 {
    public partial class MudleTreeManager : DevExpress.XtraEditors.XtraUserControl {
        private SortableSearchableBindingList<mModule> _BindingList = new SortableSearchableBindingList<mModule>();
        public MudleTreeManager() {
            InitializeComponent();
        }
        public event DevExpress.XtraTreeList.FocusedNodeChangedEventHandler FocusedNodeChanged;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            //bindingSource1.DataSource = _BindingList;
            InitData();
            btAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btAdd_ItemClick);
            treeList1.CellValueChanged += treeList1_CellValueChanged;
            treeList1.AfterDragNode += new DevExpress.XtraTreeList.NodeEventHandler(treeList1_AfterDragNode);
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(sender, e);
        }
        void updateNode(TreeListNode node) {
            mModule obj = treeList1.GetDataRecordByNode(node) as mModule;
            sqlmap.Update<mModule>(obj);
        }
        void treeList1_AfterDragNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e) {
            updateNode(e.Node);
        }
        void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e) {
            updateNode(e.Node);
        }
        
        IBaseSqlMapDao sqlmap = null;
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeList1.DataSource = null;
            _BindingList.Clear();
            if (sqlmap == null)
                sqlmap = ClientServer.GetService<IBaseSqlMapDao>();
            _BindingList.Add(sqlmap.GetList<mModule>("order by parentid,Sequence"));
            treeList1.DataSource = _BindingList;
        }
        void btAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string parentid = "0";
            if (treeList1.Selection.Count > 0) {
                mModule obj0 = treeList1.GetDataRecordByNode(treeList1.Selection[0]) as mModule;
                parentid = obj0.ParentID;
            }
            newModule(parentid);
        }
        mModule newModule(string parentid) {
            mModule obj = new mModule();
            obj.Modu_ID = obj.CreateID();
            obj.ParentID = parentid;
            if (parentid == "0")
                obj.ModuName = "新系统";
            else
                obj.ModuName = "新模块";

            sqlmap.Create<mModule>(obj);
            _BindingList.Add(obj);
            treeList1.SetFocusedNode(treeList1.FindNodeByKeyID(obj.Modu_ID));
            return obj;
        }
        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            InitData();
        }
        private void btDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (treeList1.Selection.Count > 0) {

                mModule obj = treeList1.GetDataRecordByNode(treeList1.Selection[0]) as mModule;
                if (treeList1.Selection[0].HasChildren) {
                    MainHelper.ShowWarningMessageBox("【" + obj.ModuName + "】有子模块，不可删除？");
                    return;
                }
                if (MsgBox.ShowAskMessageBox("是否确认删除 【" + obj.ModuName + "】?") == DialogResult.OK) {
                    sqlmap.DeleteByKey<mModule>(obj.Modu_ID);
                    _BindingList.Remove(obj);
                }
            }
        }
        private void btAdd2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string parentid = "0";
            if (treeList1.Selection.Count > 0) {
                mModule obj0 = treeList1.GetDataRecordByNode(treeList1.Selection[0]) as mModule;
                parentid = obj0.Modu_ID;
            }
            newModule(parentid);
        }

        private void btEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            
        }
    }
}
