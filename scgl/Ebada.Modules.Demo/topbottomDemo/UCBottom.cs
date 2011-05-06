/**********************************************
系统:Ebada物流企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-3-1
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
using Ebada.Platform.Model;
using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;

namespace Ebada.Modules.Demo {

    public partial class UCBottom : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Empolyees> gridViewOperation;
        private string parentID;
        public UCBottom() {
            InitializeComponent();
            initImageList();
            initColumns();
            gridViewOperation = new GridViewOperation<Empolyees>(gridControl1, gridView1, barManager1, new frmEmpolyeesEdit(),new UCBottomFind());
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<Empolyees>(gridViewOperation_BeforeAdd);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            
        }
        /// <summary>
        /// 获取相应parentid子表的记录,用于判定是否可以删除父表记录。
        /// </summary>
        /// <returns></returns>
        public int GetRowCount() {
            return gridViewOperation.BindingList.Count;
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<Empolyees> e) {
            //判断是否有parentid值，如果没有不允许增加子表记录
            if (string.IsNullOrEmpty(parentID)) {
                e.Cancel = true;
                MainHelper.ShowWarningMessageBox("请先选择单位后增加职员！");
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<Empolyees> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Empolyees newobj) {
            newobj.Org_ID = parentID;//给新记录设置parentid;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                string str=" where 1>1";
                if(!string.IsNullOrEmpty(value)){
                    str = string.Format("where Org_ID='{0}'", value);
                }
                gridViewOperation.RefreshData(str);
            }
        }
    }
}
