using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider userProvider;

        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }
        [HttpPost, Route("UserRegisteration")]
        public async Task<IActionResult> Register(UserModel user)
        {
            UserDomain userDomain = new UserDomain();
            return Ok(await userProvider.UserRegisteration(userDomain));
        }
        [HttpPost, Route("UserLogin")]
        public async Task<IActionResult> Login(UserDomain userDomain)
            => Ok(await userProvider.UserLogin(userDomain));
        [HttpPost, Route("UserUpdate")]
        public async Task<IActionResult> Update(UserDomain userDomain)
            => Ok(await userProvider.UpdateUser(userDomain));
        [HttpPost, Route("UnRegisterUser")]
        public async Task<IActionResult> Delete(UserDomain userDomain)
            => Ok(await userProvider.DeleteUser(userDomain.UserID));
        [HttpPost, Route("GetUser")]
        public async Task<IActionResult> GetUser(UserDomain userDomain)
            => Ok(await userProvider.GetUser(userDomain));
        [HttpGet, Route("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
            => Ok(await userProvider.GetAllUsers());
    }
}
