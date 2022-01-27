using SVR.Core.UpdateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVR.Core.Services
{
    public class BaseService
    {
        public BaseUpdateModel UpdateChildEntities(BaseUpdateModel src, BaseUpdateModel dest)
        {
            
            dest.Active = src.Active;
            dest.Deleted = src.Deleted; 
            dest.CreatedDate = src.CreatedDate;
            dest.ModifiedDate = src.ModifiedDate;
            dest.ModifiedBy = src.ModifiedBy;
            dest.CreatedBy = src.CreatedBy; 
            dest.ModifiedById = src.ModifiedById; 
            dest.CreatedById = src.CreatedById;
            return dest;
        }
    }
}
