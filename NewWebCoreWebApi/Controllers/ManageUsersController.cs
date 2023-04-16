using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewHomeWorkWebApi.Data.Models.Users;

namespace NewWebCoreWebApi.Controllers
{
    [ApiController]
    [Route("/user/[controller]")]
    public class ManageUsersController : Controller
    {

        public IUserStorage _userStorage;
        private readonly ILogger<ManageUsersController> _logger;
        public ManageUsersController(IUserStorage userStorage, ILogger<ManageUsersController> logger)
        {
            _userStorage = userStorage;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Get user id {id}");
            return Ok(_userStorage.UserGet(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _userStorage.Add(user);
            _logger.LogInformation($"Post user: {user}");
            return Ok($"new id {user.Id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userStorage.Remove(id);
            _logger.LogInformation($"{id} deleted");
            return Ok();
        }
    }
}
