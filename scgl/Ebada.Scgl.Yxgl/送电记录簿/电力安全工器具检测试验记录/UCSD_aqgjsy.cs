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
    [ToolboxItem(false)]
    public partial class UCSD_aqgjsy : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjl_14aqgjsy> gridViewOperation;

        public event SendDataEventHandler<sdjl_14aqgjsy> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private sdjl_aqgj _parentobj;
        public UCSD_aqgjsy()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_14aqgjsy>(gridControl1, gridView1, barManager1,new frmSD14aqgjsyEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_14aqgjsy>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_14aqgjsy>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<sdjl_14aqgjsy>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<sdjl_14aqgjsy>(gridViewOperation_AfterEdit);
        }

        void gridViewOperation_AfterEdit(sdjl_14aqgjsy obj) {
            if (PSObj != null) {
                _parentobj.syrq = obj.rq;
                _parentobj.syrq2 = obj.xcsyrq;
                ClientHelper.PlatformSqlMap.Update<sdjl_aqgj>(_parentobj);
            }
        }

        void gridViewOperation_AfterAdd(sdjl_14aqgjsy obj)
        {
            RefreshData(" where OrgCode='" + parentID + "' and sbID='" + PSObj.sbID + "' order by rq");
            if (PSObj != null) {
                _parentobj.syrq = obj.rq;
                _parentobj.syrq2 = obj.xcsyrq;
                ClientHelper.PlatformSqlMap.Update<sdjl_aqgj>(_parentobj);
            }
        }
        public sdjl_aqgj PSObj
        {
            get { return _parentobj;}
            set 
            {
                
                
                if (value!=null)
                {
                    _parentobj = value;
                    //获取变电所
                    IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + value.OrgID + "'");
                    mOrg org = null;
                    if (list.Count > 0)
                        org = list[0];

                    if (org != null)
                    {
                        ParentObj = org;

                    }

                    
                }
                if (parentID != null && PSObj != null)
                {
                    RefreshData(" where OrgCode='" + parentID + "' and sbID='" + PSObj.sbID + "' order by rq");

                }
              
               
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_14aqgjsy> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_14aqgjsy> e)
        {
            if (parentID == null||PSObj==null)
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_14aqgjsy);
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
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjl_14aqgjsy> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_14aqgjsy newobj)
        {
            if (parentID == null||PSObj==null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
         
            newobj.sbID = PSObj.sbID;
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
                if (!string.IsNullOrEmpty(value)&&PSObj!=null)
                {
                    RefreshData(" where OrgCode='" + value + "' and sbID='" + PSObj.sbID + "' order by rq");
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
            if (PSObj!=null&&gridView1.RowCount>0)
            {
                frmExportYearSelect frm = new frmExportYearSelect();
                DataTable dt = new DataTable();
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(bool));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //dt = frm.DT1;
                    DataRow[] dtc = frm.DT1.Select("B=1");
                    foreach (DataRow dr1 in dtc)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dr1[0].ToString();
                        dr[1] = Convert.ToInt32(dr1[1]);
                        dt.Rows.Add(dr);
                    }
                    dtc = frm.DT1.Select("D=1");
                    foreach (DataRow dr1 in dtc)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dr1[2].ToString();
                        dr[1] = Convert.ToInt32(dr1[3]);
                        dt.Rows.Add(dr);
                    }
                    dtc = frm.DT1.Select("F=1");
                    foreach (DataRow dr1 in dtc)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dr1[4].ToString();
                        dr[1] = Convert.ToInt32(dr1[5]);
                        dt.Rows.Add(dr);
                    }
                    IList<sdjl_14aqgjsy> pjlist = new List<sdjl_14aqgjsy>();
                    if (dt.Rows.Count == 0)
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            pjlist.Add(gridView1.GetRow(i) as sdjl_14aqgjsy);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            sdjl_14aqgjsy obj = gridView1.GetRow(i) as sdjl_14aqgjsy;
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (Convert.ToInt32(dt.Rows[j][0]) == obj.rq.Year)
                                {
                                    pjlist.Add(gridView1.GetRow(i) as sdjl_14aqgjsy);
                                }
                            }

                        }
                    }

                    ExportSD14.ExportExcel(PSObj, pjlist);
                }
              
            }
           
           
        }
    }
}
