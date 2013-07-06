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
using System.Collections;

namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    /// 
    /// </summary>
    
    public partial class Ucm_ksjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<bdjl_ksjl> gridViewOperation;

        public event SendDataEventHandler<bdjl_ksjl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public Ucm_ksjl()
        {
            InitializeComponent();
            bar3.Visible = false;
            initImageList();
            gridViewOperation = new GridViewOperation<bdjl_ksjl>(gridControl1, gridView1, barManager1,new frm_ksjlEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<bdjl_ksjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<bdjl_ksjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        private IViewOperation<bdjl_ksnr> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<bdjl_ksnr> ChildView
        {
            get { return childView; }
            set
            {
                childView = value;
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<bdjl_ksjl> e)
        {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
            if (gridView1.GetFocusedRow() == null)
                return;
            bdjl_ksjl ksjl = gridView1.GetFocusedRow() as bdjl_ksjl;
            IList<bdjl_ksnr> ksnrList = new List<bdjl_ksnr>();
            ksnrList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_ksnr>("where ParentID='" + ksjl.ID + "'");
            if (ksnrList.Count > 0)
            {
                MsgBox.ShowWarningMessageBox("请先删除考试内容!");
                e.Cancel = true;
            }
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<bdjl_ksjl> e)
        {
            if (parentID == null)
                e.Cancel = true;
            if (string.IsNullOrEmpty(baruser.EditValue as string))
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null&& MainHelper.UserOrg.OrgType=="1") {//如果是供电所人员，则锁定
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
                ICollection ryList = ComboBoxHelper.GetGdsRy(org.OrgCode);//获取供电所人员列表
                this.repositoryItemComboBox1.Items.AddRange(ryList);
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as bdjl_ksjl);
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

            //需要隐藏列时在这写代码
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
            hideColumn("Bkrqz");
            hideColumn("Kswyhzr");
            hideColumn("Wy");
            hideColumn("TotalEvaluate");
            hideColumn("Kswyhjl");
            hideColumn("Orgcode");
            hideColumn("Orgname");
            hideColumn("Sequence");
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
        public GridViewOperation<bdjl_ksjl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(bdjl_ksjl newobj)
        {
            if (parentID == null) return;
            if (string.IsNullOrEmpty(baruser.EditValue as string))
                return;
            mUser user= Client.ClientHelper.PlatformSqlMap.GetOne<mUser>("where username='" + baruser.EditValue as string + "'");
            if (user == null)
            {
                MsgBox.ShowWarningMessageBox("数据库中不存在该员工！");
                return;
            }
            newobj.UserName = user.UserName;
            newobj.PostName = user.PostName;
            newobj.Ksrq = DateTime.Now;
            newobj.Orgcode = parentID;
            newobj.Orgname = parentObj.OrgName;
           
               
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
                    RefreshData(" where Orgcode='" + value + "'");
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
            if (gridView1.GetFocusedRow() != null)
            {
                bdjl_ksjl ksjl= gridView1.GetFocusedRow() as bdjl_ksjl;
                IList<bdjl_ksnr> ksList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_ksnr>("where parentID='" + ksjl.ID + "'");
                if (ksList == null || ksList.Count == 0)
                {
                    MsgBox.ShowWarningMessageBox("请先填写考试内容!");
                    return;
                }
                ExportBDksjl.ExportExcel(ksjl);
                   
            }
        }
    }
}
