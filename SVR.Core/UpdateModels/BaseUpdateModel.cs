using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.UpdateModels
{
            public class BaseUpdateModel
        {
            public BaseUpdateModel()
            {
                CreatedDate = DateTimeOffset.UtcNow;
            }
            public bool Active { get; set; } = true;
            public int CreatedById { get; set; }
            public string CreatedBy { get; set; }

            public DateTimeOffset CreatedDate { get; set; }

            public bool Deleted { get; set; }

            public int Id { get; set; }

            public int ModifiedById { get; set; }

            public string ModifiedBy { get; set; }

            public DateTimeOffset ModifiedDate { get; set; }

        }
    }
