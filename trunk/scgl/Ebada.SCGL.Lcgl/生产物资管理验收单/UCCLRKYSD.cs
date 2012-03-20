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
using Ebada.Components;
using System.Threading;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCCLRKYSD : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_clrkysd> gridViewOperation;

        public event SendDataEventHandler<PJ_clrkysd> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_clrkysd,LP_Record";
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
                    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                    {
                        barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                        if (fjly == null) fjly = new frmModleFjly();
                    }
                    liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        if (wt.CommandName == "01")
                        {
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            if (wt.Description != "") SubmitButton.Caption = wt.Description;
                            barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "") TaskOverButton.Caption = wt.Description;
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
        public UCCLRKYSD()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_clrkysd>(gridControl1, gridView1, barManager1, new frmCLRKYSEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_clrkysd>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_clrkysd>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_clrkysd>(gridViewOperation_AfterDelete);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_clrkysd>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_clrkysd>(gridViewOperation_BeforeEdit);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_clrkysd>(gridViewOperation_BeforeUpdate);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_clrkysd>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            if (isWorkflowCall && fjly==null)
            {
                fjly = new frmModleFjly();
            }
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_clrkysd> e)
        {
           

        }
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_clrkysd> e)
        {
            
        }
        void gridViewOperation_AfterEdit(PJ_clrkysd obj)
        {

            RefreshData(" where     1=1");
        }
        void gridViewOperation_AfterDelete(PJ_clrkysd obj)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }

           
            
        }
        void gridViewOperation_AfterAdd(PJ_clrkysd newobj)
        {
            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = newobj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = newobj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_clrkysd> e)
        {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_clrkysd> e)
        {
          
 
        }

        private void btAddKuCun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ("rabbit赵建明付岩张发冯富玲刘振远赵忠田".Contains(Ebada.Client.Platform.MainHelper.User.UserName))
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never ;
            }
            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            //btGdsList.Edit = DicTypeHelper.GdsDic3;
            //btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }
            iniProject();
            RefreshData(" where 1=1");
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_clrkysd);
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

           
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //if (isWorkflowCall)
            //{
            //    if (slqwhere == "") slqwhere = " where 1=1";
            //    slqwhere = slqwhere + " and id  in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by ID desc";
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_clrkysd> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_clrkysd newobj)
        {
            //if (parentID == null) return;
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            
           
          
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
                    RefreshData(" where  1=1 ");
                }
            }
        }

        void iniProject()
        {
            repositoryItemComboBox1.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssgc  from PJ_clrkysd where 1=1 ");
            repositoryItemComboBox1.Items.AddRange(mclist);
        }
        private void barEditGC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemComboBox2.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssxm  from PJ_clrkysd where  ssgc='" + barEditGC.EditValue + "'  and ssxm!='' ");
            repositoryItemComboBox2.Items.AddRange(mclist);

            repositoryItemComboBox3.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_clrkysd where  ssgc='" + barEditGC.EditValue + "'  and wpmc!='' ");
            repositoryItemComboBox3.Items.AddRange(mclist);

            repositoryItemComboBox4.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_clrkysd where  ssgc='" + barEditGC.EditValue + "'  and wpgg!='' ");
            repositoryItemComboBox4.Items.AddRange(mclist);
            barEditFGC.EditValue = ""; 
        }
        private void barEditFGC_EditValueChanged(object sender, EventArgs e)
        {



            inidate();
            repositoryItemComboBox3.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_clrkysd where  ssxm='" + barEditFGC.EditValue + "'  and wpmc!='' ");
            repositoryItemComboBox3.Items.AddRange(mclist);

            repositoryItemComboBox4.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_clrkysd where  ssxm='" + barEditFGC.EditValue + "'  and wpgg!='' ");
            repositoryItemComboBox4.Items.AddRange(mclist);

        }

        private void barEditGC_EditValueChanged(object sender, EventArgs e)
        {
            barEditGC_ItemClick(sender, null);

            inidate();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {

            repositoryItemComboBox4.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_clcrkd where  wpmc='" + barEditItem1.EditValue + "' and wpgg!='' ");
            repositoryItemComboBox4.Items.AddRange(mclist);
            inidate();
            
        }
        private void inidate()
        {
            string ssgc = " and 1=1 ", ssxm = " and 1=1 ", wpgg = " and 1=1 ", wpmc = " and 1=1 ";
            if (barEditGC.EditValue != null && barEditGC.EditValue.ToString() != "")
                ssgc = " and ssgc='" + barEditGC.EditValue + "' ";
            if (barEditFGC.EditValue!=null&&barEditFGC.EditValue.ToString() != "")
                ssxm = " and ssxm='" + barEditFGC.EditValue + "' ";
            if (barEditItem1.EditValue != null && barEditItem1.EditValue.ToString() != "")
                wpmc = " and wpmc='" + barEditItem1.EditValue + "' ";
            if (barEditItem2.EditValue != null && barEditItem2.EditValue.ToString() != "")
                wpgg = " and wpgg='" + barEditItem2.EditValue + "' ";
            RefreshData(" where  1=1" + ssgc + ssxm + wpmc + wpgg);
        }
        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {


            inidate();
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
            //IList<PJ_clrkysd> datalist = gridView1.DataSource as IList<PJ_clrkysd>;
            frmProjectSelect fys = new frmProjectSelect();
            fys.strType = " and 1=1";
            fys.StrSQL = "select distinct ssgc  from PJ_clrkysd where  1=1";
            if (fys.ShowDialog() == DialogResult.OK)
            {

                ExportCLRKYSEdit etdjh = new ExportCLRKYSEdit();
                etdjh.ExportExcelProjectCKD(parentID,fys.strProject,fys.strFenproject);
            }
           
           
           
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
            frmProjectSelect fys = new frmProjectSelect();
            fys.strType = " and 1=1";
            fys.StrSQL = "select distinct ssgc  from PJ_clrkysd where  1=1";
            if (fys.ShowDialog() == DialogResult.OK)
            {
                ExportCLRKYSEdit export = new ExportCLRKYSEdit();
                export.CurrRecord = currRecord;
                export.IsWorkflowCall = isWorkflowCall;
                export.ParentTemple = parentTemple;
                export.RecordWorkFlowData = WorkFlowData;

                export.ExportExcelSubmit(ref parentTemple, "", fys.strProject, fys.strFenproject , false);

                fm.ParentTemple = parentTemple;
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    if (fjly == null) fjly = new frmModleFjly();
                    fjly.btn_Submit_Click(sender, e);
                    if (MainHelper.UserOrg.OrgName.IndexOf("局") == -1)
                        export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns("", fys.strProject, fys.strFenproject);
                    else
                        export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns("", fys.strProject, fys.strFenproject);
                    gridControl1.FindForm().Close();
                }
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

        private void barCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             frmNumSelect fys = new frmNumSelect();
            fys.strType = " and 1=1";
            fys.StrSQL = "select distinct dhht  from PJ_clrkysd where  1=1 and dhht!=''";
            if (fys.ShowDialog() == DialogResult.OK)
            {
                string filter = " where 1=1";
                if(fys.strNum!="全部")
                    filter = " where dhht='" + fys.strNum + "'";
                IList<PJ_clrkysd> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clrkysd>(
                         filter
                           );
                IList<PJ_clcrkd> cdatalist = new List<PJ_clcrkd>();
                string num = "";
                IList<PJ_clcrkd> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                   <PJ_clcrkd>(" where  id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='工程材料入库单' order by id desc ");
                if (pnumli.Count == 0)
                    num = "SCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
                else
                {
                    num = "SCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("SCRK", "")) + 1);

                }
                PJ_clcrkd lc = null;
                foreach (PJ_clrkysd ysd in datalist)
                {
                    lc = MainHelper.PlatformSqlMap.GetOne<PJ_clcrkd>(" where lyparent='"+ysd.ID +"' and type = '工程材料入库单'");
                    if (lc == null)
                    {
                        PJ_clcrkd clc = new PJ_clcrkd();
                        clc.ID = clc.CreateID();
                        clc.ssgc = ysd.ssgc;
                        clc.ssxm = ysd.ssxm;
                        clc.type = "工程材料入库单";
                        clc.num = num;
                        clc.wpmc = ysd.wpmc;
                        clc.wpgg = ysd.wpgg;
                        clc.wpdw = ysd.wpdw;
                        clc.wpdj = ysd.wpdj;
                        clc.wpcj = ysd.ghdw;
                        clc.wpsl = ysd.wpsl;
                        clc.kcsl = ysd.wpsl;
                        clc.indate = ysd.indate;
                        clc.lyparent = ysd.ID;
                        cdatalist.Add(clc);

                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    }
                }
                frmCLRKYSShow fss = new frmCLRKYSShow();
                fss.DataList = cdatalist;
                if (fss.ShowDialog() == DialogResult.OK)
                {
                    foreach (PJ_clcrkd clc in cdatalist)
                    {
                        long i = 0;
                        System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneInt",
                            "select  sum(cast(kcsl as int) )  from PJ_clcrkd where (type = '工程材料入库单' or type = '工程材料入库单原始库存')"
                            + " and wpmc='" + clc.wpmc + "' " + " and ssgc='" + clc.ssgc + "' "
                            + " and wpgg='" + clc.wpgg + "' and id!='" + clc.ID + "' ");
                        if (mclist[0] != null) i = Convert.ToInt64(mclist[0].ToString());
                        clc.zkcsl = (Convert.ToInt64(clc.kcsl) + i).ToString();
                        Client.ClientHelper.PlatformSqlMap.Create<PJ_clcrkd>(clc);
                    }
                    MsgBox.ShowTipMessageBox("导入成功!");
                }
            }
        }

        private void barExplorYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProjectSelect fys = new frmProjectSelect();
            fys.strType = " and 1=1";
            fys.StrSQL = "select distinct ssgc  from PJ_clrkysd where  1=1";
            if (fys.ShowDialog() == DialogResult.OK)
            {
                ExportCLRKYSEdit etdjh = new ExportCLRKYSEdit();
                etdjh.ExportExcelProjectCKD("", fys.strProject, fys.strFenproject);
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

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

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
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清空所有数据，删除后不可恢复?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_clcrkd>(" where 1=1");
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_clrkysd>(" where 1=1");
            RefreshData("where  1=1" );
        }

       

    
    }
}
