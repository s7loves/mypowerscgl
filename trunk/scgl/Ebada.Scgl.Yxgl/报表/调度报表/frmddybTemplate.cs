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

namespace Ebada.Scgl.Yxgl
{
    public partial class frmddybTemplate : DevExpress.XtraEditors.XtraForm
    {
        string filepath = Path.GetTempPath();
        xxgx_ddyb _pjobject;
        public frmddybTemplate()
        {
            InitializeComponent();
            this.Text = "调度报表";
        }
        public xxgx_ddyb pjobject
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
        public void Show(xxgx_ddyb obj)
        {
            _pjobject = obj;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pjobject!=null)
            {
                try
                {
                   dsoFramerControl1.FileSave();
                   pjobject.filedata = dsoFramerControl1.FileDataGzip;
                   Client.ClientHelper.PlatformSqlMap.Update<xxgx_ddyb>(pjobject);
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
                    if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                    {
                        ExcelAccess ex = new ExcelAccess();
                        ex.Open(fname);
                        //此处写填充内容代码

                        ex.ShowExcel();
                        return;
                    }
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
            dsoFramerControl1.FileDataGzip = _pjobject.filedata;
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
            pjobject.filedata = dsoFramerControl1.FileDataGzip;
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

    }
}