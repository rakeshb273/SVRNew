using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data.Entitites
{
    public class Address: CommonEntity
    {
        public Address()
        {
            State = new State();
        }
        public int ID { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Landmark { get; set; }
        public virtual string City { get; set; }
        public virtual int Pincode { get; set; }
        public virtual State State { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}
