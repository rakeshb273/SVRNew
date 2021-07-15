using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class LinqExtension
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(
          this IQueryable<TEntity> source,
          string orderByProperty,
          bool desc)
        {
            if (string.IsNullOrWhiteSpace(orderByProperty))
            {
                return source.Provider.CreateQuery<TEntity>(source.Expression);
            }
            else
            {
                string orderByDirection = desc ? "descending" : "ascending";
                return source.AsQueryable().OrderBy($"{orderByProperty} {orderByDirection}");
            }
        }

        //https://stackoverflow.com/questions/32619338/ef-distinctby-on-an-iqueryable
        public static IQueryable<TSource> DistinctBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
        {
            return source.GroupBy(keySelector).Select(x => x.FirstOrDefault());
        }
    }
}
