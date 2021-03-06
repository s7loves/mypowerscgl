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
using System.Text.RegularExpressions;
namespace Ebada.Scgl.Yxgl
{
    public partial class frm14aqgjsyEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_14aqgjsy> m_CityDic = new SortableSearchableBindingList<PJ_14aqgjsy>();

        public frm14aqgjsyEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "rq");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "xcsyrq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "syr");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "ajqz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sjr");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "jr", false, DataSourceUpdateMode.OnPropertyChanged);
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_14aqgjsy rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_14aqgjsy;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_14aqgjsy>(value as PJ_14aqgjsy, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit4.Properties.Items.Clear();
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            comboBoxEdit1.Properties.Items.AddRange(ryList);
            ComboBoxHelper.FillCBoxByDyk("公用属性","检查人",comboBoxEdit3);
            //comboBoxEdit3.Properties.Items.AddRange(ryList);
            comboBoxEdit4.Properties.Items.AddRange(ryList);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (UCPJ_14aqgj.Syzq.IndexOf(".") == -1)
            {
                dateEdit2.EditValue = ((DateTime)dateEdit1.EditValue).AddYears(Convert.ToInt32(UCPJ_14aqgj.Syzq));
            }
            else
            {

                Regex r1 = new Regex(@"[0-9]+(?=.)");
                string year = r1.Match(UCPJ_14aqgj.Syzq).Value;
                r1 = new Regex(@"(?<=.)[0-9]+");
                string month = r1.Match(UCPJ_14aqgj.Syzq).Value;
                if (year == "") year = "0";
                if (month == "") month = "0";
                else
                    month =(Math.Floor( Convert.ToDouble( "0." + month)*12)).ToString();
                dateEdit2.EditValue = ((DateTime)dateEdit1.EditValue).AddYears(Convert.ToInt32(year));
                dateEdit2.EditValue = ((DateTime)dateEdit2.EditValue).AddMonths(Convert.ToInt32(month));
            }
            rowData.xcsyrq = (DateTime)dateEdit2.EditValue;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("14电力安全工具试验记录", "结论", memoEdit1);
            if (!string.IsNullOrEmpty(memoEdit1.EditValue as string))
            {
                rowData.jr = memoEdit1.EditValue as string;
            }

        }
    }
}