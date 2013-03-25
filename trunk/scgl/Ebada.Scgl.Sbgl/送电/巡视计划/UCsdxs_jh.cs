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
namespace Ebada.Scgl.Sbgl
{
    public partial class UCsdxs_jh : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sd_xsjh> gridViewOperation;
        public event SendDataEventHandler<sd_xsjh> FocusedRowChanged;

        private string checkState="";
        public string CheckState
        {
            get
            {
                return this.checkState;
            }
            set
            {
                this.checkState = value;
            }
        }

        public UCsdxs_jh()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_xsjh>(gridControl1, gridView1, barManager1, false);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
           
           
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            InitData();//初始数据
            InitColumns();//初始列
            

        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_xsjh);
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
            this.gridView1.Columns["OrgCode"].Caption = "单位名称";
            this.gridView1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.OrgDic;
            this.gridView1.Columns["OrgCode"].VisibleIndex = m++;

            this.gridView1.Columns["LineName"].Caption = "线路名称";
            this.gridView1.Columns["LineName"].VisibleIndex = m++;

            this.gridView1.Columns["vol"].Caption = "电压等级";
            this.gridView1.Columns["vol"].VisibleIndex = m++;

            this.gridView1.Columns["xslb"].Caption = "巡视类别";
            this.gridView1.Columns["xslb"].VisibleIndex = m++;

            this.gridView1.Columns["xsnr"].Caption = "巡视内容";
            this.gridView1.Columns["xsnr"].VisibleIndex = m++;

            this.gridView1.Columns["sxr"].Caption = "巡视人员";
            this.gridView1.Columns["sxr"].VisibleIndex = m++;

            if (checkState == "01")
            {
                this.gridView1.Columns["jhsj"].Caption = "计划时间";
                this.gridView1.Columns["jhsj"].VisibleIndex = m++;
            }

            this.gridView1.Columns["xskssj"].Caption = "巡视开始时间";
            this.gridView1.Columns["xskssj"].VisibleIndex = m++;

            this.gridView1.Columns["xswcsj"].Caption = "巡视完成时间";
            this.gridView1.Columns["xswcsj"].VisibleIndex = m++;

            this.gridView1.Columns["wcbj"].Caption = "是否完成";
            this.gridView1.Columns["wcbj"].VisibleIndex = m++;

            this.gridView1.Columns["qxnr"].Caption = "缺陷内容";
            this.gridView1.Columns["qxnr"].VisibleIndex = m++;

            this.gridView1.Columns["flag"].Caption = "任务状态";
            this.gridView1.Columns["flag"].VisibleIndex = m++;

            if (checkState == "01")
            {

                this.gridView1.Columns["cjr"].Caption = "创建人";
                this.gridView1.Columns["cjr"].VisibleIndex = m++;

                this.gridView1.Columns["fbr"].Caption = "发布人";
                this.gridView1.Columns["fbr"].VisibleIndex = m++;

                this.gridView1.Columns["fbsj"].Caption = "发布时间";
                this.gridView1.Columns["fbsj"].VisibleIndex = m++;
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshData() {

            string sql = "";
            if (checkState == "01")
            {
                sql = "where wcbj='未完成'";
            }
            else
            {
                sql = "where wcbj='完成'";
            }
            gridViewOperation.RefreshData(sql);
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sd_xsjh xsjh = new sd_xsjh();
            frmsdxs_jh frm = new frmsdxs_jh();
            frm.RowData = xsjh;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<sd_xsjh>(frm.RowData);
                RefreshData();
            }
            
        }

        private void btUpdates_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() == null)
                return;
            sd_xsjh xsjh = gridView1.GetFocusedRow() as sd_xsjh;
            frmsdxs_jh frm = new frmsdxs_jh();
            frm.isupdate = true;
            frm.RowData = xsjh;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<sd_xsjh>(frm.RowData);
                RefreshData();
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() == null)
                return;
            sd_xsjh xsjh = gridView1.GetFocusedRow() as sd_xsjh;
            Client.ClientHelper.PlatformSqlMap.DeleteByWhere<sd_xsjhnr>("where ParentID='" + xsjh.ID + "'");
            Client.ClientHelper.PlatformSqlMap.Delete<sd_xsjh>(xsjh);
            RefreshData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_xsjh);

        }

       
    }
}
