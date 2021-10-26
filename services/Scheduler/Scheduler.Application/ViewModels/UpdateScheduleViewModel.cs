using NodaTime;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Application.ViewModels
{
    public class UpdateScheduleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public Instant Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public Instant End { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
