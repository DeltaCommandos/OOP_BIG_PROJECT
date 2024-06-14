namespace OOP_BIG_PROJECT.Models
{
	public class Match
	{
		public int MatchId { get; set; }
		public int UserId1 { get; set; }
		public int UserId2 { get; set; }
		public int GameId { get; set; }
		public int VenueId { get; set; }
		public DateTime ScheduledTime { get; set; }
		public bool IsAccepted { get; set; }

		public User User1 { get; set; }
		public User User2 { get; set; }
		public Game Game { get; set; }
		public Venue Venue { get; set; }
	}
}
