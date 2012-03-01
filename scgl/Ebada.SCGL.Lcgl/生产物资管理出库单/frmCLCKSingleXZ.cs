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
    public partial class frmCLCKSingleXZ : FormBase, IPopupFormEdit
    {
        public frmCLCKSingleXZ()
        {
            InitializeComponent();
        }
        private PJ_clcrkd returnData = null;
        public PJ_clcrkd ReturnData
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

        void dataBind()
        {
            
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wpmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "wpgg");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "kcsl");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "ssxm");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "yt");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "cksl");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "ssgc");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "num");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");


        }
        #region IPopupFormEdit Members
        private PJ_clcrkd rowData = null;

        public object RowData
        {
            get
            {

                return rowData;

            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as PJ_clcrkd;
                   
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_clcrkd>(value as PJ_clcrkd, rowData);
                }

            }
        }

        #endregion

        private void frmCLCKXZ_Load(object sender, EventArgs e)
        {
            spinEdit2.Properties.MaxValue =Convert.ToDecimal( rowData.kcsl);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (returnData == null) returnData = new PJ_clcrkd();
            ConvertHelper.CopyTo<PJ_clcrkd>(rowData, returnData);
        }

       
      


       
    }
}
