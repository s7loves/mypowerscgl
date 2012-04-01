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
using Ebada.Scgl.WFlow;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_18gysbpj : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_18gysbpj> gridViewOperation;

        public event SendDataEventHandler<PJ_18gysbpj> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_18gysbpj,LP_Record";
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
                        if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                        {
                            if (fjly == null) fjly = new frmModleFjly();
                            barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                        }
                        if (wt.CommandName == "01")
                        {
                            liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            if (wt.Description != "")
                                SubmitButton.Caption = wt.Description;
                            liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
      
        public UCPJ_18gysbpj()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_18gysbpj>(gridControl1, gridView1, barManager1,new frm18gysbpjEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_18gysbpj>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_18gysbpj>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_18gysbpj>(gridViewOperation_AfterAdd);
        }

        void gridViewOperation_AfterAdd(PJ_18gysbpj obj)
        {
            IList<PS_xl> listxl = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + btGdsList.EditValue + "'and ParentID = ''");
            int bh = 0;
            foreach (PS_xl pl in listxl)
            {
                bh++;
                //线路
                PJ_18gysbpjmx pjmx = new PJ_18gysbpjmx();
                pjmx.PJ_ID = obj.PJ_ID;
                pjmx.xh = bh;
                pjmx.sbdy = pl.LineName;
                pjmx.CreateDate = DateTime.Now;
                Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
                pjmx.CreateMan = m_UserBase.RealName;
                int line1 = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "SELECT SUM(WireLength) FROM PS_xl WHERE SUBSTRING(LineID, 1, 6) = '" + pl.LineCode + "'AND (lineKind = '一类')"));
                int line2 = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "SELECT SUM(WireLength) FROM PS_xl WHERE SUBSTRING(LineID, 1, 6) = '" + pl.LineCode + "'AND (lineKind = '二类')"));
                int line3 = Convert.ToInt32(Client.ClientHelper.PlatformSqlMap.GetObject("SelectOneInt", "SELECT SUM(WireLength) FROM PS_xl WHERE SUBSTRING(LineID, 1, 6) = '" + pl.LineCode + "'AND (lineKind = '三类')"));
                pjmx.one = line1;
                pjmx.two = line2;
                pjmx.three = line3;
                if ((line1 + line2 + line3) != 0)
                {
                    pjmx.whl = Convert.ToDecimal((line1 + line2) / (line1 + line2 + line3));
                }

                Client.ClientHelper.PlatformSqlMap.Create<PJ_18gysbpjmx>(pjmx);
                //台区
                IList<PS_tq> listtq = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>("where SUBSTRING(xlCode, 1, 6) ='" + pl.LineCode + "'");

                foreach (PS_tq pq in listtq)
                {

                    bh++;
                    pjmx = new PJ_18gysbpjmx();
                    pjmx.ID += bh;
                    pjmx.xh = bh;
                    pjmx.PJ_ID = obj.PJ_ID;
                    pjmx.sbdy = pq.tqName;
                    pjmx.CreateDate = DateTime.Now;
                    pjmx.CreateMan = m_UserBase.RealName;
                    switch (pq.btKind)
                    {
                        case "一类":
                            pjmx.one = 1;
                            pjmx.whl = 1;
                            break;
                        case "二类":
                            pjmx.two = 2;
                            pjmx.whl = 1;
                            break;
                        case "三类":
                            pjmx.three = 1;
                            pjmx.whl = 0;
                            break;

                    }
                    Client.ClientHelper.PlatformSqlMap.Create<PJ_18gysbpjmx>(pjmx);
                }
                //开关
                IList<PS_kg> listkg = Client.ClientHelper.PlatformSqlMap.GetList<PS_kg>("WHERE (gtID IN(SELECT gtID FROM PS_gt WHERE (SUBSTRING(LineCode, 1, 6) = '" + pl.LineCode + "')))");
                foreach (PS_kg pq in listkg)
                {
                    bh++;
                    pjmx = new PJ_18gysbpjmx();
                    pjmx.ID += bh;
                    pjmx.xh = bh;
                    pjmx.PJ_ID = obj.PJ_ID;
                    pjmx.sbdy = pq.kgName;
                    pjmx.CreateDate = DateTime.Now;
                    pjmx.CreateMan = m_UserBase.RealName;
                    switch (pq.kgkind)
                    {
                        case "一类":
                            pjmx.one = 1;
                            pjmx.whl = 1;
                            break;
                        case "二类":
                            pjmx.two = 2;
                            pjmx.whl = 1;
                            break;
                        case "三类":
                            pjmx.three = 1;
                            pjmx.whl = 0;
                            break;

                    }
                    Client.ClientHelper.PlatformSqlMap.Create<PJ_18gysbpjmx>(pjmx);
                }
                //变压器
                IList<PS_tqbyq> listbyq = Client.ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>("WHERE (tqID IN(SELECT tqID FROM PS_tq WHERE (SUBSTRING(tqcode, 1, 6) = '" + pl.LineCode + "')))");
                foreach (PS_tqbyq pq in listbyq)
                {
                    bh++;
                    pjmx = new PJ_18gysbpjmx();
                    pjmx.ID += bh;
                    pjmx.xh = bh;
                    pjmx.PJ_ID = obj.PJ_ID;
                    pjmx.sbdy = pq.byqName;
                    pjmx.CreateDate = DateTime.Now;
                    pjmx.CreateMan = m_UserBase.RealName;
                    switch (pq.byqkind)
                    {
                        case "一类":
                            pjmx.one = 1;
                            pjmx.whl = 1;
                            break;
                        case "二类":
                            pjmx.two = 2;
                            pjmx.whl = 1;
                            break;
                        case "三类":
                            pjmx.three = 1;
                            pjmx.whl = 0;
                            break;

                    }
                    Client.ClientHelper.PlatformSqlMap.Create<PJ_18gysbpjmx>(pjmx);
                }
            }
            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = obj.PJ_ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = obj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            }
            RefreshData(" where OrgCode='" + parentID + "'");
          
        }
      
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_18gysbpj> e)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + e.Value.PJ_ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_18gysbpj> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
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
                ParentObj = org;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_18gysbpj);
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
            hideColumn("gzrjID");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            if (isWorkflowCall)
            {
                if (slqwhere == "") slqwhere = " where 1=1";
                slqwhere = slqwhere + " and PJ_ID  in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
                slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                   + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            }
            slqwhere = slqwhere + " order by PJ_ID desc";
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_18gysbpj> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_18gysbpj newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            
            
           
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
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where OrgCode='" + value + "'");
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                Export18.ExportExcel(gridView1.GetFocusedRow() as PJ_18gysbpj);
            }
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
            fjly.btn_Submit_Click(sender, e);
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



        private void barFJLY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }
    }
}
