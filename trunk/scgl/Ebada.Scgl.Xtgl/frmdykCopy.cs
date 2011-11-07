using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using Ebada.Core;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using System.Threading;
using Ebada.Components;

namespace Ebada.Scgl.Xtgl
{
    public partial class frmdykCopy:FormBase
    {
        string mRoleID = "";
        DataTable dt=null;
        private PJ_dyk parentObj;
        private string parentID = "";
        public PJ_dyk ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    parentID = null;
                }
                else
                {
                    parentID = value.ID;
                }
            }
        }

        public frmdykCopy()
        {
            InitializeComponent();
           
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void getCheckList(TreeListNodes nodes, IList<string> list)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.Checked && node["ParentID"].ToString() != "")
                {

                    list.Add(node["ID"].ToString());
                }
                if (node.HasChildren)
                {
                    this.getCheckList(node.Nodes, list);
                }
            }
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<PJ_dyk> list2 = new List<PJ_dyk>();
            this.getCheckList(this.treeList1.Nodes, list);
            long xhidex = 0;
            IList<PJ_dyk> li = MainHelper.PlatformSqlMap.GetList<PJ_dyk>("SelectPJ_dykList", " where ParentID='" + parentObj.bh + "'  order by id desc");
            if (li.Count > 0)
                xhidex = (Convert.ToInt64(li[0].bh) + 1);
            else
            {
                xhidex = (Convert.ToInt64(parentObj.bh) * 100 + 1);
            }
            foreach (string str in list)
            {
                PJ_dyk dyk = new PJ_dyk();
                TreeListNode td = treeList1.FindNodeByKeyID(str);



                dyk.ID = Convert.ToString(xhidex);
                dyk.bh = dyk.ID;
                xhidex++;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                dyk.ParentID = parentObj.ID;
                dyk.dx = parentObj.dx;
                dyk.nr = td["nr"].ToString();
                dyk.sx = td["sx"].ToString();
                list2.Add(dyk);
            }
            try
            {
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                if (list2.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Insert, list2.ToArray());
                    list3.Add(obj3);
                }

                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            }
            catch (Exception exception)
            {
                MainHelper.ShowWarningMessageBox(exception.Message);
               
            }
            this.DialogResult = DialogResult.OK;
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
           
        }
        void Inidata()
        {
             IList li = MainHelper.PlatformSqlMap.GetList("SelectPJ_dykList", " where 1=1  order by id");
            if (dt == null)
            {
                if (li.Count > 0)
                {
                    dt = ConvertHelper.ToDataTable(li);
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add("dx", typeof(string));
                    dt.Columns.Add("sx", typeof(string));
                    dt.Columns.Add("nr", typeof(string));
                    dt.Columns.Add("ID", typeof(string));
                    dt.Columns.Add("ParentID", typeof(string));
                }
                dt.Columns.Add("xh", typeof(bool));

            }
            foreach (DataRow drtemp in dt.Rows)
            {
                drtemp["xh"] = 0;
            }
            li = MainHelper.PlatformSqlMap.GetList("SelectPS_sbcsList", " where 1=1  order by bh");
            DataRow dr = dt.NewRow();
            dr["xh"] = 0;
            dr["id"] = "0000";
            dr["dx"] = "设备参数";
            dr["sx"] ="";
            dr["nr"] = "";
            dt.Rows.Add(dr);
            foreach (PS_sbcs sbcs in li)
            {
                 dr = dt.NewRow();
                dr["xh"] = 0;
                dr["id"] = sbcs.ID;
                dr["ParentID"] = "0000";
                dr["dx"] = "设备参数";
                dr["sx"] = sbcs.mc;
                dr["nr"] = sbcs.xh;
                dt.Rows.Add(dr);
            }

            treeList1.DataSource = dt;
        }
        private void frmdykCopy_Load(object sender, EventArgs e)
        {
            Inidata();
        }
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                this.SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;

                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }

                node.ParentNode.CheckState = b ? CheckState.Checked : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
    }
}