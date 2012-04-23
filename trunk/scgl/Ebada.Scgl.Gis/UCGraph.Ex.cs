using System;
using System.Collections.Generic;
using System.Text;
using ScglShapesLib;
using System.Data;
using System.Drawing;
using Netron.GraphLib;
using System.Collections;
using DevExpress.Utils;
using System.Threading;
using System.Windows.Forms;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis
{
    partial class UCGraph
    {
        public delegate void runableDelegate();
        #region 属性
        /// <summary>
        /// 是否显示设备拓扑结构按钮
        /// </summary>
        public bool Showsbtop {
            get { return showsbtop; }
            set {
                showsbtop = value;
                toolStripButton3.Visible = value;
            }
        }
        /// <summary>
        /// 是否显示生成按钮
        /// </summary>
        public bool ShowCreat
        {
            get { return toolStripButton1.Visible; }
            set { toolStripButton1.Visible = value; }
        }
        /// <summary>
        /// 是否显示保存按钮
        /// </summary>
        public bool ShowSave {
            get { return tbSave.Visible; }
            set { tbSave.Visible = value; }
        }
        /// <summary>
        /// 是否显示所有关联电气结线图
        /// </summary>
        public bool Showdeep {
            get { return showdeep; }
            set { showdeep = value; }
        }
        #endregion


        #region  布局
        /// <summary>
        /// 重新布局图元
        /// </summary>
        private void setLayout() {
            StartLayout();
            //graphControl1.GraphLayoutAlgorithm = GraphLayoutAlgorithms.Tree;
            //graphControl1.StartLayout();
        }
        public void StartLayout() {

            if (thLayout != null) thLayout.Abort();
            ts = null;
            try {

                //ts = new ThreadStart(getRunable());
                //thLayout = new Thread(ts);
                //thLayout.Start();
                //Refresh();
            } catch {
            }

        }
        //runableDelegate getRunable() {
        //    AutojxtLayout tl = new AutojxtLayout(graphControl1);
        //    return new runableDelegate(tl.StartLayout);
        //}
        #endregion

        #region 变量
        bool showdeep = false;
        bool showsbtop = true;
        static WaitDialogForm msgbox = null;
        Thread thLayout = null;
        ThreadStart ts = null;


        Hashtable pidHash = new Hashtable();
        //已遍历的母线
        Dictionary<string, string> mxdic = new Dictionary<string, string>();
        //已生成图元的设备
        Dictionary<string, BaseShape> shapdic = new Dictionary<string, BaseShape>();
        //图元当前连接点
        Dictionary<BaseShape, int> shapenumdic = new Dictionary<BaseShape, int>();
        //母线连接点-getfrom
        Dictionary<BaseShape, int> shapenumdicmx = new Dictionary<BaseShape, int>();
        #endregion

        #region 生成图形
        private void createGraph() {
            //UCBDZsbtopo sbtopo = new UCBDZsbtopo();
            //sbtopo.Showdeep = showdeep;
            string p = pid;
            if (pid.StartsWith("jxt")) p = "";
            //DataTable sbtable = sbtopo.GetSBtable(p);
            shapdic.Clear();
            if (msgbox == null)
                msgbox = new WaitDialogForm("", "绘制图元，请稍候。。。");
            msgbox.Show();
            graphControl1.BeginInitData();
            //createGraph(sbtable, "root");
            aa();
            graphControl1.EndInitData();
            msgbox.Hide();
            //sbtopo.Dispose();
            //sbtopo = null;
        }
        private void aa() {
            string tqcode = pid;
            IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where linecode like '" + tqcode + "%' and linevol='0.4' order by linecode");
            DataTable xltable = Ebada.Core.ConvertHelper.ToDataTable((IList)list,typeof(PS_xl));
            List<xl> xllist = new List<xl>();
            foreach (PS_xl line in list) {
                xl xl = new xl(line);
                xl.initgtsb();
                xllist.Add(xl);
            }
            if (xllist.Count > 0)
                createxl(xllist[0],0);
        }
        void createxl(xl xl,int level) {
            Point offset = Point.Empty;
            BaseShape preshape = null;
            int stepx = 0;
            int stepy = 30;
            if (level == 0) {
                offset = new Point(graphControl1.Width / 2, graphControl1.Height/2);
            } else if(xl.parentNode!=null) {
                preshape = shapdic[xl.parentNode.owner.gtID];
                offset=xl.parentNode.Location;
                stepx = 30; stepy = 0;
            }
            int i=0;
            newShape("text", xl.owner.LineCode, xl.owner.LineName, level).Location=offset;
            foreach (pnode node in xl.nodes) {
                node.Location = new Point(offset.X+stepx*i, offset.Y+stepy * i);
                i++;
            }
            
            for (i = 0; i < xl.nodes.Count; i++) {
                BaseShape shape = creategt(xl.nodes[i]);
                if (preshape != null) {
                    createconnect(preshape, shape,level);
                }
                preshape = shape;
                
            }
            foreach(pnode node in xl.nodes){
                foreach(xl line in xl.Lines){
                    createxl(xl, level + 1);
                }
            }
        }

        private void createconnect(BaseShape preshape, BaseShape shape,int level) {
            int mod = level % 2;
            Connector confrom = preshape.Connectors[3];
            Connector conto = shape.Connectors[1];
            graphControl1.AddConnection(confrom, conto);
        }
        BaseShape creategt(pnode node) {
            BaseShape shape = newShape("gt", node.owner.gtID, node.owner.gth, 0);

            shape.Location = node.Location;

            return shape;
        }
        class pnode{
            public Point Location;
            public List<xl> Lines;
            public List<PS_gtsb> biaoxhs;
            public PS_gt owner;
            public pnode() {
                Location = Point.Empty;
                Lines = new List<xl>();
                biaoxhs = new List<PS_gtsb>();
            }
            public xl ownerLine;
            internal void addLine(xl xl) {
                Lines.Add(xl);
            }
        }
        class xl {
            public List<pnode> nodes;
            public pnode parentNode;
            public List<xl> Lines;

            public PS_xl owner;
            public xl(PS_xl xl) {
                owner = xl;
                nodes = new List<pnode>();
                Lines = new List<xl>();

            }
            public void initgtsb(){
                string linecode = owner.LineCode;
                IList<PS_gt> gtlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + linecode + "' order by gtcode");

                addGt(gtlist);
                IList<PS_gtsb> gtsblist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gtsb>(" where sbtype like '17%' and  gtid in (select gtid from ps_gt where linecode ='" + linecode + "')");
                addBx(gtsblist);
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where  parentgt in (select gtcode from ps_gt where  linecode='" + linecode + "')");
                addXl(xlList);
            }
            internal void addXl(IList<PS_xl> xlList) {
                foreach (PS_xl line in xlList) {
                    xl xl = new xl(line);
                    Lines.Add(xl);
                    pnode node = getNodeByCode(line.ParentGT);

                    if (node != null) {
                        xl.parentNode = node;
                        node.addLine(xl);
                    }
                }
            }
            private void addBx(ICollection<PS_gtsb> list) {
                foreach (PS_gtsb sb in list) {
                    pnode node = getNodeByID(sb.gtID);
                    if (node != null) {
                        node.biaoxhs.Add(sb);
                    }
                }
            }
            public void addGt(ICollection<PS_gt> list) {
                foreach (PS_gt gt in list) {
                    if (gt.gth == "0000") continue;
                    nodes.Add(new pnode() { owner = gt, ownerLine = this });
                }
            }
            private pnode getNodeByCode(string p) {
                foreach (pnode node in nodes) {
                    if (node.owner.gtCode == p) return node;
                }

                return null;
            }
            private pnode getNodeByID(string p) {
                foreach (pnode node in nodes) {
                    if (node.owner.gtID == p) return node;
                }

                return null;
            }
        }
        private void createGraph(DataTable t, string p) {
            pidHash.Clear();
            graphControl1.NewDiagram(true);
            shapdic.Clear();
            shapenumdic.Clear();

            doCreateChild(t, p);
            mxdic.Clear();
            setLayout();

        }
        /// <summary>
        /// 递归了节点　
        /// </summary>
        /// <param name="t"></param>
        /// <param name="p"></param>
        private void doCreateChild(DataTable t, string p) {
            if (pidHash.ContainsKey(p)) return;
            pidHash.Add(p, p);
            DataRow[] rows = t.Select("parentid='" + p + "'");
            foreach (DataRow r in rows) {
                BaseShape shp = null;
                string type = r["type"].ToString();
                string id = r["id"].ToString();
                string devid = r["uid"].ToString();
                string name = r["name"].ToString();
                double dy = 0;
                try { dy = (double)r["dy"]; } catch { }
                int grade = 0;
                int.TryParse(r["gradation"].ToString(), out grade);

                if (!shapdic.ContainsKey(id)) {
                    //if (type == "01" && p != "root") continue;
                    shp = newShape(type, devid, name, grade);
                } else {
                    shp = shapdic[id];
                    if (shp.DeviceType == "05") continue;
                }
                if (shp != null) {
                    if (shapdic.ContainsKey(p)) {
                        BaseShape pshp = shapdic[p];
                        if (!(mxdic.ContainsKey(shp.DeviceID + pshp.DeviceID))) {
                            Connector confrom = getForm(pshp, shp.Grade);
                            Connector conto = getTo(shp, shp.Grade);
                            //增加连接线
                            Connection cn = graphControl1.AddConnection(confrom, conto);
                            if (cn != null && shp.DeviceType!="01")
                                cn.LinePath = "Rectangular";
                            //增加连接设备记录，以免重复连接
                            mxdic.Add(pshp.DeviceID + shp.DeviceID, null);
                        }
                    }
                }
                if (!(shp.DeviceType == "05" && dy>10))
                doCreateChild(t, id);
            }
        }
        /// <summary>
        /// 增加一个设备图元
        /// </summary>
        /// <param name="type">图元种类</param>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private BaseShape newShape(string type, string id, string text, int grade) {
            BaseShape shp =  graphControl1.AddShape(ShapeHelper.GetShapeKey(type), new PointF(10, 10)) as BaseShape;
            if (shp != null) {
                shp.Text = text;
                shp.DeviceID = id;
                shp.Grade = grade;
                shapdic.Add(id, shp);
            }
            return shp;
        }
        private Connector getForm(BaseShape shp, int tograde) {
            Connector con = shp.Connectors[0];
            string type = shp.DeviceType;
            if (type == "05") {
                con = shp.Connectors[3];
            } else if (type == "01") {//母线
                if (shapenumdic.ContainsKey(shp)) {
                    shapenumdic[shp]++;
                } else {
                    shapenumdic.Add(shp, 1);
                }
                con = shp.Connectors["bottom" + shapenumdic[shp]];
            }
            else if (type == "56" || type == "57" || type == "58")
            {
                if (shapenumdicmx.ContainsKey(shp))
                {
                    //shapenumdic[shp]++;
                    shapenumdicmx[shp]++;
                }
                else
                {
                    shapenumdicmx.Add(shp, 1);
                }
                int n = 5 - shapenumdicmx[shp] + 1;
                con = shp.Connectors["bottom" + n.ToString()]; 
            }
            else {
                //if (OddEven.IsEven(tograde)) {
                //    con = shp.Connectors["rightconnector"];
                //} else {
                //    con = shp.Connectors["bottomconnector"];
                //}
            }
            return con;
        }
        private Connector getTo(BaseShape shp, int tograde) {
            Connector con = shp.Connectors[0];
            string type = shp.DeviceType;
            if (type == "05") {
                con = shp.Connectors[2];
                shp.Angle = 180;
            } else if (type == "01") {//母线
                if (shapenumdic.ContainsKey(shp)) {
                    shapenumdic[shp]++;
                } else {
                    shapenumdic.Add(shp, 1);
                }
                con = shp.Connectors["bottom" + shapenumdic[shp]];            
            }
            else if (type == "56" || type == "57" || type == "58")
            {
                if (shapenumdic.ContainsKey(shp))
                {
                    shapenumdic[shp]++;
                }
                else
                {
                    shapenumdic.Add(shp, 1);
                }
                con = shp.Connectors["bottom" + shapenumdic[shp]]; 
            
            }
            else {
                //if (OddEven.IsEven(tograde)) {
                //    con = shp.Connectors["leftconnector"];
                //} else {
                //    con = shp.Connectors["topconnector"];
                //}
            }
            return con;
        }
        #endregion
    }
}
