using Newtonsoft.Json;
using POS.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace POS.ApiServices
{
    public class CategoriesService
    {
        private static readonly HttpClient Client = CreateClient();

        public async Task<ApiResult<List<CategoryDto>>> GetCategoriesWithProductsAsync()
        {
            try
            {
                var response = await Client.GetAsync("Categories/with-products");
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return ApiResult<List<CategoryDto>>.Fail(GetErrorMessage(response.StatusCode, body));
                }

                var categories = JsonConvert.DeserializeObject<List<CategoryDto>>(body) ?? new List<CategoryDto>();
                categories = categories.Where(category => category.ProductCount > 0).ToList();

                return ApiResult<List<CategoryDto>>.Ok(categories);
            }
            catch (HttpRequestException)
            {
                return ApiResult<List<CategoryDto>>.Fail("Cannot connect to API. Please check that the API project is running.");
            }
            catch (TaskCanceledException)
            {
                return ApiResult<List<CategoryDto>>.Fail("API request timeout. Please try again.");
            }
            catch (Exception ex)
            {
                return ApiResult<List<CategoryDto>>.Fail(ex.Message);
            }
        }

        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            client.Timeout = TimeSpan.FromSeconds(30);
            return client;
        }

        private static string GetErrorMessage(HttpStatusCode statusCode, string body)
        {
            if (!string.IsNullOrWhiteSpace(body))
            {
                return body.Trim('"');
            }

            return $"Failed to load categories. Status code: {(int)statusCode}";
        }
    }
}
