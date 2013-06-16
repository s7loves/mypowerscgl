﻿/**********************************************
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

namespace Ebada.Scgl.Gis
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_21gzbxdh : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_21gzbxdh> gridViewOperation;

        public event SendDataEventHandler<PJ_21gzbxdh> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        public event ObjectEventHandler<PJ_21gzbxdh> OnBeginLocation;
        private string parentID = null;
        private mOrg parentObj;
        public UCPJ_21gzbxdh()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_21gzbxdh>(gridControl1, gridView1, barManager1, new frm21gzbxdhEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_21gzbxdh>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_21gzbxdh>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            (gridViewOperation.EditForm as frm21gzbxdhEdit).OnBeginLocation += new ObjectEventHandler<PJ_21gzbxdh>(UCPJ_21gzbxdh_OnBeginLocation);
            bar3.Visible = false;
        }

        void UCPJ_21gzbxdh_OnBeginLocation(PJ_21gzbxdh obj) {
            if (OnBeginLocation != null) {
                OnBeginLocation(obj);
            }
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_21gzbxdh> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_21gzbxdh> e)
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_21gzbxdh);
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
            if (MainHelper.UserOrg != null)
            {
                string strSQL = "where OrgCode='" + MainHelper.UserOrg.OrgCode + "' order by id desc";
                RefreshData(strSQL);
            }
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            hideColumn("OrgCode");
            hideColumn("gzrjID");
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
        public GridViewOperation<PJ_21gzbxdh> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_21gzbxdh newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
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
            if (gridView1.RowCount > 0)
            {
                frmExportYearSelect frm = new frmExportYearSelect();
                DataTable dt = new DataTable();
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(bool));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                   // dt = frm.DT1;
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

                        IList<PJ_21gzbxdh> pjlist = new List<PJ_21gzbxdh>();
                        if (dt.Rows.Count == 0)
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                PJ_21gzbxdh _pj = gridView1.GetRow(i) as PJ_21gzbxdh;
                                pjlist.Add(_pj);


                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                PJ_21gzbxdh _pj = gridView1.GetRow(i) as PJ_21gzbxdh;
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (Convert.ToInt32(dt.Rows[j][0]) == _pj.rq.Year)
                                    {
                                        pjlist.Add(_pj);

                                    }
                                }


                            }
                        }
                        Export21.ExportExcel(pjlist);
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
                
               
            }
            else
            {
                return;
            }
        }
    }
}
