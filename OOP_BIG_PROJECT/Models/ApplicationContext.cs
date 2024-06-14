using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace OOP_BIG_PROJECT.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FightClub;Username=postgres;Password=GOOOOOOOOOOOOOOOOOOOL");
            // Федя -
            // Валера - postgres  GOOOOOOOOOOOOOOOOOOOL
            // Андрей - postgres  GOOOOOOOOOOOOOOOOOOOL
        }

    }
}
