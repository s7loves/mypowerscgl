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
    public partial class frmWGGCCLDSingleXZ : FormBase, IPopupFormEdit
    {
        public frmWGGCCLDSingleXZ()
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

        void dataBind()
        {
            
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "wpmc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "wpgg");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "kcsl");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "ssxm");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "yt");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "cksl");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "lqdw");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "ghdw");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "ssgc");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "num");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "ckdate");

        }
        #region IPopupFormEdit Members
        private PJ_wgclcrkd rowData = null;

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
                    this.rowData = value as PJ_wgclcrkd;
                   
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PJ_wgclcrkd>(value as PJ_wgclcrkd, rowData);
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
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct lqdw  from PJ_wgclcrkd where type = '工程材料出库单'");
            comboBoxEdit6.Properties.Items.AddRange(mclist);

            comboBoxEdit9.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ghdw  from PJ_wgclcrkd where type = '工程材料出库单'");
            comboBoxEdit9.Properties.Items.AddRange(mclist);

            comboBoxEdit5.Properties.Items.Clear();
            comboBoxEdit5.Properties.Items.Add("工程");
            comboBoxEdit5.Properties.Items.Add("检修");
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct yt  from PJ_wgclcrkd where type = '工程材料出库单'");
            comboBoxEdit5.Properties.Items.AddRange(mclist);
            //if (comboBoxEdit5.Properties.Items.Count == 0)
            //for (int i = 0; i < comboBoxEdit5.Properties.Items.Count;i++ )
            //{
            //    comboBoxEdit5.Properties.Items.Add("工程");
            //    comboBoxEdit5.Properties.Items.Add("检修");
            //}
            comboBoxEdit6.Properties.Items.Clear();
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select  OrgName  from mOrg where c1='是' order by orgcode");
            comboBoxEdit6.Properties.Items.AddRange(mclist);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (returnData == null) returnData = new PJ_wgclcrkd();
            ConvertHelper.CopyTo<PJ_wgclcrkd>(rowData, returnData);
        }

        

       
      


       
    }
}
