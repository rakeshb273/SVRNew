using SVR.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Core.Repository.Interface
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> GetPagedResponseAsync(PagedParameter paging, CancellationToken cancellationToken);

        Task<int> GetTotalRecords(CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        bool CheckIfNameExists(int id, string name);
    }
}
