using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.WFlow;
using Ebada.SCGL.WFlow.Tool;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Scgl.Core;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCGDSCKD : DevExpress.XtraEditors.XtraUserControl
    {
        public UCGDSCKD()
        {
            InitializeComponent();

            lkeGDS.Properties.DisplayMember = "OrgName";
            lkeGDS.Properties.ValueMember = "OrgCode";
            IList<mOrg> list = ClientHelper.PlatformSqlMap.GetList<mOrg>(" where OrgType='1'");
            lkeGDS.Properties.DataSource = list;
            lkeGDS.Properties.NullText = "";
            lkeGDS.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrgName", 100, "请选择供电所"));

            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {
                lkeGDS.EditValue = MainHelper.UserOrg.OrgCode;
                lkeGDS.Properties.ReadOnly = true;
            }
            else
            {
                lkeGDS.Properties.ReadOnly = false;
            }
        }

        #region
        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_clcrkd,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                //liuchbarSubItem.Enabled = !value;
                //btAdd.Enabled = !value;
                //btEdit.Enabled = !value;
                //btDelete.Enabled = !value;
                //btAddKuCun.Enabled = !value
                ucgdsck1.ReadOnly = value;
            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;

                ucgdsck1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {
                isWorkflowCall = value;
                ucgdsck1.IsWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucgdsck1.CurrRecord = value;
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
                ucgdsck1.RecordWorkFlowData = value;
                //if (isWorkflowCall)
                //{
                //    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                //    {
                //        ucgdsck1.barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                //        if (fjly == null) fjly = new frmModleFjly();
                //    }
                //    //ucgdsck1.liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                //    //ucgdsck1.liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                //    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                //    foreach (WF_WorkTaskCommands wt in wtlist)
                //    {
                //        if (wt.CommandName == "01")
                //        {
                //            //ucgdsck1.SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                //            //if (wt.Description != "") ucgdsck1.SubmitButton.Caption = wt.Description;
                //            //ucgdsck1.barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //        }
                //        else
                //            if (wt.CommandName == "02")
                //            {
                //                //ucgdsck1.TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                //                //if (wt.Description != "") ucgdsck1.TaskOverButton.Caption = wt.Description;
                //            }

                // }
                //}
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucgdsck1.VarDbTableName = value;
            }
        }
        #endregion

        #region 结束
        private void TaskOverButton_Click(object sender, EventArgs e)
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

        #region 附件留言
        private void barFJLY_Click(object sender, EventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }
        #endregion

        #region 自动出库
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lkeGDS.EditValue == null) return;

            frmGDSCKEdit frm = new frmGDSCKEdit();
            PJ_gdscrk wp = gridView1.GetFocusedRow() as PJ_gdscrk;

            if (wp == null || Convert.ToInt32(wp.kcsl) <= 0)
            {
                wp = new PJ_gdscrk();
            }
            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
            <PJ_gdscrk>(" where id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' order by wpmc desc ");
            if (pnumli.Count == 0)
                wp.num = "GDSCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                wp.num = "GDSCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("GDSCRK", "")) + 1);
            }
            wp.type = "出库";
            wp.OrgCode = lkeGDS.EditValue.ToString();
            frm.RowData = wp;
            frm.ShowDialog();
        }
        #endregion

        #region 供电所改变查找物品名称
        private void lkeGDS_EditValueChanged(object sender, EventArgs e)
        {
            comWpmc.EditValue = null;
            comWpmc.Properties.Items.Clear();
            if (lkeGDS.EditValue != null)
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select distinct wpmc from PJ_gdscrk where OrgCode='" + lkeGDS.EditValue + "'");
                if (list != null && list.Count > 0)
                {
                    comWpmc.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品名称改变查找物品规格
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.EditValue = null;
            comWpgg.Properties.Items.Clear();
            if (comWpmc.EditValue != null)
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select distinct wpgg from PJ_gdscrk where OrgCode='" + lkeGDS.EditValue + "' and wpmc='" + comWpmc.EditValue + "'");
                if (list != null && list.Count > 0)
                {
                    comWpgg.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 物品规格改变查找物品单位
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            comWpdw.EditValue = null;
            comWpdw.Properties.Items.Clear();
            if (comWpgg.EditValue != null)
            {
                IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select distinct wpdw from PJ_gdscrk where OrgCode='" + lkeGDS.EditValue + "' and wpmc='" + comWpmc.EditValue + "' and wpgg='" + comWpgg.EditValue + "'");
                if (list != null && list.Count > 0)
                {
                    comWpdw.Properties.Items.AddRange(list);
                }
            }
        }
        #endregion

        #region 查询
        private bool first = true;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql = " where OrgCode='" + lkeGDS.EditValue + "' and type='原始材料'";
            if (comWpmc.EditValue != null)
            {
                sql += " and wpmc='" + comWpmc.EditValue + "'";
                if (comWpgg.EditValue != null)
                {
                    sql += " and wpgg='" + comWpgg.EditValue + "'";
                    if (comWpdw.EditValue != null)
                    {
                        sql += " and wpdw='" + comWpdw.EditValue + "'";
                    }
                }
            }
            IList<PJ_gdscrk> list = ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>(sql);
            gridControl1.DataSource = list;
            if (first)
            {
                HideColumns();
            }
        }

        // 隐藏列
        private void HideColumns()
        {
            gridView1.Columns["num"].Visible = false;
            gridView1.Columns["indate"].Visible = false;
            gridView1.Columns["ckdate"].Visible = false;
            gridView1.Columns["cksl"].Visible = false;
            gridView1.Columns["OrgCode"].Visible = false;
            gridView1.Columns["type"].Visible = false;
            gridView1.Columns["yt"].Visible = false;
            gridView1.Columns["rkslcount"].Visible = false;
            gridView1.Columns["ckslcount"].Visible = false;
            gridView1.Columns["kcslcount"].Visible = false;
        }
        #endregion

    }
}
