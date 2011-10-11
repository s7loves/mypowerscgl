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

namespace Ebada.SCGL.WFlow.Tool
{

    public partial class UCmExcel : DevExpress.XtraEditors.XtraUserControl {
        public GridViewOperation<LP_Temple> gridViewOperation;
        private static string strParentID;
        public static string GetParentID()
        {
            return strParentID;
        }
        public event SendDataEventHandler<LP_Temple> FocusedRowChanged;
        private string parentID;
        private LP_Temple parentObj;
        public UCmExcel() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<LP_Temple>(gridControl1, gridView1, barManager1, new frmExcelModelEdit());
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeAdd);
            gridViewOperation.AfterAdd += new ObjectEventHandler<LP_Temple>(gridViewOperation_AfterAdd);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeInsert);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeEdit);
            initColumns();
        }

        void gridViewOperation_AfterAdd(LP_Temple obj)
        {
            parentID = ParentObj.LPID;
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<LP_Temple> e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择模板后再修改模板！");

            }

            if(e.Value.DocContent.Length==0)e.Value.DocContent = parentObj.DocContent;
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<LP_Temple> e) {
            //if (e.Value.Password.Length <= 12) {
            //    e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
            //} 
            byte[] bt = new byte[0];
            if (e.Value.DocContent == null)
            {
                e.Value.DocContent = bt;
            }
            if (e.Value.ImageAttachment == null)
            {
                e.Value.ImageAttachment = bt;
            }
            if (e.Value.SignImg == null)
            {
                e.Value.SignImg = bt;
            }
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<LP_Temple> e) {
            //e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            gridView1.Columns["ParentID"].Visible = false;
            //gridView1.Columns["OrgName"].Visible = false;
            //gridView1.Columns["Password"].ColumnEdit = repositoryItemTextEdit1;
            repositoryItemTextEdit1.EditValueChanged += new EventHandler(repositoryItemTextEdit1_EditValueChanged);
        }

        void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e) {
            
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<LP_Temple> e) {
            if (string.IsNullOrEmpty(parentID)) {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择模板后再修改模板！");

            }
            e.Value.DocContent = parentObj.DocContent;
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as LP_Temple);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<LP_Temple> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(LP_Temple newobj) {
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            //newobj.Valid = true;          
            newobj.ParentID = parentID;
            newobj.Kind = ParentObj.Kind;
            byte[] bt = new byte[0];
            newobj.DocContent = bt;
            newobj.ImageAttachment = bt;
            newobj.SignImg = bt;
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
                        str = string.Format("where parentid='{0}'", parentID);
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

                parentObj = value;
                if (value == null) {
                    parentID = null;
                    strParentID = null;
                } else {
                    ParentID = value.LPID;
                    strParentID = value.LPID;
                }
            }
        }

    }
}
