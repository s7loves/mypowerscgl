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
    public partial class UCBB_Aqxpj : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<xxgx_aqxpj> gridViewOperation;
        private string basesql = "where 1>0 ";
        public event SendDataEventHandler<xxgx_aqxpj> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        public UCBB_Aqxpj()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<xxgx_aqxpj>(gridControl1, gridView1, barManager1, new frmAqxpj());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<xxgx_aqxpj>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }



        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<xxgx_aqxpj> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;

            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

            RepositoryItem reItem;
            IList<DicType> dictypeList = new List<DicType>();
            int year = DateTime.Now.Year;
            for (int i = year; i > year-50; i--)
            {
                dictypeList.Add(new DicType(i.ToString(), i.ToString()));
            }
            reItem = new LookUpDicType(dictypeList);
            barsj.Edit = reItem;
            

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];
            if (org == null)
                return;
            string sql = " and orgcode='" + org.OrgCode + "'";
            if (!string.IsNullOrEmpty(barsj.EditValue as string))
            {
                sql += "and year='"+barsj.EditValue.ToString()+"'";
            }
            sql = basesql + sql;
            RefreshData(sql);
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as xxgx_aqxpj);
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
            if (MainHelper.UserOrg != null)
            {
                string strSQL = "where OrgCode='" + MainHelper.UserOrg.OrgCode + "'";
                RefreshData(strSQL);
            }
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            //DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            //dEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //dEdit.Mask.EditMask = "yyyy-MM-dd";
            //dEdit.Mask.UseMaskAsDisplayFormat = true;
            //hideColumn("sbID");
            gridView1.Columns["orgcode"].ColumnEdit = DicTypeHelper.OrgDic;
            gridView1.Columns["orgcode"].Caption = "单位";
            gridView1.Columns["year"].Caption = "时间";
            gridView1.Columns["filedata"].Caption = "文件数据";
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
        public GridViewOperation<xxgx_aqxpj> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(xxgx_aqxpj newobj)
        {
           
            if (!string.IsNullOrEmpty(btGdsList.EditValue as string))
                newobj.orgcode = btGdsList.EditValue.ToString();
            if (!string.IsNullOrEmpty(barsj.EditValue as string))
            {
                newobj.scsj = barsj.EditValue.ToString();
            }
            else
            {
                newobj.scsj = DateTime.Now.Year.ToString();
            }
            newobj.scsj = DateTime.Now.ToString();
            newobj.scry = MainHelper.User.UserName;
        }
       

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                IList<xxgx_aqxpj> pjlist = new List<xxgx_aqxpj>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    xxgx_aqxpj _pj = gridView1.GetRow(i) as xxgx_aqxpj;
                    pjlist.Add(_pj);


                }
                
            }
            else
            {
                return;
            }
        }

        private void barsj_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(barsj.EditValue as string))
                return;
            string sql = " and year='" + barsj.EditValue.ToString() + "'";
            if (!string.IsNullOrEmpty(btGdsList.EditValue as string))
            {
                sql += "and orgcode='" + btGdsList.EditValue.ToString() + "'";
            }
            sql = basesql + sql;
            RefreshData(sql);
        }

        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btGdsList.EditValue = null;
            barsj.EditValue = null;
            RefreshData(basesql);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            xxgx_aqxpj aqxpj = gridView1.GetFocusedRow() as xxgx_aqxpj;
            frmAqTemplate frm = new frmAqTemplate();
            frm.pjobject = aqxpj;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Update<xxgx_aqxpj>(frm.pjobject);
                //MessageBox.Show("保存成功");
            }
        }

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xxgx_aqxpj aqxpj = new xxgx_aqxpj();
            if (!string.IsNullOrEmpty(btGdsList.EditValue as string))
                aqxpj.orgcode = btGdsList.EditValue.ToString();
            if (!string.IsNullOrEmpty(barsj.EditValue as string))
            {
                aqxpj.scsj = barsj.EditValue.ToString();
            }
            else
            {
                aqxpj.scsj = DateTime.Now.Year.ToString();
            }
            aqxpj.scsj = DateTime.Now.ToString();
            aqxpj.scry = MainHelper.User.UserName;
            frmAqxpj frm = new frmAqxpj();
            frm.RowData = aqxpj;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Client.ClientHelper.PlatformSqlMap.Create<xxgx_aqxpj>(frm.RowData as xxgx_aqxpj);
                RefreshData(basesql);
            }
        }

        private void btExport0_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
                return;
            xxgx_aqxpj obj = gridView1.GetFocusedRow() as xxgx_aqxpj;
            string fname = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
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
    }
}
