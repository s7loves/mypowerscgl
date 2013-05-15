using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Core;
using Ebada.Scgl.Model;
using Ebada.Client;

namespace Ebada.Scgl.Gis
{
    public partial class frmChooseBD_SBTZ : Ebada.UI.Base.FormBase
    {
        public frmChooseBD_SBTZ()
        {
            InitializeComponent();
            lookUpEdit1.Properties.DisplayMember = "a2";
            lookUpEdit1.Properties.ValueMember = "sb_id";
            lookUpEdit1.Properties.NullText = "";
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("a2", lookUpEdit1.Width, "请选择设备"));
        }

        public string OrgCode { get; set; }
        public string MC { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public string sb_id
        {
            get
            {
                return lookUpEdit1.EditValue.ToString();
            }
        }

        private void frmChooseBD_SBTZ_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = Client.ClientHelper.PlatformSqlMap.GetList<BD_SBTZ>(" where orgcode='" + OrgCode + "' and sbtype=(select dm from BD_SBTZ_ZL where mc='" + MC + "')");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBox.ShowWarningMessageBox("请选择设备！");
            }
        }
    }
}