using ExampleDomain.Classes.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MinimalApiCRUD.Repos
{
    public class Repo : IRepo
    {
        private readonly Context _context;

        public Repo(Context context)
        {
            _context = context;
        }

        public async Task<bool> Create(Project p)
        {
            _context.Projects.Add(p);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> Delete(Guid id)
        {
            var data = await Get(x => x.Id == id);
            if (data != null)
            {
                _context.Projects.Remove(data);
                return await _context.SaveChangesAsync() == 1;
            }
            return false;
        }

        public async Task<Project> Get(Expression<Func<Project, bool>>? filter)
        {
            return await _context.Projects.SingleOrDefaultAsync(filter);

        }

        public async Task<IEnumerable<Project>> GetAll(Expression<Func<Project, bool>>? filter = null)
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> Update(Project project)
        {
            var data = await Get(x => x.Id == project.Id);

            if (data != null)
            {
                data = project;
                _context.Projects.Update(data);
                var wasSaved = await _context.SaveChangesAsync();
                return wasSaved == 1 ? project : null;
            }
            return null;
        }
    }
}
