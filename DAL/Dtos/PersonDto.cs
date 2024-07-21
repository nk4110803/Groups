using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
namespace DAL.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        // public virtual ICollection<Event> MyEvents { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        //public virtual ICollection<Group> MyGroups { get; set; }
        public string ProfilePicture { get; set; }

    }
}
