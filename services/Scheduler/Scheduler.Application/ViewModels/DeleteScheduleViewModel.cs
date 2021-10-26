using System.ComponentModel.DataAnnotations;

namespace Scheduler.Application.ViewModels
{
    public class DeleteScheduleViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
