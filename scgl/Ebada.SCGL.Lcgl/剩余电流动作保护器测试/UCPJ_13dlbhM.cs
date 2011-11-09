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

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_13dlbhM : DevExpress.XtraEditors.XtraUserControl {
        /// <summary>
        /// 
        /// </summary>

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PS_tqdlbh,PJ_13dlbhjl,LP_Record";
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
        public UCPJ_13dlbhM()
        {
            InitializeComponent();
            //接收行焦点改变事件
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PS_tqdlbh>(ucTop_FocusedRowChanged);
        }

        void ucTop_FocusedRowChanged(object sender, PS_tqdlbh obj)
        {
            ucBottom.ParentObj = obj;
            if (ucTop.gds!=null)
            {
                ucBottom.gds = ucTop.gds;
            }
            
            splitCC1.Panel2.Text = " " + (obj != null ? obj.tqName : "");
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
        }

    }
}
