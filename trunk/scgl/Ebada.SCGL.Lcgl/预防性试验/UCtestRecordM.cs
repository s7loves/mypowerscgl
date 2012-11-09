﻿using System;
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
    [ToolboxItem(false)]
    public partial class UCtestRecordM : UserControl
    {
        public UCtestRecordM()
        {
            InitializeComponent();
        }
        public UserControl Show(string str)
        {
            int m = 0;
            int.TryParse(str, out m);
            if (m!=0)
            {
                int top = m / 10;
                int down = m % 10;
                if (1 <= top && top <= 4)
                {
                    for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                    {
                        xtraTabControl1.TabPages[i].PageVisible = false;
                    }
                    xtraTabControl1.TabPages[top - 1].PageVisible = true;
                }
                if (1 <= down && down <= 4)
                {
                    for (int i = 0; i < xtraTabControl2.TabPages.Count; i++)
                    {
                        xtraTabControl2.TabPages[i].PageVisible = false;
                    }
                    xtraTabControl2.TabPages[down - 1].PageVisible = true;
                }
            }

            return this;
        }
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_yfsyjl,PJ_yfsyhcjl,LP_Record";

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
                uCtestRecord1.ReadOnly = value;
                uCtestRecord2.ReadOnly = value;
                uCtestRecord3.ReadOnly = value;
                uCtestRecord4.ReadOnly = value;
                uCtestRecordjhmxTable1.ReadOnly = value;
                uCtestRecordssqkTable1.ReadOnly = value;
                uCtestRecordwcqkTable1.ReadOnly = value;
                uCtestHCRecord1.ReadOnly = value;
               


            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                uCtestRecord1.ParentTemple = value;
                uCtestRecord2.ParentTemple = value;
                uCtestRecord3.ParentTemple = value;
                uCtestRecord4.ParentTemple = value;
                uCtestRecordjhmxTable1.ParentTemple = value;
                uCtestRecordssqkTable1.ParentTemple = value;
                uCtestRecordwcqkTable1.ParentTemple = value;
                uCtestHCRecord1.ParentTemple = value; 
            }
        }
        public bool IsWorkflowCall
        {
            set {

                isWorkflowCall = value;
                uCtestRecord1.IsWorkflowCall = value;
                uCtestRecord2.IsWorkflowCall = value;
                uCtestRecord3.IsWorkflowCall = value;
                uCtestRecordssqkTable1.IsWorkflowCall = value;
                uCtestRecordwcqkTable1.IsWorkflowCall = value;
                uCtestRecordjhmxTable1.IsWorkflowCall = value;
                uCtestRecord4.IsWorkflowCall = value;
                uCtestHCRecord1.IsWorkflowCall = value; 
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                uCtestRecord1.CurrRecord = value;
                uCtestRecord2.CurrRecord = value;
                uCtestRecord3.CurrRecord = value;
                uCtestRecordssqkTable1.CurrRecord = value;
                uCtestRecordwcqkTable1.CurrRecord = value;
                uCtestRecordjhmxTable1.CurrRecord = value;
                uCtestRecord4.CurrRecord = value;
                uCtestHCRecord1.CurrRecord = value; 
            
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
                uCtestRecord2.RecordWorkFlowData = value;
                uCtestRecord3.RecordWorkFlowData = value;
                uCtestRecordssqkTable1.RecordWorkFlowData = value;
                uCtestRecordwcqkTable1.RecordWorkFlowData = value;
                uCtestRecordjhmxTable1.RecordWorkFlowData = value;
                uCtestRecord4.RecordWorkFlowData = value;
                uCtestHCRecord1.RecordWorkFlowData = value;


            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                uCtestRecordssqkTable1.VarDbTableName = value;
                uCtestRecordwcqkTable1.VarDbTableName = value;
                uCtestRecord2.VarDbTableName = value;
                uCtestRecord3.VarDbTableName = value;
                uCtestRecordjhmxTable1.VarDbTableName = value;
                uCtestRecord4.VarDbTableName = value;
                uCtestHCRecord1.VarDbTableName = value;
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
