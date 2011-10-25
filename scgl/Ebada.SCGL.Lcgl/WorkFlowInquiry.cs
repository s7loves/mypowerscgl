using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using System.Collections;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    public partial class WorkFlowInquiry : FormBase
    {
        public WorkFlowInquiry()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        private void IniData()
        {
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select FlowCaption from WF_WorkFlow  where 1=1");
            cbeWorkFlowCaption.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgName  from mOrg  where 1=1");
            cbeOrg.Properties.Items.AddRange(li);
        }
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            IniData();
        }

        private void cbeWorkFlowCaption_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select WorkFlowId from WF_WorkFlow  where FlowCaption='"+cbeWorkFlowCaption.Text+"'");
            if (obj != null) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select TaskCaption from WF_WorkTask  where WorkFlowId='" + obj + "'");
            cbeStatus.Properties.Items.AddRange(li);

        }

       
    }
}
