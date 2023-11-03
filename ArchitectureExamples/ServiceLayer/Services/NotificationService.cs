namespace ServiceLayer.Services
{
    using ExampleDomain.Classes.Entities;

    public class NotificationService
    {
        private readonly UserService _userService;

        public NotificationService(UserService userService)
        {
            this._userService = userService;
        }

        public async Task SendUpdateNotification(PurchaseOrder po)
        {
            var email = this._userService.GetUserById(po.AuthorId);
            
            // do some email thingy
            await Task.Delay(2000);
        }
    }
}
