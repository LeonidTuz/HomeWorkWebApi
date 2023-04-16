using Microsoft.AspNetCore.Mvc;
using NewHomeWorkWebApi.Data.Models.Users;

namespace NewWebCoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCollectionController : Controller
    {
        public IUserStorage _userStorage;
        private readonly ILogger<ManageUsersController> _logger;
        public UserCollectionController(IUserStorage userStorage, ILogger<ManageUsersController> logger)
        {
            _userStorage = userStorage;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get user collection");
            return Ok(_userStorage.Render().ToString());
        }
    }
}
