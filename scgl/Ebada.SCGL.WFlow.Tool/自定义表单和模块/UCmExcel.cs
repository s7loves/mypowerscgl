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
using Ebada.Components;
using DevExpress.XtraGrid;
using DevExpress.Data;

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
            gridViewOperation.AfterEdit += new ObjectEventHandler<LP_Temple>(gridViewOperation_AfterEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<LP_Temple>(gridViewOperation_AfterDelete);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeInsert);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<LP_Temple>(gridViewOperation_BeforeEdit);
            initColumns();
        }
        void inidata()
        {
            string str = string.Format("where parentid='{0}' order by status,SortID", parentID);
            gridViewOperation.RefreshData(str);
        
        }
        void gridViewOperation_AfterEdit(LP_Temple obj)
        {
            inidata();
        }
        void gridViewOperation_AfterDelete(LP_Temple obj)
        {
            string slqwhere = " where ParentID='" + obj.ParentID + "' ";

            slqwhere = slqwhere + " order by SortID";
            IList<LP_Temple> li = MainHelper.PlatformSqlMap.GetListByWhere<LP_Temple>(slqwhere);
            int i = 1;
            List<LP_Temple> list = new List<LP_Temple>();
            foreach (LP_Temple ob in li)
            {
                ob.SortID= i;
                if (ob.SignImg == null)
                {
                    ob.SignImg = new byte[0];
                }
                if (ob.ImageAttachment == null)
                {
                    ob.ImageAttachment = new byte[0];
                }
                if (ob.DocContent == null)
                {
                    ob.DocContent = new byte[0];
                }
                i++;
                list.Add(ob);
            }
            List<SqlQueryObject> list3 = new List<SqlQueryObject>();
            if (list.Count > 0)
            {
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            inidata();
        }
        void gridViewOperation_AfterAdd(LP_Temple obj)
        {
            parentID = ParentObj.LPID;
            inidata();
        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<LP_Temple> e)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                e.Cancel = true;
                MsgBox.ShowWarningMessageBox("请先选择模板后再修改模板！");

            }

            if (e.Value.DocContent==null||e.Value.DocContent.Length == 0) e.Value.DocContent = parentObj.DocContent;
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
            string slqwhere = " where ParentID='" + e.Value.ParentID + "' and SortID =" + e.Value.SortID + " and lpid!='" + e.Value.LPID+"'";
            IList<LP_Temple> li = MainHelper.PlatformSqlMap.GetListByWhere<LP_Temple>(slqwhere);
            if (li.Count > 0)
            {
                //li[0].SortID = e.ValueOld.SortID;
                //if (li[0].DocContent == null)
                //{
                //    li[0].DocContent = bt;
                //}
                //if (li[0].ImageAttachment == null)
                //{
                //    li[0].ImageAttachment = bt;
                //}
                //if (li[0].SignImg == null)
                //{
                //    li[0].SignImg = bt;
                //}
                //MainHelper.PlatformSqlMap.Update<LP_Temple>(li[0]);
                slqwhere = " where ParentID='" + e.Value.ParentID + "' and SortID>" + e.ValueOld.SortID + " and lpid!='" + e.Value.LPID + "' and SortID<=" + e.Value.SortID;

                slqwhere = slqwhere + " order by SortID";
                 li = MainHelper.PlatformSqlMap.GetListByWhere<LP_Temple>(slqwhere);
                int i = 1;
                List<LP_Temple> list = new List<LP_Temple>();
                foreach (LP_Temple ob in li)
                {
                    ob.SortID = ob.SortID-1;
                    if (ob.SignImg == null)
                    {
                        ob.SignImg = new byte[0];
                    }
                    if (ob.ImageAttachment == null)
                    {
                        ob.ImageAttachment = new byte[0];
                    }
                    if (ob.DocContent == null)
                    {
                        ob.DocContent = new byte[0];
                    }
                    list.Add(ob);
                }
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                if (list.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                    list3.Add(obj3);
                }
                slqwhere = " where ParentID='" + e.Value.ParentID + "' and SortID<=" + e.ValueOld.SortID + " and lpid!='" + e.Value.LPID + "' and SortID>=" + e.Value.SortID;

                slqwhere = slqwhere + " order by SortID";
                li = MainHelper.PlatformSqlMap.GetListByWhere<LP_Temple>(slqwhere);

                foreach (LP_Temple ob in li)
                {
                    ob.SortID = ob.SortID + 1;
                    if (ob.SignImg == null)
                    {
                        ob.SignImg = new byte[0];
                    }
                    if (ob.ImageAttachment == null)
                    {
                        ob.ImageAttachment = new byte[0];
                    }
                    if (ob.DocContent == null)
                    {
                        ob.DocContent = new byte[0];
                    }
                    list.Add(ob);
                }
                 list3 = new List<SqlQueryObject>();
                if (list.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                    list3.Add(obj3);
                }

                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            }

           
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<LP_Temple> e) {
            //e.Value.Password = MainHelper.EncryptoPassword(e.Value.Password);
             string slqwhere = " where ParentID='" + e.Value.ParentID + "' and SortID =" + e.Value.SortID + " and lpid!='" + e.Value.LPID+"'";
            IList<LP_Temple> li = MainHelper.PlatformSqlMap.GetListByWhere<LP_Temple>(slqwhere);
            if (li.Count > 0)
            {
                //li[0].SortID = e.ValueOld.SortID;
                //if (li[0].DocContent == null)
                //{
                //    li[0].DocContent = bt;
                //}
                //if (li[0].ImageAttachment == null)
                //{
                //    li[0].ImageAttachment = bt;
                //}
                //if (li[0].SignImg == null)
                //{
                //    li[0].SignImg = bt;
                //}
                //MainHelper.PlatformSqlMap.Update<LP_Temple>(li[0]);
                slqwhere = " where ParentID='" + e.Value.ParentID + "' and SortID>=" + e.ValueOld.SortID + " and lpid!='" + e.Value.LPID + "'";

                slqwhere = slqwhere + " order by SortID";
                li = MainHelper.PlatformSqlMap.GetListByWhere<LP_Temple>(slqwhere);
                int i = 1;
                List<LP_Temple> list = new List<LP_Temple>();
                foreach (LP_Temple ob in li)
                {
                    ob.SortID = ob.SortID + 1;
                    if (ob.SignImg == null)
                    {
                        ob.SignImg = new byte[0];
                    }
                    if (ob.ImageAttachment == null)
                    {
                        ob.ImageAttachment = new byte[0];
                    }
                    if (ob.DocContent == null)
                    {
                        ob.DocContent = new byte[0];
                    }
                    list.Add(ob);
                }
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                if (list.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                    list3.Add(obj3);
                    MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
                }
            }
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            gridView1.Columns["ParentID"].Visible = false;
            //gridView1.Columns["OrgName"].Visible = false;
            //gridView1.Columns["Password"].ColumnEdit = repositoryItemTextEdit1;
            gridView1.Columns["CellName"].VisibleIndex = 1;
            gridView1.Columns["SortID"].VisibleIndex = 0;
            gridView1.Columns["CellPos"].VisibleIndex = 1;
            gridView1.Columns["SortID"].SortOrder = ColumnSortOrder.Ascending;
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
            string slqwhere = " where ParentID='" + e.Value.ParentID + "' ";
            e.Value.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere) + 1;
            e.Value.WordCount = "50";
            e.Value.CtrlSize = "200,20";
            slqwhere = " where ParentID='" + e.Value.ParentID + "' ";

            e.Value.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere)+1;

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
                        str = string.Format("where parentid='{0}' order by status,SortID", parentID);
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

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (string.IsNullOrEmpty(parentID))
            //{
               
            //    MsgBox.ShowWarningMessageBox("请先选择模板后再修改模板！");
            //    return;
            //}
            //frmExcelModelEdit frm = new frmExcelModelEdit();
            //LP_Temple lpr = new LP_Temple();
            //lpr.ParentID = ParentObj.LPID;
            //string slqwhere = " where ParentID='" +lpr.ParentID + "' ";
            //lpr.SortID = MainHelper.PlatformSqlMap.GetRowCount<LP_Temple>(slqwhere) + 1;
            //lpr.DocContent = parentObj.DocContent;
            //frm.RowData = lpr;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    MainHelper.PlatformSqlMap.Create<LP_Temple>(lpr);
            //    inidata();
            //}
        }

    }
}
