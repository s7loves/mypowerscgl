using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Reflection;
using Ebada.Client;
using Ebada.Client.Platform;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmTemplate : DevExpress.XtraEditors.XtraForm
    {
       // Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application(); //引用Excel对象
        string uid1 = "";
        string filename = "";
        string filepath = Path.GetTempPath();
        private DataTable dt = null;
        private IList<PJ_yfsyjl> dtlist = null;
        private StringBuilder strMerCol;
        public DataTable dataTable
        {
            set {dt=value ;  }
            
        }
        public IList<PJ_yfsyjl> dataList
        {
            set { dtlist = value; }

        }
        public StringBuilder MerColNames
        {
            set { strMerCol = value; }

        }


        public frmTemplate()
        {
            InitializeComponent();
        }
     

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                string fname = "";
                saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname = saveFileDialog1.FileName;
                    
                    gridControl1.ExportToXls(fname); 
                    DSOFramerControl fc=new DSOFramerControl ();
                    fc.FileOpen (fname);
                    Excel.Workbook wb = fc.AxFramerControl.ActiveDocument as Excel.Workbook;
                    Excel.Worksheet xx = wb.Application.Sheets[1] as Excel.Worksheet;
                    int i=xx.UsedRange.Columns.Count;
                    int j = xx.UsedRange.Columns.Count;
                    for(i=1;i<=xx.UsedRange.Columns.Count;i++)
                        for (j = 1; j <= xx.UsedRange.Rows.Count; j++)
                        {
                            Excel.Range range = (Excel.Range)xx.get_Range(xx.Cells[j, i], xx.Cells[j, i]);
                            range.Interior.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                        }

                    fc.FileSave( );
                    fc.FileClose();
                    fc.Dispose();
                    if (MessageBox.Show("导出成功，是否打开该文档？", "警告", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    System.Diagnostics.Process.Start(fname);
                }

        }

        private void frm26Template_Load(object sender, EventArgs e)
        {
            if (dtlist != null)
            {
                gridControl1.DataSource = dtlist;
            }
            else
            if (dt != null)
            {
                gridControl1.DataSource = dt;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }

        private void frm24Template_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }


    }
}