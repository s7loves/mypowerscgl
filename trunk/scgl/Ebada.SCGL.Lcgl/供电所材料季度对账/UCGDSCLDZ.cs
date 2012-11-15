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
    [ToolboxItem(false)]
    public partial class UCGDSCLDZ : DevExpress.XtraEditors.XtraUserControl
    {
        #region


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
            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                //this.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {
                isWorkflowCall = value;
                //this.IsWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                //this.CurrRecord = value;
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
                //this.RecordWorkFlowData = value;

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
                //frm.VarDbTableName = value;
            }
        }

        private GridViewOperation<PJ_gdscrk> gridViewOperation;

        public UCGDSCLDZ()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_gdscrk>(gridControl1, gridView1, barManager1, null);
        }

        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
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

            hideColumn("wpsl");
            hideColumn("cksl");
            hideColumn("indate");
            hideColumn("kcsl");
            hideColumn("num");
            hideColumn("lasttime");
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

        #endregion

        #region 导出数据2
        private void barExplorYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barGDS.EditValue != null)
            {
                if (barEndTime.EditValue == null)
                {
                    MsgBox.ShowTipMessageBox("请选择季度");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    string time = " " + now.ToLongTimeString();
                    ExportGDSCRKDZ etdjh = new ExportGDSCRKDZ();
                    etdjh.ExportGDSRKDExcel(barGDS.EditValue.ToString(), barEndTime.EditValue.ToString().Substring(0, 10) + time);
                }
            }
        }
        #endregion

        #region 供电所改变、重新绑定数
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
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
            RefreshData();
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

        #region 是否为原始库存更改后、重新绑定数据
        private void ckYanShiCaiLiao_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion

        #region 窗体加载事件
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();
            if (this.Site != null) return;
            barGDS.Edit = DicTypeHelper.GdsDic;

            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
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
        public void RefreshData()
        {
            DateTime now = DateTime.Now;
            string time = " " + now.ToLongTimeString();
            if (barGDS.EditValue == null) return;
            string sql = "  as a where id = (select max(ID) from pj_gdscrk as b where b.wpmc=a.wpmc and b.wpgg=a.wpgg and b.wpdw=a.wpdw and b.OrgCode=a.OrgCode) and  OrgCode='" + barGDS.EditValue + "'";
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

            if (barEndTime.EditValue != null)
            {
                sql += " and (indate <= '" + barEndTime.EditValue + "' or ckdate<='" + barEndTime.EditValue.ToString().Substring(0, 10) + time + "')";
            }

            sql += " order by ID desc,wpmc";
            gridViewOperation.RefreshData(sql);
        }
        #endregion

        #region 入库截止日期改变
        private void barEndTime_EditValueChanged(object sender, EventArgs e)
        {
            if (barEndTime.EditValue != null)
            {
                if (Convert.ToDateTime(barEndTime.EditValue) > DateTime.Now)
                {
                    barEndTime.EditValue = DateTime.Now;
                }
            }
            RefreshData();
        }
        #endregion

        #region 提交审核
        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

        #region 重置查询条件
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetWpmc();
        }
        #endregion

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PJ_gdscrk crk = gridView1.GetFocusedRow() as PJ_gdscrk;
            if (crk != null)
            {
                ExportGDSCRKDZ etdjh = new ExportGDSCRKDZ();
                etdjh.ExportOne(crk);
            }
            else
            {
                MsgBox.ShowTipMessageBox("请先选中要导出的数据！");
            }
        }
    }
}
