using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient, Uri baseUrlAddress) 
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrlAddress;

            setAcceptJsonHeaderFormat();
        }

        public void Run()
        {

            HttpResponseMessage response = makeRequest("/api/Category/categories");

            if (response.IsSuccessStatusCode)
            {
                Task<string> responseBody = getResponseBodyAsync(response);
                Console.WriteLine(responseBody.Result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private HttpResponseMessage makeRequest(string url) 
        {
            var response = _httpClient.GetAsync("/api/Category/categories").Result;
            return response;
        }

        private HttpResponseMessage makeRequest(string url, string a)
        {
            var response = _httpClient.GetAsync("/api/Category/categories").Result;
            return response;
        }

        private async Task<string> getResponseBodyAsync(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        private void setAcceptJsonHeaderFormat()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}