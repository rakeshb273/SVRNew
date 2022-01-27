using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.Models
{
    public class BillDto
    {
        public int id { get; set; }
        public  string InvoiceNo { get; set; } 
        public  DateTime BilledDate { get; set; }
        public string CustomerName { get; set; }
        public int BillItemCount { get; set; }
    }
}
