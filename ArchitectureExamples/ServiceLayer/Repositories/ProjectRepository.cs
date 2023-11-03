using ExampleDomain.Classes.Entities;

namespace ServiceLayer
{
    public interface IProjectRepository{

        Task<Project> GetProjectById(Guid id);
    }

    public class ProjectRepository : IProjectRepository
    {

        private List<Project> _ProjectList {get;set;} = new();

        public ProjectRepository()
        {
            _ProjectList = new List<Project>();
            _ProjectList.Add(new Project(){
                Id = Guid.Empty,
                Name = "Project 1",
                Description = "Description 1",
            });

            _ProjectList.Add(new Project(){
                Id = Guid.NewGuid(),
                Name = "Project 2",
                Description = "Description 2",
            });
        }

        public async Task<Project> GetProjectById(Guid id) => _ProjectList.FirstOrDefault(p => p.Id == id);
    }
}
