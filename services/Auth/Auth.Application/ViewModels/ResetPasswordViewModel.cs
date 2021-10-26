using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string PasswordConfirm { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
