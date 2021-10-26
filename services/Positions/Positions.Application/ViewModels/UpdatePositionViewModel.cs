using System.ComponentModel.DataAnnotations;

namespace Positions.Application.ViewModels
{
    public class UpdatePositionViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
