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

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPS_kg : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_kg> gridViewOperation;

        public event SendDataEventHandler<PS_kg> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        //private PS_kg _parentobj;
        public UCPS_kg()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_kg>(gridControl1, gridView1, barManager1,new frmkgEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_kg>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_kg>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PS_kg>(gridViewOperation_AfterAdd);
            bar3.Visible = false;
            btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void gridViewOperation_AfterAdd(PS_kg obj)
        {
            //RefreshData("where byqID='" + PSObj.byqID + "'");
        }
   
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_kg> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_kg> e)
        {
            //if (parentID == null)
            //    e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];
            
            if (org != null)
            {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
                //RefreshData("select * from dbo.PS_kg a,dbo.PS_gt b ,dbo.PS_xl c where  a.gtID=b.gtID and b.LineCode=c.LineCode and c.OrgCode='" + org.OrgCode + "'");
                //RefreshData(" where  PS_kg.gtID=PS_gt.gtID and PS_gt.LineCode=PS_xl.LineCode and PS_xl.OrgCode='" + org.OrgCode + "'");
                IList<PS_kg> blist = Client.ClientHelper.PlatformSqlMap.GetList<PS_kg>("SelectPS_kgByStr", "select * from dbo.PS_kg a,dbo.PS_gt b ,dbo.PS_xl c where  a.gtID=b.gtID and  b.LineCode=c.LineCode and lEFT(c.LineCode,'" + org.OrgCode .Length+ "')='" + org.OrgCode + "'");
                gridControl1.DataSource = blist;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_kg);
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
            RefreshData("");
            //需要初始化数据时在这写代码
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            //hideColumn("OrgCode");
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
        public GridViewOperation<PS_kg> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_kg newobj)
        {
            //if (parentID == null) return;
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            //newobj.CreateDate = DateTime.Now;
            //newobj.CreateMan = MainHelper.LoginName;
            //if (PSObj==null)
            //{
            //    return;
            //}
            //newobj.byqID = PSObj.byqID;
            //newobj.tqID = "123";
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
                if (!string.IsNullOrEmpty(value))
                {
                   // RefreshData(" where OrgCode='" + value + "' order by id desc");
                    RefreshData("");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    parentID = null;
                }
                else
                {
                    ParentID = value.OrgID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                Export12.ExportExcel(gridView1.GetFocusedRow() as PS_kg);
            }
           
           
        }
    }
}
