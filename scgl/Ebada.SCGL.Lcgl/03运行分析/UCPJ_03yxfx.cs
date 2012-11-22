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
using System.Collections;
using Ebada.Core;
using DevExpress.XtraEditors.Repository;
using Ebada.Components;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_03yxfx : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_03yxfx> gridViewOperation;

        public event SendDataEventHandler<PJ_03yxfx> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private DataTable gridtable = null;
        private GridColumn picview;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_03yxfx,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                liuchbarSubItem.Enabled = !value;
                btReAdd.Enabled = !value;
                btReEdit.Enabled = !value;
                btReDelete.Enabled = !value;

            }
        }

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
            set
            {
                currRecord = value;
                RecordIkind = currRecord.Kind;
            }
        }


        private bool isJu()
        {
            bool result = false;
            IList<mUser> list = ClientHelper.PlatformSqlMap.GetList<mUser>(" where usercode in (select UserID from ruserrole where roleID in (select RoleID from mRole where RoleName in ('生产局长','生技部长','生技部生产专工','生技部配电专工','生技部计划专工') ))");
            string usercode = MainHelper.User.UserCode;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].UserCode == usercode)
                {
                    barJU.Edit.ReadOnly = false;
                    repositoryItemLookUpEdit2.DataSource = list;
                    if ( repositoryItemLookUpEdit2.Columns.Count < 1)
                    {
                        repositoryItemLookUpEdit2.DisplayMember = "OrgName";
                        repositoryItemLookUpEdit2.ValueMember = "OrgCode";
                        repositoryItemLookUpEdit2.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrgName", 100, "请选择"));
                    }

                    barJU.EditValue = list[i].OrgCode;
                    result = true;
                    barJU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    break;
                }
                else if (i == list.Count - 1 && list[i].UserCode != usercode)
                {
                    result = false;
                    barJU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    if (RecordIkind.IndexOf("局") == -1)
                    {
                        bar1.Visible = true;
                    }
                    else
                    {
                        bar1.Visible = false;
                        gridControl1.DataSource = null;
                        MsgBox.ShowWarningMessageBox("抱歉，您不是局用户，无操作权限！");
                    }
                }
            }
            if (RecordIkind.IndexOf("局") == -1)
            {
                barJU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            return result;
        }

        //private string recordIkind = "定期分析";
        private string recordIkind;
        public string RecordIkind
        {
            get { return recordIkind; }
            set
            {
                recordIkind = value;
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
        #region
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
            }
        }
        private RepositoryItemImageEdit imageEdit1;
        private mOrg parentObj;
        public UCPJ_03yxfx()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_03yxfx>(gridControl1, gridView1, barManager1, new frmyxfxEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_03yxfx>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_03yxfx>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_03yxfx> e)
        {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_03yxfx> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        #endregion

        private void UCPJ_03yxfx_Load(object sender, EventArgs e)
        {
            InitColumns();//初始列
            InitData();//初始数据
            List<WF_Operator> wflist2 = new List<WF_Operator>();
            IList<WF_WorkFlow> list = MainHelper.PlatformSqlMap.GetList<WF_WorkFlow>("SelectWF_WorkFlowList", "where FlowCaption like '%分析%'");
            foreach (WF_WorkFlow wf in list)
            {
                IList<WF_WorkTask> list2 = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", "where WorkFlowId='" + wf.WorkFlowId + "' and  TaskTypeId!='2' order by TaskTypeId");
                foreach (WF_WorkTask wt in list2)
                {
                    WF_Operator wfop = (WF_Operator)MainHelper.PlatformSqlMap.GetObject("SelectWF_OperatorList", "where WorkFlowId='" + wt.WorkFlowId + "' and WorkTaskId='" + wt.WorkTaskId + "' and OperContent='all'");
                    if (wfop == null)
                    {
                        wfop = new WF_Operator();
                        wfop.OperatorId = Guid.NewGuid().ToString();
                        wfop.OperContent = "all";
                        wfop.Description = "所有人";
                        wfop.OperDisplay = "所有人";
                        wfop.WorkFlowId = wt.WorkFlowId;
                        wfop.WorkTaskId = wt.WorkTaskId;
                        wfop.OperType = 5;
                        wfop.InorExclude = true;
                        wflist2.Add(wfop);

                    }
                }

            }
            if (wflist2.Count > 0)
            {
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                SqlQueryObject wfobj3 = new SqlQueryObject(SqlQueryType.Insert, wflist2.ToArray());
                list3.Add(wfobj3);
                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            }
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            btGdsList.EditValue = MainHelper.UserOrg.OrgCode;

            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {
                btGdsList.Edit.ReadOnly = true;
            }
            if (isJu())
            {
                btGdsList.Edit.ReadOnly = false;
            }
        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            if (btGdsList.EditValue != null)
            {
                tempOrgCode = btGdsList.EditValue.ToString();
            }
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "' ");
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
            //if (FocusedRowChanged != null)
            //{
            //    FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_03yxfx);
            //}
            //if (gridView1.GetFocusedDataRow() != null && MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType != "1")
            //{
            //    btReEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    if (gridView1.GetFocusedDataRow()["py"].ToString().Trim() == "" || gridView1.GetFocusedDataRow()["qz"].ToString().Trim() == "")
            //    {
            //        btReEdit.Caption = "领导检查";
            //    }
            //    else
            //    {
            //        btReEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    }
            //}
        }
        #region
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
            if (MainHelper.UserOrg != null)
            {
                //string strSQL = "where OrgCode='" + MainHelper.UserOrg.OrgCode + "' and type='"+recordIkind+"' order by id desc";
                string strSQL = "where  OrgCode='" + MainHelper.UserOrg.OrgCode + "' and   type='" + recordIkind + "' order by id desc";
                RefreshData(strSQL);
            }

        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Caption = AttributeHelper.GetDisplayName(typeof(PJ_03yxfx), gridView1.Columns[i].FieldName);

            }
            hideColumn("OrgCode");
            hideColumn("gznrID");
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            if (picview == null)
            {
                imageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
                ((System.ComponentModel.ISupportInitialize)(this.imageEdit1)).BeginInit();
                // 
                // imageEdit1
                // 
                this.imageEdit1.AutoHeight = false;
                this.imageEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                this.imageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                this.imageEdit1.Name = "imageEdit1";
                this.imageEdit1.PopupFormSize = new System.Drawing.Size(1200, 600); ;
                ((System.ComponentModel.ISupportInitialize)(this.imageEdit1)).EndInit();

                picview = new DevExpress.XtraGrid.Columns.GridColumn();
                picview.Caption = "流程图";
                picview.Visible = true;
                //picview.MaxWidth = 300;
                //picview.MinWidth = 300;
                gridControl1.RepositoryItems.Add(imageEdit1);

                picview.ColumnEdit = imageEdit1;
                //DevExpress.XtraEditors.Repository.RepositoryItem

                this.picview.VisibleIndex = 2;
                picview.FieldName = "Image";
                gridView1.Columns.Add(picview);
                ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            }

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //gridViewOperation.RefreshData(slqwhere);
            if (gridtable != null) gridtable.Rows.Clear();

            IList<PJ_03yxfx> li = MainHelper.PlatformSqlMap.GetList<PJ_03yxfx>("SelectPJ_03yxfxList", slqwhere);
            if (li.Count != 0)
            {
                gridtable = ConvertHelper.ToDataTable((IList)li);

            }
            else
            {
                if (gridtable == null) gridtable = new DataTable();
            }

            if (!gridtable.Columns.Contains("Image")) gridtable.Columns.Add("Image", typeof(Bitmap));
            int i = 0;
            for (i = 0; i < gridtable.Rows.Count; i++)
            {

                gridtable.Rows[i]["Image"] = RecordWorkTask.WorkFlowBitmap(gridtable.Rows[i]["ID"].ToString(), imageEdit1.PopupFormSize);
            }

            gridControl1.DataSource = gridtable;
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_03yxfx> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_03yxfx newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.rq = DateTime.Now;
            try { frmLP.ReadTaskData(newobj, RecordWorkFlowData, ParentTemple, CurrRecord); }
            catch { }
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
                    string tempkind = recordIkind;
                    if (tempkind.IndexOf("局") != -1)
                    {
                        tempkind = tempkind.Replace("局", "供电所");
                    }
                    RefreshData(" where OrgCode='" + value + "' and type='" + tempkind + "'  order by id desc");
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
                PJ_03yxfx yxfx = new PJ_03yxfx();
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                foreach (DataColumn dc in gridtable.Columns)
                {
                    if (dc.ColumnName != "Image") yxfx.GetType().GetProperty(dc.ColumnName).SetValue(yxfx, dr[dc.ColumnName], null);
                }
                Export03.ExportExcel(yxfx);
            }
            else
            {
                return;
            }
        }
        #endregion

        string tempOrgCode = "";
        #region 局改变
        private void barJU_EditValueChanged(object sender, EventArgs e)
        {
            if (barJU.EditValue != null)
            {
                tempOrgCode = barJU.EditValue.ToString();
                RefreshData("where orgcode='" + barJU.EditValue + "'and  type='" + recordIkind + "' order by id desc");
            }
        }
        #endregion

        #region 增加
        private void btReAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmyxfxEdit fm = new frmyxfxEdit();
            PJ_03yxfx yxfx = new PJ_03yxfx();
            if (MainHelper.UserOrg == null) return;
            string orgcode = "";
            if (isJu() && barJU.Visibility== DevExpress.XtraBars.BarItemVisibility.Always)
            {
                orgcode = barJU.EditValue.ToString();
            }
            else
            {
                orgcode = btGdsList.EditValue.ToString();
            }
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + orgcode + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];
            yxfx.OrgCode = orgcode;
            yxfx.OrgName = org.OrgName;
            yxfx.type = recordIkind;
            yxfx.rq = DateTime.Now;
            fm.RowData = yxfx;
            fm.RecordStatus = 0;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                RefreshData("where orgcode='" + orgcode + "'and  type='" + recordIkind + "' order by id desc");
            }
        }
        #endregion

        #region 修改
        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmyxfxEdit fm = new frmyxfxEdit();
            PJ_03yxfx yxfx = new PJ_03yxfx();
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null) return;
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image") yxfx.GetType().GetProperty(dc.ColumnName).SetValue(yxfx, dr[dc.ColumnName], null);
            }
            fm.RowData = yxfx;
            if (isJu())
            {
                fm.RecordStatus = 4;
            }
            else
            {
                fm.RecordStatus = 3;
            }
            if (fm.ShowDialog() == DialogResult.OK)
            {
                RefreshData("where orgcode='" + yxfx.OrgCode + "'and  type='" + yxfx.type + "' order by id desc");
            }
        }
        #endregion

        #region 查看
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmyxfxEdit fm = new frmyxfxEdit();
            PJ_03yxfx yxfx = new PJ_03yxfx();
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null) return;
            foreach (DataColumn dc in gridtable.Columns)
            {
                if (dc.ColumnName != "Image") yxfx.GetType().GetProperty(dc.ColumnName).SetValue(yxfx, dr[dc.ColumnName], null);
            }
            fm.RowData = yxfx;
            fm.RecordStatus = -1;
            fm.ShowDialog();
            //if (MainHelper.UserOrg == null) return;
            //if (gridView1.FocusedRowHandle >= 0)
            //{
            //    DataRow dr = gridView1.GetFocusedDataRow();
            //    PJ_03yxfx yxfx = new PJ_03yxfx();
            //    foreach (DataColumn dc in gridtable.Columns)
            //    {
            //        if (dc.ColumnName != "Image") yxfx.GetType().GetProperty(dc.ColumnName).SetValue(yxfx, dr[dc.ColumnName], null);
            //    }
            //    //if (!RecordWorkTask.HaveRunRecordRole(yxfx.ID, MainHelper.User.UserID)) return;
            //    DataTable dt = RecordWorkTask.GetRecordWorkFlowData(yxfx.ID, MainHelper.User.UserID);
            //    frmyxfxEdit fm = new frmyxfxEdit();

            //    IList<mUser> lm = ClientHelper.PlatformSqlMap.GetList<mUser>(" where usercode in (select UserID from ruserrole where roleID in (select RoleID from mRole where RoleName in ('生产局长','生技部长') ))");
            //    string usercode = MainHelper.User.UserCode;
            //    for (int i = 0; i < lm.Count; i++)
            //    {
            //        if (lm[i].UserCode == usercode)
            //        {
            //            if (btReEdit.Caption == "领导检查")
            //            {
            //                fm.RecordStatus = 1;
            //                break;
            //            }
            //            else if (btReEdit.Caption == "检查人检查")
            //            {
            //                fm.RecordStatus = 2;
            //                break;
            //            }
            //        }
            //        else if (i == lm.Count - 1 && lm[i].UserCode != usercode)
            //        {
            //            MsgBox.ShowWarningMessageBox("抱歉，您没有检查权限！");
            //            return;
            //        }
            //    }
            //    fm.RecordWorkFlowData = dt;
            //    fm.RowData = yxfx;

            //    fm.ShowDialog();
            //    RefreshData("where orgcode='" + btGdsList.EditValue + "'and  type='" + recordIkind + "' order by id desc");
            //}
            //else
            //{
            //    return;
            //}
        }
        #endregion

        #region
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName != "Image")
                e.Cancel = true;
        }

        private void btReDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainHelper.UserOrg == null) return;

            if (gridView1.FocusedRowHandle < 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除 【" + dr["zt"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }

            try
            {


                RecordWorkTask.DeleteRecord(dr["ID"].ToString());
                MainHelper.PlatformSqlMap.DeleteByWhere<PJ_03yxfx>(" where id ='" + dr["ID"].ToString() + "'");
                //InitData();
                RefreshData("where orgcode='" + btGdsList.EditValue + "'and  type='" + recordIkind + "' order by id desc");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //InitData();
            RefreshData("where orgcode='" + btGdsList.EditValue + "'and  type='" + recordIkind + "' order by id desc");
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
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }
        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
        #endregion
    }
}
