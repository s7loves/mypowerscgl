/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-3-3
最后一次修改:2011-3-3
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

namespace Ebada.Modules.Demo {
    /// <summary>
    /// GridView查询示例
    /// </summary>
    public partial class UCGridView : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Empolyees> gridViewOperation;
        
        public event SendDataEventHandler<Empolyees> FocusedRowChanged;
        private string parentID;
        public UCGridView() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<Empolyees>(gridControl1, gridView1, barManager1, new frmEmpolyeesEdit());
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as Empolyees);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        public GridViewOperation<Empolyees> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Empolyees newobj) {
            newobj.Empolyee_ID = newobj.CreateID();
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
            }
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e) {
            gridViewOperation.FindShowType = (ShowType)Enum.Parse(typeof(ShowType), btShowType.EditValue.ToString());
        }

        private void btShowType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            
        }
    }
}
