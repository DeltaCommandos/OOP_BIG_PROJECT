﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OOP_BIG_PROJECT.Models;


namespace OOP_BIG_PROJECT.Controllers
{
    public class MessageController : Controller
	{
		private readonly ApplicationContext _context;

		public MessageController(ApplicationContext context)
		{
			_context = context;
		}

		// Метод для отправки сообщения
		[HttpPost]
		public async Task<IActionResult> Send(int receiverId, string content)
		{
			var message = new Message
			{
				//SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier),
				ReceiverId = receiverId,
				Content = content 
				//,
    //            Timestamp = TimeSpan.
            };

			_context.Messages.Add(message);
			await _context.SaveChangesAsync();

			return RedirectToAction("Chat", new { receiverId });
		}

		// Метод для просмотра чата
		//public async Task<IActionResult> Chat(int receiverId)
		//{
		//	var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		//	var messages = await _context.Messages
		//		.Where(m => (m.SenderId == userId && m.ReceiverId == receiverId) ||
		//					(m.SenderId == receiverId && m.ReceiverId == userId))
		//		.OrderBy(m => m.Timestamp)
		//		.ToListAsync();

		//	return View(messages);
		//}
	
	}
}
