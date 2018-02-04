using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TT_Mobile
{
    public class AppService
    {
        HttpClient client;
        string url = "http://192.168.1.9";

        public AppService()
        {
            client = new HttpClient();
        }

        public async Task<bool> Login(string userName, string password)
        {
            
            var keyValues = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url+ "/students/login");
             request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var result = await client.SendAsync(request);
             string content = await result.Content.ReadAsStringAsync();

            dynamic res = JsonConvert.DeserializeObject(content);

            bool success = res["success"];

            if(success == true) 
            AppData.user = JsonConvert.DeserializeObject<user>(res["user"].ToString());

            return success;
        
        }


        public async Task<bool> SignUp(string firstname, string lastname, string phone, string mobile, string address, string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("firstname", firstname),
                new KeyValuePair<string, string>("lastname", lastname)
,
                new KeyValuePair<string, string>("phone", phone),
                new KeyValuePair<string, string>("mobile", mobile),
                new KeyValuePair<string, string>("address", address),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url + "/students/signUp");
            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var result = await client.SendAsync(request);
            string content = await result.Content.ReadAsStringAsync();

            dynamic res = JsonConvert.DeserializeObject(content);

            bool success = res["success"];

            return success;


        }




    }
}
