using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels
{
    public class OnboardViewModel
    {
        public string Display { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string First { get; set; }

        [Required]
        public string Last { get; set; }

        [Required]
        public int[] Positions { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
