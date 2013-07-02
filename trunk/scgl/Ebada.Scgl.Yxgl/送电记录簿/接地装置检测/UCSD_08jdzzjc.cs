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
using DevExpress.XtraEditors.Repository;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_08jdzzjc : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjl_07jdzz> gridViewOperation;
        private string basesql = "where 1>0";
        private string orgsql = "";
        private string xlsql = "";
        public event SendDataEventHandler<sdjl_07jdzz> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmSD08JDZZEdit frm = new frmSD08JDZZEdit();
        private string parentID = null;
        private mOrg parentObj;
        public UCSD_08jdzzjc()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_07jdzz>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_07jdzz>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_07jdzz>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_07jdzz> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_07jdzz> e)
        {
            if (parentID == null)
            {
                MsgBox.ShowWarningMessageBox("请选择单位!");
                e.Cancel = true;
            }
            if (string.IsNullOrEmpty(barxl.EditValue as string))
            {
                MsgBox.ShowWarningMessageBox("请选择线路!");
                e.Cancel = true;
            }
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

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            barxl.EditValue = null;
            barxl.Edit = null;
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];
            if (org != null)
            {
                //frm.ParentID = org.OrgCode;
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
                RepositoryItem gdsDic;
                IList<sd_xl> xllist = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where orgcode='"+org.OrgCode+"' and parentid='0'");
                IList<DicType> dic = new List<DicType>();
                foreach (sd_xl xl in xllist)
                {
                    dic.Add(new DicType(xl.LineCode,xl.LineName));
                }
                gdsDic = new LookUpDicType(dic);
                this.barxl.Edit = gdsDic;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_07jdzz);
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
            //hideColumn("gzwz");
            hideColumn("sbID");
            hideColumn("LineID");
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
        public GridViewOperation<sdjl_07jdzz> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_07jdzz newobj)
        {
            if (parentID == null) return;
            if (string.IsNullOrEmpty(this.barxl.EditValue as string))
                return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            newobj.LineID = this.barxl.EditValue as string;
            sd_xl xl= Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>("where linecode='" + newobj.LineID + "'");
            newobj.LineName = xl.LineName;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            
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
                    orgsql = " and OrgCode='" + value + "'";
                    string sql = basesql + orgsql;
                    RefreshData(sql);
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
            IList<sdjl_07jdzz> jdzzList = new List<sdjl_07jdzz>();
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    sdjl_07jdzz jdzz = gridView1.GetRow(i) as sdjl_07jdzz;
                    jdzzList.Add(jdzz);
                }
                ExportSD08.ExportExcel(jdzzList);
            }
        }

        private void barxl_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(barxl.EditValue as string))
                return;
            xlsql = " and lineid ='"+barxl.EditValue as string+"'";
            string sql = basesql + orgsql + xlsql;
            RefreshData(sql);
        }
    }
}
