namespace OOP_BIG_PROJECT.Models
{
	public class Place
	{
		public int PlaceId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public ICollection<Match> Matches { get; set; }
	}
}
