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
using Ebada.Core;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCAQGJSTZ : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_anqgjcrkd> gridViewOperation;

        public event SendDataEventHandler<PJ_anqgjcrkd> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_anqgjcrkd,LP_Record";
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
        private string strSQL = "";
        public string StrSQL
        {

            set
            {
                strSQL = value;
                RefreshData(strSQL);
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
        private DataTable gridtable = null;
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        public UCAQGJSTZ()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_anqgjcrkd>(gridControl1, gridView1, barManager1, new frmAQGJSTZEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_anqgjcrkd>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_anqgjcrkd>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_anqgjcrkd>(gridViewOperation_AfterDelete);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_anqgjcrkd>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            if (isWorkflowCall && fjly==null)
            {
                fjly = new frmModleFjly();
            }
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

        void iniProject()
        {
            repositoryItemComboBox1.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssgc  from PJ_anqgjcrkd where type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存'  and ssgc!='' ");
            repositoryItemComboBox1.Items.AddRange(mclist);
        }
        private void barEditGC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemComboBox2.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssxm  from PJ_anqgjcrkd where  ssgc='" + barEditGC.EditValue + "' and ( type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') and ssxm!='' ");
            repositoryItemComboBox2.Items.AddRange(mclist);

            repositoryItemComboBox3.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where  ssgc='" + barEditGC.EditValue + "' and ( type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') and wpmc!='' ");
            repositoryItemComboBox3.Items.AddRange(mclist);

            repositoryItemComboBox4.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where  ssgc='" + barEditGC.EditValue + "' and ( type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') and wpgg!='' ");
            repositoryItemComboBox4.Items.AddRange(mclist);
            barEditFGC.EditValue = "";
        }
        private void barEditFGC_EditValueChanged(object sender, EventArgs e)
        {



            inidate();
            repositoryItemComboBox3.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where  ssxm='" + barEditFGC.EditValue + "' and ( type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') and wpmc!='' ");
            repositoryItemComboBox3.Items.AddRange(mclist);

            repositoryItemComboBox4.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where  ssxm='" + barEditFGC.EditValue + "' and ( type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') and wpgg!='' ");
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
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where  wpmc='" + barEditItem1.EditValue + "' and wpgg!='' ");
            repositoryItemComboBox4.Items.AddRange(mclist);
            inidate();

        }
        private void inidate()
        {
            string ssgc = " and 1=1 ", ssxm = " and 1=1 ", wpgg = " and 1=1 ", wpmc = " and 1=1 ";
            if (barEditGC.EditValue != null && barEditGC.EditValue.ToString() != "")
                ssgc = " and ssgc='" + barEditGC.EditValue + "' ";
            if (barEditFGC.EditValue != null && barEditFGC.EditValue.ToString() != "")
                ssxm = " and ssxm='" + barEditFGC.EditValue + "' ";
            if (barEditItem1.EditValue != null && barEditItem1.EditValue.ToString() != "")
                wpmc = " and wpmc='" + barEditItem1.EditValue + "' ";
            if (barEditItem2.EditValue != null && barEditItem2.EditValue.ToString() != "")
                wpgg = " and wpgg='" + barEditItem2.EditValue + "' ";
            RefreshData(" where  (type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') " + ssgc + ssxm + wpmc + wpgg);
        }
        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            inidate();
        }
        void gridViewOperation_AfterDelete(PJ_anqgjcrkd obj)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }

            RefreshData(" where OrgCode='" + parentID + "' ");
        }
        void gridViewOperation_AfterAdd(PJ_anqgjcrkd newobj)
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
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_anqgjcrkd> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_anqgjcrkd> e)
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
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

      
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_anqgjcrkd);
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

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Caption = AttributeHelper.GetDisplayName(typeof(PJ_anqgjcrkd), gridView1.Columns[i].FieldName);
            }
            //hideColumn("OrgCode");
            //hideColumn("OrgName");
            hideColumn("ssgc");
            hideColumn("ssxm");
            hideColumn("wpcj");
            hideColumn("lqdw");
            hideColumn("lasttime");
            hideColumn("lyparent");
            hideColumn("kcsl");
            gridView1.Columns["num"].Width = 150;
            gridView1.Columns["type"].Width = 150;
            gridView1.Columns["num"].VisibleIndex = 1;
            gridView1.Columns["type"].VisibleIndex = 2;
            gridView1.Columns["OrgName"].VisibleIndex = 3;
            gridView1.Columns["wpmc"].VisibleIndex=4;
            gridView1.Columns["wpgg"].VisibleIndex=5;

            gridView1.Columns["wpdw"].VisibleIndex=6;
            gridView1.Columns["wpsl"].VisibleIndex=7;
            gridView1.Columns["wpdj"].VisibleIndex=8;
            gridView1.Columns["indate"].VisibleIndex=9;
            gridView1.Columns["ckdate"].VisibleIndex=10;
            gridView1.Columns["cksl"].VisibleIndex = 11;

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            GridColumn picview = new GridColumn();
            picview.Caption = "物品价值";
            picview.VisibleIndex = 12;
            picview.FieldName = "wpjz";
            gridView1.Columns.Add(picview);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();

            gridView1.Columns["zkcsl"].VisibleIndex=14;
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
            //slqwhere = slqwhere + " order by id desc";
            //gridViewOperation.RefreshData(slqwhere);
            if (gridtable != null) gridtable.Rows.Clear();

            IList<PJ_anqgjcrkd> li = MainHelper.PlatformSqlMap.GetList<PJ_anqgjcrkd>("SelectPJ_anqgjcrkdList", strSQL + "  order by type,cast( indate as datetime)");
            if (li.Count != 0)
            {
                gridtable = ConvertHelper.ToDataTable((IList)li);

            }
            else
            {
                if (gridtable == null) gridtable = new DataTable();
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gridView1.Columns)
            {
                gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            }
            if (!gridtable.Columns.Contains("xh")) gridtable.Columns.Add("xh", typeof(string));
            if (!gridtable.Columns.Contains("wpjz")) gridtable.Columns.Add("wpjz", typeof(string));
            int i = 1;
            double dsum1 = 0;//入库单
            double dsum2 = 0;//出库单
            double dsum3 = 0;//材料单
            double dsum4 = 0;//库存单
            double djzsum1 = 0;//入库单
            double djzsum2 = 0;//出库单
            double djzsum3 = 0;//材料单
            double djzsum4 = 0;//材料单
            bool bfind1 = false;//入库单
            bool bfind2 = false;//出库单
            bool bfind3 = false;//材料单
            foreach (DataRow dr in gridtable.Rows)
            {
                dr["xh"] = i++;
                if (dr["wpsl"].ToString() == "") dr["wpsl"] = 0;
                if (dr["wpdj"].ToString() == "") dr["wpdj"] = 0;
                if (dr["type"].ToString().IndexOf("入库单") > 0)
                {
                    dsum1 += Convert.ToDouble(dr["wpsl"]);
                    dr["wpjz"] = Convert.ToDouble(dr["wpsl"]) * Convert.ToDouble(dr["wpdj"]);
                    djzsum1 += Convert.ToDouble(dr["wpjz"]);
                    dsum4 += Convert.ToDouble(dr["kcsl"]);
                    djzsum4 += Convert.ToDouble(dr["kcsl"]) * Convert.ToDouble(dr["wpdj"]);
                    bfind1 = true;
                }
                else
                    if (dr["type"].ToString().IndexOf("出库单") > 0)
                    {

                        dsum2 += Convert.ToDouble(dr["cksl"]);
                        dr["wpjz"] = Convert.ToDouble(dr["cksl"]) * Convert.ToDouble(dr["wpdj"]);
                        djzsum2 += Convert.ToDouble(dr["wpjz"]);
                        bfind2 = true;
                    }
                    else
                        if (dr["type"].ToString().IndexOf("材料单") > 0)
                        {

                            dsum3 += Convert.ToDouble(dr["cksl"]);
                            dr["wpjz"] = Convert.ToDouble(dr["cksl"]) * Convert.ToDouble(dr["wpdj"]);
                            djzsum3 += Convert.ToDouble(dr["wpjz"]);
                            bfind3 = true;
                        }

            }

            if (bfind1)
            {
                DataRow dr1 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr1["type"] = "入库单";
                dr1["wpmc"] = "入库合计";
                dr1["wpsl"] = dsum1;
                dr1["wpjz"] = djzsum1;
                gridtable.Rows.Add(dr1);
            }
            if (bfind2)
            {
                DataRow dr1 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr1["type"] = "出库单";
                dr1["wpmc"] = "出库合计";
                dr1["wpsl"] = dsum2;
                dr1["wpjz"] = djzsum2;
                gridtable.Rows.Add(dr1);
            }
            if (bfind3)
            {
                DataRow dr1 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr1["type"] = "材料单";
                dr1["wpmc"] = "出库合计";
                dr1["wpsl"] = dsum3;
                dr1["wpjz"] = djzsum3;
                gridtable.Rows.Add(dr1);
            }
            if (gridtable.Rows.Count > 0)
            {
                DataRow dr2 = gridtable.NewRow();
                //dr1["xh"] = i++;
                dr2["type"] = "现有库存";
                dr2["wpmc"] = "库存合计";
                dr2["wpsl"] = dsum4;
                dr2["wpjz"] = djzsum4;
                gridtable.Rows.Add(dr2);
                IList wpli = MainHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select distinct wpmc from PJ_anqgjcrkd {0} ", strSQL));
                foreach (string wpmc in wpli)
                {
                    IList wpggli = MainHelper.PlatformSqlMap.GetList("SelectOneStr",
                   string.Format("select distinct wpgg from PJ_anqgjcrkd {0} ", strSQL));
                    string stryskc = "",//原始库存
                     strjzyskc = "",//原始库存价值

                     strrks = "",//入库数
                     strjzrks = "",//入库数价值

                     strcks = "",//出库数 
                     strjzcks = "",//出库数价值

                     strxykc = "",//现有库存
                    strjzxykc = "";//现有库存价值
                    List<string> sli = new List<string>();
                    sli.Add("所安全工器具");
                    //sli.Add("撤旧材料");
                    //sli.Add("非生产物资");
                    foreach (string strtype in sli)
                    {
                        if (strSQL.IndexOf(strtype) < 0 && strSQL.IndexOf("type") > -1) continue;
                        foreach (string wpgg in wpggli)
                        {
                            stryskc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select wpsl from PJ_anqgjcrkd where  wpmc='{0}' and wpgg='{1}'  and type = '{2}原始库存' ",
                                wpmc, wpgg, strtype));
                            strjzyskc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(wpsl as float)*cast(wpdj as float)) as nvarchar(50)) from PJ_anqgjcrkd where  wpmc='{0}' and wpgg='{1}'  and type = '{2}原始库存' ", wpmc, wpgg, strtype));

                            strrks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(wpsl as float)) as nvarchar(50)) from PJ_anqgjcrkd   {2}  and wpmc='{0}' and wpgg='{1}'  and type = '{3}入库单' ",
                                 wpmc, wpgg, strSQL, strtype));
                            strjzrks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(wpsl as float)*cast(wpdj as float)) as nvarchar(50)) from PJ_anqgjcrkd   {2}  and wpmc='{0}' and wpgg='{1}'  and type = '{3}入库单' ", wpmc, wpgg, strSQL, strtype));

                            strcks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(cksl as float)) as nvarchar(50))  from PJ_anqgjcrkd   {2} and  wpmc='{0}' and wpgg='{1}'  and type='{3}出库单' ",
                                wpmc, wpgg, strSQL, strtype));
                            strjzcks = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(cksl as float)*cast(wpdj as float)) as nvarchar(50))  from PJ_anqgjcrkd   {2} and  wpmc='{0}' and wpgg='{1}'  and type='{3}出库单' ",
                                wpmc, wpgg, strSQL, strtype));

                            strxykc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(kcsl as float)) as nvarchar(12))  from PJ_anqgjcrkd {2} and  wpmc='{0}' and wpgg='{1}' and type = '{3}入库单'   ",
                                wpmc, wpgg, strSQL, strtype));
                            strjzxykc = (string)MainHelper.PlatformSqlMap.GetObject("SelectOneStr",
                            string.Format("select cast(sum(cast(kcsl as float)*cast(wpdj as float)) as nvarchar(50))  from PJ_anqgjcrkd {2} and  wpmc='{0}' and wpgg='{1}' and type = '{3}入库单' ",
                                wpmc, wpgg, strSQL, strtype));

                            DataRow dr1;
                            if (strSQL.IndexOf("type") == -1 || strSQL.IndexOf("%" + strtype + "%") > 0 || strSQL.IndexOf("入库单") > 0)
                            {
                                dr1 = gridtable.NewRow();
                                //dr1["xh"] = i++;x
                                dr1["type"] = strtype + "入库单合计";
                                dr1["wpmc"] = wpmc;
                                dr1["wpgg"] = wpgg;
                                dr1["wpsl"] = strrks;
                                dr1["wpjz"] = strjzrks;
                                gridtable.Rows.Add(dr1);
                            }

                            if (strSQL.IndexOf("type") == -1 || strSQL.IndexOf("%" + strtype + "%") > 0 || strSQL.IndexOf("出库单") > 0)
                            {
                                dr1 = gridtable.NewRow();
                                dr1["type"] = strtype + "出库单合计";
                                dr1["wpmc"] = wpmc;
                                dr1["wpgg"] = wpgg;
                                dr1["wpsl"] = strcks;
                                dr1["wpjz"] = strjzcks;
                                gridtable.Rows.Add(dr1);
                            }


                            dr1 = gridtable.NewRow();
                            dr1["type"] = strtype + "原始库存";
                            dr1["wpmc"] = wpmc;
                            dr1["wpgg"] = wpgg;
                            dr1["wpsl"] = stryskc;
                            dr1["wpjz"] = strjzyskc;
                            gridtable.Rows.Add(dr1);



                            dr1 = gridtable.NewRow();
                            dr1["type"] = strtype + "现有库存";
                            dr1["wpmc"] = wpmc;
                            dr1["wpgg"] = wpgg;
                            dr1["wpsl"] = strxykc;
                            dr1["wpjz"] = strjzxykc;
                            gridtable.Rows.Add(dr1);


                        }

                    }
                }
            }
            gridControl1.DataSource = gridtable; 
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_anqgjcrkd> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_anqgjcrkd newobj)
        {
            if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.indate = DateTime.Now;
          
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
                    RefreshData(" where OrgCode='" + value + "' ");
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //IList<PJ_anqgjcrkd> datalist = gridView1.DataSource as IList<PJ_anqgjcrkd>;
            IList<PJ_anqgjcrkd> datalist = new List<PJ_anqgjcrkd>();
            foreach (DataRow dr in gridtable.Rows)
            {
                PJ_anqgjcrkd pc = new PJ_anqgjcrkd();
                foreach (DataColumn dc in gridtable.Columns)
                {
                    if (dc.DataType.FullName.IndexOf("wpjz") < 0)
                        pc.GetType().GetProperty(dc.ColumnName).SetValue(pc, dr[dc.ColumnName], null);
                }
                datalist.Add(pc);
            }
            //frmProjectSelect fys = new frmProjectSelect();
            //fys.strType = " and (type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') ";
            //fys.StrSQL = "select distinct ssgc  from PJ_anqgjcrkd where  (type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') ";
            //if (fys.ShowDialog() == DialogResult.OK)
            //{

            ExportAQGJSTZEdit etdjh = new ExportAQGJSTZEdit();
                etdjh.ExportExcel(datalist);
            //}
           
           
           
        }

        

        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MsgBox.ShowTipMessageBox("没有开发此功能!");
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
            ////请求确认
            //if (MsgBox.ShowAskMessageBox("是否确认复制去年计划生成今年计划 ?") != DialogResult.OK)
            //{
            //    return;
            //}
            //IList<PJ_anqgjcrkd> bjlist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_anqgjcrkd>("where orgcode='" + btGdsList.EditValue + "' AND jhnf='"+DateTime.Now.Year+"'");
            //List<PJ_anqgjcrkd> list = new List<PJ_anqgjcrkd>();
            //foreach (PJ_anqgjcrkd bj in bjlist)
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

        private void barExplorYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            IList<PJ_anqgjcrkd> datalist = new List<PJ_anqgjcrkd>();
            foreach (DataRow dr in gridtable.Rows)
            {
                PJ_anqgjcrkd pc = new PJ_anqgjcrkd();
                foreach (DataColumn dc in gridtable.Columns)
                {
                    if (dc.ColumnName.IndexOf("wpjz") < 0 && dc.ColumnName.IndexOf("xh") < 0 && dr[dc.ColumnName].ToString()!=string.Empty)
                        pc.GetType().GetProperty(dc.ColumnName).SetValue(pc, dr[dc.ColumnName], null);
                }
                datalist.Add(pc);
            }
            //frmProjectSelect fys = new frmProjectSelect();
            //fys.strType = " and (type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') ";
            //fys.StrSQL = "select distinct ssgc  from PJ_anqgjcrkd where  (type = '局安全工器具入库单' or type = '局安全工器具入库单原始库存') ";
            //if (fys.ShowDialog() == DialogResult.OK)
            //{

            ExportAQGJSTZEdit etdjh = new ExportAQGJSTZEdit();
            etdjh.ExportExcel(datalist);
            //}
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

    }
}
