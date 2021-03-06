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
    public partial class UCPJ_25main : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_25> gridViewOperation;

        public event SendDataEventHandler<PJ_25> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCPJ_25main()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_25>(gridControl1, gridView1, barManager1, new frm25Edit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_25>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_25>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_25>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_25> e)
        {
            if (e.Value.BigData == null)
            {
                e.Value.BigData = new byte[0];
            }

        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_25> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_25> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }
          

        }
        public void initcoment()
        {
            InitColumns();//初始列
            InitData();//初始数据
          
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_25);
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
        public GridViewOperation<PJ_25> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_25 newobj)
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                frm25Template frm = new frm25Template();
                frm.pjobject = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_25;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Client.ClientHelper.PlatformSqlMap.Update<PJ_25>(frm.pjobject);
                   MessageBox.Show("保存成功");
                }
            }
            
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
               PJ_25 OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_25;
               if (OBJECT.BigData!=null)
                {
                    if (OBJECT.BigData.Length!=0)
                   {
                       DSOFramerControl ds1 = new DSOFramerControl();
                       ds1.FileData = OBJECT.BigData;
                      // ds1.FileOpen(ds1.FileName);
                     
                       string fname = ds1.FileName;
                       ds1.FileClose(); 
                       ExcelAccess ex = new ExcelAccess();

                       ex.Open(fname);
                       //此处写填充内容代码
                       IList<PJ_25zbdymx> list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='" + OBJECT.ID + "'and Type='发电机'");
                       IList<PJ_25zbdymx> list1 = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='" + OBJECT.ID + "'and Type='原动机'");
                       for (int i = 0; i < list.Count; i++)
                       {
                           ex.SetCellValue(list[i].xh, 26 + i, 1);
                           ex.SetCellValue(list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 2);
                           ex.SetCellValue(list[i].dy.ToString(), 26 + i, 3);
                           ex.SetCellValue(list[i].azrq.ToString(), 26 + i, 4);
                           ex.SetCellValue(list[i].sccj, 26 + i, 5);
                       }
                       for (int i = 0; i < list1.Count; i++)
                       {
                           ex.SetCellValue(list[i].xh, 26 + i, 8);
                           ex.SetCellValue(list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 11);
                           ex.SetCellValue(list[i].dy.ToString(), 26 + i, 12);
                           ex.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i, 13);
                           ex.SetCellValue(list[i].sccj, 26 + i, 14);
                       }
                       ex.ShowExcel();
                   }
                    else
                    {
                        Export25.ExportExcel(OBJECT);
                    }
                 
                }
               else
               {
                   Export25.ExportExcel(OBJECT);
               }
            }
        }

        private void btView_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                PJ_25 OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_25;
                Export25.ExportExcel(OBJECT);
                //if (OBJECT.BigData != null)
                //{
                //    if (OBJECT.BigData.Length != 0)
                //    {
                //        DSOFramerControl ds1 = new DSOFramerControl();
                //        ds1.FileData = OBJECT.BigData;
                //        // ds1.FileOpen(ds1.FileName);
                //        ExcelAccess ex = new ExcelAccess();

                //        string fname = ds1.FileName;

                //        ex.Open(fname);
                //        //此处写填充内容代码
                //        IList<PJ_25zbdymx> list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='" + OBJECT.ID + "'and Type='发电机'");
                //        IList<PJ_25zbdymx> list1 = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='" + OBJECT.ID + "'and Type='原动机'");
                //        for (int i = 0; i < list.Count; i++)
                //        {
                //            ex.SetCellValue(list[i].xh, 26 + i, 1);
                //            ex.SetCellValue("'"+list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 2);
                //            ex.SetCellValue(list[i].dy.ToString(), 26 + i, 3);
                //            ex.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i, 4);
                //            ex.SetCellValue(list[i].sccj, 26 + i, 5);
                //        }
                //        for (int i = 0; i < list1.Count; i++)
                //        {
                //            ex.SetCellValue(list[i].xh, 26 + i, 8);
                //            ex.SetCellValue("'" + list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 11);
                //            ex.SetCellValue(list[i].dy.ToString(), 26 + i, 12);
                //            ex.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i, 13);
                //            ex.SetCellValue(list[i].sccj, 26 + i, 14);
                //        }
                //        ds1.FileClose();
                //        ex.ShowExcel();
                //    }
                //    else
                //    {
                //        Export25.ExportExcel(OBJECT);
                //    }

                //}
                //else
                //{
                //    Export25.ExportExcel(OBJECT);
                //}
            }
        }
    }
}
