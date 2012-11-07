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

namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_05jckyjl : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PJ_05jckyjl> gridViewOperation;
        
        public event SendDataEventHandler<PJ_05jckyjl> FocusedRowChanged;
        private string parentID=null;
        private PJ_05jcky parentObj;
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
               // liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btEdit.Enabled = !value;
                btDelete.Enabled = !value;

            }
        }

        public UCPJ_05jckyjl() {
            InitializeComponent();
            bar3.Visible = false;
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_05jckyjl>(gridControl1, gridView1, barManager1, new frmjckyjlEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_05jckyjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_05jckyjl>(gridViewOperation_BeforeDelete);
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_05jckyjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_05jckyjl>(gridViewOperation_AfterEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_05jckyjl>(gridViewOperation_AfterDelete);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;

        }

        void gridViewOperation_AfterDelete(PJ_05jckyjl obj)
        {
            Delqxmx(obj.ID);
        }

        void gridViewOperation_AfterEdit(PJ_05jckyjl obj)
        {
            Addqxmx(obj);
        }

        void gridViewOperation_AfterAdd(PJ_05jckyjl obj)
        {
            Addqxmx(obj);
        }
        //处理缺陷明细  lgmqx
        private void Addqxmx(PJ_05jckyjl obj)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(obj.ID);
            if (obj.jr != "合格")
            {
                if (tempobj == null || tempobj.xcr == string.Empty)
                {
                    MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                    PJ_qxfl mx = new PJ_qxfl();
                    mx.ID = obj.ID;
                    mx.OrgCode = parentObj.OrgCode;
                    mx.OrgName = parentObj.OrgName;
                    mx.LineID = "06";
                    mx.LineName = parentObj.LineID;
                    mx.xlqd = parentObj.gtID;
                    mx.xssj = obj.clrq;
                    mx.xsr = obj.clrqz;
                    mx.qxly = "交叉跨越及对地距离测量记录";
                    mx.qxnr = "交叉跨越及对地距离测量不合格";
                    if (obj.scz<parentObj.gdjl*0.5M)
                    {
                        mx.qxlb = "重大缺陷";
                    }
                    else
	                {
                        mx.qxlb = "一般缺陷";
	                }
                    

                    MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                }

            }
            else
            {
                if (tempobj != null && tempobj.xcr == string.Empty)
                {
                    MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                }

            }

        }
        private void Delqxmx(string id)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(id);
            if (tempobj != null && tempobj.xcr == string.Empty)
            {
                MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(id);
            }
        }
        private IViewOperation<PJ_05jckyjl> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<PJ_05jckyjl> ChildView {
            get { return childView; }
            set {
                childView = value;
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_05jckyjl> e) {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_05jckyjl> e) {
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_05jckyjl);
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
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            //gridView1.Columns[7].Visible = false;
            hideColumn("gzrjID");
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
        public GridViewOperation<PJ_05jckyjl> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_05jckyjl newobj) {
            if (parentID == null) return;
            newobj.jckyID = parentID;
            newobj.CreateDate = DateTime.Now;

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
                    RefreshData(" where jckyID='" + value + "' order by CreateDate");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PJ_05jcky ParentObj {
            get { return parentObj; }
            set {
                
                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.jckyID;
                }
            }
        }
    }
}
