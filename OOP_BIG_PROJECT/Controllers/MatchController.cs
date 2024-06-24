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
                _fighters = new List<Fighter>();
                List<int> LikedFightersId = _context.Fighter.Where(a => a.Id != StaticStuff.Fighter.Id)
                                                            .Select(a => a.Id)
                                                            .ToList();
                foreach(int LikedFighterId in LikedFightersId)
                {
                    //List < Likes > CorrentFighter=_context.Likes.Where(a=>a.LikerId== StaticStuff.Fighter.Id).ToList();
                    // List<Likes> LikedFighter = _context.Likes.Where(a => a.LikerId == LikedFighterId).ToList();
                    
                    bool Liker = _context.Likes.Any(l => (l.LikerId == LikedFighterId && l.LikedFighterId == StaticStuff.Fighter.Id));
                    bool liked = _context.Likes.Any(l => (l.LikerId == StaticStuff.Fighter.Id && l.LikedFighterId == LikedFighterId));
                    if (!(Liker && liked))
                    {
                        var LikedFighter = _context.Fighter.FirstOrDefault(a => a.Id == LikedFighterId);
                        if (LikedFighter != null)
                        {
                            _fighters.Add(LikedFighter);
                        }
                    }

                }
               // _fighters = _context.Fighter.Where(a => a.Id != StaticStuff.Fighter.Id).ToList();
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
                if (FighterForMatch.Flag)
                {
                    Fighter selectedFighter = GetRandomFighter();
                    var viewModel = new FighterViewModel
                    {
                        SelectedFighter = selectedFighter
                    };
                    FighterForMatch.Flag = false;
                    return View(viewModel);
                }
                else
                {
                    Fighter selectedFighter = GetRandomFighterCase2();
                    var viewModel = new FighterViewModel
                    {
                        SelectedFighter = selectedFighter
                    };
                    FighterForMatch.Flag = false;
                    return View(viewModel);
                }
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
                FighterForMatch.Flag = true;
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
                FighterForMatch.Flag = true;
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
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
                Random random = new Random();
                int index = random.Next(fighters.Count);
                Fighter selectedFighter = fighters[index];
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == selectedFighter.Id);
                fighters.RemoveAt(index);
                FighterForMatch.Fighters = fighters;
                return selectedFighter;
            }
        }
        private Fighter GetRandomFighterCase2()
        {
            var fighters = FighterForMatch.Fighters;
            if (fighters.Count == 0)
            {
                return null;
            }
            else
            {
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
                Random random = new Random();
                int index = random.Next(fighters.Count);
                Fighter selectedFighter = fighters[index];
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == selectedFighter.Id);
                FighterForMatch.Fighters = fighters;
                return selectedFighter;
            }
        }
    }
}
