﻿/**********************************************
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
        bool canDel = false;
        public UCBD_SX()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<BD_SBTZ_SX>(gridControl1, gridView1, barManager1);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<BD_SBTZ_SX>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent+=new ObjectEventHandler<BD_SBTZ_SX>(gridViewOperation_CreatingObjectEvent);
            gridViewOperation.AfterAdd += new ObjectEventHandler<BD_SBTZ_SX>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeInsert+=new ObjectOperationEventHandler<BD_SBTZ_SX>(gridViewOperation_BeforeInsert);
           
            gridView1.Click += new EventHandler(gridView1_Click);
            gridView1.CellValueChanged += new CellValueChangedEventHandler(gridView1_CellValueChanged);
            enableList.AddRange(new string[]{"a1","a2","a3","a4","a5","a6","a7","a8"});
            
        }

        void gridViewOperation_AfterAdd(BD_SBTZ_SX obj)
        {
            BD_SBTZ_SX ss = obj;
        }

        void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            object obj = gridView1.GetRow(e.RowHandle);
            if (obj != null)
                ClientHelper.PlatformSqlMap.Update<BD_SBTZ_SX>(obj);
        }

        #region 
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<BD_SBTZ_SX> e)
        {
            bool ishas = false;
            if (enableList.Contains((e.Value as BD_SBTZ_SX).sxcol))
            {
                ishas = true;
               
            }
            IList<BD_SBTZ_SX> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<BD_SBTZ_SX>("where sxcol='" + (e.Value as BD_SBTZ_SX).sxcol + "'" +
                "and zldm='" + parentID + "'");
            if (list.Count > 0)
            {
                //Client.ClientHelper.PlatformSqlMap.Delete<BD_SBTZ_SX>(list[0]);
                //int id=(int)Client.ClientHelper.PlatformSqlMap.Create<BD_SBTZ_SX>(e.Value as BD_SBTZ_SX);

                ishas = true;
               
            }
            if (ishas)
            {
                Client.ClientHelper.PlatformSqlMap.Delete<BD_SBTZ_SX>(e.ValueOld);
                Client.ClientHelper.PlatformSqlMap.Create<BD_SBTZ_SX>(e.Value);
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
            BD_SBTZ_SX sx = e.Value as BD_SBTZ_SX;
            sx.zldm = parentID;
            int id = (int)Client.ClientHelper.PlatformSqlMap.Create<BD_SBTZ_SX>(e.Value as BD_SBTZ_SX);
            e.Value.id = id;
            gridViewOperation.BindingList.Add(e.Value);
            e.Cancel = true;
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
            gridView1.OptionsBehavior.Editable = btEdit.Enabled;
            canDel = btDelete.Enabled;
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
                    //btEdit.Enabled = false;
                    gridView1.Columns["sxname"].OptionsColumn.AllowEdit = false;
                    btDelete.Enabled = false;
                }
                else
                {
                    //btEdit.Enabled = true;
                    gridView1.Columns["sxname"].OptionsColumn.AllowEdit = true;
                    if(canDel)
                    btDelete.Enabled = true;
                }
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
            
            int m = 1;
            //sxcol(属性列)、sxname(属性名)、isvisible(是否显示)、isdel(是否可删除)、isedit(是否可修改)
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbox.Items.Add("是");
            cbox.Items.Add("否");
            gridView1.Columns["isvisible"].ColumnEdit = cbox;
            gridView1.Columns["isdel"].ColumnEdit = cbox;
            gridView1.Columns["isedit"].ColumnEdit = cbox;

            gridView1.Columns["zldm"].Visible = false;
            gridView1.Columns["c1"].Visible = false;
            gridView1.Columns["c2"].Visible = false;

            cbox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbox.Items.Add("文本");
            cbox.Items.Add("下拉列表");
            cbox.Items.Add("日期");
            cbox.Items.Add("整数");
            cbox.Items.Add("小数");
            gridView1.Columns["sxtype"].ColumnEdit = cbox;
            cbox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbox.Items.Add("查询");
            cbox.Items.Add("数组(分隔符'|')");
            gridView1.Columns["boxtype"].ColumnEdit = cbox;
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
            newobj = new BD_SBTZ_SX();
            //int result=0;
            //IList<string> list = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select Convert(nvarchar(50),max(id)) from BD_SBTZ_SX");
            //if (list.Count > 0)
            //{
            //    if (!int.TryParse(list[0], out result))
            //    {
            //        MsgBox.ShowWarningMessageBox("数据库格式错误！");
            //        return;
            //    }
            //}
            //newobj.id = result + 1;    
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
