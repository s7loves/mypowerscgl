using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Sbgl
{
    public partial class UCPS_XS : DevExpress.XtraEditors.XtraUserControl
    {
        UCxsTree scLeft;
        Control scright;
        public UCPS_XS()
        {
            InitializeComponent();
            InitFrom();
        }
        void InitFrom()
        {
            scLeft = new UCxsTree();
            scLeft.Parent = splitContainerControl1.Panel1;
            scLeft.Dock = DockStyle.Fill;
            scLeft.LineSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_xl>(scLeft_LineSelectionChanged);
            scLeft.DxxhSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_dxxh>(scLeft_DxxhSelectionChanged);
            scLeft.ByqxhSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_byqxh>(scLeft_ByqxhSelectionChanged);
        }
        protected override void OnLoad(EventArgs e)
        {           
            base.OnLoad(e);
        }
        void scLeft_ByqxhSelectionChanged(object sender, Ebada.Scgl.Model.PS_byqxh obj)
        {
            
            scright = new UCPsbyqxhSelect();
            scright.Visible = false;
            scright.Parent = splitContainerControl1.Panel2;
            (scright as UCPsbyqxhSelect).ParentObj = obj;
            scright.Dock = DockStyle.Fill;
            scright.Visible = true;           
        }

        void scLeft_DxxhSelectionChanged(object sender, Ebada.Scgl.Model.PS_dxxh obj)
        {
            
            scright = new UCPsdxxhSelect();
            scright.Visible = false;
            scright.Parent = splitContainerControl1.Panel2;
            (scright as UCPsdxxhSelect).ParentObj = obj;
            scright.Dock = DockStyle.Fill;
            scright.Visible = true;
        }

        void scLeft_LineSelectionChanged(object sender, Ebada.Scgl.Model.PS_xl obj)
        {
            
            scright = new UCPS_xlSelect();
            scright.Visible = false;
            (scright as UCPS_xlSelect).ParentObj = obj;
            scright.Parent = splitContainerControl1.Panel2;
            scright.Dock = DockStyle.Fill;
            scright.Visible = true;
        }
    }
}
