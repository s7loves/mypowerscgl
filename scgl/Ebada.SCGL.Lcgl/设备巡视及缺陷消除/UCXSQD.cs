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

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCXSQD : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_sbxsqd> gridViewOperation;

        public event SendDataEventHandler<PJ_sbxsqd> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        frmxsDialog fdialog = null;
        public UCXSQD()
        {
            InitializeComponent();
            fdialog = new frmxsDialog();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_sbxsqd>(gridControl1, gridView1, barManager1, fdialog);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_sbxsqd>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_sbxsqd>(gridViewOperation_BeforEdit);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_sbxsqd>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        void gridViewOperation_BeforEdit(object render, ObjectOperationEventArgs<PJ_sbxsqd> e)
        {
            if (ParentID==null)
            {
                e.Cancel = true;
            }
            fdialog.orgcode = parentObj.OrgID;
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_sbxsqd> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_sbxsqd> e)
        {
            if (parentID == null)
                e.Cancel = true;
            
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_sbxsqd);
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

            //hideColumn("OrgCode");
            hideColumn("LineCode");
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
        public GridViewOperation<PJ_sbxsqd> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_sbxsqd newobj)
        {
            if (parentID == null) return;
            fdialog.orgcode = parentObj.OrgID;
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            //newobj.CreateDate = DateTime.Now;
            //Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            //newobj.CreateMan = m_UserBase.RealName;
            //newobj.xssj = DateTime.Now;
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
                    RefreshData(" where LineCode in(select lineid from ps_xl where OrgCode='" + value+ "')");
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
            //frm06sbxsLine frm = new frm06sbxsLine();
            //frm.orgcode = btGdsList.EditValue.ToString();
            //if (frm.ShowDialog()==DialogResult.OK)
            //{

            //    IList<PJ_sbxsqd> pj06list = new List<PJ_sbxsqd>();
            //    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_sbxsqd>(" where LineName='" + frm.linename + "'");
            //    Export06.ExportExcel(pj06list);
            //}
            
            
            
           
        }
    }
}
