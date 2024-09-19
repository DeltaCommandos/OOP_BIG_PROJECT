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
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

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
        public IActionResult TagMenu()
        {
            var response = new TagsViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagAdd()
        {
            var response = new TagsViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagChange()
        {
            var response = new TagsViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagDelete()
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

        [HttpGet]
        public IActionResult AccountHome()
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangeLoginAndPassword()
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var response = new UserViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult ChangeLogin()
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var response = new UserViewModel();
            return View(response);
        }




        [HttpGet]
        public IActionResult ChangeInfo()
        {
            if (StaticStuff.Fighter == null)
            {
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            // Предположим, что данные о бойце хранятся в StaticStuff.Fighter
            var response = new FighterViewModel
            {
                SelectedFighter = StaticStuff.Fighter // Передача бойца в модель
            };

            return View(response);
        }

        [HttpGet]
        public IActionResult ChangeAge()
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var response = new FighterViewModel
            {
                SelectedFighter = StaticStuff.Fighter
            };
            return View(response);
        }


        [HttpGet]
        public IActionResult ChangeTags()
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var allTags = _context.Tags.ToList();
            var response = new FighterViewModel
            {
                AllTags = allTags,
            };
            return View(response);
        }

        //[HttpGet]
        //public IActionResult MyInfo()
        //{
        //    var response = new FighterViewModel();
        //    return View(response);
        //}
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
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            int currentFighterId = StaticStuff.Fighter.Id;

            List<Fighter> fighters = _context.Fighter.Where(a => a.Id != currentFighterId).ToList();

            List<int> likedFighterIds = _context.Likes
                                              .Where(l => l.LikerId == currentFighterId && l.IsLiked == true)
                                              .Select(l => l.LikedFighterId)
                                              .ToList();

            A.likedFighterIds = likedFighterIds;

            List<Tuple<Fighter, Fighter>> mutualLikes = new List<Tuple<Fighter, Fighter>>();

            foreach (int likedFighterId in likedFighterIds)
            {
                // Проверяем, лайкнул ли текущий боец бойца с идентификатором likedFighterId
                bool isMutualLike = _context.Likes.Any(l => l.LikerId == likedFighterId && l.LikedFighterId == currentFighterId && l.IsLiked==true);

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
                 List<User> accounts = _context.User.Where<User>(a => a.Username == A.Username).ToList();
                if (accounts.Count != 0)
                {
                    A.IsUserExistingRelogin = true;
                    return View(A); // Возвращаем представление с сообщением об ошибке
                }
                else
                {
                    //меняем имя fighter
                    fighterToUpdate.Name = A.Username;
                    User userToUpdate = _context.User.FirstOrDefault(a => a.Id == StaticStuff.Fighter.UserId);
                    //меняем имя User
                    userToUpdate.Username = A.Username;

                    if (userToUpdate.Username != null || fighterToUpdate.Name != null)
                    {
                        StaticStuff.Fighter.Name = fighterToUpdate.Name;
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
            }

            return View(A);
        }
        [HttpPost]
        public IActionResult Back()
        {
            return RedirectToAction("ChangeLoginAndPassword", "Account");
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
        public IActionResult ChangeInfo(FighterViewModel model)
        {
            if (model.SelectedFighter != null)
            {
                // Обновляем данные о бойце
                var fighterToUpdate = StaticStuff.Fighter;
                fighterToUpdate.Skills = model.SelectedFighter.Skills;
                _context.Update(fighterToUpdate); // Обновите запись в контексте
                _context.SaveChanges(); // Сохраните изменения
            }

            return RedirectToAction("AccountHome");
        }


        [HttpPost]
        public IActionResult ChangeAge(FighterViewModel model)
        {
            if (model.SelectedFighter != null)
            {
                // Обновляем данные о бойце
                var fighterToUpdate = StaticStuff.Fighter;
                fighterToUpdate.Age = model.SelectedFighter.Age;
                _context.Update(fighterToUpdate); // Обновите запись в контексте
                _context.SaveChanges(); // Сохраните изменения
            }

            return RedirectToAction("AccountHome");
        }

        [HttpPost]
        public IActionResult ChangeTags(FighterViewModel A)
        {
            Fighter fighterToUpdate = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);

            // Заполняем список тегов для передачи в представление, если это ещё не было сделано
            if (A.AllTags == null)
            {
                A.AllTags = _context.Tags.ToList();
            }

            if (fighterToUpdate == null)
            {
                return View(A); // Возвращаем заполненный ViewModel
            }
            else
            {
                // Обновляем теги бойца
                fighterToUpdate.TagId1 = A.SelectedTag1;
                fighterToUpdate.TagId2 = A.SelectedTag2;
                fighterToUpdate.TagId3 = A.SelectedTag3;
                fighterToUpdate.TagId4 = A.SelectedTag4;
                fighterToUpdate.TagId5 = A.SelectedTag5;

                _context.Fighter.Update(fighterToUpdate);
                _context.SaveChanges();

                return RedirectToAction("AccountHome");
            }
        }
        [HttpGet]
        public IActionResult MyInfo(FighterViewModel A)
        {
            var Fighter = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
            A.AllTags = _context.Tags.ToList();
            if (Fighter != null)
            {
                A.SelectedFighter = Fighter;
                _context.SaveChanges();
                return View(A);
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public IActionResult Blacklist(FighterViewModel viewModel)
        {
            List <int> bannedfightersId=_context.BansForFighters.Where(a=>a.Banner==StaticStuff.Fighter.Id).Select(a=>a.Banned).ToList();
            List<int> idsToRemove = new List<int>();
            List<Fighter> bannedfighters = new List<Fighter>();
            foreach (int bannedfighterId in bannedfightersId)
            {
                Fighter bannedfighter = _context.Fighter.FirstOrDefault(a => a.Id == bannedfighterId);
                if (bannedfighter != null && !idsToRemove.Contains(bannedfighter.Id))
                {
                    bannedfighters.Add(bannedfighter);
                    idsToRemove.Add(bannedfighter.Id); 
                }
            }

            bannedfightersId.RemoveAll(id => idsToRemove.Contains(id));

            viewModel.BlackListFighters = bannedfighters;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BlacklistUnban(int receiverId)
        {
            int? bannedfighterid = _context.BansForFighters.Where(a => a.Banned == receiverId && a.Banner == StaticStuff.Fighter.Id).Select(l => l.Banned).FirstOrDefault();

            List <BansForFighters> bannedfighter = _context.BansForFighters.Where(a => a.Banned == bannedfighterid).ToList();
            _context.BansForFighters.RemoveRange(bannedfighter);
            Likes NewMatch1= new Likes();
            NewMatch1.LikerId = StaticStuff.Fighter.Id;
            NewMatch1.LikedFighterId = receiverId;
            NewMatch1.IsLiked = true;
            NewMatch1.LikerStatus = false;
            Likes NewMatch2 = new Likes();
            NewMatch2.LikerId = receiverId;
            NewMatch2.LikedFighterId = StaticStuff.Fighter.Id;
            NewMatch2.IsLiked = true;
            NewMatch2.LikerStatus = false;
            _context.Likes.Add(NewMatch1);
            _context.Likes.Add(NewMatch2);
            _context.SaveChanges();
            return RedirectToAction("Blacklist");
        }
        [HttpPost]
        public IActionResult OpenChat(int receiverId)
        {
            return RedirectToAction("ChatView", new { receiverId = receiverId });
        }
        [HttpPost]
        public IActionResult DeleteChat(int receiverId)
        {
            //List <int> receiverlikesid=_context.Likes.Where(l=>l.LikerId== receiverId && l.LikedFighterId==StaticStuff.Fighter.Id).Select(l=>l.Id).ToList();
            //List < int> senderlikesid= _context.Likes.Where(l => l.LikerId == StaticStuff.Fighter.Id && l.LikedFighterId == receiverId).Select(l => l.Id).ToList();
            //foreach(int receiverlikeid in receiverlikesid)
            //{
            //   Likes receiverlike=new Likes();
            //    receiverlike = _context.Likes.FirstOrDefault(a => a.Id == receiverlikeid);
            //    _context.Remove(receiverlike);

            //}
            List<Likes> receiverlikes = _context.Likes.Where(l => l.LikerId == receiverId && l.LikedFighterId == StaticStuff.Fighter.Id).ToList();
            List<Likes> senderlikes = _context.Likes.Where(l => l.LikerId == StaticStuff.Fighter.Id && l.LikedFighterId == receiverId).ToList();
            List<Messages> receiverMessages = _context.Messages.Where(l => l.SenderId == receiverId && l.ReceiverId == StaticStuff.Fighter.Id).ToList();
            List<Messages> senderMessages = _context.Messages.Where(l => l.SenderId == StaticStuff.Fighter.Id && l.ReceiverId == receiverId).ToList();
            _context.RemoveRange(receiverlikes);
            _context.RemoveRange(senderlikes);
            _context.RemoveRange(receiverMessages);
            _context.RemoveRange(senderMessages);
            _context.SaveChanges();
            return RedirectToAction("ViewMatches");
        }
        public IActionResult BanChat(int receiverId)
        {
            //List <int> receiverlikesid=_context.Likes.Where(l=>l.LikerId== receiverId && l.LikedFighterId==StaticStuff.Fighter.Id).Select(l=>l.Id).ToList();
            //List < int> senderlikesid= _context.Likes.Where(l => l.LikerId == StaticStuff.Fighter.Id && l.LikedFighterId == receiverId).Select(l => l.Id).ToList();
            //foreach(int receiverlikeid in receiverlikesid)
            //{
            //   Likes receiverlike=new Likes();
            //    receiverlike = _context.Likes.FirstOrDefault(a => a.Id == receiverlikeid);
            //    _context.Remove(receiverlike);

            //}
            int BannerId = StaticStuff.Fighter.Id;
            int BannedId = receiverId;
            BansForFighters Ban = new BansForFighters
            {
                Banner = BannerId,
                Banned = BannedId
            }
            ;
            List<Likes> receiverlikes = _context.Likes.Where(l => l.LikerId == receiverId && l.LikedFighterId == StaticStuff.Fighter.Id).ToList();
            List<Likes> senderlikes = _context.Likes.Where(l => l.LikerId == StaticStuff.Fighter.Id && l.LikedFighterId == receiverId).ToList();
            //List<Messages> receiverMessages = _context.Messages.Where(l => l.SenderId == receiverId && l.ReceiverId == StaticStuff.Fighter.Id).ToList();
            //List<Messages> senderMessages = _context.Messages.Where(l => l.SenderId == StaticStuff.Fighter.Id && l.ReceiverId == receiverId).ToList();
            _context.BansForFighters.Add(Ban);
            _context.RemoveRange(receiverlikes);
            _context.RemoveRange(senderlikes);
            //_context.RemoveRange(receiverMessages);
            //_context.RemoveRange(senderMessages);
            _context.SaveChanges();
            return RedirectToAction("ViewMatches");
        }
        [HttpGet]
        public IActionResult ChatView(int receiverId)
        {
            if (StaticStuff.Fighter == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

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
                DateTime currentUtcTime = DateTime.UtcNow;
                DateTime adjustedTime = currentUtcTime.AddHours(3);

                if (!messageExists)
                {
                    // Создаем новое сообщение и сохраняем его в базу данных
                    Messages chatMessage = new Messages
                    {
                        SenderId = Sender.Id,
                        ReceiverId = Receiver.Id,
                        Content = A.Content,
                        Timestamp = adjustedTime
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
                        Timestamp = adjustedTime // Добавляем временную метку сообщения
                    };

                    _context.Messages.Add(chatMessage);
                }
                //Messages chatMessage = new Messages
                //{
                //    SenderId = Sender.Id,
                //    ReceiverId = Receiver.Id,
                //    Content = A.Content,
                //    Timestamp = DateTime.UtcNow // Добавляем временную метку сообщения
                //};

                //_context.Messages.Add(chatMessage);

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