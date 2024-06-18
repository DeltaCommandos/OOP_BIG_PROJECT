using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using OOP_BIG_PROJECT.ViewModels;

namespace OOP_BIG_PROJECT.Models
{
    public class Likes
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public bool Like1 { get; set; }
        public bool Like2 { get; set; }
    }
}
