using Microsoft.EntityFrameworkCore;
using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Fighter> Fighter { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Place> Venue { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Tags> Tags { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FightClub1;Username=postgres;Password=admin1488");
            // Федя - admin1488
            // Валера - GOOOOOOOOOOOOOOOOOOOL
            // Андрей - GOOOOOOOOOOOOOOOOOOOL
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.User1)
                .WithMany(u => u.MatchesAsUser1)
                .HasForeignKey(m => m.UserId1)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Match>()
                .HasOne(m => m.User2)
                .WithMany(u => u.MatchesAsUser2)
                .HasForeignKey(m => m.UserId2)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Messages>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.MessageSend)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Messages>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.MessageGot)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
