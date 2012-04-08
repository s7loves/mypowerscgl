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
using DevExpress.Utils;
using Ebada.Scgl.Sbgl;
using System.IO;
using GMap.NET;

namespace TLMapPlatform {
    /// <summary>
    /// 图层管理控件
    /// </summary>
    public partial class UCMapLayer : UserControl {

        public UCMapLayer() {
            createWaitDlg();
            InitializeComponent();
            InitTree();
            
        }
        static void createWaitDlg() {
            waitdlg = new WaitDialogForm("", "正在加载数据，请稍候。。。");
        }
        static void closeWaitDlg() {
            if (waitdlg != null) {
                waitdlg.Close();
                waitdlg = null;
            }
        }
        static void setWaitMsg(string str) {
            if (str == null) {
                closeWaitDlg();
            } else {
                if (waitdlg == null)
                    createWaitDlg();
                waitdlg.SetCaption(str);
            }
        }
        void Overlays_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            closeWaitDlg();
        }
        DataTable mTable;
        const string visible="1";
        const string hide = "0";
        static WaitDialogForm waitdlg;
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
            
            mTable.Rows.Add(hide, "0", "高压线路", "10", "0");
            mTable.Rows.Add(hide, "0", "低压台区", "0.4", "0");
            mTable.Rows.Add(hide, "0", "变电所", "bdz", "0");
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
            if (!"rabbit赵建明付岩张发冯富玲刘振远赵忠田".Contains(Ebada.Client.Platform.MainHelper.User.UserName)) {
                treeList1.Columns["编辑"].Visible = false;
                this.treeList1.Columns["Layer"].Visible = false;
            }
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
                treeList1.EndInit();
            }
        }
        public void InitLayer()
        {
            treeList1.BeginInit();

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
            setWaitMsg("");
            GMapOverlay lay = mRMap.FindCreateLine(lineCode);
            setWaitMsg(null);
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
                    if (code.Length == 3) {

                        ContextMenu cm = new ContextMenu();
                        MenuItem item = new MenuItem();
                        item.Text = "导出地理接线图";
                        item.Click += new EventHandler(导出地理接线图_Click);
                        item.Tag = code;
                        cm.MenuItems.Add(item);
                        cm.Show(treeList1, e.Location);
                        return;

                    }
                    showContextMenu(code,e.Location);
                    
                }
            } 
        }
        private RectLatLng union(RectLatLng r1, RectLatLng r2) {

            double l = Math.Min(r1.Left, r2.Left);
            double t = Math.Max(r1.Top, r2.Top);
            double r = Math.Max(r2.Right, r1.Right);
            double b = Math.Min(r1.Bottom, r2.Bottom);
            return new RectLatLng(t, l, r - l, t - b);
        }
        void 导出地理接线图_Click(object sender, EventArgs e) {
            string code=(sender as MenuItem).Tag.ToString();
            mOrg org = ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + code + "'");
            if (org != null) {
                //IList<PS_xl> list = ClientHelper.PlatformSqlMap.GetList<PS_xl>("where len(linecode)=6 and linecode like '" + code + "%'");

                //foreach (PS_xl xl in list) {
                //    showLayer(xl.LineCode, true);
                //}
                //RectLatLng rect = RectLatLng.Empty;
                GMap.NET.RectLatLng? r1 = MapControl.GetRectOfAllMarkers(null);
                GMap.NET.RectLatLng? r2 = MapControl.GetRectOfAllRoutes(null);
                GMap.NET.RectLatLng rect = RectLatLng.Empty;
                if (r1.HasValue) {
                    rect = r1.Value;
                    if (r2.HasValue) rect = union(rect, r2.Value);
                } else if (r2.HasValue) {
                    rect = r2.Value;
                }
                //foreach (PS_xl xl in list) {
                //    RectLatLng? rll =mRMap.GetRectOfAllRoutes(xl.LineCode);
                //    if (rll .HasValue) {
                //        if (rect.IsEmpty)
                //            rect = rll.Value;
                //        else
                //            rect = RectLatLng.Union(rect, rll.Value);
                //    }
                //}
                if (rect.IsEmpty) return;
                rect.Inflate(0.002d, 0.002d);
                GPoint p1 = mRMap.FromLatLngToLocal(rect.LocationTopLeft);
                GPoint p2 = mRMap.FromLatLngToLocal(rect.LocationRightBottom);
                RectangleF rf = new RectangleF(p1.X,p1.Y,p2.X-p1.X,p2.Y-p1.Y);
                //GMapOverlay lay ;
                GPoint p3 = p1;
                p3.Offset(mRMap.Width / 2, mRMap.Height / 2);

                mRMap.Position = mRMap.FromLocalToLatLng(p3.X, p3.Y);
                mRMap.Invalidate();
                Application.DoEvents();
                Rectangle rt = Rectangle.Round(rf);
                Bitmap bitmap=new Bitmap(rt.Width,rt.Height);

                //mRMap.VirtualSizeEnabled = true;
                Graphics g=Graphics.FromImage(bitmap);
                g.Clear(Color.White);
                //mRMap.ShowTileGridLines = true;
                mRMap.FillEmptyTiles = true;
                mRMap.Render(g, rt.Size);
                mRMap.FillEmptyTiles = false;
                Application.DoEvents();
                //mRMap.ShowTileGridLines = false;
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.RestoreDirectory = true;
                dlg.Filter = "*.bmp|*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    bitmap.Save(dlg.FileName);
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
                item = new MenuItem("高压线路条图汇总表");
                item.Click += new EventHandler(条图汇总表16_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem("高压线路条图");
                item.Click += new EventHandler(高压线路条图17_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem("台区属性");
                item.Click += new EventHandler(台区属性_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem("低压台区完好率及台区网络图");
                item.Click += new EventHandler(低压台区完好率及台区网络图_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem("导出台区网络图");
                item.Click += new EventHandler(台区网络图_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem("导出单线系统图");
                item.Click += new EventHandler(单线图_Click);
                contextMenu.MenuItems.Add(item);
            }
            bool flag = code.Length == 6;
            contextMenu.MenuItems[2].Enabled = flag;
            contextMenu.MenuItems[3].Enabled = flag;
            contextMenu.MenuItems[4].Enabled = !flag;
            contextMenu.MenuItems[5].Enabled = !flag;
            contextMenu.MenuItems[6].Enabled = flag;
            contextMenu.Tag = code;
            contextMenu.Show(treeList1, p);
        }
        void 台区网络图_Click(object sender, EventArgs e) {
            Bitmap bt =  GMapHelper.GetDytqMap(contextMenu.Tag.ToString());
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.RestoreDirectory = true;
            dlg.Filter = "*.bmp|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK) {
                bt.Save(dlg.FileName);
            }
        }
        void 单线图_Click(object sender, EventArgs e) {
            System.Drawing.Image bt = new DrawingDxt2().GetImage(contextMenu.Tag.ToString());
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.RestoreDirectory = true;
            dlg.Filter = "*.bmp|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK) {
                bt.Save(dlg.FileName);
            }
        }void 低压台区完好率及台区网络图_Click(object sender, EventArgs e) {
            show20dyt(contextMenu.Tag.ToString());
        }
        void 高压线路条图17_Click(object sender, EventArgs e) {
            ShowTT(contextMenu.Tag.ToString());
        }
        static void show20dyt(string tqcode) {
            PS_tq tq = Ebada.Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(string.Format("where tqcode='{0}'", tqcode));
            if (tq != null) {
                PJ_20 pj = ClientHelper.PlatformSqlMap.GetOneByKey<PJ_20>(tq.tqID);
                //DialogResult result = DialogResult.No;
                mOrg org = ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + tq.OrgCode + "'");
                if (pj == null) {
                    pj = new PJ_20() { OrgCode=tq.OrgCode, tqCode=tq.tqCode,tqName=tq.tqName, CreateMan="system"};
                    if (org != null) {
                        pj.ParentID = org.OrgID;
                        pj.OrgName = org.OrgName;
                    }
                }

                string flag = "edit";
                if (pj.ID != tq.tqID) {
                    pj.ID = tq.tqID;
                    flag = "add";
                }

                object instance = null;

                Ebada.Client.Platform.MainHelper.Execute("Ebada.Scgl.Yxgl.dll", "Ebada.Scgl.Yxgl.frm20Template", "Show", new object[] { pj, flag }, null, ref instance);
                Form frm = instance as Form;
                frm.ShowDialog();
            }
        }
        internal static void ShowTT(string linecode) {
            PS_xl xl = Ebada.Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(string.Format("where linecode='{0}'", linecode));
            if (xl != null) {
                PJ_17 pj17 = ClientHelper.PlatformSqlMap.GetOneByKey<PJ_17>(xl.LineID);
                DialogResult result = DialogResult.No;
                if (pj17 == null) {
                    pj17 = new PJ_17() { LineCode = xl.LineCode, LineName = xl.LineName, OrgCode = xl.OrgCode, CreateMan = "system" };
                } else {
                    result = MsgBox.ShowAskMessageBox(xl.LineName + "已经存在，是否要重新生成。\n生成条图需要几分钟，建议没有修改数据前不要重新生成。\n[确认]重新生成，[取消]打开已生成数据。");
                }
                if (pj17.ID != xl.LineID || result == DialogResult.OK) {
                    setWaitMsg("正在生成“" + xl.LineName + "”条图数据");
                    waitdlg.TopMost = false;
                    Ebada.Client.Platform.MainHelper.Execute("Ebada.Scgl.Yxgl.dll", "Ebada.Scgl.Yxgl.UCPJ_17", "ExportToExcel", new object[] { "高压配电线路条图", "", pj17 });

                    setWaitMsg(null);
                }
                if (pj17.ID == xl.LineID) {
                    if (result == DialogResult.OK)
                        ClientHelper.PlatformSqlMap.Update<PJ_17>(pj17);
                } else {
                    pj17.ID = xl.LineID;
                    ClientHelper.PlatformSqlMap.Create<PJ_17>(pj17);
                }
                object instance = null;

                Ebada.Client.Platform.MainHelper.Execute("Ebada.Scgl.Yxgl.dll", "Ebada.Scgl.Yxgl.frm17Template", "Show", new object[] { pj17 }, null, ref instance);
                Form frm = instance as Form;
                if (frm.ShowDialog() == DialogResult.OK) {
                    object value = instance.GetType().GetProperty("pjobject").GetValue(instance, null);
                    if (value is PJ_17) {
                        ClientHelper.PlatformSqlMap.Update<PJ_17>(value);
                    }
                }

            }
        }
        void 条图汇总表16_Click(object sender, EventArgs e) {
            PS_xl xl = Ebada.Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(string.Format("where linecode='{0}'",contextMenu.Tag));

            if (xl != null) {
                setWaitMsg("汇总“"+xl.LineName+"”数据");
                waitdlg.TopMost = false;
                Ebada.Client.Platform.MainHelper.Execute("Ebada.Scgl.Yxgl.dll", "Ebada.Scgl.Yxgl.Export16", "ExportExcel", new object[] { xl });
                setWaitMsg(null);
            }
        }
        void 台区属性_Click(object sender, EventArgs e) {
            PS_tq tq = Ebada.Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(string.Format("where tqcode='{0}'", contextMenu.Tag));

            if (tq == null) return;
            frmtqEdit dlg = new frmtqEdit();
            dlg.RowData = tq;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Application.DoEvents();
                Ebada.Client.ClientHelper.PlatformSqlMap.Update<PS_tq>(dlg.RowData);
            }
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
