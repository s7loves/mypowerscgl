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
    public partial class UCPJ_06cqsbxs: DevExpress.XtraEditors.XtraUserControl
    {
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_06sbxs,PJ_06sbxsmx,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucTop.ParentTemple = value;
                ucBottom.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucTop.IsWorkflowCall = value;
                ucBottom.IsWorkflowCall = value;


            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucTop.CurrRecord = value;
                ucBottom.CurrRecord = value;

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
                ucBottom.RecordWorkFlowData = value;

            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucTop.VarDbTableName = value;
                ucBottom.VarDbTableName = value;
            }
        }
        public UCPJ_06cqsbxs()
        {
            InitializeComponent();
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_06sbxs>(ucTop_FocusedRowChanged);
        }
        void ucTop_FocusedRowChanged(object sender, PJ_06sbxs obj)
        {
            ucBottom.ParentObj = obj;
            //splitCC1.Panel2.Text = "测量记录：" + (obj != null ? obj.kymc : "");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ucTop.initcomment();
        }
    }
}
