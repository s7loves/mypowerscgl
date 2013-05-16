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
    public partial class frmJH_WorkContent :FormBase
    {
        public string year;
        public string orgcode;
        public string content;
        public frmJH_WorkContent()
        {
            InitializeComponent();
        }

        void ucworkcontent_GridviewDoubleClick(object sender, string content)
        {
            this.content = content;
            this.DialogResult = DialogResult.OK;
        }

        private void frmJH_WorkContent_Load(object sender, EventArgs e)
        {
            this.Text = year + "年周工作内容";
            UCJH_WorkContent ucworkcontent = new UCJH_WorkContent();
            ucworkcontent.Dock = DockStyle.Fill;
            ucworkcontent.year = year;
            ucworkcontent.orgcode = orgcode;
            this.Controls.Add(ucworkcontent);
            ucworkcontent.GridviewDoubleClick += new UCJH_WorkContent.GridviewDoubleClickHandler(ucworkcontent_GridviewDoubleClick);
           
        }
    }
}