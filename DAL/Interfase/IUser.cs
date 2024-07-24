using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using DAL.Dtos;

namespace DAL.Interface
{
    public interface IUser
    {
        Task<User> getUserById(int id);
        Task<bool> createUser(UserDto user);
        Task<bool> addEvent(int userId, int eventId);
        Task<List<UserDto>> getAllUsers(int groupId);
        Task<List<EventDto>> getAllEvents(int userId);
        Task<UserDto> getUserByEmail(string Email);

    }
}

