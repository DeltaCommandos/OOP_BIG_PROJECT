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
        public IActionResult Index()
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
        public IActionResult TagChangeDelete()
        { 
            var TagsViewModel = new TagsViewModel
            {
                AllTags = _context.Tags.ToList() // Заполнение списка тегов из базы данных
            };
            return View(TagsViewModel);
           
        }

        [HttpGet]
        public IActionResult TagChange(TagsViewModel A)
        {
            var response = new TagsViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult TagChangeName(TagsViewModel A)
        {
            Tags tagToUpdate = _context.Tags.FirstOrDefault(a => a.Id == StaticStuff.Tag.Id);

            if (tagToUpdate == null)
            {
                return View("TagChange", A);
            }
            else
            {
                tagToUpdate.Name = A.SelectedTag.Name;
                _context.Tags.Update(tagToUpdate);
                _context.SaveChanges();
                return RedirectToAction("TagMenu");
            }
            //var response = new TagsViewModel();
            //return View(response);
        }
        [HttpPost]
        public IActionResult TagDelete(int TagId)
        {
            Tags tag = _context.Tags.FirstOrDefault(l => l.Id == TagId);
            //List<Tags> TagsId = _context.Tags.Where(l => l.Id == TagId).ToList();
            //List<Tags> TagsName = _context.Tags.Where(l => l.Name == StaticStuff.Tags.Name).ToList();
            //List<Tags> TagsDiscription = _context.Tags.Where(l => l.Description == StaticStuff.Tags.Description).ToList();
            _context.Tags.Remove(tag);
            //_context.RemoveRange(TagsName);
            //_context.RemoveRange(TagsDiscription);
            _context.SaveChanges();
            return RedirectToAction("TagMenu");
        }
        [HttpGet]
        public IActionResult Ban()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpPost]
        public IActionResult TagMake(TagsViewModel A)
        {
            //Tags tag = _context.Tags.FirstOrDefault(a => a.Id == A.Id);
            List<Tags> accounts = _context.Tags.Where<Tags>(a => a.Name == A.Name).ToList();
            if (accounts.Count != 0)
            {
                A.IsTagExisting = true;
                return View("TagAdd", A); // Возвращаем представление с сообщением об ошибке
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
