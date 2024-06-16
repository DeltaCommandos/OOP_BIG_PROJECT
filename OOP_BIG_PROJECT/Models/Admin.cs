using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        // public int Rating { get; set; }

    }
}
