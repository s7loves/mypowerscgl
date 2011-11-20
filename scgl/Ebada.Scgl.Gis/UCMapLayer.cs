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
using Ebada.Scgl.Gis;
using GMap.NET.WindowsForms;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Collections;

namespace TLMapPlatform {
    /// <summary>
    /// 图层管理控件
    /// </summary>
    public partial class UCMapLayer : UserControl {

        public UCMapLayer() {

            InitializeComponent();
            //mRMap = map;
            //mRMap.Overlays.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Overlays_CollectionChanged);
            InitTree();
        }

        void Overlays_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            
        }
        DataTable mTable;
        const string visible="1";
        const string hide = "0";
        protected void InitTree() {
            mTable = new DataTable();
            mTable.Columns.Add("显示");
            mTable.Columns.Add("编辑");
            mTable.Columns.Add("层");
            mTable.Columns.Add("ID");
            mTable.Columns.Add("ParentID");
            mTable.Columns.Add("Layer");//打开层属性
            treeList1.DataSource = mTable;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            
            mTable.Rows.Add(hide, "0", "10kV线路", "10", "0");
            mTable.Rows.Add(hide, "0", "0.4kV台区", "0.4", "0");
            mTable.Rows.Add(hide, "0", "变电所", "bdz", "0");
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
        }

        void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e) {
            //DataRow row=treeList1.GetDataRecordByNode(e.Node) as DataRow;
            string id = e.Node["ID"].ToString();
            if (id.Contains("_")&& e.Node.Nodes.Count==1) {
                e.Node.Nodes.Clear();
                inittq(id.Substring(0, id.Length - 1));
            }
            e.CanExpand = true;
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            if (id.Contains("_") && !e.Node.HasChildren) {
                mTable.Rows.Add(hide, "0", "_", id+"^", id);
            }
        }
        private bool showToolbar;

        public bool ShowToolbar {
            get { return showToolbar; }
            set { showToolbar = value;
            controlNavigator1.Visible = showToolbar;
            }
        }
        private RMap mRMap;
        /// <summary>
        /// 图形控制
        /// </summary>
        public RMap MapControl {
            get { return mRMap; }
            set {
                if (value == mRMap) return;
                mRMap = value;
                treeList1.BeginInit();
                //mTable.Rows.Clear();
                if (value != null) {
                    //foreach (GMapOverlay layer in mRMap.Overlays) {
                    //    mTable.Rows.Add(layer.IsVisibile ? "1" : "0", "1", layer.Text, layer.Id, "0");
                    //}
                }
                treeList1.EndInit();
            }
        }
        public void InitLayer()
        {
            treeList1.BeginInit();
            //mTable.Rows.Clear();
            if (mRMap != null)
            {
                //foreach (GMapOverlay layer in mRMap.Overlays) {
                //    mTable.Rows.Add(layer.IsVisibile ? "1" : "0", "1", layer.ToString(), "1", layer.Id);
                //}
            }
            IList<mOrg> orgList = ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='1'");
            foreach (mOrg org in orgList) {
                mTable.Rows.Add(hide, "0", org.OrgName, org.OrgCode, "10");
                mTable.Rows.Add(hide, "0", org.OrgName, org.OrgCode+"_", "0.4");
            }
            IList<PS_xl> list= ClientHelper.PlatformSqlMap.GetList<PS_xl>("where len(linecode)=6 order by linecode");
            foreach (PS_xl xl in list) {
                mTable.Rows.Add(hide, "0", xl.LineName, xl.LineCode, xl.OrgCode);
            }
            
            treeList1.EndInit();
            //treeList1.ParentFieldName = "ParentID";

        }
        private void inittq(string gdscode) {
            treeList1.BeginInit();
            IList<PS_tq> tqlist = ClientHelper.PlatformSqlMap.GetList<PS_tq>(string.Format("where left(tqcode,3)={0}",gdscode));
            foreach (PS_tq tq in tqlist) {
                mTable.Rows.Add(hide, "0", tq.tqName, tq.tqCode, tq.tqCode.Substring(0, 3) + "_");
            }
            treeList1.EndInit();
        }
        private void controlNavigator1_Click(object sender, EventArgs e) {

        }
        public GMapOverlay AddLayer(string strName)
        {
            GMapOverlay layer = new GMapOverlay(mRMap, "0");
            mTable.Rows.Add("1", "1", strName, "1", layer.Id);
            return layer;
        }
     
        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
            if (e.Button.Tag.ToString() == "Add") {
                //Layer layer = Layer.CreateNew("新图层", VectorControl.SVGDocument);
                mTable.Rows.Add("1", "1", "新图层", "1", "","0"); e.Handled = true;
            } 
           if (e.Button.Tag.ToString() =="Del" ) {
               if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
               }
            }
            if (e.Button.Tag.ToString() == "Up")
            {
                
            }
            if (e.Button.Tag.ToString() == "Down")
            {
                
            }
            
        }
        private void setLayerAllowEdit(string lineCode, bool isEdit) {
            GMapOverlay lay = mRMap.FindOverlay(lineCode);
            if (lay != null && lay is IUpdateable) {
                (lay as IUpdateable).AllowEdit = isEdit;
            }
        }
        private void showLayer(string lineCode,bool visible) {

            GMapOverlay lay = mRMap.FindCreateLine(lineCode);
            
            lay.IsVisibile = visible;
            if (lineCode == "bdz")
                showbdz(lay);
        }

        private void showbdz(GMapOverlay lay) {
           IList<mOrg> list= Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(" where orgtype='2' order by  orgcode");
           
            foreach (mOrg obj in list) {
               if (obj != null) {
                   mRMap.FindMarker(obj);
               }
           }
        }
        private void treeList1_MouseClick(object sender, MouseEventArgs e) {
            //查找单元格，改变状态
            TreeListHitInfo hit = treeList1.CalcHitInfo(e.Location);
            if (hit.Node != null && hit.Column != null) {
                if (e.Button == MouseButtons.Left) {
                    string value = hit.Node[hit.Column.FieldName].ToString();
                    if (hit.Column.VisibleIndex > 0 && hit.Column.VisibleIndex < 3) {
                        hit.Node.SetValue(hit.Column.FieldName, (value == "1") ? 0 : 1);
                        string code = hit.Node["ID"].ToString();
                        if (hit.Column.FieldName == "显示") {

                            if (code.Length >= 6 || code == "bdz")
                                showLayer(code, hit.Node["显示"].ToString() == "1");

                        } else if (hit.Column.FieldName == "编辑") {
                            setLayerAllowEdit(code, hit.Node["编辑"].ToString() == "1");
                        }
                    }
                } else if (e.Button == MouseButtons.Right) {

                    string code = hit.Node["ID"].ToString();
                    showContextMenu(code,e.Location);
                    
                }
            } 
        }
        ContextMenu contextMenu;
        private void showContextMenu(string code,Point p) {
            if (contextMenu == null) {
                contextMenu= new ContextMenu();
                MenuItem item = new MenuItem();
                item.Text = "刷新";
                item.Click += new EventHandler(刷新_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem("定位");
                item.Click += new EventHandler(定位_Click);
                contextMenu.MenuItems.Add(item);
            }
            contextMenu.Tag = code;
            contextMenu.Show(treeList1, p);
        }

        void 定位_Click(object sender, EventArgs e) {
            mRMap.LocationOverlay(contextMenu.Tag as string);
        }

        void 刷新_Click(object sender, EventArgs e) {
            mRMap.RefreshOverlay(contextMenu.Tag as string);
        }
        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e) {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (e.Node == null) return;
            //mRMap.SVGDocument.CurrentLayer = mRMap.SVGDocument.GetLayerByID(e.Node["ID"].ToString());
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            if (e.Column.FieldName == "层") {//修改图层名称
                
            }
        }

        private void treeList1_NodeChanged(object sender, NodeChangedEventArgs e) {

        }
    }
}
