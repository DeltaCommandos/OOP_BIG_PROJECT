using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.ViewModels
{
	public class AllJudgeViewModel
	{
		public Judgement judge { get; set; }
		public List<Fighter> fighters { get; set; }
		public Place place { get; set; }
		public List<Place> places { get; set; }
		public List<MainDB> fights { get; set; }
        //public List<Diagnosis> diagnosis { get; set; }
        public Fighter fighter { get; set; }
		//public Diagnosis singlediagnosis { get; set; }
		public bool hasFights {  get; set; }
    }
}
