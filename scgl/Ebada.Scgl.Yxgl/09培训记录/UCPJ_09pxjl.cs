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

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_09pxjl : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_09pxjl> gridViewOperation;

        public event SendDataEventHandler<PJ_09pxjl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCPJ_09pxjl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_09pxjl>(gridControl1, gridView1, barManager1,new frm09pxjlEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_09pxjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_09pxjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_09pxjl>(gridViewOperation_AfterAdd);
        }

        void gridViewOperation_AfterAdd(PJ_09pxjl obj)
        {
            
            CreatRiZhi(obj);
        }
        public static void CreatRiZhi(PJ_09pxjl obj)
        {


            PJ_gzrjnr gzr = new PJ_gzrjnr();
            gzr.gzrjID = gzr.CreateID();
            gzr.ParentID = obj.ID;
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            IList<PJ_01gzrj> gzrj01 = MainHelper.PlatformSqlMap.GetList<PJ_01gzrj>("SelectPJ_01gzrjList", "where GdsCode='" + MainHelper.User.OrgCode + "' and rq between '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59") + "'");

            if (gzrj01.Count > 0)
            {
                gzr.gzrjID = gzrj01[0].gzrjID;
            }
            else
            {
                PJ_01gzrj pj = new PJ_01gzrj();
                pj.gzrjID = pj.CreateID();
                pj.GdsCode = obj.OrgCode;
                pj.GdsName = obj.OrgName;
                pj.CreateDate = DateTime.Now;
                pj.CreateMan = MainHelper.User.UserName;
                gzr.gzrjID = pj.gzrjID;
                pj.rq = obj.rq;
                pj.xq = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                pj.rsaqts = (DateTime.Today - MainHelper.UserOrg.PSafeTime.Date).Days;
                pj.sbaqts = (DateTime.Today - MainHelper.UserOrg.DSafeTime.Date).Days;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                MainHelper.PlatformSqlMap.Create<PJ_01gzrj>(pj);


            }
            IList<PJ_gzrjnr> gzrlist = MainHelper.PlatformSqlMap.GetList<PJ_gzrjnr>("SelectPJ_gzrjnrList", "where gzrjID  = '" + gzr.gzrjID + "' order by seq  ");
            if (gzrlist.Count > 0)
            {
                gzr.seq = gzrlist[gzrlist.Count - 1].seq + 1;
            }
            else
                gzr.seq = 1;

            gzr.gznr =obj.hydd+ "职工培训";
            gzr.fzr = obj.zcr;

            gzr.cjry = obj.zcr + "等" + gzr.cjry + "人";
           
            gzr.CreateDate = DateTime.Now;
            gzr.CreateMan = MainHelper.User.UserName;
            gzr.fssj = DateTime.Now;
            MainHelper.PlatformSqlMap.Create<PJ_gzrjnr>(gzr);

        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_09pxjl> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_09pxjl> e)
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_09pxjl);
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

            hideColumn("OrgCode");
            hideColumn("gznrID");
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
        public GridViewOperation<PJ_09pxjl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_09pxjl newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.rq = DateTime.Now;
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
                    RefreshData(" where OrgCode='" + value + "' order by id desc");
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
            if (gridView1.FocusedRowHandle>=0)
            {
                Export09.ExportExcel(gridView1.GetFocusedRow() as PJ_09pxjl);
            }
        }
    }
}
