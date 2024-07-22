using DAL.Dtos;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Groups.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IEvent _dbEvent;
        public EventController(IEvent dbEvent)
        {
            _dbEvent = dbEvent;
        }

        [HttpPost("{groupId}")]
        public async Task<IActionResult> Post([FromBody] EventDto _event, int groupId)
        {
            bool create = await _dbEvent.createEvent(_event, groupId);
            if (create)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            var _event = await _dbEvent.getEventById(id);
            return _event;
        }
    }
}
