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
    public partial class UCPJ_06sbxsmx : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_06sbxsmx> gridViewOperation;

        public event SendDataEventHandler<PJ_06sbxsmx> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private PJ_06sbxs parentObj;
        frm06sbxsmxEdit fmx = new frm06sbxsmxEdit();
        public UCPJ_06sbxsmx()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_06sbxsmx>(gridControl1, gridView1, barManager1,fmx);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_06sbxsmx>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_06sbxsmx>(gridViewOperation_BeforeDelete);
           gridViewOperation.BeforeEdit+=new ObjectOperationEventHandler<PJ_06sbxsmx>(gridViewOperation_BeforeEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_06sbxsmx> e)
        {
           
        }
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_06sbxsmx> e)
        {
            fmx.ParentObj = ParentObj;
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_06sbxsmx> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //InitColumns();//初始列
           // InitData();//初始数据
            //if (this.Site != null) return;
            //btGdsList.Edit = DicTypeHelper.GdsDic;
            //btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            //if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            //{//如果是供电所人员，则锁定
            //    btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
            //    btGdsList.Edit.ReadOnly = true;
            //}

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
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_06sbxsmx);
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
            hideColumn("LineID");
            hideColumn("gzrjID");
            //hideColumn("xcqx");
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
        public GridViewOperation<PJ_06sbxsmx> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_06sbxsmx newobj)
        {
            if (parentID == null) return;
            newobj.ParentID = parentID;
            newobj.LineName = ParentObj.LineName;
            newobj.xlqd = ParentObj.xlqd;
            newobj.OrgCode = parentObj.OrgCode;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.xssj = DateTime.Now;
            newobj.xcrq = DateTime.Now;
            fmx.ParentObj = ParentObj;
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
                    RefreshData(" where ParentID='" + value + "' order by CreateDate desc");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PJ_06sbxs ParentObj
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
                    ParentID = value.ID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////frm06sbxsLine frm = new frm06sbxsLine();
            ////frm.orgcode = btGdsList.EditValue.ToString();
            ////if (frm.ShowDialog()==DialogResult.OK)
            ////{

            ////    IList<PJ_06sbxsmx> pj06list = new List<PJ_06sbxsmx>();
            ////    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxsmx>(" where LineName='" + frm.linename + "'");
            ////    if (pj06list.Count>0)
            ////    {
            ////        Export06.ExportExcel(pj06list);
            ////    }
            ////   else
            ////    {
            ////        MsgBox.ShowTipMessageBox("此线路没有添加巡视情况。");
            ////        return;
            ////    }
            ////}

            //Dictionary<string, List<PJ_06sbxsmx>> diclist = new Dictionary<string, List<PJ_06sbxsmx>>();
            //for (int i = 0; i < gridView1.RowCount;i++ )
            //{
            //    PJ_06sbxsmx _pj = gridView1.GetRow(i) as PJ_06sbxsmx;
            //    if (diclist.ContainsKey(_pj.LineID))
            //    {
            //        diclist[_pj.LineID].Add(_pj);
            //    }
            //    else
            //    {
            //        List<PJ_06sbxsmx> lispj = new List<PJ_06sbxsmx>();
            //        lispj.Add(_pj);
            //        diclist[_pj.LineID] = lispj;
            //    }
            //}
            //foreach (KeyValuePair<string, List<PJ_06sbxsmx>> pp in diclist)
            //{
            //    List<PJ_06sbxsmx> objlist = pp.Value;
            //    if (objlist.Count > 0)
            //    {
            //        Export06.ExportExcel(objlist);
            //    }

            //}
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (parentID == null) return;
            //frmXSQD pd = new frmXSQD();
            //pd.parentobj = ParentObj;
            //if (gridView1.FocusedRowHandle >= 0)
            //{
            //    pd.xsobj = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_06sbxsmx;
            //}
            
            //pd.ShowDialog();
          
        }
    }
}
