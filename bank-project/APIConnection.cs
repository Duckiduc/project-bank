using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bank_project
{
    public class ApiConnection
    {
        public ApiConnection()
        {

        }

        public decimal AddToCurrency(string currency, decimal amount)
        {
            JObject data = ApiFetch();
            decimal rate = Convert.ToDecimal(data["data"][currency]);
            return amount * rate;
        }

        public JObject ApiFetch()
        {
            //apiKey is in clear because there are no limits in usage and no cost associated to it
            string URL = "https://freecurrencyapi.net/api/v2/latest";
            string apiKey = "?apikey=22f7bcf0-40e4-11ec-bc0a-991d492137a1";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL + apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                JObject data = (JObject)JsonConvert.DeserializeObject(dataObjects);
                client.Dispose();
                return data;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
    }
}
