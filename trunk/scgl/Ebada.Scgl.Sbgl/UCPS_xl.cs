/**********************************************
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
    public partial class UCPS_xl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_xl> gridViewOperation;

        public event SendDataEventHandler<PS_xl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmxlEdit frm = new frmxlEdit();
        private string parentID = null;
        private mOrg parentObj;
        string mLineCode=string.Empty;
        string mOrgCode=string.Empty;
        private mOrg _mOrg = null;
        public UCPS_xl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_xl>(gridControl1, gridView1, barManager1, frm);
            //gridViewOperation.AfterEdit += new ObjectEventHandler<PS_xl>(gridViewOperation_AfterEdit);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PS_xl>(gridViewOperation_BeforeUpdate);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.CellValueChanged += new CellValueChangedEventHandler(gridView1_CellValueChanged);
        }

        void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            PS_xl obj = gridView1.GetRow(e.RowHandle) as PS_xl;
            if (obj!=null)
            {
                Client.ClientHelper.PlatformSqlMap.Update<PS_xl>(obj);
            }
        }

        void gridViewOperation_AfterEdit(PS_xl obj)
        {
            if (obj!=null)
            {
                Client.ClientHelper.PlatformSqlMap.Update<PS_xl>(obj);
            }
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PS_xl> e)
        {

        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_xl> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_xl> e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);     
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }



        void btXlList_EditValueChanged(object sender, EventArgs e)
        {
//                 frm.LineCode = btXlList.EditValue.ToString();
//                 IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + btXlList.EditValue.ToString() + "'");
//                 repositoryItemLookUpEdit3.DataSource = list;
//                 ParentObj = null;
//                 if (frm.LineCode.Length == 6) {
//                     //RefreshData(string.Format("where left(tqcode,{0})='{1}'", frm.LineCode.Length, frm.LineCode));
//                     RefreshData(string.Format("where xlcode='{0}'", frm.LineCode));
//                     //gridViewOperation.BindingList.Add(Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>(string.Format("where xlcode2='{0}'", frm.LineCode)));
//                 } else {
//                     RefreshData(string.Format("where xlcode2='{0}'",frm.LineCode));
//                 }
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            _mOrg = null;
            if (list.Count > 0)
                _mOrg = list[0];

//             frm.LineCode = string.Empty;
            if (_mOrg != null)
            {
                //frm.GdsCode = _mOrg.OrgCode;               
                ParentID = _mOrg.OrgCode;                           
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_xl);
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
            foreach (GridColumn gc in gridView1.Columns)
            {
                hideColumn(gc.FieldName);
            }
            gridView1.Columns["LineName"].Visible = true;
            gridView1.Columns["LineP"].Visible = true;
            gridView1.Columns["LineQ"].Visible = true;
            gridView1.Columns["K"].Visible = true;
            gridView1.Columns["TotalT"].Visible = true;
            //需要隐藏列时在这写代码
            //hideColumn("ParentID");
            //hideColumn("gzrjID");
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
        public GridViewOperation<PS_xl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
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
                    RefreshData(" where orgCode='" + value + "' and LineVol = '10' order by LineName");
                }
                else
                {
                    string tempstr = " 235@$U#u#$";
                    RefreshData(" where orgCode='" + tempstr + "' and LineVol = '10'  order by tqName");
                }
            }
        }
        /// <summary>
        /// 隐藏下选择列表
        /// </summary>
        public void HideList()
        {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;   
            //bar3.Visible = false;
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
                    ParentID = null;
                }
                else
                {
                    ParentID = value.OrgCode;               
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
//             if (gridView1.FocusedRowHandle>=0)
//             {
//                 gridControl1.ExportToExcelOld("C:\\temp.xls");
//                 System.Diagnostics.Process.Start("C:\\temp.xls");
//             }
           
           
        }
        PS_xl mXL = null;
        public PS_xl GetXL() {

//             if (!string.IsNullOrEmpty(frm.LineCode)) {
//                 if (mXL != null && mXL.LineCode == frm.LineCode) {
//                     
//                 } else {
//                     mXL = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + frm.LineCode + "'");
//                 }
//             }
             return mXL;
        }
        public mOrg GetmOrg() {

            return _mOrg;
        }

    }
}
