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

namespace Ebada.Scgl.Yxgl {
    public partial class UCxlTreeSelector : UserControl {

        public event SendDataEventHandler<PS_xl> LineSelectionChanged;
        private Dictionary<string, PS_xl> mLines;
        private Dictionary<string, mOrg> mOrgs;
        private DataTable mTable;
        public UCxlTreeSelector() {
            InitializeComponent();
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            treeList1.BeforeFocusNode += new BeforeFocusNodeEventHandler(treeList1_BeforeFocusNode);
            treeList1.BeforeExpand += new BeforeExpandEventHandler(treeList1_BeforeExpand);
            mLines = new Dictionary<string, PS_xl>();
            mOrgs = new Dictionary<string, mOrg>();
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
            IList<mOrg> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgtype='1'");
            foreach (mOrg org in list) {
                mTable.Rows.Add(org.OrgName, org.OrgCode, "gds", "gds");
                mOrgs.Add(org.OrgCode, org);
            }
        }
        void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e) {
            
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["Type"].ToString();
            if (!e.Node.HasChildren) {
                treeList1.BeginInit();
                if (type == "gds") {
                    IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + id + "' and len(linecode)=6");
                    foreach (PS_xl xl in list) {
                        mTable.Rows.Add(xl.LineName, xl.LineID, id, "xl");
                        mLines.Add(xl.LineID, xl);
                    }
                } else if (type == "xl") {
                    IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where parentid='" + id + "' and linevol>=10.0");
                    foreach (PS_xl xl in list) {
                        mTable.Rows.Add(xl.LineName, xl.LineID, id, "xl");
                        mLines.Add(xl.LineID, xl);
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
        public PS_xl GetLine() {

            return null;
        }
        /// <summary>
        /// 获取选中的线路所在单位
        /// </summary>
        /// <returns></returns>
        public mOrg GetOrg() {

            return null;
        }
        /// <summary>
        /// 设置显示的所,可控制数据范围只显示单个所
        /// </summary>
        /// <returns></returns>
        public void SetShowOrg(mOrg org) {

        }
    }
}
