using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.Models
{
   public class BaseDto
    {
        public BaseDto()
        {
            Active = true;
        }
        public bool Active { get; set; }

        public int Id { get; set; }

        //[CompareIgnoreAttribute]
        //public bool IsEditMode { get; set; } = false;

    }
}
