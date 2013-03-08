/**********************************************
系统:企业ERP
模块:变电所维护
作者:Rabbit
创建时间:2011-5-20
最后一次修改:2011-5-20
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

namespace Ebada.Scgl.Sbgl {
   
    //[ToolboxItem(false)]
    public partial class UCBD_SX : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<BD_SBTZ_SX> gridViewOperation;
        List<string> enableList = new List<string>();
        public event SendDataEventHandler<BD_SBTZ_SX> FocusedRowChanged;
        private string parentID;
        private string addColName="";
        private string editColValue="";
        private BD_SBTZ_ZL parentObject;
        public UCBD_SX()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<BD_SBTZ_SX>(gridControl1, gridView1, barManager1);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<BD_SBTZ_SX>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<BD_SBTZ_SX>(gridViewOperation_BeforeInsert);
            gridView1.Click += new EventHandler(gridView1_Click);
            enableList.AddRange(new string[]{"a1","a2","a3","a4","a5","a6","a7","a8"});
        }

        #region 
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<BD_SBTZ_SX> e)
        {
            if (enableList.Contains((e.Value as BD_SBTZ_SX).sxcol))
            {
                MessageBox.Show("不能添加a1-a8之间的值");
                e.Cancel = true;
            }
            IList<BD_SBTZ_SX> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<BD_SBTZ_SX>("where sxcol='" + (e.Value as BD_SBTZ_SX).sxcol + "'" +
                "and zldm='" + parentID + "'");
            if (list.Count > 0)
            {
                MessageBox.Show("字段添加重复，添加数据失败！");
                e.Cancel = true;
            }
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<BD_SBTZ_SX> e)
        {

            if (enableList.Contains((e.Value as BD_SBTZ_SX).sxcol))
            {
                //不创建类
                MessageBox.Show("不能添加a1-a8之间的值");
                e.Cancel = true;

            }
            IList<BD_SBTZ_SX> list= Client.ClientHelper.PlatformSqlMap.GetListByWhere<BD_SBTZ_SX>("where sxcol='" + (e.Value as BD_SBTZ_SX).sxcol + "'"+
                "and zldm='"+parentID+"'");
            if (list.Count > 0)
            {
                MessageBox.Show("字段添加重复，添加数据失败！");
                e.Cancel = true;
            }
        }
        #endregion
        
        void gridView1_Click(object sender, EventArgs e) {
            if (FocusedRowChanged != null && focusedRow!=gridView1.GetFocusedRow()) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as BD_SBTZ_SX);
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        object focusedRow;
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {

            BD_SBTZ_SX sbsx = gridView1.GetFocusedRow() as BD_SBTZ_SX;
            if (sbsx != null)
            {
                string enablestr = sbsx.sxcol;
                if (enableList.Contains(enablestr))
                {
                    btEdit.Enabled = false;
                    btDelete.Enabled = false;
                }
                else
                {
                    btEdit.Enabled = true;
                    btDelete.Enabled = true;
                }
            }
            else
            {
                btEdit.Enabled = false;
                btDelete.Enabled = false;
            }
            
            if (FocusedRowChanged != null) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as BD_SBTZ_SX);
                
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {
            foreach (GridColumn c in gridView1.Columns)
            {
                c.Visible = false;
            }
            int m = 1;
            //sxcol(属性列)、sxname(属性名)、isvisible(是否显示)、isdel(是否可删除)、isedit(是否可修改)
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbox.Items.Add("是");
            cbox.Items.Add("否");
            gridView1.Columns["sxcol"].Visible = true;
            gridView1.Columns["sxcol"].VisibleIndex = m;
            m++;
            gridView1.Columns["sxname"].Visible = true;
            gridView1.Columns["sxname"].VisibleIndex = m;
            m++;
            gridView1.Columns["norder"].Visible = true;
            gridView1.Columns["norder"].VisibleIndex = m;
            m++;
            gridView1.Columns["isvisible"].Visible = true;
            gridView1.Columns["isvisible"].ColumnEdit = cbox;
            gridView1.Columns["isvisible"].VisibleIndex = m;
            m++;
            gridView1.Columns["isdel"].Visible = true;
            gridView1.Columns["isdel"].ColumnEdit = cbox;
            gridView1.Columns["isdel"].VisibleIndex = m;
            m++;
            gridView1.Columns["isedit"].Visible = true;
            gridView1.Columns["isedit"].ColumnEdit = cbox;
            gridView1.Columns["isvisible"].VisibleIndex = m;

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
        public GridViewOperation<BD_SBTZ_SX> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(BD_SBTZ_SX newobj) {
           
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if(value!=null)
                    RefreshData("where zldm='" + parentID + "' order by Convert(int,norder)");
            }
        }

        public BD_SBTZ_ZL ParentObject
        {
            get { return this.parentObject; }
            set
            {
                if (value != null)
                {
                    this.parentObject = value;
                    ParentID = value.dm;
                }
            }
        }

        public void HideList() {
            bar1.Visible = false;
            bar3.Visible = false;
        }
    }
}
