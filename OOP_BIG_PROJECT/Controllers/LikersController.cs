using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP_BIG_PROJECT.Data;
using OOP_BIG_PROJECT.Models;
using OOP_BIG_PROJECT.ViewModels;

namespace OOP_BIG_PROJECT.Controllers
{
    public class LikersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<Fighter> _likerfighters;

        public LikersController(ApplicationDbContext context)
        {
            _context = context;
            _likerfighters = new List<Fighter>();

            //List<bool> LikerFightersS = _context.Likes.Where(a => a.LikedFighterId == StaticStuff.Fighter.Id).Select(a => a.LikerStatus).ToList();
            List<int> LikerFightersId=_context.Likes.Where(a=>a.LikedFighterId==StaticStuff.Fighter.Id).Select(a=>a.LikerId).ToList();
            foreach (int LikerFighterId in LikerFightersId)
            {
                bool liker = _context.Likes.Any(l => ((l.LikerId == StaticStuff.Fighter.Id && l.LikedFighterId== LikerFighterId)));
                bool likerstatus = _context.Likes.Any(l => ((l.LikerId == LikerFighterId) && (l.LikedFighterId == StaticStuff.Fighter.Id) && l.LikerStatus==true));
                if ((!liker) && (!likerstatus))
                {
                    var likerfighter = _context.Fighter.FirstOrDefault(a => LikerFighterId == a.Id);
                    if(likerfighter!=null)
                    {
                        _likerfighters.Add(likerfighter);
                    }
                }
                LikerFighters.Fighters = _likerfighters;
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (LikerFighters.Fighters.Count != 0)
            {
                Fighter selectedFighter = GetLikerFighter();
                var viewModel = new FighterViewModel
                {
                    AllTags = _context.Tags.ToList(),
                    SelectedFighter = selectedFighter
                };
                //LikerFighters.Flag = false;
                return View(viewModel);
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
        private Fighter GetLikerFighter()
        {
            var fighters = LikerFighters.Fighters;
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
                LikerFighters.Fighters = fighters;
                return selectedFighter;
            }
        }
        [HttpPost]
        public IActionResult Like(int fighterId)
        {
            var Likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == fighterId);
            List<Likes> OverLikes = new List<Likes>();
            if (Likedfighter != null)
            {
                var likes = new Likes();
                likes.LikerId = StaticStuff.Fighter.Id;
                likes.LikedFighterId = Likedfighter.Id;
                likes.IsLiked = true;
                likes.LikerStatus = true;
                _context.Likes.Add(likes);
                OverLikes = _context.Likes.Where(a => (Likedfighter.Id == a.LikedFighterId && StaticStuff.Fighter.Id == a.LikerId)).ToList();
                foreach(var OverLike in OverLikes)
                {
                    OverLike.LikerStatus = true; 
                    _context.Likes.Update(OverLike); 
                }
                //LikerFighters.Flag = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Dislike(int fighterId)
        {
            var Likedfighter = _context.Fighter.FirstOrDefault(a => a.Id == fighterId);
            List<Likes> OverLikes = new List<Likes>();
            if (Likedfighter != null)
            {
                var likes = new Likes();
                likes.LikerId = StaticStuff.Fighter.Id;
                likes.LikedFighterId = Likedfighter.Id;
                likes.IsLiked = false;
                likes.LikerStatus = true;
                _context.Likes.Add(likes);
                OverLikes = _context.Likes.Where(a => (Likedfighter.Id == a.LikedFighterId && StaticStuff.Fighter.Id == a.LikerId)).ToList();
                foreach (var OverLike in OverLikes)
                {
                    OverLike.LikerStatus = true;
                    _context.Likes.Update(OverLike);
                }
                //FighterForMatch.Flag = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Back()
        {
            return RedirectToAction("AccountHome", "Account");
        }
    }
    
}
