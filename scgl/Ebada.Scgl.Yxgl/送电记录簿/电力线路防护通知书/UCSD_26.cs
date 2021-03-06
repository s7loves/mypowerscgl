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
    public partial class UCSD_26 : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjl_26> gridViewOperation;

        public event SendDataEventHandler<sdjl_26> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCSD_26()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_26>(gridControl1, gridView1, barManager1, new frmSD26Edit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_26>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<sdjl_26>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_26>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_26> e)
        {

        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<sdjl_26> e)
        {
            if (e.Value.BigData == null)
            {
                e.Value.BigData = new byte[0];
            }

        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_26> e)
        {
            if (parentID == null)
                e.Cancel = true;
            
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
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_26);
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
            //RefreshData("");
            if (MainHelper.UserOrg != null)
            {
                string strSQL = "where ParentID='" + MainHelper.UserOrg.OrgCode + "' order by ID desc";
                RefreshData(strSQL);
            }
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码


            hideColumn("ParentID");
            hideColumn("gzrjID");
            hideColumn("BigData");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
            hideColumn("xybh");

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjl_26> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_26 newobj)
        {
            if (parentID == null) return;
            newobj.ParentID = parentID;
            //newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;

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
                    RefreshData(" where ParentID ='" + value + "' order by ID desc");
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
            if (gridView1.FocusedRowHandle > -1)
            {
                sdjl_26 OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjl_26;
                if (OBJECT!= null)
                {
                    #region 注释的部分
                    //if (OBJECT.BigData.Length != 0)
                    //{
                    //    DSOFramerControl ds1 = new DSOFramerControl();
                    //    ds1.FileData = OBJECT.BigData;
                    //    string fname = ds1.FileName;
                    //    ds1.FileClose();
                    //    // ds1.FileOpen(ds1.FileName);
                    //    ExcelAccess ex = new ExcelAccess();


                    //    ex.Open(fname);
                    //    //此处写填充内容代码

                    //    ex.ShowExcel();
                    //}
                    //else
                    //{
                    //    Export26.ExportExcel(OBJECT);
                    //}

                    #endregion
                    ExportSD26.ExportExcel(OBJECT);
                }

            }
        }

        private void btView_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                sdjl_26 OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjl_26;
                if (OBJECT != null)
                {
                    #region 注释的部分
                    //if (OBJECT.BigData.Length != 0)
                    //{
                    //    DSOFramerControl ds1 = new DSOFramerControl();
                    //    ds1.FileData = OBJECT.BigData;
                    //    string fname = ds1.FileName;
                    //    ds1.FileClose();
                    //    // ds1.FileOpen(ds1.FileName);
                    //    ExcelAccess ex = new ExcelAccess();


                    //    ex.Open(fname);
                    //    //此处写填充内容代码

                    //    ex.ShowExcel();
                    //}
                    //else
                    //{
                    //    Export26.ExportExcel(OBJECT);
                    //}

                    #endregion
                    ExportSD26.ExportExcel(OBJECT);
                }
            }
        }
    }
}
