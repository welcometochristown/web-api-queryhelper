using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace web_api_queryhelper
{
    public static partial class JSONQueryHelper
    {
        #region void
  
        public static Task DeleteAPIResultAsync(string server, string apiString, int timeout = 180)
        {
            return DeleteAPIResultAsync(server, apiString, new HttpClientHandler(),  null, new NameValueCollection(), timeout);
        }

        public static Task DeleteAPIResultAsync(string server, string apiString, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return DeleteAPIResultAsync(server, apiString, new HttpClientHandler(),  authenticationHeader, new NameValueCollection(), timeout);
        }

        public static Task DeleteAPIResultAsync(string server, string apiString, NameValueCollection headers, int timeout = 180)
        {
            return DeleteAPIResultAsync(server, apiString, new HttpClientHandler(),  null, headers, timeout);
        }

        public static Task DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, int timeout = 180)
        {
            return DeleteAPIResultAsync(server, apiString, clientHandler,  null, new NameValueCollection(), timeout);
        }

        public static Task DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return DeleteAPIResultAsync(server, apiString, clientHandler, authenticationHeader, new NameValueCollection(), timeout);
        }

        public static Task DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            return DeleteAPIResultAsync(server, apiString, clientHandler,  null, headers, timeout);
        }

        public static Task DeleteAPIResultAsync(string server, string apiString, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, NameValueCollection headers, int timeout = 180)
        {
            try
            {
                return APIResult(async (HttpClient client) =>
                {
                    return await client.DeleteAsync(apiString);

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

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(),  null, new NameValueCollection(), timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(),  authenticationHeader, new NameValueCollection(), timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, NameValueCollection headers, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, new HttpClientHandler(), null, headers, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, clientHandler,  null, new NameValueCollection(), timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, clientHandler,  authenticationHeader, new NameValueCollection(), timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, NameValueCollection headers, int timeout = 180)
        {
            return await DeleteAPIResultAsync<T>(server, apiString, clientHandler,  null, headers, timeout);
        }

        public static async Task<T> DeleteAPIResultAsync<T>(string server, string apiString, HttpClientHandler clientHandler, AuthenticationHeaderValue authenticationHeader, NameValueCollection headers, int timeout = 180)
        {
            try
            {

                return await APIResult<T>(async (HttpClient client) =>
                {
                    return await client.DeleteAsync(apiString);

                }, server, clientHandler, headers, authenticationHeader, SafeSpan(timeout));

            }
            catch(QueryHelperException ex)
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
