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
    internal class GroupData : IGroup
    {
        private readonly GroupsContext _context;
        private readonly IMapper _mapper;

        public GroupData(GroupsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Event>> getAllEvents(int groupId)
        {
            var groupEntity = await _context.Groups.FindAsync(groupId);
            //var @group = _mapper.Map<Group>(groupEntity);
            List<Event> allEvents = (List<Event>)groupEntity.Events;
            return allEvents;
        }
        public async Task<bool> createGroup(GroupDto group)
        {
            _context.Groups.Add(_mapper.Map<Group>(group));
            return true;
        }

        public async Task<bool> AddEventToGroup(int groupId, Event newEvent)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group == null)
            {
                return false; // Handle group not found scenario
            }

            group.Events.Add(newEvent);
            await _context.SaveChangesAsync(); // Save changes to the database
            return true;
        }


        public async Task<bool> AddPersonToGroup(int groupId, Person newPerson)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group == null)
            {
                return false;
            }

            group.Members.Add(newPerson);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}

