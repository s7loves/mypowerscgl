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
using System.Data.SqlClient;
using System.Threading;

namespace Ebada.Scgl.Sbgl
{
    public partial class UCsdxs_jhnr : DevExpress.XtraEditors.XtraUserControl
    {



        private GridViewOperation<sd_xsjhnr> gridViewOperation;
        public event SendDataEventHandler<sd_xsjhnr> FocusedRowChanged;
        public UCsdxs_jhnr()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_xsjhnr>(gridControl1, gridView1, barManager1, false);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
           
           
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            InitData();//初始数据
            InitColumns();//初始列
            

        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_xsjhnr);
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            RefreshData();
        }
        
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;
            }
            int m = 0;
            this.gridView1.Columns["gtbh"].Caption = "杆塔编号";
            this.gridView1.Columns["gtbh"].VisibleIndex = m++;

            this.gridView1.Columns["flag1"].Caption = "缺陷状态";
            this.gridView1.Columns["flag1"].VisibleIndex = m++;

            this.gridView1.Columns["lng"].Caption = "经度";
            this.gridView1.Columns["lng"].VisibleIndex = m++;

            this.gridView1.Columns["lat"].Caption = "纬度";
            this.gridView1.Columns["lat"].VisibleIndex = m++;

            this.gridView1.Columns["flag2"].Caption = "巡视状态";
            this.gridView1.Columns["flag2"].VisibleIndex = m++;

            this.gridView1.Columns["xssj"].Caption = "巡视时间";
            this.gridView1.Columns["xssj"].VisibleIndex = m++;

            this.gridView1.Columns["qxnr"].Caption = "缺陷内容";
            this.gridView1.Columns["qxnr"].VisibleIndex = m++;
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
      

       

        private string parentid;
        private string ParentID
        {
            get
            {
                return parentid;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                parentid = value;
                RefreshData();
            }
        }

        public void RefreshData()
        {
            string sql = " where ParentID='"+ParentID+"'";
            gridViewOperation.RefreshData(sql);
        }

        private sd_xsjh parentobj;
        public sd_xsjh ParentObj
        {
            get
            {
                return parentobj;
            }
            set
            {
                if (value == null)
                    return;
                this.parentobj = value;
                this.ParentID = value.ID;
            }
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (parentobj == null)
                return;
            int startgt =-1;
            int endgt = -1; 
            try
            {
                 startgt = Convert.ToInt32(parentobj.c1);
                 endgt = Convert.ToInt32(parentobj.c2);
                int temp = 0;
                if (startgt > endgt)
                {
                    temp = startgt;
                    startgt = endgt;
                    endgt = temp;
                }
            }
            catch
            {
                MsgBox.ShowWarningMessageBox("杆塔序号错误!");
                return;
            }
            if (startgt < 0 || endgt < 0)
                return;
            
            string sql = "where Convert(int,gtCode) between "+startgt+" and "+ endgt+" and LineCode='"+parentobj.LineID+"'";

            List<sd_gt> sdgtList=(List<sd_gt>)Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>(sql);
            if (sdgtList == null)
                return;
            if (sdgtList.Count == 0)
                return;
            List<sd_xsjhnr> xsjhnrList = new List<sd_xsjhnr>();
            foreach (sd_gt gt in sdgtList)
            {
                sd_xsjhnr xsjhnr = new sd_xsjhnr();
                xsjhnr.ParentID = parentid;
                xsjhnr.gtid = gt.gtID;
                xsjhnr.gtbh = gt.gtCode;
                xsjhnr.lat = gt.gtLat.ToString();
                xsjhnr.lng = gt.gtLon.ToString();
                xsjhnrList.Add(xsjhnr);
                Thread.Sleep(10);
            }
           
            frmsd_xsjhnr frm = new frmsd_xsjhnr();
            frm.gtList = sdgtList;
            frm.RowData = xsjhnrList;
            if (frm.ShowDialog() == DialogResult.OK)
            {

                foreach (sd_xsjhnr jhnr in (List<sd_xsjhnr>)frm.RowData)
                {
                    Client.ClientHelper.PlatformSqlMap.Create<sd_xsjhnr>(jhnr);
                }
                RefreshData();
                
            }
        }



    }
}
