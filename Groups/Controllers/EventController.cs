using DAL.Dtos;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventDto _event)
        {
            bool create = await _dbEvent.createEvent(_event);
            if (create)
                return Ok();
            return BadRequest();

        }
    }
}
