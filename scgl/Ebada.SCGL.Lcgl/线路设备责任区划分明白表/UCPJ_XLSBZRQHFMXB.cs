/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using DevExpress.Utils;
using Ebada.Scgl.Lcgl;
using Ebada.Scgl.WFlow;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_XLSBZRQHFMXB : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_xlsbzrqhfmbb> gridViewOperation;

        public event SendDataEventHandler<PJ_xlsbzrqhfmbb> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private string parentUserName = null;
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_xlsbzrqhfmbb,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
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
            set { currRecord = value; }
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
                            SubmitButton.Caption = wt.Description;
                            liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "") TaskOverButton.Caption = wt.Description;
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
                varDbTableName = value;
            }
        }
        public UCPJ_XLSBZRQHFMXB()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_xlsbzrqhfmbb>(gridControl1, gridView1, barManager1, new frmXLSBZRQHFMXBEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_xlsbzrqhfmbb>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_xlsbzrqhfmbb>(gridViewOperation_AfterDelete);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_xlsbzrqhfmbb>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        void gridViewOperation_AfterDelete(PJ_xlsbzrqhfmbb obj)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
           
            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}

            RefreshData(" where OrgCode='" + parentID + "' order by id desc");
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_xlsbzrqhfmbb> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_xlsbzrqhfmbb> e)
        {
            if (parentID == null || parentUserName == null || parentUserName == "")
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue == null) return;
            parentUserName = barEditItem1.EditValue.ToString();
            if (!string.IsNullOrEmpty(parentUserName))
            {
                RefreshData(" where OrgCode='" + parentID + "' and zrr='" + parentUserName + "' order by id desc");
            }
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];

            repositoryItemComboBox1.Items.Clear();
            barEditItem1.EditValue = null;
            if (org != null)
            {
                ParentObj = org;
                repositoryItemComboBox1.Properties.Items.Clear();
                IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='线路设备责任区划分明白表' and sx like '%{0}%' and nr!=''", "负责人"));
                if (strlist.Count > 0)
                    repositoryItemComboBox1.Properties.Items.AddRange(strlist);
                else
                {
                    strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                    string.Format("select UserName from mUser where  OrgCode = '{0}'", parentID));
                    repositoryItemComboBox1.Properties.Items.AddRange(strlist);


                }
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }
            

        }
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_xlsbzrqhfmbb);
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            hideColumn("OrgCode");
            hideColumn("OrgName");
            hideColumn("S1");
            hideColumn("S2");
            hideColumn("S3");

           
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_xlsbzrqhfmbb> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_xlsbzrqhfmbb newobj)
        {
            if (parentID == null || parentUserName == null || parentUserName=="") return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.Creattime = DateTime.Now;
            newobj.zrr = parentUserName;
          
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where OrgCode='" + value + "' order by id desc");
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
                    ParentID = value.OrgID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

            ExportXLSBZRQHFMXB etdjh = new ExportXLSBZRQHFMXB();
            etdjh.ExportExcel(parentID);
           
           
           
        }

        private void barExplorMonth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportTDJH etdjh = new ExportTDJH();
            etdjh.ExportExcelMonth(parentObj.OrgCode);
        }

        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmModleSubmit fm = new frmModleSubmit();
            fm.RecordWorkFlowData = WorkFlowData;
            fm.CurrRecord = currRecord;
            if (currRecord.Status == "申报")
                fm.Status = "add";
            else
                fm.Status = "edit";
            fm.Kind = currRecord.Kind;
            ExportTDJH export = new ExportTDJH();
            export.CurrRecord = currRecord;
            export.IsWorkflowCall = isWorkflowCall;
            export.ParentTemple = parentTemple;
            export.RecordWorkFlowData = WorkFlowData;

            export.ExportExcelSubmit(ref parentTemple,  parentID, false);
           
            fm.ParentTemple = parentTemple;
            if (fm.ShowDialog() == DialogResult.OK)
            {

                if (MainHelper.UserOrg.OrgName.IndexOf("局") == -1)
                    export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(parentID);
                else
                    export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(parentID);
                gridControl1.FindForm().Close();
            }
        }

        private void liuchenBarClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strmess = "";
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联信息?") != DialogResult.OK)
            {
                return;
            }
            if (RecordWorkTask.DeleteModleRelationRecord(currRecord, WorkFlowData,ref strmess))
            {
                MsgBox.ShowTipMessageBox("清除成功");
            }
            else
            {
                MsgBox.ShowTipMessageBox("清除失败: " + strmess);
            }

        }

        private void barExplorAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportCQJBYDTDJXJH etdjh = new ExportCQJBYDTDJXJH();
            etdjh.ExportExcel("");
        }

        private void barExplorOrgCun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportCQJBYDTDJXJH etdjh = new ExportCQJBYDTDJXJH();
            etdjh.ExportExcelCunJian(parentID);
        }

        private void barExplorJuCun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportCQJBYDTDJXJH etdjh = new ExportCQJBYDTDJXJH();
            etdjh.ExportExcelCunJian("");
        }

        private void barExplorOrgQiu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ExportCQJBYDTDJXJH etdjh = new ExportCQJBYDTDJXJH();
            etdjh.ExportExcelQiuJian(parentID);
        }

       


    }
}
