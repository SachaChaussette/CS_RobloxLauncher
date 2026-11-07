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

namespace RobloxLauncher.Models
{

    public static class DataAPI
    {
        private static readonly HttpClient client = new HttpClient();

        static DataAPI()
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                "AppleWebKit/537.36 (KHTML, like Gecko) " +
                "Chrome/120.0.0.0 Safari/537.36");

            client.DefaultRequestHeaders.Accept.ParseAdd("application/json, text/plain, */*");

            client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en-US,en;q=0.9");

            client.DefaultRequestHeaders.Referrer = new Uri("https://www.rolimons.com/");

            client.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "https://www.rolimons.com");
        }

        public static async Task<T> GetDataFromAPI<T>(string _url, string? _rootName = null)
        {
            string _json = await client.GetStringAsync(_url);

            if (!string.IsNullOrEmpty(_rootName))
            {
                _json = "{\"" + _rootName + "\":" + _json + "}";
            }

            return JsonConvert.DeserializeObject<T>(_json) ?? throw new InvalidOperationException("Réponse API invalide.");
        }
    }

}
