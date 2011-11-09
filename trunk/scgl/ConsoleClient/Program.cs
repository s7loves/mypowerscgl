using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Net;

namespace ConsoleClient
{
    class Program
    {
        static string baseUrl = "http://192.168.238.129:83/ScglService";
        static void Main(string[] args)
        {
            
            try {
                testGetUser("rabbit", "aaa");
                //test();
            } catch (Exception err) {
                Console.WriteLine(err.Message);
            }
            Console.ReadLine();
        }
        static void test() {
            var client = new WebClient();
            System.Threading.Thread.Sleep(1000);
            client.Headers.Add("content-type", "application/xml");
            ////var user1 = client.DownloadString("http://localhost:3274/Member.svc/User/1");
            var user2 = client.DownloadString("http://192.168.238.129:82/AccountService/GetAccountData");
            Console.WriteLine(user2);

            //client.Headers.Add("content-type", "application/json;charset=utf-8");


            //var usern = client.UploadString("http://localhost:3274/Member.svc/User/admin/admin", "POST", String.Empty);
            //var usern = client.UploadString("http://localhost:3274/Member.svc/AddUser", "POST", user1);
            //var usern2 = client.UploadString("http://192.168.238.129:82/AccountService/SetList", "POST", user2);
            //Console.WriteLine(usern2);
            //var usern2 = "{\"Name\":\"rabbit\",\"Birthday\":\"\\/Sun Jul 03 13:25:54 GMT+00:00 2011\\/\",\"Age\":56,\"Address\":\"YouYi East Road\"}";
            string usern2 = "{\"Address\":\"YouYi East Road\",\"Age\":56,\"Birthday\":\"\\/Date(1320822727963+0800)\\/\",\"Name\":\"rabbit\"}";
            //usern2 = "{\"Address\":\"YouYi East Road\",\"Age\":56,\"Birthday\":\"\\/Date(1320822727963+0800)\\/\",\"Name\":\"rabbit\"}";
            client.Headers.Add("content-type", "application/json;charset=utf-8");
            usern2 = client.UploadString("http://192.168.238.129:82/AccountService/SetData", "POST", usern2);
            //client.Headers.Add("content-type", "application/json;charset=utf-8");
            //var data = "{\"gtID\":\"21803701400030000\",\"LineCode\":\"2180370140003\",\"gtCode\":\"21803701400030000\",\"gth\":\"0000\",\"gtType\":\"混凝土拔梢杆\",\"gtModle\":\"直线杆\",\"gtHeight\":\"10.0\",\"gtLon\":\"127.00069166666667\",\"gtLat\":\"46.94825\",\"gtElev\":\"160.3\",\"gtSpan\":\"否\",\"jsonData\":null}";//,{"gtID":"21803701400030010","LineCode":"2180370140003","gtCode":"21803701400030010","gth":"0010","gtType":"混凝土拔梢杆","gtModle":"直线杆","gtHeight":"10.0","gtLon":"127.001175","gtLat":"46.94802333333333","gtElev":"159.7","gtSpan":"否","jsonData":null}]";
            
            //data = "[{\"gth\":\"0010\",\"gtHeight\":\"10.0\",\"gtLat\":\"0\",\"gtID\":\"20110815101847123555\",\"gtType\":\"混凝土拔梢杆\",\"gtSpan\":\"否\",\"gtLon\":\"0\",\"LineCode\":\"2180370010003001\",\"gtCode\":\"21803700100030010010\",\"gtModle\":\"直线杆\",\"gtElev\":\"0\"},{\"gth\":\"0020\",\"gtHeight\":\"10.0\",\"gtLat\":\"0\",\"gtID\":\"20110815101847123556\",\"gtType\":\"混凝土拔梢杆\",\"gtSpan\":\"否\",\"gtLon\":\"0\",\"LineCode\":\"2180370010003001\",\"gtCode\":\"21803700100030010020\",\"gtModle\":\"直线杆\",\"gtElev\":\"0\"}]";
            //var usern2 = client.UploadString(baseUrl + "/UpdateGtOne", "POST", data);


            Console.WriteLine(usern2);


        }
        static void testGetUser(string id, string pwd) {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json;charset=utf-8");
            string user = client.DownloadString(baseUrl + "/GetUser/" + id + "/" + pwd); 

            Console.WriteLine(user);
            client.Headers.Add("content-type", "application/json");
            client.Encoding = Encoding.UTF8; //有中文时必须
            user = client.UploadString(baseUrl+"/SetUser",user);
            Console.WriteLine(user);
        }
        static string convert(string utf8string) {
            byte[] buffer1 = Encoding.Default.GetBytes(utf8string);
            byte[] buffer2 = Encoding.Convert(Encoding.UTF8, Encoding.Default, buffer1, 0, buffer1.Length);
            string strBuffer = Encoding.Default.GetString(buffer2, 0, buffer2.Length);
            return strBuffer;
        }
    }
}
