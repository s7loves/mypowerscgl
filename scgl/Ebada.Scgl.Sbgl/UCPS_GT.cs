﻿/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-7-6
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
using System.Collections;

namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPS_GT : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_gt> gridViewOperation;

        public event SendDataEventHandler<PS_gt> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private PS_xl parentObj;
        Random mRandom = new Random();
        public UCPS_GT()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_gt>(gridControl1, gridView1, barManager1, new frmgtEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_gt>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_gt>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<PS_gt>(gridViewOperation_BeforeInsert);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PS_gt>(gridViewOperation_BeforeUpdate);
            try {
                gridView1.Columns["dxplfs"].VisibleIndex=-1;//导线排列方式
            } catch { }
btDelete2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public UCPS_GT(PS_xl xl):this() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ParentObj = xl;
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PS_gt> e) {
            e.Cancel = true;
            try {
                PS_gt gt =e.Value;
                frmgtEdit frm = gridViewOperation.EditForm as frmgtEdit;
                PS_Image image = frm.GetPS_Image();
                if (frm.GetImage() != null ) {
                    if (gt.ImageID == "" || image==null) {
                        image = new PS_Image();
                        image.ImageName = "杆塔照片";
                        image.ImageType = "gt";
                        image.ImageData = (byte[])frm.GetImage();
                        gt.ImageID = image.ImageID;
                         Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, gt, null);
                    } else {

                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null,new object[] { gt, image },  null);
                    }
                   
                } else {
                    Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(e.Value);
                }

                Ebada.Core.ConvertHelper.CopyTo(gt, e.ValueOld);
            } catch (Exception err) { throw err; }
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<PS_gt> e) {
            e.Cancel = true;
            try {
                frmgtEdit frm = gridViewOperation.EditForm as frmgtEdit;
                PS_Image image = null;
                if (frm.GetImage() != null) {
                    image = new PS_Image();
                    image.ImageName = "杆塔照片";
                    image.ImageType = "gt";
                    image.ImageData = (byte[])frm.GetImage();
                    e.Value.ImageID = image.ImageID;
                    Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(new object[]{e.Value,image}, null, null);
                }
                else{
                    Client.ClientHelper.PlatformSqlMap.Create<PS_gt>(e.Value);
                }
                
                gridViewOperation.BindingList.Add(e.Value);
            } catch (Exception err) { throw err; }
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_gt> e)
        {
            //e.Cancel = true;
            //gridViewOperation.BindingList.Remove(e.Value);
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_gt> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null && this.Site.DesignMode) return;
            if (ParentObj != null) return;
            btXlList.EditValueChanged += new EventHandler(btXlList_EditValueChanged);

            //20110818改
            btGdsList.Edit = DicTypeHelper.GdsDic;

            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }
            //20110818改
            if (!"rabbit赵建明管理员超级管理员".Contains(MainHelper.User.UserName))
            {
                btDeleteMenu.Enabled = false;
            }
        }

        void btXlList_EditValueChanged(object sender, EventArgs e)
        {
            parentID = btXlList.EditValue.ToString();
            if (parentID != "")
            {
                IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where LineCode='" + parentID + "'");
                PS_xl xl = null;
                if (list.Count > 0)
                {
                    xl = list[0];
                    ParentObj = xl;
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
                
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit2.DataSource = xlList;
                //if (SelectGdsChanged != null)
                //    SelectGdsChanged(this, org);
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_gt);
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
            //hideColumn("ParentID");
            //hideColumn("gzrjID");
            gridView1.Columns["c1"].VisibleIndex = 2;
            gridView1.Columns["gth"].Caption = "序号";
            gridView1.SortInfo.Add(gridView1.Columns["gth"], DevExpress.Data.ColumnSortOrder.Ascending);
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
        public GridViewOperation<PS_gt> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_gt newobj)
        {
            if (parentID == null) return;
            newobj.LineCode = parentID;
            if (gtInsert) {
                gtInsert = false;
                newobj.gth = getInsertGh();
            } else {
                newobj.gth = getGgh();
            }
            newobj.gtCode = ParentObj.LineCode + newobj.gth;
            newobj.c1 = newobj.gth;
            newobj.gtID = newobj.gtCode;
            newobj.gtID += mRandom.Next(10, 99);
            newobj.gtSpan = 50;
            newobj.gtMs = 1.7m;
            newobj.gtHeight = 10m;
            newobj.gtNode = "否";
            newobj.gtModle = "直线杆";
            newobj.gtType = "混凝土拔梢杆";
        }

        private string getInsertGh() {
            var row = gridView1.GetFocusedRow();
            if (row == null) {
                return getGgh();
            }
            PS_gt gt = row as PS_gt;
            int index = gridView1.FocusedRowHandle;
            int n1 = 0;
            int n2 = int.Parse(gt.gth);
            
            if (index > 0) {
                n1 = int.Parse((gridView1.GetRow(index - 1) as PS_gt).gth);
            }
            int n3 = (n1 + n2) / 2;
            if (n3 > n1 && n3 < n2) {
                return n3.ToString("0000");
            } else {
                return getGgh();
            }
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
                    RefreshData(" where LineCode='" + value + "' order by gth");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_xl ParentObj
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
                    ParentID = value.LineCode;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                gridControl1.ExportToXls("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }
        }
        string getGgh() {
            //杆塔号0010-9990
            object obj=Client.ClientHelper.PlatformSqlMap.GetObject("Select", "Select isnull(max(gth),'0') as gth from ps_gt where Linecode='" + parentID + "'");
            string gth = "0";
            if (obj != null) {
                Hashtable ht = obj as Hashtable;
                if (ht.Contains("gth")) {
                    gth = ht["gth"].ToString();
                    
                }
            }
            int step = 10;
            if (gth =="0") step = 0;
            gth = (int.Parse(gth) + step).ToString("0000");
            return gth;
        }
        private void btAddM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (parentID == null)
                return;
            PS_gt gt = new PS_gt();
            gt.gth = getGgh();
            gt.gtCode = ParentObj.LineCode + gt.gth;
            gt.gtSpan = 50;
            gt.gtMs = 1.7m;
            gt.gtHeight = 10m;
            gt.gtNode = "否";
            gt.gtModle = "直线杆";
            gt.gtType = "混凝土拔梢杆";
            frmgtEdit frm = new frmgtEdit();
            frm.RowData = gt;
            frm.MultipleAdd = true;//批量增加
            if (frm.ShowDialog() == DialogResult.OK) {
                gt = frm.RowData as PS_gt;
                int num = frm.MultipleNum;//批量增加杆塔数
                int gh = int.Parse(gt.gth);
                int count = num;
                PS_Image image = null;
                if (frm.GetImage() != null) {
                    count++;
                    image = new PS_Image();
                    image.ImageName = "杆塔照片";
                    image.ImageType = "gt";
                    image.ImageData = (byte[])frm.GetImage();
                    gt.ImageID = image.ImageID;
                }
                object[] gts = new object[count];
                if (image != null)
                    gts[count - 1] = image;
                gt.LineCode = ParentObj.LineCode;
                string id = DateTime.Now.ToString("yyyyMMddHHmmss");
                
                for (int i = 0; i < num; i++) {
                    PS_gt newgt = new PS_gt();
                    Ebada.Core.ConvertHelper.CopyTo(gt, newgt);
                    
                    string gth = (gh + 10 * i).ToString("0000");
                    newgt.gth = gth;
                    newgt.gtID=newgt.gtCode = newgt.LineCode + gth;
                    newgt.gtID+= mRandom.Next(10, 99);
                    gts[i] = newgt;
                }
                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(gts, null, null);
                gridViewOperation.BindingList.Add(gts);
            }
        }
        /// <summary>
        /// 隐藏下选择列表
        /// </summary>
        public void HideList() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        /// <summary>
        /// 增加其它设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAddM2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if(gridViewOperation.BindingList.Count==0)return;
            frmgtsbEditM dlg = new frmgtsbEditM();
            dlg.SetGt(gridViewOperation.BindingList);
            dlg.ShowDialog(this);
        }
        bool gtInsert = false;
        private void btAddIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            gtInsert = true;
            btAdd.PerformClick();
        }

        private void btDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            frmGtDel dlg = new frmGtDel("杆塔");
            dlg.SetGt(gridViewOperation.BindingList);
            if (dlg.ShowDialog() == DialogResult.OK) {
                btRefresh.PerformClick();
            }
        }

        private void btDelete3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            frmGtDel dlg = new frmGtDel("杆塔设备");
            dlg.SetGt(gridViewOperation.BindingList);
            if (dlg.ShowDialog() == DialogResult.OK) {
                btRefresh.PerformClick();
            }
        }
        private bool checktq(out PS_tq pstq) {
            pstq = null;
            if (ParentObj == null) return false;
            
            if (ParentObj.LineVol != "0.4") {
                MsgBox.ShowWarningMessageBox("此功能只对0.4kV线路有效！");
                return false;
            }
            string linecode = ParentObj.LineCode.Substring(0, ParentObj.LineCode.Length - 3);
            PS_tq tq = ClientHelper.PlatformSqlMap.GetOne<PS_tq>("where tqcode='" + linecode + "'");
            if (tq == null) {
                MsgBox.ShowTipMessageBox(string.Format("没有找到台区号为｛{0}｝的台区，请重新选择一级线路！", linecode));
                return false;
            }
            pstq = tq;
            return true;
        }
        private void btAddM4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            PS_tq tq = null;
            if (!checktq(out tq)) return;
            frmgtsbEditM dlg = new frmgtsbEditM();
            dlg.pstq = tq;
            dlg.ShowDialog(this);
        }

        private void btDelete4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            PS_tq tq = null;
            if (!checktq(out tq)) return;
            if (MsgBox.ShowAskMessageBox("警告!此操作将删除["+tq.tqName+"]台区下所有杆塔的附属设备，确认吗？") == DialogResult.OK) {
                int count = ClientHelper.PlatformSqlMap.GetRowCount<PS_xl>("where linevol='0.4' and linecode like '" + tq.tqCode + "%'");
                if (count > 0) {
                    string sql = string.Format(" where gtid in(select gtid from ps_gt where linecode in (select linecode from ps_xl where linevol='0.4' and linecode like '{0}%'))", tq.tqCode);
                    count = ClientHelper.PlatformSqlMap.DeleteByWhere<PS_gtsb>(sql);
                    MsgBox.ShowTipMessageBox(string.Format("共删除{0}条记录.",count));
                }
            }
        }
      
    }
}
