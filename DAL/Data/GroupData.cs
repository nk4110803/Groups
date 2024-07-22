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
    public class GroupData : IGroup
    {
        private readonly GroupsContext _context;
        private readonly IMapper _mapper;
        private readonly IPerson _Person;
        //private readonly IEvent _event;

        public GroupData(GroupsContext context, IMapper mapper,IPerson person)
        {
            _context = context;
            _mapper = mapper;
            _Person = person;
           // _event = @event;
        }

        /*public async Task<List<Event>> getAllEvents(int groupId)
        {
            var groupEntity = await _context.Groups.FindAsync(groupId);
            //var @group = _mapper.Map<Group>(groupEntity);
            List<Event> allEvents = (List<Event>)groupEntity.Events;
            return allEvents;
        }*/
        public async Task<bool> createGroup(GroupDto _group)
        {
            _context.Groups.Add(_mapper.Map<Group>(_group));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Group> getGroupById(int id)
        {
            var groupEntity = await _context.Groups.FindAsync(id);
            return groupEntity;
        }

        /*public async Task<bool> AddEventToGroup(int groupId, EventDto newEvent)
        {
            Group @group = await getGroupById(groupId);
            await _event.createEvent(newEvent,@group.Id);
            if (@group == null)
                return false;
            if (@group.Events == null)
                @group.Events = new List<Event>();
            Event @event = _mapper.Map<Event>(newEvent);
            @event.EventGroup = @group;
            @group.Events.Add(@event);
            await _context.SaveChangesAsync();
            return true;
        }*/


        public async Task<bool> AddPersonToGroup(int groupId, int personId)
        {
            Group @group = await getGroupById(groupId);
            Person @person = await _Person.getPersonById(personId);
            if (@group==null||@person==null)
                return false;
            if (@group.Members == null)
                @group.Members = new List<Person>();
            if (@person.Groups == null)
                @person.Groups = new List<Group>();
            @group.Members.Add(@person);
            @person.Groups.Add(@group);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

