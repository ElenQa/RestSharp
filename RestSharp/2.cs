using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RestSharp_Example
{
    class Program1
    {
        [DataContract]
        class Response2
        {
            [DataMember]
            bool error { get; set; }
            [DataMember]
            string description { get; set; }
            [DataMember]
            int code { get; set; }
           
        }
        class _2
        {
            void Execute()
            {

                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://gogotaxi.com.ua");


                RestRequest request = new RestRequest(Method.GET);
                request.Resource = "/api/driver/me";

                //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("token", "ce18c8257503ba0dfa0656ea4306d22b3933ffbe1923aaff18ecc078b5070a52");


                IRestResponse response = client.Execute(request);
                string content = response.Content;

                object desContent1 = JsonConvert.DeserializeObject(content);

                Response2 desContent = JsonConvert.DeserializeObject<Response2>(content);
                
                Console.Write(desContent1);
                Console.ReadKey();
            }
        }
    }
}