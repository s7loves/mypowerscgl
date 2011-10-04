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
        private string formtype="";
        private DataTable fjtable = null;
        private string upfileurl;
        private string downfileurl;
        private int icurrent = -1;
        private int itablecurrent = -1;
        private int iupcount = -1;
        private bool isupfile = false;
        private bool isdownfile = false;
        private bool upcancel = false;
        private long lupTotleSize = 0;
        private long lupedTotleSize = 0;
        private List<string> upfilelist;
        private List<string> downfilelist;
        private FileStream myFileStream;
        private BinaryReader myBinaryReader;
        private string upfilePath;
        private string recordID;
        private static AutoResetEvent upcomEvent;
        private static AutoResetEvent downcomEvent;


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
            WebClient webClient = new WebClient();
            webClient.OpenWriteCompleted+= new OpenWriteCompletedEventHandler(webClient_OpenWriteCompleted);//委托异步上传事件
            webClient.Headers["User-Agent"] = "blah";
            webClient.Credentials = CredentialCache.DefaultCredentials;
            url.Query = string.Format("filename={0}", saveFileName);//上传url参数
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
            WebClient client = new WebClient();  //再次new 避免WebClient不能I/O并发   
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);  
            client.DownloadFile(strUrlDirPath, fileNameFullPath);
            //异步下载
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(strUrlDirPath), fileNameFullPath); 
        
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            downcomEvent.Set();
        }
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        { //下载过程中
            int a = e.ProgressPercentage;
            fjtable.Rows[itablecurrent]["Progress"]  = a;
        }
        private void iniColoumn()
        {
            if (formtype == "下载")
            {
                fjgridView.Columns["DelBut"].VisibleIndex = -1;
                fjgridView.Columns["DownBut"].Visible=true;
                upfileButton.Visible = false;
            }
            if (formtype == "上传")
            {
                fjgridView.Columns["DownBut"].VisibleIndex = -1;
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
                    dr["SaveFileName"] = lifjlis[i].FileRelativePath;
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
                progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
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
        private void upfileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "";
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
               PJ_lcfj lcfu;
               for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
               {
                   DataRow dr = fjtable.NewRow();
                   string strFileName = openFileDialog1.FileNames[i];
                   lcfu = new PJ_lcfj();
                   dr["FileName"] = System.IO.Path.GetFileName(strFileName) + "(等待上传中...)";
                   fileStreamtemp = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                   if (fileStreamtemp.Length >  1000 * 1000 * 1055&&1==2)
                   {
                       if (strerr == "")
                           strerr = System.IO.Path.GetFileName(strFileName) + " ";// +"";
                       else
                           strerr =strerr+ "、" + System.IO.Path.GetFileName(strFileName);// +"";

                       continue;
                   }
                   if (lupTotleSize + fileStreamtemp.Length > (long)1000 * 1000 * 1000 && 1 == 2)
                   {
                       MsgBox.ShowTipMessageBox("附件总大小不超过1G");
                       break;
                   }
                   lupTotleSize += fileStreamtemp.Length;
                   
                   dr["FilePath"] = strFileName;
                   dr["DownBut"] = "下载";
                   dr["DelBut"] = "删除";
                   dr["Kind"] = "等待上传中...";
                   savefilename = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "-" + Path.GetFileName(strFileName);
                   dr["SaveFileName"] = savefilename;
                   fjtable.Rows.Add(dr);
                   upfilelist.Add(savefilename);
                   lcfu.ID = lcfu.CreateID();
                   lcfu.Filename = Path.GetFileName(strFileName);
                   lcfu.FileRelativePath = upfilePath + "/" + savefilename;
                   lcfu.FileSize = fileStreamtemp.Length;
                   lcfu.RecordID = recordID;
                   MainHelper.PlatformSqlMap.Create<PJ_lcfj>(lcfu);
                   Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                   iupcount++;
                   progressBarControlTol.Position =Convert.ToInt32( (100*lupedTotleSize ) / lupTotleSize);
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
           string filepath = "";
           for ( i = 0; i < upfilelist.Count; )
           {
               icurrent = i;
               
               for (int j= 0; j < fjtable.Rows.Count;j++)
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
               UpLoadFile(filepath, upfilePath + "/" + savefilename, upfileurl);
               upcomEvent.WaitOne();
               if (!upcancel && itablecurrent!=-1)
               {
                   fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(filepath);
                   fjtable.Rows[itablecurrent]["Progress"] = 100;
                   fjtable.Rows[itablecurrent]["Kind"] = "上传完毕"/* "等待上传中..."*/;
                   itablecurrent = -1;
                   upfilelist.Remove(upfilelist[0]);
                   progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
               }
           }
           isupfile = false;
           return;
       }
        void downfileFunc()
        {

            int i = 0;
            string savefilename = "";
            string filepath = "";
            for (i = 0; i < downfilelist.Count; )
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
                DownFile(filepath, downfileurl + "UpLoadFiles/" + savefilename);
                downcomEvent.WaitOne();
                if (!upcancel && itablecurrent != -1)
                {
                    fjtable.Rows[itablecurrent]["FileName"] = Path.GetFileName(filepath);
                    fjtable.Rows[itablecurrent]["Progress"] = 100;
                    fjtable.Rows[itablecurrent]["Kind"] = "上传完毕"/* "等待上传中..."*/;
                    itablecurrent = -1;
                    downfilelist.Remove(downfilelist[0]);
                    //progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
                }
            }
            isdownfile = false;
            return;
        }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            if (fjgridView.FocusedRowHandle < 0) return;
            DataRow dr = fjgridView.GetDataRow(fjgridView.FocusedRowHandle);
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dr["FilePath"] = dlg.SelectedPath.ToString() + dr["FileName"].ToString();
                dr["Kind"] = "等待下载中...";
                dr["FileName"] = dr["FileName"].ToString() + "(等待下载中...)";
            }
            downfilelist.Add(dr["SaveFileName"].ToString());

            if (!isdownfile && downfilelist.Count > 0)
               {
                   isdownfile = true;
                   tipLabelControl.Visible = true;
                   Thread downThread = new Thread(new ThreadStart(this.downfileFunc));
                   downThread.Start();
                   //upfileFunc(1);
               }
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
                fjtable.Columns.Add("Kind", typeof(string));
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
            downfileurl= upfileurl.Substring(0, i + 1);
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

                if (dr["SaveFileName"].ToString() == upfilelist[icurrent] && dr["Kind"].ToString() == "上传中...")
                {
                    upcancel = true;
                    itablecurrent = -1;
                }
                
                
                lupTotleSize -= fileStreamtemp.Length;
                if (dr["Kind"].ToString() == "上传中..." || dr["Kind"].ToString() == "上传完毕")
                 lupedTotleSize -= fileStreamtemp.Length;
                upfilelist.Remove(dr["SaveFileName"].ToString());
                progressBarControlTol.Position = Convert.ToInt32((100 * lupedTotleSize) / lupTotleSize);
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


    }
}
