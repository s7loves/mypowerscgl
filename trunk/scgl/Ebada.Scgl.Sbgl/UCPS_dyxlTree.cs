/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-5-23
最后一次修改:2011-5-23
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
using Ebada.Scgl.Model;
using DevExpress.XtraEditors.Controls;
using Ebada.Scgl.Core;
using DevExpress.XtraTreeList.Columns;
using System.Collections;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPS_dyxlTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<PS_xl> treeViewOperator;
        private string parentID = null;
        private mOrg parentObj;
        private PS_tq tq;
        private PS_xl xl;
        [Browsable(false)]
        public PS_xl XL {
            get { return xl; }
            set { xl = value; }
        }
        [Browsable(false)]
        public PS_tq TQ {
            get { return tq; }
            set { tq = value; }
        }
        [Browsable(false)]
        public TreeViewOperation<PS_xl> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        
        public event SendDataEventHandler<PS_xl> FocusedNodeChanged;
        public event SendDataEventHandler<PS_xl> AfterAdd;
        public event SendDataEventHandler<PS_xl> AfterEdit;
        public event SendDataEventHandler<PS_xl> AfterDelete;
        public UCPS_dyxlTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<PS_xl>(treeList1, barManager1,new frmxlEdit());
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.BeforeAdd += new ObjectOperationEventHandler<PS_xl>(treeViewOperator_BeforeAdd);
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            
        }

        void treeViewOperator_BeforeAdd(object render, ObjectOperationEventArgs<PS_xl> e) {
            if (ParentObj == null) {
                MsgBox.ShowTipMessageBox("请先选择台区！");
                e.Cancel = true;

            }
        }
        
        

        void treeViewOperator_AfterDelete(PS_xl newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(PS_xl newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(PS_xl newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as PS_xl);
        }
        string getparentValue() {
            string ret = "0";
            if (treeList1.Selection.Count > 0) {
                ret = treeList1.Selection[0][treeList1.ParentFieldName].ToString();
            }
            return ret;
        }
        void treeViewOperator_CreatingObject(PS_xl newobj) {
            string pid = getparentValue();
            TreeListNode pnode = null;
            PS_xl xl1 = null;
            if (treeList1.Selection.Count > 0) {
                xl1 = treeList1.GetDataRecordByNode(treeList1.Selection[0]) as PS_xl;
                pnode = treeList1.Selection[0].ParentNode;
            }
            string linecode = "";
            if (newobj.ParentID == pid) {//同级
                linecode = getcode(pnode, pnode != null ? pnode.Nodes : treeList1.Nodes);
            } else {
                linecode = getcode(treeList1.Selection[0], treeList1.Selection[0].Nodes);
            }
            pid = newobj.ParentID;
            if (xl1 != null)
                Ebada.Core.ConvertHelper.CopyTo(xl1, newobj);
            else if (xl != null) {
                Ebada.Core.ConvertHelper.CopyTo(xl, newobj);
                newobj.LineType = "1";
                newobj.Contractor = tq.Contractor;
            }

            newobj.ParentID = pid;
            if (pid == "0") newobj.ParentID = tq.tqCode;
            newobj.LineID = newobj.LineCode = linecode;
            newobj.LineVol = "0.4";
            newobj.LineName = "";
            newobj.ParentGT = "";
        }
        string getcode(TreeListNode pnode, TreeListNodes nodes) {
            string code = "";
            string linecode = TQ.tqCode;
            int levenum = 3;
            if(pnode!=null)
                linecode = pnode["LineCode"].ToString();

            string sql = string.Format("Select max(linecode) from ps_xl where len(linecode)={2} and Left(linecode,{0})='{1}' and linevol>=10.0", linecode.Length,linecode,linecode.Length+levenum);
            Hashtable ht = Client.ClientHelper.PlatformSqlMap.GetObject("Select", sql) as Hashtable;
            if (ht != null && ht["LineCode"] != null) {
                string childcode = ht["LineCode"].ToString();
                if (!string.IsNullOrEmpty(childcode)) {
                    int maxcode = int.Parse(childcode.Substring(linecode.Length, levenum));
                    code = linecode + (maxcode + 1).ToString("000");
                }
            }
            if (code == "") {
                if (nodes.Count > 0) {
                    int maxcode = 0;
                    linecode = nodes[0]["LineCode"].ToString();
                    foreach (TreeListNode node in nodes) {
                        linecode = node["LineCode"].ToString();
                        maxcode = Math.Max(maxcode, int.Parse(linecode.Substring(linecode.Length - 3, 3)));
                    }
                    code = linecode.Substring(0, linecode.Length - 3) + (maxcode + 1).ToString("000");

                } else {
                    if (pnode != null) {
                        code = pnode["LineCode"].ToString() + "001";
                    } else {
                        code = TQ.tqCode + "001";
                    }
                }
            }
            return code;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Init();
        }
        public void Init() {

            treeList1.Columns["OrgCode"].Visible = true;
            treeList1.Columns["LineType"].Visible = false;
            treeList1.Columns["LineNamePath"].Visible = false;
            treeList1.Columns["LineGtbegin"].Visible = false;
            treeList1.Columns["LineGtend"].Visible = false;
            treeList1.Columns["WireLength"].Visible = false;
            treeList1.Columns["TotalLength"].Visible = false;
            treeList1.Columns["ActualLoss"].Visible = false;
            treeList1.Columns["gdbj"].Visible = false;
            treeList1.Columns["TheoryLoss"].Visible = false;
            treeList1.Columns["ParentGT"].Visible = false;
            treeList1.Columns["WireType"].Visible = false;
            treeList1.Columns["LineCode"].Visible = true;
            if (this.Site != null ) return;

            treeList1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.GdsDic;
            treeList1.Columns["OrgCode2"].ColumnEdit = DicTypeHelper.BdsDic;
            treeList1.Columns["Owner"].ColumnEdit = DicTypeHelper.OwnerDic;
            treeList1.Columns["RunState"].ColumnEdit = DicTypeHelper.RunState;
            
            btGdsList.Edit = DicTypeHelper.GdsDic;

            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by linetype,linecode");
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null) {
                ParentObj = org;
            }
        }
        public void RefreshData(string slqwhere) {
            treeViewOperator.RefreshData(slqwhere);
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(string.Format(" where left(linecode,{0})='{1}' and linevol='0.4' order by linecode",tq.tqCode.Length,tq.tqCode));
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj
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
                    ParentID = value.OrgCode;
                }
            }
        }
        /// <summary>
        /// 隐藏选择列表
        /// </summary>
        public void HideList() {
            btGdsList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btXlList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btTQList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
    }
}
