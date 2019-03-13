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

        
        public static void DeleteAPIResultAsync(string server, string apiString, int timeout = 180)
        {
             DeleteAPIResultAsync(server, apiString, new HttpClientHandler(), new NameValueCollection(), null, timeout);
        }

        public static void DeleteAPIResultAsync(string server, string apiString, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            DeleteAPIResultAsync(server, apiString, new HttpClientHandler(), new NameValueCollection(), authenticationHeader, timeout);
        }

        public static void DeleteAPIResultAsync(string server, string apiString, NameValueCollection headers, int timeout = 180)
        {
            DeleteAPIResultAsync(server, apiString, new HttpClientHandler(), headers, null, timeout);
        }

        public static void DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, int timeout = 180)
        {
            DeleteAPIResultAsync(server, apiString, clientHandler, new NameValueCollection(), null, timeout);
        }

        public static void DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            DeleteAPIResultAsync(server, apiString, clientHandler, new NameValueCollection(), authenticationHeader, timeout);
        }

        public static void DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            DeleteAPIResultAsync(server, apiString, clientHandler, headers, null, timeout);
        }

        public static void DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            APIResult(async (HttpClient client) =>
            {
                return await client.DeleteAsync(apiString);

            }, server, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        #endregion

        #region <T>

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(), new NameValueCollection(), null, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(), new NameValueCollection(), authenticationHeader, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, NameValueCollection headers, int timeout = 180)
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

            }, server, clientHandler, headers, authenticationHeader, TimeSpan.FromSeconds(timeout));
        }

        #endregion
    }
     
}
