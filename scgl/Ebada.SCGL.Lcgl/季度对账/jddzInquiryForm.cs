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
using Ebada.Scgl.WFlow;
using Ebada.Client;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.Utils;

namespace Ebada.Scgl.Lcgl
{
    public partial class jddzInquiryForm : FormBase
    {
        public jddzInquiryForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string strSQL = "where 1=1 ";
            
            int i = 0;
            WaitDialogForm wdf = new WaitDialogForm("", "正在查询数据...");
            if (comboBoxEdit4.Text == "入库")
            {
                strSQL = strSQL + " and type='入库单'  ";
            }
            if (comboBoxEdit4.Text == "出库")
            {
                strSQL = strSQL + " and type='出库单'  ";
            } 
            if (checkEdit1.Checked)
            {

                strSQL = strSQL + " and (indate between  '" + deCreatTimeStart.DateTime.ToString("d") + " 00:00:00' and '" + deCreatTimeEnd.DateTime.ToString("d") + " 23:59:59' ) ";

            }
            if (checkEdit2.Checked)
            {

                strSQL = strSQL + " and (wpmc =  '" + cbeWPMC.Text + "' ) ";

            }
            if (checkEdit3.Checked)
            {

                strSQL = strSQL + " and (wpgg =  '" + cbewpgg.Text + "' ) ";

            }
            if (checkEdit4.Checked)
            {

                strSQL = strSQL + " and (wpdw =  '" + cbewpdw.Text + "' ) ";

            }
            if (checkEdit5.Checked)
            {

                strSQL = strSQL + " and (OrgName =  '" + cbeOrg.Text + "' ) ";

            }
            strSQL = strSQL + "  order by type,indate";


            uCmjddzInquiry1.StrSQL = strSQL;
          
            wdf.Close();
        }
        
        private void IniData()
        {
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select OrgName  from mOrg  where 1=1 order by OrgCode");
            cbeOrg.Properties.Items.AddRange(li);
            if (cbeOrg.Properties.Items.Count > 0)
            {
                cbeOrg.SelectedIndex = 0;
            }
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpmc  from PJ_clcrkd  where 1=1 ");
            cbeWPMC.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpgg  from PJ_clcrkd  where 1=1 ");
            cbewpgg.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpdw  from PJ_clcrkd  where 1=1 ");
            cbewpdw.Properties.Items.AddRange(li);
            
        }
        private void WorkFlowInquiry_Load(object sender, EventArgs e)
        {
            IniData();
        }

        private void cbeWPMC_TextChanged(object sender, EventArgs e)
        {
            cbewpgg.Properties.Items.Clear();
            cbewpdw.Properties.Items.Clear();
            IList li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpgg  from PJ_clcrkd  where 1=1 and wpmc='" + cbeWPMC.Text + "' ");
            cbewpgg.Properties.Items.AddRange(li);
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select  distinct wpdw  from PJ_clcrkd  where 1=1 and wpmc='" + cbeWPMC.Text + "' ");
            cbewpdw.Properties.Items.AddRange(li);
        }

       



    
  
       

      

       
    }
}
