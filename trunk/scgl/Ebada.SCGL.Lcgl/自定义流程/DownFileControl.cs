using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using EbadaAutoupdater;
using Ebada.Scgl.Core;
using System.Threading;
using Ebada.Client;

namespace Ebada.Scgl.Lcgl
{
    public partial class DownFileControl : UserControl
    {
        public DownFileControl()
        {
            InitializeComponent();
        }
        private string formtype="";
        private DataTable fjtable = null;
        private string upfileurl;
        private int icurrent = -1;
        private int itablecurrent = -1;
        private int iupcount = -1;
        private bool isupfile = false;
        private bool upcancel = false;
        private long lupTotleSize = 0;
        private long lupedTotleSize = 0;
        private List<string> upfilelist;
        private FileStream myFileStream;
        private BinaryReader myBinaryReader;
        private static AutoResetEvent upcomEvent;
        public string FormType
        {
            get { return formtype; }
            set { formtype = value;
                if (formtype == "下载")
                {
                    fjgridView.Columns["DelBut"].VisibleIndex = -1;
                    //splitContainerControl1.Panel2.Visible = false;
                    upfileButton.Visible = false;
                }
                if (formtype == "上传")
                {
                    fjgridView.Columns["DownBut"].VisibleIndex = -1;
                }
            }
        }
        /// <summary>
        /// WebClient上传文件至服务器（不带进度条）
        /// </summary>
        /// <param name="fileNameFullPath">要上传的文件（全路径格式）</param>
        /// <param name="strUrlDirPath">Web服务器文件夹路径</param>
        /// <returns>True/False是否上传成功</returns>
        public void UpLoadFile( string fileNameFullPath, string saveFileName, string strUrlDirPath)
        {
           
           
             myFileStream = new FileStream(fileNameFullPath, FileMode.Open, FileAccess.Read);
             myBinaryReader = new BinaryReader(myFileStream);
            //try
            //{
            //     int bufSize = 3000;
            //     int byteGet = 0;
            //     long bytewriteed = 0;
            //     byte[] buf = new byte[bufSize];
            //     long fileleng = myFileStream.Length;
            //     WebClient webClient = new WebClient();
            //     webClient.Credentials = CredentialCache.DefaultCredentials;
            //     webClient.OpenWriteCompleted += new OpenWriteCompletedEventHandler(webClient_OpenWriteCompleted);//委托异步上传事件
            //    Stream postStream = webClient.OpenWrite(strUrlDirPath, "PUT");
            //     if (postStream.CanWrite)
            //     {

            //         while ((byteGet = myBinaryReader.Read(buf, 0, bufSize)) > 0)//循环读取,上传
            //         {
            //             postStream.Write(buf, 0, byteGet);//注意这里
            //             bytewriteed += byteGet;
            //             fjtable.Rows[itablecurrent]["Progress"] = (bytewriteed)*100 / fileleng;
            //         }
            //         postStream.Close();//关闭流
            //         myFileStream.Close();
            //         myBinaryReader.Close();
            //         return true;
            //     }
            //     else{

            //         myFileStream.Close();
            //         postStream.Close();//关闭流
            //         return false;

            //     }
            //}
            //catch (Exception exp)
            //{
            //    //MessageBox.Show("文件上传失败：" + exp.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            UriBuilder url = new UriBuilder(strUrlDirPath);//上传路径
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            url.Query = string.Format("filename={0}", saveFileName);//上传url参数
            webClient.OpenWriteCompleted += new OpenWriteCompletedEventHandler(webClient_OpenWriteCompleted);//委托异步上传事件
            webClient.OpenWriteAsync(url.Uri);
        }


        void webClient_OpenWriteCompleted(object sender, System.Net.OpenWriteCompletedEventArgs e)
        {
            int bufSize = 3000;
            int byteGet = 0;
            long bytewriteed = 0;
            long fileleng = myFileStream.Length;
            byte[] buf = new byte[bufSize];
            string strdw1="";
            long ldw1 = 1;
            string strdw2 = "";
            long ldw2 = 1;
            if (lupTotleSize/(1000)<1000)
            {
                    strdw1 = "K";
                    ldw1 = 1000;
            }
            else if (lupTotleSize / (1000 * 1000) < 1000) 
            {
                    strdw1 = "M";
                    ldw1 = 1000 * 1000;

            }
           
            while ((byteGet = myBinaryReader.Read(buf, 0, bufSize)) > 0)//循环读取,上传
            {
                if (upcancel)
                {
                    lupedTotleSize -= bytewriteed;
                    break;
                }
                if (itablecurrent == -1) 
                    break;
                e.Result.Write(buf, 0, byteGet);//注意这里
                bytewriteed += byteGet;
                fjtable.Rows[itablecurrent]["Progress"] = (bytewriteed) * 100 / fileleng;
                if (lupedTotleSize / (1000) < 1000)
                {
                    strdw2 = "K";
                    ldw2 = 1000;
                }
                else if (lupedTotleSize / (1000 * 1000) < 1000)
                {
                    strdw2 = "M";
                    ldw2 = 1000 * 1000;

                }
                tipLabelControl.Text = String.Format("已上传 : {0}{1}，总文件大小{2}{3}", lupedTotleSize / (ldw2), strdw2, lupTotleSize / ldw1, strdw1);
                lupedTotleSize += byteGet;
            }
            if (!upcancel && itablecurrent!=-1) e.Result.Close();//关闭
            myBinaryReader.Close();//关闭myBinaryReader
            tipLabelControl.Text = String.Format("已上传 : {0}{1}，总文件大小{2}{3}", lupedTotleSize / (ldw2), strdw2, lupTotleSize / ldw1, strdw1);
            if (upcancel || itablecurrent==-1||fjtable.Rows[itablecurrent]["Progress"].ToString() == "100")
            {
                upcomEvent.Set();
            }
        }
        private void upfileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.*)|*.*";
            openFileDialog1.Multiselect = true; 
           if(openFileDialog1.ShowDialog()==DialogResult.OK)
           {
               if (icurrent == -1)
               {
                  icurrent= fjtable.Rows.Count + 1;
               }
               FileStream fileStreamtemp;
               String strerr = "";
               for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
               {
                   DataRow dr = fjtable.NewRow();
                   string strFileName = openFileDialog1.FileNames[i];
                   dr["FileName"] = System.IO.Path.GetFileName(strFileName) + "(等待上传中...)";
                   fileStreamtemp = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                   if (fileStreamtemp.Length >  1000 * 1000 * 400)
                   {
                       if(strerr=="")
                       strerr = dr["FileName"]+" ";// +"";
                       else
                           strerr = "、"+dr["FileName"];// +"";

                       continue;
                   }
                   if (lupTotleSize + fileStreamtemp.Length > (long)1000 * 1000 * 3000)
                   {
                       MsgBox.ShowTipMessageBox("附件总大小不超过3G");
                       break;
                   }
                   lupTotleSize += fileStreamtemp.Length;
                   
                   dr["FilePath"] = strFileName;
                   dr["DownBut"] = "下载";
                   dr["DelBut"] = "删除";
                   dr["Kind"] = "等待上传中...";
                   fjtable.Rows.Add(dr);
                   upfilelist.Add(strFileName);
                   iupcount++;
               }
               if (strerr!="")
               {

                   MsgBox.ShowTipMessageBox("文件 "+strerr + " 超过200M,为加入列表");

               }
               if (!isupfile&&upfilelist.Count>0)
               {
                   isupfile = true;
                   lupedTotleSize = 0;
                   tipLabelControl.Visible = true;
                   Control.CheckForIllegalCrossThreadCalls = false;
                   Thread downThread = new Thread(new ThreadStart(this.upfileFunc));
                   downThread.Start();
                   //upfileFunc(1);
               }
           }
        }

        void upfileFunc()
       {
           //WebClient webClient = new WebClient();
           //System.Collections.Specialized.NameValueCollection querystring = new System.Collections.Specialized.NameValueCollection();
           //webClient.UploadProgressChanged += new System.Net.UploadProgressChangedEventHandler(webClient_UploadProgressChanged);
           //webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
           //webClient.OpenWriteCompleted += new OpenWriteCompletedEventHandler(webClient_OpenWriteCompleted);//委托异步上传事件
            int i = 0;
           string savefilename="";
           for ( i = 0; i < upfilelist.Count; )
           {
               icurrent = i;
               savefilename = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "-" + Path.GetFileName(upfilelist[icurrent]);
               for (int j= 0; j < fjtable.Rows.Count;j++)
               {
                   if (fjtable.Rows[j]["Kind"].ToString() != "等待上传中...")
                   {
                       continue;
                   }
                   if (upfilelist[icurrent] == fjtable.Rows[j]["FilePath"].ToString())
                   {
                       itablecurrent = j;
                       fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(upfilelist[icurrent]);
                       fjtable.Rows[itablecurrent]["Kind"] = "上传中...";
                       break;
                   }
               }
               upcancel = false;
               UpLoadFile(upfilelist[i], savefilename, upfileurl);
               upcomEvent.WaitOne();
               if (!upcancel && itablecurrent!=-1)
               {
                   fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(upfilelist[icurrent]);
                   fjtable.Rows[itablecurrent]["Progress"] = 100;
                   fjtable.Rows[itablecurrent]["Kind"] ="上传完毕"/* "等待上传中..."*/;
                   itablecurrent = -1;
                   upfilelist.Remove(upfilelist[0]);
                   progressBarControlTol.Position = (iupcount-upfilelist.Count)*100 / iupcount;
               }
           }
           isupfile = false;
           return;
       }

        private void DownFileControl_Load(object sender, EventArgs e)
        {
            if (fjtable == null)
            {
                fjtable = new DataTable();
                fjtable.Columns.Add("FileName", typeof(string));
                fjtable.Columns.Add("DelBut", typeof(string));
                fjtable.Columns.Add("DownBut", typeof(string));
                fjtable.Columns.Add("Progress", typeof(string));
                fjtable.Columns.Add("FilePath", typeof(string));
                fjtable.Columns.Add("Kind", typeof(string));
            }
            fjgridControl.DataSource= fjtable;
            upfileurl = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME)).UpfileUrl;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            upfilelist = new List<string>();
            upcomEvent = new AutoResetEvent(false);
            upfileurl = "http://localhost/ScglUpFileService/UpFileHandler.ashx";
            iupcount = 0;
        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            if (fjgridView.FocusedRowHandle < 0) return;
            DataRow dr = fjgridView.GetDataRow(fjgridView.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除附件 【" + dr["FileName"].ToString() + "】?") != DialogResult.OK)
            {
                return;
            }
            string strdw1 = "";
            long ldw1 = 1;
            string strdw2 = "";
            long ldw2 = 1;
            if (lupTotleSize / (1000) < 1000)
            {
                strdw1 = "K";
                ldw1 = 1000;
            }
            else if (lupTotleSize / (1000 * 1000) < 1000)
            {
                strdw1 = "M";
                ldw1 = 1000 * 1000;

            }
            if (lupedTotleSize / (1000) < 1000)
            {
                strdw2 = "K";
                ldw2 = 1000;
            }
            else if (lupedTotleSize / (1000 * 1000) < 1000)
            {
                strdw2 = "M";
                ldw2 = 1000 * 1000;

            }
            FileStream fileStreamtemp = new FileStream(dr["FilePath"].ToString(), FileMode.Open, FileAccess.Read);
            if (isupfile)
            {
                
                if (dr["FilePath"].ToString() == upfilelist[icurrent] && dr["Kind"].ToString() == "上传中...")
                {
                    upcancel = true;
                    itablecurrent = -1;
                }
                else
                {
                    lupedTotleSize -= fileStreamtemp.Length;
                    
                }
                lupTotleSize -= fileStreamtemp.Length;
                upfilelist.Remove(dr["FilePath"].ToString());
                progressBarControlTol.Position = (iupcount - upfilelist.Count)*100 / iupcount;
            }
            else
            { 
                lupedTotleSize -= fileStreamtemp.Length;
                lupTotleSize -= fileStreamtemp.Length;
                upfilelist.Remove(dr["FilePath"].ToString());
            }
            iupcount--;
            tipLabelControl.Text = String.Format("已上传 : {0}{1}，总文件大小{2}{3}", lupedTotleSize / (ldw2), strdw2, lupTotleSize / ldw1, strdw1);
            fjtable.Rows.Remove(dr);


            
        }

    }
}
