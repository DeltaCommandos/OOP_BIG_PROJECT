namespace OOP_BIG_PROJECT.Models
{
	public class Game
	{
		public int GameId { get; set; }
		public string Name { get; set; }
		public ICollection<Match> Matches { get; set; }
	}
}
