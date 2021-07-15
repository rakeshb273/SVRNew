using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Shared.Parameters
{
   public class PagedParameter
    {
        public PagedParameter()
        {
            OrderBy = string.Empty;
            PageIndex -= 1;
        }

        public void SetTotalRecords(int total)
        {
            TotalRecords = total;
            TotalPages = (total == 0 || PageSize == 0) ? 0 : (int)Math.Ceiling(total / (double)PageSize);
        }

        public bool HasNextPage => (PageIndex < TotalPages);

        public bool HasPreviousPage => (PageIndex > 1);

        public bool IsDescending { get; set; }

        private string _orderBy;

        public string OrderBy
        {
            get
            {
                return _orderBy;
            }

            set
            {
                _orderBy = value;
            }
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int Skip { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
    }
}
