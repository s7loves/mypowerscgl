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
        UCPS_xl scrightxl;
        UCPsdxxhSelect scrightdxxh;  
        UCPsbyqxhSelect scrightbyqxh;
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
            scrightdxxh = new UCPsdxxhSelect();
            scrightdxxh.Parent = splitContainerControl1.Panel2;   
            scrightdxxh.Dock = DockStyle.Fill;
            scrightdxxh.Visible = false;
            scrightxl = new UCPS_xl();
            scrightxl.HideList();
            scrightxl.Parent = splitContainerControl1.Panel2;
            scrightxl.Dock = DockStyle.Fill;
            scrightxl.Visible = false;
            scrightbyqxh = new UCPsbyqxhSelect();
            scrightbyqxh.Parent = splitContainerControl1.Panel2;
            scrightbyqxh.Dock = DockStyle.Fill;
            scrightbyqxh.Visible = false;
            scLeft.LineSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(scLeft_LineSelectionChanged);
            scLeft.DxxhSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_dxxh>(scLeft_DxxhSelectionChanged);
            scLeft.ByqxhSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_byqxh>(scLeft_ByqxhSelectionChanged);   
         
        }
        protected override void OnLoad(EventArgs e)
        {           
            base.OnLoad(e);
        }
        void scLeft_ByqxhSelectionChanged(object sender, Ebada.Scgl.Model.PS_byqxh obj)
        {             
            scrightbyqxh.ParentObj = obj;
            scrightbyqxh.Visible = true;
            scrightdxxh.Visible = false;
            scrightxl.Visible = false;
        }

        void scLeft_DxxhSelectionChanged(object sender, Ebada.Scgl.Model.PS_dxxh obj)
        {         
            scrightdxxh.ParentObj = obj;
            scrightbyqxh.Visible = false;
            scrightdxxh.Visible = true;
            scrightxl.Visible = false;         
        }

        void scLeft_LineSelectionChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {            
            scrightxl.ParentObj = obj;
            scrightbyqxh.Visible = false;
            scrightdxxh.Visible = false;
            scrightxl.Visible = true;        
        }
    }
}
