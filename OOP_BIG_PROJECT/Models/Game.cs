namespace OOP_BIG_PROJECT.Models
{
	public class Game
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Match>? Matches { get; set; }
	}
}
