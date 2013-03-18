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
    [ToolboxItem(false)]
    public partial class UCsdxlTree : UserControl {

        public event SendDataEventHandler<sd_xl> LineSelectionChanged;
        private Dictionary<string, sd_xl> mLines;
        private Dictionary<string, sd_xl> mLines2;
        private Dictionary<string, mOrg> mOrgs;
        private Dictionary<string, PS_tq> mTQs;
        private DataTable mTable;
        private mOrg m_org;
        private bool showHvol=true;
        private bool showLvol=true;
        public UCsdxlTree()
        {
            InitializeComponent();
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
            mLines = new Dictionary<string, sd_xl>();
            mLines2 = new Dictionary<string, sd_xl>();
            mOrgs = new Dictionary<string, mOrg>();
            mTQs = new Dictionary<string, PS_tq>();
            
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
            IList<sd_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where 1>0");
            foreach (sd_xl xl in list)
            {
                mLines.Add(xl.LineID, xl);
                mTable.Rows.Add(xl.LineName, xl.LineID, xl.ParentID, "xl");
               
            }
        }
        void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e) {
            
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["Type"].ToString();

            if (!e.Node.HasChildren)
            {
                treeList1.BeginInit();
                if (type == "xl")
                {
                    IList<sd_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where parentid='" + id + "'");
                    
                    
                    foreach (sd_xl xl in list)
                    {

                        if (!mLines.ContainsKey(xl.LineID))
                        {
                            mTable.Rows.Add(xl.LineName, xl.LineID, id, "xl");
                            mLines.Add(xl.LineID, xl);
                        }
                    }
                } 
          
                treeList1.EndInit();
            }
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["Type"].ToString();
            if (type == "xl") {
                if (LineSelectionChanged != null)
                    LineSelectionChanged(treeList1, mLines[id]);
           
            }
        }

        /// <summary>
        /// 获取选中的线路
        /// </summary>
        /// <returns></returns>
        public sd_xl GetLine() {
            TreeListNode node = treeList1.FocusedNode;
            sd_xl line = null;
            if (node != null) {
                string id = node["ID"].ToString();
                string type = node["Type"].ToString();
                if (type == "xl")
                    line = mLines[id];
                else if (type=="xl2")
                    line=mLines2[id];
            }
            return line;
        }
        /// <summary>
        /// 获取选中的线路所在单位
        /// </summary>
        /// <returns></returns>
        public mOrg GetOrg() {
            sd_xl line = GetLine();
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
