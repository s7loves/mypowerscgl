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
    /// 配电图形-单线图
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCLayerCar : UserControl, IUCLayer {

        WaitDialogForm waitdlg;
        DrawingDxt dxt;
        PS_xl _xl;
        Queue<gps_position> queuePos;
        PlaybackHelper playback;
        public UCLayerCar() {
            
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
            //treeList1.FocusedNodeChanged+=new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.Columns["层"].Caption = "设备名称";
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
            if (!e.Node.HasChildren && type=="0") {
                mTable.Rows.Add(hide, "0", "_", id+"^", id);
            }
        }
        private bool showToolbar;

        public bool ShowToolbar {
            get { return showToolbar; }
            set { showToolbar = value;
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
                playback = new PlaybackHelper(mRMap,this.Container);
            }
        }
        public void InitLayer()
        {
            treeList1.BeginInit();
            initdevice();
            treeList1.EndInit();
        }
        private void initdevice() {
            IList<v_position_now> list = Client.ClientHelper.PlatformSqlMap.GetList<v_position_now>(null);
            
            foreach (v_position_now pos in list) {
                mTable.Rows.Add(hide, "0", pos.device_name, pos.device_id, "0", "1");
            }
        }
        private void initxl(string pid) {
            if (pid == "all") {
                IList<PS_xl> list = ClientHelper.PlatformSqlMap.GetList<PS_xl>("where len(linecode)=6 order by linecode");
                foreach (PS_xl xl in list) {
                    mTable.Rows.Add(hide, "0", xl.LineName, xl.LineCode, pid,"1");
                }
            }
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
            frmMapCar form= this.FindForm() as frmMapCar;
            if(form!=null){
                form.LocationMarker(id);
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
                contextMenu.MenuItems.Add(item);
            }
            contextMenu.Tag = code;
            contextMenu.Show(treeList1, p);
        }
        

       

        private string getxlname(string xlcode) {
            string name = xlcode;
           DataRow[] rows= mTable.Select("id='" + xlcode + "'");
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
                
                if (playback.PlayState != PlaybackHelper.PlayBackType.Pause) {
                    if (treeList1.FocusedNode == null) return;
                    playback.SetDevice(int.Parse(treeList1.FocusedNode["ID"].ToString()));

                    playback.StartTime = dateEdit1.DateTime;
                    playback.EndTime = dateEdit2.DateTime;
                }
                try {
                   playback.Speed=int.Parse(  comboBoxEdit1.EditValue.ToString());
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
    }
}
