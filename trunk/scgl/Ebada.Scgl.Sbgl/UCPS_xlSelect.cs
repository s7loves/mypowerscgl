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
    public partial class UCPS_xlSelect : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<PS_xl> treeViewOperator;
        private string parentID = null;
        private PS_xl parentObj;
        [Browsable(false)]
        public TreeViewOperation<PS_xl> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        
        public event SendDataEventHandler<PS_xl> FocusedNodeChanged;
        public event SendDataEventHandler<PS_xl> AfterAdd;
        public event SendDataEventHandler<PS_xl> AfterEdit;
        public event SendDataEventHandler<PS_xl> AfterDelete;
        public UCPS_xlSelect() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<PS_xl>(treeList1, barManager1,new frmxlEdit());     
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            Init();
        }



        

        void treeViewOperator_AfterDelete(PS_xl newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(PS_xl newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
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

        }
        string getcode(TreeListNode pnode, TreeListNodes nodes) {
            string code = "";
            int levenum = 3;
            if (pnode!=null && pnode.Level == 0) levenum = 4;
            string linecode = "";// pnode["LineCode"].ToString();
            if (pnode != null ) {//可能与低压线路重号
                linecode = pnode["LineCode"].ToString();
                string sql = string.Format("Select max(linecode) as LineCode from ps_xl where len(linecode)={2} and Left(linecode,{0})='{1}'", linecode.Length,linecode,linecode.Length+levenum);
                Hashtable ht = Client.ClientHelper.PlatformSqlMap.GetObject("Select", sql) as Hashtable;
                if (ht != null && ht["LineCode"]!=null) {
                    string childcode = ht["LineCode"].ToString();
                    if (!string.IsNullOrEmpty(childcode)) {
                        int maxcode = int.Parse(childcode.Substring(linecode.Length, levenum));
                        if (levenum == 4) {
                            code = linecode + (maxcode + 10).ToString("0000");
                        } else {
                            code = linecode + (maxcode + 1).ToString("000");
                        }
                    }
                }
            } 
           if(code==""){
               if (nodes.Count > 0) {
                   int maxcode = 0;
                   foreach (TreeListNode node in nodes) {
                       linecode = node["LineCode"].ToString();
                       maxcode = Math.Max(maxcode, int.Parse(linecode.Substring(linecode.Length - levenum, levenum)));
                   }
                   if (levenum == 4) {
                       code = linecode.Substring(0, linecode.Length - levenum) + (maxcode + 10).ToString("0000");
                   } else {
                       code = linecode.Substring(0, linecode.Length - levenum) + (maxcode + 1).ToString("000");
                   }

               } else 
               {
                    if (pnode != null) {
                        if (pnode.Level == 0)
                            code = pnode["LineCode"].ToString() + "0010";
                        else
                            code = pnode["LineCode"].ToString() + "001";
                    } else {
                        code = ParentObj.OrgCode + "001";
                    }
                }
            }

            return code;
        }
        protected override void OnLoad(EventArgs e) {
            InitData();
            base.OnLoad(e);

        }
        public void Init() {
            foreach (TreeListColumn cl in treeList1.Columns)
            {
                cl.Visible = false;
            }

            treeList1.Columns["LineName"].Visible = true;
            treeList1.Columns["LineP"].Visible = true;
            treeList1.Columns["LineQ"].Visible = true;
            treeList1.Columns["K"].Visible = true;
            treeList1.Columns["TotalT"].Visible = true;
 

            //treeList1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.GdsDic;
            //treeList1.Columns["OrgCode2"].ColumnEdit = DicTypeHelper.BdsDic;
            //treeList1.Columns["Owner"].ColumnEdit = DicTypeHelper.OwnerDic;
            //treeList1.Columns["RunState"].ColumnEdit = DicTypeHelper.RunState;
            if (this.Site != null) return;    

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData(" where LineID='" + ParentID + "' and linevol='10'  order by linecode");
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e) {

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
                    RefreshData(" where LineID='" + value + "' and linevol='10'  order by linecode");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_xl ParentObj
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
                    ParentID = value.LineID;
                }
            }
        }

    }
}
