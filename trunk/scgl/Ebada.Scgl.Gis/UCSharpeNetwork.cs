using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using System.Xml;
using Ebada.Scgl.Gis;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Collections;
using DevExpress.Utils;
using Ebada.Scgl.Gis.Markers;

namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 配电图形-网络图
    /// </summary>
    public partial class UCSharpeNetwork : UserControl, IUCLayer {

        WaitDialogForm waitdlg;
        DrawingNetwork dxt;
        mOrg _gds;
        public UCSharpeNetwork() {
            
            InitializeComponent();
            InitTree();
            createCheckGroup();
        }
        public UCSharpeNetwork(string gdscode) {

            InitializeComponent();
            if (gdscode == "all")
                _gds = new mOrg() { OrgCode = gdscode, OrgName = "全局配电线路网络图" };
            else
                _gds = ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + gdscode + "'");
            InitTree();
            createCheckGroup();
        }
        private void createCheckGroup() {
            checkxlmc.CheckedChanged += checkxlmc_CheckedChanged;
            checkgth.CheckedChanged += checkgth_CheckedChanged;
            checkbyqrl.CheckedChanged += checkbyqrl_CheckedChanged;
            checkkg.CheckedChanged += checkkg_CheckedChanged;
            checkbyq.CheckedChanged += checkbyq_CheckedChanged;
            checkgt.CheckedChanged += checkgt_CheckedChanged;
        }

        void Overlays_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            
        }
        void createWaitDlg() {
            waitdlg = new WaitDialogForm("", "正在加载数据，请稍候。。。");
        }
        void closeWaitDlg() {
            if (waitdlg != null) {
                waitdlg.Close();
                waitdlg = null;
            }
        }
        void setWaitMsg(string str) {
            if (str == null) {
                closeWaitDlg();
            } else {
                if (waitdlg == null)
                    createWaitDlg();
                waitdlg.SetCaption(str);
            }
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
            mTable.Columns.Add("type");//打开层属性
            treeList1.DataSource = mTable;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";

            if (_gds == null) {
                mTable.Rows.Add(hide, "0", "全局配电线路网络图", "all", "0", "1");
                mTable.Rows.Add(hide, "0", "供电所网络图", "gds", "0", "0");
            } else {
                mTable.Rows.Add(visible, "0", _gds.OrgName, _gds.OrgCode, "0", "1");
            }
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
            treeList1.Columns["层"].Caption = "图纸名称";
            treeList1.Columns["Layer"].Visible = false;
            if (!"rabbit赵建明付岩张发冯富玲刘振远赵忠田".Contains(Ebada.Client.Platform.MainHelper.User.UserName))
            {
                
            }
            treeList1.Columns["编辑"].Visible = false;
            treeList1.Columns["显示"].Visible = false;
        }

        void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e) {
            //DataRow row=treeList1.GetDataRecordByNode(e.Node) as DataRow;
            string id = e.Node["ID"].ToString();
            if (id.Contains("gds")&& e.Node.Nodes.Count==1) {
                e.Node.Nodes.Clear();
                initgds(id);
            }
            e.CanExpand = true;
        }

        private void initgds(string pid) {
            IList<mOrg> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='1'");
            foreach (mOrg gds in list) {
                mTable.Rows.Add(hide, "0", gds.OrgName, gds.OrgCode, pid, "1");
            }
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["type"].ToString();
            if (!e.Node.HasChildren && type=="0") {
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
                dxt = new DrawingNetwork(mRMap);

            }
        }
        public void InitLayer()
        {

            if (_gds != null)
                buildLineMapGds(_gds.OrgCode);

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
                    if (hit.Node["type"].ToString() == "1") {
                        string code = hit.Node["ID"].ToString();
                        showContextMenu(code, e.Location);
                    }
                    
                }
            } 
        }
        ContextMenu contextMenu;
        private void showContextMenu(string code,Point p) {
            if (contextMenu == null) {
                contextMenu= new ContextMenu();
                MenuItem item = new MenuItem();
                //item.Text = "刷新";
                //item.Click += new EventHandler(刷新_Click);
                //contextMenu.MenuItems.Add(item);
                item = new MenuItem("打开");
                item.Click += new EventHandler(打开_Click);
                contextMenu.MenuItems.Add(item);
            }
            contextMenu.Tag = code;
            contextMenu.Show(treeList1, p);
        }
        void 条图汇总表17_Click(object sender, EventArgs e) {
            PS_xl xl = Ebada.Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(string.Format("where linecode='{0}'",contextMenu.Tag));

            if (xl != null)
                Ebada.Client.Platform.MainHelper.Execute("Ebada.Scgl.Yxgl.dll", "Ebada.Scgl.Yxgl.Export16", "ExportExcel", new object[] { xl });
        }

        #region 网络图
        void 打开_Click(object sender, EventArgs e) {
            //MethodInvoker m = delegate() {
                
            //};
            //Invoke( m);
            clearMapData();
            if (contextMenu.Tag.ToString() == "all") {
                buildLineMapAll();
            } else {
                buildLineMapGds(contextMenu.Tag.ToString());
            }
        }

        private void clearMapData() {
            //MapControl.
            dxt.Bounds = RectLatLng.Empty;
            foreach (GMapOverlay lay in MapControl.Overlays) {
                if (lay.Id == "bdz") lay.Markers.Clear();
                else
                    lay.IsVisibile = false;
            }
        }
        private Dictionary<string, mOrg> bdsList;

        public Dictionary<string, mOrg> BdsList {
            get {
                if (bdsList == null) {
                    bdsList = new Dictionary<string, mOrg>();
                    IList<mOrg> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='2'");
                    foreach (mOrg bds in list) {
                        bdsList.Add(bds.OrgCode, bds);
                    }
                }
                return bdsList; }
        }
        public void buildLineMapGds(string gdscode) {
            if (gdscode == "all") {
                buildLineMapAll();
                return;
            }
            setWaitMsg("");

            IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where len(linecode)=6 and orgcode='" + gdscode + "'");
            List<string> lines = new List<string>();
            foreach (PS_xl xl in list) {
                setWaitMsg("生成“" + xl.LineName + "”信息");
                showLayer(xl.LineCode, true);
                if (lines.Contains(xl.OrgCode2)) continue;
                lines.Add(xl.OrgCode2);
                if (BdsList.ContainsKey(xl.OrgCode2))
                    MapControl.FindMarker(bdsList[xl.OrgCode2]).IsVisible=true;
            }
            buildTitleInfo(gdscode);
            setWaitMsg(null);
        }
        private RectLatLng union(RectLatLng r1,RectLatLng r2) {
            
            double l = Math.Min(r1.Left, r2.Left);
            double t = Math.Max(r1.Top, r2.Top);
            double r = Math.Max(r2.Right, r1.Right);
            double b = Math.Min(r1.Bottom, r2.Bottom);
            return new RectLatLng(t, l, r - l, t - b);
        }
        private void buildTitleInfo(string gdscode) {
            GMap.NET.RectLatLng? r1= MapControl.GetRectOfAllMarkers(null);
            GMap.NET.RectLatLng? r2=MapControl.GetRectOfAllRoutes(null);
            GMap.NET.RectLatLng rect = RectLatLng.Empty;
            if (r1.HasValue) rect = r1.Value;
            if (r2.HasValue) rect = union(rect, r2.Value);
            if (!rect.IsEmpty) {
                
                rect.Inflate(.002d, .001d);
                string name = "绥化农电局";
                if (gdscode != null) {
                    mOrg org = Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + gdscode + "'");

                    if (org != null) {
                        name = org.OrgName;
                    }
                } 
                //GMapMarkerText text = new GMapMarkerText(new PointLatLng(rect.Top - .0025, rect.Left + rect.WidthLng / 2));
                //text.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                name = name + "高压配电线路网络图 - " + DateTime.Now.Year + "年";

                dxt.Title = name;
                dxt.Bounds = rect;
                MapControl.SetZoomToFitRect(rect);
            }
            
        }


        private void buildLineMapAll() {
            setWaitMsg("");
            IList<PS_xl> list=Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where len(linecode)=6");
            List<string> lines = new List<string>();
            foreach (PS_xl xl in list) {
                setWaitMsg("生成“" + xl.LineName + "”信息");
                showLayer(xl.LineCode, true);
                if (lines.Contains(xl.OrgCode2)) continue;
                lines.Add(xl.OrgCode2);
                if (BdsList.ContainsKey(xl.OrgCode2))
                    MapControl.FindMarker(bdsList[xl.OrgCode2]).IsVisible = true;
            }
            buildTitleInfo(null);
            setWaitMsg(null);
        }
        #endregion

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
        #region 图层信息

        private void checkgt_CheckedChanged(object sender, EventArgs e) {
            mRMap.Showgt = checkgt.Checked;
            checkgth.Enabled = checkgt.Checked;
        }


        private void checkgth_CheckedChanged(object sender, EventArgs e) {
            mRMap.Showgth = checkgth.Checked;
        }
        private void checkbyq_CheckedChanged(object sender, EventArgs e) {
            mRMap.Showbyq = checkbyq.Checked;
            checkbyqrl.Enabled = checkbyq.Checked;
        }
        private void checkbyqrl_CheckedChanged(object sender, EventArgs e) {
            mRMap.Showbyqrl = checkbyqrl.Checked;
        }
        private void checkkg_CheckedChanged(object sender, EventArgs e) {
            mRMap.Showkg = checkkg.Checked;
        }
        private void checkxlmc_CheckedChanged(object sender, EventArgs e) {
            mRMap.Showxlmc = checkxlmc.Checked;
        }
        #endregion
    }
}
