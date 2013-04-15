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
    public partial class Ucm_jdbhjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_jdbhjl> gridViewOperation;
        private bool issearch = false;
        public Ucm_jdbhjl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_jdbhjl>(gridControl1, gridView1, barManager1, false);
           
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
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_jdbhjl>(sqlwhere);
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

        private void Ucm_czpdjb_Load(object sender, EventArgs e)
        {
            InitGridviewColumn();
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

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["lineCode"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["c3"].Visible = false;
            //gridView1.Columns["dzsj"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //gridView1.Columns["dzsj"].DisplayFormat.FormatString = "HH:mm:ss";
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                MsgBox.ShowWarningMessageBox("请先选择一个变电所!");
                return;
            }
            frm_jdbhjl frm = new frm_jdbhjl();
            bdjl_jdbhjl jdbhjl = new bdjl_jdbhjl();
            jdbhjl.OrgCode = parentID;
            jdbhjl.rq = DateTime.Now; 
            frm.RowData = jdbhjl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<bdjl_jdbhjl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btEdits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_jdbhjl jdbhjl = gridView1.GetFocusedRow() as bdjl_jdbhjl;
            frm_jdbhjl frm = new frm_jdbhjl();
            frm.RowData = jdbhjl;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<bdjl_jdbhjl>(frm.RowData);
                RefreshGridData("");
            }
        }

        private void btDeletes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            if (MsgBox.ShowAskMessageBox("确定要删除吗?") == DialogResult.OK)
            {
                bdjl_jdbhjl jdbhjl = gridView1.GetFocusedRow() as bdjl_jdbhjl;
                Client.ClientHelper.PlatformSqlMap.Delete<bdjl_jdbhjl>(jdbhjl);
                RefreshGridData("");
            }
        }

        private void btRefreshs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshGridData("");
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
            RefreshGridData("");
            issearch = false;
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!issearch)
            {
                MsgBox.ShowWarningMessageBox("请先选择一个设备名称!");
                return;
            }
            IList<bdjl_jdbhjl> jdbhList = new List<bdjl_jdbhjl>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is bdjl_jdbhjl)
                    jdbhList.Add(row as bdjl_jdbhjl);
            }
            ExportBdjl.ExprotExcelJdbhjl(jdbhList);
        }

    }
}
