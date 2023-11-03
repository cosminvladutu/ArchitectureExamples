using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    using ExampleDomain.Classes.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase 
    {
        [HttpGet(Name = "Get")]
        public async Task<Project> Get(Guid id)
        {
            return default;
        }
    }
}
