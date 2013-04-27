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

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_05 : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjls_fsgyxjl> gridViewOperation;

        private string parentID;
        private mOrg parentObj;
        public UCSD_05()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_fsgyxjl>(gridControl1, gridView1, barManager1, new frmSD_fsyyxjl());
            
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
               
            }


        }
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
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
                string strSQL = "where OrgCode='" + MainHelper.UserOrg.OrgCode + "' order by ID desc";
                RefreshData(strSQL);
            }
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            gridView1.Columns["kssj"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["kssj"].DisplayFormat.FormatString = "HH:mm:ss";
            gridView1.Columns["jssj"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["jssj"].DisplayFormat.FormatString = "HH:mm:ss";

            hideColumn("OrgCode");
            hideColumn("OrgName");
            hideColumn("yxtmID");
            hideColumn("jljpj");
            hideColumn("ndcs");
            hideColumn("qzldr");
            hideColumn("qzjhr");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
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
        public GridViewOperation<sdjls_fsgyxjl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
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
                    RefreshData(" where OrgCode ='" + value + "' order by ID desc");
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
                    ParentID = value.OrgCode;
                }
            }
        }



        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                sdjls_fsgyxjl OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjls_fsgyxjl;
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
                    //ExportSD26.ExportExcel(OBJECT);
                }

            }
        }

        private void btView_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                sdjls_fsgyxjl OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjls_fsgyxjl;
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
                    Export_fsgyx.ExportExcel(OBJECT);
                }
            }
        }

        private void btAdds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(parentID))
                return;
            frmSD_fsyyxjl frm = new frmSD_fsyyxjl();
            sdjls_fsgyxjl fsgyx = new sdjls_fsgyxjl();
            fsgyx.OrgCode = parentID;
            fsgyx.OrgName = ParentObj.OrgName;
            fsgyx.yxdw = ParentObj.OrgName;
            frm.RowData = fsgyx;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<sdjls_fsgyxjl>(frm.RowData);
                RefreshData("");
            }
        }
    }
}
