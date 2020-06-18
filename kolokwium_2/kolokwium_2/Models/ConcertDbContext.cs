using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_2.Models
{
    public class ConcertDbContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Artist_Event> Artist_Event { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Event_Organiser> Event_Organiser { get; set; }
        public ConcertDbContext() { }
        public ConcertDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artist_Event>().HasKey(e => new { e.IdArtist, e.IdEvent });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event_Organiser>().HasKey(e => new { e.IdEvent, e.IdOrganiser });
        }
    }
}
