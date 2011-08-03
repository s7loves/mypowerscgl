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
    public partial class frmbyqxhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_byqxh> m_CityDic = new SortableSearchableBindingList<PS_byqxh>();

        public frmbyqxhEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.textEdit1.DataBindings.Add("EditValue", rowData, "byqModle");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "byqVol");

            this.spinEdit1.DataBindings.Add("EditValue", rowData, "byqCapcity");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "Loss1");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "Loss2");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "Ratedcurrent");


        }
        #region IPopupFormEdit Members
        private PS_byqxh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_byqxh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_byqxh>(value as PS_byqxh, rowData);
                }     
            }
        }

        #endregion

        private void InitComboBoxData() {
            
        }

    }
}