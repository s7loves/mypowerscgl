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
    [ToolboxItem(false)]
    public partial class UCGDSRK : DevExpress.XtraEditors.XtraUserControl
    {
        #region

        private DateTime enterTime;

        private GridViewOperation<PJ_gdscrk> gridViewOperation;
        frmGDSRKEdit frm = new frmGDSRKEdit();

        public event SendDataEventHandler<PJ_gdscrk> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_gdscrk,LP_Record";

        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btDelete.Enabled = !value;
            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                frm.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {
                isWorkflowCall = value;
                frm.IsWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                frm.CurrRecord = value;
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
                frm.RecordWorkFlowData = value;

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
                frm.VarDbTableName = value;
            }
        }
        public UCGDSRK()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_gdscrk>(gridControl1, gridView1, barManager1, frm);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_gdscrk>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_gdscrk>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_gdscrk>(gridViewOperation_AfterDelete);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_gdscrk>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_gdscrk>(gridViewOperation_BeforeDelete);
            if (isWorkflowCall && fjly == null)
            {
                fjly = new frmModleFjly();
            }
        }

        #region 删除后删除流程
        void gridViewOperation_AfterDelete(PJ_gdscrk obj)
        {
            if (isWorkflowCall)
            {
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.ID + "' and RecordID='" + currRecord.ID + "'"
                      + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                      + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                      + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                      + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
                RefreshData();
            }
        }
        #endregion

        #region 添加之后
        void gridViewOperation_AfterAdd(PJ_gdscrk newobj)
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
            GetWpmc();

            //RefreshData();
            //gridControl1.RefreshDataSource();
            //gridView1.RefreshData();
        }
        #endregion

        #region 删除之前
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_gdscrk> e)
        {
            PJ_gdscrk crk = gridView1.GetFocusedRow() as PJ_gdscrk;
            if (crk == null)
            {
                MsgBox.ShowTipMessageBox("请先选中要删除的一条记录！");
            }
            else
            {
                var rkcount = ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select cast(count(*) as varchar(50)) from pj_gdscrk where ID >" + crk.ID + " and wpmc='" + crk.wpmc + "' and wpgg='" + crk.wpgg + "' and wpdw='" + crk.wpdw + "' and OrgCode='" + crk.OrgCode + "'");
                if (rkcount != null && Convert.ToInt32(rkcount) > 0)
                {
                    MsgBox.ShowWarningMessageBox("该记录不是最后一条,无法删除！");
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_gdscrk);
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
            hideColumn("type");
            hideColumn("yt");
            hideColumn("ckdate");
            hideColumn("OrgCode");
            hideColumn("cksl");
            hideColumn("num");
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_gdscrk> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
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
                    RefreshData();
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
        #endregion

        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_gdscrk newobj)
        {
            if (barGDS.EditValue == null) return;
            newobj.OrgCode = barGDS.EditValue.ToString();
        }

        #region 清除相关信息
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
        #endregion

        #region 导出数据 1
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmGDSSelect fys = new frmGDSSelect();
            //if (fys.ShowDialog() == DialogResult.OK)
            //{
            //    ExportGDSCKEdit etdjh = new ExportGDSCKEdit();
            //    etdjh.ExportGDSRKDExcel(fys.OrgCode, fys.JingBanRen);
            //}
        }
        #endregion

        #region 导出数据2
        private void barExplorYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGDSSelect fys = new frmGDSSelect();
            if (fys.ShowDialog() == DialogResult.OK)
            {
                ExportGDSRKEdit etdjh = new ExportGDSRKEdit();
                etdjh.ExportGDSRKDExcel(fys.OrgCode, fys.JingBanRen, enterTime);
            }
        }
        #endregion

        #region 附件留言
        private void barFJLY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }
        #endregion

        #region 任务结束
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
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }
        #endregion

        #region 供电所改变、重新绑定数
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + barGDS.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }

            GetWpmc();
        }

        private void GetWpmc()
        {
            comWpmc.Items.Clear();
            barWpmc.EditValue = null;
            if (barGDS.EditValue == null) return;
            IList listgds = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "'");
            if (listgds != null && listgds.Count > 0)
            {
                comWpmc.Items.AddRange(listgds);
            }
        }
        #endregion

        #region 物品名称更改
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.Items.Clear();
            barWpgg.EditValue = null;

            if (barGDS.EditValue != null)
            {
                RefreshData();
            }

            if (barWpmc.EditValue == null) return;
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "' and wpmc='" + barWpmc.EditValue + "' ");
            if (list != null && list.Count > 0)
            {
                comWpgg.Items.AddRange(list);
            }
        }
        #endregion

        #region 物品规格更改后、清空物品单位、重新绑定数据
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            comWpdw.Items.Clear();
            barWpdw.EditValue = null;

            if (barWpgg.EditValue == null) return;
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpdw from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "' and wpmc='" + barWpmc.EditValue + "' and wpgg='" + barWpgg.EditValue + "' ");
            if (list != null && list.Count > 0)
            {
                comWpdw.Items.AddRange(list);
            }
            RefreshData();
        }
        #endregion

        #region 物品单位更改、重新绑定数据
        private void barWpdw_EditValueChanged(object sender, EventArgs e)
        {
            if (barWpdw.EditValue != null)
            {
                RefreshData();
            }
        }
        #endregion

        #region 窗体加载事件
        private void UCGDSRK_Load(object sender, EventArgs e)
        {
            enterTime = DateTime.Now;
            InitColumns();
            if (this.Site != null) return;
            barGDS.Edit = DicTypeHelper.GdsDic;

            //如果是供电所人员，则锁定
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {
                barGDS.EditValue = MainHelper.UserOrg.OrgCode;
                barGDS.Edit.ReadOnly = true;
            }
            else
            {
                barGDS.Edit.ReadOnly = false;
            }
        }
        #endregion

        #region 刷新数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        string expotSQL = "";
        public void RefreshData()
        {
            if (barGDS.EditValue == null) return;
            string sql = " where OrgCode='" + barGDS.EditValue + "' and type!='出库'";
            if (barWpmc.EditValue != null)
            {
                sql += " and wpmc='" + barWpmc.EditValue + "'";
                if (barWpgg.EditValue != null)
                {
                    sql += " and wpgg='" + barWpgg.EditValue + "'";
                    if (barWpdw.EditValue != null)
                    {
                        sql += "and wpdw='" + barWpdw.EditValue + "'";
                    }
                }
            }

            string _sql = "";
            try
            {
                DateTime now = DateTime.Now;
                string time = " " + now.ToLongTimeString();
                if (barStarTime.EditValue != null && barEndTime.EditValue != null)
                {
                    if (Convert.ToDateTime(barStarTime.EditValue.ToString()) <= Convert.ToDateTime(barEndTime.EditValue.ToString()))
                    {
                        _sql += " and indate between '" + barStarTime.EditValue + "' and '" + barEndTime.EditValue.ToString().Substring(0, 10) + time + "'";
                    }
                    else
                    {
                        _sql += " and indate between '" + barEndTime.EditValue + "' and '" + barStarTime.EditValue.ToString().Substring(0, 10) + time + "'";
                    }
                }
                else if (barStarTime.EditValue != null && barEndTime.EditValue == null)
                {
                    _sql += " and indate >= '" + barStarTime.EditValue + "'";
                }
                else if (barStarTime.EditValue == null && barEndTime.EditValue != null)
                {
                    _sql += "and indate <= '" + barEndTime.EditValue + "'";
                }
            }
            catch
            {
                _sql = "";
            }
            sql += " " + _sql;

            sql += " order by wpmc,indate";
            gridViewOperation.RefreshData(sql);
            expotSQL = sql;
        }
        #endregion

        #region 添加之前、初始化数据
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_gdscrk> e)
        {
            if (barGDS.EditValue == null)
            {
                return;
            }
            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                   <PJ_gdscrk>(" where ID like '" + DateTime.Now.ToString("yyyyMMdd") + "%' order by id desc ");
            if (pnumli.Count == 0)
                e.Value.num = "GDSCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                e.Value.num = "GDSCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("GDSCRK", "")) + 1);
            }
        }
        #endregion

        #region 入库起始日期改变
        private void barStarTime_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion

        #region 入库截止日期改变
        private void barEndTime_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion

        # region 导出选中出库单
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PJ_gdscrk crk = gridView1.GetFocusedRow() as PJ_gdscrk;
            if (crk != null)
            {
                ExportGDSRKEdit etdjh = new ExportGDSRKEdit();
                etdjh.ExportOne(crk);
            }
            else
            {
                MsgBox.ShowTipMessageBox("请先选中要导出的数据！");
            }
        }
        #endregion

        #region 查询重置
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetWpmc();
        }
        #endregion

        #region 导出查询结果
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (expotSQL == "")
            {
                MsgBox.ShowTipMessageBox("请先填充上面的查询条件！");
            }
            else
            {
                frmGDSSelect fys = new frmGDSSelect();
                if (fys.ShowDialog() == DialogResult.OK)
                {
                    ExportGDSRKEdit etdjh = new ExportGDSRKEdit();
                    etdjh.ExportExcelForSQL(fys.OrgCode, fys.JingBanRen, expotSQL);
                }
            }
        }
        #endregion

    }
}
