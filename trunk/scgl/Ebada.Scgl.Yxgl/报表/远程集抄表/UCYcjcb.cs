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

namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCYcjcb : DevExpress.XtraEditors.XtraUserControl
    {
       
        public UCYcjcb()
        {
            InitializeComponent();
            initImageList();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
        }

        
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
       
        private void hideColumn(string colname)
        {
            //gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
          
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            dEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dEdit.Mask.EditMask = "yyyy-MM-dd HH:mm";
            

            dEdit.Mask.UseMaskAsDisplayFormat = true;
            //hideColumn("sbID");
            //hideColumn("OrgCode");
            ////hideColumn("gzrjID");
            //hideColumn("c1");
            //hideColumn("c2");
            //hideColumn("c3");
        }
      
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                IList<sdjls_sgbp> pjlist = new List<sdjls_sgbp>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    sdjls_sgbp _pj = gridView1.GetRow(i) as sdjls_sgbp;
                    pjlist.Add(_pj);
                }
                ExportSDsgbp.ExportExcel(pjlist);
            }
            else
            {
                return;
            }
        }
    }
}
