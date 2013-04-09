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

namespace Ebada.Scgl.Sbgl
{
    public partial class Ucm_ddczzl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_ddzczl> gridViewOperation;
        public Ucm_ddczzl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_ddzczl>(gridControl1, gridView1, barManager1, false);
           
        }

        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        private void RefreshGridData(string sqlwhere)
        {
            if (string.IsNullOrEmpty(sqlwhere))
            {
                
                sqlwhere = "where 1>0";
            }
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_ddzczl>(sqlwhere);
        }

        private void Ucm_czpdjb_Load(object sender, EventArgs e)
        {
            RefreshGridData("");
            InitGridviewColumn();
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["c3"].Visible = false;

            gridView1.Columns["kssj"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["kssj"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            gridView1.Columns["zzsj"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["zzsj"].DisplayFormat.FormatString = "HH:mm";

        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frm_ddczzl frm = new frm_ddczzl();
            bdjl_ddzczl ddczzl = new bdjl_ddzczl();
            ddczzl.kssj = DateTime.Now.ToString();
            ddczzl.zzsj = DateTime.Now.ToString("HH:mm:ss");
            frm.RowData = ddczzl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_ddzczl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_ddzczl ddczzl = gridView1.GetFocusedRow() as bdjl_ddzczl;
            frm_ddczzl frm = new frm_ddczzl();
            frm.RowData = ddczzl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_ddzczl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_ddzczl ddczzl = gridView1.GetFocusedRow() as bdjl_ddzczl;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_ddzczl>(ddczzl);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

    }
}
