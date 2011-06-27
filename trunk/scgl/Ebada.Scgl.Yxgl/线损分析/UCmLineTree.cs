/**********************************************
系统:企业ERP
模块:组织机构
作者:Rabbit
创建时间:2011-5-18
最后一次修改:2011-5-19
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

namespace Ebada.Scgl.Yxgl{
    /// <summary>
    /// 组织机构
    /// </summary>
    public partial class UCmLineTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<PS_xl> treeViewOperator;
        [Browsable(false)]
        public TreeViewOperation<PS_xl> TreeViewOperator
        {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        //private IViewOperation<PS_xl> childView;
        ///// <summary>
        ///// 获取和设置子表的数据操作接口
        ///// </summary>
        //[Browsable(false)]
        //public IViewOperation<PS_xl> ChildView
        //{
        //    get { return childView; }
        //    set
        //    {
        //        childView = value;
        //        if (value != null)
        //        {
        //            bar1.Visible = false;
        //            bar3.Visible = false;
        //            foreach (TreeListColumn tc in treeList1.Columns)
        //            {
        //                tc.Visible = false;
        //            }
        //            treeList1.Columns["LineName"].Visible = true;

        //            treeList1.AllowDrop = false;
             
        //            treeList1.ParentFieldName = "";
        //            treeList1.ParentFieldName = "ParentID";
        //            treeList1.KeyFieldName = "LineID";
        //        }
        //    }
        //}
        public event SendDataEventHandler<PS_xl> FocusedNodeChanged;
        public event SendDataEventHandler<PS_xl> AfterAdd;
        public event SendDataEventHandler<PS_xl> AfterEdit;
        public event SendDataEventHandler<PS_xl> AfterDelete;
        public UCmLineTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<PS_xl>(treeList1, barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            //treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            //treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            //treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            
        }

        void treeViewOperator_AfterDelete(PS_xl newobj)
        {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(PS_xl newobj)
        {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(PS_xl newobj)
        {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as PS_xl);
        }

        void treeViewOperator_CreatingObject(PS_xl newobj)
        {
            //newobj.OrgType = "0";
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Init();
        }
        public void Init() {  
            foreach (TreeListColumn tc in treeList1.Columns)
            {
                tc.Visible = false;
            }
            treeList1.Columns["LineName"].Visible = true;
            if (this.Site == null)
                InitData();

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by LineVol,LineName");
        }

    }
}
