/**********************************************
系统:库存管理
模块:工程计划明细表
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
using Ebada.Kcgl.Model;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Collections;
using Ebada.UI.Base;

namespace Ebada.Kcgl {
    /// <summary>
    /// 工程计划明细表
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC工程计划明细表 : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Model.kc_工程计划明细表> gridViewOperation;

        public event SendDataEventHandler<Model.kc_工程计划明细表> FocusedRowChanged;
        private string parentID;
        private Model.kc_工程项目 parentObj;
        public UC工程计划明细表() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<Model.kc_工程计划明细表>(gridControl1, gridView1, barManager1,true);
            gridViewOperation.SqlMap = Client.ClientHelper.TransportSqlMap;
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<Ebada.Kcgl.Model.kc_工程计划明细表>(gridViewOperation_BeforeAdd);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar3.Visible = false;
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            gridView1.ShowButtonMode = ShowButtonModeEnum.ShowForFocusedRow;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.CellValueChanging += new CellValueChangedEventHandler(gridView1_CellValueChanging);
            gridView1.IndicatorWidth = 40;//设置显示行号的列宽
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
        }

        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e) {
            //设置显示行数
            if (e.Info.IsRowIndicator) {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
                e.Info.ImageIndex = -1;
            }
        }

        void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e) {
            var obj = gridView1.GetRow(e.RowHandle) as kc_工程计划明细表;
            if (obj == null) return;
            if (e.Column.FieldName == kc_工程计划明细表.f_数量) {
                obj.总计 =Convert.ToDouble( e.Value) * Convert.ToDouble(obj.单价);
            } else if (e.Column.FieldName == kc_工程计划明细表.f_单价) {
                obj.总计 = Convert.ToDouble(e.Value) * Convert.ToDouble(obj.数量);
            }
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<Ebada.Kcgl.Model.kc_工程计划明细表> e) {
            if (parentObj == null) e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            
            InitColumns();//初始列
            InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as Model.kc_工程计划明细表);
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

            //需要隐藏列时在这写代码
            gridView1.Columns[kc_工程计划明细表.f_总计].OptionsColumn.AllowEdit = false;
            setColumnVisible(false,kc_工程计划明细表.f_供货厂家, kc_工程计划明细表.f_项目名称, kc_工程计划明细表.f_工程类别, kc_工程计划明细表.f_材料名称_ID, kc_工程计划明细表.f_工程项目_ID);
            gridView1.Columns[kc_工程计划明细表.f_规格及型号].OptionsColumn.AllowEdit = false;
            gridView1.Columns[kc_工程计划明细表.f_计量单位].OptionsColumn.AllowEdit = false;
            //gridView1.Columns[kc_工程计划明细表.f_材料名称].ShowButtonMode = ShowButtonModeEnum.ShowOnlyInEditor;
            gridView1.Columns[kc_工程计划明细表.f_工程类别_ID].ColumnEdit = getLookup<kc_工程类别>(kc_工程类别.f_ID, kc_工程类别.f_工程类别);
            gridView1.Columns[kc_工程计划明细表.f_工程类别_ID].ColumnEdit.EditValueChanging += new ChangingEventHandler(工程类别ColumnEdit_EditValueChanging);
            gridView1.Columns[kc_工程计划明细表.f_材料名称].ColumnEdit = getclSeach();// getLookup<kc_材料名称表>(kc_材料名称表.f_ID, kc_材料名称表.f_材料名称);
            //gridView1.Columns[kc_工程计划明细表.f_材料名称_ID].ColumnEdit.EditValueChanging += new ChangingEventHandler(材料名称表ColumnEdit_EditValueChanging);
            gridView1.Columns[kc_工程计划明细表.f_供货厂家_ID].ColumnEdit = getLookup<kc_供货厂家>(kc_供货厂家.f_ID, kc_供货厂家.f_厂家名称);
            gridView1.Columns[kc_工程计划明细表.f_供货厂家_ID].ColumnEdit.EditValueChanging += new ChangingEventHandler(供货厂家ColumnEdit_EditValueChanging);
        }
        void 供货厂家ColumnEdit_EditValueChanging(object sender, ChangingEventArgs e) {
            kc_工程计划明细表 obj = gridView1.GetFocusedRow() as kc_工程计划明细表;
            if (obj != null) {
                obj.供货厂家 = gridView1.GetDisplayTextByColumnValue(gridView1.Columns[kc_工程计划明细表.f_供货厂家_ID],e.NewValue);
            }
        }

        void 工程类别ColumnEdit_EditValueChanging(object sender, ChangingEventArgs e) {
            kc_工程计划明细表 obj= gridView1.GetFocusedRow() as kc_工程计划明细表;
            if (obj != null) {
                obj.工程类别 = gridView1.GetDisplayTextByColumnValue(gridView1.Columns[kc_工程计划明细表.f_工程类别_ID], e.NewValue);
            }
        }
        void 材料名称表ColumnEdit_EditValueChanging(object sender, ChangingEventArgs e) {
            kc_工程计划明细表 obj= gridView1.GetFocusedRow() as kc_工程计划明细表;
            if (obj != null) {
                var cl=Client.ClientHelper.TransportSqlMap.GetOneByKey<kc_材料名称表>(e.NewValue);
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

        RepositoryItem getclSeach() {
            var edit = new RepositoryItemButtonEdit();
            //edit.Buttons[0].Kind = ButtonPredefines.Ellipsis;
            edit.Click += new EventHandler(edit_Click);
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;
            return edit;
        }

        void edit_Click(object sender, EventArgs e) {
            frmCLSelector dlg = new frmCLSelector();
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (dlg.Selected材料 != null) {
                   var row= gridView1.GetFocusedRow() as kc_工程计划明细表 ;
                   row.材料名称_ID = dlg.Selected材料.ID;
                   row.材料名称 = dlg.Selected材料.材料名称;
                   row.规格及型号 = dlg.Selected材料.规格及型号;
                   row.计量单位 = dlg.Selected材料.计量单位;
                   Client.ClientHelper.TransportSqlMap.Update<kc_工程计划明细表>(row);
                   gridView1.UpdateCurrentRow();
                }
            }
        }
        RepositoryItem getLookup<T>(string key, string value) {
            IDictionary dic = Client.ClientHelper.TransportSqlMap.GetDictionary<T>(null, key,value);
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
            public LookUpDicType(IList datasource,string key,string value) {
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GridViewOperation<Model.kc_工程计划明细表> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Model.kc_工程计划明细表 newobj) {
            newobj.工程项目_ID = parentObj.ID;
            newobj.项目名称 = parentObj.工程项目名称;
            newobj.计划日期 = DateTime.Today;
            newobj.合同到货日期 = DateTime.Today;
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
                    RefreshData(" where 工程项目_ID='" + value + "'");
                } else {
                    RefreshData(" where 1>0");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Model.kc_工程项目 ParentObj {
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
