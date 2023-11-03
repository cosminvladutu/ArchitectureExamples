namespace Cqrs
{
    using ExampleDomain.Classes.Entities;

    public interface IPORepository
    {
        Task<PurchaseOrder> Get(Guid id);

        Task<IList<PurchaseOrder>> Get(Func<PurchaseOrder, bool>? filter);

        Task Delete(Guid id);

        Task Update(PurchaseOrder project);
    }
    
    public class PORepository : IPORepository
    {
        private List<PurchaseOrder> _db = new List<PurchaseOrder>();

        public PORepository()
        {
            this._db.Add(new PurchaseOrder()
            {
                Id = Guid.Empty,
                Description = "Bla bla bla",
                
            });
            
            this._db.Add(new PurchaseOrder()
            {
                Id = Guid.NewGuid(),
                Description = "PO 2",
            });
        }

        public async Task<PurchaseOrder> Get(Guid id) => this._db.Where(p => p.Id == id).FirstOrDefault();

        public async Task<IList<PurchaseOrder>> Get(Func<PurchaseOrder, bool>? filter)
        {
            return this._db.Where(filter).ToList();
        }

        public async Task Delete(Guid id)
        {
            var item = this._db.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                throw new NullReferenceException();
            }

            this._db.Remove(item);
        }

        public async Task Update(PurchaseOrder project)
        {
            var itemToReplace = this._db.FirstOrDefault(p => p.Id == project.Id);
            
            if (itemToReplace == null)
            {
                throw new NullReferenceException();
            }

            itemToReplace = project;
        }
    }
}
