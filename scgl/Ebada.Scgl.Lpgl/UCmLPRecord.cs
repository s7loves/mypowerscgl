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

namespace Ebada.Scgl.Lpgl {

    public partial class UCmLPRecord : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<LP_Record> gridViewOperation;
        private static string strKind;
        public static string GetParentKind()
        {
            return strKind;
        }
        private static string status;
        public static string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public event SendDataEventHandler<LP_Record> FocusedRowChanged;
        private string parentID;
        private LP_Temple parentObj;
        public UCmLPRecord() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<LP_Record>(gridControl1, gridView1, barManager1,new frmLP());
            //gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeEdit);
            //gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            //gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeInsert);
            //gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<LP_Record>(gridViewOperation_BeforeUpdate);
            initColumns();
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<LP_Record> e)
        {
            Status = "edit";
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<LP_Record> e)
        {
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<LP_Record> e)
        {
            //e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            gridView1.Columns["ParentID"].Visible = false;
            //gridView1.Columns["ID"].Visible = false;
            //gridView1.Columns["OrgName"].Visible = false;
            //gridView1.Columns["Password"].ColumnEdit = repositoryItemTextEdit1;
            //repositoryItemTextEdit1.EditValueChanged += new EventHandler(repositoryItemTextEdit1_EditValueChanged);
        }

        void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e) {
            
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<LP_Record> e)
        {
            Status = "add";
            //if (string.IsNullOrEmpty(parentID)) {
            //    e.Cancel = true;
            //    MsgBox.ShowWarningMessageBox("请先选择模板后再修改模板！");
            //}
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as LP_Record);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<LP_Record> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(LP_Record newobj)
        {

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
                        str = string.Format("where kind='{0}'", parentID);
                    }
                }
                gridViewOperation.RefreshData(str);
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LP_Temple ParentObj {
            get { return parentObj; }
            set {
                    string str=" where 1>1";
                    parentObj = value;
                    if (value == null) {
                        str = "";
                       // parentID = null;
                       strKind = null;
                    } else {
                      // ParentID = value.LPID;
                        strKind = value.Kind;
                        
                        if (!string.IsNullOrEmpty(value.Kind)) {
                            str = string.Format("where kind='{0}'", value.Kind);
                        }
                    }
                    gridViewOperation.RefreshData(str);

            }
        }

    }
}
