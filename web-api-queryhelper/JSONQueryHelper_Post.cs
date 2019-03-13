using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace web_api_queryhelper
{
    public static partial class JSONQueryHelper
    {
        #region void

        public static void PostAPIResultAsync(string server, string apiString, object postObject, int timeout = 180)
        {
              PostAPIResultAsync(server, apiString, postObject, new HttpClientHandler(), new NameValueCollection(), null, timeout);
        }

        public static void PostAPIResultAsync(string server, string apiString, object postObject, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
              PostAPIResultAsync(server, apiString, postObject, new HttpClientHandler(), new NameValueCollection(), authenticationHeader, timeout);
        }

        public static void PostAPIResultAsync(string server, string apiString, object postObject, NameValueCollection headers, int timeout = 180)
        {
              PostAPIResultAsync(server, apiString, postObject, new HttpClientHandler(), headers, null, timeout);
        }

        public static void PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, int timeout = 180)
        {
              PostAPIResultAsync(server, apiString, postObject, clientHandler, new NameValueCollection(), null, timeout);
        }

        public static void PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
              PostAPIResultAsync(server, apiString, postObject, clientHandler, new NameValueCollection(), authenticationHeader, timeout);
        }

        public static void PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
              PostAPIResultAsync(server, apiString, postObject, clientHandler, headers, null, timeout);
        }

        public static void PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
              APIResult(async (HttpClient client) =>
            {
                  return await client.PostAsJsonAsync(apiString, postObject);

            }, server, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }
        #endregion

        #region <T>

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, new HttpClientHandler(), new NameValueCollection(), null, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, new HttpClientHandler(), new NameValueCollection(), authenticationHeader, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, NameValueCollection headers, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, new HttpClientHandler(), headers, null, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, clientHandler, new NameValueCollection(), null, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, clientHandler, new NameValueCollection(), authenticationHeader, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, clientHandler, headers, null, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await APIResult<T>(async (HttpClient client) =>
            {
                return await client.PostAsJsonAsync(apiString, postObject);

            }, server, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        #endregion
    }
}
