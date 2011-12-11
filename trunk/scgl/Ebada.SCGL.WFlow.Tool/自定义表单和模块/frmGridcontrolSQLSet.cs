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
    public partial class frmGridcontrolSQLSet : FormBase
    {
        public frmGridcontrolSQLSet()
        {
            InitializeComponent();
        }
        private LP_Temple rowData = null;
        private DataTable griddt = null;
        private string strSQL = "";

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
            int i = 0;
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
            for (i = 1; i <= wb.Application.Sheets.Count; i++)
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
             
             for ( i = 0; i < li.Count; i++)
             {
                 DataRow dr = dt.NewRow();
                 dr["name"] = li[i];
                 dt.Rows.Add(dr);
             }
             WinFormFun.LoadComboBox(cbxWorkDbTable, dt, "name", "name");
             memoEdit1.Text = "说明 SQL语句支持中的特殊代码\r\n 固定值中 数字+数字:{1+10}表示1到10用于序号 {sortid}:当前表单的序号为sortid的字段\r\n{recordid}:票LP_Record的ID\r\n{orgcode}:用户单位编号\r\n{userid}:用户编号\r\n{编号规则一:单位的sortid}:把26个供电所按顺序编号分别为01、02、03以此类推，001为单据编号\r\n";
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);

            string[] comItem = SelectorHelper.ToDBC(rowData.ColumnName).Split('|');
            griddt = new DataTable();
            griddt.Columns.Add("name",typeof(string));
            griddt.Columns.Add("sql",typeof(string));
            griddt.Rows.Clear();
            i = 0;
            foreach (string strname in comItem)
            {
                DataRow dr = griddt.NewRow();
                if (strname == "") continue;
                dr["name"] = strname;
                Regex r1 = new Regex(@"(?<=\["+i+":).*?(?=\\])");
                if (r1.Match(rowData.SqlSentence).Value!="")
                {
                    dr["sql"] = r1.Match(rowData.SqlSentence).Value;
                }
                griddt.Rows.Add(dr);
                i++;
            }
            WinFormFun.LoadComboBox(columnBox, griddt, "sql", "name");
            gridControl1.DataSource = griddt;
            gridView1.Columns["name"].Caption = "列名";
            gridView1.Columns["name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
             gridView1.Columns["name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["sql"].Caption = "SQL语句";
            gridView1.Columns["sql"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["sql"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.OptionsBehavior.Editable = false;
           
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
        private void SetDataBaseSQL(DevExpress.XtraEditors.TextEdit tetSQL, ComboBox cbxDbTable, ComboBox cbxDbTableColumns)
        {
            if (cbxDbTable.SelectedIndex > 0 && cbxDbTableColumns.SelectedIndex > 0)
            {
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + ((ListItem)cbxDbTable.SelectedItem).ID + "'");
                if (list.Count > 0&&1==0)
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                }
                else
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 ";
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
                                + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                        }

                }
            }

        }
        private void cbxWorkDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxWorkDbTable.SelectedIndex <1) return;
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
            if (cbxWorkDataTable.SelectedIndex < 1) return;
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string strSQLtemp = "";
            simpleButton3.Text = "修改";
            if (rbnWorkFixValue.Checked == true)
            {

                strSQLtemp = "select top 1 '" + tetWorkFixValue.Text + "' from LP_Temple where 9=9";
            }
            else if (rbnWorkTable.Checked == true)
            {
                strSQLtemp = "select ControlValue from WF_TableFieldValue where 10=10  "
                    + "and UserControlId='" + ((ListItem)cbxWorkDataTable.SelectedItem).ID + "' "
                    + " and FieldId='" + ((ListItem)cbxWorkTableColumns.SelectedItem).ID + "' ";
                if (ceBind.Checked)
                {
                    strSQLtemp = strSQLtemp + " and RecordId='{recordid}'";
                }

            }
            else if (rbnWorkExcel.Checked == true)
            {
                strSQLtemp = "Excel:" + cbxWorkExcelTable.Text + ":" + tetWorkPos.Text;
            }
            else if (rbnWorkDatabase.Checked == true)
            {
                strSQLtemp = tetWorkSQL.Text;
            }

            
            int i = 0;
            foreach (DataRow dr in griddt.Rows)
            {
                if (dr["name"].ToString() == columnBox.Text)
                {
                    dr["sql"] = strSQLtemp;
                    break;
                }
                i++;
            }
            if ( columnBox.Items.Count>i+1) ((ListItem)columnBox.Items[i + 1]).ID = strSQLtemp;
        }

        private void columnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQLtemp = ((ListItem)columnBox.SelectedItem).ID;
            if (columnBox.SelectedIndex < 1) return;
            if (strSQLtemp != "")
            {
                simpleButton3.Text = "修改";
                if (strSQLtemp.IndexOf("9=9") > -1)
                {
                    rbnWorkFixValue.Checked = true;

                    tetWorkFixValue.Text = strSQLtemp.Replace("select top 1 '", "").Replace("' from LP_Temple where 9=9", "");
                }
                else if (strSQLtemp.IndexOf("Excel:") > -1)
                {
                    rbnWorkExcel.Checked = true;
                    int index1 = strSQLtemp.LastIndexOf(":");
                    string tablename = strSQLtemp.Substring(6, index1 - 6);
                    string cellpos = strSQLtemp.Substring(index1 + 1);

                    cbxWorkExcelTable.Text = tablename;
                    tetWorkPos.Text = cellpos;
                }
                else if (strSQLtemp.IndexOf("10=10") > -1)
                {
                    rbnWorkTable.Checked = true;
                    Regex r1 = new Regex(@"(?<=UserControlId=').*?(?=')");
                    //cbxWorkDataTable.Text = r1.Match(strSQL).Value;
                    setComoboxFocusIndex(cbxWorkDataTable, r1.Match(strSQLtemp).Value);
                    r1 = new Regex(@"(?<=FieldId=').*?(?=')");
                    //cbxWorkTableColumns.Text = r1.Match(strSQL).Value;
                    setComoboxFocusIndex(cbxWorkTableColumns, r1.Match(strSQLtemp).Value);
                }
                else
                {
                    rbnWorkDatabase.Checked = true;
                    int index1 = strSQLtemp.ToLower().IndexOf("select");
                    int index2 = strSQLtemp.ToLower().IndexOf("from");
                    int index3 = strSQLtemp.ToLower().IndexOf("where");
                    string tablename = "";
                    if (index1 == -1 || index2 == -1 || index3 == -1) return;
                    tablename = strSQLtemp.Substring(index2 + 4, index3 - (index2 + 4)).Trim();
                    string cellpos = strSQLtemp.Substring(index1 + 6, index2 - (index1 + 6)).Trim();
                    //cbxWorkDbTable.SelectedItem = tablename;
                    //cbxWorkTableColumns.Text = cellpos;
                    setComoboxFocusIndex(cbxWorkDbTable, tablename);
                    setComoboxFocusIndex(cbxWorkDbTableColumns, cellpos);
                    tetWorkSQL.Text = strSQLtemp;
                }

            }
            else
            {
                tetWorkFixValue.Text = "";
                tetWorkSQL.Text = "";
                simpleButton3.Text = "添加";
            }
        }

       

       

    }
}
