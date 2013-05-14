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
using System.Data.SqlClient;
using System.Threading;

namespace Ebada.Scgl.Sbgl
{
    public partial class UCsd_xsxm : DevExpress.XtraEditors.XtraUserControl
    {


        public bool issearch = false;
        private GridViewOperation<sd_xsxm> gridViewOperation;
        public event SendDataEventHandler<sd_xsxm> FocusedRowChanged;
        public UCsd_xsxm()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_xsxm>(gridControl1, gridView1, barManager1, false);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;


        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            InitData();//初始数据
            InitColumns();//初始列
            InitBar();

        }

        private void InitBar()
        {
            if (issearch)
            {
                bar1.Visible = false;
            }
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_xsxm);
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
            foreach (GridColumn c in gridView1.Columns)
            {
                c.Visible = false;
            }
            int m = 0;
            this.gridView1.Columns["zl"].Caption = "项目种类";
            this.gridView1.Columns["zl"].VisibleIndex = m++;

            this.gridView1.Columns["mc"].Caption = "项目内容";
            this.gridView1.Columns["mc"].VisibleIndex = m++;

            this.gridView1.Columns["flag"].Caption = "巡视状况";
            this.gridView1.Columns["flag"].VisibleIndex = m++;

            this.gridView1.Columns["xssj"].Caption = "巡视时间";
            this.gridView1.Columns["xssj"].VisibleIndex = m++;

            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
        }




        private string parentid;
        private string ParentID
        {
            get
            {
                return parentid;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                parentid = value;
                RefreshData();
            }
        }

        public void RefreshData()
        {
            string sql = " where ParentID='" + ParentID + "'";
            gridViewOperation.RefreshData(sql);
        }

        private sd_xsjh parentobj;
        public sd_xsjh ParentObj
        {
            get
            {
                return parentobj;
            }
            set
            {
               
                this.parentobj = value;
                if (value == null)
                    return;
                this.ParentID = value.ID;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentid))
                return;
            if (parentobj == null)
                return;
            frmsd_xsxm frm = new frmsd_xsxm();
            sd_xsxm sdxsxm = new sd_xsxm();
            sdxsxm.ParentID = parentid;
            frm.RowData = sdxsxm;
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<sd_xsxm>(frm.RowData);
                RefreshData();
            }
        }

        private void btUpdates_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() == null)
                return;
            sd_xsxm xsxm = this.gridView1.GetFocusedRow() as sd_xsxm;
            
            frmsd_xsxm frm = new frmsd_xsxm();
            frm.isupdate = true;
            frm.RowData = xsxm;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<sd_xsxm>(frm.RowData);
                RefreshData();
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("数据删除后不能恢复，确定删除吗?") != DialogResult.OK)
                return;
            sd_xsxm xsxm = this.gridView1.GetFocusedRow() as sd_xsxm;
            Client.ClientHelper.PlatformSqlMap.Delete<sd_xsxm>(xsxm);
            RefreshData();
        }

       



    }
}
