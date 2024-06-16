using OOP_BIG_PROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.ViewModels
{
    public class FighterViewModel:Fighter
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public bool Sex { get; set; } = false;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public int UserId { get; set; }




        public Fighter Fighter { get; set; }

    }
}
