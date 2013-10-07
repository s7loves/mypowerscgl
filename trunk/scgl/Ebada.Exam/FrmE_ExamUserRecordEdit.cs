using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.UI.Base;
using System.IO;

namespace Ebada.Exam
{
    public partial class FrmE_ExamUserRecordEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_ExamUserRecord> m_CityDic = new SortableSearchableBindingList<E_ExamUserRecord>();
        public FrmE_ExamUserRecordEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtTitle.DataBindings.Add("EditValue", rowData, "Name");
            this.txtPost.DataBindings.Add("EditValue", rowData, "Post");

            this.mtxtContent.DataBindings.Add("EditValue", rowData, "ExamRecord");
            this.txtOther.DataBindings.Add("EditValue", rowData, "OrgName");



        }
        private E_ExamUserRecord rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as E_ExamUserRecord;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_ExamUserRecord>(value as E_ExamUserRecord, rowData);
                }
                if (rowData.OrgName.Length>0)
                {
                    btnDownLoad.Enabled = true;
                }
                else
                {
                    btnDownLoad.Enabled = false;
                }
                txtFileName.EditValue = string.Empty;
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pname = txtTitle.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("标题不能为空！");
                return;
            }
            if (mtxtContent.Text.Trim().Length == 0)
            {
                MsgBox.ShowWarningMessageBox("内容不能为空！");
                return;
            }
            if (rowData.WordData.Length==0)
            {
                rowData.OrgName = string.Empty;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void BrowserFile()
        {
            string filePath = "";
            string fileName = "";
            string type = "";

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtFileName.Text = filePath;
                
                fileName = Path.GetFileName(filePath);
                type = Path.GetExtension(filePath);
                rowData.BySCol1 = type;
                FileStream fsBLOBFile = null;
                Byte[] bytBLOBData = null;

                fsBLOBFile = new FileStream(filePath, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite);
                bytBLOBData = new Byte[fsBLOBFile.Length];

                if (bytBLOBData.Length > 999999999)
                {
                    MsgBox.ShowWarningMessageBox("上传资源最大支持999999999字节(约953.67M)");
                    return;
                }
                fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                rowData.WordData = bytBLOBData;
                fsBLOBFile.Close();

                txtOther.EditValue = fileName;
                rowData.OrgName = fileName;
                txtFileName.EditValue = filePath;

            }
          
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            BrowserFile();
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {

            CommentHelper.SaveFile(rowData.WordData,rowData.BySCol1);
        }


    }
}
