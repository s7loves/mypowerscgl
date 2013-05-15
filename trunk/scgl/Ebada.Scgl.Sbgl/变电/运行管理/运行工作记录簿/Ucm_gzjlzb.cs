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
    public partial class Ucm_gzjlzb : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_gzjlzb> gridViewOperation;
        
        public Ucm_gzjlzb()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_gzjlzb>(gridControl1, gridView1, barManager1, false);
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
                sqlwhere = "where ParentID='" + parentID + "'";
            }
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_gzjlzb>(sqlwhere);
            gridView1.BestFitColumns();
        }

        private string parentID;
        private string sql = "";
        public string ParentID { 
            get
            {
                return this.parentID;
            }
            set {
                //if (!string.IsNullOrEmpty(value))
                //{
                    this.parentID = value;
                    sql = "where ParentID='" + parentID + "'";
                    RefreshGridData(sql);
                //}
            }
        }

        private void Ucm_czpdjb_Load(object sender, EventArgs e)
        {
            gridView1.BestFitColumns();
            InitGridviewColumn();
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["c3"].Visible = false;
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dte = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            dte.Mask.EditMask = "HH:mm";
            dte.Mask.UseMaskAsDisplayFormat = true;
            gridView1.Columns["sj"].ColumnEdit = dte;
            
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                MsgBox.ShowWarningMessageBox("请先选择工作记录!");
                return;
            }
            frm_gzjlzb frm = new frm_gzjlzb();
            bdjl_gzjlzb gzjlzb = new bdjl_gzjlzb();
            gzjlzb.ParentID = parentID;
            gzjlzb.sj = DateTime.Now.ToShortDateString();
            frm.RowData = gzjlzb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_gzjlzb>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_gzjlzb gzjlzb = gridView1.GetFocusedRow() as bdjl_gzjlzb;
            frm_gzjlzb frm = new frm_gzjlzb();
            frm.RowData = gzjlzb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_gzjlzb>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_gzjlzb gzjlzb = gridView1.GetFocusedRow() as bdjl_gzjlzb;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_gzjlzb>(gzjlzb);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

    }
}
