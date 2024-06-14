﻿using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
    public class user
    {
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public ICollection<Match> Matches { get; set; }
		public ICollection<Message> Messages { get; set; }

	}
}
