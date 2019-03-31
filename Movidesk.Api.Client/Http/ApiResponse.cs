using Movidesk.Api.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Movidesk.Api.Client.Http
{
    public class ApiResponse<T> where T : class
    {
        public HttpResponseMessage InnerResponse { get; set; }
        public T ResponseObject { get; set; }
    }
}
