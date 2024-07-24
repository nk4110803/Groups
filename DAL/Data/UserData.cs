using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using AutoMapper;
using DAL.Dtos;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class UserData : IUser
    {
        private readonly GroupsContext _context;
        private readonly IMapper _mapper;
        public UserData(GroupsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> getUserById(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            return userEntity;
        }
        public async Task<bool> createUser(UserDto _user)
        {
            _context.Users.Add(_mapper.Map<User>(_user));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> addEvent(int userId, int eventId)
        {
            User @user = await getUserById(userId);
            Event @event = await _context.Events.FindAsync(eventId);
            if (@user == null||@event==null)
                    return false;
            if(@user.Events==null)
                @user.Events=new List<Event>();
            @user.Events.Add(@event);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<UserDto>> getAllUsers(int groupId)
        {
            var userEntity = await _context.Groups
                .Include(g => g.Members)
                .FirstOrDefaultAsync(g => g.Id == groupId);

            if (userEntity == null)
            {
                throw new ArgumentException($"No group found with ID {groupId}", nameof(groupId));
            }
            var userDtos = userEntity.Members.Select(e => _mapper.Map<UserDto>(e)).ToList();
            return userDtos;
        }
        public async Task<List<EventDto>> getAllEvents(int userId)
        {
            var userEntity = await _context.Groups
                .Include(p => p.Events)
                .FirstOrDefaultAsync(p => p.Id == userId);

            if (userEntity == null)
            {
                throw new ArgumentException($"No group found with ID {userId}", nameof(userId));
            }
            var eventDtos = userEntity.Events.Select(e => _mapper.Map<EventDto>(e)).ToList();
            return eventDtos;
        }

        public async Task<UserDto>getUserByEmail(string Email)
        {
            var mailFind = _context.Users.FirstOrDefault(b => b.Email == Email);
            var afterMapper = _mapper.Map<UserDto>(mailFind);
            return afterMapper;
        }
    }
}

