namespace OOP_BIG_PROJECT.Models
{
	public class Match
	{
		public int MatchId { get; set; }
		public int UserId1 { get; set; }
		public int UserId2 { get; set; }
		public int GameId { get; set; }
		public int PlaceId { get; set; }
		public DateTime ScheduledTime { get; set; }
		public bool IsAccepted { get; set; }

		public User User1 { get; set; }
		public User User2 { get; set; }
		public Game Game { get; set; }
		public Place Place { get; set; }
	}
}
