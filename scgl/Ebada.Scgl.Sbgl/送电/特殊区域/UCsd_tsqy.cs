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
using DevExpress.XtraEditors.Repository;
using System.Collections;
using Ebada.Scgl.Sbgl.变电;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCsd_tsqy : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sd_tsqy> gridViewOperation;
        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
        public event SendDataEventHandler<sd_tsqy> FocusedRowChanged;
        public event SendDataEventHandler<sd_xl> SelectGdsChanged;
        frmtqbyqEdit frm = new frmtqbyqEdit();
        private string parentID = null;
        private sd_xl parentObj;
        private sd_tsqyzl parentType;
        private UCPopupSelectorBase xlselector;
        public UCsd_tsqy()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_tsqy>(gridControl1, gridView1, barManager1, new frmsd_tsqyEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sd_tsqy>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<sd_tsqy>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<sd_tsqy>(gridViewOperation_BeforeInsert);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sd_tsqy>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            //btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btTQList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btAdds.Enabled = false;
            btEdits.Enabled = false;
            btDelete.Enabled = false;
            HideList();
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<sd_tsqy> e)
        {
            //e.Cancel = true;
            //try
            //{
            //    frmSBTZ frm = gridViewOperation.EditForm as frmSBTZ;
            //    PS_Image image = null;
            //    if (frm.GetImage() != null)
            //    {
            //        image = new PS_Image();
            //        image.ImageName = "送电设备照片";
            //        image.ImageType = "sdsb";
            //        image.ImageData = (byte[])frm.GetImage();
            //        e.Value.a25 = image.ImageID;
            //        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(new object[] { e.Value, image }, null, null);
            //    }
            //    else
            //    {
            //        Client.ClientHelper.PlatformSqlMap.Create<sd_tsqy>(e.Value);
            //    }

            //    gridViewOperation.BindingList.Add(e.Value);
            //}
            //catch (Exception err) { throw err; }
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<sd_tsqy> e)
        {
            //e.Cancel = true;
            //try
            //{
            //    sd_tsqy sdsb = e.Value;
            //    frmSBTZ frm = gridViewOperation.EditForm as frmSBTZ;
            //    PS_Image image = frm.GetPS_Image();
            //    if (frm.GetImage() != null)
            //    {
            //        if (sdsb.a25 == "" || image == null)
            //        {
            //            image = new PS_Image();
            //            image.ImageName = "特殊区域照片";
            //            image.ImageType = "sdsb";
            //            image.ImageData = (byte[])frm.GetImage();
            //            sdsb.a25 = image.ImageID;
            //            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, sdsb, null);
            //        }
            //        else
            //        {

            //            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, new object[] { sdsb, image }, null);
            //        }

            //    }
            //    else
            //    {
            //        Client.ClientHelper.PlatformSqlMap.Update<sd_tsqy>(e.Value);
            //    }

            //    Ebada.Core.ConvertHelper.CopyTo(sdsb, e.ValueOld);
            //}
            //catch (Exception err) { throw err; }
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sd_tsqy> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sd_tsqy> e) {
            if (parentObj == null) {
                frmbdsbEdit frm= gridViewOperation.EditForm as frmbdsbEdit;

                e.Cancel = true;
                MsgBox.ShowTipMessageBox("请先选择送电线路后增加！");
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_tsqy);
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

            gridView1.Columns["gtbegin"].Caption = "起始杆塔";
            gridView1.Columns["gtbegin"].VisibleIndex = 0;
            gridView1.Columns["gtend"].Caption = "终止杆塔";
            gridView1.Columns["gtend"].VisibleIndex = 1;
           
        }
        private void InitGridColumns()
        {
            foreach (GridColumn c in gridView1.Columns)
            {
                c.Visible = false;
            }
            gridView1.Columns["gtbegin"].Caption = "起始杆塔";
            gridView1.Columns["gtbegin"].VisibleIndex = 0;
            gridView1.Columns["gtend"].Caption = "终止杆塔";
            gridView1.Columns["gtend"].VisibleIndex = 1;
            if (parentType != null)
            {
                string sqlwhere = "where zldm='"+parentType.zldm+"' and isuse='是'";
                IDictionary dic= ClientHelper.PlatformSqlMap.GetDictionary<sd_tsqyzlsx>(sqlwhere, "sxcol", "sxname");
                string cname = "";
                if (dic.Count > 0)
                {
                    for (int i = 2; i <=26; i++)
                    {
                        cname = "a" + (i-1);
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
                sql = "  where LineID='" + parentID + "'";
                if (parentType != null) {
                    sql += " and zldm='" + parentType.zldm + "' ";
                }
                sql += "order by zldm";
            } else {
                sql = " where 1>1";
            }

            gridViewOperation.RefreshData(sql);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sd_tsqy> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sd_tsqy newobj) {

            if (gridView1.FocusedRowHandle > -1) {
                //sd_tsqy tq = gridView1.GetFocusedRow() as sd_tsqy;
                //Ebada.Core.ConvertHelper.CopyTo(tq, newobj);
                newobj.ID = newobj.CreateID();
            }
            newobj.OrgCode = parentObj.OrgCode;
            newobj.LineID = parentObj.LineID;
            newobj.zldm = parentType.zldm;
            newobj.createdate = DateTime.Now;
            newobj.createman = MainHelper.User.UserName;
            
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
        public sd_xl ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.LineID;
                }
                setToolbar();
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sd_tsqyzl ParentType {
            set {
                parentType = value;
                InitGridColumns();
                setToolbar();
                RefreshData();
            }
        }

        private void setToolbar() {
            bool flag = (parentType != null && parentObj != null);

            btAdds.Enabled = flag;
            btEdits.Enabled = flag;
            btDelete.Enabled = flag;

        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle >= 0) {

            }


        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            frmsd_tsqyEdit frmtsqy = new frmsd_tsqyEdit();
            sd_tsqy tsqy = new sd_tsqy();
            tsqy.OrgCode = parentObj.OrgCode;
            tsqy.LineID = parentObj.LineID;
            tsqy.zldm = parentType.zldm;
            tsqy.createdate = DateTime.Now;
            tsqy.createman = MainHelper.User.UserName;
            frmtsqy.sdxl = this.parentObj;
            frmtsqy.tsqyzl = this.parentType;
            frmtsqy.RowData = tsqy;
            if (frmtsqy.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<sd_tsqy>(frmtsqy.RowData);
                if (frmtsqy.GetImage() != null)
                {
                    sd_tsqyimage tsqyImage = new sd_tsqyimage();
                    tsqyImage.ParentID = tsqy.ID;
                    tsqyImage.data = (byte[])frmtsqy.GetImage();
                    Client.ClientHelper.PlatformSqlMap.Create<sd_tsqyimage>(tsqyImage);
                    
                }
                RefreshData();
            }
        }

        private void btEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            sd_tsqy tsqy = gridView1.GetFocusedRow() as sd_tsqy;
            frmsd_tsqyEdit frmtsqy = new frmsd_tsqyEdit();
            frmtsqy.sdxl = this.parentObj;
            frmtsqy.tsqyzl = this.parentType;
            frmtsqy.RowData = tsqy;
            if (frmtsqy.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<sd_tsqy>(tsqy);
                if (frmtsqy.ispicChange)
                {
                    sd_tsqyimage tsqyImage = Client.ClientHelper.PlatformSqlMap.GetOne<sd_tsqyimage>("where ParentID='" + tsqy.ID + "'");
                    if (tsqyImage == null)
                    {
                        tsqyImage = new sd_tsqyimage();
                        tsqyImage.ParentID = tsqy.ID;
                        tsqyImage.data = (byte[])frmtsqy.GetImage();
                        Client.ClientHelper.PlatformSqlMap.Create<sd_tsqyimage>(tsqyImage);
                    }
                    else
                    {
                        tsqyImage.ParentID = tsqy.ID;
                        tsqyImage.data = (byte[])frmtsqy.GetImage();
                        if (tsqyImage.data == null)
                            tsqyImage.data = new byte[] { 0 };

                        Client.ClientHelper.PlatformSqlMap.Update<sd_tsqyimage>(tsqyImage);
                    }
                }
                RefreshData();
            }
        }

        
    }
}
