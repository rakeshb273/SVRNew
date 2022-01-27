using SVR.Core.Models;
using SVR.Core.Repository.Interface;
using SVR.Core.UpdateModels;
using SVR.Data.Entitites;
using SVR.Core.Repository.Interface;
using SVR.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SVR.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using AutoMapper.QueryableExtensions;
using SVR.Core.RelatedData;

namespace SVR.Core.Repository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly AppDataDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbSet<Bill> _countries;

        public BillRepository(AppDataDbContext dbContext, IConfigurationProvider configurationProvider, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _countries = dbContext.Set<Bill>();
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }

        public async Task<BillRelatedDto> GetRelatedData(CancellationToken cancellationToken)
        {
            var customers = await _dbContext.Customers.AsQueryable().Where(x => x.isActive).Include(x=>x.Address).ToListAsync(cancellationToken);

            return await Task.FromResult(
                new BillRelatedDto()
                {
                    customers = customers
                });
        }



        private Bill FetchCurrent(int id)
        {
            if (id > 0)
            {
                return _dbContext.Bills.AsQueryable().AsTracking()
                           .Include(x => x.BillItems)
                          .Single(x => x.ID == id);
            }

            return new Bill();
        }

        public async Task<int> CreateOrUpdate(BillUpdateModel entity, CancellationToken cancellationToken)
        {
            var existing = FetchCurrent(entity.ID);
            var changed = _mapper.Map<BillUpdateModel, Bill>(entity);

            if (!cancellationToken.IsCancellationRequested)
            {
                #region collections


                // existing.BillItems = _dbContext.Bills.AsQueryable().AsTracking().Where(x => entity.billItems.Select(x => x.bill).AsEnumerable()).ToList();

                #endregion collections

                _dbContext.Entry(existing).CurrentValues.SetValues(changed);

                if (entity.ID == 0)
                {
                    _dbContext.Update(existing);
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return existing.ID;
        }

        public async Task<List<BillDto>> GetAll(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                return await GetQueryFiltered()
                    .OrderBy(x => x.CreatedBy)
                    .ProjectTo<BillDto>(_configurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return null;
        }

        public async Task<BillUpdateModel> GetById(int id, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                return await _dbContext.Bills.AsQueryable().Where(x => x.ID == id)
                .ProjectTo<BillUpdateModel>(_configurationProvider).FirstOrDefaultAsync(cancellationToken);

                //if (entity != null)
                //{
                //    return _dbContext.WorkflowInstances.GetActiveDraftWorkflowAsync(id.ToString(), nameof(BillUpdateModel), true, UserId, entity);
                //}
            }

            return null;
        }

        public async Task<IReadOnlyList<BillDto>> GetPagedCollection(
            FilterParameter parameter,
            CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                return await GetQueryFiltered()
                    .Where(ExpressionBuilder(parameter.Filter))
                    .OrderBy(parameter.Pager.OrderBy, parameter.Pager.IsDescending)
                    .Skip((parameter.Pager.PageIndex) * parameter.Pager.PageSize)
                    .Take(parameter.Pager.PageSize)
                    .ProjectTo<BillDto>(_configurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return null;
        }

        public async Task<int> GetTotalRecords(FilterParameter parameter, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                var source = GetQueryFiltered()
                    .Where(ExpressionBuilder(parameter.Filter));

                return await source.CountAsync(cancellationToken).ConfigureAwait(false);
            }

            return 0;
        }

        private IQueryable<Bill> GetQueryFiltered()
        {
            //var userInfo = _userAuthenticator.Get(_userAuthenticator.GetUserName());
            // var draftIds = _dbContext.WorkflowInstances.UnPublishedDraftsVisible(nameof(BillUpdateModel), userInfo.BusinesLegalLinkId, userInfo.IsAdministrator);
            return _dbContext.Bills.AsQueryable();
            // (!x.Published && draftIds != null && draftIds.Contains(x.Id)) || x.Published
        }

        public async Task<IEnumerable<BillDto>> GetSyncAll(int skip, int take)
        {
            //if (!cancellationToken.IsCancellationRequested)
            //{
            return await GetQueryFiltered()
                .OrderBy(x => x.CreatedBy)
                .ProjectTo<BillDto>(_configurationProvider)
                //.ToListAsync(cancellationToken)
                .ToListAsync()
                .ConfigureAwait(false);
            //}

            //return null;
        }
    }
}
