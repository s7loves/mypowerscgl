﻿using System;
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
    public partial class frmtqbyqEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqbyq> m_CityDic = new SortableSearchableBindingList<PS_tqbyq>();

        public frmtqbyqEdit() {
            InitializeComponent();
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "byqCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "byqName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "byqModle");
            this.checkEdit1.DataBindings.Add("EditValue", rowData, "omniseal");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "byqOwner");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "byqVol");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "byqPhase");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "byqCapcity");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "byqLineGroup");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "byqFactory");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "byqNumber");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "byqMadeDate");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "byqCycle");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "byqVolOne");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "byqVolTwo");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "byqCurrentOne");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "byqCurrentTwo");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "byqInstallDate");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "byqInstallAdress");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "byqState");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "InDate");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "tqID");
            this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "byqkind");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "jlType");
            this.comboBoxEdit15.DataBindings.Add("EditValue", rowData, "azType");
            this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "isCount");  

            this.lookUpEdit1.EditValueChanged += new EventHandler(lookUpEdit1_EditValueChanged);

            comboBoxEdit3.SelectedIndexChanged += new EventHandler(comboBoxEdit3_SelectedIndexChanged);
            spinEdit1.EditValueChanged += spinEdit1_Properties_EditValueChanged;
        }
        void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxEdit3.SelectedIndex < 0) return;
            string[] ss = comboBoxEdit3.Text.Split('-');
            if (ss.Length != 3) return;
            comboBoxEdit3.Text = ss[0];
            spinEdit1.Text = ss[2];
            //comboBoxEdit7.Text = ss[1].Split('/')[0];
        }

        void lookUpEdit1_EditValueChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(lookUpEdit1.Text)) {
                this.comboBoxEdit2.EditValue = rowData.byqName = lookUpEdit1.Text;
                this.comboBoxEdit14.EditValue = rowData.byqInstallAdress = lookUpEdit1.Text;
            }
        }
        #region IPopupFormEdit Members
        private PS_tqbyq rowData = null;
        private string xlcode;
        public object RowData {
            get {
                PS_tqbyq tq = new PS_tqbyq();
                ConvertHelper.CopyTo(rowData, tq);
                return tq;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tqbyq;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tqbyq>(value as PS_tqbyq, rowData);
                }
                if (rowData.byqCode == "")
                {
                    rowData.byqInstallDate = DateTime.Now;
                    rowData.byqMadeDate = DateTime.Now;
                    rowData.InDate = DateTime.Now;
                }
                if (xlcode != rowData.byqCode.Substring(0, 6)) {
                    xlcode = rowData.byqCode.Substring(0, 6);
                    this.lookUpEdit1.EditValueChanged -= new EventHandler(lookUpEdit1_EditValueChanged);
                    lookUpEdit1.Properties.DataSource = ClientHelper.PlatformSqlMap.GetList<PS_tq>(string.Format(" where left(tqcode,3)='{0}'", xlcode.Substring(0,3)));
                    this.lookUpEdit1.EditValueChanged += new EventHandler(lookUpEdit1_EditValueChanged);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {


            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "型号", comboBoxEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "制造厂", comboBoxEdit10.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "一次电压", spinEdit2.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "二次电压", spinEdit3.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "一次额定电流", spinEdit4.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "二次额定电流", spinEdit5.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "容量", spinEdit1.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "相别", comboBoxEdit8.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "结线组别", comboBoxEdit9.Properties);
            ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "周波", comboBoxEdit12.Properties);
            this.comboBoxEdit7.Properties.Items.AddRange(ComboBoxHelper.GetVoltage());
            comboBoxEdit16.Properties.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
            string.Format("select nr from pj_dyk where  dx='公用属性' and sx like '%{0}%' and nr!=''", "完好类型"));
            if (strlist.Count > 0)
                comboBoxEdit16.Properties.Items.AddRange(strlist);
            else
            {
                comboBoxEdit16.Properties.Items.Add("一类");
                comboBoxEdit16.Properties.Items.Add("二类");
                comboBoxEdit16.Properties.Items.Add("三类");
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("变压器编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void spinEdit1_Properties_EditValueChanged(object sender, EventArgs e) {
            switch (Convert.ToInt32(spinEdit1.EditValue)) {
                case 10:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(0.58);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(14.4);
                    break;
                case 20:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(1.15);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(28.8);

                    break;
                case 30:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(1.73);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(43.3);

                    break;
                case 50:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(2.89);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(72.1);

                    break;
                case 63:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(3.64);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(90.9);

                    break;
                case 80:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(4.62);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(115.5);

                    break;
                case 100:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(5.77);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(144.3);

                    break;
                case 125:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(7.22);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(180.4);

                    break;
                case 160:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(9.24);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(230.9);

                    break;
                case 200:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(11.54);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(288.7);

                    break;
                case 250:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(14.35);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(360.9);

                    break;

                case 315:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(18.19);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(454.7);
                    break;
                case 630:
                    spinEdit4.EditValue = rowData.byqCurrentOne = Convert.ToDecimal(36.37);
                    spinEdit5.EditValue = rowData.byqCurrentTwo = Convert.ToDecimal(909.35);

                    break;
            }
        }
    }
}