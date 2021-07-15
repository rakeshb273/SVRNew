using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Data.Entitites
{
    public class State : CommonEntity
    {
        public virtual string Name { get; set; }
        public virtual int Code { get; set; }


    }
}
