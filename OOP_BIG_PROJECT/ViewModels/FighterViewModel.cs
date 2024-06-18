using OOP_BIG_PROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.ViewModels
{
    public class FighterViewModel
    { 
        public int FighterId { get; set; }

        public int Mode { get; set; }
        public Fighter SelectedFighter { get; set; }
    }
}
