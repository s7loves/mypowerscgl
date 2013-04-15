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
    public partial class Ucm_sbjxjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_sbjxjl> gridViewOperation;
        private bool issearch = false;
        public Ucm_sbjxjl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_sbjxjl>(gridControl1, gridView1, barManager1, false);
           
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
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_sbjxjl>(sqlwhere);
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
                    Loadlkue();
                }
            }
        }
        private void Loadlkue()
        {
            string sqlsbmc = "select distinct a2 from BD_SBTZ where OrgCode='" + parentID + "' and rtrim(ltrim(a2))!=''";
            IList<string> ls = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlsbmc);
            List<DicType> sbmcList = new List<DicType>();
            foreach (string mc in ls)
            {
                sbmcList.Add(new DicType(mc, mc));
            }
            SetComboBoxData(lkuesbmc, "Value", "Key", "请选择", "设备名称", sbmcList);

        }

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

        private void Ucm_czpdjb_Load(object sender, EventArgs e)
        {
            InitGridviewColumn();
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["lineCode"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
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
            frm_sbjxjl frm = new frm_sbjxjl();
            bdjl_sbjxjl sbjxjl = new bdjl_sbjxjl();
            sbjxjl.OrgCode = parentID;
            sbjxjl.jxrq = DateTime.Now;
            frm.RowData = sbjxjl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_sbjxjl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_sbjxjl czpdjb = gridView1.GetFocusedRow() as bdjl_sbjxjl;
            frm_sbjxjl frm = new frm_sbjxjl();
            frm.RowData = czpdjb;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_sbjxjl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_sbjxjl czpdjb = gridView1.GetFocusedRow() as bdjl_sbjxjl;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_sbjxjl>(czpdjb);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!issearch)
            {
                MsgBox.ShowWarningMessageBox("请先选择一个设备名称!");
                return;
            }
            IList<bdjl_sbjxjl> sbjxList = new List<bdjl_sbjxjl>();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is bdjl_sbjxjl)
                    sbjxList.Add(row as bdjl_sbjxjl);

            }
            ExportBdjl.ExportExcelSbjxjl(sbjxList);
        }

        private void lkuesbmc_EditValueChanged(object sender, EventArgs e)
        {
            string sqlwhere = "";
            if (lkuesbmc.EditValue == null)
            {
                sqlwhere = "where OrgCode='" + parentID + "'";
                issearch = false;
            }
            else
            {
                sqlwhere = "where OrgCode='" + parentID + "' and sbmc='" + lkuesbmc.EditValue.ToString() + "'";

                issearch = true;
            }
            RefreshGridData(sqlwhere);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.lkuesbmc.EditValue = null;
            issearch = false;
            RefreshGridData("");
        }

    }
}
