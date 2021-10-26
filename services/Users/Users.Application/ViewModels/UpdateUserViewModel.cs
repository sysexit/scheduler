using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Application.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string First { get; set; }
        [Required]
        public string Last { get; set; }
        [Required]
        public int[] Positions { get; set; }
        public string Display { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }
}
