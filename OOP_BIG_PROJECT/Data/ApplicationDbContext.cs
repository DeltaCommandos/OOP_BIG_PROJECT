using Microsoft.EntityFrameworkCore;
using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FightClub;Username=postgres;Password=GOOOOOOOOOOOOOOOOOOOL");
            // Федя - postgres
            // Валера - postgres  GOOOOOOOOOOOOOOOOOOOL
            // Андрей - postgres  GOOOOOOOOOOOOOOOOOOOL
        }
    }
}
