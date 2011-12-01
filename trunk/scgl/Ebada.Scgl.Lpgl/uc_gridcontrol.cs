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

namespace Ebada.Scgl.Lpgl
{
    public partial class uc_gridcontrol : UserControl
    {
        private char pcomboxitem = '，';
        private IList<DevExpress.XtraEditors.Repository.RepositoryItemComboBox> colctrllist;
        string[] m_ColName;
        private bool gridFlag = false;
        public IList<DevExpress.XtraEditors.Repository.RepositoryItemComboBox> colCtrlList
        {
            get { return colctrllist; }
        }
        public DataTable GetDS()
        {
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

        public void InitCol(string[] arrCol)
        {
            m_ColName = arrCol;
            DataTable ds = new DataTable();
            for (int i = 0; i < arrCol.Length;i++ )
            {
                ds.Columns.Add(arrCol[i]);
                ds.Columns[i].Caption = arrCol[i];
            }    
            gridControl1.DataSource = ds;
            DevExpress.XtraGrid.Views.Grid.GridView grid = gridView1;
            grid.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grid.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;           
            grid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grid.OptionsView.ShowGroupPanel = false;            
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                DevExpress.XtraEditors.Repository.RepositoryItemComboBox lue1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                grid.Columns[i].ColumnEdit = lue1;
                lue1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                colctrllist.Add(lue1);
            }           
        }

        public void InitData(string[] sql,string[] sqlColName,string[] comBoxItem)
        {

            int k = 0;
            foreach (DevExpress.XtraEditors.Repository.RepositoryItemComboBox combox in colctrllist)
            {
                combox.Items.Clear();
                if (sql.Length != 0)
                {
                    if (sql[k] != "")
                    {
                        IList rstlist = MainHelper.PlatformSqlMap.GetList(SplitSQL(sql[k])[0], SplitSQL(sql[k])[1]);
                        for (int i = 0; i < rstlist.Count; i++)
                        {
                            combox.Items.Add(rstlist[i].GetType().GetProperty(sqlColName[k]).GetValue(rstlist[i], null));
                        }
                    }
                }
                if (comBoxItem.Length>k)
                {
                    //string[] comItem = comBoxItem[k].Split(pcomboxitem);
                    string[] comItem = SelectorHelper.ToDBC(comBoxItem[k]).Split(pcomboxitem);
                    for (int i = 0; i < comItem.Length;i++ )
                    {
                        if (comItem[i]!="")
                        {
                            switch (comItem[i])
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
                                    combox.Items.Add(comItem[i]);
                                    break;
                            }
                        }
                    }
                }
                k++;
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
            DataTable dt=GetDS();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                max = 1; 
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string oneCol = dt.Rows[j][i].ToString();
                    string splitRst = sh.GetPlitStringN(oneCol, wcount[i]);
                    if (GetPlitLen(splitRst) > max)
                        max = GetPlitLen(splitRst);
                    colArr[i] += splitRst;
                    useforadd[i] = splitRst;
                    if (i == dt.Columns.Count - 1 && max != 1)
                    {
                        AddMauRow(ref colArr,useforadd, max);
                    }
                }
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
                for (int j = 0; j < max - GetPlitLen(useforadd[i].Substring(0, useforadd[i].Length - 2)); j++)
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
