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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmGDSCCXQJHEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_ccxqjh> m_CityDic = new SortableSearchableBindingList<PJ_ccxqjh>();

        public frmGDSCCXQJHEdit()
        {
            InitializeComponent();
        }
        void dataBind() {



            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "xsjmc");
            //this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "gcmc");
            //this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "zybr");
            //this.spinEdit1.DataBindings.Add("EditValue", rowData, "dgzj");
            //this.spinEdit2.DataBindings.Add("EditValue", rowData, "qtzj");
            //this.spinEdit3.DataBindings.Add("EditValue", rowData, "sxzjsum");
            //this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "wcsj");

            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_ccxqjh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_ccxqjh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_ccxqjh>(value as PJ_ccxqjh, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
           

           // comboBoxEdit4.Properties.Items.Clear();
           // strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
           //string.Format("select nr from pj_dyk where  dx='设备更改大修计划' and sx like '%{0}%' and nr!=''", "完成时间"));
           // if (strlist.Count > 0)
           //     comboBoxEdit4.Properties.Items.AddRange(strlist);
           // else
           // {
           //     comboBoxEdit4.Properties.Items.Add("全年");
           //     comboBoxEdit4.Properties.Items.Add("1月");
           //     comboBoxEdit4.Properties.Items.Add("2月");
           //     comboBoxEdit4.Properties.Items.Add("3月");
           //     comboBoxEdit4.Properties.Items.Add("4月");
           //     comboBoxEdit4.Properties.Items.Add("5月");
           //     comboBoxEdit4.Properties.Items.Add("6月");
           //     comboBoxEdit4.Properties.Items.Add("7月");
           //     comboBoxEdit4.Properties.Items.Add("8月");
           //     comboBoxEdit4.Properties.Items.Add("9月");
           //     comboBoxEdit4.Properties.Items.Add("10月");
           //     comboBoxEdit4.Properties.Items.Add("11月");
           //     comboBoxEdit4.Properties.Items.Add("12月");
               
           // }





         
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

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Excel文件(*.xls)|*.xls|Word文件(*.doc)|*.doc";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    buttonEdit1.Text = openFileDialog1.FileName;
            //    rowData.BigData = Ecommon.GetImageBate(openFileDialog1.FileName);
            //    string[] str_name =  buttonEdit1.Text.Split("\\".ToCharArray());
            //    string[] filename = str_name[str_name.Length - 1].Split(".".ToCharArray());
            //    byte[] Excbyte = System.Text.Encoding.Default.GetBytes(filename[filename.Length - 1]);
            //    string Exc = System.Text.Encoding.Default.GetString(Excbyte);
            //    rowData.S1 ="."+ Exc;
            //}
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("设备更改大修计划", "备注", memoEdit3);
        }

     
       

     

      
    }
}