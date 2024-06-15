﻿using System.ComponentModel.DataAnnotations;
using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT.ViewModels
{
    public class RegisterViewModel:User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsUserExisting { get; set; }
        public User User { get; set; }

    }

}
