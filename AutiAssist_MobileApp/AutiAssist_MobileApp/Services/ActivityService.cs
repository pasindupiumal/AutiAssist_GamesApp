using AutiAssist_MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutiAssist_MobileApp.Services
{
    class ActivityService
    {
        static string BaseURL = "http://10.0.2.2:5001";
        static HttpClient client;

        static ActivityService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
        }


        public static async Task TrainValues(Activity activity)
        {
            var json = JsonConvert.SerializeObject(activity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/trainValues", content);

            Console.WriteLine(response.StatusCode);
        }
    }
}
