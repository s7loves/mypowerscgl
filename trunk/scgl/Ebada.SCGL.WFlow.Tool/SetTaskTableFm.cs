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
namespace Ebada.SCGL.WFlow.Tool
{
    public partial class SetTaskTableFm : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<LP_Temple> m_CityDic = new SortableSearchableBindingList<LP_Temple>();

        public SetTaskTableFm()
        {
            InitializeComponent();
        }
        void dataBind() {

            this.textEdit1.DataBindings.Add("EditValue", rowData, "CellName");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "CtrlType");
            //this.dsoFramerWordControl1.DataBindings.Add("FileDataGzip", rowData, "DocContent");
            byte[] bt = new byte[0];
            rowData.ImageAttachment = bt;
            rowData.SignImg = bt;

        }
        #region IPopupFormEdit Members
        private LP_Temple rowData = null;

        public object RowData {
            get {
                byte[] bt = this.dsoFramerWordControl1.FileDataGzip;
                rowData.ImageAttachment = bt;
                rowData.SignImg = bt;             
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {                    
                    this.rowData = value as LP_Temple;         
                    dataBind();
                    
                } else {                
                    ConvertHelper.CopyTo<LP_Temple>(value as LP_Temple, rowData);              
                    
                }
            }
        }

        #endregion
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            this.dsoFramerWordControl1.FileDataGzip = this.rowData.DocContent;
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

        private void frmExcelEdit_FormClosed(object sender, FormClosedEventArgs e)
        {   
            this.dsoFramerWordControl1.FileClose();
            base.Close();
        }

        private void frmExcelEdit_Load(object sender, EventArgs e)
        {
            uCmExcel1.ParentObj = rowData;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.dsoFramerWordControl1.FileSave();            
            rowData.DocContent = this.dsoFramerWordControl1.FileDataGzip; 
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {       
            this.dsoFramerWordControl1.FileClose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmLP frm = new frmLP();
            LP_Record lpr = new LP_Record();
            frm.Status = "add";
            frm.Kind = rowData.Kind;
            frm.ParentTemple = rowData;

            lpr.Status = "测试";
            //lpr.Status = "填票";
            //frm.RowData = lpr;
            frm.CurrRecord = lpr;
            frm.ShowDialog();
        }

       
       
    }
}