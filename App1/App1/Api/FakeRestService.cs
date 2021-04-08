namespace App1.Api {
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public class FakeRestService : IRestService {

        /// <inheritdoc />
        public List<Root> Items { get; }

        public FakeRestService() {
        }

        /// <inheritdoc />
        public List<Root> RefreshData(string productCode) {
            return RefreshDataAsync(productCode).Result;
        }

        /// <inheritdoc />

        /// <inheritdoc />
        public async Task<List<Root>> RefreshDataAsync(string productCode) {
            
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var resourceName = "App1.Resources.answer.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    string text = reader.ReadToEnd();
                    var result =  JsonConvert.DeserializeObject<List<Root>>(text);
                    return result;
                }
            }
        }
    }
}