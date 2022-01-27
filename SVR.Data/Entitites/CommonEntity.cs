using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data.Entitites
{
   public class CommonEntity
    { 

        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public virtual bool isActive { get; set; }

    }
}
