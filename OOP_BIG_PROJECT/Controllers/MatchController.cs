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
            // Обработка лайка - сохранение информации о лайке в базе данных или другая логика
            // В данном примере, просто перенаправляем на метод Index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Dislike(int fighterId)
        {
            // Обработка дизлайка - сохранение информации о дизлайке в базе данных или другая логика
            // В данном примере, просто перенаправляем на метод Index
            return RedirectToAction("Index");
        }

        private Fighter GetRandomFighter()
        {
            // Получаем список бойцов, исключая текущего пользователя (если нужно)
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
