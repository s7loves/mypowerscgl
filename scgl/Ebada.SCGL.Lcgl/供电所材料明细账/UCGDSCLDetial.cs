/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
***********************************************/
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
using DevExpress.Utils;
using Ebada.Scgl.Lcgl;
using Ebada.Scgl.WFlow;
using Ebada.Components;
using System.Threading;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCGDSCLDetial : DevExpress.XtraEditors.XtraUserControl
    {
        #region
        private GridViewOperation<PJ_gdscrk> gridViewOperation;

        public UCGDSCLDetial()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_gdscrk>(gridControl1, gridView1, barManager1, null);
        }

        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }

        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            hideColumn("type");
            hideColumn("yt");
            hideColumn("ckdate");
            hideColumn("OrgCode");

            hideColumn("wpsl");
            hideColumn("cksl");
            hideColumn("indate");
            hideColumn("kcsl");
            gridView1.Columns["num"].Width = 150;
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_gdscrk> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }

        #endregion

        #region 导出数据2
        private void barExplorYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barGDS.EditValue != null && barEndTime.EditValue != null)
            {
                ExportGDSCRKDetial etdjh = new ExportGDSCRKDetial();
                etdjh.ExportGDSRKDExcel(barGDS.EditValue.ToString(), barEndTime.EditValue.ToString());
            }
        }
        #endregion

        #region 供电所改变、重新绑定数
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            comWpmc.Items.Clear();
            barWpmc.EditValue = null;
            if (barGDS.EditValue == null) return;
            IList listgds = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "'");
            if (listgds != null && listgds.Count > 0)
            {
                comWpmc.Items.AddRange(listgds);
            }
            RefreshData();
        }
        #endregion

        #region 物品名称更改
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.Items.Clear();
            barWpgg.EditValue = null;

            if (barGDS.EditValue != null)
            {
                RefreshData();
            }

            if (barWpmc.EditValue == null) return;
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "' and wpmc='" + barWpmc.EditValue + "' ");
            if (list != null && list.Count > 0)
            {
                comWpgg.Items.AddRange(list);
            }
        }
        #endregion

        #region 物品规格更改后、清空物品单位、重新绑定数据
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            comWpdw.Items.Clear();
            barWpdw.EditValue = null;

            if (barWpgg.EditValue == null) return;
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpdw from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "' and wpmc='" + barWpmc.EditValue + "' and wpgg='" + barWpgg.EditValue + "' ");
            if (list != null && list.Count > 0)
            {
                comWpdw.Items.AddRange(list);
            }
            RefreshData();
        }
        #endregion

        #region 物品单位更改、重新绑定数据
        private void barWpdw_EditValueChanged(object sender, EventArgs e)
        {
            if (barWpdw.EditValue != null)
            {
                RefreshData();
            }
        }
        #endregion

        #region 是否为原始库存更改后、重新绑定数据
        private void ckYanShiCaiLiao_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion

        #region 窗体加载事件
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();
            if (this.Site != null) return;

            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                barGDS.EditValue = MainHelper.UserOrg.OrgCode;
                barGDS.Edit.ReadOnly = true;
            }
            else
            {
                barGDS.Edit = DicTypeHelper.GdsDic;
            }
        }
        #endregion

        #region 刷新数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData()
        {
            if (barGDS.EditValue == null) return;
            string sql = " where OrgCode='" + barGDS.EditValue + "' and type!='原始入库材料'";
            if (barWpmc.EditValue != null)
            {
                sql += " and wpmc='" + barWpmc.EditValue + "'";
                if (barWpgg.EditValue != null)
                {
                    sql += " and wpgg='" + barWpgg.EditValue + "'";
                    if (barWpdw.EditValue != null)
                    {
                        sql += "and wpdw='" + barWpdw.EditValue + "'";
                    }
                }
            }

            if (barEndTime.EditValue != null)
            {
                sql += " and (indate <= '" + barEndTime.EditValue + "' or ckdate<='" + barEndTime.EditValue + "')";
            }

            sql += " order by wpmc desc";
            gridViewOperation.RefreshData(sql);
        }
        #endregion

        #region 入库截止日期改变
        private void barEndTime_EditValueChanged(object sender, EventArgs e)
        {
            if (barEndTime.EditValue != null)
            {
                if (Convert.ToDateTime(barEndTime.EditValue) > DateTime.Now)
                {
                    barEndTime.EditValue = DateTime.Now;
                }
            }
            RefreshData();
        }
        #endregion
    }
}
