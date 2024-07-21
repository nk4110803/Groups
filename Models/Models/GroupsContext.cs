using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models.Models
{
    public class GroupsContext : DbContext
    {
        public GroupsContext(DbContextOptions<GroupsContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // קונפיגורציות לפי הצורך
           /* modelBuilder.Entity<Event>()
                .HasOne(e => e.Owner)
                .WithMany(ei=>ei.MyEvents)
                .HasForeignKey(e => e.Owner); // התאמת שדה המפתח הזר

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Meneger)
                .WithMany(gi => gi.MyGroups)
                .HasForeignKey(g => g.Meneger); */// התאמת שדה המפתח הזר

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Events)
                .WithMany(e => e.ConfirmedArrival)
                .UsingEntity(j => j.ToTable("PersonEvent")); // הגדרת טבלת הקשר בין Person ל־Event

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Groups)
                .WithMany(g => g.Members)
                .UsingEntity(j => j.ToTable("PersonGroup")); // הגדרת טבלת הקשר בין Person ל־Group

            base.OnModelCreating(modelBuilder);
        }

    }
}