﻿/**********************************************
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

namespace Ebada.Scgl.Run{
    /// <summary>
    /// 组织机构
    /// </summary>
    public partial class UCmSystemTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mModule> treeViewOperator;
        [Browsable(false)]
        public TreeViewOperation<mModule> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        private IViewOperation<mModulFun> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<mModulFun> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    bar3.Visible = false;
                }
            }
        }
        public event SendDataEventHandler<mModule> FocusedNodeChanged;
        public event SendDataEventHandler<mModule> AfterAdd;
        public event SendDataEventHandler<mModule> AfterEdit;
        public event SendDataEventHandler<mModule> AfterDelete;
        public UCmSystemTree()
        {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<mModule>(treeList1, barManager1,new frmModuleEdit());
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeViewOperator.BeforeInsert += new ObjectOperationEventHandler<mModule>(treeViewOperator_BeforeInsert);
        }

        void treeViewOperator_BeforeInsert(object render, ObjectOperationEventArgs<mModule> e) {
            List<object> list = new List<object>();
            string parentid = e.Value.Modu_ID;
            list.Add(e.Value);
            //treeViewOperator.BindingList.Add(e.Value);
        }
        private mModulFun createFun(string code, string name,string parentid) {
            mModulFun fun = new mModulFun(); fun.FunID = fun.CreateID();
            fun.FunCode = code;
            fun.FunName = name;
            fun.Modu_ID = parentid;

            return fun;
        }
        void treeViewOperator_AfterDelete(mModule newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(mModule newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(mModule newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as mModule);
        }

        void treeViewOperator_CreatingObject(mModule newobj) {
            newobj.visiableFlag = true;
            newobj.Description = xtdm;
            newobj.ActivityFlag = true;

        }
	public string xtdm="system";
	
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Init();
        }
        public void Init() {

            
            if (this.Site == null)
                InitData();
            this.treeList1.KeyFieldName = "Modu_ID";
            this.treeList1.ParentFieldName = "ParentID";

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData(" where Description='"+xtdm+"' order by parentid,sequence");
        }

    }
}
