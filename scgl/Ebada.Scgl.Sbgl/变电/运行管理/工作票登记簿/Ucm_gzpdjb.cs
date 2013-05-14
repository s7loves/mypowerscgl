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
    [ToolboxItem(false)]
    public partial class Ucm_gzpdjb : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_gzpdjb> gridViewOperation;
        public Ucm_gzpdjb()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_gzpdjb>(gridControl1, gridView1, barManager1, false);
           
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
                if (string.IsNullOrEmpty(parentID))
                    return;
                sqlwhere = "where OrgCode='" + parentID + "'";
            }
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_gzpdjb>(sqlwhere);
        }

        private string parentID;
        private string sql = "";
        public string ParentID { 
            get
            {
                return this.parentID;
            }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    this.parentID = value;
                    sql = "where OrgCode='"+parentID+"'";
                    RefreshGridData(sql);
                }
            }
        }

        private void Ucm_czpdjb_Load(object sender, EventArgs e)
        {
            InitGridviewColumn();
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["c3"].Visible = false;
            gridView1.Columns["gzkssj"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            gridView1.Columns["gzjssj"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            //gridView2.Columns["Date"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                MsgBox.ShowWarningMessageBox("请先选择一个变电所!");
                return;
            }
            frm_gzpdjb frm = new frm_gzpdjb();
            bdjl_gzpdjb gzpdjb = new bdjl_gzpdjb();
            gzpdjb.OrgCode = parentID;
            gzpdjb.gzkssj = DateTime.Now;
            gzpdjb.gzjssj = DateTime.Now;
            try
            {
                gzpdjb.c1 = Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where OrgCode='" + parentID + "'").OrgName;
                frm.RowData = gzpdjb;
            }
            catch
            {
                MsgBox.ShowWarningMessageBox("单位代码错误!");
                return;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_gzpdjb>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_gzpdjb czpdjb = gridView1.GetFocusedRow() as bdjl_gzpdjb;
            frm_gzpdjb frm = new frm_gzpdjb();
            frm.RowData = czpdjb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_gzpdjb>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_gzpdjb czpdjb = gridView1.GetFocusedRow() as bdjl_gzpdjb;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_gzpdjb>(czpdjb);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}
