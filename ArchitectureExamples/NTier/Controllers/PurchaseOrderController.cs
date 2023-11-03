using ExampleDomain.Classes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IBL _logic;

        public PurchaseOrderController(IBL logic)
        {
            _logic = logic;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            return await _logic.GetAll();
        }

        [HttpGet(Name = "Get")]
        public async Task<PurchaseOrder> Get(Guid id)
        {
            return await _logic.Get(id);
        }

        [HttpPost(Name = "Create")]
        public async Task<Guid> Create(PurchaseOrder po)
        {
            return await _logic.Create(po);
        }
    }
}
