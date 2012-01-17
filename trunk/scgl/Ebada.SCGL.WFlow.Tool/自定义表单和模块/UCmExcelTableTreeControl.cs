/**********************************************
系统:企业ERP
模块:组织机构
作者:Rabbit
创建时间:2011-5-18
最后一次修改:2011-5-19
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Components;
using Ebada.Client;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors.Controls;
using Ebada.Scgl.Core;
using DevExpress.XtraTreeList.Columns;

namespace Ebada.SCGL.WFlow.Tool
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public partial class UCmExcelTableTreeControl : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<LP_Temple> treeViewOperator;
        [Browsable(false)]
        public TreeViewOperation<LP_Temple> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        private IViewOperation<LP_Temple> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<LP_Temple> ChildView
        {
            get { return childView; }
            set {
                childView = value;
            }
        }
        public event SendDataEventHandler<LP_Temple> FocusedNodeChanged;
        public event SendDataEventHandler<LP_Temple> AfterAdd;
        public event SendDataEventHandler<LP_Temple> AfterEdit;
        public event SendDataEventHandler<LP_Temple> AfterDelete;
        public UCmExcelTableTreeControl()
        {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<LP_Temple>(treeList1, barManager1, new SetTaskTableFm());
            
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.BeforeAdd += new ObjectOperationEventHandler<LP_Temple>(treeViewOperator_BeforeAdd);
            treeViewOperator.BeforeEdit += new ObjectOperationEventHandler<LP_Temple>(treeViewOperator_BeforeEdit);
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            
        }
        void treeViewOperator_BeforeEdit(object render, ObjectOperationEventArgs<LP_Temple> e)
        {
            if (treeList1.FocusedNode == null)
            {
                return;
            }
            LP_Temple lp = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as LP_Temple;
            if (lp.CtrlSize == "目录")
            {
                e.Cancel=true;
            }
            
        }
        void treeViewOperator_BeforeAdd(object render, ObjectOperationEventArgs<LP_Temple> e)
        {
            if (treeList1.FocusedNode != null)
            {
                LP_Temple parentlp = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as LP_Temple;
                if (parentlp != null)
                {
                    e.Value.ParentID = parentlp.LPID;
                    string slqwhere = " where   ParentID='" + parentlp.LPID + "'";
                        slqwhere += " and CtrlSize != '目录'";
                        e.Value.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere) + 1;
                }
            }
            //e.Value.CtrlSize = "表单";
        }
        void treeViewOperator_AfterDelete(LP_Temple newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);                
        }

        void treeViewOperator_AfterEdit(LP_Temple newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(LP_Temple newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
            newobj.CtrlSize = "";
            InitData();
        }
        
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as LP_Temple);
        }

        void treeViewOperator_CreatingObject(LP_Temple newobj) {
            //newobj.OrgType = "0";
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Init();
            InitData();
        }
        public void Init() {
            //foreach (TreeListColumn tc in treeList1.Columns)
            //{
            //    tc.Visible = false;
            //}
            //treeList1.Columns["CellName"].Visible = true;
            //treeList1.Columns["OrgType"].ColumnEdit = DicTypeHelper.OrgTypeDic;
            //if (this.Site == null)
            //    InitData();
            //treeList1.Columns["CellName"].Caption = "表名";
            //treeList1.Columns["CellName"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //treeList1.Columns["CellName"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            this.treeList1.KeyFieldName = "LPID";
            //this.treeList1.ParentFieldName = "ParentID";
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData("where parentid = '0' order by cellname");
            //treeViewOperator.RefreshData("where CtrlSize='目录' or ParentID not in (select LPID from LP_Temple where 1=1) order by cellname");
            string slqwhere = "where CtrlSize='目录' or ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') order by CtrlSize desc, SortID";

            IList<LP_Temple> list = MainHelper.PlatformSqlMap.GetList<LP_Temple>(slqwhere);
            foreach (LP_Temple lp in list)
            {
                lp.SignImg = new byte[0];
                lp.ImageAttachment = new byte[0];
                lp.DocContent = new byte[0];
                if (lp.CtrlSize != "目录" && lp.CtrlSize != "")
                {
                    lp.CtrlSize = "";
                    MainHelper.PlatformSqlMap.Update<LP_Temple>(lp);
                }
            }
            this.treeList1.BeginUpdate();
            treeList1.DataSource = list;
            this.treeList1.EndUpdate();
        }
        public bool BarManagerVisible
        {            
            get { return bar1.Visible; }
            set { bar1.Visible = value; }
        }

        private void barAddFloder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTableMulu frm = new frmTableMulu();
            LP_Temple lp = new LP_Temple();
            string slqwhere = " where CtrlSize='目录'  and ParentID not in (select LPID from LP_Temple where 1=1 )  ";
            
            lp.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere) + 1;
            frm.RowData = lp;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MainHelper.PlatformSqlMap.Create<LP_Temple>(lp);
                InitData();
            }
        }

        private void barAddChildFloder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(treeList1.FocusedNode==null)
            {
                return;
            }
            LP_Temple parentlp = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as LP_Temple;
            //LP_Temple lp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(treeList1.FocusedNode["lpid"]);
            frmTableMulu frm = new frmTableMulu();
            if (parentlp == null)
            {
                return;
            }
            if (parentlp.CtrlSize != "目录")
            {
                return;
            }
            string slqwhere = " where   ParentID='" + parentlp.LPID + "' and CtrlSize = '目录'";
            LP_Temple lp = new LP_Temple();
            lp.CtrlSize = "目录";
            lp.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere) + 1;
            lp.ParentID = parentlp.LPID;
            frm.RowData = lp;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MainHelper.PlatformSqlMap.Create<LP_Temple>(lp);
                InitData();
            }
        }

        private void barEditFloder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (treeList1.FocusedNode == null)
            {
                return;
            }
            LP_Temple lp = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as LP_Temple;
            //LP_Temple lp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(treeList1.FocusedNode["lpid"]);
            frmTableMulu frm = new frmTableMulu();
            if (lp == null)
            {
                return;
            }
            if (lp.CtrlSize != "目录")
            {
                return;
            }
            frm.RowData = lp;
            lp.CtrlSize = "目录";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lp.SignImg = new byte[0];
                lp.ImageAttachment = new byte[0];
                lp.DocContent = new byte[0];
                MainHelper.PlatformSqlMap.Update<LP_Temple>(lp);
                InitData();
            }
        }

        private void treeList1_AfterDragNode(object sender, NodeEventArgs e)
        {
            if (treeList1.FocusedNode == null)
            {
                return;
            }
            LP_Temple lp = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as LP_Temple;
            LP_Temple parentlp = treeList1.GetDataRecordByNode(treeList1.FocusedNode.ParentNode) as LP_Temple;
            lp.SignImg = new byte[0];
            lp.ImageAttachment = new byte[0];
            lp.DocContent = new byte[0];
            //LP_Temple lp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(treeList1.FocusedNode["lpid"]);
            //LP_Temple parentlp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(treeList1.FocusedNode.ParentNode["lpid"]);
            if (parentlp.CtrlSize != "目录")
            {
                InitData();
                return;
            }
            lp.ParentID = parentlp.LPID;
            string slqwhere = " where   ParentID='" + parentlp.LPID + "'";
            if (lp.CtrlSize != "目录")
            slqwhere +=  " and CtrlSize != '目录'";
            else
                slqwhere += " and CtrlSize = '目录'";

            lp.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere) + 1;
            MainHelper.PlatformSqlMap.Update<LP_Temple>(lp);
            
        }

        private void treeList1_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            
                LP_Temple lp = treeList1.GetDataRecordByNode(e.Node) as LP_Temple;
                if (lp == null) return;
                if (lp.CtrlSize == "目录")
                {
                    e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
                }
                else
                {
                    e.NodeImageIndex =4;
                }
        }

        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();
        }

      
       

      
    }
}
