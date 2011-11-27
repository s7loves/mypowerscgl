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
            //DataRow row=treeList1.GetDataRecordByNode(e.Node) as DataRow;
            string id = e.Node["ID"].ToString();
            if (id.Contains("_") && e.Node.Nodes.Count == 1) {
                e.Node.Nodes.Clear();
                //inittq(id.Substring(0, id.Length - 1));
            }
            e.CanExpand = true;
        }

        void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e) {
            string id = e.Node["ID"].ToString();
            string type = e.Node["Type"].ToString();
            if (!e.Node.HasChildren) {
                if (type == "gds") {
                    IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + id + "'");
                    foreach (PS_xl xl in list) {
                        mTable.Rows.Add(xl.LineName, xl.LineID, "xl", id);
                        mLines.Add(xl.LineID, xl);
                    }
                } else if (type == "xl") {
                    IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where parentid='" + id + "'");
                    foreach (PS_xl xl in list) {
                        mTable.Rows.Add(xl.LineName, xl.LineID, "xl", id);
                        mLines.Add(xl.LineID, xl);
                    }
                }
            }
        }
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            
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
        public void GetShowOrg(mOrg org) {

        }
    }
}
