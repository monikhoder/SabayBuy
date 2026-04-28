using Newtonsoft.Json;
using POS.Dtos;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POS.ApiServices
{
    public class POSAccountService
    {
        private static readonly CookieContainer CookieContainer = new CookieContainer();
        private static readonly HttpClient Client = CreateClient();

        public static PosUserDto CurrentUser { get; private set; }

        public async Task<ApiResult<PosUserDto>> LoginAsync(string email, string password)
        {
            var loginDto = new LoginDto
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await Client.PostAsync("POSAccount/login", content);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return ApiResult<PosUserDto>.Fail(GetErrorMessage(response.StatusCode, body));
                }

                var user = JsonConvert.DeserializeObject<PosUserDto>(body);
                CurrentUser = user;

                return ApiResult<PosUserDto>.Ok(user);
            }
            catch (HttpRequestException)
            {
                return ApiResult<PosUserDto>.Fail("Cannot connect to API. Please check that the API project is running.");
            }
            catch (TaskCanceledException)
            {
                return ApiResult<PosUserDto>.Fail("API request timeout. Please try again.");
            }
            catch (Exception ex)
            {
                return ApiResult<PosUserDto>.Fail(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> LogoutAsync()
        {
            try
            {
                var response = await Client.PostAsync("POSAccount/logout", new StringContent(string.Empty));
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return ApiResult<bool>.Fail(GetErrorMessage(response.StatusCode, body));
                }

                CurrentUser = null;
                return ApiResult<bool>.Ok(true);
            }
            catch (HttpRequestException)
            {
                return ApiResult<bool>.Fail("Cannot connect to API. Please check that the API project is running.");
            }
            catch (TaskCanceledException)
            {
                return ApiResult<bool>.Fail("API request timeout. Please try again.");
            }
            catch (Exception ex)
            {
                return ApiResult<bool>.Fail(ex.Message);
            }
        }

        internal static HttpClient CreateSharedClient()
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = CookieContainer,
                UseCookies = true
            };

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            client.Timeout = TimeSpan.FromSeconds(30);
            return client;
        }

        private static HttpClient CreateClient()
        {
            return CreateSharedClient();
        }

        private static string GetErrorMessage(HttpStatusCode statusCode, string body)
        {
            if (!string.IsNullOrWhiteSpace(body))
            {
                return body.Trim('"');
            }

            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "Only admin and seller can login to POS.";
            }

            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Invalid email or password.";
            }

            return "Login failed. Please try again.";
        }
    }
}
