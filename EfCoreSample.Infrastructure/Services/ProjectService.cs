using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Doman.Entities;
using EfCoreSample.Infrastructure.Abstraction;
using AutoMapper;

namespace EfCoreSample.Infrastructure.Services
{
    public class ProjectService : IService<Project,long>
    {
        private readonly IRepository<Project, long> _db;

        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ProjectService(IRepository<Project, long> db, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _db = db;

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        /* public Task<SaveTSourceResponse> SaveAsync<TSource, SaveTSourceResponse>(TSource category)
            where TSource : class
            where SaveTSourceResponse : BaseResponse
         {

         }*/

        public Task<SaveTSourceResponse> SaveAsync<SaveTSourceResponse>(Project category) where SaveTSourceResponse : BaseResponse
        {
            throw new NotImplementedException();
        }

        public Task<TDestination> FindAsync<TDestination>(long key) where TDestination : class
        {
            
            _db.FindAsync(key);
            throw new NotImplementedException();
        }

        public Task<List<TDestination>> GetAsync<TDestination>(Expression<Func<Project, bool>> expression) where TDestination : class
        {
            throw new NotImplementedException();
        }

        public Task<TDestination> InsertAsync<TDestination>(Project entity) where TDestination : class
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange<TDestination>(IEnumerable<TDestination> entities) where TDestination : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update<TDestination>(TDestination entity) where TDestination : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(long key)
        {
            throw new NotImplementedException();
        }

        



        /*   public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
           {
               return await _db.AnyAsync(expression);
           }

           public async Task<int> CreateAsync<TSource, TDestination>(TSource item)
               where TSource : class
               where TDestination : class
           {
               try
               {
                   var entity = _mapper.Map<TDestination>(item);
                   _dbWrite.Add(entity);
                   var success = await _dbWrite.SaveChangesAsync();
                   if (success) return (int)entity.GetType().GetProperty("Id").GetValue(entity);
                   return -1;
               }
               catch { }
               return -1;
           }

           public async Task<bool> DeleteAsync<TSource>(Expression<Func<TSource, bool>> expression) where TSource : class
           {
               try
               {
                   _dbWrite.Delete(expression);
                   return await _dbWrite.SaveChangesAsync();
               }
               catch { }
               return false;
           }

           public async Task<List<TDestination>> GetAsync<TSource, TDestination>(bool include = false)
               where TSource : class
               where TDestination : class
           {
               if (include) _dbRead.Include<TSource>();
               var entities = await _dbRead.GetAsync<TSource>();
               return _mapper.Map<List<TDestination>>(entities);

           }

           public async Task<List<TDestination>> GetAsync<TSource, TDestination>(Expression<Func<TSource, bool>> expression, bool include = false)
               where TSource : class
               where TDestination : class
           {
               if (include) _dbRead.Include<TSource>();
               var entities = await _dbRead.GetAsync(expression);
               return _mapper.Map<List<TDestination>>(entities);
           }*/


        /*    public async Task<TDestination> SingleAsync<TSource, TDestination>(Expression<Func<TSource, bool>> expression, bool include = false)
            where TSource : class
            where TDestination : class
        {
            if (include) _dbRead.Include<TSource>();
            var entity = await _dbRead.SingleAsync(expression);
            return _mapper.Map<TDestination>(entity);
        }

        public async Task<bool> UpdateAsync<TSource, TDestination>(TSource item)
            where TSource : class
            where TDestination : class
        {
            try
            {
                var entity = _mapper.Map<TDestination>(item);
                _dbWrite.Update(entity);
                return await _dbWrite.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

        }*/
    }
}
