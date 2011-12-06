using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCPS_byqM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_byqM()
        {
            InitializeComponent();
            ucpS_tqbyq1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_tqbyq>(ucpS_tqbyq1_FocusedRowChanged);
        }

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PS_tqbyq,LP_Record";
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
                ucpS_tqbyq1.IsWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucpS_tqbyq1.CurrRecord = value;

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
                ucpS_tqbyq1.RecordWorkFlowData = value;
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
                ucpS_tqbyq1.VarDbTableName = value;
            }
        }


        void ucpS_tqbyq1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_tqbyq obj)
        {
            splitCC1.Panel2.Text = "变压器：" + (obj != null ? obj.byqName : "");
            ucpJ_11byqbd1.ParentObj = ucpS_tqbyq1.ParentObj;
            ucpJ_11byqbd1.PSObj = obj;
            ucpJ_11byqdy1.ParentObj = ucpS_tqbyq1.ParentObj;
            ucpJ_11byqdy1.PSObj = obj;
            ucpJ_11byqdzcl1.ParentObj = ucpS_tqbyq1.ParentObj;
            ucpJ_11byqdzcl1.PSObj = obj;


        }
    }
}
