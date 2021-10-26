using System.ComponentModel.DataAnnotations;

namespace Templates.Application.ViewModels
{
    public class UpdateTemplateViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Start { get; set; }

        [Required]
        public string End { get; set; }

        [Required]
        public int Position { get; set; }
    }
}
