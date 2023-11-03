using ExampleDomain.Classes.Entities;
using System.Linq.Expressions;

namespace MinimalApiCRUD.Repos
{
    public interface IRepo
    {
        Task<bool> Create(Project p);
        Task<Project> Get(Expression<Func<Project, bool>>? filter);
        Task<IEnumerable<Project>> GetAll(Expression<Func<Project, bool>>? filter = null);
        Task<Project> Update(Project project);
        Task<bool> Delete(Guid id);
    }
}
