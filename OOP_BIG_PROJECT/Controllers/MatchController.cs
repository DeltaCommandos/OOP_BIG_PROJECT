using Microsoft.AspNetCore.Mvc;
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

        public void Likes(FighterViewModel A)
        {
           
        }

        [HttpPost]
        public IActionResult Index(FighterViewModel A)
        {
            Fighter selectedFighter = GetRandomFighter();
            A.SelectedFighter = selectedFighter;

            _context.SaveChanges(); // Сохранение изменений в базу данных

            return RedirectToAction("Index"); // Перенаправление на GET-версию метода Index
        }

        [HttpGet]
        public IActionResult Index()
        {
            Fighter selectedFighter = GetRandomFighter();
            var response = new FighterViewModel
            {
                SelectedFighter = selectedFighter
            };

            return View(response);
        }
        private Fighter GetRandomFighter()
        {
            List<Fighter> Fighters = _context.Fighter.Where(a => a.Id != StaticStuff.Fighter.Id).ToList();
            Random random = new Random();

            if (Fighters.Count == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }

            int index = random.Next(Fighters.Count);
            Fighter selectedFighter = Fighters[index];
            Fighters.RemoveAt(index);

            return selectedFighter;
        }

    }

}


// Метод для создания матча
//public async Task<IActionResult> Create(int userId, int gameId, int venueId, DateTime scheduledTime)
//{
//	var match = new Match
//	{
//		//UserId1 = User.FindFirstValue(ClaimTypes.NameIdentifier),
//		UserId2 = userId,
//		GameId = gameId,
//		PlaceId = venueId,
//		ScheduledTime = scheduledTime,
//		IsAccepted = false
//	};

//	_context.Matches.Add(match);
//	await _context.SaveChangesAsync();

//	return RedirectToAction("Index", "Home");
//}

//// Метод для подтверждения матча
//[HttpPost]
//public async Task<IActionResult> Accept(int matchId)
//{
//	var match = await _context.Matches.FindAsync(matchId);
//	match.IsAccepted = true;
//	await _context.SaveChangesAsync();

//	return RedirectToAction("Index", "Home");
//}