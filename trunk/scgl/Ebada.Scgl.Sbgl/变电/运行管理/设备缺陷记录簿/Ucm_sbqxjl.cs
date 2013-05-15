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
    [ToolboxItem(false)]
    public partial class Ucm_sbqxjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_sbqxjl> gridViewOperation;
        public Ucm_sbqxjl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_sbqxjl>(gridControl1, gridView1, barManager1, false);
           
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
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_sbqxjl>(sqlwhere);
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
            List<DicType> qxlbList = new List<DicType>();
            qxlbList.Add(new DicType("一般", "一般"));
            qxlbList.Add(new DicType("重大", "重大"));
            SetComboBoxData(lkueqxlb, "Value", "Key", "请选择", "缺陷类别", qxlbList);
        }
        //SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["c1"].Caption = "消除日期";
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dte = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            dte.Mask.EditMask = "yyyy-MM-dd";
            dte.Mask.UseMaskAsDisplayFormat = true;
            gridView1.Columns["c1"].ColumnEdit=dte;
            
            gridView1.Columns["c2"].Caption = "消除人";
            gridView1.Columns["c3"].Caption = "验收人";
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                MsgBox.ShowWarningMessageBox("请先选择一个变电所!");
                return;
            }
            frm_sbqxjl frm = new frm_sbqxjl();
            bdjl_sbqxjl sbqxjl = new bdjl_sbqxjl();
            sbqxjl.OrgCode = parentID;
            sbqxjl.fxrq = DateTime.Now;
            sbqxjl.c1 = DateTime.Now.ToShortDateString();
            frm.RowData = sbqxjl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_sbqxjl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_sbqxjl czpdjb = gridView1.GetFocusedRow() as bdjl_sbqxjl;
            frm_sbqxjl frm = new frm_sbqxjl();
            frm.RowData = czpdjb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_sbqxjl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_sbqxjl czpdjb = gridView1.GetFocusedRow() as bdjl_sbqxjl;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_sbqxjl>(czpdjb);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

        private void btnSearchs_Click(object sender, EventArgs e)
        {
            if (this.lkueqxlb.EditValue == null)
                return;
            string sqlwhere = " where qxlb='" + lkueqxlb.EditValue.ToString() + "'";
            RefreshGridData(sqlwhere);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.lkueqxlb.EditValue = null;
            RefreshGridData("");
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<bdjl_sbqxjl> ddList = new List<bdjl_sbqxjl>();// gridView1.DataSource as IList<JH_weekks>;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is bdjl_sbqxjl)
                    ddList.Add(row as bdjl_sbqxjl);
            }
            string title = "";
            if (this.lkueqxlb.EditValue != null)
            {
                title = this.lkueqxlb.EditValue.ToString();
            }
            ExportBdjl.ExportExcelSbqxjl(title, ddList);
        }

    }
}
