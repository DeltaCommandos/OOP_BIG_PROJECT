using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
    public class User
    {
        [Display(Name="Введите свой никнейм:")]
        [Required(ErrorMessage ="Вам нужно ввести никнейм!")]
        public string Name { get; set; }

        [Display(Name = "Введите пароль: ")]
        [Required(ErrorMessage = "Вам нужно ввести пароль!")]
        public string Password { get; set; }

    }
}
