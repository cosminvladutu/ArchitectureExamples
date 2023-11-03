namespace Cqrs
{
    using System.Diagnostics;
    using MakePurchaseCommand;

    public interface ICommand : IEvent
    {
        
    }


    public interface IResult  
    {
        
    }

    public interface IEvent
    {
        
    }

    // public class Mediator
    // {
    //     private readonly AssignProjectToPoCommandHandler _assignProjectToPoCommandHandler;
    //     private readonly MakePurchaseOrderHandler _makePurchaseOrderHandler;
    //
    //     public Mediator(AssignProjectToPoCommandHandler assignProjectToPoCommandHandler, MakePurchaseOrderHandler makePurchaseOrderHandler)
    //     {
    //         this._assignProjectToPoCommandHandler = assignProjectToPoCommandHandler;
    //         this._makePurchaseOrderHandler = makePurchaseOrderHandler;
    //
    //     }
    //     
    //     public async Task<CommandResult<IResult>?> Handle(IEvent @event)
    //     {
    //         return @event switch
    //         {
    //             AssignProjectToPoCommand => await this._assignProjectToPoCommandHandler.Handle((AssignProjectToPoCommand) @event),
    //             MakePurchaseOrderCommand => await this._makePurchaseOrderHandler.Handle((MakePurchaseOrderCommand) @event),
    //             _ => null,
    //
    //         };
    //     }
    // }

    public interface ICommandHandler<T, TR> where T : IEvent 
    {
        public Task<TR> Handle(T command);
    }
    
    public class CommandResult<T> where T : IResult
    {
        public bool IsSuccessfull { get; set; }

        public List<string> Errors = new List<string>();

        public T Payload { get; set; } = default;

        public static CommandResult<T> Failure(string s)
            => new CommandResult<T>()
            {
                IsSuccessfull = false,
                Errors = new List<string>()
                {
                    s
                },
                Payload = default
            };
        
        public static CommandResult<T> Failure(List<string> s)
            => new CommandResult<T>()
            {
                IsSuccessfull = false,
                Errors = s,
                Payload = default
            };
        
        public static CommandResult<T> Success(T result)
            => new CommandResult<T>()
            {
                IsSuccessfull = true,
                Payload = result
            };
    }

    public class Unit : IResult
    {
        
    }
    
}
