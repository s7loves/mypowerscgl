﻿/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
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
using Ebada.Scgl.Core;

namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCsd_jcky : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_05jcky> gridViewOperation;

        public event SendDataEventHandler<PJ_05jcky> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmjckyEdit frm = new frmjckyEdit();
        private string parentID = null;
        private sd_gt parentObj;
        public UCsd_jcky()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_05jcky>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_05jcky>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_05jcky>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_05jcky> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_05jcky> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            btXlList.EditValueChanged += new EventHandler(btXlList_EditValueChanged);
            btGtList.EditValueChanged += new EventHandler(btGtList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGtList_EditValueChanged(object sender, EventArgs e)
        {
            parentID = btGtList.EditValue.ToString();
            if (parentID != "")
            {
                IList<sd_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where gtID='" + parentID + "'");
                sd_gt gt = null;
                if (list.Count > 0)
                {
                    gt = list[0];
                    ParentObj = gt;
                }
            }
        }

        void btXlList_EditValueChanged(object sender, EventArgs e)
        {
      
                IList<sd_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='" + btXlList.EditValue.ToString() + "'");
                repositoryItemLookUpEdit3.DataSource = list;
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];
            
            if (org != null)
            {
               
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
            }
            

        }
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_05jcky);
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
        }
        /// <summary>
        /// 隐藏下选择列表
        /// </summary>
        public void HideList()
        {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            hideColumn("LineID");
            hideColumn("gtID");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_05jcky> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_05jcky newobj)
        {
            if (parentID == null) return;
            newobj.gtID = parentID;
            newobj.kygh = parentObj.gth;
            newobj.LineID = parentObj.LineCode;
            newobj.OrgCode = parentObj.LineCode.Substring(0, 3);
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + newobj.OrgCode + "'");
            if (org != null)
                newobj.OrgName = org.OrgName;
   
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where gtID='" + value + "'");
                }
                else
                {
                    RefreshData(" where 1>1");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sd_gt ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    ParentID = null;
                }
                else
                {
                    ParentID = value.gtID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle>=0)
            {
                gridControl1.ExportToXls("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }
           
           
        }
    }
}
