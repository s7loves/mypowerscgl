﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.UI.Base;

namespace Ebada.Exam
{
    public partial class FrmE_BusinesInfoEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_BusinesInfo> m_CityDic = new SortableSearchableBindingList<E_BusinesInfo>();
        public FrmE_BusinesInfoEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtTitle.DataBindings.Add("EditValue", rowData, "Title");
            this.mtxtContent.DataBindings.Add("EditValue", rowData, "Content");

        }
        private E_BusinesInfo rowData = null;

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
                    this.rowData = value as E_BusinesInfo;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_BusinesInfo>(value as E_BusinesInfo, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pname = txtTitle.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("标题不能为空！");
                return;
            }
            if (mtxtContent.Text.Trim().Length == 0)
            {
                MsgBox.ShowWarningMessageBox("内容不能为空！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
