//using Microsoft.AspNetCore.Mvc;
//using OOP_BIG_PROJECT.Data;
//using OOP_BIG_PROJECT.Models;
//using System.Security.Claims;

//namespace OOP_BIG_PROJECT.Controllers
//{
//    public class MatchController : Controller
//	{
//		private readonly ApplicationDbContext _context;

//		public MatchController(ApplicationDbContext context)
//		{
//			_context = context;
//		}

//		// Метод для создания матча
//		public async Task<IActionResult> Create(int userId, int gameId, int venueId, DateTime scheduledTime)
//		{
//			var match = new Match
//			{
//				//UserId1 = User.FindFirstValue(ClaimTypes.NameIdentifier),
//				UserId2 = userId,
//				GameId = gameId,
//				PlaceId = venueId,
//				ScheduledTime = scheduledTime,
//				IsAccepted = false
//			};

//			_context.Matches.Add(match);
//			await _context.SaveChangesAsync();

//			return RedirectToAction("Index", "Home");
//		}

//		// Метод для подтверждения матча
//		[HttpPost]
//		public async Task<IActionResult> Accept(int matchId)
//		{
//			var match = await _context.Matches.FindAsync(matchId);
//			match.IsAccepted = true;
//			await _context.SaveChangesAsync();

//			return RedirectToAction("Index", "Home");
//		}
//	}
//}
