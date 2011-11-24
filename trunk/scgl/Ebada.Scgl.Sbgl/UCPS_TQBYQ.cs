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

namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPS_TQBYQ : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_tqbyq> gridViewOperation;

        public event SendDataEventHandler<PS_tqbyq> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmtqbyqEdit frm = new frmtqbyqEdit();
        private string parentID = null;
        private PS_tq parentObj;
        public UCPS_TQBYQ()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_tqbyq>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_tqbyq>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_tqbyq>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_tqbyq> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_tqbyq> e)
        {
            if (parentObj == null)
            {
                e.Cancel = true;
                MsgBox.ShowTipMessageBox("台区不能为空！");
            }
            else
            {

                //PS_tq tq = MainHelper.PlatformSqlMap.GetOneByKey<PS_tq>(parentID);
                //e.Value.byqInstallAdress = tq.Adress; 
            
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
            btXlList.EditValueChanged += new EventHandler(btXlList_EditValueChanged);
            btGtList.EditValueChanged += new EventHandler(btGtList_EditValueChanged);
            btTQList.EditValueChanged += new EventHandler(btTQList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btTQList_EditValueChanged(object sender, EventArgs e)
        {
            parentID = btTQList.EditValue.ToString();
            if (parentID != "")
            {
                IList<PS_tq> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>("where tqID='" + parentID + "'");
                PS_tq tq = null;
                if (list.Count > 0)
                {
                    tq = list[0];
                    ParentObj = tq;
                }
            }
        }

        void btGtList_EditValueChanged(object sender, EventArgs e)
        {
            IList<PS_tq> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>("where gtID='" + btGtList.EditValue.ToString() + "'");
            repositoryItemLookUpEdit4.DataSource = list;
 
        }

        void btXlList_EditValueChanged(object sender, EventArgs e)
        {
            string xlcode = btXlList.EditValue.ToString();
            if (string.IsNullOrEmpty(xlcode)) return;
            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + xlcode + "'");
            repositoryItemLookUpEdit3.DataSource = list;
            IList<PS_tq> list2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_tq>(string.Format("where left(tqcode,{0})='{1}'", xlcode.Length, xlcode));
            repositoryItemLookUpEdit4.DataSource = list2;
            
            RefreshData(string.Format(" where left(byqcode,{0})='{1}'",xlcode.Length,xlcode));
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];
            
            if (org != null)
            {
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "' and linevol='10'");
                repositoryItemLookUpEdit2.DataSource = xlList;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_tqbyq);
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
        /// 隐藏选择列表
        /// </summary>
        public void HideList()
        {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btGtList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btTQList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar3.Visible = false;
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            //hideColumn("ParentID");
            //hideColumn("gzrjID");
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
        public GridViewOperation<PS_tqbyq> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_tqbyq newobj)
        {

            if (gridView1.FocusedRowHandle > -1) {
                PS_tqbyq tq = gridView1.GetFocusedRow() as PS_tqbyq;
                Ebada.Core.ConvertHelper.CopyTo(tq, newobj);
                
            }
            //newobj.byqInstallAdress = parentObj.Adress;
            newobj.byqName = "";
            newobj.tqID = parentID;
            newobj.byqCode = newobj.byqID = getcode();

        }
        string getcode() {
            string code = "";

            if (gridViewOperation.BindingList.Count > 0) {
                int maxcode = 0; 
                string tqcode = gridViewOperation.BindingList[0].byqCode;
                foreach (PS_tqbyq node in gridViewOperation.BindingList) {
                    tqcode = node.byqCode;
                    maxcode = Math.Max(maxcode, int.Parse(tqcode.Substring(tqcode.Length - 2, 2)));
                }
                code = tqcode.Substring(0, tqcode.Length - 2) + (maxcode + 1).ToString("00");

            } else {
                code = parentObj.tqCode + "01";
            }

            return code;
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
                    RefreshData(" where tqID='" + value + "' order by byqCode");
                }
                else
                {
                    string tempstr = " 235@$U#u#$";
                    RefreshData(" where tqID='" + tempstr + "' order by byqCode");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_tq ParentObj
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
                    ParentID = value.tqID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle>=0)
            {
                gridControl1.ExportToXls("C:\\temp.xls");
                System.Diagnostics.Process.Start("C:\\temp.xls");
            }
           
           
        }
    }
}
