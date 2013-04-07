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

namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    /// 变电所
    /// </summary>
   
    public partial class ucmOrg : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<mOrg> gridViewOperation;

        public event SendDataEventHandler<mOrg> FocusedRowChanged;
        private string parentID;
        public ucmOrg()
        {
            InitializeComponent();
           
            
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            gridView1.Click += new EventHandler(gridView1_Click);
        }

        void gridView1_Click(object sender, EventArgs e)
        {
            if (FocusedRowChanged != null && focusedRow != gridView1.GetFocusedRow())
            {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as mOrg);
            }
        }

        void treeViewOperator_BeforeInsert(object render, ObjectOperationEventArgs<mOrg> e)
        {
            e.Value.OrgID = e.Value.OrgCode;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

           
            InitData();//初始数据
            InitColumns();//初始列
            if (gridView1.RowCount > 0)
                gridView1.SelectRow(0);
        }
        

        object focusedRow;
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null && focusedRow != gridView1.GetFocusedRow())
            {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as mOrg);
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            RefreshData(" where parentid='300' order by orgcode");
            gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            //gridView1.Columns["OrgType"].Visible = false;
            //gridView1.Columns["ParentID"].Visible = false;

            foreach (GridColumn c in gridView1.Columns)
            {
                c.Visible = false;
            }
            gridView1.Columns["OrgName"].Visible = true;

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridControl1.DataSource=Client.ClientHelper.PlatformSqlMap.GetListByWhere<mOrg>(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<mOrg> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(mOrg newobj)
        {
            newobj.OrgType = "2";
            newobj.ParentID = "300";
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
            }
        }

        internal void SetShowOrg(mOrg mOrg)
        {
            gridViewOperation.BindingList.Clear();
            gridViewOperation.BindingList.Add(mOrg);
        }
        /// <summary>
        /// 隐藏选择列表
        /// </summary>
        public void HideList()
        {
            
        }
    }
}
