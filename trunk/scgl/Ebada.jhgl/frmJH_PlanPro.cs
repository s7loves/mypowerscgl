using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;

namespace Ebada.jhgl
{
    public partial class frmJH_PlanPro :FormBase
    {
        public string year;
        public string orgcode;
        public string planPro;
        public frmJH_PlanPro()
        {
            InitializeComponent();
        }

        void ucworkcontent_GridviewDoubleClick(object sender, string planPro)
        {
            this.planPro = planPro;
            this.DialogResult = DialogResult.OK;
        }

        private void frmJH_WorkContent_Load(object sender, EventArgs e)
        {
            this.Text = year + "年周计划项目";
            UCJH_PlanPro ucworkcontent = new UCJH_PlanPro();
            ucworkcontent.Dock = DockStyle.Fill;
            ucworkcontent.year = year;
            ucworkcontent.orgcode = orgcode;
            this.Controls.Add(ucworkcontent);
            ucworkcontent.GridviewDoubleClick += new UCJH_PlanPro.GridviewDoubleClickHandler(ucworkcontent_GridviewDoubleClick);
           
        }
    }
}