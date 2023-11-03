using AutoFixture;
using ExampleDomain.Classes.Entities;
using MinimalApiCRUD.Repos;

namespace MinimalApiCRUD.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepo _repo;

        public ProjectService(IRepo repo)
        {
            _repo = repo;
        }
        public Task ChangeName(Guid id, string name)
        {
            var fixture = new Fixture();

            var project = fixture.Create<Project>();

            project.Id = id;
            project.Name = name;

            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var fixture = new Fixture();

            return fixture.CreateMany<Project>(2);
        }

        public async Task<Project> GetById(Guid id)
        {
            var fixture = new Fixture();

            return fixture.Create<Project>();
        }

        public async Task<Project> Save(Project p)
        {
            _repo.Create(p);
            return p;
        }
    }
}
