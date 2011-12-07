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
    public partial class UCPJ_07jdzzM : DevExpress.XtraEditors.XtraUserControl
    {

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_07jdzz,PJ_07jdzzjl,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucTop.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucTop.IsWorkflowCall = value;


            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucTop.CurrRecord = value;

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
                ucTop.RecordWorkFlowData = value;

            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucTop.VarDbTableName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public UCPJ_07jdzzM()
        {
            InitializeComponent();
            //接收行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_07jdzz>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PJ_07jdzz obj)
        {
            ucBottom.ParentObj = obj;
            splitCC1.Panel2.Text = " " + (obj != null ? obj.OrgName : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            splitCC1.Panel1.Text = "接地装置";
            splitCC1.Panel1.Text = "接地装置检测记录";
        }


    }
}
