/**********************************************
系统:计划管理
模块:年计划
作者:Rabbit
创建时间:2012-9-12
最后一次修改:2012-9-15
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
    /// 工程类别管理
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCJH_weekks : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<JH_weekks> gridViewOperation;

        public event SendDataEventHandler<JH_weekks> FocusedRowChanged;
        private string parentID;
        private mOrg org;
        private string type1="1";//1-区分科室、2-供电所
        private string type2 = "全年计划";
        private bool 全局 = false;
        string filter = "";

        UCJH_monthks ucjh_year;
        public UCJH_weekks() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<JH_weekks>(gridControl1, gridView1, barManager1,true);
            
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            //btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<JH_weekks>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<JH_weekks>(gridViewOperation_BeforeAdd);
            barEditItem1.EditValueChanged += new EventHandler(barEditItem1_EditValueChanged);
            gridView1.IndicatorWidth = 40;//设置显示行号的列宽
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsSelection.EnableAppearanceFocusedCell = true;
            treeList1.OptionsSelection.InvertSelection = true;
            org = MainHelper.UserOrg;
            //splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            gridViewOperation.AfterAdd += new ObjectEventHandler<JH_weekks>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<JH_weekks>(gridViewOperation_BeforeEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<JH_weekks>(gridViewOperation_AfterDelete);
            createcontrol();
            btExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btExport1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void gridViewOperation_AfterDelete(JH_weekks obj) {
            //恢复列表
            if (obj.计划种类.Contains("一")) {
                JH_monthks ks = Client.ClientHelper.PlatformSqlMap.GetOneByKey<JH_monthks>(obj.c2);
                if (ks != null) {
                    ks.可选标记 = "";
                    ClientHelper.PlatformSqlMap.Update<JH_monthks>(ks);
                }
            }
        }
        void createcontrol() {
            UCJH_monthks ks = new UCJH_monthks(全局);
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
            ks.RowDoubleClicked += new SendDataEventHandler<JH_monthks>(ks_RowDoubleClicked);
        }
        void ks_RowDoubleClicked(object sender, JH_monthks obj) {
            if (parentID == null || parentID.Length!=7) {
                MsgBox.ShowAskMessageBox("请先选择计划周");
                return;
            }
            foreach (JH_weekks jh in gridViewOperation.BindingList){
                if (obj.ID == jh.c2) return;
            }
            JH_weekks addjh = new JH_weekks();
            //ConvertHelper.CopyTo(obj, addjh);

            Type t = addjh.GetType();
            Type t2 = obj.GetType();
            foreach (PropertyInfo p in t.GetProperties()) {

                p.SetValue(addjh, t2.GetProperty(p.Name).GetValue(obj, null), null);

            }
            addjh.ID = addjh.CreateID();
            addjh.c2 = obj.ID;
            addjh.完成标记 = "未完成";
            addjh.完成时间 = DateTime.Now;
            addjh.ParentID = parentID;
            Client.ClientHelper.PlatformSqlMap.Create<JH_weekks>(addjh);
            gridViewOperation.BindingList.Add(addjh);
            if (obj.计划种类.Contains("一")) {
                obj.可选标记 = "否";
                Client.ClientHelper.PlatformSqlMap.Update<JH_monthks>(obj);
            }
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
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<JH_weekks> e) {
            if (e.Value.计划分类 != type2 ||e.Value.单位分类 != type1) {

                MsgBox.ShowAskMessageBox("此记录不能修改");
                return;
            }
        }

        void gridViewOperation_AfterAdd(JH_weekks obj) {
            return;
            
        }
        JH_weekks createjh(mOrg o,JH_weekks s) {
            JH_weekks jh = new JH_weekks();
            ConvertHelper.CopyTo(s, jh);
            jh.ID = jh.CreateID();
            jh.单位代码 = o.OrgCode;
            jh.单位名称 = o.OrgName;
            jh.c2 = s.ID;
            jh.单位分类 = "9";//下发任务

            return jh;
        }
        //全局计划
        public Control showtype0() {
            type1 = "0";
            type2 = "全年";
            return this; 
        }
        //全局临时计划
        public Control showtype00() {
            type1 = "0";
            type2 = "临时";
            return this;
        }
        //科室计划
        public Control showtype1() {
            type1 = "1";
            type2 = "全年";
            return this;
        }
        //各科室计划
        public Control showtype11() {
            type1 = "1";
            type2 = "临时";
            return this;
        }
        //所
        public Control showtype2() {
            type1 = "2";
            type2 = "全年";
            return this;
        }
        //所
        public Control showtype22() {
            type1 = "2";
            type2 = "临时";
            return this;
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
            barStaticItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }
        public Control showtype(string where) {
            filter = where;
           


            return this;
        }
        JH_yearkst ParentOBJ = new JH_yearkst();
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            JH_yearkst org = treeList1.GetDataRecordByNode(e.Node) as JH_yearkst;
            if (org != null && org.年.Length>6) {

                ParentID = org.年;
                ParentOBJ = org;
                ucjh_year.showread(全局 ? "0" : "", ParentID.Substring(0,6));    
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
            RefreshData("where 1>2");
            inittree(year);

            ucjh_year.showread(全局 ? "0" : "", "");      
        }

        void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e) {
            
        }


        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<JH_weekks> e) {
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

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<JH_weekks> e) {

            
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as JH_weekks);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            IList list= Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select 年 from jh_yearkst where parentid='0'");

            repositoryItemComboBox1.Items.AddRange(list);

            IList<mOrg> list2 = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where 1>0 order by OrgCode,OrgType");

            foreach (mOrg org in list2)
            {
                this.repositoryItemCheckedComboBoxEdit1.Items.Add(org.OrgName, CheckState.Unchecked, true);
            }

            //IList<mOrg> list2= Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='0' and c3='是'");
            //list2.Add(new mOrg() {OrgID="0", OrgCode = "0", OrgName = "全部" });
            //treeList1.DataSource = list2;
            //treeList1.KeyFieldName = "OrgID";
            //treeList1.ParentFieldName = "ParentID";
            //RefreshData("");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {
        //     private string _单位代码=String.Empty; 
        //private string _单位名称=String.Empty; 
        //private string _计划项目=String.Empty; 
        //private string _实施内容=String.Empty; 
        //private string _主要负责人=String.Empty; 
        //private string _参加人员=String.Empty; 
        //private DateTime _预计时间=new DateTime(1900,1,1); 
        //private DateTime _预计时间2=new DateTime(1900,1,1); 
        //private string _计划种类=String.Empty; 
        //private string _计划分类=String.Empty; 
        //private string _完成标记=String.Empty; 
        //private DateTime _完成时间=new DateTime(1900,1,1); 
        //private string _总结提升=String.Empty; 
        //private string _未完成原因=String.Empty; 
        //private string _可选标记=String.Empty; 
        //private string _单位分类=String.Empty; 
            //需要隐藏列时在这写代码
            gridView1.Columns["c2"].Visible = false;
            gridView1.Columns["c1"].Caption = "计划完成部门";
            //gridView1.Columns["c2"].Caption = "合作任务ID";
            gridView1.Columns["预计时间"].Caption = "开始日期";
            gridView1.Columns["预计时间2"].Caption = "结束日期";

            gridView1.Columns["c3"].Visible = false;
            //gridView1.Columns["单位名称"].Visible = false;
            gridView1.Columns["c4"].Visible = false;
            gridView1.Columns["ParentID"].Visible = false;
            //gridView1.Columns["未完成原因"].Visible = false;
            gridView1.Columns["单位代码"].Visible = false;
            //gridView1.Columns["计划分类"].Visible = false;
            //gridView1.Columns["预计时间"].Visible = false;
            //gridView1.Columns["预计时间2"].Visible = false;
            //gridView1.Columns["完成标记"].Visible = false;
            //gridView1.Columns["完成时间"].Visible = false;
            //gridView1.Columns["总结提升"].Visible = false;
            gridView1.Columns["可选标记"].Visible = false;
            gridView1.Columns["单位分类"].Visible = false;
            gridView1.Columns["c5"].Visible = false;
            gridView1.Columns["计划分类"].Visible = false;

            RepositoryItemComboBox box1 = new RepositoryItemComboBox();
            box1.Items.AddRange(new string[] { "常规计划", "临时计划" });
            gridView1.Columns["计划种类"].ColumnEdit = box1;

            box1 = new RepositoryItemComboBox();
            box1.Items.AddRange(new string[] { "完成", "未完成" });
            gridView1.Columns["完成标记"].ColumnEdit = box1;
            //box1 = new RepositoryItemComboBox();
            //box1.Items.AddRange(new string[] { "全年计划", "临时计划" });
            //gridView1.Columns["计划分类"].ColumnEdit = box1;
        }
        private IViewOperation<JH_weekks> childView2;

        public IViewOperation<JH_weekks> ChildView2 {
            get { return childView2; }
            set {
                childView2 = value; if (value != null) {
                    bar3.Visible = false;
                }
            }
        }

        private IViewOperation<JH_weekks> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IViewOperation<JH_weekks> ChildView {
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
        public GridViewOperation<JH_weekks> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(JH_weekks newobj) {
            newobj.ParentID = parentID;
            newobj.单位分类 = type1;
            if (org != null) {
                newobj.单位代码 = org.OrgCode;
                newobj.单位名称 = org.OrgName;
                newobj.c1 = org.OrgName;
            }
            newobj.计划种类 = "常规计划";
            newobj.计划分类 = type2;
            newobj.预计时间 = DateTime.Today;
            newobj.预计时间2 = DateTime.Today;
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
                string where = "where parentid like '" + value + "%'";
                if (全局) {}
                else{
                    //if(!string.IsNullOrEmpty(type1))
                    //where += " and (单位分类='9' or 单位分类='" + type1 + "')";
                    if (org != null)
                        where += " and 单位代码='" + org.OrgCode + "'";
                }

                RefreshData(where);
            }
        }

        private void btExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<JH_weekks> list1 = new List<JH_weekks>();// gridView1.DataSource as IList<JH_weekks>;
            for (int i = 0; i < gridView1.RowCount; i++) {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is JH_weekks)
                    list1.Add(row as JH_weekks);
            } ExportPDCA.ExportExcelWeek(ParentOBJ, list1);
        }
        private void btExport1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<JH_weekks> list1 = new List<JH_weekks>();// gridView1.DataSource as IList<JH_weekks>;
            for (int i = 0; i < gridView1.RowCount; i++) {
                var row = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                if (row is JH_weekks)
                    list1.Add(row as JH_weekks);
            } ExportPDCA.ExportExcelWeek(ParentOBJ, list1);
        }

        private void btJZ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (MsgBox.ShowAskMessageBox("此操作将未完成的计划转至下一期") == DialogResult.OK) {

                foreach (var item in gridViewOperation.BindingList) {
                    if (item.完成标记 != "完成") {
                        int pid = int.Parse(item.ParentID) + 1;
                        JH_yearkst kst = ClientHelper.PlatformSqlMap.GetOneByKey<JH_yearkst>(pid.ToString());
                        if (kst == null) {
                            if (item.ParentID.Length == 7) {
                                pid = int.Parse(item.ParentID.Substring(0, 6)) + 1;
                                kst = ClientHelper.PlatformSqlMap.GetOneByKey<JH_yearkst>(pid.ToString());
                            }
                        }
                        if (kst != null) {
                            item.ParentID = kst.ID;
                            ClientHelper.PlatformSqlMap.Update<JH_weekks>(item);
                        }
                    }
                }
                btRefresh.PerformClick();
            }
        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            string[] orgname = barEditItem2.EditValue.ToString().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
            string prID = ParentID;
            string sqlWhere = "";
            if (prID != null)
            {
                sqlWhere = "where parentid='" + prID + "'";
            }
            if (orgname.Length > 0)
            {
                if (sqlWhere == "")
                {
                    sqlWhere = "where 单位名称 in (";
                }
                else
                {
                    sqlWhere = sqlWhere + " and 单位名称 in (";
                }
                for (int i = 0; i < orgname.Length; i++)
                {
                    if (i != orgname.Length - 1)
                    {
                        sqlWhere = sqlWhere + "'" + orgname[i].Trim() + "',";
                    }
                    else
                    {
                        sqlWhere = sqlWhere + "'" + orgname[i].Trim() + "')";
                    }

                }
            }
            
            RefreshData(sqlWhere);
        }
    }
}
