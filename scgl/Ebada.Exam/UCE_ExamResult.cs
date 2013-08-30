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
    public partial class UCE_ExamResult : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_ExamResult> gridViewOperation;
        private string parentID = null;
        private E_ExamResult parentObj;
        public event SendDataEventHandler<E_ExamResult> FocusedRowChanged;

        public string SqlWhere
        {
            set
            {
                if (value!=null)
                {
                    RefreshData(value);
                }
            }
        }

        public UCE_ExamResult()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_ExamResult>(gridControl1, gridView1, barManager1);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_ExamResult>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_ExamResult>(gridViewOperation_BeforeDelete);
            gridViewOperation.FocusedRowChanged += new SendDataEventHandler<E_ExamResult>(gridViewOperation_FocusedRowChanged);
            barLkueExam.EditValueChanged += new EventHandler(barLkueExam_EditValueChanged);
        }

        void barLkueExam_EditValueChanged(object sender, EventArgs e)
        {
            if (barLkueExam.EditValue!=null&&barLkueExam.EditValue.ToString()!=string.Empty)
            {
                string sqlwhere = " where E_ID='" + barLkueExam.EditValue.ToString() + "' order by Score desc";
                RefreshDataOrder(sqlwhere);
            }
        }

        void gridViewOperation_FocusedRowChanged(object sender, E_ExamResult obj)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as E_ExamResult);
        }
        

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_ExamResult> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_ExamResult> e) {
   
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

            //hideColumn("ID");
            gridView1.Columns["E_ID"].ColumnEdit = DicTypeHelper.E_Exam;
            gridView1.Columns["UserID"].ColumnEdit = DicTypeHelper.UserDic;
            gridView1.Columns["Sequence"].Visible = false;
            barLkueExam.Edit = DicTypeHelper.E_Exam;
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshDataOrder(string sqlhwere)
        {
            IList<E_ExamResult> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<E_ExamResult>(sqlhwere);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Sequence = i + 1;
            }
            gridControl1.DataSource = list;
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<E_ExamResult> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_ExamResult newobj) {

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
                    RefreshData(" where ID='" + value + "' order by dxxh");
                }
                else
                {
                    RefreshData(" where dydj='10' order by dxxh");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public E_ExamResult ParentObj
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
                    ParentID = value.ID;
                }
            }
        }
    }
}
