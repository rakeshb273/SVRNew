using SVR.Core.Models;
using SVR.Core.RelatedData;
using SVR.Core.UpdateModels;
using SVR.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Core.Services.Interface
{
    public interface IBillService
    {
        Task<BillRelatedDto> GetRelatedData(CancellationToken cancellationToken);
        Task<Response<int> > CreateorUpdate(BillUpdateModel entity, CancellationToken cancellationToken);
         Task<PagedResponse<IEnumerable<BillDto>>> GetPagedCollection(FilterParameter parameter, CancellationToken cancellationToken);

        Task<int> GetTotalRecords(FilterParameter parameter, CancellationToken cancellationToken);


        Task<Response<IEnumerable<BillDto>>> GetAll(CancellationToken cancellationToken); 

        Task<Response<BillUpdateModel>> GetById(int id, CancellationToken cancellationToken);

        Task<IEnumerable<BillDto>> GetSyncAll(int skip , int take);
    }
}
