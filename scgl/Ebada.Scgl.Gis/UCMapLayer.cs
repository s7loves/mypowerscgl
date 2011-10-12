using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using TLVector.Core.Figure;
using DevExpress.XtraTreeList;
using System.Xml;
using TLVector.Core.Interface.Figure;

namespace TLMapPlatform {
    /// <summary>
    /// 图层管理控件
    /// </summary>
    public partial class UCMapLayer : UserControl {

        public UCMapLayer() {
            InitializeComponent();
            InitTree();
        }
        DataTable mTable;
        protected void InitTree() {
            //TreeListColumn tlc = treeList1.Columns.Add();
            mTable = new DataTable();
            mTable.Columns.Add("显示");
            mTable.Columns.Add("编辑");
            mTable.Columns.Add("层");
            mTable.Columns.Add("layer");
            mTable.Columns.Add("ID");

            treeList1.DataSource = mTable;
        }
        private TLVector.TLVectorControl mVectorControl;
        /// <summary>
        /// 图形控制
        /// </summary>
        public TLVector.TLVectorControl VectorControl {
            get { return mVectorControl; }
            set {
                if (value == mVectorControl) return;
                mVectorControl = value;
                treeList1.BeginInit();
                mTable.Rows.Clear();
                if (value != null) {
                    foreach (Layer layer in mVectorControl.SVGDocument.Layers) {
                        mTable.Rows.Add(layer.Visible?"1":"0", "1", layer.Label, "1", layer.ID);
                    }
                }
                treeList1.EndInit();
            }
        }
        public void InitLayer()
        {
            treeList1.BeginInit();
            mTable.Rows.Clear();
            if (mVectorControl != null)
            {
                foreach (Layer layer in mVectorControl.SVGDocument.Layers)
                {
                    mTable.Rows.Add(layer.Visible ? "1" : "0", "1", layer.Label, "1", layer.ID);
                }
            }
            treeList1.EndInit();
        }
        private void controlNavigator1_Click(object sender, EventArgs e) {

        }
        public Layer AddLayer(string strName)
        {
            Layer layer = Layer.CreateNew(strName, VectorControl.SVGDocument);
            mTable.Rows.Add("1", "1", strName, "1", layer.ID);
            return layer;
        }
     
        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
            if (e.Button.Tag.ToString() == "Add") {
                Layer layer = Layer.CreateNew("新图层", VectorControl.SVGDocument);
                mTable.Rows.Add("1", "1", "新图层", "1", layer.ID); e.Handled = true;
            } 
           if (e.Button.Tag.ToString() =="Del" ) {
               if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
               }
            }
            if (e.Button.Tag.ToString() == "Up")
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList1.FocusedNode.Clone() as DevExpress.XtraTreeList.Nodes.TreeListNode;
                Layer layer = mVectorControl.SVGDocument.GetLayerByID(treeList1.FocusedNode["ID"].ToString());
                layer.GoUp();
                InitLayer();
                treeList1.FocusedNode = treeList1.FindNodeByID(node.Id-1);
            }
            if (e.Button.Tag.ToString() == "Down")
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList1.FocusedNode.Clone() as DevExpress.XtraTreeList.Nodes.TreeListNode;
                Layer layer = mVectorControl.SVGDocument.GetLayerByID(treeList1.FocusedNode["ID"].ToString());
                layer.GoDown();
                InitLayer();
                treeList1.FocusedNode = treeList1.FindNodeByID(node.Id+1);
            }
            
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e) {
            //查找单元格，改变状态
            TreeListHitInfo hit = treeList1.CalcHitInfo(e.Location);
            if (hit.Node != null && hit.Column != null) {
                string value = hit.Node[hit.Column.FieldName].ToString();
                if (hit.Column.VisibleIndex < 2) {
                    hit.Node.SetValue(hit.Column.FieldName, (value == "1") ? 0 : 1);
                    if (hit.Column.FieldName == "显示") {
                        Layer layer = mVectorControl.SVGDocument.GetLayerByID(hit.Node["ID"].ToString());
                        layer.Visible = hit.Node["显示"].ToString() == "1";
                    } else if (hit.Column.FieldName == "编辑") {
                        Layer layer = mVectorControl.SVGDocument.GetLayerByID(hit.Node["ID"].ToString());
                        XmlNodeList list = this.mVectorControl.SVGDocument.SelectNodes("//*[@layer='" + layer.ID + "']");
                        foreach (XmlNode elNode in list)
                        {
                            (elNode as IGraph).IsLock =hit.Node["编辑"].ToString() == "0"?true:false; 
                        }
                    }
                }
            } 
        }

        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e) {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (e.Node == null) return;
            mVectorControl.SVGDocument.CurrentLayer = mVectorControl.SVGDocument.GetLayerByID(e.Node["ID"].ToString());
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            if (e.Column.FieldName == "层") {//修改图层名称
                Layer layer = mVectorControl.SVGDocument.GetLayerByID(e.Node["ID"].ToString());
                if (layer != null)
                    layer.Label = e.Value.ToString();
            }
        }

        private void treeList1_NodeChanged(object sender, NodeChangedEventArgs e) {

        }
    }
}
