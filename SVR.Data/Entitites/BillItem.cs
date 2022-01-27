using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data.Entitites
{
    public class BillItem : CommonEntity
    {
        public int ID { get; set; }
        public   string Name { get; set; }
        public virtual int HSNCode { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Price { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual int Amount
        {
            get
            {
                return Quantity * Price;

            }
        }


    }
}
