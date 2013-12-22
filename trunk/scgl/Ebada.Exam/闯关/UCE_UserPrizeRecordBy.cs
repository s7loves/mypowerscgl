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
    public partial class UCE_UserPrizeRecordBy : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_UserPrizeRecord> gridViewOperation;
        private string parentID = null;
        private E_UserPrizeRecord parentObj;
        public event SendDataEventHandler<E_UserPrizeRecord> FocusedRowChanged;

        public UCE_UserPrizeRecordBy()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_UserPrizeRecord>(gridControl1, gridView1, barManager1,new FrmE_UserPrizeRecordEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_UserPrizeRecord>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<E_UserPrizeRecord>(gridViewOperation_BeforeEdit);
            gridView1.FocusedRowChanged += new FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<E_UserPrizeRecord> e)
        {
            e.Value.ExchangeTime = DateTime.Now;
        }

        void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
            {
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as E_UserPrizeRecord);
            }
            CheckDH();

        }
        private void CheckDH()
        {
            E_UserPrizeRecord eur = gridView1.GetFocusedRow() as E_UserPrizeRecord;
            if (eur!=null)
            {
                if (eur.HasFinished)
                {
                    btEdit3.Enabled = false;
                }
                else
                {
                    btEdit3.Enabled = true;
                }
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_UserPrizeRecord> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_UserPrizeRecord> e) {
   
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
            
            string sql = " where UserID='" + MainHelper.User.UserID + "'  order by HasFinished , SendTime desc";
            RefreshData(sql);
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            gridView1.Columns["UserID"].ColumnEdit = DicTypeHelper.UserDic;
            gridView1.Columns["PrizeID"].ColumnEdit = DicTypeHelper.PrizeDic;
            gridView1.Columns["Handler"].ColumnEdit = DicTypeHelper.UserDic;
            
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
        public GridViewOperation<E_UserPrizeRecord> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_UserPrizeRecord newobj) {

           
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                //if (!string.IsNullOrEmpty(value))
                //{
                //    RefreshData(" where ID='" + value + "' order by dxxh");
                //}
                //else
                //{
                //    RefreshData(" where dydj='10' order by dxxh");
                //}
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public E_UserPrizeRecord ParentObj
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

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow()!=null)
            {
                ParentObj = gridView1.GetFocusedRow() as E_UserPrizeRecord;
            }
        }

        private void btEdit3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MsgBox.ShowAskMessageBox("确定要撤销兑换吗？")==DialogResult.OK)
            {

                E_UserPrizeRecord eupr = MainHelper.PlatformSqlMap.GetOneByKey<E_UserPrizeRecord>(ParentObj.ID);

                if (eupr.HasFinished)
                {
                    MsgBox.ShowWarningMessageBox("奖品刚刚发放完成，无法撤销！");
                    return;
                }
                E_Prize eP = MainHelper.PlatformSqlMap.GetOneByKey<E_Prize>(ParentObj.PrizeID);
                eP.CurrentNum += ParentObj.PrizeNum;
                int score = eP.Price * ParentObj.PrizeNum;
                E_UserScoreRecord eusr = new E_UserScoreRecord();
                eusr.UserID = MainHelper.User.UserID;
                eusr.Flag = "+1";
                eusr.Score = score;
                eusr.Reason = "撤销兑换奖品";
                eusr.BySCol4 = "奖品：" + eP.PrizeName + " 数量：" + ParentObj.PrizeNum;
                eusr.CreateTime = DateTime.Now;

                if (eP.Image==null)
                {
                    eP.Image = new byte[] { }; 
                }
                MainHelper.PlatformSqlMap.Delete<E_UserPrizeRecord>(ParentObj);
                MainHelper.PlatformSqlMap.Update<E_Prize>(eP);
                MainHelper.PlatformSqlMap.Create<E_UserScoreRecord>(eusr);
                this.btRefresh.PerformClick();
                MsgBox.ShowSuccessfulMessageBox("撤销成功！");
            }
        }


       
    }
}
