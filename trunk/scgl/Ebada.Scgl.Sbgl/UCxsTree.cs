using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Ebada.Scgl.Sbgl {
    public partial class UCxsTree : UserControl {

        public event SendDataEventHandler<PS_xl> LineSelectionChanged;
        public event SendDataEventHandler<PS_dxxh> DxxhSelectionChanged;
        public event SendDataEventHandler<PS_byqxh> ByqxhSelectionChanged;
        private Dictionary<string, PS_xl> mLines;
        private Dictionary<string, mOrg> mOrgs;
        private Dictionary<string, PS_tq> mTQs;
        private Dictionary<string, PS_dxxh> mDxxh;
        private Dictionary<string, PS_byqxh> mByqxh;
        private DataTable mTable;
        private mOrg m_org;
        private bool showHvol=true;
        private bool showLvol=true;
        public UCxsTree() {
            InitializeComponent();
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
            mLines = new Dictionary<string, PS_xl>();
            mOrgs = new Dictionary<string, mOrg>();
            mTQs = new Dictionary<string, PS_tq>();
            mDxxh = new Dictionary<string, PS_dxxh>();
            mByqxh = new Dictionary<string, PS_byqxh>();
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            initTree();
        }
        private void initTable() {
            mTable = new DataTable();
            mTable.Columns.Add("Name");
            mTable.Columns.Add("ID");
            mTable.Columns.Add("ParentID");
            mTable.Columns.Add("Type");
            treeList1.DataSource = mTable;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
        }
        private void initTree() {
            if (mTable == null) initTable();
            mTable.Rows.Add( "线路", "gds","0", "gds");
            mTable.Rows.Add( "导线型号", "xlxh", "0","xlxh");
            mTable.Rows.Add( "变压器型号", "byqxh", "0","byqxh");
            IList<mOrg> list=new List<mOrg>();
            if (m_org == null) {
                list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='1'");
            } else {
                list.Add(m_org);
            }
            foreach (mOrg org in list) {
                mTable.Rows.Add(org.OrgName, org.OrgCode, "gds", "gds");
                mOrgs.Add(org.OrgCode, org);
                if(showHvol)
                mTable.Rows.Add("高压线路",  "g_" + org.OrgCode, org.OrgCode, "gyxl");
                //if(showLvol)
                //mTable.Rows.Add("低压线路", "d_" + org.OrgCode, org.OrgCode, "dyxl");
            }
        }
        void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e) {
            
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["Type"].ToString();
            
            if (!e.Node.HasChildren) {
                treeList1.BeginInit();
                if (type == "gyxl") {
                    IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + id.Substring(2) + "' and len(linecode)=6");
                    foreach (PS_xl xl in list) {
                        mTable.Rows.Add(xl.LineName, xl.LineID, id, "xl");
                        mLines.Add(xl.LineID, xl);
                    }
                } else if (type == "xlxh") {
                    IList<PS_dxxh> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_dxxh>("SelectPS_dxxhList");
                    //string lname = mLines[id].LineName;
                    foreach (PS_dxxh xlxh in list)
                    {
                        mTable.Rows.Add(xlxh.dxxh/*.Replace(lname, "")*/, xlxh.ID, id, "xlxhchild");
                        mDxxh.Add(xlxh.ID, xlxh);
                    }
                } else if (type == "byqxh") {
                   // string lname = e.Node["Name"].ToString();
                    IList<PS_byqxh> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_byqxh>("SelectPS_byqxhList");
                    foreach (PS_byqxh byqxh in list)
                    {
                        mTable.Rows.Add(byqxh.byqModle/*.Replace(lname, "")*/, byqxh.ID, id, "byqxhchild");
                        mByqxh.Add(byqxh.ID, byqxh);
                    }
                } 
                treeList1.EndInit();
            }
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (e.Node == null)
            {
                return;
            }
            string id = e.Node["ID"].ToString();
            string type = e.Node["Type"].ToString();
            if (type == "xl") {
                if (LineSelectionChanged != null)
                    LineSelectionChanged(treeList1, mLines[id]);
            }
            else if (type == "xlxhchild")
            {
                if (DxxhSelectionChanged!=null)
                {
                    DxxhSelectionChanged(treeList1, mDxxh[id]);
                }
            }
            else if (type == "byqxhchild")
            {
                if (ByqxhSelectionChanged!=null)
                {
                    ByqxhSelectionChanged(treeList1, mByqxh[id]);
                }
            }
        }

        /// <summary>
        /// 获取选中的线路
        /// </summary>
        /// <returns></returns>
        public PS_xl GetLine() {
            TreeListNode node = treeList1.FocusedNode;
            PS_xl line = null;
            if (node != null) {
                string id = node["ID"].ToString();
                string type = node["Type"].ToString();
                if (type == "xl")
                    line = mLines[id];
            }
            return line;
        }
        /// <summary>
        /// 获取选中的线路所在单位
        /// </summary>
        /// <returns></returns>
        public mOrg GetOrg() {
            PS_xl line = GetLine();
            mOrg org = null;
            if (line != null) {
                org = mOrgs[line.OrgCode];
            }
            return org;
        }
        /// <summary>
        /// 设置显示的所,可控制数据范围只显示单个所,在load前设置才会生效
        /// </summary>
        /// <returns></returns>
        public void SetShowOrg(mOrg org) {
            m_org = org;
        }
        /// <summary>
        /// 显示高压线路
        /// </summary>
        public bool ShowHvol { get { return showHvol; } set { showHvol = value; } }
        /// <summary>
        /// 显示低压线路
        /// </summary>
        public bool ShowLvol { get { return showLvol; } set { showLvol = value; } }
    }
}
