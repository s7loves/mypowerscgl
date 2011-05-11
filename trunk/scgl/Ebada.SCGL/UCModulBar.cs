using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Platform.Model;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Ebada.SCGL
{
    public partial class UCModulBar : UserControl
    {
        public UCModulBar()
        {
            InitializeComponent();
        }
        public frmMain2 PlatForm = null;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 
        }
        public void RefreshData(string filter)
        {
            treeList1.BeginInit();
            treeList1.Nodes.Clear();
            treeList1.DataSource = null;
            treeList1.DataSource = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mModule>(filter);
            treeList1.EndInit();
            //setImage();
        }
        public void SetImage()
        {
            setImages(treeList1.Nodes);
        }
        private void setImages(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    setImages(node.Nodes);
                    node.ImageIndex = 0;
                }
                else
                {
                    node.ImageIndex = 1;
                }
            }
        }
        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeListHitInfo hit = treeList1.CalcHitInfo(treeList1.PointToClient(Control.MousePosition));
            if (hit.Node != null && hit.Column != null)
            {
                mModule obj = treeList1.GetDataRecordByNode(hit.Node) as mModule;
                if (obj != null )
                {
                    PlatForm.OpenModule(obj);
                }
            }
        }
    }
}
