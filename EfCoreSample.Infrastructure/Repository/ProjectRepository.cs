using EfCoreSample.Doman.Entities;
using EfCoreSample.Infrastructure.Abstraction;
using EfCoreSample.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.Infrastructure.Repository
{
    public class ProjectRepository : IRepository<Project, long>
    {
        private readonly EfCoreSampleDbContext _context;

        public ProjectRepository(EfCoreSampleDbContext context)
        {
            _context = context;
        }
        public async Task<Project> FindAsync(long key)
        {
            var project = await _context.Projects.FindAsync(key);
            if (project != null)
            {
                await _context.Entry(project)
                    .Collection(p => p.EmployeeProjects).LoadAsync();                
            }
            return project;
        }

        public async Task<IEnumerable<Project>> GetAsync(Expression<Func<Project, bool>> expression)
        {
            return await _context.Projects.Where(expression).ToListAsync();
        }

        public async Task<Project> InsertAsync(Project item)
        {
            await _context.Projects.AddAsync(item);
            return item;

        }

        public async Task<bool> IsExistAsync(long key)
        {
            return await _context.Projects.AnyAsync(p=>p.Id.Equals(key));
        }

        public void UpdateRange(IEnumerable<Project> items)
        {
            foreach (var item in items) Update(item);
        }

        public Project Update(Project item)
        {
            var entity = _context.Find<Project>();
            if (entity != null) _context.Entry(entity).State =
                        EntityState.Detached;
            _context.Projects.Update(item);
            return item;
        }

        public bool Remove(Project item)
        {
            var exists = IsExistAsync(item.Id);
            if (exists == null) return false;          
            _context.Projects.Remove(item);           
            return true;            
        }

        public bool Remove(long key)
        {
            var exists = IsExistAsync(key);
            if (exists == null) return false;
            var entity = _context.Projects.Find(key);
            _context.Projects.Remove(entity);
            return true;
        }

        
    }
}
