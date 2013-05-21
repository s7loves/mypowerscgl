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

namespace Ebada.Scgl.Gis.Gps
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCgps_SeeCarrier : DevExpress.XtraEditors.XtraUserControl
    {
      
        public UCgps_SeeCarrier()
        {
            InitializeComponent();
        }

        public string carrier_id;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();//初始数据
            InitColumns();//初始列
            if (this.Site != null) return;
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
            RefreshData(carrier_id);
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            DevExpress.XtraEditors.Repository.RepositoryItemColorEdit colorEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            gridView1.Columns["color"].ColumnEdit = colorEdit;

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string carrierid)
        {
            IList<gps_carrier> carrierList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<gps_carrier>("where carrier_id='" + carrierid + "'");
            if (carrierList == null)
                carrierList = new List<gps_carrier>();
            gridControl1.DataSource = carrierList;
            this.gridView1.BestFitColumns();
        }
    }
}
