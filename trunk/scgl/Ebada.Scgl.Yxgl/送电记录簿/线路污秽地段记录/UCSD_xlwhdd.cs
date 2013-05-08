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
using System.Collections;

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_xlwhdd : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjls_xlwhjl> gridViewOperation;

        public event SendDataEventHandler<sdjls_xlwhjl> FocusedRowChanged;
        
        private string parentID = null;
        private sd_xl parentObj;
        public UCSD_xlwhdd()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjls_xlwhjl>(gridControl1, bandedGridView1, barManager1, new frm_xlwhdd());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjls_xlwhjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjls_xlwhjl>(gridViewOperation_BeforeDelete);
            bandedGridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjls_xlwhjl> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjls_xlwhjl> e) {
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
            btLinevolList.EditValueChanged += new EventHandler(btLinevolList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }


        }

        void btLinevolList_EditValueChanged(object sender, EventArgs e)
        {
            ParentID = btLinevolList.EditValue.ToString();
        }

        void btlineList_EditValueChanged(object sender, EventArgs e)
        {
            RepositoryItem sdxlvolDic;
            IList<DicType> volDicList = new List<DicType>();
            ICollection list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select distinct lineVol from sd_xl where   LineCode='{0}' ", btlineList.EditValue));
            foreach(string s in list)
            {
                volDicList.Add(new DicType(s, s));
            }
            sdxlvolDic = new LookUpDicType(volDicList);
            btLinevolList.Edit = sdxlvolDic;
            
            IList<sd_xl> xllist = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where LineCode='" + btlineList.EditValue + "'");
            sd_xl xl = null;
            if (list.Count > 0)
                xl = xllist[0];

            if (xl != null)
            {
                ParentObj = xl;
            }
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {

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
            if (FocusedRowChanged != null)
                FocusedRowChanged(bandedGridView1, bandedGridView1.GetFocusedRow() as sdjls_xlwhjl);
        }
        private void hideColumn(string colname) {
            try {
                bandedGridView1.Columns[colname].Visible = false;
            } catch { }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            if (MainHelper.UserOrg != null) {
                string strSQL = "where linecode in( select linecode from sd_xl where orgCode='" + MainHelper.UserOrg.OrgCode + "')";
                
                RefreshData(strSQL);
            }
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            //hideColumn("qzrq");

            hideColumn("LineName");
            hideColumn("LineCode");
            hideColumn("OrgCode");
            hideColumn("OrgName");
            hideColumn("gx");

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
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
            this.bandedGridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjls_xlwhjl> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjls_xlwhjl newobj) {
            if (parentID == null) return;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            mOrg org= Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='"+btGdsList.EditValue.ToString()+"'");
            newobj.OrgCode = org.OrgCode;
            newobj.OrgName = org.OrgName;
            newobj.LineName = parentObj.LineName;
            newobj.LineCode = parentObj.LineCode;
            newobj.LineVol = parentID;
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
                    RefreshData(" where LineCode='" + btlineList.EditValue + "' and LineVol='"+value +"' order by id desc");
                    
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
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (bandedGridView1.RowCount > 0)
            {
                IList<sdjls_xlwhjl> whjlList = new List<sdjls_xlwhjl>();
                for (int i = 0; i < bandedGridView1.RowCount; i++)
                {
                    var row = bandedGridView1.GetRow(bandedGridView1.GetVisibleRowHandle(i));
                    if (row is sdjls_xlwhjl)
                    {
                        whjlList.Add(row as sdjls_xlwhjl);
                    }
                }
                ExportSDxlwh.ExportExcel(whjlList);
            }
        }

        private void UCSD_xlwhdd_Load(object sender, EventArgs e)
        {
            this.bandedGridView1.BestFitColumns();
        }
    }
}
