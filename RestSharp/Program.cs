using System;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace RestSharp_Example
{
    class Program
    {
        [DataContract]
        class Response
        {
            [DataMember]
            bool error { get; set; }
            [DataMember]
            string description { get; set; }
                       
        }
        static void Main(string[] args)
        {

            var request = (HttpWebRequest)WebRequest.Create("https://gogotaxi.com.ua/api/driver/validate");

            var postData = "phoneNumber=+380938933955";
            
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //object desContent = JsonConvert.DeserializeObject(responseString);
                        
            Response desContent = JsonConvert.DeserializeObject<Response>(responseString);


            Console.Write(desContent);
            
            Console.ReadKey();
                       


        }
    }
}