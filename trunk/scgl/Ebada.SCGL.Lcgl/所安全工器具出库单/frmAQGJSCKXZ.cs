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
    public partial class frmAQGJSCKXZ : FormBase, IPopupFormEdit
    {
        public frmAQGJSCKXZ()
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
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "lqdw");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "cksl");
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
            btnOK.DialogResult = DialogResult.None;
            //spinEdit2.Properties.MaxValue =Convert.ToDecimal( rowData.kcsl);
            comboBoxEdit8.Text = num;





            comboBoxEdit6.Properties.Items.Clear();
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select UserName   from mUser where OrgName = '" + rowData.OrgName + "' ");
            comboBoxEdit6.Properties.Items.AddRange(mclist);

            comboBoxEdit1.Properties.Items.Clear();
             mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where type = '" + type + "' or type = '" + type + "原始库存'");
            comboBoxEdit1.Properties.Items.AddRange(mclist);
         

         
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpgg  from PJ_anqgjcrkd where type = '" + type + "' or type = '" + type + "原始库存'");
            comboBoxEdit2.Properties.Items.AddRange(mclist);
            spinEdit2.Enabled = false;
            spinEdit2.Properties.MaxValue = (decimal)0.001;
            comboBoxEdit2_SelectedIndexChanged(sender,e);
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneInt",
                "select sum(cast(kcsl as float))    from PJ_anqgjcrkd where (type = '" + type + "' or type = '" + type + "原始库存') and wpmc='" + comboBoxEdit1.Text + "' and wpgg='" + comboBoxEdit2.Text + "'  ");
            if (mclist.Count > 0 && mclist[0] != null)
            {
                spinEdit2.Properties.MaxValue = Convert.ToDecimal(mclist[0]);
                comboBoxEdit3.Text = spinEdit2.Properties.MaxValue.ToString();
            }
            else
            {
                comboBoxEdit3.Text = "0";
                spinEdit2.Properties.MaxValue = (decimal)0.001;
            }
            spinEdit2.Enabled = true;
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "0"||spinEdit2.Value==0 )
            {
                MsgBox.ShowTipMessageBox("物品无库存或出库数量为空！");
                return;
            }
            this.DialogResult = DialogResult.OK;

            rowData.zkcsl = spinEdit2.Properties.MaxValue.ToString();
            if (returnData == null) returnData = new PJ_anqgjcrkd();
            ConvertHelper.CopyTo<PJ_anqgjcrkd>(rowData, returnData);
        }

        private void comboBoxEdit7_TextChanged(object sender, EventArgs e)
        {

            comboBoxEdit1.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_anqgjcrkd where type = '" + type + "' or type = '" + type + "原始库存'");
            comboBoxEdit1.Properties.Items.AddRange(mclist);
            spinEdit2.Enabled = false;
            spinEdit2.Properties.MaxValue = 0;

          
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
