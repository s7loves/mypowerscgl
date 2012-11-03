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

namespace Ebada.Scgl.Lcgl.供电所材料出库单
{
    public partial class frmGDSCk : DevExpress.XtraEditors.XtraForm
    {
        public frmGDSCk()
        {
            InitializeComponent();
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
            frmGDSCKEdit frm = new frmGDSCKEdit();
            PJ_gdscrk wp = gridView1.GetFocusedRow() as PJ_gdscrk;
            if (wp != null)
            {
                frm.RowData = wp;
            }
            frm.ShowDialog();
        }
        #endregion
    }
}