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
    [ToolboxItem(false)]
    public partial class UCPJ_23 : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_23> gridViewOperation;

        public event SendDataEventHandler<PJ_23> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_23,LP_Record";
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

        public UCPJ_23()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_23>(gridControl1, gridView1, barManager1, new frm23Edit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_23>(gridViewOperation_BeforeAdd);
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_23>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_23>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_23>(gridViewOperation_BeforeDelete);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_23>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_23> e)
        {
            if (e.Value.BigData == null)
            {
                e.Value.BigData = new byte[0];
            }

        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_23> e)
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
        private void initbh(PJ_23 obj)
        {
            if (!string.IsNullOrEmpty(obj.xybh)) return;
            string ret = string.Empty;
            string year = DateTime.Now.Year.ToString();
            string gds = parentObj.OrgName.Replace("供电所", "");
            string strname = SelectorHelper.GetPysm(gds, true) + year + "";
            strname = strname.ToUpper();
            string strmax = MainHelper.PlatformSqlMap.GetObject("SelectOneStr", "select max(xybh) from pj_23 where xybh like '" + strname + "%'") as string;
            if (string.IsNullOrEmpty(strmax))
            {
                ret = strname + "001";
            }
            else
            {
                int count = int.Parse(strmax.Substring(strmax.Length - 3, 3)) + 1;

                ret = strname + count.ToString("000");
            }
            obj.xybh = ret;
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_23> e)
        {
            if (parentID == null)
                e.Cancel = true;
            else
            {
                initbh(e.Value);
            }
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
        void gridViewOperation_AfterEdit(PJ_23 obj)
        {
            //修改模板

            mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(obj.ParentID);
            string fname = Application.StartupPath + "\\00记录模板\\23配电线路产权维护范围协议书.xls";
            string bhname = org.OrgName.Replace("供电所", "");
            DSOFramerControl dsoFramerControl1 = new DSOFramerControl();
            dsoFramerControl1.FileOpen(fname);
            Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            //PJ_23 obj1 = (PJ_23)MainHelper.PlatformSqlMap.GetObject("SelectPJ_23List", "where ParentID='" + obj.ParentID + "' and xybh like '" + SelectorHelper.GetPysm(org.OrgName.Replace("供电所", ""), true) + "-" + DateTime.Now.Year.ToString() + "-%' order by xybh ASC");
            //int icount = 1;
            //if (obj1 != null && obj1.xybh != "")
            //{
            //    //icount = Convert.ToInt32(obj.xybh.Split('-')[2]) + 1;
            //}
            string strname = obj.xybh;// SelectorHelper.GetPysm(bhname, true);
            ExcelAccess ea = new ExcelAccess();
            ea.MyWorkBook = wb;
            ea.MyExcel = wb.Application;
            ea.SetCellValue(strname.ToUpper(), 4, 8);
            //strname = DateTime.Now.Year.ToString();
            //ea.SetCellValue(strname, 4, 9);
            //strname = string.Format("{0:D3}", icount);
            //ea.SetCellValue(strname, 4, 10);
            ea.SetCellValue(obj.cqdw + "：", 6, 4);
            ea.SetCellValue(obj.linename, 10, 7);
            ea.SetCellValue(obj.fzlinename, 10, 10);
            ea.SetCellValue("'" + obj.gh, 10, 16);
            ea.SetCellValue(obj.cqfw, 11, 4);
            ea.SetCellValue(obj.cqdw, 13, 4);
            ea.SetCellValue(obj.qdrq.Year.ToString(), 21, 7);
            ea.SetCellValue(obj.qdrq.Month.ToString(), 21, 9);
            ea.SetCellValue(obj.qdrq.Day.ToString(), 21, 11);
            dsoFramerControl1.FileSave();
            obj.BigData = dsoFramerControl1.FileData;
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            MainHelper.PlatformSqlMap.Update<PJ_23>(obj);
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_23);
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
            hideColumn("ParentID");
            hideColumn("gzrjID");
            hideColumn("BigData");
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
            slqwhere = slqwhere + " order by CreateDate desc";
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_23> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_23 newobj)
        {
            if (parentID == null) return;
            newobj.ParentID = parentID;
            //newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;

        }
        void gridViewOperation_AfterAdd(PJ_23 newobj)
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
                currRecord.DocContent = newobj.BigData;
                MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            }
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
                    RefreshData(" where ParentID='" + value + "'");
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
            PJ_23 OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_23;
            //if (OBJECT.BigData != null)
            //{
            //    if (OBJECT.BigData.Length != 0)
            //    {
            //        DSOFramerControl ds1 = new DSOFramerControl();
            //        ds1.FileData = OBJECT.BigData;
            //        string fname = ds1.FileName;
            //        ds1.FileClose();
            //        // ds1.FileOpen(ds1.FileName);
            //        ExcelAccess ex = new ExcelAccess();


            //        ex.Open(fname);
            //        //此处写填充内容代码
            //        ex.ShowExcel();
            //    }
            //    else
            //    {
            //        Export23.ExportExcel(OBJECT);
            //    }

            //}
            //else
            //{
            //    Export23.ExportExcel(OBJECT);
            //}

            Export23.ExportExcel(OBJECT);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                frm23Template frm = new frm23Template();
                frm.pjobject = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_23;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Client.ClientHelper.PlatformSqlMap.Update<PJ_23>(frm.pjobject);
                    MessageBox.Show("保存成功");
                }
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
