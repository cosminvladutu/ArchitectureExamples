using ExampleDomain.Classes.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using System.Xml.Linq;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly PurchaseOrderService purchaseOrderService;
        private readonly NotificationService notificationService;

        public PurchaseOrderController(PurchaseOrderService purchaseOrderService, NotificationService notificationService)
        {
            this.purchaseOrderService = purchaseOrderService;
            this.notificationService = notificationService;
        }

        [HttpGet(Name = "Get")]
        public async Task<PurchaseOrder> Get(Guid id)
        {
            return await this.purchaseOrderService.Get(id);
        }

        [HttpPost(Name = "Approve")]
        public async Task<bool> Approve(Guid poId)
        {
            try
            {
                var po = await this.purchaseOrderService.Get(poId);
                await this.purchaseOrderService.Approve(po);
                await this.notificationService.SendUpdateNotification(po);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Something bad is going on.");
            }
        }
    }
}
