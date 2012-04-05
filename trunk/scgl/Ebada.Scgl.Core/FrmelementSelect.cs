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

namespace Ebada.Scgl.Core
{
    public partial class FrmelementSelect : FormBase
    {
        public FrmelementSelect()
        {
            InitializeComponent();
        }
        public PanelControl control
        {
            get
            {
                return panelControl1;
            }
        }
    }
}