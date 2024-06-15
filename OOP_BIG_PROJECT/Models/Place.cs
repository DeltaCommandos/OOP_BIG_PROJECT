namespace OOP_BIG_PROJECT.Models
{
	public class Place
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public ICollection<Match> Matches { get; set; }
	}
}
