namespace ServiceLayer.Services
{
    using ExampleDomain.Classes.Entities;

    public class UserService
    {
        public async Task<User> GetUserById(Guid id)
        {
            return new User()
            {
                FirstName = "Gigi",
                LastName = "Kent",
                PrimaryEmail = "gigi.kent@yahoo.co.uk",
            };

        }
    }
}
