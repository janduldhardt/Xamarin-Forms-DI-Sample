namespace App1.Api {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using App1;
    using Models;
    using Newtonsoft.Json;

    public class RestService : IRestService {

        HttpClient client;

        public List<Root> Items { get; private set; }

        public RestService() {
            client = new HttpClient();
        }



        public async Task<List<Root>> RefreshDataAsync(string productCode) {
            Items = new List<Root>();

            Uri uri = new Uri($"{Constants.RestUrl}{productCode}");
            try {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Root>>(content);
                }
            } catch (Exception ex) {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }


    }
}