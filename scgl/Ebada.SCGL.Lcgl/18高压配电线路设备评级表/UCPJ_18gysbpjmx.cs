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
using Ebada.Components;
using System.Threading;
using Ebada.Scgl.WFlow;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_18gysbpjmx : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_18gysbpjmx> gridViewOperation;

        public event SendDataEventHandler<PJ_18gysbpjmx> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private PJ_18gysbpj _parentobj;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_18gysbpjmx,LP_Record";
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
      
        public UCPJ_18gysbpjmx()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_18gysbpjmx>(gridControl1, gridView1, barManager1,new frm18gysbpjmxEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_18gysbpjmx>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_18gysbpjmx>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_18gysbpjmx>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_18gysbpjmx>(gridViewOperation_AfterDelete);
        }
        void gridViewOperation_AfterDelete(PJ_18gysbpjmx obj)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.PJ_ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
            IList<PJ_18gysbpjmx> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_18gysbpjmx>(" where PJ_ID='" + PSObj.PJ_ID + "' order by xh ");
            List<PJ_18gysbpjmx> list2 = new List<PJ_18gysbpjmx>();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].xh = i;
            }
            list2.AddRange (list);
            try
            {
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                
                if (list.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, list2.ToArray());
                    list3.Add(obj3);
                }

                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
                RefreshData(" where PJ_ID='" + PSObj.PJ_ID + "' order by xh ");

            }
            catch (Exception exception)
            {
                MainHelper.ShowWarningMessageBox(exception.Message);
               
            }
        }
        void gridViewOperation_AfterAdd(PJ_18gysbpjmx obj)
        {
            //RefreshData(" where PJ_ID='" + PSObj.PJ_ID + "' order by id desc");
            RefreshData(" where PJ_ID='" + PSObj.PJ_ID + "' order by xh ");

            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = obj.PJ_ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = obj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
                PJ_qxfl qxfj = new PJ_qxfl();
                qxfj.CreateDate = PSObj.CreateDate;
                qxfj.CreateMan = PSObj.CreateMan;
                qxfj.LineID ="";
                qxfj.LineName ="";
                qxfj.OrgCode = PSObj.OrgCode;
                qxfj.OrgName = PSObj.OrgName;
                qxfj.qxlb = obj.qxlb;
                qxfj.qxly = "高压配电设备评级表";
                qxfj.qxnr = obj.qxnr;
                qxfj.xcqx = "";
                qxfj.xcr = "";
                qxfj.xlqd = "";
                qxfj.xsr = "";
                qxfj.xssj = new DateTime(1900, 1, 1);
                MainHelper.PlatformSqlMap.Create<PJ_qxfl>(qxfj);
                LP_Record lpr = new LP_Record();
                lpr.ID = "N" + lpr.CreateID();
                lpr.Kind = "设备缺陷管理流程";
                lpr.CreateTime = DateTime.Now.ToString();
                lpr.OrgName = qxfj.OrgName;

                string[] strtemp = RecordWorkTask.RunNewGZPRecord(lpr.ID, "设备缺陷管理流程", MainHelper.User.UserID, false);
                if (strtemp[0].IndexOf("未提交至任何人") > -1)
                {
                    MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                    return;
                }
                DataTable recordWorkFlowData = RecordWorkTask.GetRecordWorkFlowData(lpr.ID, MainHelper.User.UserID);
                if (recordWorkFlowData == null)
                {
                    MsgBox.ShowWarningMessageBox("出错，未找到该流程信息，请检查模板设置!");

                }
                LP_Temple ParentTemple = RecordWorkTask.GetWorkTaskTemple(recordWorkFlowData, lpr);
                if (ParentTemple == null)
                    lpr.Number = RecordWorkTask.CreatWorkFolwNo(MainHelper.UserOrg, "");
                else
                    lpr.Number = RecordWorkTask.CreatWorkFolwNo(MainHelper.UserOrg, ParentTemple.LPID);
                lpr.Status = recordWorkFlowData.Rows[0]["TaskCaption"].ToString();
                MainHelper.PlatformSqlMap.Create<LP_Record>(lpr);
                currRecord = lpr;
                WorkFlowData = recordWorkFlowData;

              

                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ID = mrwt.CreateID();
                mrwt.ModleRecordID = qxfj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = qxfj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }
        }
      
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_18gysbpjmx> e)
        {
           
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_18gysbpjmx> e)
        {
            if (PSObj == null)
                e.Cancel = true;
            object ob = Client.ClientHelper.PlatformSqlMap.GetObject("GetPJ_18gysbpjmxRowCount", " where PJ_ID='" +e.Value.PJ_ID  + "'");
           e.Value.xh = Convert.ToInt32(ob);  
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //InitColumns();//初始列
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

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            //IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            //mOrg org=null;
            //if (list.Count > 0)
            //    org = list[0];
            
            //if (org != null)
            //{
            //    ParentObj = org;
            //    if (SelectGdsChanged != null)
            //        SelectGdsChanged(this, org);
            //}
            

        }
        public PJ_18gysbpj PSObj
        {
            get { return _parentobj; }
            set
            {
                _parentobj = value;
                if (PSObj != null)
                {
                    RefreshData(" where PJ_ID='" + value.PJ_ID + "'  order by id desc");
                }
                else
                {
                    RefreshData(" where PJ_ID='   ###@@@#'  order by id desc");
                }

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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_18gysbpjmx);
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

            //hideColumn("OrgCode");
            hideColumn("gzrjID");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_18gysbpjmx> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_18gysbpjmx newobj)
        {
            if (PSObj == null) return;
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            newobj.PJ_ID = PSObj.PJ_ID;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
        }
      
        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridView1.RowCount>0)
            //{
            //     IList<PJ_18gysbpjmx> pjlist=new List<PJ_18gysbpjmx>();
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        pjlist.Add(gridView1.GetRow(i) as PJ_18gysbpjmx);
            //    }
            //   Export18.ExportExcel(pjlist);
            //}
           
           
        }
    }
}
