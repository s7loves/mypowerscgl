using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using System.Collections;

namespace Ebada.Scgl.Gis
{
    public partial class frmBianDianZhanJieXianTu : DevExpress.XtraEditors.XtraForm
    {
        public frmBianDianZhanJieXianTu()
        {
            InitializeComponent();
        }

        #region 加载事件,查找变电所
        private void frmBianDianZhanJieXianTu_Load(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(" where orgtype='2'");
            treeList1.DataSource = list;
        }
        #endregion

        #region 变电站改变查找该变电站的线路图
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                mOrg org = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as mOrg;
                ucXianLuTu1.Caption = org.OrgName + "  -  接线图";
                ucXianLuTu1.OrgCode = org.OrgCode;
            }
        }
        #endregion
    }
}