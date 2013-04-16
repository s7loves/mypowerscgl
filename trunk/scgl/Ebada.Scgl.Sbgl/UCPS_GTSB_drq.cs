﻿/**********************************************
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
using Ebada.UI.Base;
using DevExpress.XtraEditors.Repository;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 电容器
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPS_GTSB_drq : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_gtsb> gridViewOperation;

        public event SendDataEventHandler<PS_gtsb> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmgtsbEdit frm = new frmgtsbEdit();
        private string parentID = null;
        private PS_gt parentObj;
        public UCPS_GTSB_drq() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_gtsb>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_gtsb>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_gtsb>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_gtsb> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_gtsb> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            //btGdsList.Edit = DicTypeHelper.GdsDic;
            //btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            //btXlList.EditValueChanged += new EventHandler(btXlList_EditValueChanged);
            //btGtList.EditValueChanged += new EventHandler(btGtList_EditValueChanged);
            //if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            //{//如果是供电所人员，则锁定
            //    btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
            //    btGdsList.Edit.ReadOnly = true;
            //}

        }

        void btGtList_EditValueChanged(object sender, EventArgs e) {
            parentID = btGtList.EditValue.ToString();
            if (parentID != "") {
                IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where gtID='" + parentID + "'");
                PS_gt gt = null;
                if (list.Count > 0) {
                    gt = list[0];
                    ParentObj = gt;
                }
            }
        }

        void btXlList_EditValueChanged(object sender, EventArgs e) {

            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + btXlList.EditValue.ToString() + "'");
            repositoryItemLookUpEdit3.DataSource = list;
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null) {

                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
            }


        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_gtsb);
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
        }
        /// <summary>
        /// 隐藏下选择列表
        /// </summary>
        public void HideList() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            hideColumn("C3");
            hideColumn("C4");
            hideColumn("C5");
            gridView1.Columns["C1"].Caption = "容量";
            gridView1.Columns["C2"].Caption = "补偿方式";

            RepositoryItemComboBox box1 = new RepositoryItemComboBox();
            box1.Items.AddRange(new string[] { "静态", "动态" });
            gridView1.Columns["C2"].ColumnEdit = box1;
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PS_gtsb> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_gtsb newobj) {
            if (parentID == null) return;
            newobj.gtID = parentID;

        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {//补偿电容器
                    RefreshData(" where sbtype='16001' and   gtID='" + value + "' order by sbCode");
                } else {
                    RefreshData(" where 1>1");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_gt ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    ParentID = null;
                } else {
                    ParentID = value.gtID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle >= 0) {
                gridControl1.ExportToExcelOld("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UCPS_gtsbclbMain ucTop = new UCPS_gtsbclbMain();
            ucTop.InitColumns();
            ucTop.InitData();
            ucTop.hidbarmange();
            FormBase dlg = showControl(ucTop);
            if (dlg.DialogResult == DialogResult.OK) {
                PS_gtsbclb obj = ucTop.SelectObject();
                if (obj != null) {
                    // List<PS_gtsb> listsb=new List<PS_gtsb>();
                    IList<PS_gtsbclb> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gtsbclb>("where ParentID='" + obj.ID + "'order by xh");
                    int i = 0;
                    foreach (PS_gtsbclb pl in list) {
                        i++;
                        PS_gtsb pt = Client.ClientHelper.PlatformSqlMap.GetOne<PS_gtsb>("where gtid='" + parentID + "'and sbid='" + pl.ID + "'");
                        if (pt == null) {
                            pt = new PS_gtsb();
                            pt.gtID = parentID;
                            //pt.sbNumber = Convert.ToInt16(pl.sl);
                            // pt.sbCode = pl.xh;
                            pt.sbID = pl.ID;
                            pt.sbModle = pl.xh;
                            pt.sbName = pl.mc;
                            pt.sbType = obj.zl;
                            pt.C1 = pl.S1;
                            Client.ClientHelper.PlatformSqlMap.Create<PS_gtsb>(pt);
                        } else {
                            pt.gtID = parentID;
                            // pt.sbNumber = Convert.ToInt16(pl.sl);
                            // pt.sbCode = getcode() + i;
                            pt.sbID = pl.ID;
                            pt.sbModle = pl.xh;
                            pt.sbName = pl.mc;
                            pt.sbType = obj.zl;
                            pt.C1 = pl.S1;
                            Client.ClientHelper.PlatformSqlMap.Update<PS_gtsb>(pt);
                        }

                        //listsb.Add(pt);
                    }
                    //Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(listsb,null,null);
                }
            }
            RefreshData(" where gtID='" + parentID + "' order by sbCode");
        }
        private FormBase showControl(UserControl uc) {
            FrmSelect dlg = new FrmSelect();
            Size newsize = new Size(500, 400);
            dlg.Size = newsize;

            dlg.FormBorderStyle = FormBorderStyle.FixedSingle;

            dlg.ShowInTaskbar = false;
            dlg.MaximizeBox = false;
            dlg.MinimizeBox = false;
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.Text = "杆塔材料类型选择器";
            dlg.control.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            dlg.ShowDialog();
            return dlg;
        }
    }
}
