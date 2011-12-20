using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Collections;
using Ebada.Client.Platform;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Core;
using Ebada.Scgl.Model;
using Excel = Microsoft.Office.Interop.Excel;
using Ebada.Client;
using Ebada.Core;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Repository;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class uc_gridcontrol : UserControl
    {
        private char pcomboxitem = ',';
        private IList<DevExpress.XtraEditors.Repository.RepositoryItemComboBox> colctrllist;
        string[] m_ColName;
        private bool gridFlag = false;
        public IList<DevExpress.XtraEditors.Repository.RepositoryItemComboBox> colCtrlList
        {
            get { return colctrllist; }
        }
        public DataTable GetDS()
        {
            gridControl1.RefreshDataSource();
            return gridControl1.DataSource as DataTable;
        }
        public void SetDs(DataTable ds)
        {
            gridControl1.DataSource = ds;
        }
        public uc_gridcontrol()
        {
            InitializeComponent();
            colctrllist = new List<DevExpress.XtraEditors.Repository.RepositoryItemComboBox>();
            gridControl1.UseEmbeddedNavigator = true;
            gridControl1.Dock = DockStyle.Fill;
        }

        private void uc_gridcontrol_Load(object sender, EventArgs e)
        {
            
        }

        public void InitCol(string[] arrCol,LP_Temple lp)
        {
            m_ColName = arrCol;
            DataTable ds = new DataTable();
            for (int i = 0; i < arrCol.Length;i++ )
            {
                if (arrCol[i].ToString() == "") continue;
                ds.Columns.Add(arrCol[i]);
                ds.Columns[i].Caption = arrCol[i];
            }    
            gridControl1.DataSource = ds;
            DevExpress.XtraGrid.Views.Grid.GridView grid = gridView1;
            grid.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grid.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;           
            grid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grid.OptionsView.ShowGroupPanel = false;
            string[] comItem = SelectorHelper.ToDBC(lp.ComBoxItem).Split('|');          
            for (int i = 0; i < grid.Columns.Count; i++)
            {

                if (grid.Columns[i].FieldName == "序号" || grid.Columns[i].FieldName == "月份" || grid.Columns[i].FieldName == "季度")
                {
                    grid.Columns[i].Width = 20;
                }
                Regex r1 = new Regex(@"(?<=" + i + ":).*?(?=])");
                string strcom = r1.Match(comItem[i]).Value;
               
                if (strcom.IndexOf("RepositoryItemDateEdit") > -1)
                {
                    r1 = new Regex(@"(?<=:).*");
                    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit date =
                             new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                    if (r1.Match(strcom).Value != "")
                    {
                        date.Properties.EditMask = r1.Match(strcom).Value;
                        date.Mask.UseMaskAsDisplayFormat = true;
                        if (r1.Match(strcom).Value.ToLower().IndexOf("hh") > -1)
                        {
                            date.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
                            date.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
                        }
                    }
                    grid.Columns[i].ColumnEdit = date;
                    grid.Columns[i].DisplayFormat.FormatString = date.Properties.EditMask;
                    grid.Columns[i].ColumnEdit.EditFormat.FormatString = date.Properties.EditMask;
                }
                else if (strcom.IndexOf("RepositoryItemCalcEdit") > -1)
                {
                    r1 = new Regex(@"(?<=:).*");
                    DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit date =
                             new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
                    if (r1.Match(strcom).Value != "")
                        date.Properties.EditMask = r1.Match(strcom).Value;

                    grid.Columns[i].ColumnEdit = date;
                }
                 else
                    {
                       
                        DevExpress.XtraEditors.Repository.RepositoryItemComboBox lue1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                        
                        lue1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                        grid.Columns[i].ColumnEdit = lue1;
                        colctrllist.Add(lue1);

                    }
                
            }           
        }
        public int[] GetCellPos(string cellpos)
        {
            cellpos = cellpos.Replace("|", "");
            Regex r1 = new Regex(@"[0-9]+");
            string str = r1.Match(cellpos).Value;
            int ix = 0;
            int iy = 0;
            ix = int.Parse(str);
            r1 = new Regex(@"[A-Z]+");
            str = r1.Match(cellpos).Value;
            if (str.Length == 2)
            {
                iy = ((int)str[0] - 64) * 26 + ((int)str[1] - 64);
            }
            else
            {
                iy = (int)cellpos[0] - 64;
            }
            return new int[] { ix, iy };
            //return new int[] { int.Parse(cellpos.Substring(1)), (int)cellpos[0] - 64 };
        }
        public void InitCtrlData(RepositoryItemComboBox combox,int index,LP_Temple lp, string sqlSentence, DSOFramerControl dsoFramerWordControl1, LP_Record currRecord)
        {

            
            string ctrltype = "";
            if (lp.CtrlType.IndexOf(',') == -1)
                ctrltype = lp.CtrlType;
            else
                ctrltype = lp.CtrlType.Substring(0, lp.CtrlType.IndexOf(','));
            /*
             * 
             * SELECT   cellname,  SqlSentence,SqlColName
                FROM         LP_Temple
                where SqlSentence !=''
             * 
             * */
            IList li = new ArrayList();
            if (sqlSentence.IndexOf("Excel:") == 0)
            {
                int index1 = sqlSentence.LastIndexOf(":");
                string tablename = sqlSentence.Substring(6, index1 - 6);
                string cellpos = sqlSentence.Substring(index1 + 1);
                string[] arrCellPos = cellpos.Split('|');
                arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                string strcellvalue = "";
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                Excel.Worksheet sheet;
                sheet = wb.Application.Sheets[tablename] as Excel.Worksheet;

                for (int i = 0; i < arrCellPos.Length; i++)
                {
                    Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                    strcellvalue += range.Value2;
                }
                li.Add(strcellvalue);
            }
            else if (sqlSentence != "")
            {
                if (sqlSentence.IndexOf("{recordid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{recordid}", currRecord.ID);
                }
                if (sqlSentence.IndexOf("{orgcode}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{orgcode}", MainHelper.User.OrgCode);
                }
                if (sqlSentence.IndexOf("{userid}") > -1)
                {
                    sqlSentence = sqlSentence.Replace("{userid}", MainHelper.User.UserID);
                }
                Regex r1 = new Regex(@"(?<={)[0-9]+(?=})");
                while (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                       
                        
                        
                            string strSQL = "select ControlValue from WF_TableFieldValueView where"
                                  + " UserControlId='" + listLPID[0].ParentID + "' "
                                  + "and FieldId='" + listLPID[0].LPID + "' and ID='" + currRecord.ID + "'";
                            li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strSQL);
                            if (li.Count > 0)
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", li[0].ToString());
                            }
                            else
                            {
                                sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                                break;
                            }
                        
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{" + sortid + "}", "没有找到对应的值，请检查SQL语句设置");
                        break;
                    }
                }
                r1 = new Regex(@"(?<={编号规则一:)[0-9]+(?=})");
                if (r1.Match(sqlSentence).Value != "")
                {
                    string sortid = r1.Match(sqlSentence).Value;
                    IList<LP_Temple> listLPID = ClientHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList", " where sortID = '" + sortid + "' and parentid = '" + lp.ParentID + "'");
                    if (listLPID.Count > 0)
                    {
                        
                            sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                        
                    }
                    else
                    {
                        sqlSentence = sqlSentence.Replace("{编号规则一:" + sortid + "}", "出错，没有找到单位控件");

                    }

                }
               
                    sqlSentence = sqlSentence.Replace("\r\n", "");

                    try
                    {
                        li = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", sqlSentence);
                    }
                    catch (Exception ex)
                    {
                        li.Add(sqlSentence+"出错:" + ex.Message);

                    }
                        if (sqlSentence.IndexOf("where 9=9") == -1)
                        {
                            foreach (string strname in li)
                            {
                                combox.Items.Add(strname);
                            }
                        }
                        else
                        {
                           
                            switch (li[0].ToString())
                            {
                                case "{年}":
                                    combox.Items.Clear();
                                    for (int j = 0; j <= 20; j++)
                                    {
                                        combox.Items.Add(string.Format("{0}", j + DateTime.Now.Year));

                                    }

                                    break;
                                case "{月}":
                                    combox.Items.Clear();
                                    for (int j = 1; j <= 12; j++)
                                    {
                                        combox.Items.Add(string.Format("{0:D2}", j));

                                    }
                                    break;
                                case "{日}":
                                    combox.Items.Clear();
                                    for (int j = 1; j <= 31; j++)
                                    {
                                        combox.Items.Add(string.Format("{0:D2}", j));

                                    }
                                    break;
                                case "{时}":
                                    combox.Items.Clear();
                                    for (int j = 1; j <= 24; j++)
                                    {
                                        combox.Items.Add(string.Format("{0:D2}", j));

                                    }
                                    break;
                                case "{分}":
                                case "{秒}":
                                    combox.Items.Clear();
                                    for (int j = 0; j <= 59; j++)
                                    {
                                        combox.Items.Add(string.Format("{0:D2}", j));

                                    }
                                    break;
                                default:
                                    string strexpress = li[0].ToString();
                                    r1 = new Regex(@"[0-9]+\+[0-9]+");
                                    if (r1.Match(strexpress).Value != "")
                                    {
                                        int istart = 1;
                                        int ilen = 10;
                                        r1 = new Regex(@"[0-9]+(?=\+)");
                                        if (r1.Match(strexpress).Value != "")
                                        {
                                            istart = Convert.ToInt32(r1.Match(strexpress).Value);
                                        }
                                        r1 = new Regex(@"(?<=\+)[0-9]+");
                                        if (r1.Match(strexpress).Value != "")
                                        {
                                            ilen = Convert.ToInt32(r1.Match(strexpress).Value); ;
                                        }
                                        for (int i = istart; i <= ilen; i++)
                                        {
                                            combox.Items.Add(string.Format("{0}", i));
                                        }
                                    }
                                    else
                                    {
                                        string[] strItem = SelectorHelper.ToDBC(strexpress).Split(',');
                                        for (int i = 0; i < strItem.Length; i++)
                                        {
                                            combox.Items.Add(strItem[i]);
                                        }

                                    }
                                    break;
                            }

                        }
            }
        }
        public void InitData(string sql,string[] sqlColName,string[] comBoxItem,DSOFramerControl dsoFramerWordControl1,LP_Temple lp,LP_Record currRecord)
        {

           
            //foreach (DevExpress.XtraEditors.Repository.RepositoryItemComboBox combox in colctrllist)
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                if (gridView1.Columns[i].ColumnEdit is RepositoryItemComboBox)
                {
                    RepositoryItemComboBox combox = gridView1.Columns[i].ColumnEdit as RepositoryItemComboBox;
                    combox.Items.Clear();
                   
                        Regex r1 = new Regex(@"(?<=\[" + i + ":).*?(?=\\])");
                        string sqlSentence = "";
                        if (r1.Match(sql).Value != "")
                        {
                            sqlSentence = r1.Match(sql).Value;
                        }
                        if (sqlSentence != "")
                            InitCtrlData(combox, i, lp, sqlSentence, dsoFramerWordControl1, currRecord);

                   
                }
            }
           
        }

        public string[] SplitSQL(string sql)
        {
            int pos = sql.IndexOf("where");
            string temp = "";
            return new string[] { pos == -1 ? (temp=sql.Replace(" ","")) : 
                (temp=sql.Substring(0, pos).Replace(" ","")), pos == -1 ? "" : sql.Substring(pos) };
        }

        public string[] GetContent(List<int> wcount)
        {
            StringHelper sh = new StringHelper();
            string[] colArr = new string[m_ColName.Length];
            string[] useforadd = new string[m_ColName.Length];
            int[] rows = new int[m_ColName.Length];
            int max = 1;
            string newrow = "";
            DataTable dt=GetDS();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                max = 1; 
                
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //DataRow dr= gridView1.GetDataRow(j);
                    string oneCol = dt.Rows[j][i].ToString();
                    if (gridView1.Columns[i].ColumnEdit is RepositoryItemDateEdit && oneCol!="")
                    {
                        DevExpress.XtraEditors.DateEdit de = new DevExpress.XtraEditors.DateEdit();
                        de.DateTime = Convert.ToDateTime(oneCol);
                        de.Properties.Mask.EditMask = gridView1.Columns[i].ColumnEdit.EditFormat.FormatString;
                        de.Properties.Mask.UseMaskAsDisplayFormat = true;
                        oneCol = de.Text;
                    }
                    //if (oneCol != "")
                    {
                        //string splitRst = sh.GetPlitStringN(oneCol, wcount[i]);
                        if (oneCol == "") oneCol = " ";
                        string splitRst = oneCol;
                        if (oneCol.Length > wcount[i]) splitRst = oneCol.Substring(0, wcount[i]);
                        //if (GetPlitLen(splitRst) > max)
                        //    max = GetPlitLen(splitRst);
                        colArr[i] += newrow+splitRst;
                        useforadd[i] = newrow + splitRst;
                        if (i == dt.Columns.Count - 1 && max != 1)
                        {
                            AddMauRow(ref colArr, useforadd, max);
                        }
                    }
                }
                newrow = "\r\n";
            }
            RomoveEnd(ref colArr);
            
            return colArr;
        }

        public int GetPlitLen(string str)
        {
            return str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public void RomoveEnd(ref string[] colArr)
        {
            for (int i = 0; i < colArr.Length; i++)
            {
                if (colArr[i]!=null &&　colArr[i].EndsWith("\r\n"))
                    colArr[i] = colArr[i].Substring(0, colArr[i].Length - 2);
            }
        }

        public void AddMauRow(ref string[] colArr,string[] useforadd, int max)
        {
            for (int i = 0; i < useforadd.Length; i++)
            {
                for (int j = 0;useforadd[i]!=null && j < max - GetPlitLen(useforadd[i].Substring(0, useforadd[i].Length - 2)); j++)
                {
                    colArr[i] += "\r\n";
                }
            }
        }

        public string ConvertBetweenDataTableAndXML_AX(DataTable dtNeedCoveret)
        {
            System.IO.TextWriter tw = new System.IO.StringWriter();
            //if TableName is empty, WriteXml() will throw Exception.
            dtNeedCoveret.TableName = dtNeedCoveret.TableName.Length == 0 ? "Table_AX" : dtNeedCoveret.TableName;
            dtNeedCoveret.WriteXml(tw);
            dtNeedCoveret.WriteXmlSchema(tw);
            return tw.ToString();
        }

        public DataTable ConvertBetweenDataTableAndXML_AX(string xml)
        {
            System.IO.TextReader trDataTable = new System.IO.StringReader(xml.Substring(0, xml.IndexOf("<?xml")));
            System.IO.TextReader trSchema = new System.IO.StringReader(xml.Substring(xml.IndexOf("<?xml")));
            DataTable dtReturn = new DataTable();
            dtReturn.ReadXmlSchema(trSchema);
            dtReturn.ReadXml(trDataTable);
            return dtReturn;
        }
        public event CellValueChangedEventHandler CellValueChanged;
        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            sender = this;
            int i = 0;
            i = e.RowHandle;
            DataView dt = gridView1.DataSource as DataView;
            if (i<0)
            {
                //gridView1.UpdateCurrentRow();
                //CellValueChanged(this, e);               
                return;
            }
            dt.Table.Rows[i][e.Column.FieldName] = e.Value;
            CellValueChanged(this, e);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedRowHandle  < 0)
            {
                DataView dt = gridView1.DataSource as DataView;
                if (dt.Table.Rows.Count <= 0)
                {
                    dt.Table.Rows.Add(dt.Table.NewRow());
                    gridFlag = true;
                }
                else
                {
                    if (gridFlag)
                    {
                        if (dt.Table.Rows.Count>0)
                        {
                            gridView1.FocusedRowHandle = dt.Table.Rows.Count - 1;
                        }
                        gridFlag = false;
                    }
                    else
                    {
                        dt.Table.Rows.Add(dt.Table.NewRow());
                        gridView1.FocusedRowHandle = dt.Table.Rows.Count - 1;
                    }                
                    
                }
                             
            }
        }

    }
}
