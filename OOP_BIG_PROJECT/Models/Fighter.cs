using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace OOP_BIG_PROJECT.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public bool Sex { get; set; }
        
        public int Age { get; set; }
        public string Skills { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
        //добавить для feature(мастерства) enum перечисление
    }
}