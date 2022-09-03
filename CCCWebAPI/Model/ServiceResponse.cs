using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCWebAPI.Model
{
    /// <summary>
    /// Generic Response for the Web API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public T Model { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string ErrorCode { get; set; }
        public string Data { get; set; }
    }
}
