using SVR.Core.Models;
using SVR.Core.RelatedData;
using SVR.Core.Repository.Interface;
using SVR.Core.Services.Interface;
using SVR.Core.UpdateModels;
using SVR.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVR.Core.Services
{
    public class BillService : BaseService, IBillService
    {
        private readonly IBillRepository _repo;
        public BillService(IBillRepository repo)
        {
            _repo = repo;
        }

        async Task<BillRelatedDto> IBillService.GetRelatedData(CancellationToken cancellationToken)
        {
            return await _repo.GetRelatedData(cancellationToken).ConfigureAwait(false);
        }
        public async Task<Response<int>> CreateorUpdate(BillUpdateModel entity,CancellationToken cancellationToken) 
        { 
            var id = await _repo.CreateOrUpdate(entity, cancellationToken).ConfigureAwait(false);
            return new Response<int>(id);
        }

        public async Task<Response<IEnumerable<BillDto>>> GetAll(CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAll(cancellationToken).ConfigureAwait(false);
            return new Response<IEnumerable<BillDto>>(obj);
        }

        public async Task<Response<BillUpdateModel>> GetById(int id, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetById(id, cancellationToken).ConfigureAwait(false);
            return new Response<BillUpdateModel>(obj);
        }

        public async Task<PagedResponse<IEnumerable<BillDto>>> GetPagedCollection(FilterParameter parameter, CancellationToken cancellationToken)
        {
            var collection = await _repo.GetPagedCollection(parameter, cancellationToken).ConfigureAwait(false);
            return new PagedResponse<IEnumerable<BillDto>>(collection, parameter.Pager);
        }

        public async Task<int> GetTotalRecords(FilterParameter parameter, CancellationToken cancellationToken)
        {
            return await _repo.GetTotalRecords(parameter, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BillDto>> GetSyncAll(int skip = 0, int take = 15)
        {
            return await _repo.GetSyncAll(skip,take).ConfigureAwait(false);
        }

       
    }
}
