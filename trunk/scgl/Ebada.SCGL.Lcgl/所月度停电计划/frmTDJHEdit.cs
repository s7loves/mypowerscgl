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
    public partial class frmTDJHEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_tdjh> m_CityDic = new SortableSearchableBindingList<PJ_tdjh>();

        public frmTDJHEdit()
        {
            InitializeComponent();
            comboBoxEdit1.EditValueChanged += new EventHandler(comboBoxEdit1_EditValueChanged);
        }

        void comboBoxEdit1_EditValueChanged(object sender, EventArgs e) {

            comboBoxEditShenHeRen.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy((comboBoxEdit1.EditValue ?? "").ToString()));
        }
        void dataBind() {

            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "SQOrgname");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "ASSOrgname");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "TDtime");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "SDtime");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "JXNR");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "JXSB");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "Remark");
            this.comboBoxEditShenHeRen.DataBindings.Add("EditValue", rowData, "ShenHeRen");
           

        }
        #region IPopupFormEdit Members
        private PJ_tdjh rowData = null;

        public object RowData {
            get {
               
                return rowData;
              
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_tdjh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_tdjh>(value as PJ_tdjh, rowData);
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
            IList<ViewGds> gdslist = Client.ClientHelper.PlatformSqlMap.GetList<ViewGds>("");
            SetComboBoxData(comboBoxEdit1, "OrgName", "OrgName", "选择供电所", "", gdslist as IList);
            SetComboBoxData(comboBoxEdit2, "OrgName", "OrgName", "选择供电所", "", gdslist as IList);
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;
            

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("所月度停电计划", "停电检修设备", memoEdit2);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("所月度停电计划", "主要检修内容", memoEdit1);
        }

      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("所月度停电计划", "备注", memoEdit3);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}