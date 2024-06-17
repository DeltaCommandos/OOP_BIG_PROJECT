using System.ComponentModel.DataAnnotations;
using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.ViewModels
{
	public class UserViewModel : User
	{
        [Required]
        public string Username { get; set; }
        public bool IsPasswordCorrect { get; set; } = true;
		public bool IsUserExisting { get; set; } = true;
		public bool IsPasswordSame { get; set; } = true;
        [Required]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }
		public string Password2 { get; set; }

        public User User { get; set; }
        //public FighterViewModel FighterViewModel { get; set; }
    }
}
