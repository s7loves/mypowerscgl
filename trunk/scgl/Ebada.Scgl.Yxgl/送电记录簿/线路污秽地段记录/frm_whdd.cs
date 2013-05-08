using System;
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

namespace Ebada.Scgl.Yxgl
{
    public partial class frm_whdd : FormBase, IPopupFormEdit 
    {
        public frm_whdd()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_xlwhqd rowData;
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
                    this.rowData = value as sdjls_xlwhqd;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_xlwhqd>(value as sdjls_xlwhqd, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            ComboBoxHelper.FillCBoxByDyk("20线路污秽地段记录", "污秽等级", cmbwhdj.Properties);
            ComboBoxHelper.FillCBoxByDyk("20线路污秽地段记录", "污源性质", cmbwyxz.Properties);
        }

        private void dataBind()
        {
            this.txtwhqdmc.DataBindings.Add("EditValue", rowData, "whqd");
            this.cmbwyxz.DataBindings.Add("EditValue", rowData, "whxz");
            this.cmbwhdj.DataBindings.Add("EditValue", rowData, "whdj");
            this.memowhxx.DataBindings.Add("EditValue", rowData, "qdxx");
            
        }

        #endregion

       

    }
}