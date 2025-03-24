using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Core
{
    public class ServiceResult<TResponse>
    {
        public TResponse Response { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public int StatusCode { get; set; }


        public static ServiceResult<TResponse> OK(TResponse response)
        {
            return new ServiceResult<TResponse>
            {
                Response = response,
                Errors = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static ServiceResult<TResponse> INFO(Dictionary<string, string> errors, int statusCode, TResponse response)
        {
            return new ServiceResult<TResponse>
            {
                Response = response,
                StatusCode = statusCode,
                Errors = errors
            };
        }

        public static ServiceResult<TResponse> ERROR(Dictionary<string, string> errors, HttpStatusCode statusCode)
        {
            return new ServiceResult<TResponse>
            {
                Errors = errors,
                Response = default,
                StatusCode = (int)statusCode
            };
        }

        public static ServiceResult<TResponse> ERROR(string key, string value)
        {
            return new ServiceResult<TResponse>
            {
                Response = default,
                StatusCode = (int)HttpStatusCode.BadRequest,
                Errors = new Dictionary<string, string> { { key, value } }
            };
        }
    }
}
