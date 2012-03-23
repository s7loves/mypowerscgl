using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Core;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmWGGCCLDShow : FormBase
    {
        public frmWGGCCLDShow()
        {
            InitializeComponent();
        }
        private PJ_wgclcrkd returnData = null;
        public PJ_wgclcrkd ReturnData
        {
            get
            {

                return returnData;

            }
            set
            {

                returnData = value  ;
                

            }
        }
        private string type = null;
        public string strType
        {
            get
            {

                return type;

            }
            set
            {

                type = value;


            }
        }
        private string num = null;
        public string strNum
        {
            get
            {

                return num;

            }
            set
            {

                num = value;


            }
        }

       
        #region IPopupFormEdit Members
        private IList<PJ_wgclcrkd> dataList = null;

        public IList<PJ_wgclcrkd> DataList
        {
            get
            {

                return dataList;

            }
            set
            {
                if (value == null) return;

                dataList = value;
                gridControl1.DataSource = dataList;  
                   
                

            }
        }

        #endregion

        private void frmCLCKXZ_Load(object sender, EventArgs e)
        {

            gridView1.Columns["num"].Width = 150;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

       
      


       
    }
}
