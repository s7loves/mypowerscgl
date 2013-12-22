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

namespace Ebada.Exam {
    /// <summary>
    /// 
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCE_PrizeLeft : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_Prize> gridViewOperation;
        private string parentID = null;
        private E_Prize parentObj;
        public event SendDataEventHandler<E_Prize> FocusedRowChanged;
        public delegate void AfterChexiao();
        public event AfterChexiao afterchexiao;
        public UCE_PrizeLeft()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_Prize>(gridControl1, gridView1, barManager1,new FrmE_PrizeEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_Prize>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_Prize>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += new FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }

        void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            E_Prize p = gridView1.GetFocusedRow() as E_Prize;
            if (p!=null)
            {
                if (p.Price>Eus.CurrtenScore)
                {
                    barButtonItem1.Enabled = false;
                }
                else
                {
                    barButtonItem1.Enabled = true;
                }
            }
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as E_Prize);
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_Prize> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_Prize> e) {
   
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

        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        E_UserScore Eus;
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            Eus = MainHelper.PlatformSqlMap.GetOne<E_UserScore>(" where UserID='" + MainHelper.User.UserID + "'");
            DateTime dt=DateTime.Now;
            string sql = " where CurrentNum>0 and BeginDate<'" + dt + "' and EndDate>'" + dt + "' order by BeginDate desc";
            RefreshData(sql);
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            //hideColumn("ID");
            //gridView1.Columns["Title"].Width = 200;
            //gridView1.Columns["Content"].Width = 500;
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
        public GridViewOperation<E_Prize> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_Prize newobj) {

            try
            {
                newobj.BeginDate = DateTime.Now;
                newobj.EndDate = DateTime.Now.AddMonths(3);
            }
            catch (Exception ee)
            {
                
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                //if (!string.IsNullOrEmpty(value))
                //{
                //    RefreshData(" where ID='" + value + "' order by dxxh");
                //}
                //else
                //{
                //    RefreshData(" where dydj='10' order by dxxh");
                //}
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public E_Prize ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    parentID = null;
                }
                else
                {
                    ParentID = value.ID;
                }
            }
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow()!=null)
            {
                ParentObj = gridView1.GetFocusedRow() as E_Prize;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            E_Prize p = gridView1.GetFocusedRow() as E_Prize;
            if (p!=null)
            {
                FrmE_UUserBuyPrize frm = new FrmE_UUserBuyPrize();
                frm.RowData = p;
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    btRefresh.PerformClick();
                    if (afterchexiao!=null)
                    {
                        afterchexiao();
                    }
                }
            }
        }


       
    }
}
