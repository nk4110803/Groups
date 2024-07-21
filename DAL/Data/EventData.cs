using AutoMapper;
using DAL.Dtos;
using DAL.Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class EventData : IEvent
    {
        private readonly GroupsContext _context;
        private readonly IMapper _mapper;
        public EventData(GroupsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Event> getEventById(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            return eventEntity;
            //var @event = _mapper.Map<Event>(eventEntity);
            //return @event;
        }

        public async Task<bool> createEvent(EventDto _event)
        {
            _context.Events.Add(_mapper.Map<Event>(_event));
            return true;
        }


    }
}

