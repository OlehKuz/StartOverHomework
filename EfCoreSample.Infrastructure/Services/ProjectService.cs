using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Doman.Entities;
using EfCoreSample.Infrastructure.Abstraction;
using AutoMapper;
using EfCoreSample.Doman.DTO;

namespace EfCoreSample.Infrastructure.Services
{
    public class ProjectService : IService<Project,ProjectDTO,long>
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

         }

        public Task<SaveTSourceResponse> SaveAsync<SaveTSourceResponse>(DTO category)
            where SaveTSourceResponse : BaseResponse where DTO : class
        {
            throw new NotImplementedException();
        }*/

        public async Task<ProjectDTO> FindAsync(long key) 
        {           
            var project = await _db.FindAsync(key);
            return _mapper.Map<ProjectDTO>(project);
        }

       /* public async Task<List<DTO>> GetAsync<DTO>
            (Expression<Func<Project, bool>> predicate) where DTO : class
        {
            var projects = await _db.GetAsync(predicate);
            return _mapper.Map<List<DTO>>(projects);
        }

        public Task<long> InsertAsync<DTO>(DTO item) where DTO : class
        {
            var entity = _mapper.Map<Project>(item);
            try
            {
                var added = _db.InsertAsync(entity);
                var success = await _dbWrite.SaveChangesAsync();
                if (success) return added.Id;
                return -1;
            }
            catch { }
            return -1;
            
            
        }

        public Task UpdateRange<DTO>(IEnumerable<DTO> entities) where DTO : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update<DTO>(DTO entity) where DTO : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(long key)
        {
            
            try
            {
                var removed = _db.Remove(key);
                if (!removed) return false;
                //TODO assuming savechanges returns bool
                return await _db.SaveChangesAsync();
            }
            catch { }
            return false;
        }

        public async Task<bool> DeleteAsync<DTO>(DTO item) where DTO : class
        {
            var entity = _mapper.Map<Project>(item);
            
            try
            {
                var removed = _db.Remove(entity);
                if (!removed) return false;
                //TODO assuming savechanges returns bool
                return await _db.SaveChangesAsync();
            }
            catch { }
            return false;
        }

        public async Task<bool> AnyAsync(long key)
        {
            return await _db.IsExistAsync(key);
        }*/
    }
}

