namespace OOP_BIG_PROJECT.Models
{
    public class FighterForMatch
    {
        public static List<Fighter>? Fighters {  get; set; }
        public static List<Fighter>? SortedFighters { get; set; }
        public static bool Flag { get; set; }
        public static bool IsSorted { get; set; } = false;
    }
}
