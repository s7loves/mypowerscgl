﻿/**********************************************
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
using DevExpress.Utils;

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCsd_xlTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<sd_xl> treeViewOperator;
        private string parentID = null;
        private mOrg parentObj;
        [Browsable(false)]
        public TreeViewOperation<sd_xl> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        
        public event SendDataEventHandler<sd_xl> FocusedNodeChanged;
        public event SendDataEventHandler<sd_xl> AfterAdd;
        public event SendDataEventHandler<sd_xl> AfterEdit;
        public event SendDataEventHandler<sd_xl> AfterDelete;
        public UCsd_xlTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<sd_xl>(treeList1, barManager1,new frmsdxlEdit());
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.BeforeAdd += new ObjectOperationEventHandler<sd_xl>(treeViewOperator_BeforeAdd);
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            Init();
        }

        void treeViewOperator_BeforeAdd(object render, ObjectOperationEventArgs<sd_xl> e) {
            if (ParentObj == null) {
                MsgBox.ShowTipMessageBox("请先选择供电所！");
                e.Cancel = true;

            }
        }

        

        void treeViewOperator_AfterDelete(sd_xl newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(sd_xl newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(sd_xl newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as sd_xl);
        }
        public sd_xl Getps_xl()
        {
           
          return treeList1.GetDataRecordByNode(treeList1.Selection[0]) as sd_xl;
           
        }
        public void hidbar()
        {
            bar1.Visible=false;
        }
        string getparentValue() {
            string ret = "0";
            if (treeList1.Selection.Count > 0) {
                ret = treeList1.Selection[0][treeList1.ParentFieldName].ToString();
            }
            return ret;
        }
        void treeViewOperator_CreatingObject(sd_xl newobj) {
            string pid = getparentValue();
            TreeListNode pnode=null;
            if (treeList1.Selection[0] != null)
            {
                 pnode = treeList1.Selection[0].ParentNode;
                 
            }
            if (newobj.ParentID == pid) {//同级
                if(pnode!=null)
                    Ebada.Core.ConvertHelper.CopyTo(pnode, newobj);
                newobj.LineCode = newobj.LineID = getcode(pnode, pnode!=null?pnode.Nodes:treeList1.Nodes);
                newobj.LineID += new Random().Next(10, 99);
               newobj.LineType =pnode==null?"1": Math.Min(3, pnode.Level + 2).ToString();
            } else {
                newobj.LineCode = newobj.LineID = getcode(treeList1.Selection[0], treeList1.Selection[0].Nodes);
                newobj.LineID += new Random().Next(10, 99);
                newobj.LineType = Math.Min(3, treeList1.Selection[0].Level + 2).ToString();
            }
            
            //newobj.LineVol = "10";
            newobj.OrgCode = parentID;
        }
        string getcode(TreeListNode pnode, TreeListNodes nodes) {
            string code = "";
            int levenum = 3;
            if (pnode!=null && pnode.Level == 0) levenum = 4;
            string linecode = "";// pnode["LineCode"].ToString();
            if (pnode != null ) {//可能与低压线路重号
                linecode = pnode["LineCode"].ToString();
                string sql = string.Format("Select max(linecode) as LineCode from sd_xl where len(linecode)={2} and Left(linecode,{0})='{1}'", linecode.Length,linecode,linecode.Length+levenum);
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
                    } else{
                        code = ParentObj.OrgCode + "301";
                    }
                }
            }

            return code;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

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

            treeList1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.GdsDic;
            treeList1.Columns["OrgCode2"].ColumnEdit = DicTypeHelper.BdsDic;
            treeList1.Columns["Owner"].ColumnEdit = DicTypeHelper.OwnerDic;
            treeList1.Columns["RunState"].ColumnEdit = DicTypeHelper.RunState;
            if (this.Site != null) return;
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
                    RefreshData(" where orgcode='" + value + "'   order by linecode");
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<sd_xl> list = MainHelper.PlatformSqlMap.GetListByWhere<sd_xl>(" where xlpy='' or xlpy is null"); 
            IList<sd_xl> listout = new List<sd_xl>();
            WaitDialogForm wdf = new WaitDialogForm("", "正在生成数据...");
            try
            {
                foreach (sd_xl xl in list)
                {
                    if (xl.xlpy == "")
                    {
                        xl.xlpy = SelectorHelper.GetPysm(xl.LineName);
                        listout.Add(xl);
                    }
                }
                if (listout.Count>0)
                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, listout, null);
            }
            catch { }
            wdf.Close();
            
        }
    }
}
