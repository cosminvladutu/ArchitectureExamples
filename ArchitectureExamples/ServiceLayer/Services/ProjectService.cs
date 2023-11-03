namespace ServiceLayer.Services
{
    using ExampleDomain.Classes.Entities;

    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectService(ProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
       
        
    }
}
