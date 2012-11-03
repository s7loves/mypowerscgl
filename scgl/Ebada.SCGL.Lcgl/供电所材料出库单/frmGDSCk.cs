using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Client;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmGDSCk : DevExpress.XtraEditors.XtraForm
    {
        public frmGDSCk()
        {
            InitializeComponent();
            lkeGDS.Properties.DisplayMember = "OrgName";
            lkeGDS.Properties.ValueMember = "OrgCode";
            IList<mOrg> list = ClientHelper.PlatformSqlMap.GetList<mOrg>(" where OrgType='1'");
            lkeGDS.Properties.DataSource = list;
            lkeGDS.Properties.NullText = "";
            lkeGDS.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrgName", 100, "请选择供电所"));
        }

        #region 查询
        private bool first = true;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql = " where OrgCode='" + lkeGDS.EditValue + "' and type='原始入库材料'";
            if (comWpmc.EditValue != null)
            {
                sql += " and wpmc='" + comWpmc.EditValue + "'";
                if (comWpgg.EditValue != null)
                {
                    sql += " and wpgg='" + comWpgg.EditValue + "'";
                    if (comWpdw.EditValue != null)
                    {
                        sql += " and wpdw='" + comWpdw.EditValue + "'";
                    }
                }
            }
            IList<PJ_gdscrk> list = ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>(sql);
            gridControl1.DataSource = list;
            if (first)
            {
                HideColumns();
            }
        }

        #region 隐藏列
        private void HideColumns()
        {
            gridView1.Columns["num"].Visible = false;
            gridView1.Columns["indate"].Visible = false;
            gridView1.Columns["ckdate"].Visible = false;
            gridView1.Columns["cksl"].Visible = false;
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["type"].Visible = false;
            gridView1.Columns["yt"].Visible = false;
        }
        #endregion

        #endregion

        #region 附件留言
        private void barFJLY_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 自动出库
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lkeGDS.EditValue == null) return;

            frmGDSCKEdit frm = new frmGDSCKEdit();
            PJ_gdscrk wp = gridView1.GetFocusedRow() as PJ_gdscrk;

            if (wp == null || Convert.ToInt32(wp.kcsl) <= 0)
            {
                wp = new PJ_gdscrk();
            }
            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
            <PJ_gdscrk>(" where id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and (type='原始入库材料' or type='设置库存') order by id desc ");
            if (pnumli.Count == 0)
                wp.num = "GDSCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                wp.num = "GDSCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("GDSCRK", "")) + 1);
            }
            wp.type = "出库";
            wp.OrgCode = lkeGDS.EditValue.ToString();
            frm.RowData = wp;
            frm.SetKC = true;
            frm.ShowDialog();
        }
        #endregion

        #region 供电所改变查找物品名称
        private void lkeGDS_EditValueChanged(object sender, EventArgs e)
        {
            comWpmc.EditValue = null;
            comWpmc.Properties.Items.Clear();
            if (lkeGDS.EditValue != null)
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select distinct wpmc from PJ_gdscrk where OrgCode='" + lkeGDS.EditValue + "'");
                if (list != null && list.Count > 0)
                {
                    comWpmc.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品名称改变查找物品规格
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.EditValue = null;
            comWpgg.Properties.Items.Clear();
            if (comWpmc.EditValue != null)
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select distinct wpgg from PJ_gdscrk where OrgCode='" + lkeGDS.EditValue + "' and wpmc='" + comWpmc.EditValue + "'");
                if (list != null && list.Count > 0)
                {
                    comWpgg.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品规格改变查找物品单位
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            comWpdw.EditValue = null;
            comWpdw.Properties.Items.Clear();
            if (comWpgg.EditValue != null)
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select distinct wpdw from PJ_gdscrk where OrgCode='" + lkeGDS.EditValue + "' and wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "'");
                if (list != null && list.Count > 0)
                {
                    comWpdw.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion
    }
}