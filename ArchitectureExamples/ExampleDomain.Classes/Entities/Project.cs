namespace ExampleDomain.Classes.Entities
{
    public class Project 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Client { get; set; }
        public string Description { get; set; }
        
        public Guid Owner { get; set; }
        public IList<Guid> Approvers { get; set; } = new List<Guid>();
        public IList<Guid> Members { get; set; } = new List<Guid>();
    }
}
