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
using DevExpress.XtraEditors.Repository;

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCddyb : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<xxgx_ddyb> gridViewOperation;
        private string basesql = "where 1>0 ";
        public event SendDataEventHandler<xxgx_ddyb> FocusedRowChanged;
        
        public UCddyb()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<xxgx_ddyb>(gridControl1, gridView1, barManager1, new frmddyb());
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;

           
            int year = DateTime.Now.Year;
            for (int i = 2005; i<2050; i++)
            {
                repositoryItemComboBox2.Items.Add(i);
            }
            barYear.EditValue = year;
            for (int i = 1; i <= 12; i++) {
                repositoryItemComboBox3.Items.Add(i.ToString("00"));
            }
            barMonth.EditValue = DateTime.Today.Month.ToString("00");
        }


        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as xxgx_ddyb);
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            
                string strSQL = "where year='" + DateTime.Today.Year + "'";
                RefreshData(strSQL);
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {
            RepositoryItemDateEdit dEdit = new RepositoryItemDateEdit();
            dEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dEdit.Mask.EditMask = "yyyy-MM-dd";
            dEdit.Mask.UseMaskAsDisplayFormat = true;
            //需要隐藏列时在这写代码          
            gridView1.Columns["orgcode"].ColumnEdit = DicTypeHelper.OrgDic;
            gridView1.Columns["orgcode"].Caption = "单位";
            gridView1.Columns["year"].Caption = "年月";
            gridView1.Columns["scsj"].ColumnEdit = dEdit;
            //gridView1.Columns["filedata"].Caption = "文件数据";
            hideColumn("orgcode");
            hideColumn("filedata");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<xxgx_ddyb> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        
        private void barsj_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(barsj.EditValue as string))
                return;
            string sql = " and year='" + barsj.EditValue.ToString() + "'";
            
            sql = basesql + sql;
            RefreshData(sql);
        }

        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barsj.EditValue = null;
            RefreshData(basesql);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            xxgx_ddyb aqxpj = gridView1.GetFocusedRow() as xxgx_ddyb;
            frmddybTemplate frm = new frmddybTemplate();
            frm.pjobject = aqxpj;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<xxgx_ddyb>(frm.pjobject);
                //MessageBox.Show("保存成功");
            }
        }

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (getSj() == null) return;
            xxgx_ddyb aqxpj = new xxgx_ddyb();

            aqxpj.year = getSj();
            aqxpj.scsj = DateTime.Now.ToString();
            aqxpj.scry = MainHelper.User.UserName;
            frmddyb frm = new frmddyb();
            frm.RowData = aqxpj;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<xxgx_ddyb>(frm.RowData as xxgx_ddyb);
                RefreshData(basesql);
            }
        }

        private void btExport0_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            xxgx_ddyb obj = gridView1.GetFocusedRow() as xxgx_ddyb;
            string fname = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
            saveFileDialog1.FileName = obj.filename;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog1.FileName;
                try
                {
                    DSOFramerControl ds1 = new DSOFramerControl();
                    ds1.FileDataGzip = obj.filedata;
                    ds1.FileSave(fname, true);
                    ds1.FileClose();
                    if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                        return;

                    System.Diagnostics.Process.Start(fname);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MsgBox.ShowWarningMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                    return;
                }
            }
        }
        string getSj() {
            string year = (barYear.EditValue??"").ToString();
            string month = (barMonth.EditValue??"").ToString();
            if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month)) return null;
            return year + month;
        }
        private void barYear_EditValueChanged(object sender, EventArgs e) {
            string sql = "where year='" + getSj() + "'";
            if(sql!=null)
            RefreshData(sql);

        }

        private void barMonth_EditValueChanged(object sender, EventArgs e) {
            string sql = "where year='" + getSj() + "'";
            if (sql != null)
                RefreshData(sql);
        }
    }
}
