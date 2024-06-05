using OOP_BIG_PROJECT.Models;
namespace OOP_BIG_PROJECT.ViewModels
{
	public class RegisterViewModel : Judgement
	{
		public user username { get; set; }
		public bool IsUserExisting { get; set; }
	}
}
