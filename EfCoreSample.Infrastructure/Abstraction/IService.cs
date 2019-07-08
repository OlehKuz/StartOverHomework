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
    public interface IService<TSource,TDestination, TKey> where TSource : class where TDestination : class
    {
       
        Task<TDestination> FindAsync(TKey key);

        Task<List<TDestination>> GetAsync (Expression<Func<TSource, bool>> expression);
        Task<TKey> InsertAsync<TSourceSaveDto>(TSourceSaveDto entity) where TSourceSaveDto:class;
           
        Task UpdateRange(IEnumerable<TDestination> entities);
           

        Task<bool> Update(TDestination entity);

        Task<bool> DeleteAsync(TKey key);

        Task<bool> DeleteAsync(TSource entity);
        Task<bool> AnyAsync(TKey key);
    }
}
