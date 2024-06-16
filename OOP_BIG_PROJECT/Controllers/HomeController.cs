using Microsoft.AspNetCore.Mvc;
using OOP_BIG_PROJECT.Models;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using OOP_BIG_PROJECT.ViewModels;
using OOP_BIG_PROJECT.Data;
namespace OOP_BIG_PROJECT.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		//private readonly ILogger<HomeController> _logger;

		public HomeController(ApplicationDbContext context)
		{
			//_logger = logger;
			_context = context;
		}
        [HttpGet]
        public IActionResult Index()
        {
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
		public IActionResult Login()
		{
			var response = new UserViewModel();
			return View(response);
		}

		public IActionResult Privacy()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(UserViewModel A)
		{
			List<User> accounts = _context.User.Where<User>(a => a.Username == A.Username).ToList();
			if (accounts.Count != 0)
			{
				if (A.Password1 == accounts[0].Password)
				{
					StaticStuff.Status = accounts[0].Status;
					if (!accounts[0].Status)
					{
                        var admin = _context.Admin.FirstOrDefault(d => d.UserId == accounts[0].Id);
                        if (admin != null)
                        {
                            StaticStuff.Admin = admin;
                            return RedirectToAction("Index", "Account");
                        }
                        else
                        {
                            return View(A);
                        }
                    }
					else
					{
						StaticStuff.Fighter = _context.Fighter.Where<Fighter>(p => p.UserId == accounts[0].Id).ToList()[0];
						return RedirectToAction("Index", "Account");
					}
				}
				else
				{
					A.IsPasswordCorrect = false;
				}
			}
			else
			{
				A.IsUserExisting = false;
			}
			return View(A);
		}
		[HttpGet]
		public IActionResult Register()
		{
			var response = new RegisterViewModel();
			return View(response);
		}
		[HttpPost]
        public IActionResult Register(RegisterViewModel A)
        {
            // Проверяем, существует ли пользователь с таким именем
            List<User> accounts = _context.User.Where<User>(a => a.Username == A.Username).ToList();
			if (accounts.Count != 0)
			{
				A.IsUserExisting = true;
				return View(A); // Возвращаем представление с сообщением об ошибке
			}
			else
			{


                // Создаем нового пользователя
                _context.User.Add(new User { Username = A.Username, Password = A.Password, Status = true });
				//
				//A.userViewModel.Password1 = A.Password;
                // Добавляем пользователя в контекст и сохраняем изменения
                _context.SaveChanges();

                // Создаем бойца, связанный с новым пользователем
                User User = _context.User.Where<User>(a => a.Username == A.Username).ToList()[0];
                _context.Fighter.Add(new Fighter
                {
                    UserId = User.Id,
                    Name = A.Username
                });

                // Добавляем бойца в контекст и сохраняем изменения
				_context.SaveChanges();

                return RedirectToAction("Index", "Account"); // Перенаправляем на главную страницу или другую страницу по вашему выбору
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}

//	public class HomeController : Controller
//	{
//		// Действие для домашней страницы
//		public IActionResult Index()
//		{
//			return View();
//		}

//		// Действие для страницы конфиденциальности
//		public IActionResult Privacy()
//		{
//			return View();
//		}

//		// Действие для обработки ошибок
//		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//		public IActionResult Error()
//		{
//			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//		}
//	}
//}
