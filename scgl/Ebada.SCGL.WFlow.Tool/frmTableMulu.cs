using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using Ebada.Core;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class frmTableMulu : FormBase
    {
        #region IPopupFormEdit Members
        private LP_Temple rowData = null;

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
                    this.rowData = value as LP_Temple;
                    
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<LP_Temple>(value as LP_Temple, rowData);
                }
            }
        }

        #endregion
        void dataBind()
        {
            this.textEdit1.DataBindings.Add("EditValue", rowData, "CellName");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "SortID");


        }
        public frmTableMulu()
        {
            InitializeComponent();
        }
    }
}
