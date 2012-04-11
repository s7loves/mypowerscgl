using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;

namespace Ebada.Scgl.Sbgl
{
    public partial class frmPS_gtsbclbclEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PS_byqxh> m_CityDic = new SortableSearchableBindingList<PS_byqxh>();

        public frmPS_gtsbclbclEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "mc");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "xh");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "bh");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "S1");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "S2");
        }
        #region IPopupFormEdit Members
        private PS_gtsbclb rowData = null;

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
                    this.rowData = value as PS_gtsbclb;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PS_gtsbclb>(value as PS_gtsbclb, rowData);
                }
            }
        }

        #endregion
        private void InitComboBoxData()
        {


            comboBoxEdit4.Properties.Items.Clear();
            comboBoxEdit4.Properties.Items.Add("片");
            comboBoxEdit4.Properties.Items.Add("付");
            comboBoxEdit4.Properties.Items.Add("个");
            comboBoxEdit4.Properties.Items.Add("块");
            comboBoxEdit4.Properties.Items.Add("条");
            comboBoxEdit4.Properties.Items.Add("根");
        }
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit2.Properties.Items.Clear();
            System.Collections.IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct xh  from PS_sbcs where   mc='" + comboBoxEdit1.Text + "' and xh is not null ");
            if (mclist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(mclist);
            else
            {
                mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct nr  from pj_dyk where   sx='" + comboBoxEdit1.Text + "'");
                if (mclist.Count > 0)
                    comboBoxEdit2.Properties.Items.AddRange(mclist);
                else
                {
                    mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                "select distinct wpgg  from PJ_clcrkd where  wpmc='" + comboBoxEdit1.Text + "' and ssxm!='' ");
                    comboBoxEdit2.Properties.Items.AddRange(mclist);
                }
            }

        }

        private void frmPS_gtsbclbclEdit_Load(object sender, EventArgs e)
        {
            IList  strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select distinct mc from PS_sbcs"));
            if (strlist.Count > 0)
                comboBoxEdit1.Properties.Items.AddRange(strlist);
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PS_sbcs sbcs = MainHelper.PlatformSqlMap.GetOne<PS_sbcs>(" where mc='" + comboBoxEdit1.Text + "' and xh='" + comboBoxEdit2.Text + "'");
            if (sbcs != null)
            {
                rowData.bh = sbcs.bh + "001";
                comboBoxEdit3.Text = rowData.bh; 
            }
        }
    }
}