﻿using System.ComponentModel.DataAnnotations;

namespace OOP_BIG_PROJECT.Models
{
    public class User
    {
        public int ID { get; set; }

        //[Display(Name="Введите свой никнейм:")]
        //[Required(ErrorMessage ="Вам нужно ввести никнейм!")]
        public string Login { get; set; }

        //[Display(Name = "Введите пароль: ")]
        //[Required(ErrorMessage = "Вам нужно ввести пароль!")]
        public string Password { get; set; }

        public int Type { get; set; }



        //public User(string l, string p) {

        //    Login = l;
        //    Password = p;
        //}
    }
}