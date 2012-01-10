using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using Ebada.Scgl.Core;
using System.Reflection;
using Ebada.Scgl.Model;
using Ebada.Components;
using System.IO;
using System.Collections;

namespace Ebada.Scgl.Sbgl {
    public partial class frmDownload : DevExpress.XtraEditors.XtraForm {
        public frmDownload() {
            InitializeComponent();

            enableUpload(false);
            memoEdit1.Properties.ReadOnly = true;
#if DEBUG
            textEdit1.Text = "10.166.137.29";
            textEdit1.Text = "192.168.238.129";
#endif
            simpleButton5.Click += new EventHandler(simpleButton5_Click);
            simpleButton7.Click += new EventHandler(simpleButton7_Click);
            labelControl3.Text = "数据下载操作会消除现有数据，请谨慎使用";
            baseUrl = string.Format("http://{0}:83/ScglService/", textEdit1.Text);
        }

        void simpleButton7_Click(object sender, EventArgs e) {
            //数据检查
            memoEdit1.Text = serverInfo;
            writeLine(getClientinfo());
        }
        
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;    //如果m.Msg的值为0x8000那么表示有U盘插入
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0X8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;


        public Message mm;

        /// <summary>
        /// 监视Windows消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL:         //U盘插入
                            String[] strDrivers = Environment.GetLogicalDrives();
                            writeLine("U盘已插入,盘符为:" + strDrivers[strDrivers.Length-1]);
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:   //U盘卸载
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }

        void simpleButton5_Click(object sender, EventArgs e) {
            enableUpload(false);
            download();
            enableUpload(true);
        }
        #region 下载
        private void download() {
            string str = "开始下载数据：";
            string username = "于静淼";// Client.Platform.MainHelper.User.UserName;
            writeLine(str);
            writeLine("当前用户：" +username );
            db3Helper.Clear();
            List<ps_xl> xllist=getxl(username);
            db3Helper.Insert(xllist);
            str = "{0} {1} ，杆塔数:{2}";
            int i = 0;
            foreach (ps_xl item in xllist) {
                i++;
                List<ps_gt> gtlist = getgt(item.LineCode);

                db3Helper.Insert(gtlist);
                writeLine(string.Format(str, i, item.LineName, gtlist.Count));
                Application.DoEvents();
            }
            List<ps_gtsbzl> zllist = getgtsbzl();
            db3Helper.Insert(zllist);
            writeLine("设备参数:" + zllist.Count);
            writeLine("下载完成");
            writeLine(getClientinfo());
        }

        private List<ps_gtsbzl> getgtsbzl() {
            string ret;
            List<ps_gtsbzl> list = new List<ps_gtsbzl>();
            string url = baseUrl + "GetzlList" ;
            try {
                using (var client = new WebClient()) {
                    client.Headers.Add("content-type", "application/json;charset=utf-8");
                    client.Encoding = Encoding.UTF8;
                    ret = client.DownloadString(url);
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_gtsbzl>>(ret);
                }
            } catch (Exception err) {
                writeLine(err.Message);
            }

            return list;
        }

        private List<ps_gt> getgt(string p) {
            string ret;
            List<ps_gt> list = new List<ps_gt>();
            string url = baseUrl + "GetGtList/" + p;
            try {
                using (var client = new WebClient()) {
                    client.Headers.Add("content-type", "application/json;charset=utf-8");
                    client.Encoding = Encoding.UTF8;
                    ret = client.DownloadString(url);
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_gt>>(ret);
                }
            } catch (Exception err) {
                writeLine(err.Message);
            }

            return list;
        }
        private List<ps_xl> getxl(string username) {
            string ret;
            List<ps_xl> list = new List<ps_xl>();
            string url = baseUrl + "GetXlList2/"+username;
            //var data = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            try {
                var client = new WebClient();
                client.Headers.Add("content-type", "application/json;charset=utf-8");
                client.Encoding = Encoding.UTF8;
                ret = client.DownloadString(url);
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_xl>>(ret);
            } catch (Exception err) {
                writeLine( err.Message);
            }

            return list;
        }
        #endregion 
        private void labelControl1_Click(object sender, EventArgs e) {

        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            //数据上传
            enableUpload(false);
            upload();
            enableUpload(true);
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            //选择数据目录
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                buttonEdit1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        string serverInfo = "";
        private void simpleButton4_Click(object sender, EventArgs e) {
            //测试服务器
            serverInfo = getServerinfo();
            memoEdit1.Text = serverInfo;

        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            
            //自动搜索
            DriveInfo[] drives = DriveInfo.GetDrives();
            string filepath = "";
            foreach (DriveInfo item in drives) {
                if (item.DriveType == DriveType.Removable) 
                {                    
                    if(File.Exists(item.Name+"scgl\\scgl.db")){
                        filepath = item.Name + "scgl";
                        break;
                    }
                }
                
            }
            if (filepath == "") {
                writeLine("没有找到手机数据库");
            } else {
                buttonEdit1.Text = filepath;
                writeLine("找到手机数据库位置：" + filepath);                
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            //手机软件下载
            WebClient wb = new WebClient();
            string filename = "scgl_client.apk";
            string filepath=buttonEdit1.Text+"\\"+filename;
            string url=string.Format("http://{0}/ScglUpdateService/{1}", textEdit1.Text,filename);
            writeLine("下载更新地址："+url);
            Application.DoEvents();
            try {
                wb.DownloadFile(url, filepath);
                if (File.Exists(filepath)) {
                    writeLine("更新包已下载到：" + filepath);
                }
            } catch (Exception err){
                writeLine("下载失败：" + err.Message);
            }
        }
        private void simpleButton6_Click(object sender, EventArgs e) {
            //上传图片
            enableUpload(false);
            UploadFile();
            enableUpload(true);

        }
        private void buttonEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e) {
            enableUpload(false);
        }
        private void enableUpload(bool flag) {
            simpleButton2.Enabled = flag;
            simpleButton3.Enabled = flag;
            simpleButton5.Enabled = flag;
            simpleButton6.Enabled = flag;
        }
        int upCount = 0;
        private void upload() {
            DataTable dt = SqliteHelper.ExecuteDataTable("select * from ps_xl");
            string str = "开始上传数据：";
            writeLine(str);
            str = "{0} {1} ，杆塔数:{2},实际上传数:{3}";
            int n1=0, n2=0;
            List<ps_gt> uplist = new List<ps_gt>();
            upCount = 0;
            foreach (DataRow row in dt.Rows) {
                string linecode = row["linecode"].ToString();
                DataTable dt2 = SqliteHelper.ExecuteDataTable("select * from ps_gt where linecode='"+linecode+"'");
                n1 = dt2.Rows.Count;
                
                string ret="0";
                int n3 = 0;
                foreach (DataRow row2 in dt2.Rows) {
                    ps_gt gt = new ps_gt();
                    foreach (FieldInfo fi in gt.GetType().GetFields()) {
                        try {
                            fi.SetValue(gt, row2[fi.Name]);
                        } catch { }
                    }
                    if (gt.gtLat == "0" || gt.gtLon == "0") continue;
                    //uplist.Add(gt);
                    try {
                        UpdateGtOne(gt);
                        n3++;
                    } catch {

                    }

                }
                n2++;
                //if (uplist.Count > 0) {
                //    ret = uploadgt(uplist);
                //    uplist.Clear();
                //}
                writeLine(string.Format(str, n2, row["linename"], n1, n3));
                Application.DoEvents();
                //if (ret.Contains("(")) break;
            }
            writeLine(string.Format("共更新杆塔数：{0}", upCount));
        }
        private string UpdateGtOne(ps_gt data) {
            PS_gt gt = Ebada.Client.ClientHelper.PlatformSqlMap.GetOne<PS_gt>(string.Format("where gtCode='{0}'",data.gtCode));
            if (gt != null) {
                //foreach(FieldInfo fi in data.GetType().GetFields()){
                //    try {
                //        gt.GetType().GetProperty(fi.Name).SetValue(gt, fi.GetValue(data), null);
                //    } catch { }
                //}
                gt.gtType = data.gtType;
                gt.gtModle = data.gtModle;
                gt.gtElev = (int)decimal.Parse(data.gtElev);
                gt.gtLat = decimal.Parse(data.gtLat);
                gt.gtLon = decimal.Parse(data.gtLon);
                gt.gtHeight = decimal.Parse(data.gtHeight);
                gt.gtJg = data.gtSpan == "是" ? "是" : "否";//借杆
                if ((gt.gtLat + gt.gtLon) > 0) {
                    int n = Ebada.Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(gt);
                    upCount += n;
                }
                if (data.jsonData != null) {
                    //Console.WriteLine(data.jsonData);
                    List<ps_gtsb> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_gtsb>>(data.jsonData);
                    if (list != null && list.Count>0) {
                        List<SqlQueryObject> sqllist = new List<SqlQueryObject>();
                        SqlQueryObject sqo = new SqlQueryObject(SqlQueryType.Delete, "Delete", "delete from ps_gtsb where gtid='" + gt.gtID + "'");
                        sqllist.Add(sqo);
                        int num = 0;
                        foreach (ps_gtsb sb in list) {
                            num++;
                            PS_gtsb gtsb = new PS_gtsb() { gtID = gt.gtID, sbModle = sb.xh, sbType = sb.zldm, sbNumber = short.Parse(sb.sl), sbName = sb.zl, sbCode = num.ToString("000") };
                            gtsb.sbID = gt.gtID + num.ToString("000");
                            sqo = new SqlQueryObject(SqlQueryType.Insert, gtsb);
                            sqllist.Add(sqo);
                        }
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(sqllist);
                    }
                    //Console.WriteLine(list != null ? list.Count : 0);
                }
                //Console.WriteLine("update {0} count {1}", gt.gtCode, n);
            }

            return "";
        }
        private string uploadgt(List<ps_gt> list) {
            string ret;
            string url =baseUrl + "UpdateGtList";
            var data =Newtonsoft.Json.JsonConvert.SerializeObject(list);
            try {
                var client = new WebClient();
                client.Headers.Add("content-type", "application/json;charset=utf-8");
                client.Encoding = Encoding.UTF8;
                ret = client.UploadString(url, "POST", data);
            } catch (Exception err) {
                ret = err.Message;
            }
            return ret;
        }
        private void writeLine(string line) {
            memoEdit1.Text += "\r\n" + line;
            memoEdit1.SelectionStart = memoEdit1.Text.Length - 1;
            //memoEdit1.Refresh();
            memoEdit1.ScrollToCaret();
            
        }
        private string getClientinfo() {
            string str = "手机数据目录：{0}\r\n数据库位置：{1}\r\n数据库检查结果：{2}";
            dataPath = buttonEdit1.Text + "\\scgl.db";
            string ret = "";
            try {
                SqliteHelper.ConnStr = "Data Source=" + dataPath;
                var user=SqliteHelper.ExecuteScalar("select orgname||','||username from user");
                if(user==null)user="操作员：无";
                ret = user.ToString();

                ret += "\r\n线路数："+SqliteHelper.ExecuteScalar("select count(*) from ps_xl").ToString();
                ret += "\r\n杆塔数：" + SqliteHelper.ExecuteScalar("select count(*) from ps_gt").ToString();
                ret += "\r\n已采集的杆塔数：" + SqliteHelper.ExecuteScalar("select count(*) from ps_gt where gtlon>0 and gtlat>0").ToString();
                //ret += "\r\n没有经纬度数据的杆塔不计算在内."; 
                enableUpload(true);
            } catch (Exception err) {
                ret = err.Message;
            }

            return string.Format(str, buttonEdit1.Text, dataPath, ret);
        }
        private string baseUrl = "";
        private string dataPath="";
        private string getServerinfo() {
            string str="";
            baseUrl = string.Format("http://{0}:83/ScglService/", textEdit1.Text);
            str = "服务器IP：{0}\r\n手机服务地址：{1}\r\n测试连接{2}\r\n";
            //str = string.Format(str, textEdit1.Text, textEdit1.Text, "GetVersion");
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json;charset=utf-8");

            string ret="成功";
            try {
                ret += client.DownloadString(baseUrl + "GetVer");
            } catch (Exception err){
                ret = "失败." + err.Message;
            }
            
            return string.Format(str,textEdit1.Text,baseUrl,ret);

        }

        public string UpdateGtImage3(string id, byte[] data, string type) {

            string msg = "";
            PS_Image image = new PS_Image() { ImageID = id, ImageType = "gt" };
            image.ImageData = data;
            PS_Image image2 = new PS_Image() { ImageID = id };
            PS_gt gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_gt>(id);
            object update = null;
            object delete = image2;
            if (gt != null && gt.ImageID != id) {
                if (gt.ImageID != "") {
                    delete = new PS_Image() { ImageID = gt.ImageID };
                    delete = new object[] { image2, delete };
                }
                gt.ImageID = id;
                update = gt;
            }

            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, update, delete);
            return msg;
        }
        private void UploadFile() {
            DataTable dt = SqliteHelper.ExecuteDataTable("select gtid,gtcode from ps_gt");
            int count = 0;
            string str = "上传图片共{0}张";
            memoEdit1.Text = "";
            writeLine(string.Format(str, count));
            foreach (DataRow row in dt.Rows) {
                string file = buttonEdit1.Text + "\\" + row[1].ToString()+".jpg";
                if (File.Exists(file)) {
                    try {
                        UpdateGtImage3(row[0].ToString(), File.ReadAllBytes(file), "gt");
                        count++;
                        memoEdit1.Text = "";
                        writeLine(string.Format(str, count));
                        Application.DoEvents();
                    } catch {

                    }
                }
            }
            
            
        }
        public string UploadFile(string id, string type, Stream fileContents) {
            byte[] buffer = new byte[10000];
            int bytesRead, totalBytesRead = 0;
            MemoryStream ms = new MemoryStream();
            do {
                bytesRead = fileContents.Read(buffer, 0, buffer.Length);
                ms.Write(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);
            UpdateGtImage3(id, ms.ToArray(), type);
            ms.Close();
            ms.Dispose();

            //Console.WriteLine("Service: Received file {0} with {1} bytes", id, totalBytesRead);
            return id;
        }
    }
}