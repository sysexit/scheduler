using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Application.ViewModels
{
    public class GetScheduleViewModel
    {
        [FromQuery]
        [Required]
        public Instant Start { get; set; }

        [FromQuery]
        [Required]
        public Instant End { get; set; }
    }
}
