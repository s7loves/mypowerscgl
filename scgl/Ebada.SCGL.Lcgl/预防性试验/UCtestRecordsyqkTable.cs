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
using Ebada.Scgl.WFlow;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCtestRecordsyqkTable : DevExpress.XtraEditors.XtraUserControl
    {
        public  GridViewOperation<PJ_yfsyjl> gridViewOperation;

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
                //liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btReEdit.Enabled = !value;
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
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
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

        public UCtestRecordsyqkTable()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_yfsyjl>(gridControl1, gridView1, barManager1, new frmtestRecordsyqkEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
            
        }

        void gridViewOperation_AfterDelete(PJ_yfsyjl obj)
        {
            string slqwhere = " where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type + "'   and planExpTime like '%" + DateTime.Now.Year + "%' ";
            if (isWorkflowCall)
            {

                slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
                slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                   + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            }
            slqwhere = slqwhere + " order by xh";

            IList<PJ_yfsyjl> li = MainHelper.PlatformSqlMap.GetListByWhere<PJ_yfsyjl>(slqwhere);
            int i=1;
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
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray ());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            RefreshData(" where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type + "'  and planExpTime like '%" + DateTime.Now.Year + "%'   ");
            Delqxmx(obj.ID);
        }

        void gridViewOperation_AfterAdd(PJ_yfsyjl obj)
        {
            string slqwhere = " where OrgCode='" + obj.OrgCode + "' and  type='" + obj.type + "'";
            if (isWorkflowCall)
            {

                slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
                slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                   + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            }
            obj.xh = MainHelper.PlatformSqlMap.GetRowCount<PJ_yfsyjl>(slqwhere)+1;
            obj.CreateDate = DateTime.Now;
            MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(obj);
            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {
                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] {obj, currRecord });
            }
            RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'   and planExpTime like '%" + DateTime.Now.Year + "%'   ");
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (_type != null )
                {
                    gridView1.Columns["sbCapacity"].VisibleIndex = 4;
                    gridView1.Columns["sl"].VisibleIndex = 4;
                    switch (_type)
                    {
                        case "变压器":
                            hideColumn("sl");
                            hideColumn("sbCapacity", true);
                            break;
                        case "断路器":
                            hideColumn("sbCapacity");
                            hideColumn("sl", true);

                            break;

                        case "避雷器":
                            hideColumn("sbCapacity");
                            hideColumn("sl", true);
                            break;

                        case "电容器":
                            hideColumn("sbCapacity");
                            hideColumn("sl", true);
                            break;


                    }
                    RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "'   and planExpTime like '%" + DateTime.Now.Year + "%'  ");
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_yfsyjl);
        }
        private void hideColumn(string colname)
        {
            //gridView1.Columns[colname].Visible = false;
            hideColumn(colname, false);
        }
        private void hideColumn(string colname, bool ishide)
        {
            gridView1.Columns[colname].Visible = ishide;
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
            hideColumn("syPeriod");
            hideColumn("gzrjID");
            hideColumn("type");
            hideColumn("CreateDate");
            hideColumn("preExpTime");
            hideColumn("wcRemark");
            hideColumn("iswc");
            gridView1.Columns["charMan"].Caption = "负责人";
            gridView1.Columns["planExpTime"].Caption = "计划试验时间";
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

            if (isWorkflowCall)
            {

                slqwhere = slqwhere + " and  id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
             + " WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                 + " and   WorkFlowInsId !='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    // + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    // + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString()+"'"
                + ")";
            }


            if (_type == "电容器")
            {
                slqwhere += " and year(planExpTime)=" + DateTime.Now.Year;
            }
            gridViewOperation.RefreshData(slqwhere);
        }
        public void RefreshData()
        {
            string slqwhere = " where OrgCode='" + ParentID + "'  and type='" + _type + "' ";
            if (isWorkflowCall)
            {

                slqwhere = slqwhere + " and  id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
              + " WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                  + " and   WorkFlowInsId !='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    // + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    // + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString()+"'"
                 + ")";
            }


            if (_type == "电容器")
            {
                slqwhere += " and year(planExpTime)=" + DateTime.Now.Year;
            }
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
            if ( parentID == null)
            {
                return;
            }
            try { frmLP.ReadTaskData(newobj, RecordWorkFlowData, ParentTemple, CurrRecord); } catch { }
           
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
                if (!string.IsNullOrEmpty(value) )
                {
                    RefreshData(" where OrgCode='" + value + "'  and type='" + _type + "' ");

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
            //if (PSObj!=null&&gridView1.RowCount>0)
            //{
            //     IList<PJ_yfsyjl> pjlist=new List<PJ_yfsyjl>();
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        pjlist.Add(gridView1.GetRow(i) as PJ_yfsyjl);
            //    }
            //    Export14.ExportExcel(PSObj, pjlist);
            //}
            IList<PJ_yfsyjl> datalist = gridView1.DataSource as IList<PJ_yfsyjl>;

            Export11 export = new Export11();
            export.CurrRecord = currRecord;
            export.IsWorkflowCall = isWorkflowCall;
            export.ParentTemple = parentTemple;
            export.RecordWorkFlowData = WorkFlowData;
            switch (_type)
            {
                case "变压器":
                    export.ExportExcelbyqssqk(datalist, _type + "预防性试验实施情况记录", parentID);
                    break;
                case "断路器":
                    export.ExportExceldlqssqk(datalist, _type + "预防性试验实施情况记录", parentID);
                    break;
                case "避雷器":
                    export.ExportExcelblqssqk(datalist, _type + "预防性试验实施情况记录", parentID);
                    break;
                case "电容器":
                    export.ExportExceldrqssqk(datalist, _type + "预防性试验实施情况记录", parentID);
                    break;
            }


        }

        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            PJ_yfsyjl ob = gridView1.GetFocusedRow() as PJ_yfsyjl;
            //lgmqxlast
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(ob.ID);
            ob.gdstemp = ParentObj.OrgCode;
            if (tempobj != null)
            {
                
                ob.xlid = tempobj.xlid;
                ob.xlname = tempobj.xlname;
                ob.tqid = tempobj.tqid;
                ob.tqname = tempobj.tqname;
                ob.byqid = tempobj.byqid;
                ob.byqname = tempobj.byqname;
                ob.kgid = tempobj.kgid;
                ob.kgname = tempobj.kgname;
            }
            switch (_type)
            {
                case "变压器":
                case "断路器":
                case "避雷器":
                    frmtestRecordsyqkEdit fm = new frmtestRecordsyqkEdit();
                    fm.Type = _type;
                    fm.RowData = ob;
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(ob);
                        Addqxmx(ob);
                    }
                    break;

                case "电容器":
                    frmtestRecorddrqsyqkEdit fm2 = new frmtestRecorddrqsyqkEdit();
                    fm2.Type = _type;
                    fm2.RowData = ob;
                    if (fm2.ShowDialog() == DialogResult.OK)
                    {
                        MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(ob);
                        Addqxmx(ob);
                    }
                    break;
            }
           
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
                        if (tempobj==null||tempobj.xcr==string.Empty)
                        {
                            MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                            PJ_qxfl mx = new PJ_qxfl();
                            mx.ID = obj.ID;
                            mx.OrgCode = obj.OrgCode;
                            mx.OrgName = obj.OrgName;
                            mx.LineID = "01";
                            mx.LineName = obj.sbInstallAdress;
                            mx.xlqd = obj.sbInstallAdress;
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
                        if (tempobj!= null && tempobj.xcr ==string.Empty)
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
                            mx.xlqd = obj.sbInstallAdress;
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
                            mx.xlqd = obj.sbInstallAdress;
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
                            mx.xlqd = obj.sbInstallAdress;
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
    }
}
