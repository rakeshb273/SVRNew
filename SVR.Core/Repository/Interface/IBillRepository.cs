using SVR.Core.Models;
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
        Task<int> CreateOrUpdate(Bill_UM entity, CancellationToken cancellationToken);

        Task<List<BillDto>> GetAll(CancellationToken cancellationToken);

        Task<Bill_UM> GetById(int id, CancellationToken cancellationToken);

        Task<IReadOnlyList<BillDto>> GetPagedCollection(
            FilterParameter parameter,
            CancellationToken cancellationToken);

        Task<int> GetTotalRecords(FilterParameter parameter, CancellationToken cancellationToken);
 

       // Task<int> GetTotalDocumentRecordsAsync(FilterParameter parameter, CancellationToken cancellationToken);
    }
}
