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
    public partial class UCsdxs_jhnr : DevExpress.XtraEditors.XtraUserControl
    {


        public bool issearch = false;
        public bool isqx = false;
        public bool ishidebtAdds = false;
        private GridViewOperation<sd_xsjhnr> gridViewOperation;
        public event SendDataEventHandler<sd_xsjhnr> FocusedRowChanged;
        public UCsdxs_jhnr()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_xsjhnr>(gridControl1, gridView1, barManager1, false);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
           
           
        }
        protected override void OnLoad(EventArgs e) {
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
                //bar1.Visible = false;
                btAdds.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btUpdates.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDeletes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; 
            }
            if (ishidebtAdds)
            {
                btAdds.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_xsjhnr);
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
            RefreshData();
        }
        
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;
            }
            int m = 0;
            this.gridView1.Columns["gtbh"].Caption = "杆塔编号";
            this.gridView1.Columns["gtbh"].VisibleIndex = m++;

            this.gridView1.Columns["flag1"].Caption = "缺陷类别";
            this.gridView1.Columns["flag1"].VisibleIndex = m++;

            this.gridView1.Columns["lng"].Caption = "经度";
            this.gridView1.Columns["lng"].VisibleIndex = m++;

            this.gridView1.Columns["lat"].Caption = "纬度";
            this.gridView1.Columns["lat"].VisibleIndex = m++;

            this.gridView1.Columns["flag2"].Caption = "巡视状态";
            this.gridView1.Columns["flag2"].VisibleIndex = m++;

            this.gridView1.Columns["xssj"].Caption = "巡视时间";
            this.gridView1.Columns["xssj"].VisibleIndex = m++;

            this.gridView1.Columns["qxnr"].Caption = "缺陷内容";
            this.gridView1.Columns["qxnr"].VisibleIndex = m++;
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
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
                if (isqx)
                {
                    RefreshQxData();
                }
                else
                {
                    RefreshData();
                }
                
            }
        }

        public void RefreshData()
        {
            string sql = " where ParentID='"+ParentID+"'";
            gridViewOperation.RefreshData(sql);
        }

        public void RefreshQxData()
        {
            string sql = " where ParentID='" + ParentID + "' and RTrim(Ltrim(qxnr))!=''";
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

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (parentobj == null)
                return;
            frmsd_xsjhnr frm = new frmsd_xsjhnr();
            frm.sdxsjh = parentobj;
            if (frm.ShowDialog() == DialogResult.OK)
            {

                foreach (sd_xsjhnr jhnr in (List<sd_xsjhnr>)frm.RowData)
                {
                    if (Client.ClientHelper.PlatformSqlMap.GetOne<sd_xsjhnr>("where ID='" + jhnr.ID + "'") != null)
                    {
                        Client.ClientHelper.PlatformSqlMap.Delete<sd_xsjhnr>(jhnr);
                    }
                    sd_xsjhnr tempjhnr = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xsjhnr>("where gtbh='" + jhnr.gtbh + "' and parentid='"+parentid+"'");
                    if (tempjhnr != null)
                    {
                        Client.ClientHelper.PlatformSqlMap.Delete<sd_xsjhnr>(tempjhnr);
                    }
                    Client.ClientHelper.PlatformSqlMap.Create<sd_xsjhnr>(jhnr);
                }
                RefreshData();
                
            }
        }

        private void btnDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("数据删除后不能恢复，确定删除吗?") != DialogResult.OK)
                return;
            sd_xsjhnr jhnr = this.gridView1.GetFocusedRow() as sd_xsjhnr;
            Client.ClientHelper.PlatformSqlMap.Delete<sd_xsjhnr>(jhnr);
            RefreshData();
        }

        private void btUpdates_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() == null)
                return;
            sd_xsjhnr jhnr = this.gridView1.GetFocusedRow() as sd_xsjhnr;
            frmsd_xsjhnrEdit frm = new frmsd_xsjhnrEdit();
            frm.RowData = jhnr;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<sd_xsjhnr>(frm.RowData);
                
            }
            RefreshData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }



    }
}
