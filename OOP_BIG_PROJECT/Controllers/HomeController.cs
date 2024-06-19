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
                        //
                        // �������� ������� ������������� ����
                        //RegisterViewModel fighterViewModel = new RegisterViewModel();
                        //fighterViewModel.Name = StaticStuff.Fighter.Name;
                        //
                        //TempData["FighterId"] = StaticStuff.Fighter.Id;
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
            // ���������, ���������� �� ������������ � ����� ������
            List<User> accounts = _context.User.Where<User>(a => a.Username == A.Username).ToList();
			if (accounts.Count != 0)
			{
				A.IsUserExisting = true;
				return View(A); // ���������� ������������� � ���������� �� ������
			}
			else
			{


                // ������� ������ ������������
                _context.User.Add(new User { Username = A.Username, Password = A.Password, Status = true });
				if (A.Username == null && A.Password == null)
				{
					return View(A);
					//������� ��������� �� ������ 
				}
				else
				{
				


					//A.userViewModel.Password1 = A.Password;
					// ��������� ������������ � �������� � ��������� ���������

					_context.SaveChanges();

					// ������� �����, ��������� � ����� �������������
					User User = _context.User.Where<User>(a => a.Username == A.Username).ToList()[0];
					_context.Fighter.Add(new Fighter
					{
						UserId = User.Id,
						Name = A.Username,


                    });  
                    // ��������� ����� � �������� � ��������� ���������
                    _context.SaveChanges();
                    StaticStuff.Fighter = _context.Fighter.Where<Fighter>(p => p.UserId == User.Id).ToList()[0];
                    return RedirectToAction("PostRegister"); 
				}
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        [HttpGet]
        public IActionResult PostRegister()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
        [HttpPost]
        public IActionResult PostRegister(RegisterViewModel A)
        {
            // �������� FighterId �� TempData
            //if (TempData["FighterId"] != null && int.TryParse(TempData["FighterId"].ToString(), out int fighterId))
            //{
                // ������� ����� �� FighterId
                Fighter fighterToUpdate = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);

                if (fighterToUpdate != null)
                {
                    // ��������� ������ �����
                    fighterToUpdate.Rating = A.Rating;
                    fighterToUpdate.Sex = A.Sex;
				if (fighterToUpdate.Age <= 0)
				{
					return View(A);
				}
				fighterToUpdate.Age = A.Age;
				fighterToUpdate.Skills = A.Skills;
                    _context.Fighter.Update(fighterToUpdate);
                    _context.SaveChanges();

                    TempData["Id"] = fighterToUpdate.Id;
                    return RedirectToAction("Index", "Account");

                }
            //}
			//else
			//{
			//	// ��� ������(��� �� ����)
			//}

            return View(A);
        }

    }
}

//	public class HomeController : Controller
//	{
//		// �������� ��� �������� ��������
//		public IActionResult Index()
//		{
//			return View();
//		}

//		// �������� ��� �������� ������������������
//		public IActionResult Privacy()
//		{
//			return View();
//		}

//		// �������� ��� ��������� ������
//		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//		public IActionResult Error()
//		{
//			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//		}
//	}
//}
