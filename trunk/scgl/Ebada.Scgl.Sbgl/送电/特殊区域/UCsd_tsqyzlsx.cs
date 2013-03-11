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
    public partial class UCsd_tsqyzlsx : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sd_tsqyzlsx> gridViewOperation;
        List<string> enableList = new List<string>();
        public event SendDataEventHandler<sd_tsqyzlsx> FocusedRowChanged;
        private string parentID;
        private string addColName="";
        private string editColValue="";
        private sd_tsqyzl parentObject;
        public UCsd_tsqyzlsx()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_tsqyzlsx>(gridControl1, gridView1, barManager1);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<sd_tsqyzlsx>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<sd_tsqyzlsx>(gridViewOperation_BeforeInsert);
            gridView1.Click += new EventHandler(gridView1_Click);
            enableList.AddRange(new string[] { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" });
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sd_tsqyzlsx>(gridViewOperation_BeforeAdd);
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sd_tsqyzlsx> e) {
            if (parentObject == null) e.Cancel = true;
        }

        #region 
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<sd_tsqyzlsx> e)
        {
            if (enableList.Contains((e.Value as sd_tsqyzlsx).sxcol))
            {
                MessageBox.Show("不能添加a1-a8之间的值");
                e.Cancel = true;
            }
            IList<sd_tsqyzlsx> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_tsqyzlsx>("where sxcol='" + (e.Value as sd_tsqyzlsx).sxcol + "'" +
                "and zldm='" + parentID + "'");
            if (list.Count > 0)
            {
                MessageBox.Show("字段添加重复，添加数据失败！");
                e.Cancel = true;
            }
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<sd_tsqyzlsx> e)
        {

            if (enableList.Contains((e.Value as sd_tsqyzlsx).sxcol))
            {
                //不创建类
                MessageBox.Show("不能添加a1-a8之间的值");
                e.Cancel = true;

            }
            IList<sd_tsqyzlsx> list= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_tsqyzlsx>("where sxcol='" + (e.Value as sd_tsqyzlsx).sxcol + "'"+
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_tsqyzlsx);
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

            sd_tsqyzlsx sbsx = gridView1.GetFocusedRow() as sd_tsqyzlsx;
            if (sbsx != null) {
                string enablestr = sbsx.sxcol;
                if (enableList.Contains(enablestr)) {
                    btEdit.Enabled = false;
                    btDelete.Enabled = false;
                } else {
                    btEdit.Enabled = true;
                    btDelete.Enabled = true;
                }
            } else {
                btEdit.Enabled = false;
                btDelete.Enabled = false;
            }
            
            if (FocusedRowChanged != null) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_tsqyzlsx);
                
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            //gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {
            //foreach (GridColumn c in gridView1.Columns)
            //{
            //    c.Visible = false;
            //}
            gridView1.Columns["zldm"].Visible = false;
            int m = 1;
            //sxcol(属性列)、sxname(属性名)、isuse(是否显示)、isdel(是否可删除)、isedit(是否可修改)
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbox.Items.Add("是");
            cbox.Items.Add("否");
            gridView1.Columns["isuse"].ColumnEdit = cbox;
            gridView1.Columns["isdel"].ColumnEdit = cbox;
            gridView1.Columns["isedit"].ColumnEdit = cbox;
            //gridView1.Columns["sxcol"].Visible = true;
            //gridView1.Columns["sxcol"].VisibleIndex = m;
            //m++;
            //gridView1.Columns["sxname"].Visible = true;
            //gridView1.Columns["sxname"].VisibleIndex = m;
            //m++;
            //gridView1.Columns["norder"].Visible = true;
            //gridView1.Columns["norder"].VisibleIndex = m;
            //m++;
            //gridView1.Columns["isuse"].Visible = true;
            //gridView1.Columns["isuse"].VisibleIndex = m;
            //m++;
            //gridView1.Columns["isdel"].Visible = true;
            //gridView1.Columns["isdel"].VisibleIndex = m;
            //m++;
            //gridView1.Columns["isedit"].Visible = true;
            //gridView1.Columns["isedit"].VisibleIndex = m;

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
        public GridViewOperation<sd_tsqyzlsx> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sd_tsqyzlsx newobj) {
            newobj.zldm = parentID;
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
                if (value != null) {
                    RefreshData("where zldm='" + parentID + "' order by norder");
                    if (gridView1.RowCount == 0) {
                        createzlsx();
                    }
                } else
                    RefreshData("where 1>1");
            }
        }

        private void createzlsx() {
            List<sd_tsqyzlsx> list = new List<sd_tsqyzlsx>();
            for (int i = 1; i <= 25; i++) {
                sd_tsqyzlsx sx = new sd_tsqyzlsx() {
                     zldm=parentID, sxcol="a"+i,sxname="属性"+i, isdel="是",isedit="是",isuse="否"
                     , norder=i, vtype="文本", ctype=""
                };
                list.Add(sx);
            }
            ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(list.ToArray(), null, null);
        }

        public sd_tsqyzl ParentObject
        {
            get { return this.parentObject; }
            set
            {
                if (value != null) {
                    this.parentObject = value;
                    ParentID = value.zldm;
                } else {
                    ParentID = null;
                }
            }
        }

        public void HideList() {
            bar1.Visible = false;
            bar3.Visible = false;
        }
    }
}
