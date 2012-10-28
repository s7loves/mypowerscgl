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

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCtestdrqRecord : DevExpress.XtraEditors.XtraUserControl
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
        public UCtestdrqRecord()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_yfsyjl>(gridControl1, gridView1, barManager1, new frmtestRecorddrqEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_yfsyjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterEdit);
        }
        void gridViewOperation_AfterEdit(PJ_yfsyjl obj)
        {
            RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "' ");
        
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
            int i=0;
            List<PJ_yfsyjl> list = new List<PJ_yfsyjl>();
            int xh = -1;
            foreach (PJ_yfsyjl ob in li)
            {
                if (xh != ob.xh)
                {
                    i++;
                    xh = ob.xh;
                }
                ob.xh = i;
               
                list.Add(ob); 
            }
            List<SqlQueryObject> list3 = new List<SqlQueryObject>();
            if (list.Count > 0)
            {
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list.ToArray ());
                list3.Add(obj3);
            }

            MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            RefreshData(" where OrgCode='" + obj.OrgCode + "'  and type='" + obj.type  + "'   ");
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
            //obj.xh = MainHelper.PlatformSqlMap.GetRowCount<PJ_yfsyjl>(slqwhere);
            //obj.CreateDate = DateTime.Now;
            //MainHelper.PlatformSqlMap.Update<PJ_yfsyjl>(obj);
            //if (isWorkflowCall)
            //{
            //    IList<PJ_yfsyjl> li = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", "where xh='" + obj.xh + "'and type ='" + obj.type + "' order by CreateDate");
            //     if (li.Count == 2)
            //     {

            //         WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
            //         mrwt.ModleRecordID = li[0].ID;
            //         mrwt.RecordID = currRecord.ID;
            //         mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
            //         mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
            //         mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
            //         mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
            //         mrwt.ModleTableName = obj.GetType().ToString();
            //         mrwt.CreatTime = DateTime.Now;
            //         MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            //         mrwt = new WF_ModleRecordWorkTaskIns();
            //         mrwt.ModleRecordID = li[1].ID;
            //         mrwt.RecordID = currRecord.ID;
            //         mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
            //         mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
            //         mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
            //         mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
            //         mrwt.ModleTableName = obj.GetType().ToString();
            //         mrwt.CreatTime = DateTime.Now;
            //         MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            //     }
            //}
            RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "' ");
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (_type != null )
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

                        case "电容器":
                            hideColumn("sbCapacity");
                            gridView1.OptionsView.AllowCellMerge = true; 
                           
                            break;
                    }
                    RefreshData(" where OrgCode='" + ParentID + "'  and type='" + _type + "' ");
                }

            }
        }
       
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_yfsyjl> e)
        {
            string slqwhere ="where xh='" + e.Value.xh + "'and type ='" + e.Value.type + "' ";
            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by CreateDate";
            IList<PJ_yfsyjl> li = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", slqwhere);
           if (li.Count == 2)
           {
               Client.ClientHelper.PlatformSqlMap.Delete<PJ_yfsyjl>(li[0]);
               Client.ClientHelper.PlatformSqlMap.Delete<PJ_yfsyjl>(li[1]);
           
           }
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

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
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
    }
}
