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
    public partial class frmtqEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tq> m_CityDic = new SortableSearchableBindingList<PS_tq>();
        private string gdsCode;

        public string GdsCode
        {
            get { return gdsCode; }
            set { gdsCode = value; ComboBoxHelper.Fillgdsry(comboBoxEdit9, gdsCode); }
        }
        private string lineCode;

        public string LineCode
        {
            get { return lineCode; }
            set { lineCode = value; }
        }


        public frmtqEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tqCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "tqName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "Adress");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "xlCode");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xlCode2");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "Owner");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "cby");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "cfy");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Contractor");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "Class");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "Lowlossrate");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "tclr");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "hclr");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "InDate");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "Remark");         


        }
        #region IPopupFormEdit Members
        private PS_tq rowData = null;

        public object RowData {
            get {
                PS_tq tq = new PS_tq();
                ConvertHelper.CopyTo(rowData, tq);
                return tq;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tq;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tq>(value as PS_tq, rowData);
                }
                if(rowData.tqCode==""){
                    rowData.InDate = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>(" where OrgCode='" + gdsCode + "' and linevol='10'");
            comboBoxEdit4.Properties.DataSource = xlList;
            comboBoxEdit5.Properties.DataSource = xlList;
            
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
                MsgBox.ShowTipMessageBox("台区编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxEdit6_Properties_Click(object sender, EventArgs e)
        {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='台区' and sx='产权' and parentid=''");
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                // dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBoxEdit6.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr ;
                }
            }
        }

        private void comboBoxEdit10_Properties_Click(object sender, EventArgs e)
        {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>("where dx='台区' and sx='运行班次' and parentid=''");
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                // dlg.TxtMemo = txt;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBoxEdit10.Text = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }
            }
        }

        private void comboBoxEdit5_EditValueChanged(object sender, EventArgs e) {
            //分支线路改变时刷新杆塔号
            string linecode=comboBoxEdit5.EditValue.ToString();
            if (string.IsNullOrEmpty(linecode)) return;
            lookUpEdit1.Properties.DataSource = ClientHelper.PlatformSqlMap.GetList<PS_gt>("Where linecode='" + linecode + "'"); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

      
    }
}