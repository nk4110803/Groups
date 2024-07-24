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
    public class GroupController : Controller
    {
        private readonly IGroup _dbGroup;
        public GroupController(IGroup group)
        {
            _dbGroup = group;
        }

        [HttpPost("{managerId}")]
        public async Task<IActionResult> Post([FromBody] GroupDto _group, int managerId)
        {
            bool create = await _dbGroup.createGroup(_group, managerId);
            if (create)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{groupId}")]
        public async Task<Group> Get(int groupId)
        {
            var group = await _dbGroup.getGroupById(groupId);
            return group;
        }


        [HttpPut("{groupId},{userId}")]
        public async Task<IActionResult> Put(int groupId, int userId)
        {
            bool put = await _dbGroup.AddUserToGroup(groupId, userId);
            if (put)
                return Ok();
            return BadRequest();
        }
        [HttpPut("{groupId}")]
        public async Task<IActionResult> Put(int groupId, [FromBody] EventDto newEvent)
        {
            bool put = await _dbGroup.AddEventToGroup(groupId, newEvent);
            if (put)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{groupId},{zero}")]
        public async Task<List<EventDto>> Get(int groupId,int zero)
        {
            var _events = await _dbGroup.getAllEvents(groupId);
            return _events;
        }
        


    }
}