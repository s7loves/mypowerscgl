using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCmLPInquiryModleRecord : DevExpress.XtraEditors.XtraUserControl
    {

        public UCmLPInquiryModleRecord()
        {
            InitializeComponent();
        }

        private  string tableName;
        public  string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }
        private  string keyobj;
        public  string Keyobj
        {
            get
            {
                return keyobj;
            }
            set
            {
                keyobj = value;
            }
        }
    }
}
