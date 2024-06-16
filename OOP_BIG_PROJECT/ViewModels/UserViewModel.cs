using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.ViewModels
{
	public class UserViewModel : User
	{
		public bool IsPasswordCorrect { get; set; } = true;
		public bool IsUserExisting { get; set; } = true;
		public bool IsPasswordSame { get; set; } = true;
		public string Password1 { get; set; }
		public string Password2 { get; set; }

        public User User { get; set; }

    }
}
