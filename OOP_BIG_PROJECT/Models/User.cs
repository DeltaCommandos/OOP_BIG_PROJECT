using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
    public class User
    {
        [Key]
		public int Id { get; set; }
		public  string Username { get; set; }
		public  string Password { get; set; }
		//public string Username { get; set; }
		public bool Status { get; set; }
        public bool AdminStatus { get; set; }
        public ICollection<Match>? Matches { get; set; }
		public ICollection<Message>? MessageSend { get; set; }
        public ICollection<Message>? MessageGot { get; set; }
        public ICollection<Match> MatchesAsUser1 { get; set; }
        public ICollection<Match> MatchesAsUser2 { get; set; }

    }
}
