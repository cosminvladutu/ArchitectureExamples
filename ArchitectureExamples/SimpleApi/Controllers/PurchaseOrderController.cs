using ExampleDomain.Classes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly Context _context;

        public PurchaseOrderController(Context context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        [HttpGet(Name = "Get")]
        public async Task<PurchaseOrder> Get(Guid id)
        {
            return await _context.PurchaseOrders.SingleOrDefaultAsync(s => s.Id == id);
        }

        [HttpPost(Name = "Create")]
        public async Task<Guid> Create(PurchaseOrder po)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == po.ProjectId);

            if (project == null)
            {
                throw new InvalidOperationException("invalid_project");
            }

            if (project.Owner != Guid.Empty)
            {
                throw new InvalidOperationException("invalid_owner");
            }

            if (po.LineItems == null || !po.LineItems.Any())
            {
                throw new InvalidOperationException("no_lines");
            }

            _context.PurchaseOrders.Add(po);
            if (await _context.SaveChangesAsync() == 1)
            {
                return po.Id;
            }
            throw new Exception("error_on_save");
        }
    }
}
