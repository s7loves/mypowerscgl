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
namespace Ebada.Scgl.Yxgl
{
    public partial class frmkgEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_kg> m_CityDic = new SortableSearchableBindingList<PS_kg>();

        public frmkgEdit() {
            InitializeComponent();
        }
        void dataBind() {

            this.dateEdit1.DataBindings.Add("EditValue", rowData, "kgMadeDate");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "kgInstallDate");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "InDate");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "kgName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "kgModle");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "kgVol");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "kgPhase");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "kgFactory");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "kgCloseVol");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "kgOpenEle");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "kgLineGroup");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "kgNumber");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "kgInstallAdress");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "kgState");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "kgCode");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "kgfgb");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "kgCapcity");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "gtID");
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PS_kg rowData = null;

        public object RowData {
            get {
                
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_kg;
                    this.InitComboBoxData();
                    
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_kg>(value as PS_kg, rowData);
                    this.InitComboBoxData();
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
           
            IList<PS_gt> gtlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("");
            SetComboBoxData(lookUpEdit1, "", "", "", "", gtlist);

            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "型号", comboBoxEdit2.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "容量", spinEdit2.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "重合装置", comboBoxEdit9.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "制造厂", comboBoxEdit5.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "电压", comboBoxEdit3.Properties);
            
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "电压", comboBoxEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "遮断容量", comboBoxEdit4.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "合闸线圈电压", comboBoxEdit7.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "跳闸电流", comboBoxEdit8.Properties);
            ComboBoxHelper.FillCBoxByDyk("12线路开关卡片", "互感器变比", comboBoxEdit14.Properties);

         
      
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<PS_gt> post) {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = "gtCode";
            comboBox.Properties.ValueMember = "gtID";
            comboBox.Properties.NullText = "选择杆塔";
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("gtID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("gtCode", "杆塔编号",30),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineCode", "线路编号",40),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("gth", "杆塔号",30),
          });
        }
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            rowData.gtID = lookUpEdit1.EditValue.ToString();

            IList<PS_xl> listxl = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>( "select *  from PS_xl where LineCode in(select LineCode from PS_gt where gtID='" + rowData.gtID + "')");
            if (listxl.Count>0)
            {
                comboBoxEdit11.Text=listxl[0].LineName;
            }


            PS_gt pg = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_gt>(rowData.gtID);
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select sbName from PS_gtsb where gtid='"+rowData.gtID+"'and sbType='开关'");
            comboBoxEdit1.Properties.Items.AddRange(list);
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select sbCode from PS_gtsb where gtid='" + rowData.gtID + "'and sbType='开关'");
            if (pg == null) return;
            IList<PS_kg> kglist= Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_kg>("where gtID='"+pg.gtID+"'");
            string bh = (list.Count == 0 ? "00" : list[0].ToString());
            comboBoxEdit13.EditValue = pg.gtCode + bh+ Ecommon.GenBH(kglist.Count + 1);
            rowData.kgCode = comboBoxEdit13.EditValue.ToString();
           
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rowData.gtID==""||rowData.gtID==null)
            {
                MessageBox.Show("请选择杆塔！");
                return;
            }
            if (comboBoxEdit13.Text.Length==0)
            {
                MessageBox.Show("编号不能为空！");
                comboBoxEdit13.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        

        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit16_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

       
    }
}