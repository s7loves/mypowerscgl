/**********************************************
系统:库存管理
模块:入库单管理
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
using System.Collections;

namespace Ebada.Kcgl {
    /// <summary>
    /// 入库单管理
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC入库单 : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Model.kc_入库单> gridViewOperation;

        public event SendDataEventHandler<Model.kc_入库单> FocusedRowChanged;
        private string parentID;
        public UC入库单() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<Model.kc_入库单>(gridControl1, gridView1, barManager1,true);
            gridViewOperation.SqlMap = Client.ClientHelper.TransportSqlMap;
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<kc_入库单>(gridViewOperation_BeforeSave);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<kc_入库单>(gridViewOperation_BeforeDelete);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridView1.OptionsView.ColumnAutoWidth = true;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<kc_入库单> e) {
            if (childView != null && childView.BindingList.Count > 0) {
                e.Cancel = true;
                MsgBox.ShowAskMessageBox("请先删除材料明细，再删除入库单！");
            }
        }

        void gridViewOperation_BeforeSave(object render, ObjectOperationEventArgs<kc_入库单> e) {
            if (string.IsNullOrEmpty(e.Value.入库单号)) {
                MsgBox.ShowAskMessageBox(string.Format("【{0}不能为空！】", kc_入库单.f_入库单号)); e.Cancel = true;
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitColumns();//初始列
            //InitData();//初始数据
        }
        private IViewOperation<kc_入库明细表> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IViewOperation<Model.kc_入库明细表> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    bar3.Visible = false;
                    
                }
            }
        }
        private void hideColumn(string col, params string[] cols) {
            try { gridView1.Columns[col].Visible = false; } catch { }
            foreach (var item in cols) {
                try { gridView1.Columns[item].Visible = false; } catch { }
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as Model.kc_入库单);
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
            hideColumn(kc_入库单.f_工程类别_ID, kc_入库单.f_工程项目_ID, kc_入库单.f_供货厂家_ID);
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
        public GridViewOperation<Model.kc_入库单> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Model.kc_入库单 newobj) {
            newobj.入库单号 = getbh();
            newobj.入库时间 = DateTime.Now;
        }
        string getbh() {
            string code = "RC" + DateTime.Today.ToString("yyyyMMdd");

            IList list = Client.ClientHelper.TransportSqlMap.GetList("SelectOneStr", "select max(入库单号) from kc_入库单 where 入库单号 like '"+code+"%'");
            if (list.Count > 0 && list[0]!=null) {
                string bh = list[0].ToString().Substring(10);
                bh = (int.Parse("1" + bh) + 1).ToString().Substring(1);
                code += bh;
            } else {
                code+= "001";
            }
            return code;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
            }
        }
    }
}
