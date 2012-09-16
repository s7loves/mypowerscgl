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
    public partial class UCJH_yearks : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<JH_yearks> gridViewOperation;

        public event SendDataEventHandler<JH_yearks> FocusedRowChanged;
        private string parentID;
        private mOrg org;
        private string type1="";//1-区分科室、2-供电所
        private string type2 = "";
        private bool 全局 = false;
        string filter = "";
        public UCJH_yearks() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<JH_yearks>(gridControl1, gridView1, barManager1,new frmJH_yearksEdit());
            
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            //btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<JH_yearks>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<JH_yearks>(gridViewOperation_BeforeAdd);
            barEditItem1.EditValueChanged += new EventHandler(barEditItem1_EditValueChanged);
            gridView1.IndicatorWidth = 40;//设置显示行号的列宽
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsSelection.EnableAppearanceFocusedCell = true;
            treeList1.OptionsSelection.InvertSelection = true;
            org = MainHelper.UserOrg;
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            gridViewOperation.AfterAdd += new ObjectEventHandler<JH_yearks>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<JH_yearks>(gridViewOperation_BeforeEdit);
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<JH_yearks> e) {
            if (e.Value.计划分类 != type2 ||e.Value.单位分类 != type1) {

                MsgBox.ShowAskMessageBox("此记录不能修改");
                return;
            }
        }

        void gridViewOperation_AfterAdd(JH_yearks obj) {
            string[] dws = obj.c1.Split("、".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb =new StringBuilder();
            bool hasgds = false;
            bool hasbds = false;
            foreach (var s in dws) {
                if (s == org.OrgName) continue;
                
                sb.Append("'" + s + "',");
            }
            IList<mOrg> list = new List<mOrg>();
            if (sb.Length > 2) {
                string str= sb.ToString(0,sb.Length -1);

                list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgname in (" + str + ")");
                
            }
            if (list.Count > 0) {

                List<JH_yearks> listadd = new List<JH_yearks>();
                foreach (var o in list) {
                    IList<mOrg> list2 =Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where parentid='"+o.OrgID+"'");
                    if (list2.Count > 0) {
                        foreach(var o2 in list2){
                            listadd.Add(createjh(o2, obj));
                        }
                    } else {
                        listadd.Add(createjh(o,obj));
                    }
                }
                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(listadd.ToArray(), null, null);
            }

        }
        JH_yearks createjh(mOrg o,JH_yearks s) {
            JH_yearks jh = new JH_yearks();
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
            btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }
        public Control showdw() {
            全局 = false;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            return this;
        }
        public Control showtype(string where) {
            filter = where;
           


            return this;
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            org = treeList1.GetDataRecordByNode(e.Node) as mOrg;
            if (org != null && org.OrgCode == "0") org = null;

            ParentID = parentID;
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
            ParentID = barEditItem1.EditValue.ToString();
        }

        void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e) {
            
        }


        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<JH_yearks> e) {
            if (string.IsNullOrEmpty(type1) || string.IsNullOrEmpty(type2)) {
                e.Cancel = true;
                MsgBox.ShowAskMessageBox("操作非法，增加失败!");
                return;
            }
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

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<JH_yearks> e) {

            
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as JH_yearks);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            IList list= Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select 年 from jh_yearkst where parentid='0'");

            repositoryItemComboBox1.Items.AddRange(list);

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
            gridView1.Columns["未完成原因"].Visible = false;
            gridView1.Columns["单位代码"].Visible = false;
            //gridView1.Columns["计划分类"].Visible = false;
            //gridView1.Columns["预计时间"].Visible = false;
            //gridView1.Columns["预计时间2"].Visible = false;
            gridView1.Columns["完成标记"].Visible = false;
            gridView1.Columns["完成时间"].Visible = false;
            gridView1.Columns["总结提升"].Visible = false;
            gridView1.Columns["可选标记"].Visible = false;
            gridView1.Columns["单位分类"].Visible = false;
            gridView1.Columns["c5"].Visible = false;


            //RepositoryItemComboBox box1 = new RepositoryItemComboBox();
            //box1.Items.AddRange(new string[] {"常规计划","一次性计划" });
            //gridView1.Columns["计划种类"].ColumnEdit = box1;
            //box1 = new RepositoryItemComboBox();
            //box1.Items.AddRange(new string[] { "全年计划", "临时计划" });
            //gridView1.Columns["计划分类"].ColumnEdit = box1;
        }
        private IViewOperation<JH_yearks> childView2;

        public IViewOperation<JH_yearks> ChildView2 {
            get { return childView2; }
            set {
                childView2 = value; if (value != null) {
                    bar3.Visible = false;
                }
            }
        }

        private IViewOperation<JH_yearks> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IViewOperation<JH_yearks> ChildView {
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
        public GridViewOperation<JH_yearks> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(JH_yearks newobj) {
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
                string where = "where parentid='" + value + "'";
                if (全局) {}
                else{
                    if(!string.IsNullOrEmpty(type1))
                        where += " and (单位分类='9' or 单位分类='" + type1 + "')";
                    if (org != null)
                        where += " and 单位代码='" + org.OrgCode + "'";
                    if (!string.IsNullOrEmpty(type2)) {
                        where += " and 计划分类='" + type2 + "'";
                    }
                }

                RefreshData(where);
            }
        }
    }
}
