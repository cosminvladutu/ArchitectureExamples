using ExampleDomain.Classes.Entities;
using NTier.Abstract;

namespace NTier.DAL
{
    public class BL : IBL
    {
        private readonly IDAL _dal;

        public BL(IDAL dal)
        {
            _dal = dal;
        }
        public async Task<Guid> Create(PurchaseOrder po)
        {
            var project = await _dal.GetProjectBy(p => p.Id == po.ProjectId);

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

            var poId = await _dal.SavePo(po);

            if (poId == Guid.Empty)
            {
                throw new Exception("error_on_save");
            }
            return poId;
        }

        public async Task<PurchaseOrder> Get(Guid id)
        {
            return await _dal.GetPoBy(s => s.Id == id);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            return await _dal.GetAllPOs();
        }
    }
}
