using OOP_BIG_PROJECT.Models;
namespace OOP_BIG_PROJECT.ViewModels
{
    public class AllFighterViewModel
    {
        public List<Judgement> judges { get; set; }
        public List<MainDB> fights { get; set; }
		public Place place { get; set; }
        //public List<Diagnosis> diagnosis { get; set; }
		public Fighter fighter { get; set; }
        public List<Fighter> fighters { get; set; }
    }
}
