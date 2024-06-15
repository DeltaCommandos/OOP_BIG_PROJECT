using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.Controllers
{
    public class UserController: Controller
	{
		private readonly ApplicationContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public UserController(ApplicationContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// Метод для просмотра профилей других пользователей
		//public async Task<IActionResult> Browse()
		//{
		//	var users = await _context.Users.ToListAsync();
		//	return View(users);
		//}

		// Метод для отправки лайка/дизлайка
		//[HttpPost]
		//public async Task<IActionResult> LikeDislike(int userId, bool isLike)
		//{
		//	var currentUser = await _userManager.GetUserAsync(User);
		//	var likedUser = await _context.Users.FindAsync(userId);

		//	if (isLike)
		//	{
		//		// Логика для лайка
		//	}
		//	else
		//	{
		//		// Логика для дизлайка
		//	}

		//	return RedirectToAction(nameof(Browse));
		//}
	}
}
