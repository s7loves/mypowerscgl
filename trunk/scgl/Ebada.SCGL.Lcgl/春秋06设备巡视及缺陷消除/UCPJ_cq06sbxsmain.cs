﻿/**********************************************
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
using System.Reflection;
using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Threading;
using Ebada.Scgl.WFlow;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_cq06sbxsmain : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_06sbxs> gridViewOperation;

        public event SendDataEventHandler<PJ_06sbxs> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private IList<PJ_06sbxs> dalist = null;

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private frmModleFjly fjly = null;
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_06sbxs,PJ_06sbxsmx,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btEdit.Enabled = !value;
                btDelete.Enabled = !value;

            }
        }

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
                    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                    {
                        if (fjly == null) fjly = new frmModleFjly();
                        barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    }
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
        public UCPJ_cq06sbxsmain()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_06sbxs>(gridControl1, gridView1, barManager1,new frmcq06sbxsEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_06sbxs>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_06sbxs>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_06sbxs>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_06sbxs>(gridViewOperation_AfterEdit);
        }
        void gridViewOperation_AfterEdit(PJ_06sbxs newobj)
        {
            PJ_qxfl qxfj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(newobj.ID);
            if (qxfj != null && newobj.qxlb != "")
            {
                qxfj.LineID = newobj.LineID;
                qxfj.LineName = newobj.LineName;
                qxfj.qxlb = newobj.qxlb;
                qxfj.qxnr = newobj.qxnr;
                qxfj.xcqx = newobj.xcqx;
                qxfj.xcr = newobj.xcr;
                qxfj.xlqd = newobj.xlqd;
                qxfj.xsr = newobj.xsr;
                qxfj.xssj = newobj.xssj;
                MainHelper.PlatformSqlMap.Update<PJ_qxfl>(qxfj);
            }
            else if (qxfj != null)
            {
                MainHelper.PlatformSqlMap.Delete<PJ_qxfl>(qxfj);
            }
        }
        void gridViewOperation_AfterAdd(PJ_06sbxs newobj)
        {
            WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
            if (isWorkflowCall)
            {

                mrwt.ModleRecordID = newobj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = newobj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                //currRecord.DocContent = newobj.BigData;
                //MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);

            }
            if (newobj.qxlb != "")
            {
                PJ_qxfl qxfj = new PJ_qxfl();
                qxfj.ID = newobj.ID;
                qxfj.CreateDate = newobj.CreateDate;
                qxfj.CreateMan = newobj.CreateMan;
                qxfj.LineID = newobj.LineID;
                qxfj.LineName = newobj.LineName;
                qxfj.OrgCode = newobj.OrgCode;
                qxfj.OrgName = newobj.OrgName;
                qxfj.qxlb = newobj.qxlb;
                qxfj.qxly = "设备巡视";
                qxfj.qxnr = newobj.qxnr;
                qxfj.xcqx = newobj.xcqx;
                qxfj.xcr = newobj.xcr;
                qxfj.xlqd = newobj.xlqd;
                qxfj.xsr = newobj.xsr;
                qxfj.xssj = newobj.xssj;
                MainHelper.PlatformSqlMap.Create<PJ_qxfl>(qxfj);




                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ID = mrwt.CreateID();
                mrwt.ModleRecordID = qxfj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = qxfj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_06sbxs> e)
        {
            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + e.Value.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_06sbxs> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

          

        }
        public void initcomment()
        {
           // InitColumns();//初始列
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_06sbxs);
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
            hideColumn("LineID");
            hideColumn("gzrjID");
            //hideColumn("xcqx");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_06sbxs> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_06sbxs newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.xssj = DateTime.Now;
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frm06sbxsLine frm = new frm06sbxsLine();
            //frm.orgcode = btGdsList.EditValue.ToString();
            //if (frm.ShowDialog()==DialogResult.OK)
            //{

            //    IList<PJ_06sbxs> pj06list = new List<PJ_06sbxs>();
            //    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxs>(" where LineName='" + frm.linename + "'");
            //    if (pj06list.Count>0)
            //    {
            //        Export06.ExportExcel(pj06list);
            //    }
            //   else
            //    {
            //        MsgBox.ShowTipMessageBox("此线路没有添加巡视情况。");
            //        return;
            //    }
            //}
            if (gridView1.FocusedRowHandle >= 0)
            {
                bool xsmxflag = false; //是否有巡视的子表
                frmExportYearSelect frm = new frmExportYearSelect();
                DataTable dt = new DataTable();
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(bool));
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    DataRow[] dtc = frm.DT1.Select("B=1");
                    foreach (DataRow dr1 in dtc)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dr1[0].ToString();
                        dr[1] = Convert.ToInt32(dr1[1]);
                        dt.Rows.Add(dr);
                    }
                    dtc = frm.DT1.Select("D=1");
                    foreach (DataRow dr1 in dtc)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dr1[2].ToString();
                        dr[1] = Convert.ToInt32(dr1[3]);
                        dt.Rows.Add(dr);
                    }
                    dtc = frm.DT1.Select("F=1");
                    foreach (DataRow dr1 in dtc)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dr1[4].ToString();
                        dr[1] = Convert.ToInt32(dr1[5]);
                        dt.Rows.Add(dr);
                    }


                    Dictionary<string, List<PJ_06sbxs>> diclist = new Dictionary<string, List<PJ_06sbxs>>();
                    PJ_06sbxs _pj = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_06sbxs;
                    //添加明细表的信息
                    IList<PJ_06sbxsmx> ilist = null;
                    if (dt.Rows .Count== 0)
                    {
                       ilist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxsmx>(" where ParentID='" + _pj.ID + "' order by CreateDate desc");
                    }
                    else
                    {
                        string sely = "(";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i < dt.Rows.Count - 1)
                            {
                                sely += "'" + dt.Rows[i][0].ToString() + "',";
                            }
                            else
                                sely += "'" + dt.Rows[i][0].ToString() + "')";

                        }
                        ilist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxsmx>(" where ParentID='" + _pj.ID + "'and year(xssj) in"+sely+ "order by CreateDate desc");
                    }
                    if (ilist.Count == 0)
                    {
                        xsmxflag = false;
                        List<PJ_06sbxs> lispj = new List<PJ_06sbxs>();
                        lispj.Add(_pj);
                        diclist[_pj.LineID] = lispj;
                    }
                    else
                    {
                        xsmxflag = true;
                        List<PJ_06sbxs> lispj = new List<PJ_06sbxs>();
                        diclist[_pj.LineID] = lispj;
                        foreach (PJ_06sbxsmx pmx in ilist)
                        {
                            PJ_06sbxs newpj = new PJ_06sbxs();
                            Type obj = newpj.GetType();
                            foreach (PropertyInfo p in obj.GetProperties())
                            {
                                try
                                {
                                    p.SetValue(newpj, pmx.GetType().GetProperty(p.Name).GetValue(pmx, null), null);
                                }
                                catch (Exception ex) { }
                            }
                            diclist[_pj.LineID].Add(newpj);
                        }
                        // lispj.Add(_pj);

                    }
                    foreach (KeyValuePair<string, List<PJ_06sbxs>> pp in diclist)
                    {
                        List<PJ_06sbxs> objlist = pp.Value;
                        if (objlist.Count > 0)
                        {
                            Export06.ExportExcel(objlist,xsmxflag);
                        }

                    }
                }
          
                }
               

            //for (int i = 0; i < gridView1.RowCount;i++ )
            //{
            //    PJ_06sbxs _pj = gridView1.GetRow(i) as PJ_06sbxs;
              
            //    if (diclist.ContainsKey(_pj.LineID))
            //    {
            //        diclist[_pj.LineID].Add(_pj);
            //    }
            //    else
            //    {
            //        List<PJ_06sbxs> lispj = new List<PJ_06sbxs>();
            //        lispj.Add(_pj);
            //        diclist[_pj.LineID] = lispj;
            //    }
            //    //添加明细表的信息
            //    IList<PJ_06sbxsmx> ilist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxsmx>(" where ParentID='" + _pj.ID + "' order by CreateDate desc");
            //    foreach (PJ_06sbxsmx pmx in ilist)
            //    {
            //        PJ_06sbxs newpj = new PJ_06sbxs();
            //        Type obj = newpj.GetType();
            //        foreach (PropertyInfo p in obj.GetProperties())
            //        {
            //            try
            //            {
            //                p.SetValue(newpj, p.GetValue(pmx, null), null);
            //            }
            //            catch { }
            //        }
            //        diclist[_pj.LineID].Add(newpj);
            //    }
            //}
            //foreach (KeyValuePair<string, List<PJ_06sbxs>> pp in diclist)
            //{
            //    List<PJ_06sbxs> objlist = pp.Value;
            //    if (objlist.Count > 0)
            //    {
            //        Export06.ExportExcel(objlist);
            //    }

            //}
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (parentID == null) return;
            frmXSQD pd = new frmXSQD();
            pd.parentobj = ParentObj;
            if (gridView1.FocusedRowHandle >= 0)
            {
                pd.xsobj = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_06sbxs;
            }
            
            pd.ShowDialog();

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


        private void barFJLY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
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
        private void barxqjh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，生成消缺计划并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string slqwhere = "where OrgCode='" + parentID + "' ";
            slqwhere = slqwhere + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                   + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')"
             + " and DATEDIFF(day,cast('1900-1-1'  as datetime ) ,cast(xcrq  as datetime) )<1 ";
            slqwhere += " order by id desc";
            dalist = MainHelper.PlatformSqlMap.GetListByWhere<PJ_06sbxs>(slqwhere);
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
            if (fjly == null) fjly = new frmModleFjly();
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

            DataTable dt = RecordWorkTask.GetRecordWorkFlowData(currRecord.ID, MainHelper.User.UserID);
            slqwhere = "where OrgCode='" + parentID + "' ";
            slqwhere = slqwhere + " and (id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where 1=1 ";
            slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"

               + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "') "
               + " or (id  in (select ModleRecordID from WF_ModleRecordWorkTaskIns where 1=1 ";
            slqwhere = slqwhere + " and  RecordID='" + currRecord.ID + "'"
              + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "' "
              + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "' "
               + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "')) "
              + ")"
              ;

            slqwhere += " order by id desc";
            dalist = MainHelper.PlatformSqlMap.GetListByWhere<PJ_06sbxs>(slqwhere);
            foreach (PJ_06sbxs sbxs in dalist)
            {
                if (sbxs.qxlb == "") continue;
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                PJ_qxfl qxfj = new PJ_qxfl();
                if (WorkFlowData.Rows[0]["flowcaption"].ToString() == "春查消缺外查")
                {
                    PJ_ccxqjh ccxqjh = new PJ_ccxqjh();
                    ccxqjh.ID = sbxs.ID;
                    ccxqjh.OrgCode = sbxs.OrgCode;
                    ccxqjh.OrgName = sbxs.OrgName;
                    ccxqjh.qxlb = sbxs.qxlb;
                    ccxqjh.xqlr = sbxs.qxnr;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    try
                    {
                        MainHelper.PlatformSqlMap.Create<PJ_ccxqjh>(ccxqjh);
                    }
                    catch { }
                    qxfj.ID = ccxqjh.ID;

                    mrwt.ID = mrwt.CreateID();
                    mrwt.ModleRecordID = ccxqjh.ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                    mrwt.ModleTableName = ccxqjh.GetType().ToString();
                    mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.CreatTime = DateTime.Now;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                }
                else
                    if (WorkFlowData.Rows[0]["flowcaption"].ToString() == "秋查消缺外查")
                    {

                        PJ_qcxqjh qcxqjh = new PJ_qcxqjh();
                        qcxqjh.ID = sbxs.ID;
                        qcxqjh.OrgCode = sbxs.OrgCode;
                        qcxqjh.OrgName = sbxs.OrgName;
                        qcxqjh.qxlb = sbxs.qxlb;
                        qcxqjh.xqlr = sbxs.qxnr;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        try
                        {
                            MainHelper.PlatformSqlMap.Create<PJ_qcxqjh>(qcxqjh);
                        }
                        catch { }
                        qxfj.ID = qcxqjh.ID;


                        mrwt.ID = mrwt.CreateID();
                        mrwt.ModleRecordID = qcxqjh.ID;
                        mrwt.RecordID = currRecord.ID;
                        mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                        mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                        mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                        mrwt.ModleTableName = qcxqjh.GetType().ToString();
                        mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                        mrwt.CreatTime = DateTime.Now;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    }

                qxfj.CreateDate = sbxs.CreateDate;
                qxfj.CreateMan = sbxs.CreateMan;
                qxfj.LineID = sbxs.LineID;
                qxfj.LineName = sbxs.LineName;
                qxfj.OrgCode = sbxs.OrgCode;
                qxfj.OrgName = sbxs.OrgName;
                qxfj.qxlb = sbxs.qxlb;
                qxfj.qxly = "设备巡视";
                qxfj.qxnr = sbxs.qxnr;
                qxfj.xcqx = sbxs.xcqx;
                qxfj.xcr = sbxs.xcr;
                qxfj.xlqd = sbxs.xlqd;
                qxfj.xsr = sbxs.xsr;
                qxfj.xssj = sbxs.xssj;
                try
                {
                    MainHelper.PlatformSqlMap.Create<PJ_qxfl>(qxfj);
                }
                catch { }



                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                //Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                //mrwt = new WF_ModleRecordWorkTaskIns();
                //mrwt.ID = mrwt.CreateID();
                //mrwt.ModleRecordID = qxfj.ID;
                //mrwt.RecordID = currRecord.ID;
                //mrwt.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                //mrwt.WorkFlowInsId = dt.Rows[0]["WorkFlowInsId"].ToString();
                //mrwt.WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                //mrwt.ModleTableName = qxfj.GetType().ToString();
                //mrwt.WorkTaskInsId = dt.Rows[0]["WorkTaskInsId"].ToString();
                //mrwt.CreatTime = DateTime.Now;
                //Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                //MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);

                mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ID = mrwt.CreateID();
                mrwt.ModleRecordID = sbxs.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = sbxs.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }
            gridControl1.FindForm().Close();
        }
    }
}

