using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmsjEdit : FormBase
    {
        public frmsjEdit()
        {
            InitializeComponent();
        }

        private DateTime createtime;
        public DateTime CreateTime
        {
            get
            {
                return createtime;
            }
            set
            {
                createtime = value;
            }
        }

        private void frmsjEdit_Load(object sender, EventArgs e)
        {
            this.dateCreateTime.EditValue = createtime;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dateCreateTime.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择时间!");
                return;
            }
            createtime = Convert.ToDateTime(dateCreateTime.EditValue);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}