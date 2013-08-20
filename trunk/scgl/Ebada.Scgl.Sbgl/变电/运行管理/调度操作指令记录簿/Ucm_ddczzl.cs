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
    public partial class Ucm_ddczzl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_ddzczl> gridViewOperation;
        public Ucm_ddczzl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_ddzczl>(gridControl1, gridView1, barManager1, false);
            InitLuke();
        }

        private void InitLuke()
        {
            IList<mOrg> orgList = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgType=2 order by OrgName");
           List<DicType> dictypeList = new List<DicType>();
           foreach (mOrg org in orgList)
           {
               dictypeList.Add(new DicType(org.OrgCode, org.OrgName));
           }
           SetComboBoxData(lkueorg, "Value", "Key", "请选择", "变电所", dictypeList);
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
            gridView1.BestFitColumns();
        }

        private void Ucm_czpdjb_Load(object sender, EventArgs e)
        {
            gridView1.BestFitColumns();
            //this.datesj.EditValue = DateTime.Now.ToString("yyyy-MM");
            this.datesj.EditValue = null;
            RefreshGridData("");
            InitGridviewColumn();
        }

        private void InitGridviewColumn()
        {
            gridView1.Columns["OrgCode"].Visible = false;
            //gridView1.Columns["c1"].Visible = false;
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

        private void btnSearchs_Click(object sender, EventArgs e)
        {
            if (datesj.EditValue == null)
                return;
            string searchtime = Convert.ToDateTime(datesj.EditValue).ToString("yyyy-M");
            string sqlwhere = "where Convert(varchar,Year(kssj)) + '-' + Convert(varchar,Month(kssj))='"+searchtime+"'";
            if (!string.IsNullOrEmpty(lkueorg.EditValue as string))
            {
                sqlwhere += " and orgcode='"+lkueorg.EditValue as string+"'";
            }
            RefreshGridData(sqlwhere);
            //Convert(varchar,Year(kssj)) + '-' + Convert(varchar,Month(kssj))
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.datesj.EditValue = null;
            RefreshGridData("");
        }

        private void btExports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<bdjl_ddzczl> ddList = new List<bdjl_ddzczl>();// gridView1.DataSource as IList<JH_weekks>;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is bdjl_ddzczl)
                    ddList.Add(row as bdjl_ddzczl);
            }
            string title = "";
            if (datesj.EditValue != null)
            {
               title = Convert.ToDateTime(datesj.EditValue).Year + "年" + Convert.ToDateTime(datesj.EditValue).Month + "月";
            }
            ExportBdjl.ExportExcelDdczzl(title, ddList);
        }

    }
}
