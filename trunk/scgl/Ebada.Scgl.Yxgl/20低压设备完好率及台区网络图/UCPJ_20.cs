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
    public partial class UCPJ_20 : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_20> gridViewOperation;

        public event SendDataEventHandler<PJ_20> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCPJ_20()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_20>(gridControl1, gridView1, barManager1, new frmTemplate());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_20>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_20>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            btXlList.EditValueChanged += new EventHandler(repositoryItemLookUpEdit2_EditValueChanged);
            btTQList.EditValueChanged += new EventHandler(repositoryItemLookUpEdit3_EditValueChanged);
        }

        void repositoryItemLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            //this.ParentID = barEditItem2.EditValue.ToString();
        }

        void repositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e) {
            //
            string linecode = btXlList.EditValue==null?"":btXlList.EditValue.ToString();
            IList<PS_tq> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where left(tqcode,{0})='{1}'", linecode.Length, linecode));
            repositoryItemLookUpEdit3.DataSource = xlList;
            RefreshData(string.Format("where left(tqcode,{0})='{1}'", linecode.Length, linecode));

        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_20> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_20> e)
        {
            if (parentID == null)
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
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
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
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_20);
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
            RefreshData(" where ParentID='" + parentID + "' order by CreateDate desc");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            hideColumn("ParentID");
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
        public GridViewOperation<PJ_20> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_20 newobj)
        {
            if (parentID == null || btTQList.EditValue.ToString() == "") return;
            newobj.ParentID = parentID;
            newobj.OrgCode = parentObj.OrgCode;
            newobj.OrgName = parentObj.OrgName;
            if (btTQList.EditValue != null)
            {
                newobj.tqCode = btTQList.EditValue.ToString();
                newobj.tqName = repositoryItemLookUpEdit3.GetDisplayText(btTQList.EditValue.ToString());
            }
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            LP_Temple lp = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and CellName like '%低压线路完好率及台区网络图%'");
            newobj.BigData = lp.DocContent;
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
                    RefreshData(" where ParentID='" + value + "' order by CreateDate desc");
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

            if (parentID == null || btTQList.EditValue == null) return;
            //if (gridView1.FocusedRowHandle>=0)
            //{
            //    Export20.ExportExcel(gridView1.GetFocusedRow() as PJ_20);
            //}
            Export20.ExportExcelTQ(btTQList.EditValue.ToString());
           
        }
        private void btReExportAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export20.ExportExcelAll("");
        }

        private void btReExportOrg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export20.ExportExcelAll(parentID);
        }
        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PJ_20 newobj = new  PJ_20();
            if (parentID == null || btTQList.EditValue == null) return;
            newobj.ParentID = parentID;
            newobj.OrgCode = parentObj.OrgCode;
            newobj.OrgName = parentObj.OrgName;
            if (btTQList.EditValue != null)
            {
                newobj.tqCode = btTQList.EditValue.ToString();
                newobj.tqName = repositoryItemLookUpEdit3.GetDisplayText(btTQList.EditValue.ToString());
            }
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            frmTemplate frm = new frmTemplate();
            frm.RowData = newobj;
            frm.Status = "add";
            frm.ShowDialog();
            InitData();
        }

        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                return;
            }
            PJ_20 pj = gridView1.GetFocusedRow() as PJ_20;
            frmTemplate frm = new frmTemplate();
            frm.RowData = pj;
            frm.Status = "edit";
            frm.ShowDialog();
            InitData();
        }

        private void btReDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainHelper.UserOrg == null) return;

            if (gridView1.FocusedRowHandle < 0) return;
            PJ_20 pj = gridView1.GetFocusedRow() as PJ_20;
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除选择的数据 ?") != DialogResult.OK)
            {
                return;
            }

            try
            {



                MainHelper.PlatformSqlMap.DeleteByWhere<PJ_20>(" where id ='" + pj.ID + "'");
                LP_Temple parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>(" where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) and  CellName like '%低压线路完好率及台区网络图%'");
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_TableFieldValue>(" where RecordId ='"
                    + pj.ID + "' and UserControlId='" + parentTemple .LPID+ "'");
                InitData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

     


    }
}
