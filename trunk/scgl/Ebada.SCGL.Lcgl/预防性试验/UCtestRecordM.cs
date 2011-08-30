using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using DevExpress.XtraBars;

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
            uCtestRecord4.Type = "电容器";
            uCtestRecord1.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            uCtestRecord2.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            uCtestRecord3.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            uCtestRecord4.btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
        }
        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem btGdsList = (BarEditItem)sender;
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                uCtestHCRecord1.ParentObj= org;
                uCtestRecord1.btGdsList.EditValue = org.OrgCode ;
                uCtestRecord2.btGdsList.EditValue = org.OrgCode;
                uCtestRecord3.btGdsList.EditValue = org.OrgCode;
                uCtestRecord4.btGdsList.EditValue = org.OrgCode;
            }


        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Text.IndexOf("变压器") > 0)
            {
                uCtestHCRecord1.Type = "变压器";
            }
            else if (e.Page.Text.IndexOf("断路器") > 0)
            {
                uCtestHCRecord1.Type = "断路器";
            }
            else if (e.Page.Text.IndexOf("避雷器") > 0)
            {
                uCtestHCRecord1.Type = "避雷器";
            }
            else if (e.Page.Text.IndexOf("电容器") > 0)
            {
                uCtestHCRecord1.Type = "电容器";
            }
            //else
            //    uCtestHCRecord1.Type = null;


        }
    }
}
