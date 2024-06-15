//using Microsoft.CodeAnalysis;
//using Microsoft.EntityFrameworkCore;
//using System.Numerics;

//namespace OOP_BIG_PROJECT.Models
//{
//    public class ApplicationContext: DbContext
//    {
//        public DbSet<Fighter> fighter { get; set; }
//        public DbSet<FreeTime> freetime { get; set; }
//        public DbSet<Judgement> judgement { get; set; }
//        public DbSet<MainDB> maindb { get; set; }
//        public DbSet<Place> place { get; set; }
//        public DbSet<Rules> rules { get; set; }
//        public DbSet<user> user { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FightClub;Username=postgres;Password=admin1488");
//            // Федя -
//            // Валера - postgres  GOOOOOOOOOOOOOOOOOOOL
//            // Андрей - postgres  GOOOOOOOOOOOOOOOOOOOL
//        }

//    }
//}
