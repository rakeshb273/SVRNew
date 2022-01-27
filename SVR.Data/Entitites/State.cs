using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SVR.Data.Entitites
{
    public class State : CommonEntity
    {
        public virtual string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Code { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }


    }
}
