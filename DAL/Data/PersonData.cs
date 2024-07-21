using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using AutoMapper;
using DAL.Dtos;
using DAL.Interface;

namespace DAL.Data
{
    public class PersonData : IPerson
    {
        private readonly GroupsContext _context;
        private readonly IMapper _mapper;
        public PersonData(GroupsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /*public async Task<Person> getPersonById(int id)
        {
            var personEntity = await _context.Persons.FindAsync(id);
            return personEntity;
            //var @event = _mapper.Map<Event>(eventEntity);
            //return @event;
        }*/
        /*public async Task<bool> createPerson(PersonDto person)
        {
            _context.Persons.Add(_mapper.Map<Person>(person));
            return true;
        }*/

    }
}

