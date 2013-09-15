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
    public partial class UCE_QuestionBankForAdd : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<E_QuestionBank> gridViewOperation;

        public  delegate void RemoveObj( Dictionary<string, E_QuestionBank> dic );
        public event RemoveObj DeleteObj;

        public int DesNum;

        //标识，0为源列表，1为目标列表
        public int intfalg = 0;

        public string pid;
        public string type;
        public  Dictionary<string, E_QuestionBank> eqdic;

        private string parentID = null;


        public UCE_QuestionBankForAdd( )
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<E_QuestionBank>(gridControl1, gridView1, barManager1,new FrmE_QuestionBankEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<E_QuestionBank>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<E_QuestionBank>(gridViewOperation_BeforeDelete);
            gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
      
        }

        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow()!=null)
            {
                if (DeleteObj!=null)
                {
                    E_QuestionBank tempeq = gridView1.GetFocusedRow() as E_QuestionBank;
                    if (intfalg==0)
                    {
                        if (DesNum==eqdic.Count)
                        {
                            MsgBox.ShowWarningMessageBox("您已添加足够的" + type + "不能再添加了！");
                            return;
                        }
                        eqdic.Add(tempeq.ID, tempeq);
                    }
                    else
                    {
                        if (eqdic.ContainsKey(tempeq.ID))
                        {
                            eqdic.Remove(tempeq.ID);
                        }
                    }
                    DataRefresh();
                    DeleteObj(eqdic);
                }
            }
        }
        public  void DataRefresh()
        {
            string sql = " where ";
           
            sql += " Professional='" + pid + "'";
            if (type != null)
            {
                if (sql.Length > 7)
                {
                    sql += " and ";
                }
                sql += " Type='" + type + "'";
            }
            if (sql.Length > 7)
            {
                if (intfalg==0)
                {
                    if (eqdic!=null&&eqdic.Count>0)
                    {
                        sql += " and ByScol1!='del'  and ID not in (" + getsql() + ") order by Professional,Type";
                    }
                    else
                    {
                        sql += " and ByScol1!='del'  order by Professional,Type";
                    }
                    
                }
                else
                {
                    if (eqdic != null && eqdic.Count > 0)
                    {
                        sql += " and ByScol1!='del'  and ID in (" + getsql() + ") order by Professional,Type";
                    }
                    else
                    {
                        sql += " and ByScol1!='del'  and ByScol1='del'   order by Professional,Type";
                    }
                    
                }
                RefreshData(sql);
            }
           
            
        }

        string getsql()
        {
            string str = string.Empty;
            if (eqdic!=null)
            {
                foreach (string key in eqdic.Keys)
                {
                    str += "'" + key + "' ,";
                }
                if (str.Length>2)
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            return str;
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<E_QuestionBank> e) {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<E_QuestionBank> e) {
              
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);


         

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
            DataRefresh();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            gridView1.Columns["Professional"].ColumnEdit = DicTypeHelper.E_proDic;
            gridView1.Columns["DifficultyLevel"].ColumnEdit = DicTypeHelper.E_QuestionBankDic;

            gridView1.Columns["Title"].Width = 400;
            gridView1.Columns["Option"].Width = 120;
            gridView1.Columns["Answer"].Width = 60;
            gridView1.Columns["Explain"].Width = 100;
            gridView1.Columns["DifficultyLevel"].Width = 60;
            gridView1.Columns["Professional"].Width = 90;


          
            
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
        public GridViewOperation<E_QuestionBank> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
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
