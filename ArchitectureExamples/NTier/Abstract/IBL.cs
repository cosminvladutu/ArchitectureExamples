using ExampleDomain.Classes.Entities;

namespace NTier
{
    public interface IBL
    {
        Task<IEnumerable<PurchaseOrder>> GetAll();
        Task<PurchaseOrder> Get(Guid id);
        Task<Guid> Create(PurchaseOrder po);
    }
}
