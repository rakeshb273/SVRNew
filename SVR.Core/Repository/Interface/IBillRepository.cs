using SVR.Core.Models;
using SVR.Core.RelatedData;
using SVR.Core.UpdateModels;
using SVR.Data.Entitites;
using SVR.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Core.Repository.Interface
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
        Task<BillRelatedDto> GetRelatedData(CancellationToken cancellationToken);
        Task<int> CreateOrUpdate(BillUpdateModel entity, CancellationToken cancellationToken);

        Task<List<BillDto>> GetAll(CancellationToken cancellationToken);

        Task<BillUpdateModel> GetById(int id, CancellationToken cancellationToken);

        Task<IReadOnlyList<BillDto>> GetPagedCollection(
            FilterParameter parameter,
            CancellationToken cancellationToken);

        Task<int> GetTotalRecords(FilterParameter parameter, CancellationToken cancellationToken);

        Task<IEnumerable<BillDto>> GetSyncAll(int skip, int take );

       // Task<int> GetTotalDocumentRecordsAsync(FilterParameter parameter, CancellationToken cancellationToken);
    }
}
