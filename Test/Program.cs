using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using web_api_queryhelper;

namespace Test
{
    class Program
    {
        public class Staff
        {
           public int id { get; set; }
           public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            DoStuff();
            Console.ReadKey();
        }

        private static void DoStuff()
        {
           
        }


        private static HttpClientHandler CreateHttpClientHandler()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;

            return handler;
        }

        private static AuthenticationHeaderValue CreateAuthenticationHeaderValue(string authToken = null)
        {
            if (authToken == null)
                return null;

            var authHeader = default(AuthenticationHeaderValue);
  
            if (authToken != null)
                authHeader = new AuthenticationHeaderValue("Bearer", $"{authToken.Replace("Bearer", "").Trim()}");

            return authHeader;
        }

        private static NameValueCollection CreateNameValueCollection(Dictionary<string, string> additionalRequestHeaders = null)
        {
            if (additionalRequestHeaders == null)
                return new NameValueCollection();

            var headers = additionalRequestHeaders.Aggregate(new NameValueCollection(),
                          (seed, current) =>
                          {
                              seed.Add(current.Key, current.Value);
                              return seed;
                          });

            return headers;
        }
    }
}
