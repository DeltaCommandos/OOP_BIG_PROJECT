using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOP_BIG_PROJECT.Models
{
    public class User
    {
        [Column("Id")]
        public int Id { get; set; }
		public  string Username { get; set; }
		public  string Password { get; set; }
		//public string Username { get; set; }
		public bool Status { get; set; }
        public bool AdminStatus { get; set; }
        public ICollection<Match>? Matches { get; set; }
		public ICollection<Messages>? MessageSend { get; set; }
        public ICollection<Messages>? MessageGot { get; set; }
        public ICollection<Match> MatchesAsUser1 { get; set; }
        public ICollection<Match> MatchesAsUser2 { get; set; }

    }
}
