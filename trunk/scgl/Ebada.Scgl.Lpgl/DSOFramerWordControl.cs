using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using TONLI.Zip;
using DSOFramer;

namespace TONLI.dsoframers
{

    public partial class DSOFramerWordControl : UserControl
    {
        //static Word.Application wordApp;
        private Word.Application wordApp2;

        string tempPath;//��ʱ�ļ�Ŀ¼
        string fileName;//�ļ�·��
        bool isTempFile = false;//�Ƿ���ʱ�ļ�

        string desktopPath;
        public event EventHandler OnFileSaved;//�����ļ�ʱ����
        bool isModified;//�ĵ��Ƿ��޸�
        bool isReadOnly = false;

        object Nothing = System.Type.Missing;
        object missing = System.Type.Missing;
        public DSOFramerWordControl()
        {
            try
            {
                initCom();
            }
            catch { MessageBox.Show("����Excelʧ�ܣ����ϵͳ�Ƿ��Ѱ�װOffice"); return; }
            InitializeComponent();
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            tempPath = Path.GetTempPath();
            this.axFramerControl1.set_EnableFileCommand(dsoFileCommandType.dsoFilePrintPreview, false);

            //this.axFramerControl1.ActivationPolicy = DSOFramer.dsoActivationPolicy.dsoKeepUIActiveOnAppDeactive;
        }
        public void CanPrintView()
        {
            this.axFramerControl1.set_EnableFileCommand(dsoFileCommandType.dsoFilePrintPreview, true);
            //this.axFramerControl1.ActivationPolicy = DSOFramer.dsoActivationPolicy.dsoKeepUIActiveOnAppDeactive;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        private void initCom()
        {
            //System.Diagnostics.Process[] pTemp = System.Diagnostics.Process.GetProcesses();
            //int count = 0;
            //foreach (System.Diagnostics.Process pTempProcess in pTemp)
            //    if ((pTempProcess.ProcessName.ToLower() == ("winword").ToLower()) || (pTempProcess.ProcessName.ToLower()) == ("winword.exe").ToLower()) {
            //        count++;
            //    }

            ////����������WordApp

            //for (int i = 0; i < (2 - count); i++) {
            //    wordApp2 = new Word.ApplicationClass();
            //}
        }

        #region ��������
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set { isReadOnly = value; }
        }
        public AxDSOFramer.AxFramerControl AxFramerControl
        {
            get
            {
                return axFramerControl1;
            }
        }
        public Word.Workbook MyWorkbook
        {
            get {
                return axFramerControl1.ActiveDocument as Word.Workbook;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public bool IsModified
        {
            get { return isModified; }
            set { isModified = value; }
        }
        [Browsable(false)]
        public bool IsTempFile
        {
            get { return isTempFile; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public string TempPath
        {
            get
            {
                if (string.IsNullOrEmpty(tempPath))
                {
                    tempPath = Application.StartupPath + "\\LocalSettings\\TEMP";
                }
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                return tempPath;
            }
            set
            {
                tempPath = value;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public byte[] FileData
        {
            get
            {
                byte[] buff = new byte[0];
                if (File.Exists(fileName))
                {
                    string filecopy = fileName + "_";
                    File.Copy(fileName, filecopy);

                    using (FileStream fs = File.OpenRead(filecopy))
                    {
                        buff = new byte[(int)fs.Length];
                        fs.Read(buff, 0, (int)fs.Length);
                    }
                    File.Delete(filecopy);

                }
                return buff;
            }
            set
            {
                if (value == null || value.Length == 0) return;
                string file2 = GetTempFileName();

                using (FileStream fs = File.Create(file2))
                {
                    fs.Write(value, 0, value.Length);
                }

                FileOpen(file2);
                fileName = file2;
                isTempFile = true;
            }
        }
        /// <summary>
        /// ѹ���ļ�
        /// </summary>
        /// 
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public byte[] FileDataGzip
        {
            get
            {
                byte[] buff = new byte[0];
                if (File.Exists(fileName))
                {
                    string filecopy = fileName + "_";
                    string gzFile = string.Empty;
                    //�����ļ�
                    File.Copy(fileName, filecopy);
                    //ѹ���ļ�
                    try
                    {
                        gzFile = GZipHelper.Compress(filecopy);

                    }
                    catch (Exception err)
                    {
                        throw new Exception("ѹ��ʧ�ܡ�", err);
                    }
                    finally
                    {
                        File.Delete(filecopy);
                    }
                    //��ȡ�ļ�
                    using (FileStream fs = File.OpenRead(gzFile))
                    {
                        buff = new byte[(int)fs.Length];
                        fs.Read(buff, 0, (int)fs.Length);
                    }

                    File.Delete(gzFile);

                }
                return buff;
            }
            set
            {
                if (value == null || value.Length == 0) return;
                string gzFile = GetTempFileName() + ".gz";
                //�����ļ�
                using (FileStream fs = File.Create(gzFile))
                {
                    fs.Write(value, 0, value.Length);
                }

                string file2 = string.Empty;

                //��ѹ�ļ�
                try
                {
                    file2 = GZipHelper.UnCompress(gzFile);
                }
                catch (Exception err)
                {
                    throw new ApplicationException("������Ч��ѹ���ļ�.\n" + err.Message);
                }
                finally
                {
                    File.Delete(gzFile);
                }

                //���ļ�
                FileOpen(file2);
                fileName = file2;
                isTempFile = true;
            }
        }       
        [Browsable(false)]

        public string FileName
        {
            get { return fileName; }
        }
        public bool IsDirty
        {
            get
            {
                bool ret = false;
                try
                {
                    ret = this.axFramerControl1.IsDirty;
                }
                catch { }
                return ret;
            }
        }
        #endregion

        #region axFramerControl1 �¼�

        void axFramerControl1_OnDocumentClosed(object sender, EventArgs e)
        {
            Word.Workbook doc = axFramerControl1.ActiveDocument as Word.Workbook;
            
            object cl = Type.Missing;
            doc.Close( cl,  cl,  cl);
            if (isTempFile && File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            fileName = string.Empty;
            isTempFile = false;
            isModified = false;
        }

        void axFramerControl1_OnDocumentOpened(object sender, AxDSOFramer._DFramerCtlEvents_OnDocumentOpenedEvent e)
        {
            fileName = e.file;
        }

        void axFramerControl1_BeforeDocumentSaved(object sender, AxDSOFramer._DFramerCtlEvents_BeforeDocumentSavedEvent e)
        {

        }

        void axFramerControl1_BeforeDocumentClosed(object sender, AxDSOFramer._DFramerCtlEvents_BeforeDocumentClosedEvent e)
        {
            //(e.document as Word.Document).Application.DocumentChange -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);

        }

        void axFramerControl1_OnFileCommand(object sender, AxDSOFramer._DFramerCtlEvents_OnFileCommandEvent e)
        {
            switch (e.item)
            {
                case dsoFileCommandType.dsoFileNew:
                    e.cancel = true;
                    FileNew();
                    break;
                case DSOFramer.dsoFileCommandType.dsoFileOpen:
                    e.cancel = true;
                    FileOpen();
                    break;
                case DSOFramer.dsoFileCommandType.dsoFileClose:
                    e.cancel = true;
                    FileClose();
                    break;
                case DSOFramer.dsoFileCommandType.dsoFileSave:
                    e.cancel = true;

                    FileSave();
                    break;
                case DSOFramer.dsoFileCommandType.dsoFileSaveAs:
                    e.cancel = true;
                    FileSaveAs();
                    break;
            }
        }
        #endregion

        #region ˽�з���
        private string GetTempFileName()
        {
            //����һ��Ψһ����ʱ�ļ���
            //return TempPath + "\\" + Path.GetRandomFileName() + ".doc";
            if (TempPath.EndsWith("\\"))
            {
                return TempPath + "~" + Guid.NewGuid().ToString() + ".xls";
            }
            else
            {
                return TempPath + "\\~" + Guid.NewGuid().ToString() + ".xls";
            }            
        }
        #endregion

        /// <summary>
        /// �½��ļ�
        /// </summary>
        public void FileNew()
        {
            this.axFramerControl1.CreateNew("Excel.Sheet");
            //this.axFramerControl1.Refresh();
        }
        /// <summary>
        /// ���ļ�
        /// </summary>
        public void FileOpen()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Excel�ļ�(*.xls)|*.xls";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string copyfile = GetTempFileName();

                    File.Copy(dlg.FileName, copyfile);
                    FileOpen(copyfile);
                    isTempFile = true;
                    fileName = copyfile;
                }
            }
        }
        public void FilePrintDialog()
        {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogPrint);
        }
        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="fileName"></param>
        public void FileOpen(string filename)
        {

            axFramerControl1.Close();             
            axFramerControl1.Open(filename, IsReadOnly, null, null, null);            
            axFramerControl1.Activate();
            //Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            //doc.Application.DocumentChange += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);

        }
        public void Activate()
        {
            axFramerControl1.Activate();
        }
        /// <summary>
        /// �ĵ������仯�Ƿ���
        /// </summary>
        void Application_DocumentChange()
        {

            isModified = true;
        }
        /// <summary>
        /// �ر��ļ�
        /// </summary>
        public void FileClose()
        {
            string temp = axFramerControl1.DocumentFullName;
            axFramerControl1.Close();
            if (IsTempFile && File.Exists(temp))
            {
                try
                {
                    File.Delete(temp);
                    isTempFile = false;
                }
                catch { }

            }
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        public void FileSave()
        {

            string file = axFramerControl1.DocumentFullName;

            if (string.IsNullOrEmpty(file))
            {
                file = GetTempFileName();
                axFramerControl1.Save(file, true, null, null);
                fileName = file;
                isTempFile = true;

            }
            else
            {
                try
                {                   
                    object admin = "administrator";
                    object pwd = "";
                    axFramerControl1.Save(file, true, admin, pwd);
                }
                catch { }
            }
            //this.axFramerControl1.ActivationPolicy = DSOFramer.dsoActivationPolicy.dsoKeepUIActiveOnAppDeactive;
            if (OnFileSaved != null)
            {
                OnFileSaved(this, null);
            }
            isModified = false;
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="overwrite">�Ƿ񸲸������ļ�</param>
        public void FileSave(string filename, bool overwrite)
        {
            FileSave();
            File.Copy(axFramerControl1.DocumentFullName, filename, true);

        }
        /// <summary>
        /// �ļ����Ϊ
        /// </summary>
        public void FileSaveAs()
        {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogSaveCopy);
        }

        private void axFramerControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isModified = true;
        }
        /// <summary>
        /// ճ��
        /// </summary>
        public void DoPasteAndFormat()
        {
           // Word.Document doc = axFramerControl1.ActiveDocument as Word.Workbook;
           // doc.Application.Selection.PasteAndFormat(Microsoft.Office.Interop.Word.WdRecoveryType.wdPasteDefault);
        }
        /// <summary>
        /// ճ��
        /// </summary>
        public void DoPaste()
        {
           // Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
           // doc.Application.Selection.Paste();
        }
        /// <summary>
        /// ճ��Excel����
        /// </summary>
        public void DoPasteExcelTable()
        {
           // Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            //doc.Application.Selection.PasteExcelTable(false, false, false);
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="filePath">�ļ�·��</param>
        /// <param name="isEnd">�Ƿ����ļ�β����</param>
        private void DoInsertFromFile(string filePath, bool isEnd)
        {
           /* Word.Worksheet ws = axFramerControl1.ActiveDocument as Word.Worksheet
            
            
            object obj = System.Type.Missing;
            object unit = Word.WdUnits.wdStory;
            object missing = System.Type.Missing;
            if (isEnd)
                doc.Application.Selection.EndKey(ref unit, ref missing);
            doc.Application.Selection.InsertFile(filePath, ref obj, ref obj, ref obj, ref obj);*/
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="filePath"></param>
        public void DoInsertFromFile(string filePath)
        {
            DoInsertFromFile(filePath, false);
        }
        /// <summary>
        /// ׷���ļ�
        /// </summary>
        /// <param name="filePath"></param>
        public void DoAppendFromFile(string filePath)
        {
            DoInsertFromFile(filePath, true);
        }
        public void DoReplace(string strFind, string strReplace)
        {
            /*object strfind = strFind;
            object replace = strReplace;
            object wrap = Word.WdFindWrap.wdFindContinue;//ȫ�Ĳ���
            object matchcase = false;
            object objTrue = true;
            object objFalse = false;
            object wdreplace = Word.WdReplace.wdReplaceAll;
            Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            Word.Find find = doc.Application.Selection.Find;
            find.ClearFormatting();
            find.Replacement.ClearFormatting();
            find.ExecuteOld(ref strfind, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref wrap, ref missing, ref replace, ref wdreplace);*/
        }
        private string saveFileGzip(byte[] buff)
        {

            string gzFile = GetTempFileName() + ".gz";
            //�����ļ�
            using (FileStream fs = File.Create(gzFile))
            {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
            }

            string file2 = string.Empty;

            //��ѹ�ļ�
            try
            {
                file2 = GZipHelper.UnCompress(gzFile);
            }
            catch (Exception err)
            {
                throw new ApplicationException("������Ч��ѹ���ļ�.\n" + err.Message);
            }
            finally
            {
                File.Delete(gzFile);
            }

            return file2;
        }
        private string saveFile(byte[] buff)
        {

            string file2 = GetTempFileName();
            //�����ļ�
            using (FileStream fs = File.Create(file2))
            {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
            }

            return file2;
        }
        public void DoPageSetupDialog()
        {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogPageSetup);
        }
        /// <summary>
        /// �ϲ��ڴ�Word�ļ�
        /// </summary>
        /// <param name="buff">buff Ϊѹ�����ڴ��</param>
        public void DoAppendFromStreamGzip(byte[] buff)
        {
            if (buff == null || buff.Length == 0) return;
            string file1 = saveFileGzip(buff);

            DoInsertFromFile(file1, true);

            File.Delete(file1);
        }
        /// <summary>
        /// �������ļ�
        /// </summary>
        /// <param name="buff"></param>
        public void DoInsertFromStreamGzip(byte[] buff)
        {
            if (buff == null || buff.Length == 0) return;
            string file1 = saveFileGzip(buff);

            DoInsertFromFile(file1, false);

            File.Delete(file1);
        }
        /// <summary>
        /// �������ļ�
        /// </summary>
        /// <param name="buff"></param>
        public void DoInsertFromStream(byte[] buff)
        {
            if (buff == null || buff.Length == 0) return;
            string file1 = saveFile(buff);

            DoInsertFromFile(file1, false);

            File.Delete(file1);
        }
        /// <summary>
        /// �ϲ��ڴ�Word�ļ�
        /// </summary>
        /// <param name="buff"></param>
        public void DoAppendFromStream(byte[] buff)
        {
            if (buff == null || buff.Length == 0) return;

            string file1 = saveFile(buff);

            DoInsertFromFile(file1, true);

            File.Delete(file1);
        }

        #region �ı�����
        public void DoInsert(string text, Font font, WdParagraphAlignment alignment)
        {
            /*Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            Word.WdParagraphAlignment align = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            switch (alignment)
            {
                case WdParagraphAlignment.Center:
                    align = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case WdParagraphAlignment.Right:
                    align = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    break;
            }
            doc.Application.Selection.ParagraphFormat.Alignment = align;
            doc.Application.Selection.Font.Bold = font.Bold ? 1 : 0;
            doc.Application.Selection.Font.Name = font.Name;
            doc.Application.Selection.Font.Size = font.Size;
            doc.Application.Selection.TypeText(text);*/
        }
        public void DoInsertStart(string text, Font font, WdParagraphAlignment alignment)
        {
           /* Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            Word.WdParagraphAlignment align = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            switch (alignment)
            {
                case WdParagraphAlignment.Center:
                    align = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case WdParagraphAlignment.Right:
                    align = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    break;
            }
            object unit = Word.WdUnits.wdStory;
            object missing = System.Type.Missing;
            Word.WdParagraphAlignment oldalign = doc.Application.Selection.ParagraphFormat.Alignment;
            int oldBold = doc.Application.Selection.Font.Bold;
            string oldFontName = doc.Application.Selection.Font.Name;
            float oldSize = doc.Application.Selection.Font.Size;

            doc.Application.Selection.HomeKey(ref unit, ref missing);
            doc.Application.Selection.ParagraphFormat.Alignment = align;
            doc.Application.Selection.Font.Bold = font.Bold ? 1 : 0;
            doc.Application.Selection.Font.Name = font.Name;
            doc.Application.Selection.Font.Size = font.Size;
            doc.Application.Selection.TypeText(text);
            doc.Application.Selection.ParagraphFormat.Alignment = oldalign;
            doc.Application.Selection.Font.Name = oldFontName;
            doc.Application.Selection.Font.Size = oldSize;*/

        }
        #endregion
        #region �������
        public void DoInsertPicture(string filepath)
        {
            /*Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            object linkToFile = false;
            object saveWithDocument = true;
            object rang = System.Type.Missing;
            doc.Application.Selection.InlineShapes.AddPicture(filepath, ref linkToFile, ref saveWithDocument, ref rang);*/
        }
        public void DoAppendPicture(string filepath)
        {
            /*Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            object linkToFile = false;
            object saveWithDocument = true;
            object rang = System.Type.Missing;
            object unit = Word.WdUnits.wdStory;
            doc.Application.Selection.EndKey(ref unit, ref rang);
            doc.Application.Selection.InlineShapes.AddPicture(filepath, ref linkToFile, ref saveWithDocument, ref rang);*/
        }

        public void DoInsertOleObject(string filepath)
        {
            /*Word.Document doc = axFramerControl1.ActiveDocument as Word.Document;
            object classtype = null;
            object filename = GetTempFileName() + ".xls";
            object linkToFile = false;
            object displayAsIcon = false;
            object missing = System.Type.Missing;
            if (Path.GetExtension(filepath).ToLower() == ".xls")
            {
                File.Copy(filepath, (string)filename, true);
                classtype = "Excel.Sheet.8";
                doc.Application.Selection.InlineShapes.AddOLEObject(ref classtype, ref filename, ref linkToFile, ref displayAsIcon, ref missing, ref missing, ref missing, ref missing);
                File.Delete((string)filename);
            }*/
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            initCom();
        }
    }
    public enum WdParagraphAlignment
    {
        Left, Right, Center
    }
}
