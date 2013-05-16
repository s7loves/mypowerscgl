using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;

namespace Ebada.Scgl.Gis 
{
    public partial class frmMapXlt : FormBase
    {
        /// <summary>
        /// 变电站Code
        /// </summary>
        public string OrgCode
        {
            set
            {
                ucXianLuTu1.OrgCode = value;
            }
        }

        public frmMapXlt()
        {
            InitializeComponent();
        }
    }
}