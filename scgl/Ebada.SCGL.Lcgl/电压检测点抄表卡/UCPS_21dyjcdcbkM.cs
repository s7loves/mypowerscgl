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
    [ToolboxItem(false)]
    public partial class UCPS_21dyjcdcbkM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_21dyjcdcbkM()
        {
            InitializeComponent();
            up.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_21dyjcdcbk>(up_FocusedRowChanged);
        }

        void up_FocusedRowChanged(object sender, PJ_21dyjcdcbk obj)
        {
            if (obj!=null)
            {
                down.ParentID = obj.ID;
                down.ParentObj = obj;
            }
            
        }

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_21dyjcdcbk,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                up.ReadOnly = value;
                down.ReadOnly = value;

            }
        }

        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                up.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                up.IsWorkflowCall = value;
               
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                up.CurrRecord = value;
              
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
                up.RecordWorkFlowData = value;
                
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                up.VarDbTableName = value;
            }
        }


        
    }
}
