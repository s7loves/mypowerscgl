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

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class frmExcelEditSQLSet : FormBase
    {
        public frmExcelEditSQLSet()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private string strSQL = "";

        public string StrSQL
        {
            get
            {
                return strSQL;
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
            if (rbnWorkFixValue.Checked == true)
            {

                strSQL = "select top 1 '" + tetWorkFixValue.Text + "' from LP_Temple where 1=1";
            }
            else if (rbnWorkTable.Checked == true)
            {
                strSQL = "select ControlValue from WF_TableFieldValueView where 2=2  "
                    + "and UserControlId='" + ((ListItem)cbxWorkDataTable.SelectedItem).ID + "' "
                    + " and FieldId='" + ((ListItem)cbxWorkTableColumns.SelectedItem).ID + "' ";
                if (ceBind.Checked)
                {
                    strSQL = strSQL + " and id='{recordid}'";
                }
               
            }
            else if (rbnWorkExcel.Checked == true)
            {
                strSQL = "Excel:" + cbxWorkExcelTable.Text + ":" + tetWorkPos.Text;
            }
            else if (rbnWorkDatabase.Checked == true)
            {
                strSQL = tetWorkSQL.Text;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {

            IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", " where ParentID not in (select LPID from LP_Temple where 1=1) ");
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDataTable, dt, "LPID", "CellName");

            LP_Temple tp = ClientHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(rowData.ParentID);
          
           DSOFramerControl dsoFramerWordControl1 =new DSOFramerControl ();
           if (tp == null)
           {
               dsoFramerWordControl1.FileDataGzip = rowData.DocContent;
               rowData.DocContent = new byte[0];
           }
           else
           {
               dsoFramerWordControl1.FileDataGzip = tp.DocContent;
               
           }

           Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
           Microsoft.Office.Interop.Excel.Worksheet xx = wb.Application.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
           cbxWorkExcelTable.Items.Clear();
            for (int i = 1; i <= wb.Application.Sheets.Count; i++)
           {

               Microsoft.Office.Interop.Excel.Worksheet tmpSheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Application.Sheets.get_Item(i);
                   try
                   {
                       if (tmpSheet != null)
                       {
                           cbxWorkExcelTable.Items.Add(tmpSheet.Name);
                       }

                   }
                   catch { }

               
           }
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.Dispose();
            cbxWorkExcelTable.Text = xx.Name;

             li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select name as 'name' from sysobjects where xtype='U'  or xtype='V' order by xtype ,name");
             //dt = ConvertHelper.ToDataTable(li);
             dt = new DataTable();
             dt.Columns.Add("name", typeof(string));
             for (int i = 0; i < li.Count; i++)
             {
                 DataRow dr = dt.NewRow();
                 dr["name"] = li[i];
                 dt.Rows.Add(dr);
             }
             WinFormFun.LoadComboBox(cbxWorkDbTable, dt, "name", "name");
             memoEdit1.Text = "说明 SQL语句支持中的特殊代码\r\n {sortid}:当前表单的序号为sortid的字段\r\n{recordid}:票LP_Record的ID\r\n{orgcode}:用户单位编号\r\n {userid}:用户编号\r\n";
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);
        }
        private void SetDataBaseSQL(DevExpress.XtraEditors.TextEdit tetSQL, ComboBox cbxDbTable, ComboBox cbxDbTableColumns)
        {
            if (cbxDbTable.SelectedIndex > 0 && cbxDbTableColumns.SelectedIndex > 0)
            {
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + ((ListItem)cbxDbTable.SelectedItem).ID + "'");
                if (list.Count > 0&&1==0)
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 1=1 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                }
                else
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 1=1 ";
                }
                if (ceBind.Checked)
                {
                    if (cbxDbTable.Text == "WF_TableFieldValueView")
                        tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                    else
                        if (cbxDbTable.Text == "LP_Record")
                            tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                        else
                        {


                            tetSQL.Text = "" + tetSQL.Text + " and " + list[0].ToString()
                                + " in (select ModleRecordID from WFP_RecordWorkTaskIns where  RecordID='{recordid}')";
                        }

                }
            }

        }
        private void cbxWorkDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxWorkDbTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxWorkDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDbTableColumns, dt, "name", "name");
            cbxWorkDbTableColumns.SelectedIndex = 0;
            SetDataBaseSQL(tetWorkSQL, cbxWorkDbTable, cbxWorkDbTableColumns);
        }

        private void cbxWorkDbTableColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBaseSQL(tetWorkSQL, cbxWorkDbTable, cbxWorkDbTableColumns);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }

        private void cbxWorkDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorkDataTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList",
                "where ParentID ='" + ((ListItem)cbxWorkDataTable.SelectedItem).ID + "' order by sortid");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            for (int i = 0; i < dt.Rows.Count&&li.Count>0; i++)
            {
                dt.Rows[i]["cellname"] = dt.Rows[i]["SortID"] + " " + dt.Rows[i]["cellname"];
            
            }
                WinFormFun.LoadComboBox(cbxWorkTableColumns, dt, "LPID", "cellname");
            cbxWorkTableColumns.SelectedIndex = 0;
        }

       

       

    }
}
