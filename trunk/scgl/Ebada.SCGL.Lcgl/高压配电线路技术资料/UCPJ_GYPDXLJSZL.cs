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
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors.Controls;
using Ebada.Scgl.Core;
using DevExpress.XtraTreeList.Columns;
using System.Collections;
using System.IO;
using Ebada.Scgl.WFlow;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_GYPDXLJSZL : DevExpress.XtraEditors.XtraUserControl {

    
        TreeViewOperation<PJ_17> treeViewOperator;
        private string parentID = "";
        private DataTable dt = null;
        private mOrg parentObj = null;
        [Browsable(false)]
        public TreeViewOperation<PJ_17> TreeViewOperator
        {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        private string modleGuid = "DAB4FE1C-10C4-484E-A954-A1A9085F1BDD"; 
  
        LP_Temple Temple=null;
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;


            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;

            }
        }

        public DataTable RecordWorkFlowData
        {
            get
            {
                return WorkFlowData;
            }
            set
            {
                WorkFlowData = value;
                if (isWorkflowCall)
                {
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        if (wt.CommandName == "01")
                        {
                            liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            if (wt.Description != "")
                                SubmitButton.Caption = wt.Description;
                            liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "")
                                    TaskOverButton.Caption = wt.Description;
                                liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            }

                    }

                }
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
            }
        }
        public UCPJ_GYPDXLJSZL()
        {
            InitializeComponent();
           
            btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
            Init();
        }

        void btGDS_EditValueChanged(object sender, EventArgs e)
        {
            parentID = btGdsList.EditValue.ToString();
            
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];
            parentObj = org;
            InitData();
           
        }

      
      

     
      
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGDS_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }
        public void Init() {

            if (dt == null) dt = new DataTable();
            dt.Columns.Clear();
            dt.Columns.Add("LineName", typeof(string));
            dt.Columns.Add("RecordId", typeof(string));
            dt.Columns.Add("Remark", typeof(string));

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            Temple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where ParentID not in (select LPID from LP_Temple where 1=1) and  CellName = '高压配电线路技术档案'");
            string slqwhere = " ";
            IList recordlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", " select distinct RecordId from WF_TableFieldValue where  UserControlId='" + Temple.LPID + "' and   WorkflowId='" + modleGuid + "' and WorkFlowInsId='" + parentObj.OrgName + "' ");
            
            IList<LP_Temple> templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
               "where ParentID ='" + Temple.LPID + "' order by SortID");
            dt.Rows.Clear();
            for (int i = 0; i < recordlist.Count; )
            { 
                slqwhere = " where RecordId='"+recordlist[i]
                    + "' and  UserControlId='" + Temple.LPID 
                    + "' and   WorkflowId='"  + modleGuid 
                    + "' and   fieldname='"  + "高压配电线路名称" 
                    + "' and WorkFlowInsId='" + parentObj.OrgName + "' ";
                WF_TableFieldValue value = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(slqwhere);
                DataRow dr =dt.NewRow();
                if(value!=null)
                {
                    dr["LineName"]=value.ControlValue;
                }
                  slqwhere = " where RecordId='"+recordlist[i]
                    + "' and  UserControlId='" + Temple.LPID 
                    + "' and   WorkflowId='"  + modleGuid
                    + "' and   fieldname='" + "线路信息" 
                    + "' and WorkFlowInsId='" + parentObj.OrgName + "' ";
                value = MainHelper.PlatformSqlMap.GetOne<WF_TableFieldValue>(slqwhere);
               
                if(value!=null)
                {
                    dr["Remark"] = value.ControlValue;
                }
                dr["RecordId"] = recordlist[i];
                dt.Rows.Add(dr);
                i++;
            }
            //treeViewOperator.RefreshData(" where OrgCode='" + parentID + "' order by linetype,linecode");
            //treeViewOperator.RefreshData(slqwhere);
            gridControl1.DataSource = dt;
        }

        

        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (parentID == null|| parentID.ToString()=="" )
            {
                return;
            }
            frmGYPDXLJSZLTemplate fm = new frmGYPDXLJSZLTemplate();
            fm.Status = "add";
            fm.ModleGuid = modleGuid;
            fm.OrgName = parentObj.OrgName;
            fm.RowData = new WF_TableFieldValue();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                InitData();
            }
         
            
        }
        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
           
            WF_TableFieldValue tf = new WF_TableFieldValue();
            tf.ID= dr["RecordId"].ToString();
            frmGYPDXLJSZLTemplate fm = new frmGYPDXLJSZLTemplate();
            fm.Status = "edit";
            fm.ModleGuid = modleGuid;
            fm.OrgName = parentObj.OrgName;
            fm.RowData = tf;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                InitData();
            }
        }
        private void btReDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainHelper.UserOrg == null) return;

            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除 【" + dr["LineName"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }

            try
            {


                MainHelper.PlatformSqlMap.DeleteByWhere<WF_TableFieldValue>(" where recordID='"
                    + dr["recordID"] + "' and  UserControlId='" + Temple.LPID
                    + "' and   WorkflowId='" + modleGuid
                    + "' and WorkFlowInsId='" + parentObj.OrgName + "' ");
                InitData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();
        }

        private void btExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

     

        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void TaskOverButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string strmes = "";
            WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null)
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            }
            else
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }

        private void liuchenBarClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string strmess = "";
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联信息?") != DialogResult.OK)
            {
                return;
            }
            if (RecordWorkTask.DeleteModleRelationRecord(currRecord, WorkFlowData, ref strmess))
            {
                MsgBox.ShowTipMessageBox("清除成功");
            }
            else
            {
                MsgBox.ShowTipMessageBox("清除失败: " + strmess);
            }

        }

      
  

       
       
    }
}