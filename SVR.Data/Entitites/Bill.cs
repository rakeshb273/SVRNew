using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data.Entitites
{
    public class Bill : CommonEntity
    {
        public Bill()
        {
            this.BillItems = new HashSet<BillItem>();

        }
        public virtual ICollection<BillItem> BillItems { get; set; }
       
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string InvoiceNo { get; set; }
        //public virtual Customer BilledCustomer { get; set; }
        //public virtual Customer ShippedCustomer { get; set; }
        public virtual DateTime BilledDate { get; set; }
    }
}
