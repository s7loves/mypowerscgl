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

namespace Ebada.Exam {
    /// <summary>
    /// 
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCE_LevelStop : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_LevelStop> gridViewOperation;
        private string parentIDA = null;
        private string parentIDB = null;
        private E_Level parentObj;
        public event SendDataEventHandler<E_LevelStop> FocusedRowChanged;

        public UCE_LevelStop()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_LevelStop>(gridControl1, gridView1, barManager1, new FrmE_LevelStopEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_LevelStop>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_LevelStop>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += new FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }

        void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as E_LevelStop);
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_LevelStop> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_LevelStop> e) {
            if (ParentIDB == string.Empty)
            {
                MsgBox.ShowWarningMessageBox("请选添加关卡信息，然后再添加站点信息！");
                e.Cancel = true;
            }
   
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

        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            gridView1.Columns["SeasonID"].ColumnEdit = DicTypeHelper.E_LevelSeason;
            gridView1.Columns["LevelID"].ColumnEdit = DicTypeHelper.E_Level;

            //RefreshData("  order by Sequence asc");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
          


            //hideColumn("ID");
            //gridView1.Columns["Title"].Width = 200;
            //gridView1.Columns["Content"].Width = 500;
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
        public GridViewOperation<E_LevelStop> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_LevelStop newobj) {

            newobj.SeasonID = ParentIDA;
            newobj.LevelID = ParentIDB;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentIDA
        {
            get { return parentIDA; }
            set
            {
                parentIDA = value;
            }
        }
        public string ParentIDB
        {
            get { return parentIDB; }
            set
            {
                parentIDB = value;
               
                RefreshData(" where LevelID='" + value + "'   order by Sequence asc");
               
            }
        }
       
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public E_Level ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    parentIDB = null;
                }
                else
                {
                    ParentIDB = value.ID;
                }
            }
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //if (gridView1.GetFocusedRow()!=null)
            //{
            //    ParentObj = gridView1.GetFocusedRow() as E_LevelStop;
            //}
        }


       
    }
}
