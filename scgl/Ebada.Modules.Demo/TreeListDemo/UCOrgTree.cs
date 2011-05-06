/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-22
最后一次修改:2011-2-28
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
using Ebada.Platform.Model;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Core;
using DevExpress.XtraTreeList.Columns;

namespace Ebada.Client.Module.Org
{
    /// <summary>
    /// TreeList数据操作示例
    /// </summary>
    public partial class UCOrgTree : DevExpress.XtraEditors.XtraUserControl
    {
        TreeViewOperation<VOrgLevel> treeViewOperator;

        public TreeViewOperation<VOrgLevel> TreeViewOperator
        {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        public event SendDataEventHandler<VOrgLevel> FocusedNodeChanged;
        public event SendDataEventHandler<VOrgLevel> AfterAdd;
        public event SendDataEventHandler<VOrgLevel> AfterEdit;
        public event SendDataEventHandler<VOrgLevel> AfterDelete;

        public UCOrgTree()
        {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<VOrgLevel>(treeList1, barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
        }

        void treeViewOperator_AfterDelete(VOrgLevel newobj)
        {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(VOrgLevel newobj)
        {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(VOrgLevel newobj)
        {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as VOrgLevel);
        }

        void treeViewOperator_CreatingObject(VOrgLevel newobj)
        {
            newobj.Org_ID = new mOrg().CreateID();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            treeList1.KeyFieldName = "Org_ID";
            treeList1.ParentFieldName = "ParentID";
            treeList1.OptionsBehavior.Editable = false;
            this.SetColumn(treeList1.Columns);
            if(this.Site==null)
                InitData();
            
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            treeList1.DataSource = null;
            treeViewOperator.RefreshData("order by parentid,Sequence");
            treeList1.DataSource = treeViewOperator.BindingList;
        }

        public void InitData(string orgid)
        {
            this.InitTreeList(this.treeList1, orgid);
        }

        private void InitTreeList(DevExpress.XtraTreeList.TreeList treeList, string orgid)
        {

            treeList1.DataSource = null;
            treeViewOperator.BindingList.Clear();
            IList<VOrgLevel> orgList = ClientHelper.PlatformSqlMap.GetList<VOrgLevel>("GetVOrgLevelTreeByOrgID", orgid);
            treeViewOperator.BindingList.Add(orgList);
            treeList1.DataSource = treeViewOperator.BindingList;            
        }

        public void SetColumn(TreeListColumnCollection columns)
        {
            foreach (TreeListColumn col in columns)
            {

                if (col.FieldName == "Org_ID")
                    col.Visible = false;

                if (col.FieldName == "OrgL_ID")
                    col.Visible = false;

                if (col.FieldName == "Sequence")
                    col.Visible = false;

                if (col.FieldName == "ParentID")
                    col.Visible = false;

                if (col.FieldName == "State")
                    col.Visible = false;

                if (col.FieldName == "OrgCode")
                {
                    col.Caption = "编号";
                    col.VisibleIndex = 0;
                }

                if (col.FieldName == "cnName")
                {
                    col.Caption = "中文名称";
                    col.VisibleIndex = 1;
                }

                if (col.FieldName == "cnFullName")
                {
                    col.Caption = "中文全名";
                    col.VisibleIndex = 2;
                }

                if (col.FieldName == "enName")
                {
                    col.Caption = "英文名称";
                    col.VisibleIndex = 3;
                }

                if (col.FieldName == "enFullName")
                {
                    col.Caption = "英文全名";
                    col.VisibleIndex = 4;
                }

                if (col.FieldName == "Postcode")
                {
                    col.Caption = "邮政编码";
                    col.VisibleIndex = 5;
                }

                if (col.FieldName == "Address")
                {
                    col.Caption = "地址";
                    col.VisibleIndex = 6;
                }

                if (col.FieldName == "Website")
                {
                    col.Caption = "网址";
                    col.VisibleIndex = 7;
                }

                if (col.FieldName == "Enabled")
                {
                    col.Caption = "启用";
                    col.VisibleIndex = 8;
                }

                if (col.FieldName == "Remark")
                {
                    col.Caption = "备注";
                    col.VisibleIndex = 9;
                }

                if (col.FieldName == "CityCode")
                {
                    col.Caption = "城市编码";
                    col.VisibleIndex = 10;
                }

                if (col.FieldName == "OurCompany")
                {
                    col.Caption = "公司概况";
                    col.VisibleIndex = 11;
                }

                if (col.FieldName == "RowVersion")
                {
                    col.Visible = false;
                }
            }
        }
    }
}
