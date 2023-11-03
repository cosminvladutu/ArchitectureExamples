using ExampleDomain.Classes.Entities;

namespace ServiceLayer.Services
{
    public class PurchaseOrderService
    {
        private readonly IPORepository poRepository;

        public PurchaseOrderService(IPORepository poRepository)
        {
            this.poRepository = poRepository;
        }
        public PurchaseOrder Create(Guid AuthorId, string description)
        {
            PurchaseOrder po = new PurchaseOrder()
            {
                AuthorId = AuthorId,
                Description = description
            };

            this.poRepository.Add(po);

            return po;
        }

        public async Task<PurchaseOrder> Get(Guid id)
        {
            return await this.poRepository.Get(id);
        }

        public async Task Approve(PurchaseOrder po)
        {
           po.Status=Status.Approved;
           await this.poRepository.Update(po);
        }
    }
}
