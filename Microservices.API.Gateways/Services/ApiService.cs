using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.API.Gateways.Services
{

    public class ApiService: IApiService
    {
        public async Task<T> GetAsync<T>(string serviceUrl,  string relativePath)
        {
            HttpResponseMessage apiResponse = await SendRequest(serviceUrl, relativePath, HttpMethod.Get).ConfigureAwait(false);
            var result = await GetApiResponse<T>(apiResponse).ConfigureAwait(false);
            return result;
        }           
    
        #region Help Methods

        static async Task<HttpResponseMessage> SendRequest(string serviceUrl, string pUrl, HttpMethod httpMethod, string pJsonContent = null)
        {
            using (var _Client = HttpClientFactory.Create())
            {
                var httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = httpMethod;
                httpRequestMessage.RequestUri = new Uri(serviceUrl + pUrl);

                if (!string.IsNullOrWhiteSpace(pJsonContent))
                {
                    HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = httpContent;
                }

                _Client.Timeout = TimeSpan.FromMinutes(10);
                return await _Client.SendAsync(httpRequestMessage).ConfigureAwait(false);
            }
        }

        static async Task<T> GetApiResponse<T>(HttpResponseMessage apiResponse)
        {
            string responseData = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = default(T);

            if (apiResponse.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(responseData))
                {
                    result = JsonConvert.DeserializeObject<T>(responseData);
                }
                else
                {
                    result = default(T);
                }
            }
            else
            {
                return result;
            }

            return result;
        }
        #endregion
    }
}
