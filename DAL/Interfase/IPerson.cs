using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using DAL.Dtos;

namespace DAL.Interface
{
    public interface IPerson
    {
        Task<Person> getPersonById(int id);
        Task<bool> createPerson(PersonDto person);

    }
}

