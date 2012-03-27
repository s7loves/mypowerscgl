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
    public partial class UCPJ_23 : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_23> gridViewOperation;

        public event SendDataEventHandler<PJ_23> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCPJ_23()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_23>(gridControl1, gridView1, barManager1, new frm23Edit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_23>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_23>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_23>(gridViewOperation_BeforeDelete);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_23>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_23> e)
        {
            if (e.Value.BigData == null)
            {
                e.Value.BigData = new byte[0];
            }

        }
        void gridViewOperation_AfterEdit(PJ_23 obj)
        {
            //修改模板

            mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(obj.ParentID);
            string fname = Application.StartupPath + "\\00记录模板\\23配电线路产权维护范围协议书.xls";
            string bhname = org.OrgName.Replace("供电所", "");
            DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
            dsoFramerControl1.FileOpen(fname);
            Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            PJ_23 obj1 = (PJ_23)MainHelper.PlatformSqlMap.GetObject("SelectPJ_23List", "where ParentID='" + obj.ParentID + "' and xybh like '" + SelectorHelper.GetPysm(org.OrgName.Replace("供电所", ""), true) + "-" + DateTime.Now.Year.ToString() + "-%' order by xybh ASC");
            int icount = 1;
            if (obj1 != null && obj1.xybh != "")
            {
                icount = Convert.ToInt32(obj.xybh.Split('-')[2]) + 1;
            }
            string strname = SelectorHelper.GetPysm(bhname, true);
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            ea.SetCellValue(strname.ToUpper(), 4, 8);
            strname = DateTime.Now.Year.ToString();
            ea.SetCellValue(strname, 4, 9);
            strname = string.Format("{0:D3}", icount);
            ea.SetCellValue(strname, 4, 10);
            ea.SetCellValue(obj.cqdw + "：", 6, 4);
            ea.SetCellValue(obj.linename, 10, 7);
            ea.SetCellValue(obj.fzlinename, 10, 10);
            ea.SetCellValue("'" + obj.gh, 10,16);
            ea.SetCellValue(obj.cqfw, 11, 4);
            ea.SetCellValue(obj.cqdw, 13, 4);
            ea.SetCellValue(obj.qdrq.Year.ToString(), 21, 7);
            ea.SetCellValue(obj.qdrq.Month.ToString(), 21, 9);
            ea.SetCellValue(obj.qdrq.Day.ToString(), 21, 11);
            dsoFramerControl1.FileSave();
            obj.BigData = dsoFramerControl1.FileData;
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            MainHelper.PlatformSqlMap.Update<PJ_23>(obj);
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_23> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_23> e)
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_23);
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
            hideColumn("ParentID");
            hideColumn("gzrjID");
            hideColumn("BigData");
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
        public GridViewOperation<PJ_23> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_23 newobj)
        {
            if (parentID == null) return;
            newobj.ParentID = parentID;
            //newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
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
            PJ_23 OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_23;
            if (OBJECT.BigData != null)
            {
                if (OBJECT.BigData.Length != 0)
                {
                    DSOFramerControl ds1 = new DSOFramerControl();
                    ds1.FileData = OBJECT.BigData;
                    // ds1.FileOpen(ds1.FileName);
                    ExcelAccess ex = new ExcelAccess();

                    string fname = ds1.FileName;

                    ex.Open(fname);
                    //此处写填充内容代码
                    ds1.FileClose();
                    ex.ShowExcel();
                }
                else
                {
                    Export23.ExportExcel(OBJECT);
                }

            }
            else
            {
                Export23.ExportExcel(OBJECT);
            }
           
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                //修改模板
                PJ_23 rowData = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_23;
                //mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(rowData.ParentID);
                //string fname = Application.StartupPath + "\\00记录模板\\23配电线路产权维护范围协议书.xls";
                //string bhname = org.OrgName.Replace("供电所", "");
                //DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
                //dsoFramerControl1.FileOpen(fname);
                //Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
                //PJ_23 obj = (PJ_23)MainHelper.PlatformSqlMap.GetObject("SelectPJ_23List", "where ParentID='" + rowData.ParentID + "' and xybh like '" + SelectorHelper.GetPysm(org.OrgName.Replace("供电所", ""), true) + "-" + DateTime.Now.Year.ToString() + "-%' order by xybh ASC");
                //int icount = 1;
                //if (obj != null && obj.xybh != "")
                //{
                //    icount = Convert.ToInt32(obj.xybh.Split('-')[2]) + 1;
                //}
                //string strname = SelectorHelper.GetPysm(bhname, true);
                //ExcelAccess ea = new ExcelAccess();
                //ea.MyWorkBook = wb;
                //ea.MyExcel = wb.Application;
                //ea.SetCellValue(strname.ToUpper(), 4, 8);
                //strname = DateTime.Now.Year.ToString();
                //ea.SetCellValue(strname, 4, 9);
                //strname = string.Format("{0:D3}", icount);
                //ea.SetCellValue(strname, 4, 10);
                //ea.SetCellValue(rowData.cqdw + "：", 6, 4);
                //ea.SetCellValue(rowData.linename, 10, 7);
                //ea.SetCellValue(rowData.fzlinename, 10, 10);
                //ea.SetCellValue("'" + rowData.gh, 10, 15);
                //ea.SetCellValue(rowData.cqfw, 11, 4);
                //ea.SetCellValue(rowData.cqdw, 13, 4);
                //ea.SetCellValue(rowData.qdrq.Year.ToString(), 21, 7);
                //ea.SetCellValue(rowData.qdrq.Month.ToString(), 21, 9);
                //ea.SetCellValue(rowData.qdrq.Day.ToString(), 21,11);
                //dsoFramerControl1.FileSave();
                //rowData.BigData = dsoFramerControl1.FileData;
                //dsoFramerControl1.FileClose();
                //dsoFramerControl1.Dispose();
                //dsoFramerControl1 = null;
                //MainHelper.PlatformSqlMap.Update<PJ_23>(rowData);

                frm23Template frm = new frm23Template();
                //frm.pjobject = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_23;
                frm.pjobject = rowData;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Client.ClientHelper.PlatformSqlMap.Update<PJ_23>(frm.pjobject);
                    MessageBox.Show("保存成功");
                }
            }
        }
    }
}
