﻿/**********************************************
系统:库存管理
模块:出库明细表管理
作者:Rabbit
创建时间:2012-7-28
最后一次修改:2012-7-28
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
using DevExpress.XtraEditors.Repository;
using System.Collections;
using Ebada.UI.Base;
using DevExpress.XtraEditors.Controls;
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    /// <summary>
    /// 出库明细表管理
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC出库明细表 : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Model.kc_出库明细表> gridViewOperation;

        public event SendDataEventHandler<Model.kc_出库明细表> FocusedRowChanged;
        private string parentID;
        public UC出库明细表() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<Model.kc_出库明细表>(gridControl1, gridView1, barManager1,true);
            gridViewOperation.SqlMap = Client.ClientHelper.TransportSqlMap;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<Ebada.Kcgl.Model.kc_出库明细表>(gridViewOperation_BeforeAdd);
            gridView1.CellValueChanging+=new CellValueChangedEventHandler(gridView1_CellValueChanging);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            bar3.Visible = false;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridView1.OptionsView.ColumnAutoWidth = true;
            //初始合计列
            this.gridView1.OptionsView.ShowFooter = true;
            gridView1.Columns[Model.kc_出库明细表.f_总计].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[Model.kc_出库明细表.f_总计].SummaryItem.DisplayFormat = "合计={0}";

            gridView1.IndicatorWidth = 40;//设置显示行号的列宽
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            btExport1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btExport1_ItemClick);
            gridViewOperation.AfterAdd += new ObjectEventHandler<kc_出库明细表>(gridViewOperation_AfterAdd);
            btExport1.Caption = "打印";
        }

        void gridViewOperation_AfterAdd(kc_出库明细表 obj) {
            gridView1.FocusedRowHandle=(gridView1.RowCount - 1);
        }

        void btExport1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

            var obj = gridView1.GetFocusedRow() as kc_出库明细表;
            if (obj != null)
                PrintHelper.ExportCK(obj.出库单_ID);
        }

        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e) {
            //设置显示行数
            if (e.Info.IsRowIndicator) {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.ImageIndex = -1;
            }
        }

        void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e) {
            var obj = gridView1.GetRow(e.RowHandle) as kc_出库明细表;
            if (obj == null) return;
            if (e.Column.FieldName == kc_出库明细表.f_数量) {
                obj.总计 = Convert.ToDouble(e.Value) * Convert.ToDouble(obj.单价);
            } else if (e.Column.FieldName == kc_出库明细表.f_单价) {
                obj.总计 = Convert.ToDouble(e.Value) * Convert.ToDouble(obj.数量);
            }
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<Ebada.Kcgl.Model.kc_出库明细表> e) {
            if (ParentObj == null) e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            
                //InitColumns();//初始列
                //InitData();//初始数据
           
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as Model.kc_出库明细表);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            RefreshData("");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            gridView1.Columns[kc_出库明细表.f_出库单位_ID].Caption = "工程项目";
            //需要隐藏列时在这写代码
            setColumnVisible(false, kc_出库明细表.f_出库单位, kc_出库明细表.f_工程类别, kc_出库明细表.f_材料名称_ID);
            gridView1.Columns[kc_出库明细表.f_总计].OptionsColumn.AllowEdit = false;
            gridView1.Columns[kc_出库明细表.f_规格及型号].OptionsColumn.AllowEdit = false;
            gridView1.Columns[kc_出库明细表.f_计量单位].OptionsColumn.AllowEdit = false;
            gridView1.Columns[kc_出库明细表.f_工程类别_ID].OptionsColumn.AllowEdit = false;
            gridView1.Columns[kc_出库明细表.f_出库单位_ID].OptionsColumn.AllowEdit = false;
            gridView1.Columns[kc_出库明细表.f_工程类别_ID].ColumnEdit = getLookup<kc_工程类别>(kc_工程类别.f_ID, kc_工程类别.f_工程类别);
            gridView1.Columns[kc_出库明细表.f_工程类别_ID].ColumnEdit.EditValueChanging += new ChangingEventHandler(工程类别ColumnEdit_EditValueChanging);
            gridView1.Columns[kc_出库明细表.f_材料名称].ColumnEdit = getclSeach();// getLookup<kc_材料名称表>(kc_材料名称表.f_ID, kc_材料名称表.f_材料名称);
            //gridView1.Columns[kc_出库明细表.f_材料名称_ID].ColumnEdit.EditValueChanging += new ChangingEventHandler(材料名称表ColumnEdit_EditValueChanging);
            gridView1.Columns[kc_出库明细表.f_出库单位_ID].ColumnEdit = getLookup<kc_工程项目>(kc_工程项目.f_ID, kc_工程项目.f_工程项目名称);
            gridView1.Columns[kc_出库明细表.f_出库单位_ID].ColumnEdit.EditValueChanging += new ChangingEventHandler(供货厂家ColumnEdit_EditValueChanging);
        }
        RepositoryItem getclSeach() {
            var edit = new RepositoryItemButtonEdit();
            edit.Click += new EventHandler(edit_Click);
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;
            return edit;
        }

        void edit_Click(object sender, EventArgs e) {
            frmCLSelector dlg = new frmCLSelector();
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (dlg.Selected材料 != null) {
                    var row = gridView1.GetFocusedRow() as kc_出库明细表;
                    row.材料名称_ID = dlg.Selected材料.ID;
                    row.规格及型号 = dlg.Selected材料.规格及型号;
                    row.计量单位 = dlg.Selected材料.计量单位;
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, dlg.Selected材料.材料名称);//必须，用以触发更新记录事件
                    gridView1.UpdateCurrentRow();
                }
            }
        }
        void 供货厂家ColumnEdit_EditValueChanging(object sender, ChangingEventArgs e) {
            kc_出库明细表 obj = gridView1.GetFocusedRow() as kc_出库明细表;
            if (obj != null) {
                obj.出库单位 = gridView1.GetDisplayTextByColumnValue(gridView1.Columns[kc_出库明细表.f_出库单位_ID], e.NewValue);
            }
        }

        void 工程类别ColumnEdit_EditValueChanging(object sender, ChangingEventArgs e) {
            kc_出库明细表 obj = gridView1.GetFocusedRow() as kc_出库明细表;
            if (obj != null) {
                obj.工程类别 = gridView1.GetDisplayTextByColumnValue(gridView1.Columns[kc_出库明细表.f_工程类别_ID], e.NewValue);
            }
        }
        void 材料名称表ColumnEdit_EditValueChanging(object sender, ChangingEventArgs e) {
            kc_出库明细表 obj = gridView1.GetFocusedRow() as kc_出库明细表;
            if (obj != null) {
                var cl = Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_材料名称表>(e.NewValue);
                if (cl != null) {
                    obj.材料名称 = cl.材料名称;
                    obj.规格及型号 = cl.规格及型号;
                    obj.计量单位 = cl.计量单位;
                    obj.数量 = 0;
                    obj.单价 = 0;
                    obj.总计 = 0;
                }
            }
        }
        Dictionary<Type, IDictionary> xmdic = new Dictionary<Type, IDictionary>();
        RepositoryItem getLookup<T>(string key, string value) {
            
            IDictionary dic = Client.ClientHelper.TransportSqlMap.GetDictionary<T>(null, key, value);
            xmdic.Add(typeof(T), dic);
            List<ListItem> list = new List<ListItem>();
            foreach (var item in dic.Keys) {
                list.Add(new ListItem(item.ToString(), dic[item].ToString()));
            }
            return new LookUpDicType(list);
        }
        class LookUpDicType : RepositoryItemLookUpEdit {
            public LookUpDicType(IList datasource)
                : this(datasource, "ValueMember", "DisplayMember") {

            }
            public LookUpDicType(IList datasource, string key, string value) {
                this.Columns.Add(new LookUpColumnInfo(key, "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default));
                this.Columns.Add(new LookUpColumnInfo(value, ""));
                this.DataSource = datasource;
                this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                this.Properties.DisplayMember = value;
                this.Properties.ValueMember = key;
                this.Properties.NullText = "";
            }
        }
        private void setColumnVisible(bool visible, params string[] cols) {

            foreach (var item in cols) {
                try { gridView1.Columns[item].Visible = visible; } catch { }
            }
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
        public GridViewOperation<Model.kc_出库明细表> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Model.kc_出库明细表 newobj) {
            newobj.出库单_ID = ParentObj.ID;
            newobj.出库日期 = ParentObj.出库时间;
            newobj.工程类别_ID = ParentObj.工程类别_ID;
            newobj.出库单位_ID = ParentObj.工程项目_ID;
            newobj.出库单位 = xmdic[typeof(kc_工程项目)][ParentObj.工程项目_ID].ToString();
            newobj.工程类别 = xmdic[typeof(kc_工程类别)][ParentObj.工程类别_ID].ToString();
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where 出库单_ID='" + value + "'");
                } else {
                    RefreshData(" where 1>0");
                }
            }
        }
        Model.kc_出库单 parentObj;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Model.kc_出库单 ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.ID;
                }
            }
        }
    }
}
