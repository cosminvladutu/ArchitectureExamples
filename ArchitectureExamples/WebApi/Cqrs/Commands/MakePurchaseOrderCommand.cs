
namespace Cqrs.MakePurchaseCommand
{
    public class MakePurchaseOrderCommand : ICommand    
    {
        public Guid AuthorId { get; set; }
    }

    public class MakePurchaseOrderResponse : IResult
    {
        public Guid PurchaseOrderId {get; set;}
    }

    public class MakePurchaseOrderHandler : ICommandHandler<MakePurchaseOrderCommand, CommandResult<MakePurchaseOrderResponse>> 
    {
        public async Task<CommandResult<MakePurchaseOrderResponse>> Handle(MakePurchaseOrderCommand command)
        {
            return new CommandResult<MakePurchaseOrderResponse>();
        }
    }
}
