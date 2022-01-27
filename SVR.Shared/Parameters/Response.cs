using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Shared.Parameters
{
    public class Response<T>
    {
        public Response()
        {
        }
                
        public int ErrorCode { get; set; }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public T Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }
    }
}
