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
    public partial class frm_WhddSelect : FormBase 
    {
        public frm_WhddSelect()
        {
            InitializeComponent();
            this.ucsD_whdd1.btnOkClick += new SendDataEventHandler<sdjls_xlwhqd>(ucsD_whdd1_btnOkClick);
        }
        public void SetLineCode(string linecode)
        {
            this.ucsD_whdd1.ParentID = linecode;
        }
        void ucsD_whdd1_btnOkClick(object sender, sdjls_xlwhqd obj)
        {
            if (obj == null)
                return;
            whqd = obj;
            this.DialogResult = DialogResult.OK;
        }
        private sdjls_xlwhqd whqd;
        public sdjls_xlwhqd Whqd
        {
            get
            {
                return whqd;
            }
            set
            {
                if (value == null) return;
                if (whqd == null)
                {
                    this.whqd = value as sdjls_xlwhqd;
                    
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_xlwhqd>(value as sdjls_xlwhqd, whqd);
                }
            }
        }
    }
}