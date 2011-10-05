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
using Ebada.Scgl.Model;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    public partial class DownFileControl : UserControl
    {
        public DownFileControl()
        {
            InitializeComponent();
        }
        private string formtype="";//是上传文件还是下载文件
        private DataTable fjtable = null;
        private string upfileurl="";
        private string upfileErr = "";
        private string downfileurl = "";
        private int icurrent = -1;
        private int itablecurrent = -1;
        private int iupcount = -1;
        private int idowncount = -1;
        private bool isupfile = false;
        private bool isdownfile = false;
        private bool upcancel = false;
        private long lupTotleSize = 0;
        private long lupedTotleSize = 0;
        private long ldownTotleSize = 0;
        private long ldownedTotleSize = 0;
        private List<string> upfilelist;
        private List<string> downfilelist;
        private FileStream myFileStream;
        private BinaryReader myBinaryReader;
        private string upfilePath;//上传文件的上级文件夹名称，默认是流程的名称
        private string recordID;//所属记录的ID
        private static AutoResetEvent upcomEvent;
        private static AutoResetEvent downcomEvent;
        private string downFileFolder = "";
        public Thread upThread=null;
        public string RecordID
        {
            get { return recordID; }
            set
            {
                recordID = value;

            }
        }
        public string UpfilePath
        {
            get { return upfilePath; }
            set
            {
                upfilePath = value;
                
            }
        }
        public string FormType
        {
            get { return formtype; }
            set { formtype = value;
                
            }
        }
        /// <summary>
        /// WebClient上传文件至服务器
        /// </summary>
        /// <param name="fileNameFullPath">要上传的文件（全路径格式）</param>
        /// <param name="strUrlDirPath">Web服务器文件夹路径</param>
        public void UpLoadFile( string fileNameFullPath, string saveFileName, string strUrlDirPath)
        {
           
           
             myFileStream = new FileStream(fileNameFullPath, FileMode.Open, FileAccess.Read);
             myBinaryReader = new BinaryReader(myFileStream);
            
            UriBuilder url = new UriBuilder(strUrlDirPath);//上传路径
            url.Query = string.Format("filename={0}", saveFileName);//上传url参数
            WebClient webClient = new WebClient();
            webClient.OpenWriteCompleted+= new OpenWriteCompletedEventHandler(webClient_OpenWriteCompleted);//委托异步上传事件
            webClient.Headers["User-Agent"] = "blah";
            webClient.Credentials = CredentialCache.DefaultCredentials;
            
            webClient.OpenWriteAsync(url.Uri);
        }
         /// <summary>
        /// WebClient从服务器下载文件
        /// </summary>
        /// <param name="fileNameFullPath">要下载的文件（全路径格式）</param>
        /// <param name="strUrlDirPath">Web服务器文件夹路径</param>
        public void DownFile(string fileNameFullPath, string strUrlDirPath)
        {
            DirectoryInfo di = Directory.GetParent(fileNameFullPath);
            if (!di.Exists) di.Create();
            WebClient webClient = new WebClient();  //再次new 避免WebClient不能I/O并发   
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

            webClient.DownloadFileAsync(new Uri(strUrlDirPath), fileNameFullPath); 
        
        }
        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //downcomEvent.Set();
            if (itablecurrent != -1)
            {
                fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(fjtable.Rows[itablecurrent]["FilePath"].ToString());
                fjtable.Rows[itablecurrent]["Progress"] = 100;
                fjtable.Rows[itablecurrent]["Kind"] = "上传完毕"/* "等待上传中..."*/;
                itablecurrent = -1;
            }
            downfilelist.RemoveAt(0);
            if (idowncount != 0) progressBarControlTol.Position = Convert.ToInt32((100 * (idowncount - downfilelist.Count)) / idowncount);
            downfileFunc(0);
        }
        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        { //下载过程中

            //if (e.ProgressPercentage % 5 != 0) return;
            if (itablecurrent == -1) return;
            if (isdownfile ==false) return;
            try{
                if (fjtable.Columns.Contains("Progress")) fjtable.Rows[itablecurrent]["Progress"] = e.ProgressPercentage;
                if (idowncount!=0) progressBarControlTol.Position = (idowncount - downfilelist.Count) * 100 / idowncount;
                }
            catch
            {
            }
        }
        private void iniColoumn()
        {
            if (formtype == "下载")
            {
                fjgridView.Columns["DelBut"].VisibleIndex = -1;
                upfileButton.Visible = false;
                downfileButton.Visible = true;
                selctFileButton.Visible = true;
                openFolderButton.Visible = true;
            }
            if (formtype == "上传")
            {
                fjgridView.Columns["DownBut"].VisibleIndex = -1;
                fjgridView.Columns["SlectFile"].VisibleIndex = -1;
                upfileButton.Visible = true;
                downfileButton.Visible = false;
            }
        }
        private void iniData()
        {
            if (formtype == "下载")
            {
                IList<PJ_lcfj> lifjlis = MainHelper.PlatformSqlMap.GetList<PJ_lcfj>("SelectPJ_lcfjList", "where RecordID='"+recordID+"'");
                for (int i = 0; i < lifjlis.Count; i++)
                {
                    DataRow dr = fjtable.NewRow();

                    dr["FileName"] = lifjlis[i].Filename;
                    dr["FilePath"] = "";
                    dr["Kind"] = "";
                    dr["DownBut"] = "下载";
                    dr["DelBut"] = "删除";
                    dr["SlectFile"] = 1;
                    dr["SaveFileName"] = lifjlis[i].FileRelativePath;
                    dr["FileSize"] = lifjlis[i].FileSize;
                    fjtable.Rows.Add(dr);
                }
            }
        }
       
        void webClient_OpenWriteCompleted(object sender, System.Net.OpenWriteCompletedEventArgs e)
        {
             //WebClient wc = sender as WebClient;
            int bufSize = 3000;
            int byteGet = 0;
            long bytewrited = 0;
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
                    lupedTotleSize -= bytewrited;
                    break;
                }
                if (itablecurrent == -1) 
                    break;
                e.Result.Write(buf, 0, byteGet);//注意这里
                bytewrited += byteGet;
                fjtable.Rows[itablecurrent]["Progress"] = (bytewrited) * 100 / fileleng;
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
             tipLabelControl.Text = String.Format("已上传 : {0}{1}，总文件大小{2}{3}", Math.Round(lupedTotleSize / (ldw2 + 0.0), 1), strdw2, Math.Round(lupTotleSize / (ldw1 + 0.0), 1), strdw1);
             if (lupTotleSize != 0) progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
             else progressBarControlTol.Position = 0;
             lupedTotleSize += byteGet;
         }
         try
         {
             if (bytewrited < 20 * 1000 * 1000)
                 tipLabelControl.Text = String.Format("等待服务器返回，{0}", tipLabelControl.Text);
             else
             {
                 tipLabelControl.Text = String.Format("等待服务器返回，文件较大时时间较长");
             }
         

             if (!upcancel && itablecurrent != -1)
             {
                 //wc.IsOver = true;
                 e.Result.Close();//关闭
             }
         }
         catch (System.Exception err)
         {
             Console.WriteLine(err.Message);
         }
         myBinaryReader.Close();//关闭myBinaryReader
         tipLabelControl.Text = String.Format("已上传 : {0}{1}，总文件大小{2}{3}", lupedTotleSize / (ldw2), strdw2, lupTotleSize / ldw1, strdw1);
         //if (upcancel || itablecurrent==-1||fjtable.Rows[itablecurrent]["Progress"].ToString() == "100")
         {
             upcomEvent.Set();
         }
     }
      /// 将本地文件上传到指定的服务器(HttpWebRequest方法)
        /// </summary>
        /// <param name="address">文件上传到的服务器</param>
        /// <param name="fileNamePath">要上传的本地文件（全路径）</param>
        /// <param name="saveName">文件上传后的名称</param>
        /// <param name="progressBar">上传进度条</param>
        /// <returns>成功返回1，失败返回0</returns>
        private int Upload_Request(string address, string fileNamePath, string saveName)
        {
            int returnValue = 0;
            // 要上传的文件
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");

            //请求头部信息
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");

            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);


            // 根据uri创建HttpWebRequest对象
            UriBuilder url = new UriBuilder(address);//上传路径
            url.Query = string.Format("filename={0}", saveName);//上传url参数
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url.Uri);
            httpReq.Method = "POST";

            //对发送的数据不使用缓存【重要、关键】
            httpReq.AllowWriteStreamBuffering = false;

            //设置获得响应的超时时间（300秒）
            httpReq.Timeout = 60*60*1000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            
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
            else if (lupTotleSize / (1000 * 1000*1000) < 1000)
            {
                strdw1 = "G";
                ldw1 = 1000 * 1000*1000;

            }
            try
            {
                //progressBar.Maximum = int.MaxValue;
                //progressBar.Minimum = 0;
                //progressBar.Value = 0;
                //每次上传4k
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength];
                //已上传的字节数
                long offset = 0;
                //开始上传时间
                DateTime startTime = DateTime.Now;
                int size =0;
                Stream postStream = httpReq.GetRequestStream();
                //发送请求头部消息
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while ((size = r.Read(buffer, 0, bufferLength)) > 0)
                {
                    if (upcancel)
                    {
                        lupedTotleSize -= offset;
                        break;
                    }
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    //progressBar.Value = (int)(offset * (int.MaxValue / length));
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;
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
                    else if (lupedTotleSize / (1000 * 1000 * 1000) < 1000)
                    {
                        strdw2 = "G";
                        ldw2 = 1000 * 1000 * 1000;

                    }

                    tipLabelControl.Text = String.Format("平均速度：{4} KB/秒已上传 : {0}{1}，总文件大小{2}{3}", Math.Round(lupedTotleSize / (ldw2 + 0.0), 1), strdw2, Math.Round(lupTotleSize / (ldw1 + 0.0), 1), strdw1, (offset / 1024 / second).ToString("0.00"));
                    if (lupTotleSize != 0) progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
                    else progressBarControlTol.Position = 0;
                    lupedTotleSize += size;


                    fjtable.Rows[itablecurrent]["Progress"] = (int)((100 * offset )/ length);
                   
                   
                }
                if (!upcancel)
                {


                    //添加尾部的时间戳
                    postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    postStream.Close();
                    //获取服务器端的响应
                    WebResponse webRespon = httpReq.GetResponse();
                    Stream s = webRespon.GetResponseStream();
                    StreamReader sr = new StreamReader(s);
                    //读取服务器端返回的消息
                    String sReturnString = sr.ReadLine();
                    s.Close();
                    sr.Close();
                    if (sReturnString == "Success")
                    {
                        returnValue = 1;
                        upfileErr = "";
                    }
                    else if (sReturnString.IndexOf("Error") > -1)
                    {
                        lupedTotleSize -= offset;
                        returnValue = 0;
                        upfileErr = sReturnString;
                    }
                }
            }
            catch(Exception ex)
            {
                returnValue = 0;
                upfileErr = ex.Message;
            }
            finally
            {
                fs.Close();
                r.Close();
            }
            return returnValue;
        }
        private void upfileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
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
               string savefilename = "";
               //PJ_lcfj lcfu;
               for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
               {
                   DataRow dr = fjtable.NewRow();
                   string strFileName = openFileDialog1.FileNames[i];
                   
                   dr["FileName"] = System.IO.Path.GetFileName(strFileName) + "(等待上传中...)";
                   fileStreamtemp = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                   if (fileStreamtemp.Length >  1000 * 1000 * 55)
                   {
                       if (strerr == "")
                           strerr = System.IO.Path.GetFileName(strFileName) + " ";// +"";
                       else
                           strerr =strerr+ "、" + System.IO.Path.GetFileName(strFileName);// +"";

                       continue;
                   }
                   if (lupTotleSize + fileStreamtemp.Length > (long)1000 * 1000 * 1000)
                   {
                       MsgBox.ShowTipMessageBox("附件总大小不超过1G");
                       break;
                   }
                   lupTotleSize += fileStreamtemp.Length;
                   
                   dr["FilePath"] = strFileName;
                   dr["DownBut"] = "下载";
                   dr["DelBut"] = "删除";
                   dr["Kind"] = "等待上传中...";
                   //savefilename = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "-" + Path.GetFileName(strFileName);
                   string strtime =(string) ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select replace(replace(replace(replace(CONVERT(varchar, getdate(), 121 ),'-',''),' ',''),':',''),'.','')");
                   savefilename = strtime + "-" + Path.GetFileName(strFileName);
                   dr["SaveFileName"] = savefilename;
                   dr["FileSize"] = fileStreamtemp.Length;
                   fjtable.Rows.Add(dr);
                   upfilelist.Add(savefilename);
                   
                   iupcount++;
                   if (lupTotleSize != 0) progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
                   else progressBarControlTol.Position = 0;
               }
               if (strerr!="")
               {

                   MsgBox.ShowTipMessageBox("文件 "+strerr + " 超过55M,未加入列表");

               }
               if (!isupfile&&upfilelist.Count>0)
               {
                   isupfile = true;
                   tipLabelControl.Visible = true;
                   Control.CheckForIllegalCrossThreadCalls = false;
                   upThread = new Thread(new ThreadStart(this.upfileFunc));
                   upThread.Start();
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
           string filepath = "";
           try
           {
               for (i = 0; i < upfilelist.Count; )
               {
                   icurrent = i;

                   for (int j = 0; j < fjtable.Rows.Count; j++)
                   {
                       if (fjtable.Rows[j]["Kind"].ToString() != "等待上传中...")
                       {
                           continue;
                       }
                       if (upfilelist[icurrent] == fjtable.Rows[j]["SaveFileName"].ToString())
                       {
                           itablecurrent = j;
                           fjtable.Rows[itablecurrent]["Kind"] = "上传中...";
                           savefilename = fjtable.Rows[itablecurrent]["SaveFileName"].ToString();
                           filepath = fjtable.Rows[itablecurrent]["FilePath"].ToString();
                           fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(filepath);
                           break;
                       }
                   }
                   upcancel = false;
                   upfileErr = "";
                   //UpLoadFile(filepath, upfilePath + "/" + savefilename, upfileurl);
                   //upcomEvent.WaitOne();
                   //if (!upcancel && itablecurrent!=-1)
                   if (Upload_Request(upfileurl, filepath, upfilePath + "/" + savefilename) == 1)
                   {
                       fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(filepath);
                       fjtable.Rows[itablecurrent]["Progress"] = 100;
                       fjtable.Rows[itablecurrent]["Kind"] = "上传完毕"/* "等待上传中..."*/;
                       PJ_lcfj lcfu = new PJ_lcfj();
                       lcfu.ID = lcfu.CreateID();
                       lcfu.Filename = Path.GetFileName(filepath);
                       lcfu.FileRelativePath = upfilePath + "/" + savefilename;
                       lcfu.FileSize = Convert.ToInt64(fjtable.Rows[itablecurrent]["FileSize"]);
                       lcfu.RecordID = recordID;
                       lcfu.Creattime = DateTime.Now;
                       MainHelper.PlatformSqlMap.Create<PJ_lcfj>(lcfu);
                       itablecurrent = -1;
                       upfilelist.Remove(upfilelist[0]);
                       progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
                   }
                   else
                   {
                       MessageBox.Show(upfileErr);
                   }
               }
           }
           catch
           { }
           isupfile = false;

           return;
       }
        void downfileFunc(int i)
        {

            //int i = 0;
            string savefilename = "";
            string filepath = "";
            //for (i = 0; i < downfilelist.Count; )
            {
                icurrent = i;

                for (int j = 0; j < fjtable.Rows.Count; j++)
                {
                    if (fjtable.Rows[j]["Kind"].ToString() != "等待下载中...")
                    {
                        continue;
                    }
                    if (downfilelist[icurrent] == fjtable.Rows[j]["SaveFileName"].ToString())
                    {
                        itablecurrent = j;
                        fjtable.Rows[itablecurrent]["Kind"] = "下载中...";
                        savefilename = fjtable.Rows[itablecurrent]["SaveFileName"].ToString();
                        filepath = fjtable.Rows[itablecurrent]["FilePath"].ToString();
                        fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(filepath);
                        break;
                    }
                }
                if (itablecurrent!=-1)
                DownFile(filepath, downfileurl+ savefilename);
                //downcomEvent.WaitOne();
                
            }
            if (downfilelist.Count == 0)
            {
                isdownfile = false;
                idowncount = 0;
                downfileButton.Enabled = true;
            }
           // return;
        }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            if (fjgridView.FocusedRowHandle < 0) return;
            DataRow dr = fjgridView.GetDataRow(fjgridView.FocusedRowHandle);
           
            System.Diagnostics.Process.Start("explorer.exe",downfileurl+ dr["SaveFileName"].ToString());
        }
     
        private void DownFileControl_Load(object sender, EventArgs e)
        {
            if (fjtable == null)
            {
                fjtable = new DataTable();
                fjtable.Columns.Add("FileName", typeof(string));
                fjtable.Columns.Add("SaveFileName", typeof(string));
                fjtable.Columns.Add("DelBut", typeof(string));
                fjtable.Columns.Add("DownBut", typeof(string));
                fjtable.Columns.Add("Progress", typeof(string));
                fjtable.Columns.Add("FilePath", typeof(string));
                fjtable.Columns.Add("SlectFile", typeof(Boolean));
                fjtable.Columns.Add("Kind", typeof(string));
                fjtable.Columns.Add("FileSize", typeof(string));
            }
            fjgridControl.DataSource= fjtable;
            upfileurl = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME)).UpfileUrl;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            upfilelist = new List<string>();
            downfilelist = new List<string>();
            upcomEvent = new AutoResetEvent(false);
            downcomEvent = new AutoResetEvent(false);
            //upfileurl = "http://localhost/ScglUpFileService/UpFileHandler.ashx";
            int i = upfileurl.LastIndexOf("/");
            downfileurl= upfileurl.Substring(0, i + 1)+"UpFileFolder/";
            downFileFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "工作流附件\\" + upfilePath)+"\\";
            SelectorHelper.EnableFilePathExit(downFileFolder);
            iupcount = 0;
            iniColoumn();
            iniData();
        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            if (fjgridView.FocusedRowHandle < 0) return;
            DataRow dr = fjgridView.GetDataRow(fjgridView.FocusedRowHandle);
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认删除附件 【" + System.IO.Path.GetFileName(dr["FilePath"].ToString()) + "】?") != DialogResult.OK)
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
            else if (lupTotleSize / (1000 * 1000 * 1000) < 1000)
            {
                strdw1 = "G";
                ldw1 = 1000 * 1000*1000;

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
            else if (lupedTotleSize / (1000 * 1000*1000) < 1000)
            {
                strdw2 = "G";
                ldw2 = 1000 * 1000*1000;

            }
            FileStream fileStreamtemp = new FileStream(dr["FilePath"].ToString(), FileMode.Open, FileAccess.Read);
            if (isupfile)
            {

                if (dr["SaveFileName"].ToString() == upfilelist[icurrent] && dr["Kind"].ToString() == "上传中...")
                {
                    upcancel = true;
                    itablecurrent = -1;
                }
                
                
                lupTotleSize -= fileStreamtemp.Length;
                if (dr["Kind"].ToString() == "上传完毕")
                 lupedTotleSize -= fileStreamtemp.Length;
                upfilelist.Remove(dr["SaveFileName"].ToString());
                if (lupTotleSize != 0) progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
                else
                    progressBarControlTol.Position = 0;
            }
            else
            {
                
                lupedTotleSize -= fileStreamtemp.Length;
                lupTotleSize -= fileStreamtemp.Length;
                upfilelist.Remove(dr["SaveFileName"].ToString());
            }
            iupcount--;
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_lcfj>(" where FileRelativePath='" + upfilePath + "/" + dr["SaveFileName"].ToString() + "'");
            tipLabelControl.Text = String.Format("已上传 : {0}{1}，总文件大小{2}{3}", lupedTotleSize / (ldw2), strdw2, lupTotleSize / ldw1, strdw1);
            fjtable.Rows.Remove(dr);
            if (isupfile)
            {

                for (int j = 0; j < fjtable.Rows.Count; j++)
                {
                    if (fjtable.Rows[j]["Kind"].ToString() == "上传中...")
                    {
                        itablecurrent = j;
                        break;
                    }
                }
            }
            
        }

        private void downfileButton_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog dlg = new FolderBrowserDialog();

            
            SelectorHelper.EnableFilePathExit(downFileFolder);
           
            for (int j = 0; j < fjtable.Rows.Count; j++)
            {
                if (fjtable.Rows[j]["SlectFile"].ToString().ToLower() != "true")
                {
                    continue;
                }
                DataRow dr = fjtable.Rows[j];
                dr["FilePath"] = downFileFolder +  dr["FileName"].ToString();
                dr["Kind"] = "等待下载中...";
                dr["FileName"] = dr["FileName"].ToString() + "(等待下载中...)";
                downfilelist.Add(dr["SaveFileName"].ToString());
                //ldownTotleSize += Convert.ToInt64(dr["FileSize"]);
                idowncount++;
            }
            if (!isdownfile && downfilelist.Count > 0)
            {
                isdownfile = true;
                //tipLabelControl.Visible = true;
                downfileButton.Enabled = false;
                //Control.CheckForIllegalCrossThreadCalls = false;
                //Thread downThread = new Thread(new ThreadStart(this.downfileFunc));
                //downThread.Start();
                downfileFunc(0);
            }

          
        }

        private void selctFileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = downFileFolder;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                downFileFolder = fbd.SelectedPath+"\\";
            
            }
        }

       

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", downFileFolder);
        }

        private void fjgridView_DoubleClick(object sender, EventArgs e)
        {
            if (fjgridView.FocusedRowHandle < 0) return;
            DataRow dr = fjgridView.GetDataRow(fjgridView.FocusedRowHandle);
            if (File.Exists(downFileFolder+ dr["FileName"].ToString()))
            {
                try
                {
                    System.Diagnostics.Process.Start(downFileFolder + dr["FileName"].ToString());
                }
                catch { }
            }
            else
            {
                MsgBox.ShowTipMessageBox("打开失败，文件未找到!");
            }
        }


    }
}
