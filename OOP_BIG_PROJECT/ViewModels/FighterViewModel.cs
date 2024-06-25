using OOP_BIG_PROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.ViewModels
{
    public class FighterViewModel
    { 
        public int FighterId { get; set; }

        public int Mode { get; set; }
        public List<int> likedFighterIds { get; set; }
        public Fighter? SelectedFighter { get; set; } = null;
        public List<Tuple<Fighter, Fighter>> MutualLikes { get; set; }
        public  List<Tags> AllTags { get; set; }
        public int? SelectedTag1 { get; set; }
        public int? SelectedTag2 { get; set; }
        public int? SelectedTag3 { get; set; }
        public int? SelectedTag4 { get; set; }
        public int? SelectedTag5 { get; set; }
    }
}
