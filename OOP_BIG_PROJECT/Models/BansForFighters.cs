using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
    public class BansForFighters
    {
        [Key]
        public int Id { get; set; }
        public int Banner { get; set; }
        public int Banned { get; set; }
    }
}
