using DAL.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IGroup
    {
        //Task<List<Event>> getAllEvents(int id);
        Task<bool> createGroup(GroupDto group);
        Task<Group> getGroupById(int id);
       // Task<bool> AddEventToGroup(int groupId, EventDto newEvent);
        Task<bool> AddPersonToGroup(int groupId, int personId);


    }
}