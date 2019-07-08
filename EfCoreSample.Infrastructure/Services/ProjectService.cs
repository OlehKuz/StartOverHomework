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
        private readonly IRepository<Project, long> _repo;

       
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IRepository<Project, long> repo,  IUnitOfWork unitOfWork)
        {
            _repo = repo;

            
            _unitOfWork = unitOfWork;
        }
        public async Task<long> InsertAsync(Project entity)
        {
            try
            {
                await _repo.InsertAsync(entity);
                await _unitOfWork.CompleteAsync();
                return entity.Id;
            }
            catch { }
            return -1;
        }

        public async Task<Project> FindAsync(long key) 
        {                      
            return await _repo.FindAsync(key);
        }

        public async Task<List<Project>> GetAsync(Expression<Func<Project, bool>> predicate)
        {
            return await _repo.GetAsync(predicate);
        }

        public Task UpdateRange(IEnumerable<ProjectDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProjectDTO entity)
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


        /* public async Task<List<DTO>> GetAsync<DTO>
             (Expression<Func<Project, bool>> predicate) where DTO : class
         {
             var projects = await _db.GetAsync(predicate);
             return _mapper.Map<List<DTO>>(projects);
         }

         public Task<long> InsertAsync<DTO>(SaveProjectDTO item) where DTO : class
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

