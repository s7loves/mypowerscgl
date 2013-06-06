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
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 监控设备
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCLayerSbxj : UserControl, IUCLayer {

        WaitDialogForm waitdlg;
        DrawingDxt dxt;
        PS_xl _xl;
        Queue<gps_position> queuePos;
        PlaybackSbxjHelper playback;
        public UCLayerSbxj() {

            InitializeComponent();
            InitTree();
            groupControl1.Hide();
            queuePos = new Queue<gps_position>();
            dateEdit1.EditValue = DateTime.Now.AddDays(-1);
            dateEdit2.EditValue = DateTime.Now;
            btEnd.Enabled = false;
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
        const string visible = "1";
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
            //treeList1.FocusedNodeChanged+=new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.Columns["层"].Caption = "巡视计划";
            treeList1.Columns["Layer"].Visible = false;

            treeList1.Columns["编辑"].Visible = false;
            treeList1.Columns["显示"].Visible = false;
        }



        private void initgds(string pid) {
            IList<mOrg> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='1'");
            foreach (mOrg gds in list) {
                mTable.Rows.Add(hide, "0", gds.OrgName, gds.OrgCode, pid, "0");
            }
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["type"].ToString();
            if (!e.Node.HasChildren && type == "0") {
                mTable.Rows.Add(hide, "0", "_", id + "^", id);
            }
        }
        private bool showToolbar;

        public bool ShowToolbar {
            get { return showToolbar; }
            set {
                showToolbar = value;
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
                playback = new PlaybackSbxjHelper(mRMap, this.Container);
                playback.OnCompleted += new EventHandler(playback_OnCompleted);
            }
        }

        void playback_OnCompleted(object sender, EventArgs e) {
            this.btEnd.PerformClick();
        }
        public void InitLayer(sd_xsjh xsjh) {
            treeList1.BeginInit();
            initdevice(xsjh);
            treeList1.EndInit();
        }
        private void initdevice(sd_xsjh xsjh) {
            mTable.Rows.Clear();
            mTable.Rows.Add(hide, "0", xsjh.LineName + xsjh.xsnr, xsjh.ID, "0", "1");
            sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_xl>(xsjh.LineID);
            if (xl != null) {
                showLayer(xl.LineCode, true);
                mRMap.LocationOverlay(xl.LineCode);
            }
            dateEdit1.DateTime = xsjh.xskssj;
            dateEdit2.DateTime = xsjh.xswcsj;
        }

        private void controlNavigator1_Click(object sender, EventArgs e) {

        }


        private void setLayerAllowEdit(string lineCode, bool isEdit) {
            GMapOverlay lay = mRMap.FindOverlay(lineCode);
            if (lay != null && lay is IUpdateable) {
                (lay as IUpdateable).AllowEdit = isEdit;
            }
        }
        private void showLayer(string lineCode, bool visible) {

            GMapOverlay lay = mRMap.FindCreateLine(lineCode);

            lay.IsVisibile = visible;
        }


        private void treeList1_MouseClick(object sender, MouseEventArgs e) {
            //查找单元格，改变状态
            TreeListHitInfo hit = treeList1.CalcHitInfo(e.Location);
            if (hit.Node != null && hit.Column != null) {
                if (e.Button == MouseButtons.Left) {
                    string value = hit.Node["ID"].ToString();
                    locationMarker(value);

                } else if (e.Button == MouseButtons.Right) {
                    if (hit.Node["type"].ToString() == "1") {
                        //string code = hit.Node["ID"].ToString();
                        //showContextMenu(code, e.Location);
                    }

                }
            }
        }
        private void locationMarker(string id) {
            //frmMapCar form= this.FindForm() as frmMapCar;
            //if(form!=null){
            //    form.LocationMarker(id);
            //}

        }
        ContextMenu contextMenu;
        private void showContextMenu(string code, Point p) {
            if (contextMenu == null) {
                contextMenu = new ContextMenu();
                MenuItem item = new MenuItem();
                //item.Text = "刷新";
                //item.Click += new EventHandler(刷新_Click);
                //contextMenu.MenuItems.Add(item);
                contextMenu.MenuItems.Add(item);
            }
            contextMenu.Tag = code;
            contextMenu.Show(treeList1, p);
        }




        private string getxlname(string xlcode) {
            string name = xlcode;
            DataRow[] rows = mTable.Select("id='" + xlcode + "'");
            if (rows.Length > 0)
                name = rows[0]["层"].ToString();
            return name;
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
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            if (e.Column.FieldName == "层") {//修改图层名称

            }
        }

        private void treeList1_NodeChanged(object sender, NodeChangedEventArgs e) {

        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            if (btStart.Text == "开始") {

                if (playback.PlayState != PlaybackSbxjHelper.PlayBackType.Pause) {
                    if (treeList1.FocusedNode == null) return;
                    playback.SetDevice(treeList1.FocusedNode["ID"].ToString());

                    playback.StartTime = dateEdit1.DateTime;
                    playback.EndTime = dateEdit2.DateTime;
                }
                try {
                    playback.Speed = int.Parse(comboBoxEdit1.EditValue.ToString());
                } catch { }
                btStart.Text = "暂停";
                btEnd.Enabled = true;
                playback.Start();
            } else {
                btStart.Text = "开始";
                btEnd.Enabled = false;
                playback.Pause();
            }
        }

        private void btEnd_Click(object sender, EventArgs e) {
            btEnd.Enabled = false;
            btStart.Text = "开始";
            btStart.Enabled = true;
            playback.End();
        }
        #region 图层信息


        #endregion

        #region IUCLayer 成员

        public GMapOverlay AddLayer(string strName) {
            throw new NotImplementedException();
        }

        public void InitLayer() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
