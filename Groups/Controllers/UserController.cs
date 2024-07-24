using DAL.Dtos;
using DAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Groups.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUser _dbUser;
        public UserController(IUser _user)
        {
            _dbUser = _user;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto _user)
        {
            bool create = await _dbUser.createUser(_user);
            if (create)
                return Ok();
            return BadRequest();
        }


        [HttpGet("{userId}")]
        public async Task<User> Get(int userId)
        {
            var @user = await _dbUser.getUserById(userId);
            return @user;
        }
        [HttpPut("{userId},{eventId}")]
        public async Task<IActionResult> Put(int userId,int eventId)
        {
            bool ans=await _dbUser.addEvent(userId, eventId);
            if (ans)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{groupId},{one}")]
        public async Task<List<UserDto>> Get(int groupId,int one)
        {
            var users = await _dbUser.getAllUsers(groupId);
            return users;
        }
        /*[HttpGet("{personId}")]
        public async Task<List<EventDto>> Get(string zero,int personId)
        {
            var _events = await _dbPerson.getAllEvents(personId);
            return _events;
        }*/
        [HttpGet("GetUserByEmail/{Email}")]
        public IActionResult Get(string Email)
        {
            var user = _dbUser.getUserByEmail(Email);
            if (user.Result == null)
                return NotFound();
            return Ok(user.Result);
        }


    }
}
