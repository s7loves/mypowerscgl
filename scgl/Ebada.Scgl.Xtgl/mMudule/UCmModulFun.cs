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
using System.Threading;

namespace Ebada.Scgl.Xtgl {

    public partial class UCmModulFun : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<mModulFun> gridViewOperation;
        
        public event SendDataEventHandler<mModulFun> FocusedRowChanged;
        private string parentID;
        private mModule parentObj;
        public UCmModulFun() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<mModulFun>(gridControl1, gridView1, barManager1);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<mModulFun>(gridViewOperation_BeforeAdd);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<mModulFun>(gridViewOperation_BeforeInsert);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<mModulFun>(gridViewOperation_BeforeUpdate);
            initColumns();
        }

        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<mModulFun> e) {
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<mModulFun> e) {
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            bar3.Visible = false;
            repositoryItemComboBox1.Items.AddRange(Ebada.Scgl.Core.ComboBoxHelper.GetModuFuns());
            gridView1.Columns["FunCode"].ColumnEdit = repositoryItemComboBox1;
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<mModulFun> e) {
            if (string.IsNullOrEmpty(parentID)) {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择模块后增加操作！");
            }
            if (gridView1.RowCount == 0) {
                //增加初始模块
                List<mModulFun> list =new List<mModulFun>();
                list.Add(createFun("btAdd", "增加"));
                Thread.Sleep(10);
                list.Add(createFun("btEdit", "修改"));
                Thread.Sleep(10);
                list.Add(createFun("btDelete", "删除"));
                Thread.Sleep(10);
                list.Add(createFun("btFind", "查询"));
                Thread.Sleep(10); 
                list.Add(createFun("btExport", "导出"));

                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(list, null, null);
                gridViewOperation.RefreshData(string.Format("where Modu_ID='{0}'", parentID));
                e.Cancel = true;
                
            }

        }
        private mModulFun createFun(string code,string name) {
            mModulFun fun = new mModulFun(); fun.FunID = fun.CreateID();
            fun.FunCode = code;
            fun.FunName = name;
            fun.Modu_ID = parentID;
            
            return fun;
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as mModulFun);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<mModulFun> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(mModulFun newobj) {
            newobj.Modu_ID = parentID;
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
                        str = string.Format("where Modu_ID='{0}'", parentID);
                    }
                }
                gridViewOperation.RefreshData(str);
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mModule ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.Modu_ID;
                }
            }
        }
    }
}
