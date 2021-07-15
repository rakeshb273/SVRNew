using Microsoft.EntityFrameworkCore;
using SVR.Core.Repository.Interface;
using SVR.Data;
using SVR.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
  

namespace SVR.Core.Repository
{
   public class GenericRepository<T>: IGenericRepository<T> where T:class
    {
        private readonly AppDataDbContext _dbContext; 
        //public UserInfoDto UserInfo { get; private set; }

        //public int UserId => UserInfo?.Id ?? 0;

        public GenericRepository(AppDataDbContext dbContext )
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.Clear(); 
           /// UserInfo = _userAuthenticator.Get(_userAuthenticator.GetUserName());
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                await _dbContext.Set<T>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public string ExpressionBuilder(List<object> filter)
        {
            //var workflowDraftExpressionAssist = $"{nameof(Client.WorkflowDraftCurrentInstance)}.{nameof(Client.WorkflowDraftCurrentInstance.Status)} == {Convert.ToInt32(DraftStatus.Authorized)}";
            //convert to json and back again!
            string jsonFilter = System.Text.Json.JsonSerializer.Serialize<List<object>>(filter);
            filter = System.Text.Json.JsonSerializer.Deserialize<List<object>>(jsonFilter);

            StringBuilder sb = new StringBuilder();
            if (filter != null && filter.Any())
            {
                foreach (object opt in filter)
                {
                    System.Text.Json.JsonElement json = ((System.Text.Json.JsonElement)opt);
                    if (json.ValueKind.ToString() == "String" || json.ValueKind.ToString() == "Number")
                    {
                        sb.Append($"{opt} ");
                    }
                    else if (json.ValueKind.ToString() == "Array")
                    {
                        System.Text.Json.JsonElement arr = ((System.Text.Json.JsonElement)opt);
                        if (arr.GetArrayLength() > 0)
                        {
                            var exp = $"{(ParseExpression(arr[0].ToString(), arr[1].ToString(), arr[2].ToString()))}";
                            //if (exp.Equals(workflowDraftExpressionAssist, System.StringComparison.OrdinalIgnoreCase))
                            //{
                            //    sb.Append($"{nameof(Client.WorkflowDraftCurrentInstance)} == null or ");
                            //}
                            sb.Append(" " + exp + " ");
                        }
                    }
                }
            }
            else
            {
                sb.Append("0 = 0");
            }

            return sb.ToString();
        }

        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(PagedParameter paging,
                                                                  CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                IQueryable<T> source = _dbContext.Set<T>().AsQueryable<T>().AsNoTracking();
                return await source
                    .OrderBy(paging.OrderBy, paging.IsDescending)
                    .Skip((paging.PageIndex) * paging.PageSize)
                    .Take(paging.PageSize)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return null;
        }

        public async Task<int> GetTotalRecords(CancellationToken cancellationToken)
        {
            IQueryable<T> source = _dbContext.Set<T>().AsQueryable<T>().AsNoTracking();
            return await source.CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public bool CheckIfNameExists(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return _dbContext.Set<T>().AsQueryable<T>().Any(p => EF.Property<string>(p, "Name").ToLower() == name.ToLower() && (EF.Property<int>(p, "Id") != id));
        }

        public string ParseExpression(string name, string clause, string value)
        {
            clause = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(clause.ToLower());
            if (clause == "=")
            {
                return $"{name} == {value}";
            }
            return $"{name}.ToLower().{clause}(\"{value.ToLower().Trim()}\")";
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
 
    }
}
