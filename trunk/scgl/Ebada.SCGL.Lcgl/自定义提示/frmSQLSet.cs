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
    public partial class frmSQLSet : FormBase
    {
        public frmSQLSet()
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
            strSQL = tetWorkSQL.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void frmExcelEditSQLSet_Load(object sender, EventArgs e)
        {

            IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", "  where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) ");
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDataTable, dt, "LPID", "CellName");

          
          

         
           
           

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
             memoEdit1.Text = "说明 SQL语句支持中的特殊代码\r\n {sortid}:当前表单的序号为sortid的字段\r\n{recordid}:票LP_Record的ID\r\n{orgcode}:用户单位编号\r\n{userid}:用户编号\r\n{编号规则一:单位的sortid}:把26个供电所按顺序编号分别为01、02、03以此类推，001为单据编号\r\n";
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);
            if (strSQL != "")
            {
                
                 if (strSQL.IndexOf("10=10") > -1)
                {
                   
                    Regex r1 = new Regex(@"(?<=UserControlId=').*?(?=')");
                    //cbxWorkDataTable.Text = r1.Match(strSQL).Value;
                    setComoboxFocusIndex(cbxWorkDataTable, r1.Match(strSQL).Value);
                    r1 = new Regex(@"(?<=FieldId=').*?(?=')");
                    //cbxWorkTableColumns.Text = r1.Match(strSQL).Value;
                    setComoboxFocusIndex(cbxWorkTableColumns, r1.Match(strSQL).Value);
                }
                else
                {
                   
                    int index1 = strSQL.ToLower().IndexOf("select");
                    int index2 = strSQL.ToLower().IndexOf("from");
                    int index3 = strSQL.ToLower().IndexOf("where");
                    if (index3 == -1) index3 = strSQL.Length;
                    string tablename = "";
                    if (index1 == -1 || index2 == -1 || index3 == -1) return;
                    tablename=strSQL.Substring(index2 + 4, index3 - (index2 + 4)).Trim().Replace("dbo.","");
                    string cellpos = strSQL.Substring(index1 + 6, index2 - (index1 + 6)).Trim();
                    //cbxWorkDbTable.SelectedItem = tablename;
                    //cbxWorkTableColumns.Text = cellpos;
                    setComoboxFocusIndex(cbxWorkDbTable, tablename);
                    setComoboxFocusIndex(cbxWorkDbTableColumns, cellpos);
                    tetWorkSQL.Text = strSQL;
                }

            }
           
        }
        void setComoboxFocusIndex(ComboBox cbx,string text)
        {
            int focusindex =-1, i = 0;
            foreach (Ebada.SCGL.WFlow.Tool.ListItem it in cbx.Items)
            {

                Ebada.SCGL.WFlow.Tool.ListItem l = it as Ebada.SCGL.WFlow.Tool.ListItem;
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
            if (cbxDbTable.SelectedIndex > 0  )
            {
                if (cbxDbTableColumns.SelectedIndex > 0)
                {
                    IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + ((Ebada.SCGL.WFlow.Tool.ListItem)cbxDbTable.SelectedItem).ID + "'");
                    if (list.Count > 0 && 1 == 0)
                    {
                        tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                    }
                    else
                    {
                        tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 ";
                    }
                }
                else
                {
                    tetSQL.Text = "select * from " + cbxDbTable.Text + " where 5=5 ";
                
                }
                
            }

        }
        private void cbxWorkDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxWorkDbTable.SelectedIndex <1) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((Ebada.SCGL.WFlow.Tool.ListItem)cbxWorkDbTable.SelectedItem).ID);
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
                "where ParentID ='" + ((Ebada.SCGL.WFlow.Tool.ListItem)cbxWorkDataTable.SelectedItem).ID + "' order by sortid");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            for (int i = 0; i < dt.Rows.Count&&li.Count>0; i++)
            {
                dt.Rows[i]["cellname"] = dt.Rows[i]["SortID"] + " " + dt.Rows[i]["cellname"];
            
            }
            WinFormFun.LoadComboBox(cbxWorkTableColumns, dt, "LPID", "cellname");
            cbxWorkTableColumns.SelectedIndex = 0;
        }

        private void cbxWorkTableColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorkTableColumns.SelectedIndex < 1)
            {
                tetWorkSQL.Text = "select ControlValue from WF_TableFieldValue where 10=10  "
                      + "and UserControlId='" + ((Ebada.SCGL.WFlow.Tool.ListItem)cbxWorkDataTable.SelectedItem).ID + "' ";
                return;
            }
            tetWorkSQL.Text = "select ControlValue from WF_TableFieldValue where 10=10  "
                  + "and UserControlId='" + ((Ebada.SCGL.WFlow.Tool.ListItem)cbxWorkDataTable.SelectedItem).ID + "' "
                  + " and FieldId='" + ((Ebada.SCGL.WFlow.Tool.ListItem)cbxWorkTableColumns.SelectedItem).ID + "' ";
              
        }

       

       

    }
}
