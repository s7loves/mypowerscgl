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
    public partial class UCgps_device : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<gps_device> gridViewOperation;

        public event SendDataEventHandler<gps_device> FocusedRowChanged;

        public UCgps_device()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<gps_device>(gridControl1, gridView1, barManager1, new frm_deviceEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<gps_device>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterAdd += new ObjectEventHandler<gps_device>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<gps_device>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_AfterEdit(gps_device obj)
        {
            gridView1.BestFitColumns();
        }

        void gridViewOperation_AfterAdd(gps_device obj)
        {
            gridView1.BestFitColumns();
        }
        
        

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<gps_device> e)
        {
           
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
        }

        
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as gps_device);
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
            RefreshData();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            linkEdit.SingleClick = true;
            linkEdit.Click += new EventHandler(linkEdit_Click);

            gridView1.Columns["c1"].Caption = "查看";
            gridView1.Columns["c1"].ColumnEdit = linkEdit;
            gridView1.Columns["device_serial"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_type"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_model"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_expire"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_desc"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_state"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_made_date"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["software_version"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["system_version"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["last_modify"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["device_owner"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["phone_number"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["sim_id"].OptionsColumn.AllowEdit = false;
            hideColumn("carrier_id");
            hideColumn("c2");
            hideColumn("c3");
        }

        void linkEdit_Click(object sender, EventArgs e)
        {
            gps_device device = gridView1.GetFocusedRow() as gps_device;
            if (string.IsNullOrEmpty(device.carrier_id)||Client.ClientHelper.PlatformSqlMap.GetOne<gps_carrier>("where carrier_id='"+device.carrier_id+"'")==null)
            {
                MsgBox.ShowWarningMessageBox("该设备还没有绑定车辆信息!");
                return;
            }
            frm_SeeCarrier frm = new frm_SeeCarrier();
            frm.carrier_id = device.carrier_id;
            frm.ShowDialog();
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData()
        {
            gridViewOperation.RefreshData("");
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<gps_device> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(gps_device newobj)
        {
            newobj.device_expire = DateTime.Now;
            newobj.device_made_date = DateTime.Now;
           
        }
      

        
    }
}
