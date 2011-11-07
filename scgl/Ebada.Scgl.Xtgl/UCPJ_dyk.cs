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
using DevExpress.XtraBars;

namespace Ebada.Scgl.Xtgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_dyk : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PJ_dyk> gridViewOperation;
        
        public event SendDataEventHandler<PJ_dyk> FocusedRowChanged;
        private string parentID="";
        private PJ_dyk parentObj;
        public UCPJ_dyk() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_dyk>(gridControl1, gridView1, barManager1,new frmdykEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_dyk>(gridViewOperation_BeforeAdd);
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_dyk>(gridViewOperation_AfterAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_dyk>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
           
        }
        private IViewOperation<PJ_dyk> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<PJ_dyk> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    gridView1.Columns["bh"].Caption = "引用编号";
                    gridView1.Columns["zjm"].Caption = "备注";
                    gridViewOperation.EditForm = new PopupFormGridEdit();
                    bar3.Visible = false;
                }
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_dyk> e) {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
        }
        void gridViewOperation_AfterAdd(PJ_dyk obj)
        {
            obj.ID = obj.bh;
            MainHelper.PlatformSqlMap.Update<PJ_dyk>(obj);
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_dyk> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_dyk);
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
            RefreshData(" where parentid=''");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            hideColumn("ParentID");
            if (parentID == "") {
                hideColumn("nr");
                hideColumn("nr2");
                hideColumn("nr3");
                hideColumn("nr4");
            }
            
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
        public GridViewOperation<PJ_dyk> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_dyk newobj) {
            newobj.ParentID = parentID;
            if (parentObj != null) {
                newobj.sx = parentObj.sx;
                newobj.dx = parentObj.dx;
            }
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
        public PJ_dyk ParentObj {
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

        private void barCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmdykCopy frm = new frmdykCopy();
            frm.ParentObj = parentObj;
            frm.ShowDialog();
            RefreshData(" where parentid='" + parentObj.ID + "'");
        }
    }
}
