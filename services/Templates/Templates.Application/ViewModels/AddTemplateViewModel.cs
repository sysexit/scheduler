using System.ComponentModel.DataAnnotations;

namespace Templates.Application.ViewModels
{
    public class AddTemplateViewModel
    {
        [Required]
        public string Start { get; set; }

        [Required]
        public string End { get; set; }

        [Required]
        public int Position { get; set; }
    }
}
