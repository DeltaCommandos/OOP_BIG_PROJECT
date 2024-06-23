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
        private static List<Fighter> _fighters;


        public MatchController(ApplicationDbContext context)
        {
            _context = context;
            if (FighterForMatch.Fighters == null)
            {
                _fighters = _context.Fighter.Where(a => a.Id != StaticStuff.Fighter.Id).ToList();
                FighterForMatch.Fighters = _fighters;
            }

        }

        [HttpGet]
        public IActionResult Index()
        {
            //if (_fighters == null)
            //{
            //    _fighters = _context.Fighter.Where(a => a.Id != StaticStuff.Fighter.Id).ToList();
            //}
            if (FighterForMatch.Fighters.Count != 0)
            {
                Fighter selectedFighter = GetRandomFighter();
                var viewModel = new FighterViewModel
                {
                    SelectedFighter = selectedFighter
                };
                return View(viewModel);
            }
            else
            {
                Fighter selectedFighter = new Fighter();
                selectedFighter.Age = -1000;
                var viewModel = new FighterViewModel
                {
                    SelectedFighter = selectedFighter

                };
                //FighterForMatch.Fighters.Add(selectedFighter);
                return View(viewModel);
            }

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
        public IActionResult Back1()
        {
            return RedirectToAction("Account");
        }
        public IActionResult BackTable()
        {
            return RedirectToAction("ViewMatches", "Account");
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
            var fighters = FighterForMatch.Fighters;
            if (fighters.Count == 0)
            {
                return null;
            }
            else
            {
                Random random = new Random();
                int index = random.Next(fighters.Count);
                Fighter selectedFighter = fighters[index];
                fighters.RemoveAt(index);
                FighterForMatch.Fighters = fighters;
                return selectedFighter;
            }
        }
    }
}
