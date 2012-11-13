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
using Ebada.Components;
using DevExpress.Utils;
using System.Collections;
using Ebada.Scgl.WFlow;
using System.Runtime.InteropServices;
using Ebada.UI.Base;

namespace Ebada.Scgl.Lcgl
{

    /// <summary>
    /// 
    /// </summary>
    /// 
    [ToolboxItem(false)]
    public partial class UCtestRecord : DevExpress.XtraEditors.XtraUserControl
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public GridViewOperation<PJ_yfsyjl> gridViewOperation;

        public event SendDataEventHandler<PJ_yfsyjl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private string _type = null;
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_yfsyjl,LP_Record";
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
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        if (wt.CommandName == "01")
                        {
                            liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Caption = wt.Description;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
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
        public UCtestRecord()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_yfsyjl>(gridControl1, gridView1, barManager1, new frmtestRecordEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterEdit);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeEdit);

        }

        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_yfsyjl> e)
        {
            //lgmqxlast
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(e.ValueOld.ID);
            e.ValueOld.gdstemp = ParentObj.OrgCode;
            if (tempobj != null)
            {
                e.ValueOld.xlid = tempobj.xlid;
                e.ValueOld.xlname = tempobj.xlname;
                e.ValueOld.tqid = tempobj.tqid;
                e.ValueOld.tqname = tempobj.tqname;
                e.ValueOld.byqid = tempobj.byqid;
                e.ValueOld.byqname = tempobj.byqname;
                e.ValueOld.kgid = tempobj.kgid;
                e.ValueOld.kgname = tempobj.kgname;
            }
        }
        void gridViewOperation_AfterEdit(PJ_yfsyjl obj)
        {
            Addqxmx(obj);
            RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'  ");

        }
        //处理缺陷明细  lgmqx
        private void Addqxmx(PJ_yfsyjl obj)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(obj.ID);
            switch (_type)
            {
                case "变压器":
                    if (obj.syjg != "合格")
                    {
                        if (tempobj == null || tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                            PJ_qxfl mx = new PJ_qxfl();
                            mx.ID = obj.ID;
                            mx.OrgCode = obj.OrgCode;
                            mx.OrgName = obj.OrgName;
                            mx.LineID = "01";
                            mx.LineName = obj.sbInstallAdress;
                            mx.xlqd = obj.sbModle;
                            mx.xssj = obj.sjExpTime;
                            mx.xsr = obj.syMan;
                            mx.qxly = "变压器预防性试验实施情况记录";
                            mx.qxnr = "预防性试验不合格";
                            mx.qxlb = "重大缺陷";
                            mx.xcqx = mx.xssj.AddDays(3).ToShortDateString();

                            //lgmqxlast
                            mx.xlid = obj.xlid;
                            mx.xlname = obj.xlname;
                            mx.tqid = obj.tqid;
                            mx.tqname = obj.tqname;
                            mx.byqid = obj.byqid;
                            mx.byqname = obj.byqname;
                            mx.kgid = obj.kgid;
                            mx.kgname = obj.kgname;
                            MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                        }

                    }
                    else
                    {
                        if (tempobj != null && tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                        }

                    }
                    break;
                case "断路器":
                    if (obj.syjg != "合格")
                    {
                        if (tempobj == null || tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                            PJ_qxfl mx = new PJ_qxfl();
                            mx.ID = obj.ID;
                            mx.OrgCode = obj.OrgCode;
                            mx.OrgName = obj.OrgName;
                            mx.LineID = "02";
                            mx.LineName = obj.sbInstallAdress;
                            mx.xlqd = obj.sbModle;
                            mx.xssj = obj.sjExpTime;
                            mx.xsr = obj.syMan;
                            mx.qxly = "断路器预防性试验实施情况记录";
                            mx.qxnr = "预防性试验不合格";
                            mx.qxlb = "重大缺陷";
                            mx.xcqx = mx.xssj.AddDays(3).ToShortDateString();

                            //lgmqxlast
                            mx.xlid = obj.xlid;
                            mx.xlname = obj.xlname;
                            mx.tqid = obj.tqid;
                            mx.tqname = obj.tqname;
                            mx.byqid = obj.byqid;
                            mx.byqname = obj.byqname;
                            mx.kgid = obj.kgid;
                            mx.kgname = obj.kgname;
                            MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                        }
                    }
                    else
                    {
                        if (tempobj != null && tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                        }

                    }
                    break;

                case "避雷器":

                    if (obj.syjg != "合格")
                    {
                        if (tempobj == null || tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                            PJ_qxfl mx = new PJ_qxfl();
                            mx.ID = obj.ID;
                            mx.OrgCode = obj.OrgCode;
                            mx.OrgName = obj.OrgName;
                            mx.LineID = "03";
                            mx.LineName = obj.sbInstallAdress;
                            mx.xlqd = obj.sbModle;
                            mx.xssj = obj.sjExpTime;
                            mx.xsr = obj.syMan;
                            mx.qxly = "避雷器预防性试验实施情况记录";
                            mx.qxnr = "预防性试验不合格";
                            if (obj.syjg == "绝缘阻值低于2000兆欧")
                            {
                                mx.qxnr = "预防性试验不合格";
                                mx.qxlb = "一般缺陷";
                                mx.xcqx = mx.xssj.AddMinutes(3).ToShortDateString();
                            }
                            else if (obj.syjg == "绝缘阻值低于1000兆欧")
                            {
                                mx.qxnr = "预防性试验不合格";
                                mx.qxlb = "重大缺陷";
                                mx.xcqx = mx.xssj.AddDays(3).ToShortDateString();
                            }
                            //lgmqxlast
                            mx.xlid = obj.xlid;
                            mx.xlname = obj.xlname;
                            mx.tqid = obj.tqid;
                            mx.tqname = obj.tqname;
                            mx.byqid = obj.byqid;
                            mx.byqname = obj.byqname;
                            mx.kgid = obj.kgid;
                            mx.kgname = obj.kgname;
                            MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                        }
                    }
                    else
                    {
                        if (tempobj != null && tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                        }

                    }
                    break;
                case "电容器":
                    if (obj.syjg != "合格")
                    {
                        if (tempobj == null || tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                            PJ_qxfl mx = new PJ_qxfl();
                            mx.ID = obj.ID;
                            mx.OrgCode = obj.OrgCode;
                            mx.OrgName = obj.OrgName;
                            mx.LineID = "04";
                            mx.LineName = obj.sbInstallAdress;
                            mx.xlqd = obj.sbModle;
                            mx.xssj = obj.sjExpTime;
                            mx.xsr = obj.syMan;
                            mx.qxly = "电容器预防性试验实施情况记录";
                            mx.qxnr = "预防性试验不合格";
                            mx.qxlb = "重大缺陷";
                            mx.xcqx = mx.xssj.AddDays(3).ToShortDateString();
                            //lgmqxlast
                            mx.xlid = obj.xlid;
                            mx.xlname = obj.xlname;
                            mx.tqid = obj.tqid;
                            mx.tqname = obj.tqname;
                            mx.byqid = obj.byqid;
                            mx.byqname = obj.byqname;
                            mx.kgid = obj.kgid;
                            mx.kgname = obj.kgname;
                            MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                        }
                    }
                    else
                    {
                        if (tempobj != null && tempobj.xcr == string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                        }

                    }
                    break;
            }
        }
        private void Delqxmx(string id)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(id);
            if (tempobj != null && tempobj.xcr == string.Empty)
            {
                MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(id);
            }
        }
        void gridViewOperation_AfterDelete(PJ_yfsyjl obj)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
            string slqwhere = " where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type + "' ";
            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by xh";
            IList<PJ_yfsyjl> li = MainHelper.PlatformSqlMap.GetListByWhere<PJ_yfsyjl>(slqwhere);
            int i = 1;
            List<PJ_yfsyjl> list = new List<PJ_yfsyjl>();
            foreach (PJ_yfsyjl ob in li)
            {
                ob.xh = i;
                i++;
                list.Add(ob);
            }
            List<SqlQueryObject> list3 = new List<SqlQueryObject>();
            if (list.Count > 0)
            {
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            RefreshData(" where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type + "'  ");
        }

        void gridViewOperation_AfterAdd(PJ_yfsyjl obj)
        {
            string slqwhere = " where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type + "' ";
            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            obj.xh = MainHelper.PlatformSqlMap.GetRowCount<PJ_yfsyjl>(slqwhere);
            obj.CreateDate = DateTime.Now;
            MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(obj);
            //if (isWorkflowCall)
            //{
            //    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
            //    mrwt.ModleRecordID = obj.ID;
            //    mrwt.RecordID = currRecord.ID;
            //    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
            //    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
            //    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
            //    mrwt.ModleTableName = obj.GetType().ToString();
            //    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
            //    mrwt.CreatTime = DateTime.Now;
            //    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            //}
            Delqxmx(obj.ID);
            RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'  ");
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (_type != null)
                {
                    switch (_type)
                    {
                        case "变压器":
                            hideColumn("sl");
                            break;
                        case "断路器":
                            hideColumn("sbCapacity");

                            break;

                        case "避雷器":
                            hideColumn("sbCapacity");
                            break;

                        //case "电容器":
                        //    hideColumn("sbCapacity");
                        //    gridView1.OptionsView.AllowCellMerge = true; 
                        //    gridView1.Columns["xh"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["sbInstallAdress"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["sbModle"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["syPeriod"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["preExpTime"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["planExpTime"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["charMan"].OptionsColumn.AllowMerge = DefaultBoolean.True;
                        //    gridView1.Columns["Remark"].OptionsColumn.AllowMerge = DefaultBoolean.True;   
                        //    gridViewOperation.EditForm =  new frmtestRecorddrqEdit();
                        //break;
                    }
                    RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'  ");
                }

            }
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_yfsyjl> e)
        {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_yfsyjl> e)
        {
            if (parentID == null)
            {
                e.Cancel = true;
            }
            else
            {
                e.Value.type = _type;
                e.Value.OrgCode = parentObj.OrgCode;
                e.Value.OrgName = parentObj.OrgName;
            }
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_yfsyjl);
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
            hideColumn("gzrjID");
            hideColumn("type");
            hideColumn("iswc");
            hideColumn("syjg");
            hideColumn("syMan");
            hideColumn("sjExpTime");
            hideColumn("CreateDate");
            hideColumn("wcRemark");
            gridView1.Columns["preExpTime"].Caption = "检查试验时间";
            gridView1.Columns["planExpTime"].Caption = "下次试验时间";
            foreach (GridColumn gc in gridView1.Columns)
            {
                gc.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by xh";
            gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshData()
        {
            string slqwhere = " where OrgCode='" + ParentID + "'  and type='" + _type + "' ";
            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by xh";
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_yfsyjl> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_yfsyjl newobj)
        {
            if (parentID == null)
            {
                return;
            }
            try { frmLP.ReadTaskData(newobj, RecordWorkFlowData, ParentTemple, CurrRecord); }
            catch { }

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
                    RefreshData(" where OrgCode='" + value + "'  and type='" + _type + "'   ");

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
            //DataTable dt = new DataTable();
            //IList<PJ_yfsyjl> li = gridView1.DataSource as IList<PJ_yfsyjl>;
            //frmTemplate frm = new frmTemplate();
            //frm.dataList = li;
            //frm.ShowDialog();

            IList<PJ_yfsyjl> datalist = gridView1.DataSource as IList<PJ_yfsyjl>;
            Export11 export = new Export11();
            export.CurrRecord = currRecord;
            export.IsWorkflowCall = isWorkflowCall;
            export.ParentTemple = parentTemple;
            export.RecordWorkFlowData = WorkFlowData;
            switch (_type)
            {
                case "变压器":
                    export.ExportExcelbyq(datalist, _type + "预防性试验记录", parentID);
                    break;
                case "断路器":
                    export.ExportExceldlq(datalist, _type + "预防性试验记录", parentID);
                    break;
                case "避雷器":
                    export.ExportExcelblq(datalist, _type + "预防性试验记录", parentID);
                    break;
                case "电容器":
                    export.ExportExceldrq(datalist, _type + "预防性试验记录", parentID);
                    break;
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
            Export11 export = new Export11();
            export.CurrRecord = currRecord;
            export.IsWorkflowCall = isWorkflowCall;
            export.ParentTemple = parentTemple;
            export.RecordWorkFlowData = WorkFlowData;
            if (MainHelper.UserOrg.OrgName.IndexOf("局") == -1)
                export.ExportExceljhbAllSubmit(ref parentTemple, "预防性试验", "设备预防性试验计划（总）表", parentID, false);
            else
                export.ExportExceljhbAllSubmit(ref parentTemple, "预防性试验", "设备预防性试验计划（总）表", "", false);
            fm.ParentTemple = parentTemple;
            if (fm.ShowDialog() == DialogResult.OK)
            {

                if (MainHelper.UserOrg.OrgName.IndexOf("局") == -1)
                    export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(parentID);
                else
                    export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(parentID);
                gridControl1.FindForm().Close();
            }

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
