using System.ComponentModel.DataAnnotations;

namespace Positions.Application.ViewModels
{
    public class AddPositionViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
