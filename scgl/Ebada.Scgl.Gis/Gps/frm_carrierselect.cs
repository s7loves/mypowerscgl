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
           
        }

        private string zttype;
        public string ZtType
        {
            get
            {
                return zttype;
            }
            set
            {
                zttype = value;
            }
        }

        private string plate;
        public string Plate
        {
            get
            {
                return plate;
            }
        }
        private string carrierid;
        public string CarrierID
        {
            get
            {
                return carrierid;
            }
        }

        void carrier_GridDoubleClickEvent(object obj, gps_carrier carrier)
        {
            
            plate = carrier.plate;//车牌号或者人名
            carrierid = carrier.carrier_id;
            if (carrierid == null)
                return;
            this.DialogResult = DialogResult.OK;

        }

        private void frm_carrierselect_Load(object sender, EventArgs e)
        {
            UCgps_carrier carrier = new UCgps_carrier();
            carrier.ctype = zttype;
            carrier.GridDoubleClickEvent += new UCgps_carrier.GridviewDoubleClick(carrier_GridDoubleClickEvent);
            carrier.Dock = DockStyle.Fill;
            carrier.isbarvisible = false;
            this.Controls.Clear();
            this.Controls.Add(carrier);
        }
    }
}