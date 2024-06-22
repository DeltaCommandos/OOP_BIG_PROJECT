using Microsoft.AspNetCore.Mvc;
using OOP_BIG_PROJECT.Models;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using OOP_BIG_PROJECT.ViewModels;
using OOP_BIG_PROJECT.Data;
using System.Collections.Generic;
using System.Linq;
using NuGet.Protocol.Plugins;
namespace OOP_BIG_PROJECT.Controllers
{
    //кнопку "начать поиск". аву в углу сделать. рядом с ней изменить фото. сделать изменить увлечения. меню с предстоящими боями. 
    // ник указать 
    public class AccountController : Controller
	{
		private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult Search()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult Account()
        {
            var response = new FighterViewModel();
            return View(response);
        }


        [HttpGet]
        public IActionResult Admin()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagAdd()
        {
            var response = new TagsViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult Ban()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpPost]
        public IActionResult MakeTag(TagsViewModel A)
        {
            //Tags tag = _context.Tags.FirstOrDefault(a => a.Id == A.Id);
            List<Tags> accounts = _context.Tags.Where<Tags>(a => a.Name == A.Name).ToList();
            if (accounts.Count != 0)
            {
                A.IsTagExisting = true;
                return View(A); // Возвращаем представление с сообщением об ошибке
            }
            else
            {
                _context.Tags.Add(new Tags { Name = A.Name, Description = A.Description });
                _context.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(A);
        }


        [HttpGet]
        public IActionResult AccountHome()
        {
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangeLoginAndPassword()
        {
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangeLogin()
        {
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangeInfo()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult MyInfo()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpPost]
        public IActionResult Index(FighterViewModel A)
        {
            return View(A);
        }
        [HttpPost]
        public IActionResult Search(FighterViewModel A)
        {
            return RedirectToAction("Search", "Match");
        }
        public IActionResult Account(FighterViewModel A)
        {
            return RedirectToAction("Account", "AccountHome");
        }
        [HttpGet]
        public IActionResult ViewMatches(FighterViewModel A)
        {
            int currentFighterId = StaticStuff.Fighter.Id;

            List<Fighter> fighters = _context.Fighter.Where(a => a.Id != currentFighterId).ToList();

            List<int> likedFighterIds = _context.Likes
                                              .Where(l => l.LikerId == currentFighterId)
                                              .Select(l => l.LikedFighterId)
                                              .ToList();

            A.likedFighterIds = likedFighterIds;

            List<Tuple<Fighter, Fighter>> mutualLikes = new List<Tuple<Fighter, Fighter>>();

            foreach (int likedFighterId in likedFighterIds)
            {
                // Проверяем, лайкнул ли текущий боец бойца с идентификатором likedFighterId
                bool isMutualLike = _context.Likes.Any(l => l.LikerId == likedFighterId && l.LikedFighterId == currentFighterId);

                if (isMutualLike)
                {
                    // Находим объекты бойцов, которые лайкнули друг друга
                    Fighter currentFighter = fighters.FirstOrDefault(f => f.Id == likedFighterId);
                    Fighter likedFighter = _context.Fighter.FirstOrDefault(f => f.Id == likedFighterId);

                    if (!mutualLikes.Contains(new Tuple<Fighter, Fighter>(currentFighter, likedFighter)))
                    {
                        mutualLikes.Add(new Tuple<Fighter, Fighter>(currentFighter, likedFighter));
                    }
                }
            }
            A.MutualLikes = mutualLikes;
            return View(A);
        }
        [HttpPost]
        public IActionResult ChangeLogin(UserViewModel A)
        {
            Fighter fighterToUpdate = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
            if (fighterToUpdate == null)
            {

                return View(A);
            }
            else
            {
                //меняем имя fighter
                fighterToUpdate.Name = A.Username;
                User userToUpdate = _context.User.FirstOrDefault(a => a.Id == StaticStuff.Fighter.UserId);
                //меняем имя User
                userToUpdate.Username=A.Username;
                if (userToUpdate.Username != null || fighterToUpdate.Name != null)
                {
                    _context.Fighter.Update(fighterToUpdate);
                    _context.User.Update(userToUpdate);
                    _context.SaveChanges();
                    return RedirectToAction("AccountHome");
                }
                else
                {
                    return View(A);
                }
            }
            
            return View(A);
        }
        [HttpPost]
        public IActionResult Back()
        {
            return RedirectToAction("AccountHome", "Account");
        }
        [HttpPost]
        public IActionResult Back1()
        {
            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public IActionResult ChangePassword(UserViewModel A)
        {
            User user = _context.User.FirstOrDefault(a => a.Id == StaticStuff.Fighter.UserId);

            if (user == null)
            {
                return View(A);
            }

            user.Password = A.Password1;
            if (user.Password == null)
            {
                return View(A);
            }
            else
            {
                _context.User.Update(user);
                _context.SaveChanges();


                return RedirectToAction("AccountHome");
            }
        }
        [HttpPost]
        public IActionResult ChangeInfo(FighterViewModel A)
        {
            Fighter fighterToUpdate = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
            if (fighterToUpdate == null)
            {

                return View(A);
            }
            else
            {
                fighterToUpdate.Skills = A.SelectedFighter.Skills;
                _context.Fighter.Update(fighterToUpdate);
                _context.SaveChanges();
                return RedirectToAction("AccountHome");
            }
        }
        [HttpPost]
        public IActionResult MyInfo(FighterViewModel A)
        {
            var Fighter = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
            if (Fighter != null) 
                {
                A.SelectedFighter= Fighter;
                _context.SaveChanges();
                return RedirectToAction("AccountHome");
                }
            else
            {
                return View(A);
            }
        }
        [HttpPost]
        public IActionResult OpenChat(int receiverId)
        {
            return RedirectToAction("ChatView", new { receiverId = receiverId });
        }
        [HttpGet]
        public IActionResult ChatView(int receiverId)
        {
            var Sender = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
            var Receiver = _context.Fighter.FirstOrDefault(a => a.Id == receiverId);
            var response = new ChatViewModel
            {

                SenderId = Sender.Id,
                ReceiverId = receiverId,
                ReceiverName = Receiver.Name,
                Messages = _context.Messages
                    .Where(m =>
                        (m.SenderId == Sender.Id && m.ReceiverId == Receiver.Id) ||
                        (m.SenderId == Receiver.Id && m.ReceiverId == Sender.Id))
                     .ToList() // Инициализируем пустой список сообщений
            };
            return View(response);

        }
        [HttpPost]
        public IActionResult Chat(int receiverId, ChatViewModel A)
        {
            var Sender = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
            var Receiver = _context.Fighter.FirstOrDefault(a => a.Id == receiverId);

            if (Sender != null && Receiver != null)
            {
                bool messageExists = _context.Messages.Any(m =>
                    (m.SenderId == Sender.Id && m.ReceiverId == Receiver.Id) ||
                    (m.SenderId == Receiver.Id && m.ReceiverId == Sender.Id));

                if (!messageExists)
                {
                    // Создаем новое сообщение и сохраняем его в базу данных
                    Messages chatMessage = new Messages
                    {
                        SenderId = Sender.Id,
                        ReceiverId = Receiver.Id,
                        Content = A.Content
                    };

                    _context.Messages.Add(chatMessage);
                }
                else
                {
                    Messages chatMessage = new Messages
                    {
                        SenderId = Sender.Id,
                        ReceiverId = Receiver.Id,
                        Content = A.Content,
                        //Timestamp = DateTime.Now // Добавляем временную метку сообщения
                    };

                    _context.Messages.Add(chatMessage);
                }

                // Подготавливаем модель представления для отображения чата
                ChatViewModel viewModel = new ChatViewModel
                {
                    SenderId = Sender.Id,
                    ReceiverId = receiverId,
                    ReceiverName = Receiver.Name,
                    Messages = _context.Messages
                    .Where(m =>
                        (m.SenderId == Sender.Id && m.ReceiverId == Receiver.Id) ||
                        (m.SenderId == Receiver.Id && m.ReceiverId == Sender.Id))
                     .ToList()
                };
                _context.SaveChanges();
                return RedirectToAction("ChatView", new { receiverId = receiverId });
            }
            else
            {
                // Если Sender или Receiver не найдены, возвращаем текущее представление с моделью A
                return View(A);
            }
        }


        //        var user = _context.Fighter.Where(a => a.UserId == StaticStuff.Fighter.UserId);
        //                    if (user==null)
        //                    {
        //                        return View(A);
        //    }
        //                    else 
        //                    {
        //                    }
        //return View(A);

    }
}



















        //      private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

//	public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
//	{
//		_userManager = userManager;
//		_signInManager = signInManager;
//	}

//	[HttpGet]
//	public IActionResult Register()
//	{
//		return View();
//	}

//	[HttpPost]
//	public async Task<IActionResult> Register(RegisterViewModel model)
//	{
//		if (ModelState.IsValid)
//		{
//			var user = new IdentityUser { UserName = model.Username, Username = model.Username };
//			var result = await _userManager.CreateAsync(user, model.Password);
//			if (result.Succeeded)
//			{
//				await _signInManager.SignInAsync(user, isPersistent: false);
//				return RedirectToAction("Index", "Home");
//			}
//			foreach (var error in result.Errors)
//			{
//				ModelState.AddModelError(string.Empty, error.Description);
//			}
//		}
//		return View(model);
//	}

//	[HttpGet]
//	public IActionResult Login()
//	{
//		return View();
//	}

//	[HttpPost]
//	public async Task<IActionResult> Login(LoginViewModel model)
//	{
//		if (ModelState.IsValid)
//		{
//			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
//			if (result.Succeeded)
//			{
//				return RedirectToAction("Index", "Home");
//			}
//			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//		}
//		return View(model);
//	}