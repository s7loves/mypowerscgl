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
using DevExpress.XtraEditors.Repository;
using System.Collections;
using Ebada.Scgl.Sbgl.变电;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCBD_SBTZ : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<BD_SBTZ> gridViewOperation;
        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        public event SendDataEventHandler<BD_SBTZ> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmtqbyqEdit frm = new frmtqbyqEdit();
        private string parentID = null;
        private mOrg parentObj;
        private BD_SBTZ_ZL parentType;
        private UCPopupSelectorBase xlselector;
        public UCBD_SBTZ() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<BD_SBTZ>(gridControl1, gridView1, barManager1,new frmSBTZ());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<BD_SBTZ>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<BD_SBTZ>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<BD_SBTZ>(gridViewOperation_BeforeInsert);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<BD_SBTZ>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            //btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btTQList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btAdd.Enabled = false;
            btEdit.Enabled = false;
            btDelete.Enabled = false;
            HideList();
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<BD_SBTZ> e)
        {
            e.Cancel = true;
            try
            {
                frmSBTZ frm = gridViewOperation.EditForm as frmSBTZ;
                PS_Image image = null;
                if (frm.GetImage() != null)
                {
                    image = new PS_Image();
                    image.ImageName = "变电设备照片";
                    image.ImageType = "sdsb";
                    image.ImageData = (byte[])frm.GetImage();
                    e.Value.c3 = image.ImageID;
                    Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(new object[] { e.Value, image }, null, null);
                }
                else
                {
                    Client.ClientHelper.PlatformSqlMap.Create<BD_SBTZ>(e.Value);
                }

                gridViewOperation.BindingList.Add(e.Value);
            }
            catch (Exception err) { throw err; }
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<BD_SBTZ> e)
        {
            e.Cancel = true;
            try
            {
                BD_SBTZ sdsb = e.Value;
                frmSBTZ frm = gridViewOperation.EditForm as frmSBTZ;
                PS_Image image = frm.GetPS_Image();
                if (frm.GetImage() != null)
                {
                    if (sdsb.c3 == "" || image == null || sdsb.c3!=image.ImageID)
                    {
                        image = new PS_Image();
                        image.ImageName = "变电设备照片";
                        image.ImageType = "bd";
                        image.ImageData = (byte[])frm.GetImage();
                        sdsb.c3 = image.ImageID;
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, sdsb, null);
                    }
                    else
                    {

                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, new object[] { sdsb, image }, null);
                    }

                }
                else {
                    Client.ClientHelper.PlatformSqlMap.Update<BD_SBTZ>(e.Value);

                }

                Ebada.Core.ConvertHelper.CopyTo(sdsb, e.ValueOld);
                //RefreshData();

            }
            catch (Exception err) { throw err; }
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<BD_SBTZ> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<BD_SBTZ> e) {
            if (parentObj == null) {
                e.Cancel = true;
                MsgBox.ShowTipMessageBox("请先选择变电站后增加！");
            } else {
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            //createXLSearch();
            //InitData();//初始数据
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            InitColumns();//初始列
            //btGdsList.Edit = DicTypeHelper.GdsDic;
            //btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            //if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            //{//如果是供电所人员，则锁定
            //    btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
            //    btGdsList.Edit.ReadOnly = true;
            //}

        }
        private void createXLSearch() {
            RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1 = new RepositoryItemPopupContainerEdit();
            repositoryDateEdit1.DisplayFormat.FormatString = "yyyy-MM-dd";
            xlselector = new UCPopupSelectorBase();
            xlselector.RowSelected += new EventHandler(xlselector_RowSelected);
            repositoryItemPopupContainerEdit1.PopupControl = new PopupContainerControl();
            repositoryItemPopupContainerEdit1.PopupControl.Size = xlselector.Size;
            repositoryItemPopupContainerEdit1.PopupControl.Controls.Add(xlselector);
            repositoryItemPopupContainerEdit1.NullText = "请选择线路";
            //btXlList.Edit = repositoryItemPopupContainerEdit1;
        }
        void xlselector_RowSelected(object sender, EventArgs e) {
            //PS_xl xl = xlselector.GetFocusedRow<PS_xl>();
            //if (xl != null) {
            //    btXlList.EditValue = new Ebada.UI.Base.ListItem(xl.LineCode, xl.LineName);
            //    gridControl1.Focus();
            //}
        }
        void btTQList_EditValueChanged(object sender, EventArgs e) {

        }

        void btGtList_EditValueChanged(object sender, EventArgs e) {


        }

        void btXlList_EditValueChanged(object sender, EventArgs e) {

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {

        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as BD_SBTZ);
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
        /// 隐藏选择列表
        /// </summary>
        public void HideList() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btTQList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar3.Visible = false;
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;
            }
            //parentObj、parentType

            IDictionary dic = ClientHelper.PlatformSqlMap.GetDictionary<BD_SBTZ_SX>("where zldm='14'", "sxcol", "sxname");
            string cname = "";
            for (int i = 1; i <= 8; i++)
            {
                cname = "a" + i;
                gridView1.Columns[cname].VisibleIndex = i;
                gridView1.Columns[cname].Caption = dic[cname].ToString();
                if (i == 5 || i == 6 || i == 8)
                {
                    gridView1.Columns[cname].ColumnEdit = repositoryDateEdit1;
                    gridView1.Columns[cname].DisplayFormat.FormatString = "yyyy-MM-dd";
                }
            }
        }
        private void InitGridColumns()
        {

            foreach (GridColumn c in gridView1.Columns)
            {
                c.Visible = false;
            }
            if (parentType != null)
            {
                string sqlwhere = "where zldm='"+parentType.dm+"'";
                IDictionary dic= ClientHelper.PlatformSqlMap.GetDictionary<BD_SBTZ_SX>(sqlwhere, "sxcol", "sxname");
                string cname = "";
                if (dic.Count > 0)
                {
                    for (int i = 1; i <= 50; i++)
                    {
                        cname = "a" + i;
                        if (dic.Contains(cname))
                        {
                            gridView1.Columns[cname].VisibleIndex = i;
                            gridView1.Columns[cname].Caption = dic[cname].ToString();
                        }
                    }
                }
                
            }
        }
        
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshData() {
            string sql = "";
            if (!string.IsNullOrEmpty(parentID)) {
                sql = "  where orgcode='" + parentID + "'";
                if (parentType != null) {
                    sql += " and sbtype='" + parentType.dm + "' ";
                }
                sql += "order by sbname";
            } else {
                sql = " where 1>1";
            }

            gridViewOperation.RefreshData(sql);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<BD_SBTZ> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(BD_SBTZ newobj) {

            if (gridView1.FocusedRowHandle > -1) {
                //BD_SBTZ tq = gridView1.GetFocusedRow() as BD_SBTZ;
                //Ebada.Core.ConvertHelper.CopyTo(tq, newobj);
                newobj.sb_id = newobj.CreateID();
            }
            newobj.OrgCode = parentObj.OrgCode;

            newobj.a1 = parentType.mc;
            newobj.sbtype = parentType.dm;
            newobj.jxzq = int.Parse(parentType.jxzq);
            
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
                RefreshData();
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.OrgCode;
                }
                setToolbar();
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BD_SBTZ_ZL ParentType {
            set {
                parentType = value;
                InitGridColumns();
                setToolbar();
                RefreshData();
            }
        }

        private void setToolbar() {
            bool flag = (parentType != null && parentObj != null);

            btAdd.Enabled = flag;
            btEdit.Enabled = flag;
            btDelete.Enabled = flag;

        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle >= 0) {

            }


        }

        
    }
}
