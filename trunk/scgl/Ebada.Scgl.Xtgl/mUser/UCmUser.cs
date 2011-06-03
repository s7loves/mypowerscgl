/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-2-28
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

namespace Ebada.Scgl.Xtgl {

    public partial class UCmUser : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<mUser> gridViewOperation;
        
        public event SendDataEventHandler<mUser> FocusedRowChanged;
        private string parentID;
        public UCmUser() {
            InitializeComponent();
            initImageList();
            
            gridViewOperation = new GridViewOperation<mUser>(gridControl1, gridView1, barManager1);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<mUser>(gridViewOperation_BeforeAdd);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            initColumns();
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            gridView1.Columns["OrgCode"].Visible = true;
            gridView1.Columns["OrgName"].Visible = false;
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<mUser> e) {
            if (string.IsNullOrEmpty(parentID)) {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择机构后增加职员！");
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as mUser);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<mUser> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(mUser newobj) {
            newobj.OrgCode = parentID;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                
                string str=" where 1>1";
                if (value == "") {
                    str = "";
                    parentID = null;
                } else {
                    parentID = value;

                    if (!string.IsNullOrEmpty(parentID)) {
                        str = string.Format("where OrgCode='{0}'", parentID);
                    }
                }
                gridViewOperation.RefreshData(str);
            }
        }
    }
}
