﻿/**********************************************
系统:企业ERP
模块:供电所维护
作者:Rabbit
创建时间:2011-5-20
最后一次修改:2011-5-20
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Xtgl {
    /// <summary>
    /// 供电所维护
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCmOrgGds : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<mOrg> gridViewOperation;
        
        public event SendDataEventHandler<mOrg> FocusedRowChanged;
        private string parentID;
        public UCmOrgGds() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<mOrg>(gridControl1, gridView1, barManager1);
            
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<mOrg>(treeViewOperator_BeforeInsert);
        }

        void treeViewOperator_BeforeInsert(object render, ObjectOperationEventArgs<mOrg> e) {
            e.Value.OrgID = e.Value.OrgCode;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as mOrg);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            mOrg org = ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>("200");
            if (org == null) {
                org = new mOrg() { OrgCode = "200", OrgID = "200", OrgType = "0", OrgName = "供电所" };
                ClientHelper.PlatformSqlMap.Create<mOrg>(org);
            }
            RefreshData(" where parentid='200'");
            gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            gridView1.Columns["OrgType"].Visible = false;
            gridView1.Columns["ParentID"].Visible = false;
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<mOrg> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(mOrg newobj) {
            newobj.OrgType = "1";
            newobj.ParentID = "200";
            newobj.C1 = "是";
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
            }
        }
    }
}
