using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
