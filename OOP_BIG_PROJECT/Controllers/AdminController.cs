using Microsoft.AspNetCore.Mvc;
using OOP_BIG_PROJECT.Models;
using OOP_BIG_PROJECT.ViewModels;
using OOP_BIG_PROJECT.Data;

namespace OOP_BIG_PROJECT.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Back()
        {
            var response = new TagsViewModel();
            return RedirectToAction("TagMenu");
        }
        [HttpGet]
        public IActionResult BackAdmin()
        {
            var response = new TagsViewModel();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (StaticStuff.Admin == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagMenu()
        {
            if (StaticStuff.Admin == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            var response = new TagsViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagAdd()
        {
            if (StaticStuff.Admin == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            var response = new TagsViewModel();
            return View(response);
        }

        [HttpGet]
        public IActionResult TagChangeDelete()
        {
            if (StaticStuff.Admin == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;
            var TagsViewModel = new TagsViewModel
            {
                AllTags = _context.Tags.ToList() // Заполнение списка тегов из базы данных
            };
            return View(TagsViewModel);

        }

        [HttpGet]
        public IActionResult TagChange(int Id)
        {
            if (StaticStuff.Admin == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            StaticStuff.ChangeTag = Id;
            var response = new TagsViewModel();
            return View(response);
        }
        [HttpPost]
        public IActionResult TagChangeName(TagsViewModel A)
        {
            Tags tagToUpdate = _context.Tags.FirstOrDefault(l => l.Id == StaticStuff.ChangeTag);
            var alltags = _context.Tags.Where(l => l.Id != StaticStuff.ChangeTag).ToList();
            A.AllTags = alltags;
            if (tagToUpdate == null)
            {
                return View("TagChange", A);
            }
            else
            {
                if (A.Name != null && alltags.Any(tag => tag.Name.Equals(A.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Name", "Тег с таким именем уже существует.");
                    return View("TagChange", A);
                }
                tagToUpdate.Name = A.Name;
                tagToUpdate.Description = A.Description;
                _context.Tags.Update(tagToUpdate);
                _context.SaveChanges();

                return RedirectToAction("TagMenu");
            }
        }

        [HttpPost]
        public IActionResult TagDelete(int TagId)
        {
            if (StaticStuff.Admin == null)
            {
                // Переходим на страницу с адресом refererUrl
                return Redirect(StaticStuff.refererUrl);
            }
            StaticStuff.refererUrl = HttpContext.Request.Path;

            Tags tag = _context.Tags.FirstOrDefault(l => l.Id == TagId);
            var FightersWithTag = _context.Fighter.Where(l => l.TagId1 == tag.Id || l.TagId2 == tag.Id || l.TagId3 == tag.Id || l.TagId4 == tag.Id || l.TagId5 == tag.Id).ToList();
            foreach (var fighter in FightersWithTag)
            {
                if (fighter.TagId1 == tag.Id)
                {
                    fighter.TagId1 = 2;
                    _context.Fighter.Update(fighter);
                }
                if (fighter.TagId2 == tag.Id)
                {
                    fighter.TagId2 = 2;
                    _context.Fighter.Update(fighter);
                }
                if (fighter.TagId3 == tag.Id)
                {
                    fighter.TagId3 = 2;
                    _context.Fighter.Update(fighter);
                }
                if (fighter.TagId4 == tag.Id)
                {
                    fighter.TagId4 = 2;
                    _context.Fighter.Update(fighter);
                }
                if (fighter.TagId5 == tag.Id)
                {
                    fighter.TagId5 = 2;
                    _context.Fighter.Update(fighter);
                }

            }
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("TagChangeDelete");
        }
        [HttpGet]
        public IActionResult Ban()
        {
            var FighterViewModel = new FighterViewModel
            {
                AllFighters = _context.Fighter.ToList() // Заполнение списка тегов из базы данных
            };
            return View(FighterViewModel);
        }
        [HttpPost]
        public IActionResult BanFighter(int Id)
        {
            Fighter fighterToUpdate = _context.Fighter.FirstOrDefault(l => l.Id == Id);
            if (fighterToUpdate.Ban == true)
            {
                fighterToUpdate.Ban = false;
            }
            else
            {
                fighterToUpdate.Ban = true;
            }
            _context.Fighter.Update(fighterToUpdate);
            _context.SaveChanges();
            return RedirectToAction("Ban");
        }
        [HttpPost]
        public IActionResult TagMake(TagsViewModel A)
        {

            //Tags tag = _context.Tags.FirstOrDefault(a => a.Id == A.Id);
            List<Tags> tags = _context.Tags.Where<Tags>(a => a.Name == A.Name).ToList();
            if (tags.Count != 0)
            {
                A.IsTagExisting = true;
                ModelState.AddModelError("Name", "Тег с таким именем уже существует.");
                return View("TagAdd", A);
            }
            else
            {
                _context.Tags.Add(new Tags { Name = A.Name, Description = A.Description });
                _context.SaveChanges();
                return RedirectToAction("TagMenu");
            }
        }
    }
}