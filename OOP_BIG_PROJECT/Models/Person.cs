namespace OOP_BIG_PROJECT.Models
{
	public abstract class Person
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public int AccountID { get; set; }

		public User User { get; set; }
	}
}
