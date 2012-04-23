using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Netron.GraphLib;
using ScglShapesLib;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis
{
    public partial class UCGraph : UserControl
    {
        public UCGraph() {
            InitializeComponent();
            loadShape();

            graphControl1.OnShapeMenuItemClick += new Netron.GraphLib.ShapeInfo(graphControl1_OnShapeMenuItemClick);
        }
        public event ShapeInfo OnShapeMenuItemClick;
        public Netron.GraphLib.UI.GraphControl GraphControl {
            get { return graphControl1; }
        }
       
        void graphControl1_OnShapeMenuItemClick(object sender, Netron.GraphLib.Shape shape) {
            MenuItem menu = sender as MenuItem;
            switch (menu.Text) {
                case "设备参数":
                    showData(shape);
                    break;
                case "投入运行":
                    //setDeviceStatus((shape as BaseShape).DeviceID, 0);
                    break;
                case "退出运行":
                    //setDeviceStatus((shape as BaseShape).DeviceID,1);
                    break;
            }
            if (OnShapeMenuItemClick != null)
                OnShapeMenuItemClick(sender, shape);
        }
        /// <summary>
        /// 设置运行，退出
        /// </summary>
        /// <param name="flag">0运行，1退出</param>
        private void setDeviceStatus(string deviceid,int flag) {
            if (string.IsNullOrEmpty(deviceid)) return;
        }
        /// <summary>
        /// 显示设备属性
        /// </summary>
        /// <param name="shape"></param>
        private void showData(Netron.GraphLib.Shape shape) {
            if (shape is BaseShape) {
                BaseShape bs = shape as BaseShape;
                
            }
        }
        /// <summary>
        /// 加载图形库
        /// </summary>
        private void loadShape() {
            if (OnLoadShape != null) {
                OnLoadShape(this, null);
            } else {
                string file = Application.StartupPath + "\\ScglShapesLib.dll";
                
                shapesView.ShowAs(Netron.GraphLib.ShapesView.Tree);
                shapesView.AddLibrary(file);
                graphControl1.AddLibrary(file);
                graphControl1.GraphLayoutAlgorithm = Netron.GraphLib.GraphLayoutAlgorithms.Tree;

                
            }
            //设置连接线箭头
            //this.graphControl1.DefaultConnectionEnd = Netron.GraphLib.ConnectionEnd.RightFilledArrow;
        }
        public event EventHandler OnLoadShape;
        public string GetNml() {
            return graphControl1.GetNML();
        }
        public void OpenNml(string nml) {
            graphControl1.OpenNMLFragment(nml);
        }
        public void New() {
            graphControl1.NewDiagram(true);
        }
        private void graphControl1_OnShowProperties(object sender, object[] props) {
            this.propertyGrid1.SelectedObjects = props;
            return;
        }
        string pid;
        public void Open(string p) {
            pid = p;
            PX_Objects obj = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PX_Objects>(p);
            if (obj != null) {
                OpenNml(obj.points);
            }
        }
        public void Save(string p){
            if (string.IsNullOrEmpty(p)) p = pid;
            Save(p, false);
        }

        public void Save(string p, bool isNew) {
            if (string.IsNullOrEmpty(p))
                if (string.IsNullOrEmpty(pid))
                    return;
                else
                    p = pid;

            if (!isNew) {
                PX_Objects obj = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PX_Objects>(p);
                if (obj != null) {
                    obj.points = GetNml();
                    obj.ExData = new byte[] { }; 
                    Client.ClientHelper.PlatformSqlMap.Update<PX_Objects>(obj);
                    return;
                }
            }
            PX_Objects sf = new PX_Objects();
            sf.id = p;
            sf.layerid = "台区网络示意图";
            sf.points = GetNml();
            Client.ClientHelper.PlatformSqlMap.Create<PX_Objects>(sf);
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            createGraph();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            //frmBdzSb dlg = new frmBdzSb();
            //dlg.BDZUID = pid;
            //dlg.UCBDZsbtop.Showdeep = showdeep;
            //dlg.Show(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            //放大
            graphControl1.Zoom *= 1.1f;
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            //缩小
            graphControl1.Zoom /= 1.1f;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            setLayout();
        }

        private void tbSave_Click(object sender, EventArgs e) {
            Save(pid);
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e) {

        }

        private void tbCopy_Click(object sender, EventArgs e) {
            graphControl1.Copy();
        }

        private void tbPaste_Click(object sender, EventArgs e) {
            graphControl1.Paste();
        }

        internal static void ShowDialog(string tqcode) {
            Form dlg = new Form();
            UCGraph uc = new UCGraph();
            uc.Open(tqcode);
            uc.Dock = DockStyle.Fill;
            uc.Parent = dlg;
            uc.Showsbtop = false;
            uc.ShowSave = true;
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.Size = new Size(800, 600);
            dlg.ShowDialog();
        }
    }
}
