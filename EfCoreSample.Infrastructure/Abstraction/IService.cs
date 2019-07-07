using EfCoreSample.Doman.DTO;
using EfCoreSample.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Doman.Abstraction;
using EfCoreSample.Infrastructure.Services;

namespace EfCoreSample.Infrastructure.Abstraction
{
    public interface IService<TSource,TKey> where TSource : class
    {
        Task<SaveTSourceResponse> SaveAsync<SaveTSourceResponse>(TSource category)
            where SaveTSourceResponse : BaseResponse;

        Task<TDestination> FindAsync<TDestination>(TKey key) 
             where TDestination : class ;

        Task<List<TDestination>> GetAsync<TDestination>
            (Expression<Func<TSource, bool>> expression) where TDestination : class;
        Task<TDestination> InsertAsync<TDestination>(TSource entity)
             where TDestination : class;

        Task UpdateRange<TDestination>(IEnumerable<TDestination> entities)
             where TDestination : class;

        Task<bool> Update<TDestination>(TDestination entity)
            where TDestination : class;

        Task<bool> DeleteAsync(TKey key);

        Task<bool> DeleteAsync(TSource entity);
        Task<bool> AnyAsync(TKey key);
        
    }
}
