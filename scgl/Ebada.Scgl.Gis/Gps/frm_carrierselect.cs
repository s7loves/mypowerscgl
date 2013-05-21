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

namespace Ebada.Scgl.Gis.Gps
{
    public partial class frm_carrierselect : FormBase
    {
        public frm_carrierselect()
        {
            InitializeComponent();
            UCgps_carrier carrier = new UCgps_carrier();
            carrier.GridDoubleClickEvent += new UCgps_carrier.GridviewDoubleClick(carrier_GridDoubleClickEvent);
            carrier.Dock = DockStyle.Fill;
            carrier.isbarvisible = false;
            this.Controls.Clear();
            this.Controls.Add(carrier);
        }
        private string carrierID;
        public string CarrierID
        {
            get
            {
                return carrierID;
            }
        }


        void carrier_GridDoubleClickEvent(object obj, gps_carrier carrier)
        {
            if (carrier == null)
                return;
            carrierID = carrier.carrier_id;
            this.DialogResult = DialogResult.OK;
        }
    }
}