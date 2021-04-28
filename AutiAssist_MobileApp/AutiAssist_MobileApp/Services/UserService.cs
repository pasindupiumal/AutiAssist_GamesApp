using AutiAssist_MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutiAssist_MobileApp.Services
{
    class UserService
    {
        static string BaseURL = "http://10.0.2.2:3103";
        static HttpClient client;
        static UserService()
        { 
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
        }

        public static async Task<Response> Login(string username, string password)
        {
            var credentials = new Credential
            {
                Username = username,
                Password = password
            };

            Response failedResponse = null;

            try
            {
                var json = JsonConvert.SerializeObject(credentials);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("Users/login", content);
                var loginResponse = await response.Content.ReadAsStringAsync();
                var loginStatus = JsonConvert.DeserializeObject<Response>(loginResponse);

                if (!response.IsSuccessStatusCode)
                {
                    failedResponse = new Response();
                    failedResponse.Data = false;
                    failedResponse.Message = "Error connecting to server";
                    Debug.WriteLine($"Error connecting to server");
                    return failedResponse;
                }
                else
                {
                    return loginStatus;
                }
            }
            catch (Exception ex)
            {
                failedResponse.Data = false;
                failedResponse.Message = "Validation failed. Exception occured";
                Debug.WriteLine($"Logging in error : {ex.Message}");
                return failedResponse;
            }
        }
    }
}
