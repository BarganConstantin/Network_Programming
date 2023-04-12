using HTTPClientApp.Constants;
using HTTPClientApp.Entities;
using HTTPClientApp.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        public static GetCategoriesResponse GetCategories()
        {
            HttpResponseMessage response = _httpClient.GetAsync(UrlAddresses.GetCategoryListAddress).Result;
            Task<string> responseBody;

            if (response.IsSuccessStatusCode)
            {
                responseBody = getResponseBodyAsync(response);
                var categories = JsonSerializer.Deserialize<List<Category>>(responseBody.Result);
                return new GetCategoriesResponse() { Status = true, Categories = categories};
            }
            else
            {
                var msg = ("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase).ToString();
                return new GetCategoriesResponse() { Status = false , StatusMsg = msg};
            }
        }

        public static PostCategoryResponse PostCategory(string option)
        {
            var newCategory = new NewCategory() { title = option };
            var response = _httpClient.PostAsJsonAsync(UrlAddresses.PostCategoryListAddress, newCategory).Result;

            if (response.IsSuccessStatusCode)
            {
                return new PostCategoryResponse() { Status = true };
            }
            else
            {
                var msg = ("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase).ToString();
                return new PostCategoryResponse() { Status = false, StatusMsg = msg };
            }
        }

        public static DeleteCategoryResponse DeleteCategory(int categoryId)
        {
            var response = _httpClient.DeleteAsync(UrlAddresses.DeleteCategoryListAddress + categoryId).Result;

            if (response.IsSuccessStatusCode)
            {
                return new DeleteCategoryResponse() { Status = true };
            }
            else
            {
                var msg = ("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase).ToString();
                return new DeleteCategoryResponse() { Status = false, StatusMsg = msg };
            }
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