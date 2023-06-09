using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet(Name = "Users")]
        public async Task<List<User>> Get()
        {
            return await _usersServices.GetUsers();
        }
    }
}