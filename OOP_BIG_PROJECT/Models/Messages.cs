﻿using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
	public class Messages
	{
		[Key]
		public int Id { get; set; }
		public int? SenderId { get; set; }
		public int? ReceiverId { get; set; }
		public string? Content { get; set; }
		//public DateTime? Timestamp { get; set; }

		public User Sender { get; set; }
		public User Receiver { get; set; }
	}
}
