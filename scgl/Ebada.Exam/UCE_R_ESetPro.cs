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
using System.Data.OleDb;

namespace Ebada.Exam {
    /// <summary>
    /// 
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCE_R_ESetPro : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_R_ESetPro> gridViewOperation;
        private string parentID = null;
        private E_R_ESetPro parentObj;
        public event SendDataEventHandler<E_R_ESetPro> FocusedRowChanged;

        public delegate  void edit();
        public event edit AfterEdit;
        string _esetid = string.Empty;
        public string ESETID
        {
            set
            {
                _esetid = value;
                Refresh();
            }
            get
            {
                return _esetid;
            }
        }


        public UCE_R_ESetPro()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_R_ESetPro>(gridControl1, gridView1, barManager1,new FrmE_R_ESetProEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_R_ESetPro>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_R_ESetPro>(gridViewOperation_BeforeDelete);
            gridViewOperation.AfterEdit += new ObjectEventHandler<E_R_ESetPro>(gridViewOperation_AfterEdit);
          
        }

        void gridViewOperation_AfterEdit(E_R_ESetPro obj)
        {
            if (AfterEdit != null)
            {
                AfterEdit();
            }
        }

        void barTypeCom_EditValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        void barEproLuk_EditValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }
        void Refresh()
        {
            string sql = " where ESETID='"+ESETID+"'";
           
            RefreshData( sql);
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_R_ESetPro> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_R_ESetPro> e) {
              
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

            gridView1.Columns["PROID"].ColumnEdit = DicTypeHelper.E_proDic;

            gridView1.Columns["PROID"].Width = 200;
            gridView1.Columns["SelectNUM"].Width = 80;
            gridView1.Columns["MuSelectNUM"].Width = 80;
            gridView1.Columns["JudgeNUM"].Width = 80;
            //IList<E_Professional> orglist = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>("");
            //SetComboBoxData(repositoryItemLookUpEdit1, "PName", "ID", "请选择", "专业", orglist);
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
        public GridViewOperation<E_R_ESetPro> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(E_R_ESetPro newobj) {
            //if (barTypeCom.EditValue!=null)
            //{
            //    newobj.Type = barTypeCom.EditValue.ToString();
            //}
            //if (barEproLuk.EditValue!=null)
            //{
            //    newobj.Professional = barEproLuk.EditValue.ToString();
            //}
            //newobj.DifficultyLevel = 2;
            //newobj.InTime = DateTime.Now;
            //newobj.InUser = MainHelper.User.UserName;
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
                    RefreshData(" where PID='" + value + "'");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<E_Professional> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }
       
        
    }
}
