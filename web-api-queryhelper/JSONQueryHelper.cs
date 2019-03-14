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
    public static partial class JSONQueryHelper
    {
        /// <summary>
        /// Api result with no response type
        /// </summary>
        /// <param name="clientAction"></param>
        /// <param name="server"></param>
        /// <param name="clientHandler"></param>
        /// <param name="headerCollection"></param>
        /// <param name="authenticationHeader"></param>
        /// <param name="timeout"></param>
        private static async void APIResult(Func<HttpClient, Task<HttpResponseMessage>> clientAction, string server, HttpClientHandler clientHandler, NameValueCollection headerCollection, AuthenticationHeaderValue authenticationHeader, TimeSpan timeout)
        {
            await APIResultAction(clientAction, server, clientHandler, headerCollection, authenticationHeader, timeout);
        }

        /// <summary>
        /// Api result with [T] response type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientAction"></param>
        /// <param name="server"></param>
        /// <param name="clientHandler"></param>
        /// <param name="headerCollection"></param>
        /// <param name="authenticationHeader"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static async Task<T> APIResult<T>(Func<HttpClient, Task<HttpResponseMessage>> clientAction, string server, HttpClientHandler clientHandler, NameValueCollection headerCollection, AuthenticationHeaderValue authenticationHeader, TimeSpan timeout)
        {
            var response = await APIResultAction(clientAction, server, clientHandler, headerCollection, authenticationHeader, timeout);

            if (!response.IsSuccessStatusCode)
                throw new QueryHelperException($"Request Query Failed ({response.StatusCode}) - {response.ReasonPhrase}", response);
            else 
                return await response.Content.ReadAsAsync<T>();
        }

        /// <summary>
        /// Perform Http Action
        /// </summary>
        /// <param name="clientAction"></param>
        /// <param name="server"></param>
        /// <param name="clientHandler"></param>
        /// <param name="headerCollection"></param>
        /// <param name="authenticationHeader"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static async Task<HttpResponseMessage> APIResultAction(Func<HttpClient, Task<HttpResponseMessage>> clientAction, string server, HttpClientHandler clientHandler, NameValueCollection headerCollection, AuthenticationHeaderValue authenticationHeader, TimeSpan timeout)
        {
            using (var client = new HttpClient(clientHandler) { Timeout = timeout })
            {
                //set address
                client.BaseAddress = new Uri(server);

                //create headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = authenticationHeader;

                //custom headers
                foreach (var i in headerCollection.AllKeys.SelectMany(headerCollection.GetValues, (k, v) => new { key = k, value = v }))
                    client.DefaultRequestHeaders.Add(i.key, i.value);

                //action
                return await clientAction(client);
            }
        }

    }

}
