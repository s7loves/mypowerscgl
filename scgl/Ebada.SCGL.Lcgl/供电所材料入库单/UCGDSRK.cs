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
    public partial class UCGDSRK : DevExpress.XtraEditors.XtraUserControl
    {
        #region 
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
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_gdscrk>(gridViewOperation_BeforeEdit);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_gdscrk>(gridViewOperation_BeforeUpdate);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_gdscrk>(gridViewOperation_AfterEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            if (isWorkflowCall && fjly == null)
            {
                fjly = new frmModleFjly();
            }
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_gdscrk> e)
        {

        }
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_gdscrk> e)
        {

        }

        void gridViewOperation_AfterEdit(PJ_gdscrk obj)
        {

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
            }
            RefreshData();
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
        }
        #endregion

        #region 删除之前
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_gdscrk> e)
        {

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
            hideColumn("kcsl");
            hideColumn("ckdate");
            gridView1.Columns["num"].Width = 150;
            gridView1.Columns["OrgCode"].ColumnEdit = DicTypeHelper.GdsDic;
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
                    //RefreshData();
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
            if (barGDS.EditValue == null || barGDS.EditValue.ToString().Trim() == "")
            {
                return;
            }
            newobj.OrgCode = barGDS.EditValue.ToString();
        }

        #region 提交审核
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
            fys.strType = " and (type = '设置库存' or type = '原始入库材料') ";
            fys.StrSQL = "select distinct ssgc  from PJ_gdscrk where  (type = '设置库存' or type = '原始入库材料') ";
            if (fys.ShowDialog() == DialogResult.OK)
            {
                //ExportGDSRKEdit export = new ExportGDSRKEdit();
                //export.CurrRecord = currRecord;
                //export.IsWorkflowCall = isWorkflowCall;
                //export.ParentTemple = parentTemple;
                //export.RecordWorkFlowData = WorkFlowData;

                //export.ExportExcelSubmit(ref parentTemple, "", fys.strProject, fys.strFenproject, false);

                //fm.ParentTemple = parentTemple;
                //if (fm.ShowDialog() == DialogResult.OK)
                //{
                //    if (fjly == null) fjly = new frmModleFjly();
                //    fjly.btn_Submit_Click(sender, e);
                //    if (MainHelper.UserOrg.OrgName.IndexOf("局") == -1)
                //        export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns("", fys.strProject, fys.strFenproject);
                //    else
                //        export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns("", fys.strProject, fys.strFenproject);
                //    gridControl1.FindForm().Close();
                //}
            }
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

        #region 拷贝计划 (无内容)
        private void barCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////请求确认
            //if (MsgBox.ShowAskMessageBox("是否确认复制去年计划生成今年计划 ?") != DialogResult.OK)
            //{
            //    return;
            //}
            //IList<PJ_gdscrk> bjlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>("where orgcode='" + btGdsList.EditValue + "' AND jhnf='"+DateTime.Now.Year+"'");
            //List<PJ_gdscrk> list = new List<PJ_gdscrk>();
            //foreach (PJ_gdscrk bj in bjlist)
            //{
            //    bj.ID = bj.CreateID();
            //    bj.jhnf = (DateTime.Now.Year+1).ToString();
            //    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            //    list.Add(bj);
            //} 
            //List<SqlQueryObject> list3 = new List<SqlQueryObject>();
            //if (list.Count > 0)
            //{
            //    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Insert, list.ToArray());
            //    list3.Add(obj3);
            //}

            //MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            //RefreshData(" where OrgCode='" + parentID + "' ");
        }
        #endregion

        #region 导出数据 1
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGDSSelect fys = new frmGDSSelect();
            if (fys.ShowDialog() == DialogResult.OK)
            {
                ExportGDSRKEdit etdjh = new ExportGDSRKEdit();
                etdjh.ExportGDSRKDExcel(fys.OrgCode,fys.JingBanRen);
            }
        }
        #endregion

        #region 导出数据2
        private void barExplorYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGDSSelect fys = new frmGDSSelect();
            if (fys.ShowDialog() == DialogResult.OK)
            {
                ExportGDSRKEdit etdjh = new ExportGDSRKEdit();
                etdjh.ExportGDSRKDExcel(fys.OrgCode, fys.JingBanRen);
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

            comWpmc.Items.Clear();
            barWpmc.EditValue = null;
            if (barGDS.EditValue == null) return;
            IList listgds = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "'");
            if (listgds != null && listgds.Count > 0)
            {
                comWpmc.Items.AddRange(listgds);
            }
            if (barGDS.EditValue != null)
            {
                RefreshData();
            }
        }
        #endregion

        #region 物品名称更改
        private void comWpmc_EditValueChanged(object sender, EventArgs e)
        {
            comWpgg.Items.Clear();
            barWpgg.EditValue = null;

            if (barWpmc.EditValue == null) return;
            IList list = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg from PJ_gdscrk where OrgCode='" + barGDS.EditValue + "' and wpmc='" + barWpmc.EditValue + "' ");
            if (list != null && list.Count > 0)
            {
                comWpgg.Items.AddRange(list);
            }
            RefreshData();
        }
        #endregion

        #region 物品规格更改后、清空物品单位、重新绑定数据
        private void comWpgg_EditValueChanged(object sender, EventArgs e)
        {
            comWpdw.Items.Clear();
            barWpdw.EditValue = null;

            if (barWpdw.EditValue == null) return;
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
            if (barWpgg.EditValue != null)
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

            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                barGDS.EditValue = MainHelper.UserOrg.OrgCode;
                barGDS.Edit.ReadOnly = true;
            }
            else
            {
                barGDS.Edit = DicTypeHelper.GdsDic;
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
            if (barGDS.EditValue == null) return;
            string sql = " where OrgCode='" + barGDS.EditValue + "'";
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
            if (ckYanShiCaiLiao.EditValue != null && ckYanShiCaiLiao.EditValue.ToString() == "True")
            {
                sql += " and type='原始入库材料'";
            }
            else
            {
                sql += " and type='入库' or type='原始入库材料'";
            }
            sql += " order by ID desc";
            gridViewOperation.RefreshData(sql);
        }
        #endregion

        #region 添加之前、初始化数据
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_gdscrk> e)
        {
            if (barGDS.EditValue == null)
            {
                return;
            }
            e.Value.type = "原始入库材料";
            IList<PJ_gdscrk> pnumli = Client.ClientHelper.PlatformSqlMap.GetListByWhere
                   <PJ_gdscrk>(" where id like '" + DateTime.Now.ToString("yyyyMMdd") + "%' and type='" + e.Value.type + "' or type='设置库存' order by id desc ");
            if (pnumli.Count == 0)
                e.Value.num = "GDSCRK" + DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", 1);
            else
            {
                e.Value.num = "GDSCRK" + (Convert.ToDecimal(pnumli[0].num.Replace("GDSCRK", "")) + 1);
            }
            e.Value.lasttime = DateTime.Now;
        }
        #endregion

        #region 设置库存
        private void btAddKuCun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PJ_gdscrk pj = gridView1.GetFocusedRow() as PJ_gdscrk;
            frmGDSRKEdit edit = new frmGDSRKEdit();
            edit.SetKC = true;
            if (pj != null)
            {
                edit.RowData = pj;
            }
            edit.ShowDialog();
        }
        #endregion
    }
}
