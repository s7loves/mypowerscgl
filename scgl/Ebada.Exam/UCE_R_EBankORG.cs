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

namespace Ebada.Exam {
    /// <summary>
    /// 
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCE_R_EBankORG : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_R_EBankORG> gridViewOperation;
        private string parentID = null;
        private E_R_EBankORG parentObj;
        public event SendDataEventHandler<E_R_EBankORG> FocusedRowChanged;

        public UCE_R_EBankORG()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_R_EBankORG>(gridControl1, gridView1, barManager1,new FrmE_R_EBankORGEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_R_EBankORG>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_R_EBankORG>(gridViewOperation_BeforeDelete);
           

        }

       
        

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_R_EBankORG> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_R_EBankORG> e) {
               if (ParentID==string.Empty||ParentID==null)
	        {
                   MsgBox.ShowWarningMessageBox("请选择题库！");
                   e.Cancel=true;
                   return;
	        }
               e.Value.EBID = ParentID;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            //InitColumns();//初始列
            InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }

        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            InitColumns();
            //RefreshData(" ");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            gridView1.Columns["ORGID"].ColumnEdit = DicTypeHelper.OrgDic;
            gridView1.Columns["ORGID"].Width = 150;
            //hideColumn("ID");
            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<E_R_EBankORG> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_R_EBankORG newobj) {
            newobj.EBID = ParentID;
        }

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
                    RefreshData(" where EBID='" + value + "'");
                }
            }
        }
       
       
    }
}
