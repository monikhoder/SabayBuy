using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POS.Dtos;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POS.ApiServices
{
    public class POSOrderService
    {
        private static readonly HttpClient Client = POSAccountService.CreateSharedClient();

        public async Task<ApiResult<POSOrderCheckoutResponseDto>> CreateOrderAsync(CreatePOSOrderDto orderDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(orderDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await Client.PostAsync("pos/orders", content);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return ApiResult<POSOrderCheckoutResponseDto>.Fail(GetErrorMessage(response.StatusCode, body));
                }

                var checkoutResponse = ParseCheckoutResponse(body);
                return ApiResult<POSOrderCheckoutResponseDto>.Ok(checkoutResponse);
            }
            catch (HttpRequestException)
            {
                return ApiResult<POSOrderCheckoutResponseDto>.Fail("Cannot connect to API. Please check that the API project is running.");
            }
            catch (TaskCanceledException)
            {
                return ApiResult<POSOrderCheckoutResponseDto>.Fail("API request timeout. Please try again.");
            }
            catch (Exception ex)
            {
                return ApiResult<POSOrderCheckoutResponseDto>.Fail(ex.Message);
            }
        }

        private static POSOrderCheckoutResponseDto ParseCheckoutResponse(string body)
        {
            var token = JToken.Parse(body);

            if (token["order"] != null)
            {
                return new POSOrderCheckoutResponseDto
                {
                    Order = token["order"].ToObject<POSOrderDto>(),
                    Payment = token["payment"],
                    HasOnlinePayment = true
                };
            }

            return new POSOrderCheckoutResponseDto
            {
                Order = token.ToObject<POSOrderDto>(),
                HasOnlinePayment = false
            };
        }

        private static string GetErrorMessage(HttpStatusCode statusCode, string body)
        {
            if (!string.IsNullOrWhiteSpace(body))
            {
                return body.Trim('"');
            }

            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Please login before creating POS orders.";
            }

            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "Only admin and seller accounts can create POS orders.";
            }

            return $"Failed to create POS order. Status code: {(int)statusCode}";
        }
    }
}
