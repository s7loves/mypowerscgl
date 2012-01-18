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

namespace Ebada.Scgl.Core {
   
    public partial class DSOFramerControl : UserControl {
        
        string tempPath;//临时文件目录
        string fileName;//文件路径
        bool isTempFile = false;//是否临时文件

        string desktopPath;
        public event EventHandler OnFileSaved;//保存文件时发生
        bool isModified;//文档是否被修改
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

        #region 公共属性
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
        /// 压缩文件
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
                    //复制文件
                    File.Copy(fileName, filecopy);
                    //压缩文件
                    try {                        
                         gzFile= GZipHelper.Compress(filecopy);
                         
                    } catch (Exception err){
                        throw new Exception("压缩失败。",err);
                    }
                    finally {
                        File.Delete(filecopy);
                    }
                    //读取文件
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
                //创建文件
                using (FileStream fs = File.Create(gzFile)) {
                    fs.Write(value, 0, value.Length);
                }
                
                string file2 =string.Empty;

                //解压文件
                try {
                    file2 = GZipHelper.UnCompress(gzFile);
                } catch (Exception err) {
                    throw new ApplicationException("不是有效的压缩文件.\n"+err.Message);
                } finally {
                    File.Delete(gzFile);
                }
                
                //打开文件
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

        #region axFramerControl1 事件

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

        #region 私有方法
        private string GetTempFileName() {
            //生成一个唯一的临时文件名
            //return TempPath + "\\~" + Guid.NewGuid().ToString() + ".xls";
            return TempPath + "~" + Guid.NewGuid().ToString() + ".xls";
            //return TempPath +"24工作簿"+ ".xls";
        }
        private void Close() {
            if (MyWorkbook != null) {
                MyWorkbook.Close(false, missing, missing);
                MyWorkbook.Application.Quit();
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
        /// 新建文件
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
        /// 打开文件
        /// </summary>
        public void FileOpen() {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Filter = "office文件(*.*)|*.*";
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
        /// 打开文件
        /// </summary>
        /// <param name="fileName"></param>
        public void FileOpen(string filename) {
            
            axFramerControl1.Open(filename, IsReadOnly, null, null, null);
            this.axFramerControl1.Activate();
        }
        /// <summary>
        /// 文档发生变化是发生
        /// </summary>
        void Application_DocumentChange() {
            
            isModified = true;
        }
        /// <summary>
        /// 关闭文件
        /// </summary>
        public void FileClose() {
            axFramerControl1.Close();
            Application.DoEvents();
            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }
        }
        /// <summary>
        /// 保存文件
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
        /// 保存文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="overwrite">是否覆盖已有文件</param>
        public void FileSave(string filename,bool overwrite) {
            FileSave();
            File.Copy(axFramerControl1.DocumentFullName,filename,true);

        }
        /// <summary>
        /// 文件另存为
        /// </summary>
        public void FileSaveAs() {
            axFramerControl1.ShowDialog(DSOFramer.dsoShowDialogType.dsoDialogSaveCopy);
        }

        private void axFramerControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            isModified = true;
        }
        
        private string saveFileGzip(byte[] buff) {
            
            string gzFile = GetTempFileName() + ".gz";
            //创建文件
            using (FileStream fs = File.Create(gzFile)) {
                fs.Write(buff, 0, buff.Length);
                fs.Flush();
            }

            string file2 = string.Empty;

            //解压文件
            try {
                file2 = GZipHelper.UnCompress(gzFile);
            } catch (Exception err) {
                throw new ApplicationException("不是有效的压缩文件.\n" + err.Message);
            } finally {
                File.Delete(gzFile);
            }

            return file2;
        }
        private string saveFile(byte[] buff) {

            string file2 = GetTempFileName();
            //创建文件
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
