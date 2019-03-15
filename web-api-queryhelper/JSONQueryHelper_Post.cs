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
using System.Threading;

namespace web_api_queryhelper
{
    public static partial class JSONQueryHelper
    {
        #region void

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, int timeout = 180)
        {
              return PostAPIResultAsync(server, apiString, postObject, new HttpClientHandler(), null, new NameValueCollection(), timeout);
        }

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return PostAPIResultAsync(server, apiString, postObject, new HttpClientHandler(),  authenticationHeader, new NameValueCollection(), timeout);
        }

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, NameValueCollection headers, int timeout = 180)
        {
            return PostAPIResultAsync(server, apiString, postObject, new HttpClientHandler(), null, headers, timeout);
        }

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, int timeout = 180)
        {
            return PostAPIResultAsync(server, apiString, postObject, clientHandler,  null, new NameValueCollection(), timeout);
        }

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return PostAPIResultAsync(server, apiString, postObject, clientHandler,  authenticationHeader, new NameValueCollection(), timeout);
        }

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            return PostAPIResultAsync(server, apiString, postObject, clientHandler,  null, headers, timeout);
        }

        public static Task PostAPIResultAsync(string server, string apiString, object postObject, HttpClientHandler clientHandler,  AuthenticationHeaderValue authenticationHeader, NameValueCollection headers, int timeout = 180)
        {
            try
            {
                return APIResult(async (HttpClient client) =>
                {
                    return await client.PostAsJsonAsync(apiString, postObject);

                }, server, clientHandler, headers, authenticationHeader, SafeSpan(timeout));
            }
            catch (QueryHelperException ex)
            {
                throw new QueryHelperException($"Request to {server}/{apiString} failed. {ex.Message}", ex.Response, ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Request to {server}/{apiString} failed. {ex.Message}", ex);
            }
        }
        #endregion

        #region <T>

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, new HttpClientHandler(),  null, new NameValueCollection(), timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, new HttpClientHandler(),  authenticationHeader, new NameValueCollection(), timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, NameValueCollection headers, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, new HttpClientHandler(),  null, headers, timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, clientHandler, null, new NameValueCollection(), timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, clientHandler, authenticationHeader, new NameValueCollection(),  timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            return await PostAPIResultAsync<T>(server, apiString, postObject, clientHandler, null, headers,  timeout);
        }

        public static async Task<T> PostAPIResultAsync<T>(string server, string apiString, object postObject, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, NameValueCollection headers, int timeout = 180)
        {
            try
            {
                return await APIResult<T>(async (HttpClient client) =>
                {
                    return await client.PostAsJsonAsync(apiString, postObject);

                }, server, clientHandler, headers, authenticationHeader, SafeSpan(timeout));
            }
            catch (QueryHelperException ex)
            {
                throw new QueryHelperException($"Request to {server}/{apiString} failed. {ex.Message}", ex.Response, ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Request to {server}/{apiString} failed. {ex.Message}", ex);
            }
        }

        #endregion
    }
}
