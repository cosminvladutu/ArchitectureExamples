namespace ExampleDomain.Classes.Entities
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }

        public Status Status { get; set; }

        public List<PurchaseOrderItems> LineItems { get; set; } = new();
        
        public bool OnBehalfOfCustomer { get; set; }

        public void SetProjectId(Project project)
        {
            this.ProjectId = project.Id;
        }
    }

    public enum Status
    {
        Draft,
        Pending,
        Approved,
        Rejected,
    }

    public class PurchaseOrderItems
    {
        public Guid Id { get; set; } 
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public int Amount { get; set; }
        
        
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        
        public string SecondaryEmail { get; set; }
    }
    

    public enum Currency
    {
        EUR = 0,
        USD = 1, 
        RON = 2
    }
}
