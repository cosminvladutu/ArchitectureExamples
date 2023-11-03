namespace Cqrs
{

    public class AssignProjectToPoCommand : ICommand
    {
        public Guid PurchaseOrderId { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class AssignProjectToPoCommandHandler : ICommandHandler<AssignProjectToPoCommand, CommandResult<Unit>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPORepository _poRepository;

        public AssignProjectToPoCommandHandler(IProjectRepository projectRepository, IPORepository poRepository)
        {
            this._projectRepository = projectRepository;
            this._poRepository = poRepository;
        }

        public async Task<CommandResult<Unit>> Handle(AssignProjectToPoCommand command)
        {
            var project = await this._projectRepository.GetProjectById(command.ProjectId);

            if(project == default)
            {
                return CommandResult<Unit>.Failure("No project was found!");
            }

            var po = await this._poRepository.Get(command.PurchaseOrderId);
            
            if(po == default)
            {
                return CommandResult<Unit>.Failure("No purchase order was found!");
            }

            po.SetProjectId(project);

            await this._poRepository.Update(po);

            return CommandResult<Unit>.Success(new Unit());
        }
    }

    public static class StartupExtension
    {
        public static WebApplicationBuilder AddAssingProjectToPOUseCase(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<AssignProjectToPoCommandHandler>();
            return builder;
        }
        
    }
    


}
