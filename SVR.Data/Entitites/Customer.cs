using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data.Entitites
{
    public class Customer : CommonEntity
    {
        public virtual string Name { get; set; }
        public virtual int ID { get; set; }
        public virtual string GSTIN { get; set; }
        public virtual string GRNO { get; set; }
        public virtual string PANNO { get; set; }
       // public virtual Address Address { get; set; }

    }
}
