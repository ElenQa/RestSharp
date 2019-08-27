using System;
using RestSharp;
using Newtonsoft.Json;


namespace RestSharp_Example
{
    class Program
    {
        static void Main(string[] args)
        {
                       
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://gogotaxi.com.ua");

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "/api/driver/me";
            request.AddHeader("token", "ce18c8257503ba0dfa0656ea4306d22b3933ffbe1923aaff18ecc078b5070a52");

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            object desContent = JsonConvert.DeserializeObject(content);

            Console.Write(desContent);
            Console.ReadKey();
        }
    }
}