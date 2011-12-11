/**********************************************
系统:企业ERP
模块:  
作者:Rabbit
创建时间:2011-6-2
最后一次修改:2011-6-2
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_14aqgjM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_14aqgjM()
        {
            InitializeComponent();
            //接收行焦点改变事件
            ucpJ_14aqgj1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PS_aqgj>(ucpJ_14aqgj1_FocusedRowChanged);

        }

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PS_aqgj,PJ_14aqgjsy,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucpJ_14aqgj1.ParentTemple = value;
                ucpJ_14aqgjsy1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucpJ_14aqgj1.IsWorkflowCall = value;
                ucpJ_14aqgjsy1.IsWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucpJ_14aqgj1.CurrRecord = value;
                ucpJ_14aqgjsy1.CurrRecord = value;

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
                ucpJ_14aqgj1.RecordWorkFlowData = value;
                ucpJ_14aqgjsy1.RecordWorkFlowData = value;
               
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
                ucpJ_14aqgj1.VarDbTableName = value;
                ucpJ_14aqgjsy1.VarDbTableName = value;
            }
        }

        void ucpJ_14aqgj1_FocusedRowChanged(object sender, PS_aqgj obj)
        {
            ucpJ_14aqgjsy1.ParentID = "";
            ucpJ_14aqgjsy1.PSObj = null;
            ucpJ_14aqgjsy1.PSObj = obj;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
