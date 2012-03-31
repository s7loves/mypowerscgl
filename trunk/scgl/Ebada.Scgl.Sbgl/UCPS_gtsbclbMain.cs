﻿/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
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

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPS_gtsbclbMain : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_gtsbclb> gridViewOperation;
        
        public event SendDataEventHandler<PS_gtsbclb> FocusedRowChanged;
        private string parentID="";
        private PS_gtsbclb parentObj;
        public UCPS_gtsbclbMain()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_gtsbclb>(gridControl1, gridView1, barManager1,new  frmPS_gtsbclbEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_gtsbclb>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_gtsbclb>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<PS_gtsbclb>(gridViewOperation_BeforeInsert);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<PS_gtsbclb> e) {
            //if(string.IsNullOrEmpty(e.Value.xh))
            //    e.Value.ID = e.Value.bh;
        }
        private IViewOperation<PS_gtsbclb> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<PS_gtsbclb> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    bar3.Visible = false;
                }
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_gtsbclb> e) {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_gtsbclb> e) {
            if (parentID == null)
                e.Cancel = true;
            IList<PS_gtsbclb> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                       <PS_gtsbclb>(" where  1=1 and xh='' order by  id desc ");
            
                if (pnumli.Count == 0)
                    e.Value.zlCode = string.Format("{0:D3}", 1);
                else
                {
                    e.Value.zlCode = (Convert.ToDecimal(pnumli[0].zlCode) + 1).ToString("000");

                }
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitData();
            //InitColumns();//初始列
            //InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_gtsbclb);
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            RefreshData(" where xh=''");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码


            hideColumn("ParentID");
            hideColumn("bh");
            hideColumn("mc");
            hideColumn("xh");
            
            
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
        public GridViewOperation<PS_gtsbclb> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_gtsbclb newobj) {
            newobj.ParentID = parentID;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where parentid='"+value+"'");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_gtsbclb ParentObj {
            get { return parentObj; }
            set {
                
                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.ID;
                }
            }
        }
    }
}
