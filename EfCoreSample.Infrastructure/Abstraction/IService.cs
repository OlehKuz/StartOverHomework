using EfCoreSample.Doman.DTO;
using EfCoreSample.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Doman.Abstraction;

namespace EfCoreSample.Infrastructure.Abstraction
{
    public interface IService<TKey>
    {

        Task<TDestination> FindAsync<TSource, TDestination>(TKey key) 
        where TSource : class where TDestination : class ;

        Task<List<TDestination>> GetAsync<TSource, TDestination>
            (Expression<Func<TSource, bool>> expression)
        where TSource : class where TDestination : class;
        Task<TDestination> InsertAsync<TSource, TDestination>(TSource entity)
        where TSource : class where TDestination : class;

        Task UpdateRange<TSource>(IEnumerable<TSource> entities)
             where TSource : class;

        Task<bool> Update<TSource, TDestination>(TSource entity)
            where TSource : class where TDestination : class;

        Task<bool> DeleteAsync<TSource>(TKey key) where TSource : class;

        Task<bool> DeleteAsync<TSource>(TSource entity) where TSource : class;
        Task<bool> AnyAsync<TSource>(TKey key) where TSource : class;
    }
}
