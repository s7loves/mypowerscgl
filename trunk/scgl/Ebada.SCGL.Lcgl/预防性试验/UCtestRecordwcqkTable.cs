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
using Ebada.Components;
using DevExpress.Utils;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCtestRecordwcqkTable : DevExpress.XtraEditors.XtraUserControl
    {
        public GridViewOperation<PJ_yfsyjl> gridViewOperation;

        public event SendDataEventHandler<PJ_yfsyjl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private string _type = null;
        public UCtestRecordwcqkTable()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_yfsyjl>(gridControl1, gridView1, barManager1, new frmtestRecordwcqkEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
        }

        void gridViewOperation_AfterDelete(PJ_yfsyjl obj)
        {

            IList<PJ_yfsyjl> li = MainHelper.PlatformSqlMap.GetListByWhere<PJ_yfsyjl>(" where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type + "' order by xh");
            int i=1;
            List<PJ_yfsyjl> list = new List<PJ_yfsyjl>();
            foreach (PJ_yfsyjl ob in li)
            {
                ob.xh = i;
                i++;
                list.Add(ob); 
            }
            List<SqlQueryObject> list3 = new List<SqlQueryObject>();
            if (list.Count > 0)
            {
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray ());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            RefreshData(" where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type  + "'  order by xh ");
        }

        void gridViewOperation_AfterAdd(PJ_yfsyjl obj)
        {
            obj.xh = MainHelper.PlatformSqlMap.GetRowCount<PJ_yfsyjl>(" where OrgCode='" + obj.OrgCode + "' and  type='" + obj.type + "'");
            obj.CreateDate = DateTime.Now;
            MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(obj);
            RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'  order by xh ");
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (_type != null )
                {

                    gridView1.Columns["sbCapacity"].VisibleIndex = 4;
                    gridView1.Columns["sl"].VisibleIndex = 4;
                    gridView1.OptionsView.AllowCellMerge = false; 
                        switch (_type)
                    {
                        case "变压器":
                            hideColumn("sl");
                            hideColumn("sbCapacity", true);
                            break;
                        case "断路器":
                            hideColumn("sbCapacity");
                            hideColumn("sl", true);

                            break;

                        case "避雷器":
                            hideColumn("sbCapacity");
                            hideColumn("sl", true);
                            break;

                        case "电容器":
                            hideColumn("sbCapacity");
                            hideColumn("sl", true);
                            gridView1.OptionsView.AllowCellMerge = true; 
                            break;



                    }
                    RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'  order by xh ");
                }

            }
        }
       
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_yfsyjl> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_yfsyjl> e)
        {
            if (parentID == null)
            {
                e.Cancel = true;
            }
            else
            {
                e.Value.type = _type;
                e.Value.OrgCode = parentObj.OrgCode;
                e.Value.OrgName = parentObj.OrgName; 
            }
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_yfsyjl);
        }
        private void hideColumn(string colname)
        {
            //gridView1.Columns[colname].Visible = false;
            hideColumn(colname, false);
        }
        private void hideColumn(string colname, bool ishide)
        {
            gridView1.Columns[colname].Visible = ishide;
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

            //需要隐藏列时在这写代码

            hideColumn("OrgCode");
            hideColumn("OrgName");
            hideColumn("gzrjID");
            hideColumn("type");
            hideColumn("charMan");
            hideColumn("syMan");
            hideColumn("CreateDate");
            hideColumn("preExpTime");
            hideColumn("Remark");
            gridView1.Columns["planExpTime"].Caption = "计划试验时间";
            foreach (GridColumn gc in gridView1.Columns)
            {
                gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshData()
        {
            gridViewOperation.RefreshData("where OrgCode='" + ParentID + "'  and type='" + _type + "'  order by xh ");
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_yfsyjl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_yfsyjl newobj)
        {
            if ( parentID == null)
            {
                return;
            }
           
           
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
                if (!string.IsNullOrEmpty(value) )
                {
                    RefreshData(" where OrgCode='" + value + "'  and type='" + _type + "'  order by xh ");

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
            //if (PSObj!=null&&gridView1.RowCount>0)
            //{
            //     IList<PJ_yfsyjl> pjlist=new List<PJ_yfsyjl>();
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        pjlist.Add(gridView1.GetRow(i) as PJ_yfsyjl);
            //    }
            //    Export14.ExportExcel(PSObj, pjlist);
            //}

            IList<PJ_yfsyjl> datalist = gridView1.DataSource as IList<PJ_yfsyjl>;
            switch (_type)
            {
                case "变压器":
                    Export11.ExportExcelbyqwcqk(datalist, _type + "预防性试验完成情况报表", parentID);
                    break;
                case "断路器":
                    Export11.ExportExceldlqwcqk(datalist, _type + "预防性试验完成情况报表", parentID);
                    break;
                case "避雷器":
                    Export11.ExportExcelblqwcqk(datalist, _type + "预防性试验完成情况报表", parentID);
                    break;
                case "电容器":
                    Export11.ExportExceldrqwcqk(datalist, _type + "预防性试验完成情况报表", parentID);
                    break;
            }
        }

        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            PJ_yfsyjl ob = gridView1.GetFocusedRow() as PJ_yfsyjl;
            switch (_type)
            {
                case "变压器":
                case "断路器":
                case "避雷器":
                    frmtestRecordwcqkEdit fm = new frmtestRecordwcqkEdit();
                    fm.Type = _type;
                    fm.RowData = ob;
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(ob);

                    }
                    break;

                case "电容器":
                    frmtestRecorddrqwcqkEdit fm2 = new frmtestRecorddrqwcqkEdit();
                    fm2.Type = _type;
                    fm2.RowData = ob;
                    if (fm2.ShowDialog() == DialogResult.OK)
                    {
                        MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(ob);

                    }
                    break;
            }
        }
    }
}
