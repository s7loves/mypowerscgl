/**********************************************
系统:仓库管理
模块:材料名称
作者:Rabbit
创建时间:2012-7-28
最后一次修改:2012-7-28
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Components;
using Ebada.Client;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Kcgl.Model;
using System.Collections;

namespace Ebada.Kcgl {
    /// <summary>
    /// 材料名称维护
    /// </summary>
    public partial class UC材料名称 : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<kc_材料名称表> treeViewOperator;

        public TreeViewOperation<kc_材料名称表> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        public event SendDataEventHandler<kc_材料名称表> FocusedNodeChanged;
        public event SendDataEventHandler<kc_材料名称表> AfterAdd;
        public event SendDataEventHandler<kc_材料名称表> AfterEdit;
        public event SendDataEventHandler<kc_材料名称表> AfterDelete;
        public UC材料名称() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<kc_材料名称表>(treeList1,barManager1,true);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit +=treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete +=treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;

            treeViewOperator.SqlMap = Client.ClientHelper.TransportSqlMap;
        }

        void treeViewOperator_AfterDelete(kc_材料名称表 newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(kc_材料名称表 newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(kc_材料名称表 newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
            treeList1.SetFocusedNode(treeList1.FindNodeByKeyID(newobj.ID));
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1,treeList1.GetDataRecordByNode(e.Node) as kc_材料名称表);
        }

        void treeViewOperator_CreatingObject(kc_材料名称表 newobj) {
            string pid = getparentValue();
            TreeListNode pnode = null;
            if (treeList1.Selection[0] != null) {
                pnode = treeList1.Selection[0].ParentNode;

            }
            if (newobj.ParentID == pid) {//同级
                if (pnode != null)
                    Ebada.Core.ConvertHelper.CopyTo(pnode, newobj);
                newobj.材料代码=getcode(pnode, pnode != null ? pnode.Nodes : treeList1.Nodes);
                
            } else {
                newobj.材料代码 = getcode(treeList1.Selection[0], treeList1.Selection[0].Nodes);
            }
            newobj.材料名称 = kc_材料名称表.f_材料名称;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            treeList1.Columns["序号"].SortOrder = SortOrder.Ascending;
            treeList1.Columns["序号"].VisibleIndex = 10;
            treeList1.Columns["材料代码"].OptionsColumn.AllowEdit = false;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btFind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            InitData();
        }
        string getparentValue() {
            string ret = "0";
            if (treeList1.Selection.Count > 0) {
                ret = treeList1.Selection[0][treeList1.ParentFieldName].ToString();
            }
            return ret;
        }
        
        string getcode(TreeListNode pnode, TreeListNodes nodes) {
            string code = "";
            int levenum = 3;
            //if (pnode != null && pnode.Level == 0) levenum = 4;
            string linecode = "";// pnode["LineCode"].ToString();
            if (pnode != null) {
                linecode = pnode["材料代码"].ToString();
                string sql = string.Format("Select max(材料代码) as LineCode from kc_材料名称表 where len(材料代码)={2} and Left(材料代码,{0})='{1}'", linecode.Length, linecode, linecode.Length + levenum);
                Hashtable ht = Client.ClientHelper.TransportSqlMap.GetObject("Select", sql) as Hashtable;
                if (ht != null && ht["LineCode"] != null) {
                    string childcode = ht["LineCode"].ToString();
                    if (!string.IsNullOrEmpty(childcode)) {
                        int maxcode = int.Parse(childcode.Substring(linecode.Length, levenum));
                        code = linecode + (maxcode + 1).ToString("000");
                    }
                }
            }
            if (code == "") {
                if (nodes.Count > 0) {
                    int maxcode = 0;
                    foreach (TreeListNode node in nodes) {
                        linecode = node["材料代码"].ToString();
                        maxcode = Math.Max(maxcode, int.Parse(linecode.Substring(linecode.Length - levenum, levenum)));
                    }
                    code = linecode.Substring(0, linecode.Length - levenum) + (maxcode + 1).ToString("000");
                } else {
                    if (pnode != null) {

                        code = pnode["材料代码"].ToString() + "001";
                    } else {
                        code = "001";
                    }
                }
            }

            return code;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by "+kc_材料名称表.f_序号);    
        }
    }
}
