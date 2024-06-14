namespace OOP_BIG_PROJECT.Models
{
	public class Venue
	{
		public int VenueId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public ICollection<Match> Matches { get; set; }
	}
}
