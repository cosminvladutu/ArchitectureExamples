using ExampleDomain.Classes.Entities;
using Microsoft.EntityFrameworkCore;
using NTier.Abstract;
using System.Linq.Expressions;

namespace NTier.DAL
{
    public class DAL : IDAL
    {
        private readonly Context _context;

        public DAL(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PurchaseOrder>> GetAllPOs()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        public async Task<PurchaseOrder> GetPoBy(Expression<Func<PurchaseOrder, bool>>? filter)
        {
            return await _context.PurchaseOrders.SingleOrDefaultAsync(filter);
        }

        public async Task<Project> GetProjectBy(Expression<Func<Project, bool>>? filter)
        {
            return await _context.Projects.SingleOrDefaultAsync(filter);
        }

        public async Task<Guid> SavePo(PurchaseOrder po)
        {
            _context.PurchaseOrders.Add(po);
            if (await _context.SaveChangesAsync() == 1)
            {
                return po.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
