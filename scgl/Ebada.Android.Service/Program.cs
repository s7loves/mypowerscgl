using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

namespace Ebada.Android.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ServiceHost host = new ServiceHost(typeof(AccountService)))
            using (ServiceHost host = new ServiceHost(typeof(ScglService)))
            {
                host.Open();
                Console.WriteLine("AccountService Address:");
                foreach (var endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine(endpoint.Address.ToString());
                }
                Console.WriteLine("AccountService Started,Press any key to stop service...");
                Console.ReadKey();
                host.Close();
            }
        }
    }

    [ServiceContract]
    public interface IAccountJsonService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAccountData", BodyStyle = WebMessageBodyStyle.Bare)]
        List<Account> GetAccountData();
        [OperationContract]
        [WebInvoke(UriTemplate = "SetData", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Account SetAccountData(Account data);
        [OperationContract]
        [WebInvoke(UriTemplate = "SetData2/{data}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Account SetAccountData2(string data);
        [OperationContract]
        [WebInvoke(UriTemplate = "SetList", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Account SetList(List<Account> data);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SendMessage/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string SendMessage(string Message);
    }

    [ServiceContract]
    public interface IAccountXmlService
    {
        [OperationContract(Name = "GetAccountDataXml")]
        [WebGet(RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetAccountData", BodyStyle = WebMessageBodyStyle.Bare)]
        List<Account> GetAccountData();

        [OperationContract(Name = "SendMessageXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "SendMessage/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string SendMessage(string Message);
    }

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
    public class AccountService : IAccountJsonService, IAccountXmlService
    {
        public List<Account> GetAccountData()
        {
            return MockAccount.AccountList;
        }
        public Account SetAccountData(Account obj) {
            Account data = obj;
            
            Console.WriteLine(data.Name);
            Console.WriteLine(data.Age);
            Console.WriteLine(data.Birthday);
            Console.WriteLine(data.Address);

            return data;
        }
        public Account SetAccountData2(string obj) {
            Account data = MockAccount.AccountList[0];
            if (obj == null)
                data = MockAccount.AccountList[0];
            else
                data.Name = obj;
            Console.WriteLine(data.Name);
            Console.WriteLine(data.Age);
            Console.WriteLine(data.Birthday);
            Console.WriteLine(data.Address);

            return data;
        }
        public Account SetList(List<Account> list) {
            Account data = list[0];
            Console.WriteLine(data.Name);
            Console.WriteLine(data.Age);
            Console.WriteLine(data.Birthday);
            Console.WriteLine(data.Address);
            data.Name = "rabbit";
            return data;
        }
        public string SendMessage(string Message)
        {
            
            return " Message:" + Message;
        }
    }

    [DataContract]
    public class Account
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
    }

    public class MockAccount
    {
        public static List<Account> AccountList
        {
            get
            {
                var list = new List<Account>();
                list.Add(new Account { Name = "Bill Gates", Address = "YouYi East Road", Age = 56, Birthday = DateTime.Now });
                list.Add(new Account { Name = "Steve Paul Jobs", Address = "YouYi West Road", Age = 57, Birthday = DateTime.Now });
                list.Add(new Account { Name = "John D. Rockefeller", Address = "YouYi North Road", Age = 65, Birthday = DateTime.Now });
                return list;
            }
        }
    }
}
