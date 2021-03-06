/**********************************************
系统:企业ERP
模块:自动更新模块
作者:Rabbit
创建时间:2011-6-16
最后一次修改:2011-6-23
***********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace EbadaAutoupdater
{
    #region The delegate
    public delegate void ShowHandler();
    #endregion

    public class AutoUpdater : IAutoUpdater
    {
        #region The private fields
        private Config config = null;
        private bool bNeedRestart = false;
        private bool bDownload = false;
        List<DownloadFileInfo> downloadFileListTemp = null;
        #endregion

        #region The public event
        public event ShowHandler OnShow;
        #endregion

        #region The constructor of AutoUpdater
        public AutoUpdater()
        {
            config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
        }
        #endregion

        #region The public method
        public void Update()
        {
            if (!config.Enabled)
                return;

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(config.ServerUrl);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            foreach (LocalFile file in config.UpdateFileList)
            {
                if (listRemotFile.ContainsKey(file.Path))
                {
                    RemoteFile rf = listRemotFile[file.Path];
                    Version v1 = new Version(1, 0, 0, 0);
                    try { v1 = new Version(rf.LastVer); } catch { }
                    Version v2 = new Version(0, 0, 0, 1);
                    try { v2 = new Version(file.LastVer); } catch { }
                    if (v1 > v2)
                    {
                        downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVer, rf.Size));
                        file.LastVer = v1.ToString();
                        file.Size = rf.Size;

                        if (rf.NeedRestart)
                            bNeedRestart = true;

                        bDownload = true;
                    }

                    listRemotFile.Remove(file.Path);
                }
            }

            foreach (RemoteFile file in listRemotFile.Values)
            {
                downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size));
                config.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size));
                bDownload = true;
                if (file.NeedRestart)
                    bNeedRestart = true;
            }

            downloadFileListTemp = downloadList;

            if (bDownload)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList,config);

                if (this.OnShow != null)
                    this.OnShow();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("Ebada.SCGL");
                    
                    while (proc.Length >0)
                    {
                        if (DialogResult.Cancel  == MessageBox.Show("程序更新之前须先退出生产管理系统,确认系统已经关闭？", ConstFile.MESSAGETITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question))
                        {
                           return;
                        }
                        else
                        {
                            proc = System.Diagnostics.Process.GetProcessesByName("Ebada.SCGL");
                        }
                    }

                    StartDownload(downloadList);
                }
            }
        }

        public void RollBack()
        {
            foreach (DownloadFileInfo file in downloadFileListTemp)
            {
                string tempUrlPath = CommonUnitity.GetFolderUrl(file);
                string oldPath = string.Empty;
                try
                {
                    if (!string.IsNullOrEmpty(tempUrlPath))
                    {
                        oldPath = Path.Combine(CommonUnitity.SystemBinUrl + tempUrlPath.Substring(1), file.FileName);
                    }
                    else
                    {
                        oldPath = Path.Combine(CommonUnitity.SystemBinUrl, file.FileName);
                    }

                    if (oldPath.EndsWith("_"))
                        oldPath = oldPath.Substring(0, oldPath.Length - 1);

                    MoveFolderToOld(oldPath + ".old", oldPath);

                }
                catch (Exception ex)
                {
                    //log the error message,you can use the application's log code
                }
            }
        }


        #endregion

        #region The private method
        string newfilepath = string.Empty;
        private void MoveFolderToOld(string oldPath, string newPath)
        {
            if (File.Exists(oldPath) && File.Exists(newPath))
            {
                System.IO.File.Copy(oldPath, newPath, true);
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            DownloadProgress dp = new DownloadProgress(downloadList);
            if (dp.ShowDialog() == DialogResult.OK)
            {
                //
                if (DialogResult.Cancel == dp.ShowDialog())
                {
                    return;
                }
                //Update successfully
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));

                if (bNeedRestart)
                {
                    //Delete the temp folder
                    Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.TEMPFOLDERNAME), true);

                    MessageBox.Show(ConstFile.APPLYTHEUPDATE, ConstFile.MESSAGETITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonUnitity.RestartApplication();
                }
            }
        }

        private Dictionary<string, RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                try {
                    list.Add(node.Attributes["path"].Value, new RemoteFile(node));
                } catch { }
            }

            return list;
        }
        #endregion

    }

}
