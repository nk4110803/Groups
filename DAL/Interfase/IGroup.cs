using DAL.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    internal interface IGroup
    {
        Task<List<Event>> getAllEvents(int id);
        Task<bool> createGroup(GroupDto group);
        Task<bool> AddEventToGroup(int groupId, Event newEvent);
        Task<bool> AddPersonToGroup(int groupId, Person newPerson);


    }
}