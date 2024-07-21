using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos
{
    internal class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Meneger { get; set; }
        public virtual ICollection<Person> Members { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}