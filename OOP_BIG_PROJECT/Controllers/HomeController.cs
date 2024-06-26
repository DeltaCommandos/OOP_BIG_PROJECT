using Microsoft.AspNetCore.Mvc;
using OOP_BIG_PROJECT.Models;
using OOP_BIG_PROJECT.ViewModels;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace OOP_BIG_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        //private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationContext context)
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

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel A)
        {
            List<user> accounts = _context.user.Where<user>(a => a.Login == A.Login).ToList();
            if (accounts.Count != 0)
            {
                if (A.Password == accounts[0].Password)
                {
                    StaticStuff.Status = accounts[0].Status;
                    if (accounts[0].Status)
                    {
                        StaticStuff.judgement = _context.judgement.Where<Judgement>(d => d.ID == accounts[0].ID).ToList()[0];
                        return RedirectToAction("Index", "Doctor");
                    }
                    else
                    {
                        StaticStuff.fighter = _context.fighter.Where<Fighter>(p => p.ID == accounts[0].ID).ToList()[0];
                        return RedirectToAction("Index", "Fighter");
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
            List<user> accounts = _context.user.Where<user>(a => a.Login == A.username.Login).ToList();
            if (accounts.Count != 0)
            {
                A.IsUserExisting = true;
                return View(A);
            }
            else
            {
                _context.user.Add(new user { Login = A.username.Login, Password = A.username.Password, Status = true });
                _context.SaveChanges();
                user user = _context.user.Where<user>(a => a.Login == A.username.Login).ToList()[0];
                _context.judgement.Add(new Judgement
                {
                    ID = user.ID,
                    Name = A.Name
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
