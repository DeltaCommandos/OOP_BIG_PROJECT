using System.ComponentModel.DataAnnotations;
using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.ViewModels
{
    public class RegisterViewModel:User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsUserExisting { get; set; }
        public User User { get; set; }
        public User Fighter { get; set; }
        public  int ? FighterId { get; set; }
        public int Rating { get; set; }
        public bool Sex { get; set; } = false;
        public int? Age { get; set; }
        public string? Skills { get; set; }
        public int UserId { get; set; }

    }

}
