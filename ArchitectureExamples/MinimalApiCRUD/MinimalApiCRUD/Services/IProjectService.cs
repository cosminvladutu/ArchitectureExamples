using ExampleDomain.Classes.Entities;

namespace MinimalApiCRUD.Services
{
    public interface IProjectService
    {
        Task ChangeName(Guid id, string name);
        Task Delete(Guid id);
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetById(Guid id);
        Task<Project> Save(Project p);
    }
}
