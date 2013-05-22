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
using System.IO;

namespace Ebada.jhgl {
    /// <summary>
    /// 员工工作写实
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCJH_weekmant : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<JH_weekmant> gridViewOperation;

        public event SendDataEventHandler<JH_weekmant> FocusedRowChanged;
        private string parentID;
        private mOrg org;
        private string type1="1";//1-区分科室、2-供电所
        private bool 全局 = false;
        private bool 部门 = false;
        string filter = "";

        UCJH_weekman ucjh_year;
        public UCJH_weekmant() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<JH_weekmant>(gridControl1, gridView1, barManager1,true);
            
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<JH_weekmant>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<JH_weekmant>(gridViewOperation_BeforeAdd);
            barEditItem1.EditValueChanged += new EventHandler(barEditItem1_EditValueChanged);
            gridView1.IndicatorWidth = 40;//设置显示行号的列宽
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsSelection.EnableAppearanceFocusedCell = true;
            treeList1.OptionsSelection.InvertSelection = true;
            org = MainHelper.UserOrg;
            //splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            gridViewOperation.AfterAdd += new ObjectEventHandler<JH_weekmant>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<JH_weekmant>(gridViewOperation_BeforeEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<JH_weekmant>(gridViewOperation_AfterDelete);
            createcontrol();
            btExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btExport1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.FocusedRowChanged += new SendDataEventHandler<JH_weekmant>(UCJH_weekmant_FocusedRowChanged);
            splitContainerControl1.SplitterPosition += 60;
            bar1.Visible = true;
        }

        void UCJH_weekmant_FocusedRowChanged(object sender, JH_weekmant obj) {
            ucjh_year.ParentObj = obj;
        }

        void gridViewOperation_AfterDelete(JH_weekmant obj) {
            //恢复列表
            
        }
        void createcontrol() {
            UCJH_weekman ks = new UCJH_weekman();
            ks.Dock = DockStyle.Fill;
            ucjh_year = ks;
            SplitContainerControl split = new SplitContainerControl();
            split.Dock = DockStyle.Fill;
            split.Horizontal = false;
            split.FixedPanel = SplitFixedPanel.Panel2;
            split.Parent = splitContainerControl1.Panel2;
            split.SplitterPosition = 200;
            ks.Parent = split.Panel2;
            gridControl1.Parent = split.Panel1;
            this.ChildView = ks.GridViewOperation;
        }
        
        void inittree(string year) {
            treeList1.Columns[0].Caption = "周期";
            treeList1.Columns[0].FieldName = "标题";
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            IList<JH_yearkst> list = Client.ClientHelper.PlatformSqlMap.GetList<JH_yearkst>("where parentid like '" + year + "%'");
            treeList1.BeginInit();
            treeList1.DataSource = list;
            treeList1.EndInit();
            treeList1.Refresh();
        }
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<JH_weekmant> e) {
            
        }

        void gridViewOperation_AfterAdd(JH_weekmant obj) {
            return;
            
        }
        JH_weekmant createjh(mOrg o,JH_weekmant s) {
            JH_weekmant jh = new JH_weekmant();
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
            部门 = true;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }
        public Control showtype(string where) {
            filter = where;
           


            return this;
        }
        JH_yearkst parentOBJ = new JH_yearkst();

        public JH_yearkst ParentOBJ {
            get { return parentOBJ; }
            set { 
                parentOBJ = value;

                ParentID = value.年;
                if (gridViewOperation.BindingList.Count == 0 && (!全局&&!部门)) {
                    btAdd.PerformClick();
                }
                gridView1.Columns["考核结果"].OptionsColumn.AllowEdit = gridView1.RowCount>1;
            }
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            JH_yearkst org = treeList1.GetDataRecordByNode(e.Node) as JH_yearkst;
            if (org != null && org.年.Length>6) {

                ParentOBJ = org;
                //ucjh_year.showread(全局 ? "0" : "", ParentID.Substring(0, 6));    
            }
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
        void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            string year = barEditItem1.EditValue.ToString();
            parentID = null;
            RefreshData(" and 1>2");
            inittree(year);

            //ucjh_year.showread(全局 ? "0" : "", "");      
        }

        void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e) {
            
        }


        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<JH_weekmant> e) {
            if (parentID == null) {
                e.Cancel = true;

                MsgBox.ShowAskMessageBox("请先选择计划年份");
                return;

            }
            if (org == null) {
                e.Cancel = true;

                MsgBox.ShowAskMessageBox("请先选择计划部门");
            }
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<JH_weekmant> e) {

            
        }
        
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitColumns();//初始列
            InitData();//初始数据
            string y = DateTime.Now.Year.ToString();
            foreach (string v in repositoryItemComboBox1.Items) {
                if (v == y) {
                    barEditItem1.EditValue = v; break;
                }
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as JH_weekmant);
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
            gridView1.Columns["c3"].Visible = false;
            gridView1.Columns["ParentID"].Visible = false;
            gridView1.Columns["单位代码"].Visible = false;
            gridView1.Columns["考核人"].Visible = false;
            gridView1.Columns["考核时间"].Visible = false;
            gridView1.Columns["年月周"].Visible = false;
            gridView1.Columns["月总分"].Visible = false;
            gridView1.Columns["年总分"].Visible = false;
            RepositoryItemComboBox box1 = new RepositoryItemComboBox();
            box1.Items.AddRange(new string[] { "A", "B","C","D" });
            gridView1.Columns["考核结果"].ColumnEdit = box1;
            //gridView1.OptionsBehavior.Editable = false;
            foreach (GridColumn c in gridView1.Columns) {
                c.OptionsColumn.AllowEdit = false;
            }
            
            
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
                    //bar1.Visible = false;
                    //gridView1.OptionsBehavior.Editable = false;
                }
            }
        }
        
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            //gridViewOperation.RefreshData(slqwhere);
            gridViewOperation.BindingList.Clear();
            gridViewOperation.BindingList.Add(ClientHelper.PlatformSqlMap.GetList<JH_weekmant>("SelectJH_weekmantList2", slqwhere));

        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<JH_weekmant> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(JH_weekmant newobj) {
            newobj.ParentID = parentID;
            if (org != null) {
                newobj.单位代码 = org.OrgCode;
                newobj.单位名称 = org.OrgName;
            }
            newobj.标题 = ParentOBJ.标题;
            newobj.年月周 = ParentOBJ.年;
            newobj.开始日期 = ParentOBJ.开始日期;
            newobj.结束日期 = ParentOBJ.结束日期;
            newobj.姓名 = MainHelper.User.UserName;
            newobj.职务 = MainHelper.User.PostName;
            newobj.c1 = MainHelper.User.UserCode;
            newobj.考核结果 = "A";
            
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                if (value == null) return;
                parentID = value;
                string where = "  and a.parentid = '" + value + "' ";
                if (全局) {
                    where += string.Format(" and (a.单位代码 in (select orgcode from vroleorg where roleid in (select roleid from ruserrole where userid='{0}'))) and ( a.职务 like '%部长' or a.职务 like '%主任' or a.职务 like '%所长') ", MainHelper.User.UserID);
                }else if (部门) {
                    where += string.Format(" and a.单位代码 in (select orgcode from vroleorg where roleid in (select roleid from ruserrole where userid='{0}')) ", MainHelper.User.UserID);
                } else {
                    where += " and a.姓名='" + MainHelper.User.UserName + "'";
                }
                RefreshData(where);
            }
        }

        private void btExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucjh_year.ParentObj == null) return;
            IList<JH_weekman> list1 = ChildView.BindingList;
            ExportPDCA.ExportExcelWeekMan(ucjh_year.ParentObj, list1);
        }
        private void btExport1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucjh_year.ParentObj == null) return;
            IList<JH_weekman> list1 = ChildView.BindingList;
            ExportPDCA.ExportExcelWeekMan1(ucjh_year.ParentObj, list1);
        }

        private void btJZ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
           
        }
    }
}
