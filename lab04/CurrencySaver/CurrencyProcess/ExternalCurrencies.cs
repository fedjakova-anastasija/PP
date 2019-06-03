using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System;

namespace CurrencySaver.ExternalQueries
{
    public class Currencies
    {
        public Dictionary<string, CurrenciesParams> Valute { get; set; }
    }

    public class CurrenciesParams
    {
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public decimal Value { get; set; }
    }

    public class Client
    {
        public static R GetSync<R>(string url)
        {
            var result = default(R);
            WebClient webClient = new WebClient();
            Stream stream = null;
            try
            {
                stream = webClient.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string json = sr.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    result = JsonConvert.DeserializeObject<R>(json);
                }
            }
            finally
            {
                stream?.Close();
            }

            return result;
        }

        public static async Task<R> GetAsync<R>(string url)
        {
            var result = default(R);
            WebClient webClient = new WebClient();
            Stream stream = null;
            try
            {
                stream = await webClient.OpenReadTaskAsync(url);
                StreamReader sr = new StreamReader(stream);
                string json = await sr.ReadToEndAsync();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    result = JsonConvert.DeserializeObject<R>(json);
                }
            }
            finally
            {
                stream?.Close();
            }

            return result;
        }
    }

    public class CurrencyRequest
    {
        private const string processUrl = "https://www.cbr-xml-daily.ru/daily_json.js";

        public Currencies GetAllSync()
        {
            return Client.GetSync<Currencies>(processUrl);
        }

        public async Task<Currencies> GetAllAsync()
        {
            return await Client.GetAsync<Currencies>(processUrl);
        }
    }
}
