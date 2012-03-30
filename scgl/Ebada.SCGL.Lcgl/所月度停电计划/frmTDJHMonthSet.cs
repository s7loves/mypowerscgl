using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Core;
using Ebada.Client;
using System.Text.RegularExpressions;
using Ebada.SCGL.WFlow.Tool;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmTDJHMonthSet : FormBase
    {
        public frmTDJHMonthSet()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private DateTime dt =Convert.ToDateTime( DateTime.Now.ToString("yyyy年MM月20日"));
        private DateTime dt2 = Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy年MM月20日"));
        private ArrayList excelList = null;
        public ArrayList ExcelList
        {
            get
            {
                return excelList;
            }
            set
            {
                if (value == null) return;

                excelList = value;
            }
        }
        public DateTime dtTime
        {
            get
            {
                return dt;
            }
            set
            {
                if (value == null) return;

                dt = value;
            }
        }
        public DateTime dtTime2
        {
            get
            {
                return dt2;
            }
            set
            {
                if (value == null) return;

                dt2 = value;
            }
        }
        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;

                this.rowData = value as LP_Temple;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dt = Convert.ToDateTime( dateEdit1.EditValue);
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = dt;
            dateEdit2.DateTime = dt2;

        }
       
    
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }

     
      




    }
}
