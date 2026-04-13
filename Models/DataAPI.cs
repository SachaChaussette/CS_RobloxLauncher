using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CS_RobloxLauncher.Models
{
    public class DataAPI
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<T> GetDataFromAPI<T>(string _url, string _rootName = null)
        {
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                "(KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

            client.DefaultRequestHeaders.Add("Accept",
                "application/json, text/plain, */*");

            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("Referer", "https://www.rolimons.com/");
            client.DefaultRequestHeaders.Add("Origin", "https://www.rolimons.com");

            string _jsonData = await client.GetStringAsync(_url);

            if (!string.IsNullOrEmpty(_rootName))
            {
                _jsonData = "{\"" + _rootName + "\":" + _jsonData + "}";
            }

            return JsonConvert.DeserializeObject<T>(_jsonData);
        }
    }
}
