/**********************************************
系统:企业ERP
模块:变电所维护
作者:Rabbit
创建时间:2011-5-20
最后一次修改:2011-5-20
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

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 变电所
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCBD_SBTZ_ZL : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<BD_SBTZ_ZL> gridViewOperation;
        
        public event SendDataEventHandler<BD_SBTZ_ZL> FocusedRowChanged;
        private string parentID;
        public UCBD_SBTZ_ZL() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<BD_SBTZ_ZL>(gridControl1, gridView1, barManager1);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridView1.Click += new EventHandler(gridView1_Click);
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
        }

        void gridView1_Click(object sender, EventArgs e) {
            if (FocusedRowChanged != null && focusedRow!=gridView1.GetFocusedRow()) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as BD_SBTZ_ZL);
            }
        }

        void treeViewOperator_BeforeInsert(object render, ObjectOperationEventArgs<BD_SBTZ_ZL> e) {
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (gridView1.RowCount > 0)
                gridView1.SelectRow(0);
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        object focusedRow;
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as BD_SBTZ_ZL);
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            RefreshData("order by id" );
            gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            //gridView1.Columns["OrgType"].Visible = false;
            //gridView1.Columns["ParentID"].Visible = false;

            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;
            }
            gridView1.Columns["mc"].Visible = true;
            gridView1.Columns["dm"].Visible = true;
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
        public GridViewOperation<BD_SBTZ_ZL> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(BD_SBTZ_ZL newobj) {
           
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
            }
        }

        public void HideList() {
            bar1.Visible = false;
            bar3.Visible = false;
        }
    }
}
