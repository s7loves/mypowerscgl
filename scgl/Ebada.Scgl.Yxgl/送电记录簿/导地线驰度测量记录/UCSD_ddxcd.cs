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

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_ddxcd : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjls_ddxcd> gridViewOperation;

        public event SendDataEventHandler<sdjls_ddxcd> FocusedRowChanged;
        
        private string parentID = null;
        private sd_xl parentObj;
        public UCSD_ddxcd()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_ddxcd>(gridControl1, bandedGridView1, barManager1, new frm_ddxcd());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjls_ddxcd>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjls_ddxcd>(gridViewOperation_BeforeDelete);
            
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjls_ddxcd> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjls_ddxcd> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btlineList.EditValueChanged += new EventHandler(btlineList_EditValueChanged);
            btlineList.Edit = new RepositoryItem();
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btlineList_EditValueChanged(object sender, EventArgs e)
        {
            IList<sd_xl> list = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where LineCode='" + btlineList.EditValue + "'");
            sd_xl xl = null;
            if (list.Count > 0)
                xl = list[0];

            if (xl != null)
            {
                ParentObj = xl;
                
            }
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {

            RepositoryItem sdxlDic;
            IList<sd_xl> xllist = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where orgcode='"+btGdsList.EditValue+"'");
            IList<DicType> dic = new List<DicType>();
            foreach (sd_xl gds in xllist)
            {
                dic.Add(new DicType(gds.LineCode, gds.LineName));
            }
            sdxlDic = new LookUpDicType(dic);
            btlineList.Edit = sdxlDic;
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            
        }
        private void hideColumn(string colname) {
            try {
               
            } catch { }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            //if (MainHelper.UserOrg != null) {
            //    //string strSQL = "where lineid in( select linecode from sd_xl where orgCode='" + MainHelper.UserOrg.OrgCode + "')";
                
            //    RefreshData(strSQL);
            //}

        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            
            #region 注释的代码
            //hideColumn("LineName");
            //hideColumn("LineID");
            //hideColumn("OrgCode");
            //hideColumn("gznrID");
            //hideColumn("ParentID");
            //hideColumn("ghrq");
            //hideColumn("fzr");
            //hideColumn("lhpwchdsq");
            //hideColumn("lhps");
            //hideColumn("xghjyzxh");
            //hideColumn("xghjyzzzc");
            //hideColumn("lhjyzccrq");
            //hideColumn("jyzzzc");
            //hideColumn("lhjyzyxnx");
            //hideColumn("cb");
            //hideColumn("xb");
            //hideColumn("zyc");
            //hideColumn("c1");
            //hideColumn("c2");
            //hideColumn("c3");
            //hideColumn("c4");
            //hideColumn("c5");
            #endregion
            //需要隐藏列时在这写代码

            //hideColumn("qzrq");


           
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
            bandedGridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjls_ddxcd> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjls_ddxcd newobj) {
            if (parentID == null) return;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            mOrg org= Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='"+btGdsList.EditValue.ToString()+"'");
            newobj.OrgCode = btGdsList.EditValue.ToString();
            newobj.OrgName = org.OrgName;
            sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>("where LineCode='" + btlineList.EditValue.ToString() + "'");
            newobj.LineCode = xl.LineCode;
            newobj.LineName = xl.LineName;
            newobj.clrq = DateTime.Now;


        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where LineCode='" + value + "' order by id desc");
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sd_xl ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.LineCode;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (bandedGridView1.RowCount <= 0)
                return;
            IList<sdjls_ddxcd> ddxcdList = new List<sdjls_ddxcd>();
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                var row = bandedGridView1.GetRow(bandedGridView1.GetVisibleIndex(i));
                if (row is sdjls_ddxcd)
                    ddxcdList.Add(row as sdjls_ddxcd);
            }
            ExportDdcd.ExportExcel(ddxcdList);
            

            
        }
    }
}
