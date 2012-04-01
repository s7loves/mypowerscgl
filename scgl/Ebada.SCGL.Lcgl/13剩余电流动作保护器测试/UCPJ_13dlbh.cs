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
using DevExpress.XtraEditors.Repository;
using Ebada.Scgl.WFlow;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_13dlbh : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PS_tqdlbh> gridViewOperation;
        public mOrg gds =null;
        public event SendDataEventHandler<PS_tqdlbh> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        frmtqdlbhEdit frm = new frmtqdlbhEdit();
        private string parentID = null;
        private mOrg parentObj;


        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PS_tqdlbh,LP_Record";
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
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "")
                                    TaskOverButton.Caption = wt.Description;
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
        public UCPJ_13dlbh()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PS_tqdlbh>(gridControl1, gridView1, barManager1, frm);
            GridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PS_tqdlbh>(gridViewOperation_BeforeUpdate);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PS_tqdlbh>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PS_tqdlbh>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PS_tqdlbh>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PS_tqdlbh>(gridViewOperation_AfterDelete);
        }
        void gridViewOperation_AfterDelete(PS_tqdlbh obj)
        {

            string slqwhere = "";
            if (isWorkflowCall)
            {

               
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>("where ModleRecordID='" +
                   obj.sbID + "'"
                   + " and ModleTableName='" + obj.GetType().ToString() + "'"
                   + " and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'"
                   );
            }

            RefreshData(" where tqID in (select tqID  from PS_tq where LEFT(tqID,'" + parentID.Length + "')= '" + parentID + "') OR orgCode='" + parentObj.OrgCode + "  ");
        }
        void gridViewOperation_AfterAdd(PS_tqdlbh obj)
        {
            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = obj.sbID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                mrwt.ModleTableName = obj.GetType().ToString();
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }





            RefreshData(" where tqID in (select tqID  from PS_tq where LEFT(tqID,'" + parentID.Length + "')= '" + parentID + "')  ");


        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PS_tqdlbh> e)
        {
            if (parentID == null)
                e.Cancel = true;
            frm.OrgCode = btGdsList.EditValue.ToString();
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PS_tqdlbh> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PS_tqdlbh> e)
        {
            if (parentID == null)
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
            btXL.EditValueChanged += new EventHandler(btXLList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btXLList_EditValueChanged(object sender, EventArgs e)
        {
            if (btXL.EditValue == null) return;
            parentID = btXL.EditValue.ToString();
            
            if (parentID != "")
            {
                IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where LineCode='" + parentID + "'");
                //frm.LineCode = parentID;
                PS_xl xl = null;
                if (list.Count > 0)
                {
                    xl = list[0];
                   // ParentObj = xl;
                }
            }
         
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];
           
            if (org != null)
            {
                RefreshData(" where tqID in(select tqID from PS_tq where LEFT(tqID,'" + org.OrgCode.Length + "')='" + org.OrgCode + "')  orgCode='" + org.OrgCode + " order by sbCode ");
                gds = org;
                ParentObj = org;
                IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + org.OrgCode + "'");
                repositoryItemLookUpEdit3.DataSource = xlList;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PS_tqdlbh);
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

            //hideColumn("OrgCode");
            hideColumn("sbName");
            hideColumn("Number");
            hideColumn("MadeDate");
            hideColumn("InstallDate");
            hideColumn("State");
            hideColumn("dzsj");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            
            if (isWorkflowCall)
            {

                slqwhere = slqwhere + " and sbid in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
                slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                   + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
              
            }
            slqwhere = slqwhere + "  order by sbCode ";
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PS_tqdlbh> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PS_tqdlbh newobj)
        {
            if (parentID == null) return;
            frm.OrgCode = btGdsList.EditValue.ToString();
            newobj.orgCode = btGdsList.EditValue.ToString();
            //newobj.tqID = ParentObj.OrgID;
            //newobj.OrgName = parentObj.OrgName;
            //newobj.CreateDate = DateTime.Now;
            //newobj.CreateMan = MainHelper.LoginName;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                //where left(tqCode,{1})='{0}' ", lineCode,lineCode.Length
                parentID = value;
                //if (!string.IsNullOrEmpty(value))
                //{
                //    RefreshData(" where tqID in (select tqID  from PS_tq where LEFT(tqCODE,'"+value.Length+"')= '" + value + "')  ");
                //}
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (gridView1.FocusedRowHandle != -1)
            {
                mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(btGdsList.EditValue.ToString());  
                Export13.ExportExcel2(gridControl1.DataSource as IList<PS_tqdlbh>, org.OrgName);
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
            if (RecordWorkTask.DeleteModleRelationRecord(currRecord, WorkFlowData, ref strmess))
            {
                MsgBox.ShowTipMessageBox("清除成功");
            }
            else
            {
                MsgBox.ShowTipMessageBox("清除失败: " + strmess);
            }

        }

        private void TaskOverButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {
                IList <PS_tqdlbh> li=gridView1.DataSource as IList <PS_tqdlbh> ;
              
                 string   filter =  " and (id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                        + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "')) "
                        ;
                 IList<PJ_13dlbhjl> dllist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_13dlbhjl>
                    ("SelectPJ_13dlbhjlList", " where  1=1 " + filter);
                if (li.Count > 0)
                {
                    if (li.Count < 2)
                    {
                        if (dllist.Count < 1)
                        {
                            RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { li[0], currRecord });
                        }
                        else
                            if (dllist.Count < 2)
                            {
                                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { li[0], dllist[0], currRecord });
                            }
                            else
                            {

                                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { li[0], dllist[0], dllist[1], currRecord });
                            }

                    }
                    else
                    {
                        if (dllist.Count < 1)
                        {
                            RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { li[0], li[1], currRecord });
                        }
                        else
                            if (dllist.Count < 2)
                            {
                                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { li[0], li[1], dllist[0], currRecord });
                            }
                            else
                            {

                                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { li[0], dllist[0], dllist[1], currRecord });
                            }
                    }
                }
                else
                {
                    RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });
                }

            }
            string strmes = "";

            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] {  currRecord });

            }
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
            currRecord.LastChangeTime = DateTime.Now.ToString();
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }

        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }
    }
}
