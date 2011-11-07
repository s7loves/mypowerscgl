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

namespace Ebada.Scgl.Sbgl {
    public partial class frmUpload : DevExpress.XtraEditors.XtraForm {
        public frmUpload() {
            InitializeComponent();

            enableUpload(false);
            memoEdit1.Properties.ReadOnly = true;
#if DEBUG
            textEdit1.Text = "10.166.137.29";
#endif
        }

        private void labelControl1_Click(object sender, EventArgs e) {

        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            //数据上传
            upload();
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
            //数据检查
            memoEdit1.Text = serverInfo;
            writeLine( getClientinfo());
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            //手机软件下载
        }

        private void buttonEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e) {
            enableUpload(false);
        }
        private void enableUpload(bool flag) {
            simpleButton2.Enabled = flag;
            simpleButton3.Enabled = flag;
            simpleButton5.Enabled = flag;
        }
        private void upload() {
            DataTable dt = SqliteHelper.ExecuteDataTable("select * from ps_xl");
            string str = "开始上传数据：";
            writeLine(str);
            str = "{0} {1} ，杆塔数:{2},实际上传数:{3}";
            int n1=0, n2=0;
            List<ps_gt> uplist = new List<ps_gt>();
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
                //if (ret.Contains("(")) break;
            }
        }
        private string UpdateGtOne(ps_gt data) {
            PS_gt gt = Ebada.Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_gt>(data.gtID);
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
                    //ncount += n;
                }
                if (data.jsonData != null) {
                    Console.WriteLine(data.jsonData);
                    List<ps_gtsb> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_gtsb>>(data.jsonData);
                    if (list != null) {
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
            string str = "\r\n采集数据目录：{0}\r\n数据库位置：{1}\r\n数据库检查结果：{2}";
            dataPath = buttonEdit1.Text + "\\scgl.db";
            string ret = "";
            try {
                SqliteHelper.ConnStr = "Data Source=" + dataPath;
                ret = SqliteHelper.ExecuteScalar("select orgname||','||username from user").ToString();

                ret += "\r\n线路数："+SqliteHelper.ExecuteScalar("select count(*) from ps_xl").ToString();
                ret += "\r\n杆塔数：" + SqliteHelper.ExecuteScalar("select count(*) from ps_gt").ToString();
                ret += "\r\n可以上传的杆塔数：" + SqliteHelper.ExecuteScalar("select count(*) from ps_gt where gtlon>0 and gtlat>0").ToString();
                ret += "\r\n没有经纬度数据的杆塔不能上传更新！！！"; 
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
    }
}