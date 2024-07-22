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

        public async Task<Person> getPersonById(int id)
        {
            var personEntity = await _context.People.FindAsync(id);
            return personEntity;
        }
        public async Task<bool> createPerson(PersonDto _person)
        {
            _context.People.Add(_mapper.Map<Person>(_person));
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

