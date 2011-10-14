using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using DevExpress.XtraBars;
using Ebada.Client;
using Ebada.UI.Base;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCtestRecordM : UserControl
    {
        public UCtestRecordM()
        {
            InitializeComponent();
        }
        private bool isWorkfowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_yfsyjl,PJ_yfsyhcjl,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                uCtestRecord1.ParentTemple = value;
                uCtestRecordssqkTable1.ParentTemple = value;
            }
        }
        public bool IsWorkfowCall
        {
            set {

                isWorkfowCall = value;
                uCtestRecord1.IsWorkfowCall = value;
                uCtestRecordssqkTable1.IsWorkfowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                uCtestRecord1.CurrRecord = value;
                uCtestRecordssqkTable1.CurrRecord = value;
            
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
                uCtestRecord1.RecordWorkFlowData = value;
                uCtestRecordssqkTable1.RecordWorkFlowData = value;


            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                uCtestRecordssqkTable1.VarDbTableName = value;
            }
        }
        private void UCtestRecordM_Load(object sender, EventArgs e)
        {
            uCtestRecord1.Type = "变压器";
            uCtestRecord2.Type = "断路器";
            uCtestRecord3.Type = "避雷器";
            uCtestRecord4.Type = "电容器";
            uCtestRecordjhmxTable1.Type = "变压器";
            uCtestRecordssqkTable1.Type = "变压器";
            uCtestRecordwcqkTable1.Type = "变压器";
            uCtestRecord1.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            uCtestRecord2.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            uCtestRecord3.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            uCtestRecord4.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);

            uCtestRecord1.gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            uCtestRecord2.gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            uCtestRecord3.gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);
            uCtestRecord4.gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterAdd);

            uCtestRecord1.gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
            uCtestRecord2.gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
            uCtestRecord3.gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);
            uCtestRecord4.gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterDelete);

            uCtestRecord1.gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterEdit);
            uCtestRecord2.gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterEdit);
            uCtestRecord3.gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterEdit);
            uCtestRecord4.gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_yfsyjl>(gridViewOperation_AfterEdit);

            uCtestRecordjhmxTable1.btReEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btReEdit_ItemClick);
            uCtestRecordssqkTable1.btReEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btReEdit_ItemClick);
            uCtestRecordwcqkTable1.btReEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btReEdit_ItemClick);
        }
        private void btReEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uCtestRecordRefreshData();
        }
        void uCtestRecordRefreshData()
        {
            uCtestRecordjhmxTable1.RefreshData();
            uCtestRecordssqkTable1.RefreshData();
            uCtestRecordwcqkTable1.RefreshData();

            uCtestRecord1.RefreshData();
            uCtestRecord2.RefreshData();
            uCtestRecord3.RefreshData();
            uCtestRecord4.RefreshData();
        }
        void gridViewOperation_AfterEdit(PJ_yfsyjl obj)
        {
            uCtestRecordRefreshData();
        }
        void gridViewOperation_AfterDelete(PJ_yfsyjl obj)
        {
            uCtestRecordRefreshData();
        }
        void gridViewOperation_AfterAdd(PJ_yfsyjl obj)
        {
            uCtestRecordRefreshData();
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem btGdsList = (BarEditItem)sender;
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                uCtestHCRecord1.ParentObj= org;
                uCtestRecordjhmxTable1.ParentObj = org;
                uCtestRecordssqkTable1.ParentObj = org;
                uCtestRecordwcqkTable1.ParentObj = org;
                uCtestRecord1.btGdsList.EditValue = org.OrgCode ;
                uCtestRecord2.btGdsList.EditValue = org.OrgCode;
                uCtestRecord3.btGdsList.EditValue = org.OrgCode;
                uCtestRecord4.btGdsList.EditValue = org.OrgCode;
            }


        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == null) return;
            if (e.Page.Text.IndexOf("变压器") > -1)
            {
                uCtestHCRecord1.Type = "变压器";
                uCtestRecordjhmxTable1.Type = "变压器";
                uCtestRecordssqkTable1.Type = "变压器";
                uCtestRecordwcqkTable1.Type = "变压器";
            }
            else if (e.Page.Text.IndexOf("断路器") > -1)
            {
                uCtestHCRecord1.Type = "断路器";
                uCtestRecordjhmxTable1.Type = "断路器";
                uCtestRecordssqkTable1.Type = "断路器";
                uCtestRecordwcqkTable1.Type = "断路器";
            }
            else if (e.Page.Text.IndexOf("避雷器") > -1)
            {
                uCtestHCRecord1.Type = "避雷器";
                uCtestRecordjhmxTable1.Type = "避雷器";
                uCtestRecordssqkTable1.Type = "避雷器";
                uCtestRecordwcqkTable1.Type = "避雷器";
            }
            else if (e.Page.Text.IndexOf("电容器") > -1)
            {
                uCtestHCRecord1.Type = "电容器";
                uCtestRecordjhmxTable1.Type = "电容器";
                uCtestRecordssqkTable1.Type = "电容器";
                uCtestRecordwcqkTable1.Type = "电容器";
            }
            //else
            //    uCtestHCRecord1.Type = null;


        }
    }
}
