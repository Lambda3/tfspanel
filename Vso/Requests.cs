using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TfsPanel.Vso
{
    public class Requests
    {
        private readonly string baseUrl;
        private readonly string password;
        private readonly string username;

        public Requests(string baseUrl, string username, string password)
        {
            this.baseUrl = baseUrl;
            this.username = username;
            this.password = password;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();

            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<dynamic> Get(string url)
        {
            using (var client = CreateClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(json);
                }
            }

            throw new Exception("Invalid VSO response!");
        }
    }
}
