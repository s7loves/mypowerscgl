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

namespace Ebada.Scgl.Gis.Gps
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCgps_carrier : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<gps_carrier> gridViewOperation;

        public delegate void GridviewDoubleClick(object obj, gps_carrier carrier);

        public event GridviewDoubleClick GridDoubleClickEvent;
        public event SendDataEventHandler<gps_carrier> FocusedRowChanged;

        public bool isbarvisible = true;
        
        public UCgps_carrier()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<gps_carrier>(gridControl1, gridView1, barManager1, new frm_carrierEdit());
            gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
            gridViewOperation.AfterAdd += new ObjectEventHandler<gps_carrier>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<gps_carrier>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (GridDoubleClickEvent != null)
                GridDoubleClickEvent(this, gridView1.GetFocusedRow() as gps_carrier);
        }

        void gridViewOperation_AfterEdit(gps_carrier obj)
        {
            gridView1.BestFitColumns();
        }

        void gridViewOperation_AfterAdd(gps_carrier obj)
        {
            gridView1.BestFitColumns();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (!isbarvisible)
                this.bar1.Visible = false;
            if (this.Site != null) return;
        }
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as gps_carrier);
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            RefreshData();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            DevExpress.XtraEditors.Repository.RepositoryItemColorEdit colorEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            gridView1.Columns["color"].ColumnEdit = colorEdit;
            
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData()
        {
            gridViewOperation.RefreshData("");
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<gps_carrier> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
    }
}
