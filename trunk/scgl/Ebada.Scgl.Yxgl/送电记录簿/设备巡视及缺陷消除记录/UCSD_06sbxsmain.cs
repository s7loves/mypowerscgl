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
using System.Reflection;
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
    public partial class UCSD_06sbxsmain : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<sdjl_06sbxs> gridViewOperation;

        public event SendDataEventHandler<sdjl_06sbxs> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCSD_06sbxsmain()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_06sbxs>(gridControl1, gridView1, barManager1,new frmSD06sbxsEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_06sbxs>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_06sbxs>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_06sbxs> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_06sbxs> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

          

        }
        public void initcomment()
        {
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_06sbxs);
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
            hideColumn("xsr");
            hideColumn("qxnr");
            hideColumn("qxlb");
            hideColumn("xcr");
            hideColumn("xcrq");
            hideColumn("xcqx");
            hideColumn("OrgCode");
            hideColumn("CreateMan");
            hideColumn("LineID");
            hideColumn("gzrjID");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
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
        public GridViewOperation<sdjl_06sbxs> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_06sbxs newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.xssj = DateTime.Now;
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
            //frm06sbxsLine frm = new frm06sbxsLine();
            //frm.orgcode = btGdsList.EditValue.ToString();
            //if (frm.ShowDialog()==DialogResult.OK)
            //{

            //    IList<sdjl_06sbxs> pj06list = new List<sdjl_06sbxs>();
            //    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<sdjl_06sbxs>(" where LineName='" + frm.linename + "'");
            //    if (pj06list.Count>0)
            //    {
            //        Export06.ExportExcel(pj06list);
            //    }
            //   else
            //    {
            //        MsgBox.ShowTipMessageBox("此线路没有添加巡视情况。");
            //        return;
            //    }
            //}
            if (gridView1.FocusedRowHandle >= 0)
            {
                bool xsmxflag = false; //是否有巡视的子表
                frmExportYearSelect frm = new frmExportYearSelect();
                DataTable dt = new DataTable();
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(bool));
                if (frm.ShowDialog()==DialogResult.OK)
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


                    Dictionary<string, List<sdjl_06sbxs>> diclist = new Dictionary<string, List<sdjl_06sbxs>>();
                    sdjl_06sbxs _pj = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjl_06sbxs;
                    //添加明细表的信息
                    IList<sdjl_06sbxsmx> ilist = null;
                    if (dt.Rows .Count== 0)
                    {
                       ilist = Client.ClientHelper.PlatformSqlMap.GetList<sdjl_06sbxsmx>(" where ParentID='" + _pj.ID + "' order by CreateDate ");
                    }
                    else
                    {
                        string sely = "(";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i < dt.Rows.Count - 1)
                            {
                                sely += "'" + dt.Rows[i][0].ToString() + "',";
                            }
                            else
                                sely += "'" + dt.Rows[i][0].ToString() + "')";

                        }
                        ilist = Client.ClientHelper.PlatformSqlMap.GetList<sdjl_06sbxsmx>(" where ParentID='" + _pj.ID + "'and year(xssj) in"+sely+ "order by CreateDate ");
                    }
                    if (ilist.Count == 0)
                    {
                        xsmxflag = false;
                        List<sdjl_06sbxs> lispj = new List<sdjl_06sbxs>();
                        lispj.Add(_pj);
                        diclist[_pj.LineID] = lispj;
                    }
                    else
                    {
                        xsmxflag = true;
                        List<sdjl_06sbxs> lispj = new List<sdjl_06sbxs>();
                        diclist[_pj.LineID] = lispj;
                        foreach (sdjl_06sbxsmx pmx in ilist)
                        {
                            sdjl_06sbxs newpj = new sdjl_06sbxs();
                            Type obj = newpj.GetType();
                            foreach (PropertyInfo p in obj.GetProperties())
                            {
                                try
                                {
                                    p.SetValue(newpj, pmx.GetType().GetProperty(p.Name).GetValue(pmx, null), null);
                                }
                                catch (Exception ex) { }
                            }
                            diclist[_pj.LineID].Add(newpj);
                        }
                        // lispj.Add(_pj);

                    }
                    foreach (KeyValuePair<string, List<sdjl_06sbxs>> pp in diclist)
                    {
                        List<sdjl_06sbxs> objlist = pp.Value;
                        if (objlist.Count > 0)
                        {
                            ExportSD06.ExportExcel(objlist,xsmxflag);
                        }

                    }
                }
          
                }
               

            //for (int i = 0; i < gridView1.RowCount;i++ )
            //{
            //    sdjl_06sbxs _pj = gridView1.GetRow(i) as sdjl_06sbxs;
              
            //    if (diclist.ContainsKey(_pj.LineID))
            //    {
            //        diclist[_pj.LineID].Add(_pj);
            //    }
            //    else
            //    {
            //        List<sdjl_06sbxs> lispj = new List<sdjl_06sbxs>();
            //        lispj.Add(_pj);
            //        diclist[_pj.LineID] = lispj;
            //    }
            //    //添加明细表的信息
            //    IList<sdjl_06sbxsmx> ilist = Client.ClientHelper.PlatformSqlMap.GetList<sdjl_06sbxsmx>(" where ParentID='" + _pj.ID + "' order by CreateDate desc");
            //    foreach (sdjl_06sbxsmx pmx in ilist)
            //    {
            //        sdjl_06sbxs newpj = new sdjl_06sbxs();
            //        Type obj = newpj.GetType();
            //        foreach (PropertyInfo p in obj.GetProperties())
            //        {
            //            try
            //            {
            //                p.SetValue(newpj, p.GetValue(pmx, null), null);
            //            }
            //            catch { }
            //        }
            //        diclist[_pj.LineID].Add(newpj);
            //    }
            //}
            //foreach (KeyValuePair<string, List<sdjl_06sbxs>> pp in diclist)
            //{
            //    List<sdjl_06sbxs> objlist = pp.Value;
            //    if (objlist.Count > 0)
            //    {
            //        Export06.ExportExcel(objlist);
            //    }

            //}
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (parentID == null) return;
            frmSDXSQD pd = new frmSDXSQD();
            pd.parentobj = ParentObj;
            if (gridView1.FocusedRowHandle >= 0)
            {
                pd.xsobj = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjl_06sbxs;
            }
            
            pd.ShowDialog();
          
        }
    }
}
