using Newtonsoft.Json;
using SentinelMvcV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SentinelMvcV.Helpers
{
    public static class WebApiServices
    {
        private static readonly string url = "https://localhost:44305/";
        private static string serviceUrl = "";
        private static readonly HttpClient client = new HttpClient();

        public static string SetToken
        {
            set
            {
                if (value != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                }
            }
        }

        public static async Task<string> GetToken(UserLoginDto dto)
        {
            serviceUrl = $"{url}auth/login";

            StringContent httpcontent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(serviceUrl, httpcontent))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", null);
                    return null;
                }
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }


        public static async Task<string> GetAll(string controller, string action)
        {
            serviceUrl = $"{url}{controller}/{action}";

            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", null);
                    return null;
                }
                var result = response.Content.ReadAsStringAsync();
                return await result;
            }
        }

        public static async Task<string> GetSingle(string controller, string action, string parametreName, int id)
        {
            serviceUrl = $"{url}{controller}/{action}/{parametreName}{id}";
            using (var response = await client.GetAsync(serviceUrl))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", null);
                    return null;
                }
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> Post<T>(string controller, string action, T instance) where T : class, new()
        {
            serviceUrl = $"{url}{controller}/{action}";

            string content = JsonConvert.SerializeObject(instance);

            StringContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(serviceUrl, httpContent))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", null);
                    return null;
                }
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> Put<T>(string controller, string action, T instance) where T : class, new()
        {
            serviceUrl = $"{url}{controller}/{action}";
            StringContent httpContent =
                new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(serviceUrl, httpContent))
            {
              
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", null);
                    return null;
                }
               
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> Delete(string controller, string action, int id)
        {
            serviceUrl = $"{url}{controller}/{action}/{id}";
            using (var response = await client.DeleteAsync(serviceUrl))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
