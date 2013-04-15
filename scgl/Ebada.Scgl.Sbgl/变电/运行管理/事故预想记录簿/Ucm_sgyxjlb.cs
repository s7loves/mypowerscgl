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
    public partial class Ucm_sgyxjlb : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_sgyxjlb> gridViewOperation;
        public Ucm_sgyxjlb()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_sgyxjlb>(gridControl1, gridView1, barManager1, false);
           
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
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_sgyxjlb>(sqlwhere);
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
            gridView1.Columns["c1"].VisibleIndex = 0;
            gridView1.Columns["c1"].Caption = "日期";
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["c3"].Visible = false;
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                MsgBox.ShowWarningMessageBox("请先选择一个变电所!");
                return;
            }
            frm_sgyxjlb frm = new frm_sgyxjlb();
            bdjl_sgyxjlb sgyxjlb = new bdjl_sgyxjlb();
            sgyxjlb.OrgCode = parentID;
            sgyxjlb.c1 = DateTime.Now.ToShortDateString();
            frm.RowData = sgyxjlb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_sgyxjlb>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_sgyxjlb sgyxjlb = gridView1.GetFocusedRow() as bdjl_sgyxjlb;
            frm_sgyxjlb frm = new frm_sgyxjlb();
            frm.RowData = sgyxjlb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_sgyxjlb>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_sgyxjlb sgyxjlb = gridView1.GetFocusedRow() as bdjl_sgyxjlb;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_sgyxjlb>(sgyxjlb);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MsgBox.ShowWarningMessageBox("请选择要导出的记录!");
                return;
            }
            IList<bdjl_sgyxjlb> sgyxList = new List<bdjl_sgyxjlb>();
            sgyxList.Add(this.gridView1.GetFocusedRow() as bdjl_sgyxjlb);
            ExportBdjl.ExportExcelSgyxjlb(sgyxList);
        }

    }
}
