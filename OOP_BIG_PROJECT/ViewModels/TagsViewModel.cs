using System.ComponentModel.DataAnnotations;
using OOP_BIG_PROJECT.Models;


namespace OOP_BIG_PROJECT.ViewModels
{
    public class TagsViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTagExisting { get; set; }
    }
}
