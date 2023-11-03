using ExampleDomain.Classes.Entities;
using System.Linq.Expressions;

namespace NTier.Abstract
{
    public interface IDAL
    {
        Task<IEnumerable<PurchaseOrder>> GetAllPOs();
        Task<PurchaseOrder> GetPoBy(Expression<Func<PurchaseOrder, bool>>? filter);
        Task<Project> GetProjectBy(Expression<Func<Project, bool>>? filter);
        Task<Guid> SavePo(PurchaseOrder po);
    }
}
