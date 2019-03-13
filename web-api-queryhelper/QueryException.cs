using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace web_api_queryhelper
{
    /// <summary>
    /// Exception returned if request fails. 
    ///     Contains [Response] of type HttpReponseMessage
    /// </summary>
    public class QueryHelperException : Exception
    {
        public HttpResponseMessage Response { get; private set; }

        public QueryHelperException(string message, HttpResponseMessage response)
            : base(message) { this.Response = response; }

        public QueryHelperException(string message, HttpResponseMessage response, Exception ex)
          : base(message, ex) { this.Response = response; }


    }
}
