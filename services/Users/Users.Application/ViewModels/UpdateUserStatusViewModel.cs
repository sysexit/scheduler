using System.ComponentModel.DataAnnotations;

namespace Users.Application.ViewModels
{
    public class UpdateUserStatusViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }
}
