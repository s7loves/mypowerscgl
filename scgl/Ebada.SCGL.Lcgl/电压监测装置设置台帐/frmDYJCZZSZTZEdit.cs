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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmDYJCZZSZTZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_dyjczzsztz> m_CityDic = new SortableSearchableBindingList<PJ_dyjczzsztz>();

        public frmDYJCZZSZTZEdit()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "zzszwz");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "zzVol");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "zzdlb");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "zzxh");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "zzFactory");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "zdz");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "cjfs");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "jddate");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
           

        }
        #region IPopupFormEdit Members
        private PJ_dyjczzsztz rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_dyjczzsztz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_dyjczzsztz>(value as PJ_dyjczzsztz, rowData);
                }
            
            }
        }

        #endregion




        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void InitComboBoxData() {
           
            //填充下拉列表数据
           



            comboBoxEdit2.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='电压监测装置设置台帐' and sx like '%{0}%' and nr!=''", "监测电压（KV）"));
            if (strlist.Count > 0)
                comboBoxEdit2.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit2.Properties.Items.Add("0.22");
                comboBoxEdit2.Properties.Items.Add("0.38");
                comboBoxEdit2.Properties.Items.Add("10");
            }

            comboBoxEdit3.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='电压监测装置设置台帐' and sx like '%{0}%' and nr!=''", "监测点类别"));
            if (strlist.Count > 0)
                comboBoxEdit3.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit3.Properties.Items.Add("A");
                comboBoxEdit3.Properties.Items.Add("B");
                comboBoxEdit3.Properties.Items.Add("C");
                comboBoxEdit3.Properties.Items.Add("D");

            }

            comboBoxEdit4.Properties.Items.Clear();
             strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='电压监测装置设置台帐' and sx like '%{0}%' and nr!=''", "装置型号"));
            if (strlist.Count > 0)
                comboBoxEdit4.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit4.Properties.Items.Add("DT1—1X380V/G");
                comboBoxEdit4.Properties.Items.Add("DT1—1X220V/G");

            }

            comboBoxEdit5.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='电压监测装置设置台帐' and sx like '%{0}%' and nr!=''", "制造厂"));
            if (strlist.Count > 0)
                comboBoxEdit5.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit5.Properties.Items.Add("余姚市电器仪器厂");



            }

            comboBoxEdit6.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='电压监测装置设置台帐' and sx like '%{0}%' and nr!=''", "整定值"));
            if (strlist.Count > 0)
                comboBoxEdit6.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit6.Properties.Items.Add("353.4-406.6 V");
                comboBoxEdit6.Properties.Items.Add("198-235.4 V");



            }

         
          
            comboBoxEdit7.Properties.Items.Clear();
            strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           string.Format("select nr from pj_dyk where  dx='电压监测装置设置台帐' and sx like '%{0}%' and nr!=''", "采集方式"));
            if (strlist.Count > 0)
                comboBoxEdit7.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit7.Properties.Items.Add("人工");
                comboBoxEdit7.Properties.Items.Add("自动");



            }
           






        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

       
      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("电压监测装置设置台帐", "备注", memoEdit3);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        
      

       

      

       
    }
}