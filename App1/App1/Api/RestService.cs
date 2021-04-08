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
    using System.Text.Json;

    public class RestService : IRestService {

        private const string basePath = "https://48f5a36a6d2a.ngrok.io/query?packageCode=";

        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public List<Root> Items { get; private set; }

        public RestService() {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions {
                                                              PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                              WriteIndented = true
                                                          };
        }


        public static List<Root> GetTrackingInfoRoot(string productCode) {
            var trackingInfo = GetProductInfos(productCode).Result;
            return trackingInfo;
        }

        public async Task<List<Root>> RefreshDataAsync() {
            Items = new List<Root>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Root>>(content, serializerOptions);
                }
            } catch (Exception ex) {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }


        private static async Task<List<Root>> GetProductInfos(string query) {
            // var client = new HttpClient();
            // List<Root> productInfos = null;
            // query = HttpUtility.UrlEncode(query);
            // var uri = $"{basePath}{query}";
            // var response = await client.GetAsync(uri);
            // if (response.IsSuccessStatusCode) {
            //     var responseString = await response.Content.ReadAsStringAsync();
            //     
            //     
            //     //TODO: Delete this
            //     
            //     productInfos = JsonConvert.DeserializeObject<List<Root>>(responseString);
            // }
            //
            var assembly = typeof(App).GetTypeInfo().Assembly;
            // var fileStream = assembly.GetManifestResourceInfo("PackageTracing.Resources.Sample.json");
            //
            //
            // fileStream.jj
            // var text = File.ReadAllText(fileStream);
            // return  JsonConvert.DeserializeObject<List<Root>>(fileStream);
            // var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "App1.Resources.answer.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    string result = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Root>>(result);
                }
            }

            // return productInfos;
        }
    }
}