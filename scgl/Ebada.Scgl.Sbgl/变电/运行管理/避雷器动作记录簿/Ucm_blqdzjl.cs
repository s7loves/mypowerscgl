﻿using System;
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
    public partial class Ucm_blqdzjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_blqdzjlcs> gridViewOperation;
        public Ucm_blqdzjl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_blqdzjlcs>(gridControl1, gridView1, barManager1, false);
           
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
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_blqdzjlcs>(sqlwhere);
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
            gridView1.BestFitColumns();
            InitGridviewColumn();
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["c1"].VisibleIndex = 4;
            gridView1.Columns["c1"].Caption = "A项累计动作次数";
            gridView1.Columns["c2"].Caption = "B项累计动作次数";
            gridView1.Columns["c2"].VisibleIndex = 6;
            gridView1.Columns["c3"].Caption = "C项累计动作次数";
            gridView1.Columns["c3"].VisibleIndex = 8;
            gridView1.Columns["dzsj"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["dzsj"].DisplayFormat.FormatString = "HH:mm:ss";
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                MsgBox.ShowWarningMessageBox("请先选择一个变电所!");
                return;
            }
            frm_blqdzjl frm = new frm_blqdzjl();
            bdjl_blqdzjlcs blqdzjl = new bdjl_blqdzjlcs();
            blqdzjl.OrgCode = parentID;
            blqdzjl.dzrq = DateTime.Now;
            frm.RowData = blqdzjl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_blqdzjlcs>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_blqdzjlcs bqldzjl = gridView1.GetFocusedRow() as bdjl_blqdzjlcs;
            frm_blqdzjl frm = new frm_blqdzjl();
            frm.RowData = bqldzjl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_blqdzjlcs>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_blqdzjlcs blqtzjl = gridView1.GetFocusedRow() as bdjl_blqdzjlcs;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_blqdzjlcs>(blqtzjl);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<bdjl_blqdzjlcs> blqList = new List<bdjl_blqdzjlcs>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is bdjl_blqdzjlcs)
                {
                    blqList.Add(row as bdjl_blqdzjlcs);
                }
            }
            ExportBdjl.ExportExcelBlqdzjlb(blqList);
        }

    }
}
