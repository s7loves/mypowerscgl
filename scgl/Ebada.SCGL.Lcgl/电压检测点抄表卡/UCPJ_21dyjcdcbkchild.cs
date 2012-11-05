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

namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCPJ_21dyjcdcbkchild : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PJ_21dyjcdcbkchild> gridViewOperation;
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                //liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btEdit.Enabled = !value;
                btDelete.Enabled = !value;

            }
        }

        public event SendDataEventHandler<PJ_21dyjcdcbkchild> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        public PJ_21dyjcdcbk ParentObj;
        private string parentID = null;
        private mOrg parentObj;
        private PS_tqbyq _parentobj;
        public UCPJ_21dyjcdcbkchild()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_21dyjcdcbkchild>(gridControl1, gridView1, barManager1, new frm21dyjcdcbkchildEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_21dyjcdcbkchild>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_21dyjcdcbkchild>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_21dyjcdcbkchild>(gridViewOperation_AfterAdd);
            
           
        }


        void gridViewOperation_AfterAdd(PJ_21dyjcdcbkchild obj) {
            RefreshData(" where ParentID='" + ParentID + "' order by month ");
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_21dyjcdcbkchild> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_21dyjcdcbkchild> e) {
            if (parentID == null )
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            try
            {
                InitColumns();//初始列
                InitData();//初始数据
                if (this.Site != null) return;
                btGdsList.Edit = DicTypeHelper.GdsDic;
                gridView1.Columns["bigshowtime"].DisplayFormat.FormatString = "yyyy-MM-dd";
                gridView1.Columns["minshowtime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"; 
                    
                    
            }
            catch 
            {

            }
           
          
        }

       
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_21dyjcdcbkchild);
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
             
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
           
         
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
        public GridViewOperation<PJ_21dyjcdcbkchild> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_21dyjcdcbkchild newobj) {

            if ( parentID == null) {
                return;
            }
            newobj.ParentID = ParentID;
            newobj.month = DateTime.Now.Month;
            newobj.CreateDate = DateTime.Now;
            newobj.CreateMan = MainHelper.User.UserName;

            newobj.bigshowtime = new DateTime(int.Parse(ParentObj.year), DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute,DateTime.Now.Second);
            newobj.minshowtime = newobj.bigshowtime;

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

                if (!string.IsNullOrEmpty(value) ) {
                    RefreshData(" where ParentID='" + ParentID + "' order by month ");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
       

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //if (PSObj!=null&&gridView1.RowCount>0)
            //{
            //     IList<PJ_21dyjcdcbkchild> pjlist=new List<PJ_21dyjcdcbkchild>();
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        pjlist.Add(gridView1.GetRow(i) as PJ_21dyjcdcbkchild);
            //    }
            //    Export14.ExportExcel(PSObj, pjlist);
            //}


        }
        //导出数据

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<PJ_21dyjcdcbkchild> pjlist=new List<PJ_21dyjcdcbkchild>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    pjlist.Add(gridView1.GetRow(i) as PJ_21dyjcdcbkchild);
                }
                
            ExportPJ_21dyjcdcbk ext = new ExportPJ_21dyjcdcbk();
            ext.ExportExcel(pjlist);
        }
    }
}
