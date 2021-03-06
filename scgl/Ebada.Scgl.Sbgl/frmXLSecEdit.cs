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
    public partial class frmXLSecEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_XLSec> m_CityDic = new SortableSearchableBindingList<PS_XLSec>();
        private PS_xl parentObj;
        public frmXLSecEdit() {
            InitializeComponent();
        }
        public frmXLSecEdit(ps_xl xl):this()
        {
            
        }
        void dataBind() {
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "LineType");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "StartGT");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "EndGT");          


        }
        #region IPopupFormEdit Members
        private PS_XLSec rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_XLSec;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_XLSec>(value as PS_XLSec, rowData);
                }

            }
        }
        public PS_xl ParentObj
        {
            get { return parentObj; }
            set
            {
                parentObj = value;
            }
        }
        #endregion

        private void InitComboBoxData() {

            if (ParentObj!=null)
            {
                IList<PS_gt> gtList = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("SelectPS_gtList", "where LineCode ='" + ParentObj.LineCode + "' order by gth");               
                foreach (PS_gt gt in gtList)
                {
                   comboBoxEdit1.Properties.Items.Add(gt.gtCode);
                   comboBoxEdit2.Properties.Items.Add(gt.gtCode);
                }
                IList<PS_dxxh> dxxhList = Client.ClientHelper.PlatformSqlMap.GetList<PS_dxxh>("SelectPS_dxxhList"," where dydj = '" + ParentObj.LineVol +"'");
                foreach (PS_dxxh dxxh in dxxhList)
                {
                    comboBoxEdit13.Properties.Items.Add(dxxh.dxxh);
                }
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
            if (comboBoxEdit1.Text == ""||comboBoxEdit2.Text=="")
            {
                MsgBox.ShowTipMessageBox("杆塔编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmXLSecEdit_Load(object sender, EventArgs e)
        {
            this.InitComboBoxData();
        }

    }
}