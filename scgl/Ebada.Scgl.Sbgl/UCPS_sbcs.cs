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

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPS_sbcs : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PS_sbcs> gridViewOperation;
        
        public event SendDataEventHandler<PS_sbcs> FocusedRowChanged;
        private string parentID="";
        private PS_sbcs parentObj;
        private bool iszl = false;

        public bool Iszl {
            get { return iszl; }
            set {
                iszl = value;
                gridView1.Columns["xh"].Visible = !value;
            }
        }
        public UCPS_sbcs() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_sbcs>(gridControl1, gridView1, barManager1);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_sbcs>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PS_sbcs>(gridViewOperation_BeforeEdit);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_sbcs>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<PS_sbcs>(gridViewOperation_BeforeInsert);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PS_sbcs> e)
        {
            if (e.ValueOld == null)
                return;
            PS_sbcs sbcs = e.ValueOld as PS_sbcs;
            if(sbcs.ParentID.Trim().Length==0)
                return;
            IList<PS_sbcs> sbcsList = new List<PS_sbcs>();
            sbcsList= Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where parentid='" + sbcs.ID + "'");
            if (sbcsList.Count <= 0)
                return;
            foreach (PS_sbcs cs in sbcsList)
            {
                cs.mc = sbcs.mc;
                Client.ClientHelper.PlatformSqlMap.Update<PS_sbcs>(cs);
            }
            
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<PS_sbcs> e) {
            if (e.Value.ParentID.Length < 5) e.Value.xh = "";

            if(string.IsNullOrEmpty(e.Value.xh))
                e.Value.ID = e.Value.bh;
        }
        private IViewOperation<PS_sbcs> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<PS_sbcs> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    bar3.Visible = false;
                }
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_sbcs> e) {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_sbcs> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_sbcs);
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
            RefreshData(" where xh=''");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            hideColumn("ParentID");
            //hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbox=new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbox.Items.Add("设备");
            cbox.Items.Add("材料");
            gridView1.Columns["c1"].ColumnEdit = cbox;
            gridView1.Columns["c1"].VisibleIndex = 2;
            
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
        public GridViewOperation<PS_sbcs> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_sbcs newobj) {
            newobj.ParentID = parentID;
            CheckExsits(newobj);
            if (parentObj != null ) {
                newobj.c1 = parentObj.c1;
                if (parentObj.bh.Length > 2) {
                    newobj.bh = newobj.ParentID + getbh(8);// parentObj.bh.Substring(0, 2);
                    //newobj.ID = newobj.bh;
                    newobj.mc = parentObj.mc;
                } else  if (parentObj.bh.Length==2){
                    newobj.bh =newobj.ParentID+ getbh(5);
                }
            }
        }

        private static void CheckExsits(PS_sbcs newobj)
        {
            Random rm=new Random();
            PS_sbcs sbcs = null;
            sbcs = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_sbcs>(newobj.ID);
            if (sbcs != null)
            {
                newobj.ID += rm.Next(10, 20);
                CheckExsits(newobj);
            }
            
        }

        private string getbh(int len) {
            string bh = "";
            List<string> list = new List<string>(); 
            foreach (var row in gridViewOperation.BindingList) {
                if(row.bh.Length==len)
                list.Add(row.bh);
            }
            if (list.Count > 0) {
                list.Sort();
                string bh0 = list[list.Count - 1];
                bh0 = bh0.Substring(bh0.Length-3);
                bh = (int.Parse("1" + bh0) + 1).ToString().Substring(1);
            }
            if (bh == "") bh =  "001";
            return bh;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where parentid='"+value+"'");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_sbcs ParentObj {
            get { return parentObj; }
            set {
                
                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.ID;
                }
            }
        }
    }
}
