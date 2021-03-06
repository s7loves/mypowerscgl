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
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using Ebada.UI.Base;
using System.Collections;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPS_TQ : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_tq> gridViewOperation;

        public event SendDataEventHandler<PS_tq> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmtqEdit frm = new frmtqEdit();
        private string parentID = null;
        private PS_gt parentObj;
        string mLineCode = string.Empty;
        string mOrgCode = string.Empty;
        private mOrg _mOrg = null;
        private UCPopupSelectorBase xlselector;
        public UCPS_TQ() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_tq>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_tq>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_tq>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PS_tq>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<PS_tq>(gridViewOperation_BeforeInsert);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<PS_tq> e) {
            int count = ClientHelper.PlatformSqlMap.GetRowCount<PS_tq>(string.Format("where tqcode='{0}' ", e.Value.tqCode));
            if (count > 0) {
                MsgBox.ShowWarningMessageBox("台区代码重复！");
                e.Cancel = true;
                return;
            }
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PS_tq> e) {
            if(e.Value.tqCode!=e.ValueOld.tqCode){
                int count = ClientHelper.PlatformSqlMap.GetRowCount<PS_tq>(string.Format("where tqcode='{0}' ", e.Value.tqCode));
                if (count > 0) {
                    MsgBox.ShowWarningMessageBox("台区代码重复！");
                    e.Cancel = true;
                    return;
                }

            }
            if (e.Value.Contractor != e.ValueOld.Contractor)
                Client.ClientHelper.PlatformSqlMap.Update("Update",
                    string.Format("update ps_xl set Contractor='{0}' where left(linecode,{1})='{2}'", e.Value.Contractor, e.Value.tqCode.Length, e.Value.tqCode));
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_tq> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_tq> e) {
            if (String.IsNullOrEmpty(frm.LineCode)) {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择线路!");
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            createXLSearch();//创建线路查询列
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
            }

        }
        private void createXLSearch() {
            RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1 = new RepositoryItemPopupContainerEdit();
            
            xlselector = new UCPopupSelectorBase();
            xlselector.RowSelected += new EventHandler(xlselector_RowSelected);
            repositoryItemPopupContainerEdit1.PopupControl = new PopupContainerControl();
            repositoryItemPopupContainerEdit1.PopupControl.Size = xlselector.Size;
            repositoryItemPopupContainerEdit1.PopupControl.Controls.Add(xlselector);
            repositoryItemPopupContainerEdit1.NullText = "请选择线路";
            btXlList.Edit = repositoryItemPopupContainerEdit1;
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
            string code = string.Empty;
            object obj = (sender as DevExpress.XtraBars.BarEditItem).EditValue;
            if (obj is ListItem) {
                code = ((ListItem)obj).ValueMember;
            } else
                code = obj.ToString();

            frm.LineCode = code;
            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + btXlList.EditValue.ToString() + "'");
            repositoryItemLookUpEdit3.DataSource = list;
            ParentObj = null;
            if (frm.LineCode.Length == 6) {
                //RefreshData(string.Format("where left(tqcode,{0})='{1}'", frm.LineCode.Length, frm.LineCode));
                RefreshData(string.Format("where xlcode='{0}'", frm.LineCode));
                //gridViewOperation.BindingList.Add(Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>(string.Format("where xlcode2='{0}'", frm.LineCode)));
            } else {
                RefreshData(string.Format("where xlcode2='{0}'", frm.LineCode));
            }
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            _mOrg = null;
            if (list.Count > 0)
                _mOrg = list[0];

            frm.LineCode = string.Empty;
            if (_mOrg != null) {
                frm.GdsCode = _mOrg.OrgCode;
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + _mOrg.OrgCode + "' and  linevol='10'");
                
                xlselector.DataSource = Ebada.Core.ConvertHelper.ToDataTable((IList)xlList, typeof(PS_xl)); 
                xlselector.SetColumnsVisible("LineName");
                xlselector.SetFilterColumns("xlpy");
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_tq);
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
            hideColumn("gtID");
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
        public GridViewOperation<PS_tq> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_tq newobj) {
            //if (parentID == null) return;

            if (gridView1.FocusedRowHandle > -1) {
                PS_tq tq = gridView1.GetFocusedRow() as PS_tq;
                Ebada.Core.ConvertHelper.CopyTo(tq, newobj);
                newobj.tqName = "";
            }
            newobj.gtID = parentID;
            //newobj.tqCode = newobj.tqID = getcode();
            newobj.tqID = newobj.CreateID();
            newobj.tqCode = getcode();

        }
        string getcode() {
            string code = "";
            string linecode = frm.LineCode.Substring(0, 6);
            string sql = "select max(tqcode) from ps_tq where len(tqcode)=10 and tqcode like '" + linecode + "%'";
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sql);
            if (list.Count > 0 && list[0]!=null) {
                string bh = list[0].ToString().Substring(6);
                bh = "1" + bh;
                bh = (int.Parse(bh) + 10).ToString();
                if (bh.StartsWith("2")) {
                    MessageBox.Show("编辑超出范围，自动生成失败，需手工修改。");
                } else {
                    code = linecode + bh.Substring(1);
                }
            } else {
                code = linecode + "0010";
            }
              /*
            if (gridViewOperation.BindingList.Count > 0) {
                int maxcode = 0;
                string tqcode = gridViewOperation.BindingList[0].tqCode;
                foreach (PS_tq node in gridViewOperation.BindingList) {
                    tqcode = node.tqCode;
                    maxcode = Math.Max(maxcode, int.Parse(tqcode.Substring(tqcode.Length - 4, 4)));
                }
                code = tqcode.Substring(0, tqcode.Length - 4) + (maxcode + 10).ToString("0000");

            } else {
                code = frm.LineCode + "0010";
            }
            */
            return code;
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
                    RefreshData(" where gtID='" + value + "' order by tqName");
                } else {
                    string tempstr = " 235@$U#u#$";
                    RefreshData(" where gtID='" + tempstr + "' order by tqName");
                }
            }
        }
        /// <summary>
        /// 隐藏下选择列表
        /// </summary>
        public void HideList() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar3.Visible = false;
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
                    frm.LineCode = value.LineCode;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle >= 0) {
                gridControl1.ExportToExcelOld("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }
        }
        PS_xl mXL = null;
        public PS_xl GetXL() {

            if (!string.IsNullOrEmpty(frm.LineCode)) {
                if (mXL != null && mXL.LineCode == frm.LineCode) {

                } else {
                    mXL = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + frm.LineCode + "'");
                }
            }
            return mXL;
        }
        public mOrg GetmOrg() {

            return _mOrg;
        }

        private void btJSDJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //计算列表中所有台区下的低压线路
            int ncount = 0;
            WaitDialogForm dlg = new WaitDialogForm("", "正计算档距，请稍候。。。");
            string info = "(第{0}共" + gridView1.RowCount + "个){1}";
            try {
                foreach (var item in gridViewOperation.BindingList) {
                    ncount++;

                    dlg.Caption = string.Format(info, ncount, item.tqName);
                    SbFuns.CountTQLen(item.tqCode);

                }
            } catch (Exception err) {
                dlg.Close();
                throw err;
            }
            dlg.Close();
            MsgBox.ShowTipMessageBox("计算完毕,共计算了" + ncount + "个台区。");
        }

    }
}
