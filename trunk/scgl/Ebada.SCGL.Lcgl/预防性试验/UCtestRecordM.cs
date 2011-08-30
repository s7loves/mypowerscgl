using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Lcgl
{
    public partial class UCtestRecordM : UserControl
    {
        public UCtestRecordM()
        {
            InitializeComponent();
        }

        private void UCtestRecordM_Load(object sender, EventArgs e)
        {
            uCtestRecord1.Type = "变压器";
            uCtestRecord2.Type = "断路器";
            uCtestRecord3.Type = "避雷器";
            uCtestRecord1.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged); 
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + uCtestRecord1.btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                uCtestHCRecord1.ParentObj= org;
            }


        }
    }
}
