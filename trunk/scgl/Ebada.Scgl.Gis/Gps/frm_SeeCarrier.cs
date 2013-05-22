using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;


namespace Ebada.Scgl.Gis.Gps
{
    public partial class frm_SeeCarrier : FormBase
    {
        public string carrier_id;

        public frm_SeeCarrier()
        {
            InitializeComponent();
            
        }

        private void frm_SeeCarrier_Load(object sender, EventArgs e)
        {
            UCgps_SeeCarrier seeCarrier = new UCgps_SeeCarrier();
            seeCarrier.carrier_id = carrier_id;
            seeCarrier.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(seeCarrier);
        }
    }
}