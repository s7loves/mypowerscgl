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
    public partial class frmSpanSet : FormBase
    {
        public frmSpanSet()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private string strSQL = "";
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
        public string StrSQL
        {
            get
            {
                return strSQL;
            }
            set
            {
                if (value == null) return;

                strSQL = value;
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
            strSQL = textEdit1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {


            textEdit1.Text = strSQL;
             
           
        }
    
    
      

      
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

    }
}
