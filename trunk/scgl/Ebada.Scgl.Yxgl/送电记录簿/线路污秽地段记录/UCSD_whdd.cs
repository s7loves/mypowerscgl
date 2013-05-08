/**********************************************
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
using Ebada.Scgl.Core;
using DevExpress.XtraEditors.Repository;
using System.Collections;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    
    public partial class UCSD_whdd : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjls_xlwhqd> gridViewOperation;

        public event SendDataEventHandler<sdjls_xlwhqd> FocusedRowChanged;
        public event SendDataEventHandler<sdjls_xlwhqd> btnOkClick;

        private string parentID = null;
        
        public UCSD_whdd()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_xlwhqd>(gridControl1, gridView1, barManager1, new frm_whdd());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjls_xlwhqd>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjls_xlwhqd>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjls_xlwhqd> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjls_xlwhqd> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
        }
        
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
            
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjls_xlwhqd);
        }
        private void hideColumn(string colname) {
            try {
                gridView1.Columns[colname].Visible = false;
            } catch { }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
                string strSQL = "where linecode='"+parentID+"'";
                RefreshData(strSQL);
           
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            //hideColumn("qzrq");

            hideColumn("LineName");
            hideColumn("LineCode");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");

            gridView1.Columns["qdxx"].VisibleIndex = 3;
           
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjls_xlwhqd> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjls_xlwhqd newobj) {
            if (parentID == null) return;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();

            newobj.LineCode = parentID;
            
        }
     
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where LineCode='" +value+"' order by id desc");
                }
            }
        }

        

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (btnOkClick != null)
                btnOkClick(this, gridView1.GetFocusedRow() as sdjls_xlwhqd);
        }
    }
}
