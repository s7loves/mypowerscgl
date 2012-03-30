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
using Ebada.Client;
using System.Runtime.InteropServices;

namespace Ebada.Scgl.Core {
   
    public partial class DSOFramerControl : UserControl {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out   int ID);   

        string tempPath;//��ʱ�ļ�Ŀ¼
        string fileName;//�ļ�·��
        bool isTempFile = false;//�Ƿ���ʱ�ļ�

        string desktopPath;
        public event EventHandler OnFileSaved;//�����ļ�ʱ����
        bool isModified;//�ĵ��Ƿ��޸�
        bool isReadOnly = false;

        object Nothing = System.Type.Missing;
        object missing = System.Type.Missing;
        public DSOFramerControl() {
            
            InitializeComponent();
            myExcel = new ExcelAccess();
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            tempPath = Path.GetTempPath();
            axFramerControl1.ActivationPolicy = DSOFramer.dsoActivationPolicy.dsoKeepUIActiveOnAppDeactive;
            axFramerControl1.FrameHookPolicy = DSOFramer.dsoFrameHookPolicy.dsoSetOnFirstOpen;
            this.axFramerControl1.set_EnableFileCommand(DSOFramer.dsoFileCommandType.dsoFilePrintPreview, false);
        }

        private void initCom() {
            
        }       

        #region ��������
        ExcelAccess myExcel;
        public ExcelAccess MyExcel {
            get {
                if (MyWorkbook != null) {
                    myExcel.MyWorkBook = MyWorkbook;
                    return myExcel;
                } else {
                    return null;
                }            
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public bool IsReadOnly {
            get { return isReadOnly; }
            set { isReadOnly = value; }
        }
        public AxDSOFramer.AxFramerControl AxFramerControl {
            get {
                return axFramerControl1;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public bool IsModified {
            get { return isModified; }
            set { isModified = value; }
        }
        [Browsable(false)]
        public bool IsTempFile {
            get { return isTempFile; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public string TempPath {
            get {
                if (string.IsNullOrEmpty(tempPath)) {
                    tempPath = Application.StartupPath + "\\LocalSettings\\TEMP";
                }
                if (!Directory.Exists(tempPath)) {
                    Directory.CreateDirectory(tempPath);
                }

                return tempPath;
            }
            set {
                tempPath = value;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public byte[] FileData {
            get {
                byte[] buff = new byte[0];
                if (File.Exists(fileName)) {
                    string filecopy = fileName + "_";
                    File.Copy(fileName, filecopy);

                    using (FileStream fs = File.OpenRead(filecopy)) {
                        buff = new byte[(int)fs.Length];
                        fs.Read(buff, 0, (int)fs.Length);
                    }
                    File.Delete(filecopy);

                }
                return buff;
            }
            set {
                if (value == null || value.Length == 0) {
                    FileNew("");
                    return;

                }
                string file2 = GetTempFileName();

                using (FileStream fs =File.Create(file2)) {
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
        public byte[] FileDataGzip {
            get {
                byte[] buff = new byte[0];
                if (File.Exists(fileName)) {
                    string filecopy = fileName + "_";
                    string gzFile =string.Empty;
                    //�����ļ�
                    File.Copy(fileName, filecopy);
                    //ѹ���ļ�
                    try {                        
                         gzFile= GZipHelper.Compress(filecopy);
                         
                    } catch (Exception err){
                        throw new Exception("ѹ��ʧ�ܡ�",err);
                    }
                    finally {
                        File.Delete(filecopy);
                    }
                    //��ȡ�ļ�
                    using (FileStream fs = File.OpenRead(gzFile)) {
                        buff = new byte[(int)fs.Length];
                        fs.Read(buff, 0, (int)fs.Length);
                    }
                    
                    File.Delete(gzFile);

                }
                return buff;
            }
            set {
                if (value == null || value.Length == 0) {
                    FileNew("");
                    return;
                }
                string gzFile = GetTempFileName() + ".gz";
                //�����ļ�
                using (FileStream fs = File.Create(gzFile)) {
                    fs.Write(value, 0, value.Length);
                }
                
                string file2 =string.Empty;

                //��ѹ�ļ�
                try {
                    file2 = GZipHelper.UnCompress(gzFile);
                } catch (Exception err) {
                    throw new ApplicationException("������Ч��ѹ���ļ�.\n"+err.Message);
                } finally {
                    File.Delete(gzFile);
                }
                
                //���ļ�
                FileOpen(file2);
                fileName = file2;
                isTempFile = true;
            }
        }
        [Browsable(false)]

        public string FileName {
            get { return fileName; }
        }
        public bool IsDirty {
            get {
                bool ret = false;
                try {
                    ret = this.axFramerControl1.IsDirty;
                } catch { }
                return ret;
            }
        }
        #endregion 

        #region axFramerControl1 �¼�

        void axFramerControl1_OnDocumentClosed(object sender, EventArgs e) {
          
                if (isTempFile && File.Exists(fileName)) {
                     try {File.Delete(fileName);} catch { }
                }
                fileName = string.Empty;
                isTempFile = false;
                isModified = false;
            
        }

        void axFramerControl1_OnDocumentOpened(object sender, AxDSOFramer._DFramerCtlEvents_OnDocumentOpenedEvent e) {
            fileName = e.file;
        }

        void axFramerControl1_BeforeDocumentSaved(object sender, AxDSOFramer._DFramerCtlEvents_BeforeDocumentSavedEvent e) {

        }

        void axFramerControl1_BeforeDocumentClosed(object sender, AxDSOFramer._DFramerCtlEvents_BeforeDocumentClosedEvent e) {
            //(e.document as Word.Document).Application.DocumentChange -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);
            
        }

        void axFramerControl1_OnFileCommand(object sender, AxDSOFramer._DFramerCtlEvents_OnFileCommandEvent e) {
            switch (e.item) {
                case DSOFramer.dsoFileCommandType.dsoFileNew:
                    e.cancel = true;
                    FileNew("");
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
        private string GetTempFileName() {
            //����һ��Ψһ����ʱ�ļ���
            //return TempPath + "\\~" + Guid.NewGuid().ToString() + ".xls";
            return TempPath + "~" + Guid.NewGuid().ToString() + ".xls";
            //return TempPath +"24������"+ ".xls";
        }
        private void Close() {
            if (MyWorkbook != null) {
                //MyWorkbook.Save();
                MyWorkbook.Close(false, missing, missing);
                //MyWorkbook.Close(true, missing, missing);
                //MyWorkbook.Sheets.Application.Quit();
                MyWorkbook.Application.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(MyWorkbook);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(MyWorkbook.Application);
                //IntPtr t = new IntPtr(MyWorkbook.Application.Hwnd);
                //int k = 0;
                //GetWindowThreadProcessId(t, out   k);
                //System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                //p.Kill();

                
               
                
            }
         
        }
        #endregion
        public Word.Workbook MyWorkbook {
            get {
                Word.Workbook wb = null;
                try {
                    wb = axFramerControl1.ActiveDocument as Word.Workbook;
                } catch { }

                return wb;
            }
        }
        /// <summary>
        /// �½��ļ�
        /// </summary>
        /// <param name="type">"Excel.Sheet"</param>
        public void FileNew(string offictype) {
            
            try {
                this.axFramerControl1.CreateNew(offictype);
            } catch {
                this.axFramerControl1.CreateNew("Excel.Sheet");
                this.axFramerControl1.Activate();
            }
        }
        /// <summary>
        /// ���ļ�
        /// </summary>
        public void FileOpen() {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Filter = "office�ļ�(*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    string copyfile = GetTempFileName();

                    File.Copy(dlg.FileName, copyfile);
                    FileOpen(copyfile);
                    isTempFile = true;
                    fileName = copyfile;
                }
            }           
        }
        public void FilePrintDialog() {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogPrint);
        }
        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="fileName"></param>
        public void FileOpen(string filename) {
            
            axFramerControl1.Open(filename, IsReadOnly, null, null, null);
            this.axFramerControl1.Activate();
        }
        /// <summary>
        /// �ĵ������仯�Ƿ���
        /// </summary>
        void Application_DocumentChange() {
            
            isModified = true;
        }
        private static string CmdPing(string strIp)
        {
            // ʵ��һ��Process��,����һ����������
            Process p = new Process();
            // �趨������
            p.StartInfo.FileName = "cmd.exe";
            // �ر�Shell��ʹ��
            p.StartInfo.UseShellExecute = false;
            // �ض����׼����
            p.StartInfo.RedirectStandardInput = true;
            // �ض����׼���
            p.StartInfo.RedirectStandardOutput = true;
            //�ض���������
            p.StartInfo.RedirectStandardError = true;
            // ���ò���ʾ����
            p.StartInfo.CreateNoWindow = true;
            // ��������
            string pingrst;
            p.Start();
            p.StandardInput.WriteLine(strIp);
            p.StandardInput.WriteLine("exit");
            // ���������ȡ����ִ�н��
            string strRst = p.StandardOutput.ReadToEnd();
            pingrst = strRst;
            // if end
            p.Close();
            return pingrst;

        }
    
        /// <summary>
        /// �ر��ļ�
        /// </summary>
        public void FileClose() {
            //Close();
            //Application.DoEvents();
            string strfile = "";
            strfile = fileName;
            //IntPtr hWnd = FindWindow(null, "Microsoft Excel - ~bc52aeec-f73d-48a9-b4dc-b23e7293cba2.xls");
            //axFramerControl1.Save();
            //Close();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(axFramerControl1.ActiveDocument);
            //int generation = System.GC.GetGeneration(axFramerControl1.ActiveDocument);
            //System.GC.Collect(generation);
            //Application.DoEvents();
            axFramerControl1.Close();
            //Close();
            //Application.DoEvents();
            //axFramerControl1.Dispose();
            //axFramerControl1 = null;
            //Application.DoEvents();
            if (File.Exists(strfile))
            {
                string strtext = CmdPing("tasklist /v  /fi \"IMAGENAME eq  Excel.exe\"");
                if (strtext.IndexOf("��ȱ") > -1 || strtext.IndexOf("Microsoft Excel -")==-1)
                {
                    CmdPing("taskkill /im EXCEL.EXE /f");
                }
                //System.GC.Collect();
                //int generation = System.GC.GetGeneration(axFramerControl1);
                //System.GC.Collect(generation);
                //axFramerControl1 = null;
                try
                {
                    Application.DoEvents();
                    //PostMessage(d, &H10, 0&, 0&);


                    File.Delete(strfile);
                }
                catch { }
            }
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        public void FileSave() {

            string file = axFramerControl1.DocumentFullName;

            if (string.IsNullOrEmpty(file)) {
                file = GetTempFileName();
                axFramerControl1.Save(file, true, null, null);
                fileName = file;
                isTempFile = true;

            } else {
                axFramerControl1.Save();
            }

            if (OnFileSaved != null) {
                OnFileSaved(this, null);
            }
            isModified = false;
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="overwrite">�Ƿ񸲸������ļ�</param>
        public void FileSave(string filename,bool overwrite) {
            FileSave();
            File.Copy(axFramerControl1.DocumentFullName,filename,true);

        }
        /// <summary>
        /// �ļ����Ϊ
        /// </summary>
        public void FileSaveAs() {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogSaveCopy);
        }

        private void axFramerControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            isModified = true;
        }
        
        private string saveFileGzip(byte[] buff) {
            
            string gzFile = GetTempFileName() + ".gz";
            //�����ļ�
            using (FileStream fs = File.Create(gzFile)) {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
            }

            string file2 = string.Empty;

            //��ѹ�ļ�
            try {
                file2 = GZipHelper.UnCompress(gzFile);
            } catch (Exception err) {
                throw new ApplicationException("������Ч��ѹ���ļ�.\n" + err.Message);
            } finally {
                File.Delete(gzFile);
            }

            return file2;
        }
        private string saveFile(byte[] buff) {

            string file2 = GetTempFileName();
            //�����ļ�
            using (FileStream fs = File.Create(file2)) {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
            }

            return file2;
        }
        public void DoPageSetupDialog() {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType .dsoDialogPageSetup);
        }       

    }
    public enum WdParagraphAlignment {
        Left,Right,Center
    }
}
