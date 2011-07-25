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
    public partial class UCPJ_18gysbpjmx : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_18gysbpjmx> gridViewOperation;

        public event SendDataEventHandler<PJ_18gysbpjmx> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private PJ_18gysbpj _parentobj;
        public UCPJ_18gysbpjmx()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_18gysbpjmx>(gridControl1, gridView1, barManager1,new frm18gysbpjmxEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_18gysbpjmx>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_18gysbpjmx>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_18gysbpjmx>(gridViewOperation_AfterAdd);
        }

        void gridViewOperation_AfterAdd(PJ_18gysbpjmx obj)
        {
            RefreshData(" where PJ_ID='" + PSObj.PJ_ID + "' order by id desc");
          
        }
      
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_18gysbpjmx> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_18gysbpjmx> e)
        {
            if (PSObj == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //InitColumns();//初始列
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

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            //IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            //mOrg org=null;
            //if (list.Count > 0)
            //    org = list[0];
            
            //if (org != null)
            //{
            //    ParentObj = org;
            //    if (SelectGdsChanged != null)
            //        SelectGdsChanged(this, org);
            //}
            

        }
        public PJ_18gysbpj PSObj
        {
            get { return _parentobj; }
            set
            {
                _parentobj = value;
                if (PSObj != null)
                {
                    RefreshData(" where PJ_ID='" + value.PJ_ID + "'  order by id desc");
                }
                else
                {
                    RefreshData(" where PJ_ID='   ###@@@#'  order by id desc");
                }

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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_18gysbpjmx);
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
            hideColumn("gzrjID");
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
        public GridViewOperation<PJ_18gysbpjmx> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_18gysbpjmx newobj)
        {
            if (PSObj == null) return;
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            newobj.PJ_ID = PSObj.PJ_ID;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
        }
      
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridView1.RowCount>0)
            //{
            //     IList<PJ_18gysbpjmx> pjlist=new List<PJ_18gysbpjmx>();
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        pjlist.Add(gridView1.GetRow(i) as PJ_18gysbpjmx);
            //    }
            //   Export18.ExportExcel(pjlist);
            //}
           
           
        }
    }
}
