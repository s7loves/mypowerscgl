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
using System.Collections;
using Ebada.UI.Base;
using DevExpress.XtraBars;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPS_KG : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_kg> gridViewOperation;

        public event SendDataEventHandler<PS_kg> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmkgEdit frm = new frmkgEdit();
        private string parentID = null;
        private PS_gt parentObj;
        private UCPopupSelectorBase xlselector;
        public UCPS_KG() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_kg>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_kg>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_kg>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_kg> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_kg> e) {
            if (parentID == null) {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择杆塔!");
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            xlselector = new UCPopupSelectorBase();
            xlselector.RowSelected += new EventHandler(xlselector_RowSelected);
            repositoryItemPopupContainerEdit1.PopupControl = new PopupContainerControl();
            repositoryItemPopupContainerEdit1.PopupControl.Size = xlselector.Size;
            repositoryItemPopupContainerEdit1.PopupControl.Controls.Add(xlselector);
            repositoryItemPopupContainerEdit1.NullText = "请选择线路";
            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            btXlList.EditValueChanged += new EventHandler(btXlList_EditValueChanged);
            btGtList.EditValueChanged += new EventHandler(btGtList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            } else {
                btGdsList.EditValue = "201";
            }
            //btGdsList_EditValueChanged(null, null);
        }

        void xlselector_RowSelected(object sender, EventArgs e) {
            PS_xl xl = xlselector.GetFocusedRow<PS_xl>();
            if (xl != null) {
                btXlList.EditValue = new ListItem(xl.LineCode, xl.LineName);
                gridControl1.Focus();
            }
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
            parentID = null;
            string code = string.Empty;
            object obj =(sender as BarEditItem).EditValue;
            if(obj is ListItem){
                code = ((ListItem)obj).ValueMember;
            }else
               code=obj .ToString();

            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + code + "'");
            repositoryItemLookUpEdit3.DataSource = list;

            string filter = string.Format(" where gtid in (select gtid from ps_gt where linecode='{0}')", code);
            RefreshData(filter);
        }
        DataTable xltable;
        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null) {
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                xltable = Ebada.Core.ConvertHelper.ToDataTable((IList)xlList, typeof(PS_xl));
                //repositoryItemLookUpEdit2.DataSource = xltable;
                xlselector.DataSource = xltable;
                xlselector.SetColumnsVisible("LineName");
                xlselector.SetFilterColumns("xlpy");

                string filter = string.Format(" where gtid in (select gtid from ps_gt where left(linecode,3)='{0}')", org.OrgCode);
                RefreshData(filter);
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_kg);
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
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            //hideColumn("ParentID");
            //hideColumn("gzrjID");
        }
        /// <summary>
        /// 隐藏选择列表
        /// </summary>
        public void HideList() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
        public GridViewOperation<PS_kg> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_kg newobj) {
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
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where gtID='" + value + "' order by kgCode");
                } else {
                    string tempstr = " 235@$U#u#$";
                    RefreshData(" where gtID='" + tempstr + "' order by kgCode");
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
                gridControl1.ExportToXls("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }
        }
    }
}
