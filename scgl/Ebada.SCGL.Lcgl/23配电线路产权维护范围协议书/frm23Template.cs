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
using Excel = Microsoft.Office.Interop.Excel;

namespace Ebada.Scgl.Lcgl
{
    public partial class frm23Template : DevExpress.XtraEditors.XtraForm
    {
       // Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application(); //引用Excel对象
        string uid1 = "";
        string filename = "";
        string filepath = Path.GetTempPath();
        PJ_23 _pjobject;

        public frm23Template()
        {
            InitializeComponent();
        }
        public PJ_23 pjobject
        {
            get
            {
                return _pjobject;
            }
            set
            {
                _pjobject = value;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pjobject!=null)
            {
                try
                {
                    // dsoFramerControl1.FileSave(filename, true);
                    //dsoFramerControl1.FileName = filename;
                   dsoFramerControl1.FileSave();
                   pjobject.BigData = dsoFramerControl1.FileData;
                    Client.ClientHelper.PlatformSqlMap.Update<PJ_23>(pjobject);
                }
                catch (System.Exception ex)
                {
                    dsoFramerControl1.FileClose();
                    dsoFramerControl1.Dispose();
                    dsoFramerControl1 = null;
                }
             

            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
              SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = "";
            saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog1.FileName;
                try
                {
                    dsoFramerControl1.FileSave(saveFileDialog1.FileName, true);
                    //dsoFramerControl1.Dispose();

                    //dsoExcelControl1.AxFramerControl.Save(fname,true,null,null);
                    // dsoExcelControl1.FileSaveAs(out fname);
                    //if (MsgBox.Show("导出成功!") != DialogResult.Yes)
                    //////MsgBox.Show("导出成功!");
                    //////dsoExcelControl1.AxFramerControl.Dispose();
                    //////return;

                    if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                    {
                        //dsoExcelControl1.AxFramerControl.Dispose();
                        //dsoExcelControl1.Dispose();
                        ExcelAccess ex = new ExcelAccess();
                        //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        //string fname = Application.StartupPath + "\\00记录模板\\26防护通知书.xls";

                        ex.Open(fname);
                        //此处写填充内容代码

                        ex.ShowExcel();
                        //Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application(); //引用Excel对象
                        //Microsoft.Office.Interop.Excel.Workbook book = exc.Application.Workbooks.Add(fname); //引用Excel工作簿
                        //exc.Visible = true; //使Excel可视
                        return;
                    }
                    //System.Diagnostics.Process.Start(fname);

                    //ExcelAccess ex = new ExcelAccess();
                    ////SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    ////string fname = Application.StartupPath + "\\00记录模板\\26防护通知书.xls";

                    //ex.Open(fname);
                    ////此处写填充内容代码

                    //ex.ShowExcel();




                    //  System.Diagnostics.Process.Start(fname);
                }
                catch
                {
                    MsgBox.ShowSuccessfulMessageBox("无法保存" + fname + "。请用其他文件名保存文件，或将文件存至其他位置。");
                    return;
                }
            }
        }

        private void frm26Template_Load(object sender, EventArgs e)
        {
            initcomment();
            string fname = filepath + Guid.NewGuid().ToString() + ".xls";
            filename = fname;
            fname = Application.StartupPath + "\\00记录模板\\23配电线路产权维护范围协议书.xls";
            if (pjobject.BigData==null)
            {
                dsoFramerControl1.FileOpen(fname);
            }
            else
            {
                if (pjobject.BigData.Length!=0)
                {
                    dsoFramerControl1.FileData = pjobject.BigData;
                }
                else
                {
                    dsoFramerControl1.FileOpen(fname);
                }
            }
        }
        private void initcomment()
        {
          IList<string> ilist=  MainHelper.PlatformSqlMap.GetList<string>("SelectOneStr","select picName from PJ_tbsj");
          repositoryItemLookUpEdit1.DataSource = ilist;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dsoFramerControl1.FileSave();
            pjobject.BigData = dsoFramerControl1.FileData;
            dsoFramerControl1.FileClose();
            dsoFramerControl1.Dispose();
            dsoFramerControl1 = null;
            this.DialogResult = DialogResult.OK;
        }

        private void frm23Template_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dsoFramerControl1 != null)
            {
                dsoFramerControl1.FileClose();
                dsoFramerControl1.Dispose();
                dsoFramerControl1 = null;
            }
        }

        void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
          


        }

        private void barEditItem1_EditValueChanged_1(object sender, EventArgs e)
        {
            PJ_tbsj tb = MainHelper.PlatformSqlMap.GetOne<PJ_tbsj>("where picName = '" + barEditItem1.EditValue + "'");

            if (tb.picName != "表箱")
            {
                string tempPath = Path.GetTempPath();
                string tempfile = tempPath + "~" + Guid.NewGuid().ToString() + tb.S1;
                FileStream fs;
                fs = new FileStream(tempfile, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(tb.picImage);
                bw.Flush();
                bw.Close();
                fs.Close();
                //IDataObject data = new DataObject(DataFormats.FileDrop, new string[] { tempfile });
                //MemoryStream memo = new MemoryStream(4);
                //byte[] bytes = new byte[] { (byte)(5), 0, 0, 0 };
                //memo.Write(bytes, 0, bytes.Length);
                //data.SetData("ttt", memo);
                //Clipboard.SetDataObject(data);
                Image im = Bitmap.FromFile(tempfile);
                Bitmap bt = new Bitmap(im);
                DataObject dataObject = new DataObject();
                dataObject.SetData(DataFormats.Bitmap, bt);
                Clipboard.SetDataObject(dataObject, true);
            }
            else
            {
                Excel.Workbook wb = dsoFramerControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                Excel.Worksheet xx = wb.Application.Sheets[1] as Excel.Worksheet;
                Microsoft.Office.Interop.Excel.Shape activShape = null;
                activShape = xx.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                    (float)153.75, (float)162.75, (float)22.5, (float)10.5);
                activShape.TextFrame.Characters(1, 1).Font.Size = 8;
                activShape.TextFrame.Characters(1, 1).Text = "1";
                activShape.TextFrame.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                activShape.Cut();
            }
        }

    }
}