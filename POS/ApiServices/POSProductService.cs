using Newtonsoft.Json;
using POS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace POS.ApiServices
{
    public class POSProductService
    {
        private static readonly HttpClient Client = POSAccountService.CreateSharedClient();

        public async Task<ApiResult<PaginationDto<POSProductVariantDto>>> GetProductsAsync(POSProductQueryParams queryParams = null)
        {
            try
            {
                var url = BuildProductUrl(queryParams ?? new POSProductQueryParams());
                var response = await Client.GetAsync(url);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return ApiResult<PaginationDto<POSProductVariantDto>>.Fail(GetErrorMessage(response.StatusCode, body));
                }

                var products = JsonConvert.DeserializeObject<PaginationDto<POSProductVariantDto>>(body)
                    ?? new PaginationDto<POSProductVariantDto>
                    {
                        Data = new List<POSProductVariantDto>()
                    };

                if (products.Data == null)
                {
                    products.Data = new List<POSProductVariantDto>();
                }

                return ApiResult<PaginationDto<POSProductVariantDto>>.Ok(products);
            }
            catch (HttpRequestException)
            {
                return ApiResult<PaginationDto<POSProductVariantDto>>.Fail("Cannot connect to API. Please check that the API project is running.");
            }
            catch (TaskCanceledException)
            {
                return ApiResult<PaginationDto<POSProductVariantDto>>.Fail("API request timeout. Please try again.");
            }
            catch (Exception ex)
            {
                return ApiResult<PaginationDto<POSProductVariantDto>>.Fail(ex.Message);
            }
        }

        private static string BuildProductUrl(POSProductQueryParams queryParams)
        {
            var query = new List<string>
            {
                $"pageIndex={queryParams.PageIndex}",
                $"pageSize={queryParams.PageSize}",
                $"inStockOnly={queryParams.InStockOnly.ToString().ToLower()}"
            };

            AddQueryValue(query, "sort", queryParams.Sort);
            AddQueryValue(query, "search", queryParams.Search);
            AddQueryList(query, "brands", queryParams.Brands);
            AddQueryList(query, "categories", queryParams.Categories);

            return "POSProduct?" + string.Join("&", query);
        }

        private static void AddQueryValue(List<string> query, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            query.Add($"{key}={Uri.EscapeDataString(value)}");
        }

        private static void AddQueryList(List<string> query, string key, List<string> values)
        {
            if (values == null || values.Count == 0)
            {
                return;
            }

            var value = string.Join(",", values.Where(item => !string.IsNullOrWhiteSpace(item)));
            AddQueryValue(query, key, value);
        }

        private static string GetErrorMessage(HttpStatusCode statusCode, string body)
        {
            if (!string.IsNullOrWhiteSpace(body))
            {
                return body.Trim('"');
            }

            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Please login before loading POS products.";
            }

            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "Only admin and seller accounts can load POS products.";
            }

            return $"Failed to load products. Status code: {(int)statusCode}";
        }
    }
}
