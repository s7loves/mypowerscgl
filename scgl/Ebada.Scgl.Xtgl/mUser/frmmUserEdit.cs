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
namespace Ebada.Scgl.Xtgl {
    public partial class frmmUserEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<mUser> m_CityDic = new SortableSearchableBindingList<mUser>();

        public frmmUserEdit() {
            InitializeComponent();

            // 职员编号最长为6位
            textEdit1.Properties.MaxLength = 6;

        }
        void dataBind() {


            this.textEdit1.DataBindings.Add("EditValue", rowData, "UserCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "UserName");
            this.textEdit3.DataBindings.Add("EditValue", rowData, "LoginID");
            this.textEdit4.DataBindings.Add("EditValue", rowData, "Password");
            this.textEdit5.DataBindings.Add("EditValue", rowData, "Alias");
            this.textEdit6.DataBindings.Add("EditValue", rowData, "Tel");
            this.textEdit7.DataBindings.Add("EditValue", rowData, "Mail");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "PostName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "Sex");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "Type");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "Birthday");
            this.checkEdit1.DataBindings.Add("EditValue", rowData, "Valid");

        }
        #region IPopupFormEdit Members
        private mUser rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as mUser;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<mUser>(value as mUser, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            
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

        #region 确定按钮 职员编号为6位！
        void btnOK_Click(object sender, System.EventArgs e)
        {
            if (textEdit1.Text.Length != 6)
            {
                MsgBox.ShowWarningMessageBox("职员编号为6位！");
                textEdit1.Focus();
            }
            else
            {
                this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        #endregion
    }
}