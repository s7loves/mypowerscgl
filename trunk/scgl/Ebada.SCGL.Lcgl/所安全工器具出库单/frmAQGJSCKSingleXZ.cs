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
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmAQGJSCKSingleXZ : FormBase, IPopupFormEdit
    {
        public frmAQGJSCKSingleXZ()
        {
            InitializeComponent();
        }
        private PJ_anqgjcrkd returnData = null;
        public PJ_anqgjcrkd ReturnData
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
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "cksl");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "lqdw");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "num");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "ckdate");


        }
        #region IPopupFormEdit Members
        private PJ_anqgjcrkd rowData = null;

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
                    this.rowData = value as PJ_anqgjcrkd;
                   
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_anqgjcrkd>(value as PJ_anqgjcrkd, rowData);
                }

            }
        }

        #endregion

        private void frmCLCKXZ_Load(object sender, EventArgs e)
        {
            if (rowData.kcsl == "") rowData.kcsl = "0";
            if (rowData.kcsl != "0")
                spinEdit2.Properties.MaxValue = Convert.ToDecimal(rowData.kcsl);
            else
            {
                spinEdit2.Properties.MaxValue = Convert.ToDecimal(0.0001);
            }

            comboBoxEdit6.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select UserName   from mUser where OrgName = '" + rowData.OrgName + "' ");
            comboBoxEdit6.Properties.Items.AddRange(mclist);

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (returnData == null) returnData = new PJ_anqgjcrkd();
            ConvertHelper.CopyTo<PJ_anqgjcrkd>(rowData, returnData);
        }

        private void comboBoxEdit6_TextChanged(object sender, EventArgs e)
        {
            mOrg org = ClientHelper.PlatformSqlMap.GetOne<mOrg>(" where orgname = '" + comboBoxEdit6.Text + "' ");
            if (org != null)
            {
                rowData.OrgCode = org.OrgCode;
            }
        }

        

        

       
      


       
    }
}
