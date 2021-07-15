using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Shared.Parameters
{
    public class FilterParameter
    {
        public FilterParameter()
        {
            Pager = new PagedParameter(); 
        }

        public List<object> Filter { get; set; } 
        public PagedParameter Pager { get; set; }
    }
}
