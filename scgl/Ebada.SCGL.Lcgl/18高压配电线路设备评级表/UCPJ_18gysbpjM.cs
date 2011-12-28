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
    public partial class UCPJ_18gysbpjM : DevExpress.XtraEditors.XtraUserControl
    {

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_18gysbpj,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucpJ_18gysbpj1.ParentTemple = value;

            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucpJ_18gysbpj1.IsWorkflowCall = value;



            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucpJ_18gysbpj1.CurrRecord = value;

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
                ucpJ_18gysbpj1.RecordWorkFlowData = value;
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucpJ_18gysbpj1.VarDbTableName = value;
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_18gysbpjM()
        {
            InitializeComponent();
            ////接收行焦点改变事件
            ucpJ_18gysbpj1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_18gysbpj>(ucpJ_18gysbpj1_FocusedRowChanged);            
        }

        void ucpJ_18gysbpj1_FocusedRowChanged(object sender, PJ_18gysbpj obj)
        {
            ucpJ_18gysbpjmx1.PSObj = obj;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
