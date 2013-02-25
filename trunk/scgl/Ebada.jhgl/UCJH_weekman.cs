/**********************************************
系统:计划管理
模块:年计划
作者:Rabbit
创建时间:2013-2-8
最后一次修改:2013-2-8
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
using System.Collections;
using DevExpress.XtraEditors.Repository;
using Ebada.Core;

namespace Ebada.jhgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCJH_weekman : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<JH_weekman> gridViewOperation;

        public event SendDataEventHandler<JH_weekman> FocusedRowChanged;
        private string parentID;
        private mOrg org;
        private string type1="1";//1-区分科室、2-供电所
        private string type2 = "全年计划";
        private bool 全局 = false;
        string filter = "";

        private JH_weekmant parentObj;
        public UCJH_weekman() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<JH_weekman>(gridControl1, gridView1, barManager1,new frmJH_weekmanEdit());
            
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            //btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<JH_weekman>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<JH_weekman>(gridViewOperation_BeforeAdd);
            gridView1.IndicatorWidth = 40;//设置显示行号的列宽
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            //treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            //treeList1.OptionsBehavior.Editable = false;
            //treeList1.OptionsSelection.EnableAppearanceFocusedCell = true;
            //treeList1.OptionsSelection.InvertSelection = true;
            org = MainHelper.UserOrg;
            //splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            gridViewOperation.AfterAdd += new ObjectEventHandler<JH_weekman>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<JH_weekman>(gridViewOperation_BeforeEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<JH_weekman>(gridViewOperation_AfterDelete);
            createcontrol();
            btExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btExport1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            bar3.Visible = false;
            
        }

        public JH_weekmant ParentObj {
            get { return parentObj; }
            set {
                parentObj = value;
                if (value != null)
                    ParentID = value.ID;
                else {
                    ParentID = null;
                }
            }
        }

        void gridViewOperation_AfterDelete(JH_weekman obj) {
            //恢复列表
            
        }
        void createcontrol() {
            
        }
        
        void inittree(string year) {
            
        }
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<JH_weekman> e) {
            
        }

        void gridViewOperation_AfterAdd(JH_weekman obj) {
            return;
            
        }
        JH_weekman createjh(mOrg o,JH_weekman s) {
            JH_weekman jh = new JH_weekman();
            ConvertHelper.CopyTo(s, jh);
            jh.ID = jh.CreateID();
            jh.单位代码 = o.OrgCode;
            jh.单位名称 = o.OrgName;
            jh.c2 = s.ID;

            return jh;
        }
        
        public Control showall() {
            全局 = true;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }
        public Control showdw() {
            全局 = false;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }
        public Control showtype(string where) {
            filter = where;
           


            return this;
        }
        
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            
        }

        void treeList1_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e) {

            
            
        }
        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e) {
            //设置显示行数
            if (e.Info.IsRowIndicator) {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.ImageIndex = -1;
            }
        }
        

        void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e) {
            
        }


        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<JH_weekman> e) {
            if (parentID == null) {
                e.Cancel = true;

                //MsgBox.ShowAskMessageBox("请先选择计划年份");
                return;

            }
           
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<JH_weekman> e) {

            
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as JH_weekman);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            IList list= Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select 年 from jh_yearkst where parentid='0'");

            repositoryItemComboBox1.Items.AddRange(list);

        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {
            //需要隐藏列时在这写代码
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["预计时间"].Caption = "开始日期";
            gridView1.Columns["预计时间2"].Caption = "结束日期";

            gridView1.Columns["c3"].Visible = false;
            gridView1.Columns["c4"].Visible = false;
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["单位代码"].Visible = false;
            gridView1.Columns["可选标记"].Visible = false;
            gridView1.Columns["c5"].Visible = false;

            RepositoryItemComboBox box1 = new RepositoryItemComboBox();
            box1 = new RepositoryItemComboBox();
            box1.Items.AddRange(new string[] { "完成", "未完成" });
            gridView1.Columns["完成标记"].ColumnEdit = box1;

            //box1 = new RepositoryItemComboBox();
            //box1.Items.AddRange(new string[] { "全年计划", "临时计划" });
            //gridView1.Columns["计划分类"].ColumnEdit = box1;
        }
        private IViewOperation<JH_weekman> childView2;

        public IViewOperation<JH_weekman> ChildView2 {
            get { return childView2; }
            set {
                childView2 = value; if (value != null) {
                    bar3.Visible = false;
                }
            }
        }

        private IViewOperation<JH_weekman> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IViewOperation<JH_weekman> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    bar3.Visible = false;
                    bar1.Visible = false;
                    gridView1.OptionsBehavior.Editable = false;
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
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<JH_weekman> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(JH_weekman newobj) {
            newobj.ParentID = parentID;
            if (org != null) {
                newobj.单位代码 = org.OrgCode;
                newobj.单位名称 = org.OrgName;
            }
            newobj.预计时间 = parentObj.开始日期;
            newobj.预计时间2 = ParentObj.结束日期;
            
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                if (value == null) {
                    RefreshData("where 1>1");
                    return;
                }
                parentID = value;
                string where = "where parentid = '" + value + "'";
                bool flag = ParentObj.姓名 == MainHelper.User.UserName;

                btAdd.Enabled = flag;
                btDelete.Enabled = flag;
                gridView1.OptionsBehavior.Editable = flag;

                RefreshData(where);
            }
        }

        private void btExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ParentObj == null) return;
            IList<JH_weekman> list1 = gridView1.DataSource as IList<JH_weekman>;
            ExportPDCA.ExportExcelWeekMan(ParentObj, list1);
        }
        private void btExport1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ParentObj == null) return;
            IList<JH_weekman> list1 = gridView1.DataSource as IList<JH_weekman>;
            ExportPDCA.ExportExcelWeekMan(ParentObj, list1);
        }

        private void btJZ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
           
        }
    }
}
