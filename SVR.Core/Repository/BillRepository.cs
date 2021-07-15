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
namespace SVR.Core.Repository
{
           public class BillRepository : GenericRepository<Bill>, IBillRepository
        {
            private readonly IConfigurationProvider _configurationProvider;
            private readonly AppDataDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly DbSet<Bill> _countries;

            public BillRepository(AppDataDbContext dbContext,   IConfigurationProvider configurationProvider, IMapper mapper) : base(dbContext)
            {
                _dbContext = dbContext;
                _countries = dbContext.Set<Bill>();
                _configurationProvider = configurationProvider;
                _mapper = mapper;
            }


            //public async Task<int> PersistWorkflowDraftCurrentInstanceAsync(int id, string instanceId, int status, CancellationToken cancellationToken)
            //{
            //    var ctx = _dbContext.Set<WorkflowDraftCurrentInstance>();
            //    var active = ctx.AsQueryable().AsNoTracking().FirstOrDefault(x => x.BillId == id);
            //    if (active == null)
            //    {
            //        active = new WorkflowDraftCurrentInstance()
            //        {
            //            BillId = id,
            //            InstanceId = instanceId,
            //            Status = status
            //        };
            //    }

            //    await UpdateWorkflowDraftCurrentInstanceAsync(active, _dbContext, status, instanceId, cancellationToken);

            //    return id;
            //}

            //public async Task<LocationRelatedDto> GetCountriesWithAssociatedDataAsync(CancellationToken cancellationToken)
            //{
            //    if (!cancellationToken.IsCancellationRequested)
            //    {
            //        var countries = await _dbContext.Set<Bill>().AsQueryable()
            //            .Where(x => x.Active)
            //            .OrderBy(x => x.Name)
            //            .Select(x => new BillDto()
            //            {
            //                Id = x.Id,
            //                Name = x.Name,
            //                NativeName = x.NativeName,
            //                Alpha2 = x.Alpha2,
            //                Alpha3 = x.Alpha3
            //            })
            //            .ToListAsync(cancellationToken);

            //        var regions = await _dbContext.Set<Region>().AsQueryable()
            //            .Where(x => x.Active)
            //            .OrderBy(x => x.Name)
            //            .Select(x => new RegionDto()
            //            {
            //                Id = x.Id,
            //                Name = x.Name,
            //                SubRegion = x.SubRegion
            //            })
            //            .ToListAsync(cancellationToken);

            //        var regionGroups = await _dbContext.Set<RegionGroup>().AsQueryable()
            //            .Where(x => x.Active)
            //            .OrderBy(x => x.Name)
            //            .Select(x => new RegionGroupDto()
            //            {
            //                Id = x.Id,
            //                Name = x.Name,
            //                Code = x.Code
            //            })
            //            .ToListAsync(cancellationToken);

            //        var languages = await _dbContext.Set<Language>().AsQueryable()
            //            .Where(x => x.Active)
            //            .OrderBy(x => x.Name)
            //            .Select(x => new LanguageDto()
            //            {
            //                Id = x.Id,
            //                Name = x.Name,
            //                Iso1 = x.Iso1,
            //                Iso2 = x.Iso2
            //            })
            //            .ToListAsync(cancellationToken);

            //        var currencies = await _dbContext.Set<Currency>().AsQueryable()
            //            .Where(x => x.Active)
            //            .OrderBy(x => x.Name)
            //            .Select(x => new CurrencyDto()
            //            {
            //                Id = x.Id,
            //                Name = x.Name,
            //                Alpha3 = x.Alpha3,
            //                Symbol = x.Symbol
            //            })
            //            .ToListAsync(cancellationToken);

            //        return new LocationRelatedDto()
            //        {
            //            Countries = countries,
            //            Languages = languages,
            //            Currencies = currencies,
            //            Regions = regions,
            //            RegionGroups = regionGroups
            //        };
            //    }

            //    return null;
            //}

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

            public async Task<int> CreateOrUpdate(Bill_UM entity, CancellationToken cancellationToken)
            {
                var existing = FetchCurrent(entity.ID);
                var changed = _mapper.Map<Bill_UM, Bill>(entity);

                if (!cancellationToken.IsCancellationRequested)
                {
                    #region collections

 
                   // existing.BillItems = _dbContext.Bills.AsQueryable().AsTracking().Where(x => entity.billItems.Select(x => x.ID).AsEnumerable()).ToList();

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

            public async Task<IReadOnlyList<BillDto>> GetAll(CancellationToken cancellationToken)
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

            public async Task<Bill_UM> GetById(int id, CancellationToken cancellationToken)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    return  await _dbContext.Bills.AsQueryable().Where(x => x.ID == id)
                    .ProjectTo<Bill_UM>(_configurationProvider).FirstOrDefaultAsync(cancellationToken);

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
               // var draftIds = _dbContext.WorkflowInstances.UnPublishedDraftsVisible(nameof(Bill_UM), userInfo.BusinesLegalLinkId, userInfo.IsAdministrator);
                return _dbContext.Bills.AsQueryable();
               // (!x.Published && draftIds != null && draftIds.Contains(x.Id)) || x.Published
            }
        }
    }
