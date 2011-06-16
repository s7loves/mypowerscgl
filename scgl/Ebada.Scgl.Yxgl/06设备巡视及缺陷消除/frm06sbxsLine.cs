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
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
namespace Ebada.Scgl.Yxgl
{
    public partial class frm06sbxsLine : FormBase {
       
        public frm06sbxsLine() {
            InitializeComponent();
        }
        public string orgcode = "";
        public string linename = "";
        private void frm06sbxsLine_Load(object sender, EventArgs e)
        {

            ICollection linelist = ComboBoxHelper.GetGdsxl(orgcode);//获取供电线路名称
            //线路名称
            comboBoxEdit1.Properties.Items.AddRange(linelist);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            linename = comboBoxEdit1.EditValue.ToString();
        }
      
      
      
    }
}