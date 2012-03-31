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
    public partial class frmPS_tqsbclbEdit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<PS_byqxh> m_CityDic = new SortableSearchableBindingList<PS_byqxh>();

        public frmPS_tqsbclbEdit()
        {
            InitializeComponent();
        }
        void dataBind()
        {
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "zl");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "zlCode");
        }
        #region IPopupFormEdit Members
        private PS_tqsbclb rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as PS_tqsbclb;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<PS_tqsbclb>(value as PS_tqsbclb, rowData);
                }
            }
        }

        #endregion
        private void InitComboBoxData()
        {
           
        }
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}