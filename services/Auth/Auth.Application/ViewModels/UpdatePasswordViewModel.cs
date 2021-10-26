using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels
{
    public class UpdatePasswordViewModel
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string NewPasswordConfirm { get; set; }
    }
}
