namespace OOP_BIG_PROJECT.Models
{
	public abstract class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int AccountId { get; set; }

		public User User { get; set; }
	}
}
