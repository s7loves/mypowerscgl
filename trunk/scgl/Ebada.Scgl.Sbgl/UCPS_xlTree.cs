/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-5-23
最后一次修改:2011-5-23
***********************************************/
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
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors.Controls;
using Ebada.Scgl.Core;
using DevExpress.XtraTreeList.Columns;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPS_xlTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<PS_xl> treeViewOperator;
        [Browsable(false)]
        public TreeViewOperation<PS_xl> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        
        public event SendDataEventHandler<PS_xl> FocusedNodeChanged;
        public event SendDataEventHandler<PS_xl> AfterAdd;
        public event SendDataEventHandler<PS_xl> AfterEdit;
        public event SendDataEventHandler<PS_xl> AfterDelete;
        public UCPS_xlTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<PS_xl>(treeList1, barManager1,new frmxlEdit());
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            Init();
        }

        void treeViewOperator_AfterDelete(PS_xl newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(PS_xl newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(PS_xl newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as PS_xl);
        }

        void treeViewOperator_CreatingObject(PS_xl newobj) {
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

        }
        public void Init() {

            treeList1.Columns["OrgCode"].Visible = true;
            treeList1.Columns["LineType"].Visible = false;
            treeList1.Columns["LineNamePath"].Visible = false;
            treeList1.Columns["LineGtbegin"].Visible = false;
            treeList1.Columns["LineGtend"].Visible = false;
            treeList1.Columns["WireLength"].Visible = false;
            treeList1.Columns["TotalLength"].Visible = false;
            treeList1.Columns["ActualLoss"].Visible = false;


            treeList1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.GdsDic;
            treeList1.Columns["OrgCode2"].ColumnEdit = DicTypeHelper.BdsDic;
            treeList1.Columns["Owner"].ColumnEdit = DicTypeHelper.OwnerDic;
            treeList1.Columns["RunState"].ColumnEdit = DicTypeHelper.RunState;
            if (this.Site == null)
                InitData();

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by linetype,linecode");
        }

    }
}
