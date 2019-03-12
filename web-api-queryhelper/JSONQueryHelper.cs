using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace web_api_queryhelper
{
    public static class JSONQueryHelper
    {
        #region Delete

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(), new NameValueCollection(), null, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString,  AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
           return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(), new NameValueCollection(), authenticationHeader, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString,  NameValueCollection headers, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(), headers, null, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, clientHandler, new NameValueCollection(), null, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, clientHandler, new NameValueCollection(), authenticationHeader, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, clientHandler, headers, null, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await APIResult<T>(async (HttpClient client) =>
            {
                return await client.DeleteAsync(apiString);

            }, server, apiString, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        #endregion
       

        public static async Task<T> PutAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await APIResult<T>(async (HttpClient client) =>
            {
                return await client.PutAsJsonAsync(apiString, postObject);

            }, server, apiString, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await APIResult<T>(async (HttpClient client) =>
            {
                return await client.PostAsJsonAsync(apiString, postObject);

            }, server, apiString, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        public static async Task<T> GetAPIResult<T>(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await APIResult<T>(async (HttpClient client) =>
            {
                return await client.GetAsync(apiString);

            }, server, apiString, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        private static async Task<T> APIResult<T>(Func<HttpClient, Task<HttpResponseMessage>> clientAction, string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headerCollection, AuthenticationHeaderValue authenticationHeader, TimeSpan timeout)
        {
            T result = default(T);// = null;

            using (var client = new HttpClient(clientHandler) { Timeout = timeout })
            {
                //action
                var response = await clientAction(client);

                //set address
                client.BaseAddress = new Uri(server);

                //create headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = authenticationHeader;

                //custom headers
                foreach (var i in headerCollection.AllKeys.SelectMany(headerCollection.GetValues, (k, v) => new { key = k, value = v }))
                    client.DefaultRequestHeaders.Add(i.key, i.value);

                //read result content
                var contentString = await response.Content.ReadAsStringAsync();
            
                //check result
                if (response.IsSuccessStatusCode)
                    result = await response.Content.ReadAsAsync<T>();
                else
                    throw new Exception($"Request Failed ({response.StatusCode})\r\n{contentString}");

            }

            return result;
        }
    }
}
