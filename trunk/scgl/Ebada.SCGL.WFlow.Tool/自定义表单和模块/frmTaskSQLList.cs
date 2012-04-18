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

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class frmTaskSQLList : FormBase
    {
        public frmTaskSQLList()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private DataTable griddt = null;
        private string strSQL = "";
        private string strWorkFlowID = "";
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
        public string StrWorkFlowID
        {
            get
            {
                return strWorkFlowID;
            }
            set
            {
                if (value == null) return;

                strWorkFlowID = value;
                IList<WF_WorkTastTrans> wttli = MainHelper.PlatformSqlMap.GetList<WF_WorkTastTrans>(" where "); 
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
            int i = 0;
            strSQL = "";
            foreach (DataRow dr in griddt.Rows)
            {
                if (dr["sql"].ToString() != "")
                {
                    strSQL += "[" + i + ":" + dr["sql"] + "]";
                }
                i++;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {
            
           
        }
        void setComoboxFocusIndex(ComboBox cbx,string text)
        {
            int focusindex =-1, i = 0;
            foreach (ListItem it in cbx.Items)
            {

                ListItem l = it as ListItem;
                if (l.ID == text)
                {
                    focusindex = i;
                    break;
                }
                i++;
            }
            cbx.SelectedIndex = focusindex;
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
