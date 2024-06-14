using OOP_BIG_PROJECT.Models;
namespace OOP_BIG_PROJECT.ViewModels
{
	public class RegisterViewModel : User
	{
		public User username { get; set; }
		public bool IsUserExisting { get; set; }
	}
}
