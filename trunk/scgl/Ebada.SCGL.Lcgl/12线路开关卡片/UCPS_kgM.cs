using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCPS_kgM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_kgM()
        {
            InitializeComponent();
            ucpS_kg1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_kg>(ucpS_kg1_FocusedRowChanged);
            ucpS_kg1.SelectGdsChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucpS_kg1_SelectGdsChanged);
            ucpJ_12kgbd1.HideList();
            ucpJ_12kgjx1.HideList();
            ucpJ_12kgsy1.HideList();
        }

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PS_kg,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucpS_kg1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucpS_kg1.IsWorkflowCall = value;


            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucpS_kg1.CurrRecord = value;

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
                ucpS_kg1.RecordWorkFlowData = value;
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
                ucpS_kg1.VarDbTableName = value;
            }
        }

        void ucpS_kg1_SelectGdsChanged(object sender, Ebada.Scgl.Model.mOrg obj) {
            ucpJ_12kgbd1.ParentObj = obj;
            ucpJ_12kgjx1.ParentObj = obj;
            ucpJ_12kgsy1.ParentObj = obj;
        }

        void ucpS_kg1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_kg obj)
        {
            ucpJ_12kgbd1.PSObj = obj;
            ucpJ_12kgjx1.PSObj = obj;
            ucpJ_12kgsy1.PSObj = obj;
        }

       
    }
}
