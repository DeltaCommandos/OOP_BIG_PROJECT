﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using OOP_BIG_PROJECT.ViewModels;

namespace OOP_BIG_PROJECT.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public int Likerld { get; set; }
        public int LikedUserld { get; set; }
        public bool IsLiked { get; set; }
    }
}
