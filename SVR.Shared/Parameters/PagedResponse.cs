using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Shared.Parameters
{
    public class PagedResponse<T> : Response<T>
    {
        public PagedResponse()
        {
        }

        public PagedResponse(T data, PagedParameter pp)
        {
            PagingParameter = pp;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public PagedParameter PagingParameter { get; set; }
    }
}
