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

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    
    public partial class UCSD_yxfa : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjls_fsgyxfa> gridViewOperation;

        public event SendDataEventHandler<sdjls_fsgyxfa> FocusedRowChanged;
        public event SendDataEventHandler<sdjls_fsgyxfa> btOkClick;
        
        public UCSD_yxfa()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_fsgyxfa>(gridControl1, gridView1, barManager1, new frmyxfa());
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            
        }

       
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjls_fsgyxfa);
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
            //RefreshData("");
            RefreshData("");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            hideColumn("fasj");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
            //this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjls_fsgyxfa> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                sdjls_fsgyxfa OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjls_fsgyxfa;
                if (OBJECT!= null)
                {
                    #region 注释的部分
                    //if (OBJECT.BigData.Length != 0)
                    //{
                    //    DSOFramerControl ds1 = new DSOFramerControl();
                    //    ds1.FileData = OBJECT.BigData;
                    //    string fname = ds1.FileName;
                    //    ds1.FileClose();
                    //    // ds1.FileOpen(ds1.FileName);
                    //    ExcelAccess ex = new ExcelAccess();


                    //    ex.Open(fname);
                    //    //此处写填充内容代码

                    //    ex.ShowExcel();
                    //}
                    //else
                    //{
                    //    Export26.ExportExcel(OBJECT);
                    //}

                    #endregion
                    //ExportSD26.ExportExcel(OBJECT);
                }

            }
        }

        private void btView_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                sdjls_fsgyxfa OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjls_fsgyxfa;
                if (OBJECT != null)
                {
                    #region 注释的部分
                    //if (OBJECT.BigData.Length != 0)
                    //{
                    //    DSOFramerControl ds1 = new DSOFramerControl();
                    //    ds1.FileData = OBJECT.BigData;
                    //    string fname = ds1.FileName;
                    //    ds1.FileClose();
                    //    // ds1.FileOpen(ds1.FileName);
                    //    ExcelAccess ex = new ExcelAccess();


                    //    ex.Open(fname);
                    //    //此处写填充内容代码

                    //    ex.ShowExcel();
                    //}
                    //else
                    //{
                    //    Export26.ExportExcel(OBJECT);
                    //}

                    #endregion
                    //ExportSD26.ExportExcel(OBJECT);
                }
            }
        }

        private void btOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                if (btOkClick != null)
                {
                    btOkClick(this, gridView1.GetFocusedRow() as sdjls_fsgyxfa);
                }
            }
        }
    }
}
