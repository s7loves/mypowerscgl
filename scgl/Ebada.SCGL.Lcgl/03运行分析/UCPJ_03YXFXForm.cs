using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCPJ_03YXFXForm : Form
    {
        public UCPJ_03YXFXForm()
        {
            InitializeComponent();
        }


        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_03yxfx,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
                ucpJ_03yxfx1.ParentTemple = value;
            }
        }
        public bool IsWorkflowCall
        {
            set
            {

                isWorkflowCall = value;
                ucpJ_03yxfx1.IsWorkflowCall = value;

            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set
            {
                currRecord = value;
                ucpJ_03yxfx1.CurrRecord = value;
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
                ucpJ_03yxfx1.RecordWorkFlowData = value;

                
            }
        }

        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value;
                ucpJ_03yxfx1.VarDbTableName = value;
            }
        }
        public void UCPJ_03YXFXForm_DQFX()
        {
            //InitializeComponent();
            ucpJ_03yxfx1.RecordIkind = "定期分析";
            //ucpJ_03yxfx1.InitColumns();
            //ucpJ_03yxfx1.InitData();
            this.Show();
            

        }
        public void UCPJ_03YXFXForm_ZTFX()
        {
            //InitializeComponent();
            ucpJ_03yxfx1.RecordIkind = "专题分析";
            //ucpJ_03yxfx1.InitColumns();
            //ucpJ_03yxfx1.InitData();
            this.Show() ;
           
        }

        private void UCPJ_03YXFXForm_Load(object sender, EventArgs e)
        {
            this.Text = "运行分析-" + ucpJ_03yxfx1.RecordIkind;
        }
    }
}
