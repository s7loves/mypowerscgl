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
    public partial class frmSDyxfa : FormBase
    {
        public sdjls_fsgyxfa yxfa;
        public frmSDyxfa()
        {
            InitializeComponent();
            this.ucsD_yxfa1.btOkClick += new SendDataEventHandler<sdjls_fsgyxfa>(ucsD_yxfa1_btOkClick);
        }

        void ucsD_yxfa1_btOkClick(object sender, sdjls_fsgyxfa obj)
        {
            if (obj != null)
            {
                yxfa = obj;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}