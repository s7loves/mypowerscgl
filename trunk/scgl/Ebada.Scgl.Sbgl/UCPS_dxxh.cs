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
    [ToolboxItem(false)]
    public partial class UCPs_dxxh : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_dxxh> gridViewOperation;
        
        public event SendDataEventHandler<PS_dxxh> FocusedRowChanged;
    
        public UCPs_dxxh() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_dxxh>(gridControl1, gridView1, barManager1,new frmdxxhEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_dxxh>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_dxxh>(gridViewOperation_BeforeDelete);

        }
        

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_dxxh> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_dxxh> e) {
   
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            //InitColumns();//初始列
            InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
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
            RefreshData(" order by dxxh");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            hideColumn("ID");
            
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
        public GridViewOperation<PS_dxxh> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_dxxh newobj) {

        }

        private void btImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string sql = "insert into ps_dxxh(id,dydj,dxxh,dwdz,jmj) select newid(),'',xh ,0.0,0.0 from ps_sbcs where parentid='02001'  and xh not in (select dxxh from ps_dxxh)";

            Client.ClientHelper.PlatformSqlMap.Update("Update", sql);


            RefreshData(" order by dxxh");
        }
 

    }
}
