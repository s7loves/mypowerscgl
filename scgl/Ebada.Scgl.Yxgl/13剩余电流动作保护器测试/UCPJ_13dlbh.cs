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
    public partial class UCPJ_13dlbh : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_tqdlbh> gridViewOperation;
        public mOrg gds =null;
        public event SendDataEventHandler<PS_tqdlbh> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmtqdlbhEdit frm = new frmtqdlbhEdit();
        private string parentID = null;
        private mOrg parentObj;
        public UCPJ_13dlbh()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_tqdlbh>(gridControl1, gridView1, barManager1, frm);
            GridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PS_tqdlbh>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_tqdlbh>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_tqdlbh>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PS_tqdlbh> e)
        {
            if (parentID == null)
                e.Cancel = true;
            frm.OrgCode = btGdsList.EditValue.ToString();
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_tqdlbh> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_tqdlbh> e)
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
            btXL.EditValueChanged += new EventHandler(btXLList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btXLList_EditValueChanged(object sender, EventArgs e)
        {
            if (btXL.EditValue == null) return;
            parentID = btXL.EditValue.ToString();
            
            if (parentID != "")
            {
                IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where LineCode='" + parentID + "'");
                //frm.LineCode = parentID;
                PS_xl xl = null;
                if (list.Count > 0)
                {
                    xl = list[0];
                   // ParentObj = xl;
                }
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
                RefreshData(" where tqID in(select tqID from PS_tq where LEFT(tqID,'" + org.OrgCode.Length + "')='" + org.OrgCode + "') or orgCode='" + org.OrgCode + "' order by sbCode ");
                ParentObj = org;
                gds = org;
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit3.DataSource = xlList;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_tqdlbh);
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
            hideColumn("sbName");
            hideColumn("Number");
            hideColumn("MadeDate");
            hideColumn("InstallDate");
            hideColumn("State");
            hideColumn("dzsj");
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
        public GridViewOperation<PS_tqdlbh> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_tqdlbh newobj)
        {
            if (parentID == null) return;
            frm.OrgCode = btGdsList.EditValue.ToString();
            newobj.orgCode = btGdsList.EditValue.ToString();
            //newobj.tqID = ParentObj.OrgID;
            //newobj.OrgName = parentObj.OrgName;
            //newobj.CreateDate = DateTime.Now;
            //newobj.CreateMan = MainHelper.LoginName;
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
                //where left(tqCode,{1})='{0}' ", lineCode,lineCode.Length
                parentID = value;
                //if (!string.IsNullOrEmpty(value))
                //{
                //    RefreshData(" where tqID in (select tqID  from PS_tq where LEFT(tqCODE,'"+value.Length+"')= '" + value + "') order by sbCode ");
                //}
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
            if (gridView1.FocusedRowHandle != -1)
            {
                frmExportYearSelect frm = new frmExportYearSelect();
                DataTable dt = new DataTable();
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(bool));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //dt = frm.DT1;
                    try
                    {
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
                        //Export13.ExportExcel(gridView1.GetFocusedRow() as PS_tqdlbh);
                        mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(btGdsList.EditValue.ToString());
                        if (dt.Rows.Count == 0)
                        {
                            Export13.ExportExcel2(gridControl1.DataSource as IList<PS_tqdlbh>, org.OrgName);
                        }
                        else
                        {
                            IList<PS_tqdlbh> pjlist = new List<PS_tqdlbh>();
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                PS_tqdlbh _pj = gridView1.GetRow(i) as PS_tqdlbh;

                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (_pj.InDate.Year == Convert.ToInt32(dt.Rows[j][0]))
                                    {
                                        pjlist.Add(_pj);
                                    }
                                }


                            }
                            Export13.ExportExcel2(pjlist, org.OrgName);
                        }

                    }
                    catch (System.Exception ex)
                    {

                    }
                }
               
               
               
            }
        }
    }
}
