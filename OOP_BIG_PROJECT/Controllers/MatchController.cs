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
            if (FighterForMatch.IsSorted && FighterForMatch.SortedFighters.Count == 0)
            {
                Fighter selectedFighter = new Fighter();
                selectedFighter.Age = -1000;
                var viewModel = new FighterViewModel
                {
                    AllTags = _context.Tags.ToList(),
                    SelectedFighter = selectedFighter

                };
                //FighterForMatch.Fighters.Add(selectedFighter);  
                return View(viewModel);
            }
            if (FighterForMatch.Fighters.Count != 0)
            {
                if (FighterForMatch.Flag)
                {
                    if (!FighterForMatch.IsSorted)
                    {
                        Fighter selectedFighter = GetRandomFighter();
                        var viewModel = new FighterViewModel
                        {
                            AllTags=_context.Tags.ToList(),
                            SelectedFighter = selectedFighter
                        };
                        FighterForMatch.Flag = false;
                        return View(viewModel);
                    }
                    else
                    {
                        Fighter selectedFighter = GetRandomSortedFighter();
                        var viewModel = new FighterViewModel
                        {
                            AllTags = _context.Tags.ToList(),
                            SelectedFighter = selectedFighter
                        };
                        FighterForMatch.Flag = false;
                        return View(viewModel);
                    }
                }
                else
                {
                    if (!FighterForMatch.IsSorted)
                    {
                        Fighter selectedFighter = GetRandomFighterCase2();
                        var viewModel = new FighterViewModel
                        {
                            AllTags = _context.Tags.ToList(),
                            SelectedFighter = selectedFighter
                        };
                        FighterForMatch.Flag = false;
                        return View(viewModel);
                    }
                    else
                    {
                        Fighter selectedFighter = GetRandomSortedFighterCase2();
                        var viewModel = new FighterViewModel
                        {
                            AllTags = _context.Tags.ToList(),
                            SelectedFighter = selectedFighter
                        };
                        FighterForMatch.Flag = false;
                        return View(viewModel);
                    }
                }
            }
            else
            {
                Fighter selectedFighter = new Fighter();
                selectedFighter.Age = -1000;
                var viewModel = new FighterViewModel
                {
                    AllTags = _context.Tags.ToList(),
                    SelectedFighter = selectedFighter

                };
                //FighterForMatch.Fighters.Add(selectedFighter);
                return View(viewModel);
            }

        }
        [HttpGet]
        public IActionResult SortedByTags(FighterViewModel A)
        {
            FighterForMatch.SortedFighters = FighterForMatch.Fighters;
            List <int?> SelectedTagsId = new List<int?>();
            SelectedTagsId.Add(A.SelectedTag1);
            SelectedTagsId.Add(A.SelectedTag2);
            SelectedTagsId.Add(A.SelectedTag3);
            SelectedTagsId.Add(A.SelectedTag4);
            SelectedTagsId.Add(A.SelectedTag5);
           
            List<int?> NeededTagsId= SelectedTagsId.Where(a=>a!=null).ToList();
            int NumberOfTags = NeededTagsId.Count();
            if (NumberOfTags == 0)
            {
                FighterForMatch.IsSorted = false;
                return RedirectToAction("Index");
            }
            if (NumberOfTags == 1)
            {
                int? selectedTagId = NeededTagsId[0];
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == selectedTagId ||
                                    a.TagId2 == selectedTagId ||
                                    a.TagId3 == selectedTagId ||
                                    a.TagId4 == selectedTagId ||
                                    a.TagId5 == selectedTagId)
                        .ToList();
            }
            if (NumberOfTags == 2)
            {
                int? selectedTagId = NeededTagsId[1];
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 ==  NeededTagsId[0] ||
                                    a.TagId2 ==  NeededTagsId[0] ||
                                    a.TagId3 ==  NeededTagsId[0] ||
                                    a.TagId4 ==  NeededTagsId[0] ||
                                    a.TagId5 ==  NeededTagsId[0])
                        .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == selectedTagId ||
                                    a.TagId2 == selectedTagId ||
                                    a.TagId3 == selectedTagId ||
                                    a.TagId4 == selectedTagId ||
                                    a.TagId5 == selectedTagId)
                        .ToList();
            }
            if (NumberOfTags == 3)
            {
                int? selectedTagId = NeededTagsId[2];
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == NeededTagsId[0] ||
                                    a.TagId2 == NeededTagsId[0] ||
                                    a.TagId3 == NeededTagsId[0] ||
                                    a.TagId4 == NeededTagsId[0] ||
                                    a.TagId5 == NeededTagsId[0])
                        .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                       .Where(a => a.TagId1 == NeededTagsId[1] ||
                                   a.TagId2 == NeededTagsId[1] ||
                                   a.TagId3 == NeededTagsId[1] ||
                                   a.TagId4 == NeededTagsId[1] ||
                                   a.TagId5 == NeededTagsId[1])
                       .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == selectedTagId ||
                                    a.TagId2 == selectedTagId ||
                                    a.TagId3 == selectedTagId ||
                                    a.TagId4 == selectedTagId ||
                                    a.TagId5 == selectedTagId)
                        .ToList();
            }
            if (NumberOfTags == 4)
            {
                int? selectedTagId = NeededTagsId[3];
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == NeededTagsId[0] ||
                                    a.TagId2 == NeededTagsId[0] ||
                                    a.TagId3 == NeededTagsId[0] ||
                                    a.TagId4 == NeededTagsId[0] ||
                                    a.TagId5 == NeededTagsId[0])
                        .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                       .Where(a => a.TagId1 == NeededTagsId[1] ||
                                   a.TagId2 == NeededTagsId[1] ||
                                   a.TagId3 == NeededTagsId[1] ||
                                   a.TagId4 == NeededTagsId[1] ||
                                   a.TagId5 == NeededTagsId[1])
                       .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                      .Where(a => a.TagId1 == NeededTagsId[2] ||
                                  a.TagId2 == NeededTagsId[2] ||
                                  a.TagId3 == NeededTagsId[2] ||
                                  a.TagId4 == NeededTagsId[2] ||
                                  a.TagId5 == NeededTagsId[2])
                      .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == selectedTagId ||
                                    a.TagId2 == selectedTagId ||
                                    a.TagId3 == selectedTagId ||
                                    a.TagId4 == selectedTagId ||
                                    a.TagId5 == selectedTagId)
                        .ToList();
            }
            if (NumberOfTags == 5)
            {
                int? selectedTagId = NeededTagsId[4];
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == NeededTagsId[0] ||
                                    a.TagId2 == NeededTagsId[0] ||
                                    a.TagId3 == NeededTagsId[0] ||
                                    a.TagId4 == NeededTagsId[0] ||
                                    a.TagId5 == NeededTagsId[0])
                        .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                       .Where(a => a.TagId1 == NeededTagsId[1] ||
                                   a.TagId2 == NeededTagsId[1] ||
                                   a.TagId3 == NeededTagsId[1] ||
                                   a.TagId4 == NeededTagsId[1] ||
                                   a.TagId5 == NeededTagsId[1])
                       .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                      .Where(a => a.TagId1 == NeededTagsId[2] ||
                                  a.TagId2 == NeededTagsId[2] ||
                                  a.TagId3 == NeededTagsId[2] ||
                                  a.TagId4 == NeededTagsId[2] ||
                                  a.TagId5 == NeededTagsId[2])
                      .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                     .Where(a => a.TagId1 == NeededTagsId[3] ||
                                 a.TagId2 == NeededTagsId[3] ||
                                 a.TagId3 == NeededTagsId[3] ||
                                 a.TagId4 == NeededTagsId[3] ||
                                 a.TagId5 == NeededTagsId[3])
                     .ToList();
                FighterForMatch.SortedFighters = FighterForMatch.Fighters
                        .Where(a => a.TagId1 == selectedTagId ||
                                    a.TagId2 == selectedTagId ||
                                    a.TagId3 == selectedTagId ||
                                    a.TagId4 == selectedTagId ||
                                    a.TagId5 == selectedTagId)
                        .ToList();
            }
            FighterForMatch.IsSorted = true;
            return RedirectToAction("Index");
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
        private Fighter GetRandomSortedFighter()
        {
            var fighters = FighterForMatch.Fighters;
            var sortedfighters = FighterForMatch.SortedFighters;
            if (fighters.Count == 0)
            {
                return null;
            }
            else
            {
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
                Random random = new Random();
                int index = random.Next(sortedfighters.Count);
                Fighter selectedFighter = sortedfighters[index];

                Fighter selectedFighter1 = fighters.FirstOrDefault(f => f.Id == selectedFighter.Id);

                // int index1= fighters.Where(a=> a.Id== selectedFighter.Id)
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == selectedFighter.Id)
                if (fighters.Count != 0)
                {
                    FighterForMatch.Fighters.Remove(selectedFighter1);
                }
                if (sortedfighters.Count != 0)
                {
                    sortedfighters.RemoveAt(index);
                }
                //FighterForMatch.Fighters = fighters;
                FighterForMatch.SortedFighters = sortedfighters;
                return selectedFighter;
            }
        }
        private Fighter GetRandomSortedFighterCase2()
        {
            var fighters = FighterForMatch.Fighters;
            var sortedfighters = FighterForMatch.SortedFighters;
            if (fighters.Count == 0)
            {
                return null;
            }
            else
            {
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == StaticStuff.Fighter.Id);
                Random random = new Random();
                int index = random.Next(sortedfighters.Count);
                Fighter selectedFighter = sortedfighters[index];

                Fighter selectedFighter1 = fighters.FirstOrDefault(f => f.Id == selectedFighter.Id);

                // int index1= fighters.Where(a=> a.Id== selectedFighter.Id)
                //var likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == selectedFighter.Id)
                //FighterForMatch.Fighters = fighters;
                FighterForMatch.SortedFighters = sortedfighters;
                return selectedFighter;
            }
        }
    }
}
