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
   
   
    public partial class UCSD_ddxljqnr : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjls_ddxljqnr> gridViewOperation;

        public event SendDataEventHandler<sdjls_ddxljqnr> FocusedRowChanged;
        
        private string parentID = null;
        private sdjls_ddxljq parentObj;
        public UCSD_ddxljqnr()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_ddxljqnr>(gridControl1, gridView1, barManager1, new frm_ddxljqnr());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjls_ddxljqnr>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjls_ddxljqnr>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjls_ddxljqnr> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjls_ddxljqnr> e)
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjls_ddxljqnr);
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
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            foreach (GridColumn col in gridView1.Columns)
            {
                col.Visible = false;
            }
            int m = 0;
            gridView1.Columns["gth"].VisibleIndex = m++;
            gridView1.Columns["dj"].VisibleIndex = m++;
            gridView1.Columns["xb"].VisibleIndex = m++;
            gridView1.Columns["ljxs"].VisibleIndex = m++;
            gridView1.Columns["djzwz"].VisibleIndex = m++;
            gridView1.Columns["ddxxh"].VisibleIndex = m++;
            gridView1.Columns["ljqxh"].VisibleIndex = m++;
            gridView1.Columns["sccj"].VisibleIndex = m++;
            gridView1.Columns["bz"].VisibleIndex = m++;
            
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
        public GridViewOperation<sdjls_ddxljqnr> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjls_ddxljqnr newobj)
        {
            if (parentID == null) return;
            newobj.ParentID = parentID;
            newobj.c1 = parentObj.LineCode;
            newobj.c2 = parentObj.OrgCode;
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
                    RefreshData(" where ParentID='" + value + "'");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sdjls_ddxljq ParentObj
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
                    ParentID = value.ID;
                }
            }
        }
    }
}
