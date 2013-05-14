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
using System.Threading;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
   
    public partial class UCSD_ddxljq : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjls_ddxljq> gridViewOperation;

        public event SendDataEventHandler<sdjls_ddxljq> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCSD_ddxljq()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_ddxljq>(gridControl1, gridView1, barManager1, new frm_ddxljq());
            
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            
        }
       

       
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null) {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }


        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjls_ddxljq);
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            
            hideColumn("OrgCode");
            hideColumn("LineCode");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
            gridView1.Columns["jcrq"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["jcrq"].DisplayFormat.FormatString = "yyyy-MM-dd";
            
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjls_ddxljq> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjls_ddxljq newobj) {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.jcrq = DateTime.Now;
           
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
                    RefreshData(" where OrgCode='" + value + "' order by id desc");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.OrgID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.GetFocusedRow() == null)
                return;
            sdjls_ddxljq ljq = this.gridView1.GetFocusedRow() as sdjls_ddxljq;
            IList<sdjls_ddxljqnr> ljqnrList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sdjls_ddxljqnr>("where ParentID='" + ljq.ID + "'");
            if (ljqnrList == null)
                return;
            ExportDdxljq.ExportExcel(ljq, ljqnrList);

        }
    }
}
