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
            } catch (Exception err) {
                Console.WriteLine(err.Message);
            }
            Console.ReadLine();
        }
        static void test() {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/xml");
            //var user1 = client.DownloadString("http://localhost:3274/Member.svc/User/1");
            var user2 = client.DownloadString("http://192.168.238.129:82/AccountService/GetAccountData");
            Console.WriteLine(user2);

            client.Headers.Add("content-type", "application/json;charset=utf-8");


            //var usern = client.UploadString("http://localhost:3274/Member.svc/User/admin/admin", "POST", String.Empty);
            //var usern = client.UploadString("http://localhost:3274/Member.svc/AddUser", "POST", user1);
            var usern2 = client.UploadString("http://192.168.238.129:82/AccountService/SetList", "POST", user2);
            Console.WriteLine(usern2);
            //usern2 = "{\"Name\":\"rabbit\",\"Birthday\":\"Sun Jul 03 13:25:54 GMT+00:00 2011\",\"Age\":56,\"Address\":\"YouYi East Road\"}";
            client.Headers.Add("content-type", "application/json;charset=utf-8");
            usern2 = client.UploadString("http://192.168.238.129:82/AccountService/SetData", "POST", usern2);
            Console.WriteLine(usern2);
        }
        static void testGetUser(string id,string pwd) {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json;charset=utf-8");
            var user = client.DownloadString(baseUrl + "/GetUser/" + id + "/" + pwd);
            Console.WriteLine(user);
        }
    }
}
