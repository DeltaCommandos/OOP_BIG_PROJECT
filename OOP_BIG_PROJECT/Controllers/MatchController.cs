using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP_BIG_PROJECT.Data;
using OOP_BIG_PROJECT.Models;
using OOP_BIG_PROJECT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_BIG_PROJECT.Controllers
{
    public class MatchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Fighter selectedFighter = GetRandomFighter();
            var viewModel = new FighterViewModel
            {
                SelectedFighter = selectedFighter
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Like(int fighterId)
        {
            var Likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == fighterId);
            if (Likedfighter != null)
            {
                var likes = new Likes();
                likes.LikerId = StaticStuff.Fighter.Id;
                likes.LikedFighterId = Likedfighter.Id;
                likes.IsLiked = true;
                _context.Likes.Add(likes);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Back()
        {
           return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public IActionResult Dislike(int fighterId)
        {
            var Likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == fighterId);
            if (Likedfighter != null)
            {
                var likes = new Likes();
                likes.LikerId = StaticStuff.Fighter.Id;
                likes.LikedFighterId = Likedfighter.Id;
                likes.IsLiked = false;
                _context.Likes.Add(likes);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private Fighter GetRandomFighter()
        {

            List<Fighter> fighters = _context.Fighter.Where(a => a.Id != StaticStuff.Fighter.Id).ToList();

            if (fighters.Count == 0)
            {
                throw new InvalidOperationException("Массив бойцов пуст.");
            }
            Random random = new Random();
            int index = random.Next(fighters.Count);
            Fighter selectedFighter = fighters[index];
            fighters.RemoveAt(index);

            return selectedFighter;
        }
    }
}
