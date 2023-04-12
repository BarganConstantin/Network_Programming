using HTTPClientApp.Constants;
using HTTPClientApp.Entities;
using HTTPClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClientApp
{
    public class HttpClientService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        static HttpClientService() 
        {
            _httpClient.BaseAddress = new Uri(UrlAddresses.BaseAddress);
            setAcceptJsonHeaderFormat();
        }

        public static CategoryListResponse GetCategories()
        {
            HttpResponseMessage response = getRequest(UrlAddresses.GetCategoryListAddress);
            Task<string> responseBody;

            if (response.IsSuccessStatusCode)
            {
                responseBody = getResponseBodyAsync(response);
                var categories = JsonSerializer.Deserialize<List<Category>>(responseBody.Result);
                return new CategoryListResponse() { Status = true, Categories = categories};
            }
            else
            {
                var msg = ("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase).ToString();
                return new CategoryListResponse() { Status = false , StatusMsg = msg};
            }
        }

        private static HttpResponseMessage getRequest(string url) 
        {
            var response = _httpClient.GetAsync("/api/Category/categories").Result;
            return response;
        }

        private HttpResponseMessage makeRequest(string url, string a)
        {
            var response = _httpClient.GetAsync("/api/Category/categories").Result;
            return response;
        }

        private static async Task<string> getResponseBodyAsync(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        private static void setAcceptJsonHeaderFormat()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}