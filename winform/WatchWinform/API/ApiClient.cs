using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WatchWinform.Utils.Base;

namespace WatchWinform.API
{
    public static class ApiClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static void Initialize()
        {
            if (_httpClient.BaseAddress != new Uri(ApiSettings.BaseAddress))
                _httpClient.BaseAddress = new Uri(ApiSettings.BaseAddress);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiSettings.BearerToken);
        }           


        public static async Task<BaseResponse<T>> GetAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
        }

        public static async Task<BaseResponse<T>> PostAsync<T>(string requestUri, string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
        }

        public static async Task<BaseResponse<T>> PutAsync<T>(string requestUri, string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
        }

        public static async Task<BaseResponse<T>> DeleteAsync<T>(string requestUri)
        {
            var response = await _httpClient.DeleteAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
        }
    }
}